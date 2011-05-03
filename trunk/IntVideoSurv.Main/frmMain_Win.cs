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
using CameraViewer.NetWorking;
using CameraViewer.Remoting;
using DevExpress.XtraEditors;
using IntVideoSurv.Business;
using IntVideoSurv.Entity;
using CameraViewer.Forms;
using System.IO;
using IntVideoSurv.Business.HiK;
using System.Threading;

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
        Dictionary<int, DecoderInfo> _listDecoder;
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
            _getTransPacket.LiveDecoderPacketHandle.DataChange += LiveDecoderPacketHandleDataChange;

            //start tcp server
            var thread = new Thread(StartServerForDecoder) { IsBackground = true };
            thread.Start();

            var threadForRecognizer = new Thread(StartServerForRecognizer) { IsBackground = true };
            threadForRecognizer.Start();

            
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
        void CameraView1DoubleDecoderCam(string tag)
        {
            //splitContainerControl1.SplitterPosition = splitContainerControl1.Height - tlpBottom.Height;
            //XtraMessageBox.Show(tag);
            string[] strs = tag.Split(';');
            if (strs.Length == 2)
            {
                DispalySynCamera(int.Parse(strs[0]));
            }
        }
        void CameraView1DoubleDevCam(string tag)
        {
            //splitContainerControl1.SplitterPosition = splitContainerControl1.Height - tlpBottom.Height;
            string[] strs = tag.Split(';');
            if (strs[1] == "D")
            {
                //ViewCameraByDeviceId(int.Parse(strs[0]));
            }
            else if (strs[1] == "C")
            {
                //ViewCameraByCameraId(int.Parse(strs[0]));

                if (mainMultiplexer.GetCurrentCameraWindow()==null)
                {
                    return;
                }
                string errMsg = "";
                int row = 0, col = 0;
                mainMultiplexer.GetCurrentCameraWindowPosition(ref row, ref col);
                WindowCameraBusiness.Instance.Insert(ref errMsg,new WindowCameraInfo{CameraId = int.Parse(strs[0]),Row =row, Col = col});
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
                    _listDecoder = DecoderBusiness.Instance.GetAllDecoderInfo(ref _errMessage);
                    cameraView1.ListDecoder = _listDecoder;
                    break;                    
                default:
                    _listGroup = GroupBusiness.Instance.GetAllGroupInfos(ref _errMessage);
                    cameraView1.ListGroup = _listGroup;
                    break;
            }
        }

        private void tvSynGroup_DoubleClick(object sender, EventArgs e)
        {
            //splitContainerControl1.SplitterPosition = splitContainerControl1.Height - tlpBottom.Height;
            //XtraMessageBox.Show(DateTime.Now.ToString());
        }

        private bool _isFullScreen;
        public void FullScreen(bool isFullScreen)
        {
            
            bar2.Visible = !isFullScreen;
            //cameraView1.Visible = !isFullScreen;
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

            Splash.Splash.Status = "获取解码器信息...";
            _listDecoder = DecoderBusiness.Instance.GetAllDecoderInfo(ref _errMessage);
            cameraView1.ListDecoder = _listDecoder;

            LoadAllCamera();
            this.cameraView1.tvSynGroup.DoubleClick += this.tvSynGroup_DoubleClick;
            this.cameraView1.xtraTabControl2.SelectedPageChanged += this.xtraTabControl2_SelectedPageChanged;
            this.cameraView1.DoubleDecoderCam += CameraView1DoubleDecoderCam;
            this.cameraView1.DoubleDevCam += CameraView1DoubleDevCam;

            //Debug.WriteLine("End frmMain_Win_Load" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss fff"));
            Splash.Splash.Status = "初始化完毕!";
            Splash.Splash.Close();
            //HikVideoServerCameraDriver.InitDecodeCard();
            splitContainerControl1.SplitterPosition = splitContainerControl1.Height - 46;
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
                        IntPtr intPtr= new IntPtr();
                        camera.Handle = intPtr;
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
                            cameraDriver.Start(camera, CardOutType.DefaultDisplay, 1);
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

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool MessageBeep(uint uType);


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

        private void LiveDecoderPacketHandleDataChange(object sender, DataChangeEventArgs e)
        {

            var livePacketHandle = (LiveDecoderPacketHandle)sender;
            if (livePacketHandle == null) return;
            //处理视频 
            ShowLiveVideo(livePacketHandle);

        }
        protected void ShowLiveVideo(LiveDecoderPacketHandle liveDecoderPacketHandle)
        {
            CrossThreadOperationControl crossAdd = delegate()
            {
                string errMsg = "";
                Dictionary<int, WindowCameraInfo> listWindowCamera =
                    WindowCameraBusiness.Instance.GetWindowCameraInfoByCamera(ref errMsg,
                                                                              liveDecoderPacketHandle.CurrentNetImage.CameraId);

                foreach (var windowCameraInfo in listWindowCamera)
                {
                    CameraWindow cameraWindow = mainMultiplexer.GetCamera(windowCameraInfo.Value.Row, windowCameraInfo.Value.Col);
                    if (cameraWindow.CurrentImage != null) cameraWindow.CurrentImage.Dispose();
                    cameraWindow.CurrentImage = liveDecoderPacketHandle.CurrentNetImage.Image;
                    cameraWindow.CameraID = windowCameraInfo.Key;
                    cameraWindow.Refresh();                   
                }

            };
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

        #region 与解码器的通信

        private bool _socketState;
        private void timerCheckConnection_Tick(object sender, EventArgs e)
        {
            if (!_socketState)
                ConnectionServer();
        }
        private TcpListener listener = new TcpListener(IPAddress.Any, 8000);
        private readonly TcpClient tcpClientDecoder=new TcpClient();

        private Socket _socket2Decoder;

        public void StartServerForDecoder()
        {
            try{
                _socket2Decoder = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                _socket2Decoder.Bind(new IPEndPoint(new IPAddress(new byte[]{127,0,0,1}), 8888));
                _socket2Decoder.Listen(500);
                // 开始侦听
                while (true)
                {
                    Socket client = _socket2Decoder.Accept();
                    //start tcp server
                    var parStart = new ParameterizedThreadStart(SocketDecoderThread);
                    var myThread = new Thread(parStart);
                    myThread.Start(client);
                }
            }
            catch (Exception e)
            {
                ;
            }
            finally
            {
                tcpClientDecoder.Close();
                listener.Stop();
                _socket2Decoder.Close();
            }
        }

        //处理socket连接的线程
        public void SocketDecoderThread(object socket)
        {
            //获得客户端节点对象   
            var clientConnection = new DecoderClientConnection((Socket)socket);

            clientConnection.LiveDecoderPacketHandle.DataChange += LiveDecoderPacketHandleDataChange; 

            if (!listRunningDecoderClient.ContainsKey(clientConnection.DecoderInfo.id))
            {
                listRunningDecoderClient.Add(clientConnection.DecoderInfo.id, clientConnection);
            }
            else
            {
                listRunningDecoderClient[clientConnection.DecoderInfo.id] = clientConnection;
            }
            clientConnection.SendDecoderXML();
            clientConnection.GetData();
        }
        private Dictionary<int, DecoderClientConnection> listRunningDecoderClient = new Dictionary<int, DecoderClientConnection>();


        #endregion

        #region 与识别器的通信

        private readonly TcpListener _listenerRecognizer = new TcpListener(IPAddress.Any, 8000);
        private readonly TcpClient _tcpClientRecognizer = new TcpClient();

        private Socket _socket2Recognizer;

        public void StartServerForRecognizer()
        {
            try
            {
                _socket2Recognizer = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                _socket2Recognizer.Bind(new IPEndPoint(new IPAddress(new byte[] { 127, 0, 0, 1 }), 9999));
                _socket2Recognizer.Listen(500);
                // 开始侦听
                while (true)
                {
                    Socket client = _socket2Recognizer.Accept();
                    //start tcp server
                    var parStart = new ParameterizedThreadStart(SocketRecognizerThread);
                    var myThread = new Thread(parStart);
                    myThread.Start(client);
                }
            }
            catch (Exception e)
            {
                ;
            }
            finally
            {
                _tcpClientRecognizer.Close();
                _listenerRecognizer.Stop();
                _socket2Recognizer.Close();
            }
        }

        //处理socket连接的线程
        public void SocketRecognizerThread(object socket)
        {
            //获得客户端节点对象   
            var recognizerClientConnectionConnection = new RecognizerClientConnection((Socket)socket);

            recognizerClientConnectionConnection.LiveRecognizerEventPacketHandle.DataChange += LiveDecoderPacketHandleDataChange;

            if (!listRunningRecognizerClient.ContainsKey(recognizerClientConnectionConnection.RecognizerInfo.Id))
            {
                listRunningRecognizerClient.Add(recognizerClientConnectionConnection.RecognizerInfo.Id, recognizerClientConnectionConnection);
            }
            else
            {
                listRunningRecognizerClient[recognizerClientConnectionConnection.RecognizerInfo.Id] = recognizerClientConnectionConnection;
            }
            recognizerClientConnectionConnection.SendRecognizerXML(recognizerClientConnectionConnection.RecognizerInfo.Id);
            recognizerClientConnectionConnection.GetData();
        }
        private Dictionary<int, RecognizerClientConnection> listRunningRecognizerClient = new Dictionary<int, RecognizerClientConnection>();


        #endregion


        private void barButtonItem8_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            foreach (var v in listRunningDecoderClient)
            {
                //v.Value.SendRealDecoderStartCommand();
            }
        }

        private void barButtonItem9_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            foreach (var v in listRunningDecoderClient)
            {
                //v.Value.SendRealDecoderStopCommand();
            }
        }

        private void barButtonItem10_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            foreach (var v in listRunningDecoderClient)
            {
                //v.Value.SetPicWidthHeight(352,288);
            }
        }

        private void barButtonItem11_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            foreach (var v in listRunningDecoderClient)
            {
                v.Value.SendDecoderXML();
            }
        }

        private void barButtonItem12_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CameraWindow cameraWindow = mainMultiplexer.GetCamera(1, 1);
            cameraWindow.CurrentImage = Image.FromFile(@"C:\fff1a7ef-43d7-46d9-ad61-d5c9f8fe4b53.bmp");
        }

        private bool testimage;
        private object lockerCurrentImage = new object();
        private Guid guidA = Guid.NewGuid();
        private Guid guidB = Guid.NewGuid();
        private void timerTest_Tick(object sender, EventArgs e)
        {
            lock (lockerCurrentImage)
            {
                testimage =!testimage;
                if (testimage)
                {
                    CameraWindow cameraWindow = mainMultiplexer.GetCamera(1, 1);
                    if (cameraWindow.CurrentImage != null) cameraWindow.CurrentImage.Dispose();
                    cameraWindow.CurrentImage = Image.FromFile(@"C:\imm_2010_07_06_18_35_29_212.JPG");
                    cameraWindow.CameraID = 5;
                    cameraWindow.CurrentImageGuid = guidA;
                    cameraWindow.Refresh();

                }
                else
                {
                    CameraWindow cameraWindow = mainMultiplexer.GetCamera(1, 1);
                    if (cameraWindow.CurrentImage != null) cameraWindow.CurrentImage.Dispose();
                    cameraWindow.CurrentImage = Image.FromFile(@"C:\imm_2010_07_06_18_35_29_21.JPG");
                    cameraWindow.CameraID = 5;
                    cameraWindow.CurrentImageGuid = guidB;
                    cameraWindow.Refresh();
            
                }                
            }


        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            int iRow = 1, iCol = 1;
            Util.GetRowCol(1, ref iRow, ref iCol);
            mainMultiplexer.Rows = iRow;
            mainMultiplexer.Cols = iCol;
            mainMultiplexer.Refresh();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            int iRow = 2, iCol = 2;
            Util.GetRowCol(4, ref iRow, ref iCol);
            mainMultiplexer.Rows = iRow;
            mainMultiplexer.Cols = iCol;
            mainMultiplexer.Refresh();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            int iRow = 3, iCol = 3;
            Util.GetRowCol(9, ref iRow, ref iCol);
            mainMultiplexer.SetRowCol(iRow,iCol);
            mainMultiplexer.Refresh();
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            int iRow = 4, iCol = 4;
            Util.GetRowCol(16, ref iRow, ref iCol);
            mainMultiplexer.Rows = iRow;
            mainMultiplexer.Cols = iCol;
            mainMultiplexer.Refresh();
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            int iRow = 5, iCol = 5;
            Util.GetRowCol(25, ref iRow, ref iCol);
            mainMultiplexer.Rows = iRow;
            mainMultiplexer.Cols = iCol;
            mainMultiplexer.Refresh();
        }

        private void splitContainerControl1_Resize(object sender, EventArgs e)
        {
            
        }

        private void splitContainerControl1_SplitterPositionChanged(object sender, EventArgs e)
        {
                splitContainerControl1.SplitterPosition = splitContainerControl1.Height - 46;
        }

        private void barButtonItem13_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            long date =DateTime.Now.Ticks;
            DateTime theDate =new DateTime(date);　　

        }

        Image[] _ImageSerias = new Image[5];
        private int _currentImageIndex = 0;

        //像素级比较两个Image对象是否相同
        private bool Equals(Image a, Image b)
        {
            MemoryStream msa = new MemoryStream();
            MemoryStream msb = new MemoryStream();
            a.Save(msa, System.Drawing.Imaging.ImageFormat.Bmp);
            b.Save(msb, System.Drawing.Imaging.ImageFormat.Bmp);
            byte[] ima = msa.GetBuffer();
            byte[] imb = msb.GetBuffer();
            if (ima.Length != imb.Length) 
                return false;
            else
            {
                for (int i = 0; i < ima.Length; i++)
                    if (ima[i] != imb[i]) 
                        return false;
            }
            return true;
        }
        Guid currentGuid;
        private void barButtonItemGetPics_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ThreadStart threadStart = new ThreadStart(CaptureImageThread);
            Thread thread = new Thread(threadStart);
            thread.Start();
        }
        public delegate void DelShowDrawingForm(Image[] image,int cameraId);
        private void ShowDrawingForm(Image[] image,int cameraId)
        {
            frmDrawing myfrmDrawing = new frmDrawing(image,cameraId);
            myfrmDrawing.ShowDialog();
        }
        private void CaptureImageThread()
        {
            //lock (lockerCurrentImage)
            //{
                try
                {
                    CameraWindow camwin = mainMultiplexer.GetCurrentCameraWindow();
                    if (camwin == null)
                    {
                        XtraMessageBox.Show("请选中一个窗格!");
                        return;
                    }
                    _currentImageIndex = 0;
                    currentGuid = camwin.CurrentImageGuid;
                    _ImageSerias[_currentImageIndex++] = (Image)(camwin.CurrentImage.Clone());
                    while (_currentImageIndex < 5)
                    {
                        lock (lockerCurrentImage)
                        {
                            if (currentGuid != camwin.CurrentImageGuid)
                            {
                                _ImageSerias[_currentImageIndex++] = (Image)(camwin.CurrentImage.Clone());
                            }
                            Thread.Sleep(77);                            
                        }

                    }

                    //_ImageSerias[0] = Image.FromFile(@"C:\Users\Public\Pictures\Sample Pictures\Desert.jpg");
                    //_ImageSerias[1] = Image.FromFile(@"C:\Users\Public\Pictures\Sample Pictures\Penguins.jpg");
                    //_ImageSerias[2] = Image.FromFile(@"C:\Users\Public\Pictures\Sample Pictures\Koala.jpg");
                    //_ImageSerias[3] = Image.FromFile(@"C:\Users\Public\Pictures\Sample Pictures\Tulips.jpg");
                    //_ImageSerias[4] = Image.FromFile(@"C:\Users\Public\Pictures\Sample Pictures\Chrysanthemum.jpg");

                    //仅作测试用，摄像头ID设置为1
                    DelShowDrawingForm delShowDrawingForm  = ShowDrawingForm;
                    this.Invoke(delShowDrawingForm, new object[] { _ImageSerias, camwin.CameraID });


                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.ToString());
                }
            //}
        }
    }
}