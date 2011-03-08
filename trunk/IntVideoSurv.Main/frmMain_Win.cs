using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Windows.Forms;
using CameraViewer.Controls;
using CameraViewer.NetWorking;
using CameraViewer.Remoting;
using DevExpress.XtraEditors;
using IntVideoSurv.Business;
using IntVideoSurv.Entity;
using CameraViewer.Forms;
using System.IO;
using IntVideoSurv.Business.HiK;
using System.Threading;
using System.Diagnostics;

namespace CameraViewer
{
    public partial class MainForm : XtraForm
    {
        public delegate void ImageDataChangeHandle(object sender, DataChangeEventArgs e);

        Dictionary<int, HikVideoServerDeviceDriver> _runningDeviceList;
        Dictionary<int, HikVideoServerCameraDriver> _runningCameraList;
        Dictionary<int, GroupInfo> _listGroup;
        string _errMessage = "";
        Dictionary<int, DeviceInfo> _listDevice;
        Dictionary<int, CameraInfo> _listCam;
        Dictionary<int, CameraInfo> _listAllCam;
        Dictionary<int, SynGroup> _listSynGroup;
        Dictionary<int, GroupSwitchGroup> _listGroupSwitchGroup;
        Dictionary<int, ProgSwitchInfo> _listProgSwitch;
        Dictionary<int, DisplayChannelInfo> _listDisplayChannelInfo;
        Dictionary<int, DefaultCardOut> _listDefaultCardOut;
        Dictionary<int, AlarmIconInfo> _listCurrentAlarmIcon;
        Dictionary<int, CameraIconInfo> _listCurrentCameraIcon;
        Dictionary<int, AlarmIconInfo> _listAllAlarmIcon;
        Dictionary<int, CameraIconInfo> _listAllCameraIcon;
        Dictionary<int, AlarmInfo> _listAlarm;
        Dictionary<int, MapInfo> _listMap;
        OutputTVDeviceDriver _outputTv;
        TcpChannel chan1;
        private MapInfo currentMapInfo;


        private GetTransPacket _getTransPacket;

        public MainForm()
        {
            #if !DEBUG
            while (Login(_inputUsername, _inputPassword, PromoteInfo) != true)
            {
                PromoteInfo = "请输入正确的用户名和密码!";
            }
            #else
            CurrentUser = new UserInfo { UserId = 1, UserName = "admin", UserTypeId = 1, UserTypeName = "管理员" };
            #endif
            Splash.Splash.Show();
            this.Visible = false;
            Splash.Splash.Status = "启动.Net Remoting...";
            BeginRemotingService();
            Splash.Splash.Status = "启动流媒体服务...";
            BeginStreamMediaService();

            InitializeComponent();


            _getTransPacket = new GetTransPacket();
            _getTransPacket.LivePacketHandle.DataChange += LivePacketHandleDataChange;

            //start tcp server
            var thread = new Thread(StartServer) { IsBackground = true };
            thread.Start();

            
        }
        private void BeginRemotingService()
        {
            chan1 = new TcpChannel(8085);
            ChannelServices.RegisterChannel(chan1,false);
            RemotingConfiguration.RegisterWellKnownServiceType
                (
                typeof(SMUserService),
                "SMUserService",
                WellKnownObjectMode.Singleton
                );
        }
        private void BeginStreamMediaService()
        {
            int iret = HikStreamMediaServerSDK.InitStreamServerLib();
            if (Directory.Exists(AppSettings.Default.StreamMediaServicePath))
            {
                Directory.CreateDirectory(AppSettings.Default.StreamMediaServicePath);
            }
            iret = HikStreamMediaServerSDK.StartServer(AppSettings.Default.StreamMediaServicePath, 554);
            iret = HikStreamMediaServerSDK.RunServer();//未使用
        }
        void CameraView1DoubleSynGroup(string tag)
        {
            _isProgSwitchView = false;
            //splitContainerControl1.SplitterPosition = splitContainerControl1.Height - tlpBottom.Height;
            //XtraMessageBox.Show(tag);
            string[] strs = tag.Split(';');
            if (strs.Length == 2)
            {
                DispalySynCamera(int.Parse(strs[0]));
            }
        }

        void DispalyProgSwitch(int progSwitchId, int cameraId, int displayChannelId, int displaySplitScreenNo)
        {
            try
            {
                int iRow = 1;
                int iCol = 1;
                mainMultiplexer.CloseAll();
                mainMultiplexer.CamerasVisible = true;
                mainMultiplexer.CellWidth = 320;
                mainMultiplexer.CellHeight = 240;
                mainMultiplexer.FitToWindow = true;
                CloseAll();

                HikVideoServerDeviceDriver deviceDriver;
                HikVideoServerCameraDriver cameraDriver = null;
                HikVideoServerCameraDriver cameraDriver1;
                DeviceInfo oDevice;

                CameraInfo camera = _listAllCam[cameraId];
                oDevice = _listDevice[camera.DeviceId];
                if (!_runningDeviceList.ContainsKey(camera.DeviceId))
                {
                    deviceDriver = new HikVideoServerDeviceDriver();
                    deviceDriver.Init(ref oDevice);
                    _runningDeviceList.Add(camera.DeviceId, deviceDriver);
                }

                if (_runningDeviceList[camera.DeviceId].IsValidDevice)
                {
                    oDevice.ServiceID = _runningDeviceList[camera.DeviceId].ServiceId;
                    if (!_runningCameraList.ContainsKey(camera.CameraId))
                    {
                        camera.ListOutputTarget = new ArrayList();
                        cameraDriver = new HikVideoServerCameraDriver(oDevice);
                        cameraDriver.CurrentCamera = camera;
                        camera.TotalDSP = _outputTv.TotalDSP;
                        _runningCameraList.Add(camera.CameraId, cameraDriver);
                    }

                }



                CameraWindow camwin = mainMultiplexer.GetCamera(0, 0);
                cameraDriver1 = _runningCameraList[camera.CameraId];
                cameraDriver1.CurrentCamera.ListOutputTarget.Add(new DisplayHandlePair { DisplayChannelId = displayChannelId, DisplaySplitScreenNo =displaySplitScreenNo,Handle=camwin.Handle });
                _runningCameraList[camera.CameraId] = cameraDriver1;
                mainMultiplexer.SetCamera(0, 0, cameraDriver);

                foreach (KeyValuePair<int, HikVideoServerCameraDriver> item in _runningCameraList)
                {
                    item.Value.Start(item.Value.CurrentCamera, CardOutType.ProgSwitch, progSwitchId);
                }

                mainMultiplexer.Rows = iRow;
                mainMultiplexer.Cols = iCol;
                mainMultiplexer.SingleCameraMode = false;
                mainMultiplexer.CamerasVisible = true;
            }
            catch (Exception ex)
            {

            }



        }

        void DispalySynCamera(int synGroupId)
        {
            try
            {

                List<SynCameraInfo> listSynCamera = SynGroupBusiness.Instance.GetAllCameraBySynGroupId(ref _errMessage, synGroupId);


                int iRow = 1;
                int iCol = 1;
                int iCount = 1;
                mainMultiplexer.CloseAll();
                mainMultiplexer.CamerasVisible = true;
                mainMultiplexer.CellWidth = 320;
                mainMultiplexer.CellHeight = 240;
                mainMultiplexer.FitToWindow = true;
                CloseAll();

                HikVideoServerDeviceDriver deviceDriver = null;
                HikVideoServerCameraDriver cameraDriver = null;
                HikVideoServerCameraDriver cameraDriver1 = null;
                DeviceInfo oDevice;
                int OutputPort = 0;
                int i = 0;
                int j = 0;
                iCount = listSynCamera.Count;
                Util.GetRowCol(iCount, ref iRow, ref iCol);

                int cameraId1 = 0;
                int cameraId2 = 0;
                CameraInfo camera = null;
                foreach (SynCameraInfo item in listSynCamera)
                {

                    camera = _listAllCam[item.CameraId];
                    oDevice = _listDevice[camera.DeviceId];
                    if (!_runningDeviceList.ContainsKey(camera.DeviceId))
                    {
                        deviceDriver = new HikVideoServerDeviceDriver();
                        deviceDriver.Init(ref oDevice);
                        _runningDeviceList.Add(camera.DeviceId, deviceDriver);
                    }

                    if (_runningDeviceList[camera.DeviceId].IsValidDevice)
                    {
                        oDevice.ServiceID = _runningDeviceList[camera.DeviceId].ServiceId;
                        if (!_runningCameraList.ContainsKey(camera.CameraId))
                        {
                            camera.ListOutputTarget = new ArrayList();
                            cameraDriver = new HikVideoServerCameraDriver(oDevice);
                            cameraDriver.CurrentCamera = camera;
                            camera.TotalDSP = _outputTv.TotalDSP;
                            _runningCameraList.Add(camera.CameraId, cameraDriver);
                        }

                    }
                    CameraWindow camwin = mainMultiplexer.GetCamera(i, j);
                    cameraDriver1 = _runningCameraList[camera.CameraId];
                    cameraDriver1.CurrentCamera.ListOutputTarget.Add(new DisplayHandlePair { DisplayChannelId = item.DisplayChannelId, DisplaySplitScreenNo = item.DisplaySplitScreenNo, Handle = camwin.Handle });
                    _runningCameraList[camera.CameraId] = cameraDriver1;
                    mainMultiplexer.SetCamera(i, j, cameraDriver);
                    j = j + 1;
                    if (j >= iCol)
                    {
                        i = i + 1;
                        j = 0;
                    }

                }
                foreach (KeyValuePair<int, HikVideoServerCameraDriver> item in _runningCameraList)
                {
                    item.Value.Start(item.Value.CurrentCamera, CardOutType.SynGroup, synGroupId);
                }

                mainMultiplexer.Rows = iRow;
                mainMultiplexer.Cols = iCol;
                mainMultiplexer.SingleCameraMode = false;
                mainMultiplexer.CamerasVisible = true;
            }
            catch (Exception ex)
            {

            }



        }
             
        private void ViewCameraByDeviceId(int deviceId)
        {
            //18607550721
            int iRow = 1;
            int iCol = 1;
            int iCount = 1;
            mainMultiplexer.CloseAll();
            mainMultiplexer.CamerasVisible = true;
            mainMultiplexer.CellWidth = 320;
            mainMultiplexer.CellHeight = 240;
            mainMultiplexer.FitToWindow = true;
            CloseAll();

            HikVideoServerDeviceDriver deviceDriver;
            HikVideoServerCameraDriver cameraDriver;
            DeviceInfo oDevice;
            oDevice = _listDevice[deviceId];
            int i = 0;
            int j = 0;
            iCount = oDevice.ListCamera.Count;
            Util.GetRowCol(iCount, ref iRow, ref iCol);
            foreach (KeyValuePair<int, CameraInfo> item in oDevice.ListCamera)
            {

                CameraInfo camera = item.Value;
                CameraWindow camwin = mainMultiplexer.GetCamera(i, j);
                camera.Handle = camwin.Handle;

                oDevice.Handle = camwin.Handle;
                if (!_runningDeviceList.ContainsKey(camera.DeviceId))
                {
                    deviceDriver = new HikVideoServerDeviceDriver();
                    deviceDriver.Init(ref oDevice);
                    _runningDeviceList.Add(camera.DeviceId, deviceDriver);
                }
                if (!_runningDeviceList[camera.DeviceId].IsValidDevice)
                {
                    j = j + 1;
                    continue;

                }
                oDevice.ServiceID = _runningDeviceList[camera.DeviceId].ServiceId;
                if (!_runningCameraList.ContainsKey(camera.CameraId))
                {
                    cameraDriver = new HikVideoServerCameraDriver(oDevice);
                    cameraDriver.Start(camera);
                    _runningCameraList.Add(camera.CameraId, cameraDriver);
                    mainMultiplexer.SetCamera(i, j, cameraDriver);
                    
                }
                j = j + 1;
                if (j >= iCol)
                {
                    i = i + 1;
                    j = 0;
                }

            }

            mainMultiplexer.Rows = iRow;
            mainMultiplexer.Cols = iCol;
            mainMultiplexer.SingleCameraMode = false;
            mainMultiplexer.CamerasVisible = true;


        }
       
        private void ViewCameraByCameraId(int carmeraId)
        {

            try
            {
	            mainMultiplexer.CamerasVisible = true;
	            mainMultiplexer.CellWidth = 320;
	            mainMultiplexer.CellHeight = 240;
	            mainMultiplexer.FitToWindow = true;
	            HikVideoServerDeviceDriver deviceDriver;
	            HikVideoServerCameraDriver cameraDriver;
	            DeviceInfo oDevice;
	            CameraInfo camera = _listAllCam[carmeraId];
                CameraWindow camwin = mainMultiplexer.GetCurrentCameraWindow();
	            camera.Handle = camwin.Handle;
	            oDevice = _listDevice[camera.DeviceId];
	            oDevice.Handle = camwin.Handle;
	            if (!_runningDeviceList.ContainsKey(camera.DeviceId))
	            {
	                deviceDriver = new HikVideoServerDeviceDriver();
	                deviceDriver.Init(ref oDevice);
	                _runningDeviceList.Add(camera.DeviceId, deviceDriver);
	            }
	
	            oDevice.ServiceID = _runningDeviceList[camera.DeviceId].ServiceId;
	            if (!_runningCameraList.ContainsKey(camera.CameraId))
	            {
	                cameraDriver = new HikVideoServerCameraDriver(oDevice);
	                cameraDriver.Start(camera);
	                _runningCameraList.Add(camera.CameraId, cameraDriver);
	                mainMultiplexer.SetCamera(camwin, cameraDriver);
	            }
	            else
	            {
	                cameraDriver = _runningCameraList[camera.CameraId];
	                _runningCameraList.Remove(camera.CameraId);
	                cameraDriver.Stop();
	                cameraDriver.Close();
	                cameraDriver.Start(camera);
	                _runningCameraList.Add(camera.CameraId, cameraDriver);
	                mainMultiplexer.SetCamera(camwin, cameraDriver);
	            }
	            mainMultiplexer.CamerasVisible = true;
            }
            catch (System.Exception ex)
            {
            	
            }
            finally
            {
            }

        }
        
        private void CloseAll()
        {
            foreach (KeyValuePair<int, HikVideoServerCameraDriver> item in _runningCameraList)
            {
                item.Value.Close();
            }
            _runningCameraList.Clear();
            foreach (KeyValuePair<int, HikVideoServerDeviceDriver> item in _runningDeviceList)
            {
                item.Value.Close();
            }
            _runningDeviceList.Clear();
        }
        
        void CameraView1DoubleSynGroup(KeyValuePair<int, SynGroup> item)
        {

        }

        private void xtraTabControl2_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            switch (e.Page.TabIndex)
            {
                case 0:
                    _listGroup = GroupBusiness.Instance.GetAllGroupInfos(ref _errMessage);
                    _listMap = MapBusiness.Instance.GetAllMapInfo(ref _errMessage);
                    cameraView1.ListGroup = _listGroup;
                    cameraView1.ListMap = _listMap;
                    break;
                case 1:
                    _listSynGroup = SynGroupBusiness.Instance.GetAllSynGroups(ref _errMessage);
                    cameraView1.ListSynGroup = _listSynGroup;
                    break;                    
                case 2:
                    _listGroupSwitchGroup = GroupSwitchGroupBusiness.Instance.GetAllGroupSwitchGroups(ref _errMessage);
                    cameraView1.ListGroupSwitch = _listGroupSwitchGroup;
                    break;
                case 3:
                    _listProgSwitch = ProgSwitchBusiness.Instance.GetAllProgSwitchs(ref _errMessage);
                    cameraView1.ListProgSwitch = _listProgSwitch;
                    break;   
                default:
                    _listGroup = GroupBusiness.Instance.GetAllGroupInfos(ref _errMessage);
                    cameraView1.ListGroup = _listGroup;
                    break;
            }
        }

        private void tvSynGroup_DoubleClick(object sender, EventArgs e)
        {
            _isProgSwitchView = false;
            //splitContainerControl1.SplitterPosition = splitContainerControl1.Height - tlpBottom.Height;
            //XtraMessageBox.Show(DateTime.Now.ToString());
        }
        /// <summary>
        /// load all camera
        /// </summary>
        private void LoadAllCamera()
        {
            if (_listGroup == null) return;
            int iRow = 2;
            int iCol = 2;
            int iCount = 0;
            mainMultiplexer.CloseAll();
            mainMultiplexer.CamerasVisible = true;
            mainMultiplexer.CellWidth = 320;
            mainMultiplexer.CellHeight = 240;
            mainMultiplexer.FitToWindow = true;
            _listCam = new Dictionary<int, CameraInfo>();
            HikVideoServerDeviceDriver deviceDriver;
            HikVideoServerCameraDriver cameraDriver;
            switch (cameraView1.ViewType)
            {
                case EnumViewType.Normal:
                    foreach (KeyValuePair<int, GroupInfo> item in _listGroup)
                    {
                        if (item.Value.ListDevice != null)
                        {
                            foreach (KeyValuePair<int, DeviceInfo> device in item.Value.ListDevice)
                            {
                                if (device.Value.ListCamera != null)
                                {
                                    foreach (KeyValuePair<int, CameraInfo> camera in device.Value.ListCamera)
                                    {
                                        if (camera.Value.IsValid)
                                        {

                                            //runninPool.Add(device.Value, camera.Value);
                                            _listCam.Add(iCount, camera.Value);
                                            iCount = iCount + 1;
                                        }

                                    }
                                }
                            }
                        }

                    }
                    break;

                case EnumViewType.SynSwitch:
                    foreach (KeyValuePair<int, SynGroup> item in _listSynGroup)
                    {
                        foreach (KeyValuePair<int, CameraInfo> camera in item.Value.ListCamera)
                        {
                            if (camera.Value.IsValid)
                            {

                                //runninPool.Add(device.Value, camera.Value);
                                _listCam.Add(iCount, camera.Value);
                                iCount = iCount + 1;
                            }
                        }
                    }
                    break;

                default:
                    break;

            }

            Util.GetRowCol(iCount, ref iRow, ref iCol);
            iCount = 0;
            VideoOutputInfo videoInfo;
            //VideoOutputDriver videoDriver;
            DeviceInfo oDevice;
            DeviceInfo oDeviceHandle;
            int OutputPort = 0;
            for (int i = 0; i < iRow; i++)
            {
                for (int j = 0; j < iCol; j++)
                {
                    // get camera
                    if (_listCam.ContainsKey(iCount))
                    {
                        CameraInfo camera = _listCam[iCount];
                        CameraWindow camwin = mainMultiplexer.GetCamera(i, j);
                        camera.Handle = camwin.Handle;
                        oDevice = _listDevice[camera.DeviceId];
                        // oDevice.Handle = camwin.Handle;
                        oDevice.Handle = this.Handle;
                        if (!_runningDeviceList.ContainsKey(camera.DeviceId))
                        {
                            deviceDriver = new HikVideoServerDeviceDriver();
                            deviceDriver.Init(ref oDevice);
                            _runningDeviceList.Add(camera.DeviceId, deviceDriver);
                        }
                        if (!_runningDeviceList[camera.DeviceId].IsValidDevice)
                        {
                            iCount = iCount + 1;
                            continue;

                        }
                        oDevice.ServiceID = _runningDeviceList[camera.DeviceId].ServiceId;
                        if (!_runningCameraList.ContainsKey(camera.CameraId))
                        {
                            cameraDriver = new HikVideoServerCameraDriver(oDevice);
                            cameraDriver.Start(camera,CardOutType.DefaultDisplay,1);
                            _runningCameraList.Add(camera.CameraId, cameraDriver);
                            mainMultiplexer.SetCamera(i, j, cameraDriver);
                        }


                        //runningPool.Add(camwin, oDevice, camera);
                        if (OutputPort < 2)
                        {
                            videoInfo = new VideoOutputInfo();
                            videoInfo.CameraId = camera.CameraId;
                            videoInfo.OutputPort = OutputPort;

                            OutputPort = OutputPort + 1;

                        }
                        iCount = iCount + 1;

                    }

                }
            }
            mainMultiplexer.Rows = iRow;
            mainMultiplexer.Cols = iCol;
            mainMultiplexer.SingleCameraMode = false;
            mainMultiplexer.CamerasVisible = true;
        }

        private bool _isFullScreen;
        public void FullScreen(bool isFullScreen)
        {
            
            bar2.Visible = !isFullScreen;
            cameraView1.Visible = !isFullScreen;
            _isFullScreen = isFullScreen;
            if (_isFullScreen)
            {
                //splitContainerControl1.SplitterPosition = splitContainerControl1.Height+2;
            }
            else
            {
                //splitContainerControl1.SplitterPosition = splitContainerControl1.Height - tlpBottom.Height;

            }

        }
        private void Exit()
        {

            this.Close();

        }
        private void barbtnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Exit();

        }

        private void frmMain_Win_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Exit();
            }
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmSetting setting = new frmSetting();
            setting.ShowDialog(this);
        }

        private void multiplexer1_DoubleCamera(bool isFullScreen, CameraInfo camera)
        {
            this.FullScreen(isFullScreen);
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            HikVideoServerCameraDriver driver = mainMultiplexer.GetCurrentCameraDriver;
            if (driver == null)
            {
                XtraMessageBox.Show("请选择你要抓拍的摄象机!");
                return;
            }
            byte[] imageBuf = new byte[704 * 576 * 2];
            int Rtn = driver.GetJpegImage(ref imageBuf);
            using (MemoryStream ms = new MemoryStream(imageBuf))
            {
                Image image = Image.FromStream(ms, true);
                image.Save(string.Format("C:\\{0}_{1}.jpg", driver.CurrentCamera.Name, Guid.NewGuid().ToString()));
            }

        }

        private void cameraView1_Load(object sender, EventArgs e)
        {

        }

        private void frmMain_Win_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (!(XtraMessageBox.Show(this, "你确信要退出系统吗?", "请注意", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
                {
                    e.Cancel = true;

                    return;
                }

                SystemLogBusiness.Instance.Insert(ref _errMessage, new SystemLog
                    {
                        HappenTime = DateTime.Now,
                        SystemTypeId = 3,
                        SystemTypeName = "用户退出成功",
                        Content = "用户退出成功",
                        SyeUserName = CurrentUser.UserName,
                        ClientUserId = CurrentUser.UserId,
                        ClientUserName = CurrentUser.UserName

                    });
                CloseAll();
                _outputTv.Close();
                ChannelServices.UnregisterChannel(chan1);
                HikStreamMediaServerSDK.FiniStreamServerLib();
            }
            catch (Exception ex)
            {

            }
        }

        #region 登录相关
        public static UserInfo CurrentUser = new UserInfo();
        private static MainForm _instance;
        public static MainForm Instance
        {
            get { return _instance ?? (_instance = new MainForm()); }
        }

        private string _inputPassword = "";
        private string _inputUsername = "";
        private string PromoteInfo = "";

        private bool Login(string iu, string ip, string pi)
        {

            FormLogin lf = new FormLogin(iu, ip, pi);
            if (lf.ShowDialog(this) == DialogResult.OK)
            {
                _inputUsername = lf.InputUsername;
                _inputPassword = lf.InputPassword;
                if (lf.isLoginOK == true)
                {
                    CurrentUser = lf.currentUser;
                    return true;
                }
                return false;
            }
            System.Diagnostics.Process.GetCurrentProcess().Kill();
            return false;
        }
        #endregion

        #region 界面过滤

        private void FilterInterface()
        {
            if (CurrentUser.UserTypeName != "管理员")
            {
                if (barButtonItem1 != null)
                {
                    this.barButtonItem1.ItemClick -= barButtonItem1_ItemClick;
                    this.barButtonItem1.ItemClick += this.barButtonItem1_ItemClick_UpdateUser;
                }

            }
        }

        private void barButtonItem1_ItemClick_UpdateUser(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frmUser = new FrmUser(CurrentUser);
            frmUser.ShowDialog();
        }

        #endregion
        #region prog switch
        void cameraView1_DoubleProgSwitch(string tag)
        {
            _isProgSwitchView = true;
            //splitContainerControl1.SplitterPosition = splitContainerControl1.Height + 2;
            //  XtraMessageBox.Show(tag);
            //XtraMessageBox.Show(tag);
            string[] strs = tag.Split(';');
            DateTime dt1;
            DateTime dt2;
            if (strs.Length == 2)
            {

                ProgSwitchInfo oProgSwitchInfo = ProgSwitchBusiness.Instance.GetProgSwitchById(ref _errMessage, int.Parse(strs[0]));
                while (true)
                {
                    //DispalyProgSwitch
                    foreach (KeyValuePair<int, ProgSwitchDetailInfo> item in oProgSwitchInfo.ListProgSwitchDetailInfo)
                    {
                        if (isStop)
                        {
                            break;
                        }
                        DispalyProgSwitch(oProgSwitchInfo.Id, item.Value.CameraId, oProgSwitchInfo.DisplayChannelId, oProgSwitchInfo.DisplaySplitScreenNo);
                        dt1 = DateTime.Now.AddSeconds(item.Value.TickTime);
                        while (true)
                        {
                            if (isStop)
                            {
                                break;
                            }
                            if (DateTime.Now.CompareTo(dt1) >= 0)
                            {
                                break;
                            }
                            Thread.Sleep(100);
                            Application.DoEvents();

                        }


                    }
                    if (isStop)
                    {
                        break;
                    }
                    Application.DoEvents();
                }
                isStop = false;

            }
        }
        #endregion


        bool isStop = false;
        #region syn switch
        void cameraView1_DoubleSynSwitch(string tag)
        {
            _isProgSwitchView = false;
            //splitContainerControl1.SplitterPosition = splitContainerControl1.Height - tlpBottom.Height;
            //XtraMessageBox.Show(tag);
            string[] strs = tag.Split(';');
            DateTime dt1;
            DateTime dt2;
            
            if (strs.Length == 2)
            {
                List<GroupSwitchDetailInfo> list = GroupSwitchDetailBusiness.Instance.GetGroupSwitchDetailByGroupSwitchId(ref _errMessage, int.Parse(strs[0]));
                if(list==null) return;
                while (true)
                {
                    foreach (GroupSwitchDetailInfo item in list)
                    {
                        if (isStop)
                        {
                            break;
                        }
                        
                        DispalySynCamera(item.SynGroupId);
                        dt1 = DateTime.Now.AddSeconds(item.TickTime);
                        while (true)
                        {
                            if (isStop)
                            {
                                break;
                            }
                            if (DateTime.Now.CompareTo(dt1) >= 0)
                            {
                                break;
                            }
                            Thread.Sleep(100);
                            Application.DoEvents();

                        }


                    }
                    if (isStop)
                    {
                        break;
                    }
                    Application.DoEvents();
                }
                isStop = false;

            }
        }
        #endregion

        private void frmMain_Win_Load(object sender, EventArgs e)
        {
            this.Visible = false;
            FilterInterface();

            Splash.Splash.Status = "获取群组信息...";
            _runningDeviceList = new Dictionary<int, HikVideoServerDeviceDriver>();
            _listGroup = GroupBusiness.Instance.GetAllGroupInfos(ref _errMessage);
            cameraView1.ListGroup = _listGroup;
            Splash.Splash.Status = "初始化板卡...";
            _outputTv = new OutputTVDeviceDriver();
            _outputTv.Init();
            HikVideoServerCameraDriver.InitDecodeCard();
            Splash.Splash.Status = "获取解码卡信息...";
            _listDisplayChannelInfo = DisplayChannelBusiness.Instance.GetAllDisplayChannelInfo(ref _errMessage);
            InitDisplayRegion();

            Splash.Splash.Status = "获取设备信息...";
            _listDevice = DeviceBusiness.Instance.GetAllDeviceInfo(ref _errMessage);
            Splash.Splash.Status = "获取摄像头信息...";
            //videoOutList = new Dictionary<VideoOutputInfo, VideoOutputDriver>();
            _runningCameraList = new Dictionary<int, HikVideoServerCameraDriver>();
            _listAllCam = CameraBusiness.Instance.GetAllCameraInfo(ref _errMessage);

            Splash.Splash.Status = "获取同步群组信息...";
            _listSynGroup = SynGroupBusiness.Instance.GetAllSynGroups(ref _errMessage);
            cameraView1.ListSynGroup = _listSynGroup;
            Splash.Splash.Status = "获取群组切换信息...";
            _listGroupSwitchGroup = GroupSwitchGroupBusiness.Instance.GetAllGroupSwitchGroups(ref _errMessage);
            cameraView1.ListGroupSwitch = _listGroupSwitchGroup;
            Splash.Splash.Status = "获取程序切换信息...";
            _listProgSwitch = ProgSwitchBusiness.Instance.GetAllProgSwitchs(ref _errMessage);
            cameraView1.ListProgSwitch = _listProgSwitch;
            Splash.Splash.Status = "获取默认硬解码输出列表...";
            _listDefaultCardOut = DefaultCardOutBusiness.Instance.GetAllDefaultCardOuts(ref _errMessage);
            HikVideoServerCameraDriver.ListDefaultCardOut = _listDefaultCardOut;
            Splash.Splash.Status = "载入摄像头...";
            LoadAllCamera();
            _listAlarm = AlarmBusiness.Instance.GetAllAlarmInfo(ref _errMessage);
            SetDefaultAlarmSwitchPictureBox();
            Splash.Splash.Status = "载入地图...";
            _listMap = MapBusiness.Instance.GetAllMapInfo(ref _errMessage);
            cameraView1.ListMap = _listMap;
            _listAllAlarmIcon = AlarmIconBusiness.Instance.GetAllAlarmIconInfo(ref _errMessage);
            _listAllCameraIcon = CameraIconBusiness.Instance.GetAllCameraIconInfo(ref _errMessage);
            foreach (var VARIABLE in _listMap)
            {
                currentMapInfo = VARIABLE.Value; 
                DrawIconInMap();
                break;
            }

            this.cameraView1.tvSynGroup.DoubleClick += this.tvSynGroup_DoubleClick;
            this.cameraView1.xtraTabControl2.SelectedPageChanged += this.xtraTabControl2_SelectedPageChanged;
            this.cameraView1.DoubleSynGroup += new CameraView.TouchCamera(CameraView1DoubleSynGroup);
            this.cameraView1.DoubleDevCam += new CameraView.TouchCamera(cameraView1_DoubleDevCam);

            this.cameraView1.DoubleSynSwitch += new CameraView.TouchCamera(cameraView1_DoubleSynSwitch);

            this.cameraView1.DoubleProgSwitch += new CameraView.TouchCamera(cameraView1_DoubleProgSwitch);
            //Debug.WriteLine("End frmMain_Win_Load" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss fff"));
            Splash.Splash.Status = "初始化完毕!";
            Splash.Splash.Close();
            //HikVideoServerCameraDriver.InitDecodeCard();
            this.Visible = true;
        }

        private void InitDisplayRegion()
        {
            DISPLAY_PARA struCardPlayInfo = new DISPLAY_PARA();
            struCardPlayInfo.nLeft = 0;
            struCardPlayInfo.nTop = 0;
            struCardPlayInfo.nWidth = 704;
            struCardPlayInfo.nHeight = 576;
            struCardPlayInfo.bToScreen = 0;
            struCardPlayInfo.bToVideoOut = 1;
            if (_listDisplayChannelInfo==null) return;
            foreach (var displayChannelInfo in _listDisplayChannelInfo)
            {
                InitDisplayRegion(displayChannelInfo.Key);
            }
        }
        private void InitDisplayRegion(int displayChannelInfoId)
        {
            DISPLAY_PARA struCardPlayInfo = new DISPLAY_PARA();
            struCardPlayInfo.nLeft = 0;
            struCardPlayInfo.nTop = 0;
            struCardPlayInfo.nWidth = 704;
            struCardPlayInfo.nHeight = 576;
            struCardPlayInfo.bToScreen = 0;
            struCardPlayInfo.bToVideoOut = 1;
            int iRtn = HikVisionSDK.SetDisplayStandard(displayChannelInfoId, VideoStandard_t.StandardPAL);
            REGION_PARAM[] struDisplayRegion = HikVideoServerCameraDriver.GetStruDisplayRegion(struCardPlayInfo, _listDisplayChannelInfo[displayChannelInfoId].SplitScreenNo);
            iRtn = HikVisionSDK.SetDisplayRegion(displayChannelInfoId, _listDisplayChannelInfo[displayChannelInfoId].SplitScreenNo, ref struDisplayRegion[0], 0);
            
        }
        private void frmMain_Win_Resize(object sender, EventArgs e)
        {
            //tlpBottom.Left = splitContainerControl1.Panel2.Left;
            //splitContainerControl1.SplitterPosition = splitContainerControl1.Height - tlpBottom.Height;
        }

        private bool _isProgSwitchView;
        private void splitContainerControl1_Panel2_Resize(object sender, EventArgs e)
        {
/*
            if ((_isFullScreen) || _isProgSwitchView)
            {
                splitContainerControl1.SplitterPosition = splitContainerControl1.Height + 2;

            }
            else
            {
                splitContainerControl1.SplitterPosition = splitContainerControl1.Height - tlpBottom.Height;

            }*/

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int iRow = 1, iCol = 1;
            Util.GetRowCol(1, ref iRow, ref iCol);
            mainMultiplexer.Rows = iRow;
            mainMultiplexer.Cols = iCol;
            mainMultiplexer.Refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int iRow = 2, iCol = 2;
            Util.GetRowCol(4, ref iRow, ref iCol);
            mainMultiplexer.Rows = iRow;
            mainMultiplexer.Cols = iCol;
            mainMultiplexer.Refresh();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int iRow = 3, iCol = 3;
            Util.GetRowCol(9, ref iRow, ref iCol);
            mainMultiplexer.Rows = iRow;
            mainMultiplexer.Cols = iCol;
            mainMultiplexer.Refresh();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int iRow = 4, iCol = 4;
            Util.GetRowCol(16, ref iRow, ref iCol);
            mainMultiplexer.Rows = iRow;
            mainMultiplexer.Cols = iCol;
            mainMultiplexer.Refresh();
        }

        private bool switchmap;
        private void pictureBoxMap_DoubleClick(object sender, EventArgs e)
        {
/*
            if (!switchmap)
            {
                mainMultiplexer.Parent = pcMap;
                pictureBoxMap.Parent = this;
                pictureBoxMap.Dock = System.Windows.Forms.DockStyle.Fill;
            }
            else
            {
                mainMultiplexer.Parent = this;
                mainMultiplexer.Dock = System.Windows.Forms.DockStyle.Fill;
                pictureBoxMap.Parent = pcMap;      
            }
            switchmap = !switchmap;*/

        }

        private Point mouse_offset;
        private void pcCreatedAlarm_MouseDown(object sender, MouseEventArgs e)
        {
            mouse_offset = new Point(-e.X, -e.Y);//
            targetCameraPictureBox = null;
        }

        private PictureBox targetCameraPictureBox;
        private void pcCreatedAlarm_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBoxMap.Refresh();
            ((Control)sender).Cursor = Cursors.Arrow;//设置拖动时鼠标箭头
            if (e.Button == MouseButtons.Left)
            {
                Point mousePos = Control.MousePosition;
                mousePos.Offset(mouse_offset.X, mouse_offset.Y);//设置偏移
                ((Control)sender).Location = ((Control)sender).Parent.PointToClient(mousePos);
                double distance = double.MaxValue;
                Point targetPotint = new Point(100,100);
                for (int i = pictureBoxMap.Controls.Count - 1; i >= 0; i--)
                {
                    var VARIABLE = pictureBoxMap.Controls[i];
                    if (VARIABLE is PictureBox)
                    {
                        if (VARIABLE.Name.StartsWith("pcCreatedCamera"))
                        {
                            double newDistance =
                                Math.Sqrt(Math.Pow(((PictureBox) sender).Left - VARIABLE.Left, 2) +
                                          Math.Pow(((PictureBox) sender).Top - VARIABLE.Top, 2));
                            if (newDistance < distance)
                            {
                                targetPotint = new Point(VARIABLE.Left, VARIABLE.Top);
                                distance = newDistance;
                                targetCameraPictureBox = (PictureBox)VARIABLE;
                            }
                        }

                    }
                }
                if (distance < pictureBoxMap.Width * 0.04)
                {
                    pictureBoxMap.Refresh();
                    Graphics g = pictureBoxMap.CreateGraphics();
                    g.DrawLine(new Pen(Color.Red), new Point(((PictureBox)sender).Left, ((PictureBox)sender).Top), targetPotint);

                }
                else
                {
                    targetCameraPictureBox = null; 
                }
            }
        }
        
        private void pcCreatedAlarm_MouseUp(object sender, MouseEventArgs e)
        {
            AlarmIconInfo aii = (AlarmIconInfo)((PictureBox)sender).Tag;
            aii.X = (double)((PictureBox)sender).Left / pictureBoxMap.Width;
            aii.Y = (double)((PictureBox)sender).Top / pictureBoxMap.Height;
            
            if (targetCameraPictureBox != null)
            {
                int targetCameraId = (targetCameraPictureBox.Tag as CameraIconInfo).CameraId;
                aii.MatchCameraId = targetCameraId;
                _listCurrentCameraIcon[targetCameraId].MatchAlarmId = aii.AlarmId;
                CameraIconBusiness.Instance.Update(ref _errMessage, _listCurrentCameraIcon[targetCameraId]);
            }
            _listCurrentAlarmIcon[aii.AlarmId] = aii;
            _listAllAlarmIcon[aii.AlarmId] = aii;
            AlarmIconBusiness.Instance.Update(ref _errMessage, aii);
            pictureBoxMap.Refresh();
            targetCameraPictureBox = null;
        }

        private void pcCreatedCamera_MouseDown(object sender, MouseEventArgs e)
        {
            mouse_offset = new Point(-e.X, -e.Y);//
        }
        private void pcCreatedCamera_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBoxMap.Refresh();
            ((Control)sender).Cursor = Cursors.Arrow;//设置拖动时鼠标箭头
            if (e.Button == MouseButtons.Left)
            {
                Point mousePos = Control.MousePosition;
                mousePos.Offset(mouse_offset.X, mouse_offset.Y);//设置偏移
                ((Control)sender).Location = ((Control)sender).Parent.PointToClient(mousePos);
            }

        }


        private void pcCreatedCamera_MouseUp(object sender, MouseEventArgs e)
        {
            CameraIconInfo aii = (CameraIconInfo)((PictureBox)sender).Tag;
            aii.X = (double)((PictureBox)sender).Left / pictureBoxMap.Width;
            aii.Y = (double)((PictureBox)sender).Top / pictureBoxMap.Height;
            aii.MatchAlarmId = -1;
            _listCurrentCameraIcon[aii.CameraId] = aii;
            CameraIconBusiness.Instance.Update(ref _errMessage, aii);
            pictureBoxMap.Refresh();
        }

        void cameraView1_DoubleDevCam(string tag)
        {
            _isProgSwitchView = false;
            //splitContainerControl1.SplitterPosition = splitContainerControl1.Height - tlpBottom.Height;
            string[] strs = tag.Split(';');

            if (switchmap)
            {
                if (strs[1] == "A")
                {
                    int alarmId = int.Parse(strs[0]);
                    if (!_listAllAlarmIcon.ContainsKey(alarmId))
                    {
                        DrawAlarmIcon(alarmId);
                    }

                }
                else if (strs[1] == "C")
                {
                    int cameraId = int.Parse(strs[0]);
                    if (!_listAllCameraIcon.ContainsKey(cameraId))
                    {
                        DrawCameraIcon(cameraId);
                    }
                }
                else if (strs[1] == "m")
                {
                    int mapId = int.Parse(strs[0]);
                    currentMapInfo = _listMap[mapId];
                    DrawIconInMap();
                }
            }
            else
            {
                if (strs[1] == "D")
                {
                    isStop = true;
                    ViewCameraByDeviceId(int.Parse(strs[0]));
                }
                else if (strs[1] == "C")
                {
                    isStop = true;
                    ViewCameraByCameraId(int.Parse(strs[0]));
                }
            }
        }

        private void DrawAlarmIcon(int alarmId)
        {
            PictureBox pcCreatedAlarm = new PictureBox();
            pcCreatedAlarm.Image = Image.FromFile(Application.StartupPath + @"\img\ALARM3.BMP");
            pcCreatedAlarm.Parent = pictureBoxMap;
            pcCreatedAlarm.Width = pcCreatedAlarm.Height = 12;
            pcCreatedAlarm.SizeMode = PictureBoxSizeMode.StretchImage;
            AlarmIconInfo alarmIconInfo = new AlarmIconInfo();
            alarmIconInfo.AlarmId = alarmId;
            alarmIconInfo.ToolTip = _listAlarm[alarmId].DeviceName + "_" + _listAlarm[alarmId].Name;
            alarmIconInfo.Map = currentMapInfo.Id;
            ToolTip tTip = new ToolTip();
            tTip.SetToolTip(pcCreatedAlarm, alarmIconInfo.ToolTip);
            pcCreatedAlarm.Tag = alarmIconInfo;
            _listCurrentAlarmIcon.Add(alarmId, alarmIconInfo);
            _listAllAlarmIcon.Add(alarmId, alarmIconInfo);
            AlarmIconBusiness.Instance.Insert(ref _errMessage, alarmIconInfo);
            pcCreatedAlarm.Name = "pcCreatedAlarm" + alarmId;
            pcCreatedAlarm.ContextMenuStrip = cmIcon;
            pcCreatedAlarm.MouseDown += pcCreatedAlarm_MouseDown;
            pcCreatedAlarm.MouseMove += pcCreatedAlarm_MouseMove;
            pcCreatedAlarm.MouseUp += pcCreatedAlarm_MouseUp;
            pcCreatedAlarm.DoubleClick += pcCreatedAlarm_DoubleClick;
            pcCreatedAlarm.Click += pcCreatedAlarm_Click;
        }
        private void DrawCameraIcon(int cameraId)
        {
            PictureBox pcCreatedCamera = new PictureBox();
            pcCreatedCamera.Image = Image.FromFile(Application.StartupPath + @"\img\CAM2.BMP");
            pcCreatedCamera.Parent = pictureBoxMap;
            pcCreatedCamera.Width = pcCreatedCamera.Height = 12;
            pcCreatedCamera.SizeMode = PictureBoxSizeMode.StretchImage;
            CameraIconInfo cameraIconInfo = new CameraIconInfo();
            cameraIconInfo.CameraId = cameraId;
            cameraIconInfo.ToolTip = _listAllCam[cameraId].DeviceName + "_" + _listAllCam[cameraId].Name;
            cameraIconInfo.Map = currentMapInfo.Id;
            ToolTip tTip = new ToolTip();
            tTip.SetToolTip(pcCreatedCamera, cameraIconInfo.ToolTip);
            pcCreatedCamera.Tag = cameraIconInfo;
            _listCurrentCameraIcon.Add(cameraId, cameraIconInfo);
            _listAllCameraIcon.Add(cameraId, cameraIconInfo);
            CameraIconBusiness.Instance.Insert(ref _errMessage, cameraIconInfo);
            pcCreatedCamera.Name = "pcCreatedCamera" + cameraId;
            pcCreatedCamera.ContextMenuStrip = cmIcon;
            pcCreatedCamera.MouseDown += pcCreatedCamera_MouseDown;
            pcCreatedCamera.MouseMove += pcCreatedCamera_MouseMove;
            pcCreatedCamera.MouseUp += pcCreatedCamera_MouseUp;
            pcCreatedCamera.DoubleClick += pcCreatedCamera_DoubleClick;
            pcCreatedCamera.Click += pcCreatedCamera_Click;
        }

        private void DrawAlarmIcon(AlarmIconInfo alarmIconInfo)
        {
            PictureBox pcCreatedAlarm = new PictureBox();
            pcCreatedAlarm.Image = Image.FromFile(Application.StartupPath + @"\img\ALARM3.BMP");
            pcCreatedAlarm.Parent = pictureBoxMap;
            pcCreatedAlarm.Width = pcCreatedAlarm.Height = 12;
            pcCreatedAlarm.SizeMode = PictureBoxSizeMode.StretchImage;
            ToolTip tTip = new ToolTip();
            tTip.SetToolTip(pcCreatedAlarm, alarmIconInfo.ToolTip);
            pcCreatedAlarm.Tag = alarmIconInfo;
            pcCreatedAlarm.Top = (int)(alarmIconInfo.Y*pictureBoxMap.Height);
            pcCreatedAlarm.Left = (int)(alarmIconInfo.X * pictureBoxMap.Width);
            pcCreatedAlarm.Name = "pcCreatedAlarm" + alarmIconInfo.AlarmId;
            pcCreatedAlarm.ContextMenuStrip = cmIcon;
          
            pcCreatedAlarm.MouseDown += pcCreatedAlarm_MouseDown;
            pcCreatedAlarm.MouseMove += pcCreatedAlarm_MouseMove;
            pcCreatedAlarm.MouseUp += pcCreatedAlarm_MouseUp;
            pcCreatedAlarm.DoubleClick += pcCreatedAlarm_DoubleClick;
            pcCreatedAlarm.Click += pcCreatedAlarm_Click;
        }
        private void DrawCameraIcon(CameraIconInfo cameraIconInfo)
        {
            PictureBox pcCreatedCamera = new PictureBox();
            pcCreatedCamera.Image = Image.FromFile(Application.StartupPath + @"\img\CAM2.BMP");
            pcCreatedCamera.Parent = pictureBoxMap;
            pcCreatedCamera.Width = pcCreatedCamera.Height = 12;
            pcCreatedCamera.SizeMode = PictureBoxSizeMode.StretchImage;
            ToolTip tTip = new ToolTip();
            tTip.SetToolTip(pcCreatedCamera, cameraIconInfo.ToolTip);
            pcCreatedCamera.Tag = cameraIconInfo;
            pcCreatedCamera.Top = (int)(cameraIconInfo.Y * pictureBoxMap.Height);
            pcCreatedCamera.Left = (int)(cameraIconInfo.X * pictureBoxMap.Width);
            pcCreatedCamera.Name = "pcCreatedCamera" + cameraIconInfo.CameraId;
            pcCreatedCamera.ContextMenuStrip = cmIcon;
            pcCreatedCamera.MouseDown += pcCreatedAlarm_MouseDown;
            pcCreatedCamera.MouseMove += pcCreatedAlarm_MouseMove;
            pcCreatedCamera.MouseUp += pcCreatedCamera_MouseUp;
            pcCreatedCamera.DoubleClick += pcCreatedCamera_DoubleClick;
            pcCreatedCamera.Click += pcCreatedCamera_Click;
        }

        private void pictureBoxMap_SizeChanged(object sender, EventArgs e)
        {
            for (int i = pictureBoxMap.Controls.Count-1; i >= 0;i-- )
            {
                var VARIABLE = pictureBoxMap.Controls[i];
                if (VARIABLE is PictureBox)
                {
                    if (VARIABLE.Name.StartsWith("pcCreatedCamera")||VARIABLE.Name.StartsWith("pcCreatedAlarm"))
                    {
                        VARIABLE.Dispose();
                    }
                }
            }

            //DrawIconInMap();

        }

        private void pcCreatedAlarm_DoubleClick(object sender, EventArgs e)
        {
            AlarmIconInfo aii = (AlarmIconInfo) ((PictureBox) sender).Tag;
            ViewCameraByIcon(aii.MatchCameraId);
        }

        private void pcCreatedCamera_DoubleClick(object sender, EventArgs e)
        {
            CameraIconInfo cii = (CameraIconInfo)((PictureBox)sender).Tag;
            ViewCameraByIcon(cii.CameraId);
        }

        private void pcCreatedAlarm_Click(object sender, EventArgs e)
        {
            AlarmIconInfo aii = (AlarmIconInfo)((PictureBox)sender).Tag;
            if (aii.AlarmId!=-1)
            {
                lblAlarmPosition.Text = aii.AlarmId.ToString();                
            }
            else
            {
                lblAlarmPosition.Text = "未关联";
            }
        }

        private void pcCreatedCamera_Click(object sender, EventArgs e)
        {
            CameraIconInfo cii = (CameraIconInfo)((PictureBox)sender).Tag;
            if (cii.MatchAlarmId!=-1)
            {
                lblAlarmPosition.Text = cii.MatchAlarmId.ToString();                
            }
            else
            {
                lblAlarmPosition.Text = "未关联";
            }
        }

        private void ViewCameraByIcon(int carmeraId)
        {
            try
            {
                mainMultiplexer.CamerasVisible = true;
                mainMultiplexer.CellWidth = 320;
                mainMultiplexer.CellHeight = 240;
                mainMultiplexer.FitToWindow = true;
                mainMultiplexer.Cols = mainMultiplexer.Rows = 1;
                HikVideoServerDeviceDriver deviceDriver;
                HikVideoServerCameraDriver cameraDriver;
                DeviceInfo oDevice;
                CameraInfo camera = _listAllCam[carmeraId];
                CameraWindow camwin = mainMultiplexer.GetFirstCameraWindow();
                camera.Handle = camwin.Handle;
                oDevice = _listDevice[camera.DeviceId];
                oDevice.Handle = camwin.Handle;
                if (!_runningDeviceList.ContainsKey(camera.DeviceId))
                {
                    deviceDriver = new HikVideoServerDeviceDriver();
                    deviceDriver.Init(ref oDevice);
                    _runningDeviceList.Add(camera.DeviceId, deviceDriver);
                }

                oDevice.ServiceID = _runningDeviceList[camera.DeviceId].ServiceId;
                if (!_runningCameraList.ContainsKey(camera.CameraId))
                {
                    cameraDriver = new HikVideoServerCameraDriver(oDevice);
                    cameraDriver.Start(camera);
                    _runningCameraList.Add(camera.CameraId, cameraDriver);
                    mainMultiplexer.SetCamera(camwin, cameraDriver);
                }
                else
                {
                    cameraDriver = _runningCameraList[camera.CameraId];
                    _runningCameraList.Remove(camera.CameraId);
                    cameraDriver.Stop();
                    cameraDriver.Close();
                    cameraDriver.Start(camera);
                    _runningCameraList.Add(camera.CameraId, cameraDriver);
                    mainMultiplexer.SetCamera(camwin, cameraDriver);
                }
                mainMultiplexer.CamerasVisible = true;
            }
            catch (System.Exception ex)
            {

            }
            finally
            {
            }

        }

        private void DrawIconInMap()
        {
            for (int i = pictureBoxMap.Controls.Count - 1; i >= 0; i--)
            {
                var VARIABLE = pictureBoxMap.Controls[i];
                if (VARIABLE is PictureBox)
                {
                    VARIABLE.Dispose();
                }
            }
            pictureBoxMap.Image = Image.FromFile(Path.Combine(Application.StartupPath, currentMapInfo.FileName));
            //在地图上画摄像头图标
            _listCurrentCameraIcon = CameraIconBusiness.Instance.GetCameraIconInfoByMapId(ref _errMessage, currentMapInfo.Id);
            foreach (var cameraIconInfo in _listCurrentCameraIcon)
            {
                DrawCameraIcon(cameraIconInfo.Value);
            }

            //在地图上画报报警点图标
            _listCurrentAlarmIcon = AlarmIconBusiness.Instance.GetAlarmIconInfoByMapId(ref _errMessage, currentMapInfo.Id);
            foreach (var alarmIconInfo in _listCurrentAlarmIcon)
            {
                DrawAlarmIcon(alarmIconInfo.Value);
            }
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var tag = ((ContextMenuStrip)((ToolStripMenuItem) sender).Owner).SourceControl.Tag;
            if (tag is AlarmIconInfo)
            {
                AlarmIconInfo alarmIconInfo = (AlarmIconInfo)tag;
                AlarmIconBusiness.Instance.Delete(ref _errMessage, alarmIconInfo.AlarmId);
                _listCurrentAlarmIcon.Remove(alarmIconInfo.AlarmId);
                _listAllAlarmIcon.Remove(alarmIconInfo.AlarmId);
                ((ContextMenuStrip)((ToolStripMenuItem) sender).Owner).SourceControl.Dispose();
            }
            else if (tag is CameraIconInfo)
            {
                CameraIconInfo cameraIconInfo = (CameraIconInfo)tag;
                CameraIconBusiness.Instance.Delete(ref _errMessage, cameraIconInfo.CameraId);
                _listCurrentCameraIcon.Remove(cameraIconInfo.CameraId);
                _listAllCameraIcon.Remove(cameraIconInfo.CameraId);
                ((ContextMenuStrip)((ToolStripMenuItem)sender).Owner).SourceControl.Dispose();
            }
        }

        private void PCALarmSwithClick(object sender, EventArgs e)
        {
            if (((PictureBox)sender).Tag!=null)
            {
                int alarmid = (((PictureBox) sender).Tag as AlarmInfo).AlarmId;
                lblAlarmPosition.Text = alarmid.ToString();
                
            }
        }

        private void PCALarmSwithDoubleClick(object sender, EventArgs e)
        {
            if (((PictureBox)sender).Tag != null)
            {
                int alarmid = (((PictureBox)sender).Tag as AlarmInfo).AlarmId;
                if (_listAllAlarmIcon.ContainsKey(alarmid))
                {
                    ViewCameraByIcon(_listAllAlarmIcon[alarmid].MatchCameraId);
                    currentMapInfo = _listMap[_listAllAlarmIcon[alarmid].Map];
                    DrawIconInMap();
                }

            }
        }

        private void SetDefaultAlarmSwitchPictureBox()
        {
            foreach (var VARIABLE in tlpBottom.Controls)
            {
                if ((VARIABLE is PictureBox) && ((PictureBox)VARIABLE).Name.StartsWith("pcAlarmSwitch"))
                {
                    ((PictureBox)VARIABLE).Click += PCALarmSwithClick;
                    ((PictureBox)VARIABLE).DoubleClick += PCALarmSwithDoubleClick;
                    ((PictureBox)VARIABLE).Tag = null;
                }
            }

            foreach (var alarmInfo in _listAlarm)
            {
                foreach (var VARIABLE in tlpBottom.Controls)
                {
                    if ((VARIABLE is PictureBox) && ((PictureBox)VARIABLE).Name.StartsWith("pcAlarmSwitch") && ((PictureBox)VARIABLE).Tag==null)
                    {
                        ((PictureBox)VARIABLE).Tag = alarmInfo.Value;
                        ToolTip tt = new ToolTip();
                        tt.SetToolTip((PictureBox)VARIABLE, alarmInfo.Value.DeviceName + "_" +alarmInfo.Value.Name);
                        break;
                    }
                }
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            _runningCameraList[5].TestAlarm();
        }

        private string CurrentAlarmSites;
        private Dictionary<int, AlarmInfo> _listAlarmSites = new Dictionary<int, AlarmInfo>();
        private void timerCheckAlarmSites_Tick(object sender, EventArgs e)
        {
            if (HikVideoServerCameraDriver.AlarmSites != null)
            {
                
                CurrentAlarmSites = HikVideoServerCameraDriver.AlarmSites;
                string sitesSubString = CurrentAlarmSites.Substring(8, 4);
                int x = int.Parse(sitesSubString, NumberStyles.HexNumber);
                string sites = Convert.ToString(x, 2);
                for (int i = 0; i < sites.Length; i++)
                {
                    if ((sites.Substring(i,1)=="1"))
                    {
                        if ((_listAlarm.ContainsKey(sites.Length - i))&&_listAlarmSites.ContainsKey(sites.Length - i)==false)
                        {
                            _listAlarmSites.Add(sites.Length - i, _listAlarm[sites.Length - i]);
                        }
                        else if ((_listAlarm.ContainsKey(sites.Length - i))&&_listAlarmSites.ContainsKey(sites.Length - i)==true)
                        {
                            _listAlarmSites[sites.Length - i] = _listAlarm[sites.Length - i];
                        }
                        
                    }
                }
                HikVideoServerCameraDriver.AlarmSites =null;
            }
        }

        private bool switchImage;
        
        private void timerUpdateIcon_Tick(object sender, EventArgs e)
        {
            bool isNeedBeep = false;
            switchImage = !switchImage;
            foreach (var variable in _listAlarmSites)
            {
                foreach (var VARIABLE in tlpBottom.Controls)
                {
                    if ((VARIABLE is PictureBox) && ((PictureBox)VARIABLE).Name.StartsWith("pcAlarmSwitch") &&(((PictureBox)VARIABLE).Tag!=null)&& (((AlarmInfo)((PictureBox)VARIABLE).Tag).AlarmId == variable.Value.AlarmId))
                    {
                        if (switchImage==false)
                        {
                            ((PictureBox)VARIABLE).Image = Image.FromFile(Application.StartupPath + @"\img\AR1.BMP");
                        }
                        else
                        {
                            ((PictureBox)VARIABLE).Image = Image.FromFile(Application.StartupPath + @"\img\AR2.BMP");
                          
                        }
                        isNeedBeep = true;
                    }
                }
                foreach (var VARIABLE in pictureBoxMap.Controls)
                {
                    if ((VARIABLE is PictureBox) && ((PictureBox)VARIABLE).Name.StartsWith("pcCreatedAlarm") &&(((PictureBox)VARIABLE).Tag!=null)&& (((AlarmIconInfo)((PictureBox)VARIABLE).Tag).AlarmId == variable.Value.AlarmId))
                    {
                        if (switchImage == false)
                        {
                            ((PictureBox)VARIABLE).Image = Image.FromFile(Application.StartupPath + @"\img\ALARM3a.BMP");
                        }
                        else
                        {
                            ((PictureBox)VARIABLE).Image = Image.FromFile(Application.StartupPath + @"\img\ALARM3.BMP");
                        }
                        isNeedBeep = true;
                    }
                }
            }
            if (isNeedBeep)
            {
                MessageBeep(1);
            }
        }
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool MessageBeep(uint uType);

        private void btnCancelAlarm_Click(object sender, EventArgs e)
        {
            if(lblAlarmPosition.Text=="未选择")
            {
                return;
            }
            int alarmid = int.Parse(lblAlarmPosition.Text);
            if (_listAlarmSites.ContainsKey(alarmid))
            {
                AlarmInfo Alarm2Delete = _listAlarmSites[alarmid];
                _listAlarmSites.Remove(alarmid);
                //发送消警串口信息
                ProtocolDataItem pdi = (new ProtocolDataBuilder()).ARM_CancelAlarm(alarmid);
                SendSerialInfo(Alarm2Delete, pdi);
                lblAlarmPosition.Text = "未选择";

            }
            foreach (var VARIABLE in tlpBottom.Controls)
            {
                if ((VARIABLE is PictureBox) && ((PictureBox)VARIABLE).Name.StartsWith("pcAlarmSwitch") && (((PictureBox)VARIABLE).Tag != null) && (((AlarmInfo)((PictureBox)VARIABLE).Tag).AlarmId == alarmid))
                {
                    ((PictureBox)VARIABLE).Image = Image.FromFile(Application.StartupPath + @"\img\AR3.BMP");
                }
            }
            foreach (var VARIABLE in pictureBoxMap.Controls)
            {
                if ((VARIABLE is PictureBox) && ((PictureBox)VARIABLE).Name.StartsWith("pcCreatedAlarm") && (((PictureBox)VARIABLE).Tag != null) && (((AlarmIconInfo)((PictureBox)VARIABLE).Tag).AlarmId == alarmid))
                {
                    ((PictureBox)VARIABLE).Image = Image.FromFile(Application.StartupPath + @"\img\ALARM3.BMP");
                }
            }
        }
        private void SendSerialInfo(AlarmInfo Alarm2Delete , ProtocolDataItem pdi)
        {
            if (HikVideoServerCameraDriver.ListSerialHandle.ContainsKey(Alarm2Delete.DeviceId))
            {
                SendSerialThread sst = new SendSerialThread(Alarm2Delete, pdi);
                Thread t = new Thread(new ThreadStart(sst.SendThreadProc));
                t.Start();
                t.Join();
            }

        }
        private class SendSerialThread
        {
            //要用到的属性，也就是我们要传递的参数
            private AlarmInfo AlarmInfo;
            private ProtocolDataItem ProtocolDataItem;

            //包含参数的构造函数
            public SendSerialThread(AlarmInfo alarm2Delete, ProtocolDataItem pdi)
            {
                AlarmInfo = alarm2Delete;
                ProtocolDataItem = pdi;
            }
            //要丢给线程执行的方法，本处无返回类型就是为了能让ThreadStart来调用
            public void SendThreadProc()
            {
                //这里就是要执行的任务,本处只显示一下传入的参数
                bool ret = HCNetSDK.NET_DVR_SerialSend(HikVideoServerCameraDriver.ListSerialHandle[AlarmInfo.DeviceId],
            AlarmInfo.ChannelNo, ProtocolDataItem.StrData, ProtocolDataItem.DataLen);
            }


        }
        //设防
        private void Fortify_Click(object sender, EventArgs e)
        {
            if (lblAlarmPosition.Text == "未选择")
            {
                return;
            }
            int alarmid = int.Parse(lblAlarmPosition.Text);
            if (_listAlarmSites.ContainsKey(alarmid))
            {
                AlarmInfo Alarm2Delete = _listAlarmSites[alarmid];
                //发送设防串口信息
                ProtocolDataItem pdi = (new ProtocolDataBuilder()).ARM_Fortify(alarmid);
                SendSerialInfo(Alarm2Delete, pdi);
            }
        }
        //撤防
        private void FortifyDisable_Click(object sender, EventArgs e)
        {
            if (lblAlarmPosition.Text == "未选择")
            {
                return;
            }
            int alarmid = int.Parse(lblAlarmPosition.Text);
            if (_listAlarmSites.ContainsKey(alarmid))
            {
                AlarmInfo Alarm2Delete = _listAlarmSites[alarmid];
                //发送设防串口信息
                ProtocolDataItem pdi = (new ProtocolDataBuilder()).ARM_Fortify_Disable(alarmid);
                SendSerialInfo(Alarm2Delete, pdi);

            }
        }
        //联动开
        private void LinkageEnable_Click(object sender, EventArgs e)
        {
            if (lblAlarmPosition.Text == "未选择")
            {
                return;
            }
            int alarmid = int.Parse(lblAlarmPosition.Text);
            if (_listAlarmSites.ContainsKey(alarmid))
            {
                AlarmInfo Alarm2Delete = _listAlarmSites[alarmid];
                //发送设防串口信息
                ProtocolDataItem pdi = (new ProtocolDataBuilder()).ARM_Linkage_Enable(alarmid);
                SendSerialInfo(Alarm2Delete, pdi);

            }
        }
        //联动关
        private void LinkageDisable_Click(object sender, EventArgs e)
        {
            if (lblAlarmPosition.Text == "未选择")
            {
                return;
            }
            int alarmid = int.Parse(lblAlarmPosition.Text);
            if (_listAlarmSites.ContainsKey(alarmid))
            {
                AlarmInfo Alarm2Delete = _listAlarmSites[alarmid];
                //发送设防串口信息
                ProtocolDataItem pdi = (new ProtocolDataBuilder()).ARM_Linkage_Disable(alarmid);
                SendSerialInfo(Alarm2Delete, pdi);

            }
        }

        private void barButtonItemResultView_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            dockPanelResult.Visible = !dockPanelResult.Visible;
        }

        private void barButtonItemAlarmView_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            dockPanelAlarm.Visible = !dockPanelAlarm.Visible;
        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmSetting setting = new frmSetting();
            setting.ShowDialog(this);
        }

        private void barButtonItem3_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmSetting setting = new frmSetting();
            setting.ShowDialog(this);
        }

        private void barButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void timerCurretnTime_Tick(object sender, EventArgs e)
        {
            barStaticItemCurrentTime.Caption = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        private void barButtonItem8_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            JustForTest justForTest = new JustForTest();
            justForTest.ShowDialog();
        }

        private void LivePacketHandleDataChange(object sender, DataChangeEventArgs e)
        {

            var livePacketHandle = (LivePacketHandle)sender;
            if (livePacketHandle == null) return;
            //处理视频 ShowLiveVideo(livePacketHandle);
        }

        #region Connect sever
        private delegate void CrossThreadOperationControl();
        private void ConnectionServer()
        {
            _getTransPacket.Ip = Properties.Settings.Default.DecoderIp;
            _getTransPacket.Port = Properties.Settings.Default.DecoderPort;

            var thread = new Thread(_getTransPacket.InitSocket) { IsBackground = true };
            thread.Start();

        }

        private void GtpConnectionServerHandle(object sender, DataChangeEventArgs e)
        {
            bool isConnect = Convert.ToBoolean(e.Name);
            if (isConnect)
            {
                ThreadPool.QueueUserWorkItem(obj => _getTransPacket.GetData(), null);
                ShowConnectionInfo(e.Ip, true);
            }
            else
            {
                ShowConnectionInfo(e.Ip, false);
            }
        }

        protected void ShowConnectionInfo(string ip, bool state)
        {
            CrossThreadOperationControl crossOperation = delegate()
            {
                if (state)
                {
                    barStaticItemNetStatus.Appearance.ForeColor = barStaticItem1.Appearance.ForeColor;
                    barStaticItemNetStatus.Caption = "连接成功！";
                    _socketState = true;
                }
                else
                {
                    barStaticItemNetStatus.Appearance.ForeColor = Color.Red;
                    barStaticItemNetStatus.Caption = string.Format("连接失败！{0}秒后重连", Properties.Settings.Default.AutoConnectTime / 1000);
 //                   pictureEditRealImage.Image = MainForm.DefaultImage ?? Image.FromFile("NoData.jpg");
                    _socketState = false;
                }
            };

            try
            {
                Invoke(crossOperation);
            }
            catch (System.Exception ex)
            {
                Close();
                Dispose();
            }

        }

        #endregion

        private bool _socketState;
        private void timerCheckConnection_Tick(object sender, EventArgs e)
        {
            if (!_socketState)
                ConnectionServer();
        }
        private TcpListener listener = new TcpListener(IPAddress.Any, 8000);
        private TcpClient client=new TcpClient();
        private Thread thThreadread;//创建线程，用以侦听端口号，接受信息


        private  int portNum; //= Convert.ToInt32(LocalPortTxt.Text);
        private bool done = false;
        private IPEndPoint ipep ;
        private Socket server;
        private IPacketHandler[] _handlers;
        public LivePacketHandle LivePacketHandle;
        public DecoderStateHandle DecoderStateHandle;
        NetworkStream _networkStream;

       

        public void StartServer()
        {
            LivePacketHandle = new LivePacketHandle();
            DecoderStateHandle = new DecoderStateHandle();
            _handlers = new IPacketHandler[] { LivePacketHandle, DecoderStateHandle };
            
            try{
                server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                server.Bind(new IPEndPoint(new IPAddress(new byte[]{127,0,0,1}), 9999));
                server.Listen(500);
                // 开始侦听
                //确认连接   
                Socket client = server.Accept();
                //获得客户端节点对象   
                IPEndPoint clientep = (IPEndPoint)client.RemoteEndPoint;
                _networkStream = new NetworkStream(client);
                while (!done)
                {
                    if (client == null)
                    {
                        client = server.Accept();
                        _networkStream = new NetworkStream(client);
                    }
                    byte[] recb = new byte[10000];
                    _networkStream.Read(recb, 0, recb.Length);
                    AnalysisData(recb);

                }
            }
            catch (Exception e)
            {
                ;
            }
            finally
            {
                client.Close();
                listener.Stop();
                server.Close();
            }
        }
        //分析数据
        protected void AnalysisData(byte[] byteBuf)
        {
            foreach (var handler in _handlers)
            {
                if (handler.CanHandle(byteBuf))
                {
                    handler.Handle(byteBuf);
                }
            }
        }
        //发送心跳信号
        public void SendHbTrade()
        {
            byte[] byteHb = new byte[16] { 0xaa, 0xaa, 0xaa, 0xaa, 0xaa, 0xaa, 0xaa, 0xaa, 0xaa, 0xaa, 0xaa, 0xaa, 0xaa, 0xaa, 0xaa, 0xaa };
            byte[] byteToSend = BuildPackte(99, byteHb, 0, 16);
            try
            {
                if (_networkStream != null)
                    _networkStream.Write(byteToSend, 0, byteToSend.Length);
            }
            catch (IOException ex)
            {
                //_connectState = false;
                //ConnetSever(this, new DataChangeEventArgs("false", Ip));
                return;
            }
            catch (ObjectDisposedException ode)
            {
                //System.Diagnostics.Debug.WriteLine("对象释放异常！");
                return;
            }
        }

        private byte[] BuildPackte(int type, byte[] data, int pos, int length)
        {
            int dataLength = (length + 8);
            byte[] byteHb = new byte[dataLength + 8];

            //包头（格式+包长）
            byteHb[0] = byteHb[2] = 0xaa; byteHb[1] = byteHb[3] = 0x55;
            Array.Copy(BitConverter.GetBytes(dataLength), 0, byteHb, 4, 4);

            //数据类型

            Array.Copy(BitConverter.GetBytes(type), 0, byteHb, 8, 4);

            //数据长度
            Array.Copy(BitConverter.GetBytes(length), 0, byteHb, 12, 4);

            //真实数据
            Array.Copy(data, pos, byteHb, 16, length);

            return byteHb;

        }

        //发送解码器配置XML
        public void SendDecoderXML(int decoderid)
        {

            byte[] byteArray = System.Text.Encoding.Default.GetBytes(DecoderBusiness.Instance.GetDecoderXMLString(decoderid));

            byte[] byteToSend = BuildPackte(1, byteArray, 0, byteArray.Length);

            try
            {
                if (_networkStream != null)
                    _networkStream.Write(byteToSend, 0, byteToSend.Length);
            }
            catch (IOException ex)
            {
                //_connectState = false;
                //ConnetSever(this, new DataChangeEventArgs("false", Ip));
                return;
            }
            catch (ObjectDisposedException ode)
            {
                //System.Diagnostics.Debug.WriteLine("对象释放异常！");
                return;
            }
        }

        //发送解码器启动指令

        public void SendDecoderStartCommand()
        {
            byte[] bytes = new byte[0];
            byte[] byteToSend = BuildPackte(2, bytes, 0, 0);

            try
            {
                if (_networkStream != null)
                    _networkStream.Write(byteToSend, 0, byteToSend.Length);
            }
            catch (IOException ex)
            {
                //_connectState = false;
                //ConnetSever(this, new DataChangeEventArgs("false", Ip));
                return;
            }
            catch (ObjectDisposedException ode)
            {
                //System.Diagnostics.Debug.WriteLine("对象释放异常！");
                return;
            }
        }

        //发送解码器停止指令

        public void SendDecoderStopCommand()
        {
            byte[] bytes = new byte[0];
            byte[] byteToSend = BuildPackte(3, bytes, 0, 0);

            try
            {
                if (_networkStream != null)
                    _networkStream.Write(byteToSend, 0, byteToSend.Length);
            }
            catch (IOException ex)
            {
                //_connectState = false;
                //ConnetSever(this, new DataChangeEventArgs("false", Ip));
                return;
            }
            catch (ObjectDisposedException ode)
            {
                //System.Diagnostics.Debug.WriteLine("对象释放异常！");
                return;
            }
        }
        //设置图片长宽

        public void SetPicWidthHeight(int width, int height)
        {
            byte[] bytes = new byte[8];
            Array.Copy(BitConverter.GetBytes(width), 0, bytes, 0, 4);
            Array.Copy(BitConverter.GetBytes(height), 0, bytes, 4, 4);

            byte[] byteToSend = BuildPackte(5, bytes, 0, 8);

            try
            {
                if (_networkStream != null)
                    _networkStream.Write(byteToSend, 0, byteToSend.Length);
            }
            catch (IOException ex)
            {
                //_connectState = false;
                //ConnetSever(this, new DataChangeEventArgs("false", Ip));
                return;
            }
            catch (ObjectDisposedException ode)
            {
                //System.Diagnostics.Debug.WriteLine("对象释放异常！");
                return;
            }
        }


        static bool IsHeader(byte[] hdr)
        {
            int i = 0;
            if (hdr[i++] == 0xaa && hdr[i++] == 0x55 && hdr[i++] == 0xaa && hdr[i++] == 0x55)
            {
                return true;
            }
            return false;
        }
    }
}