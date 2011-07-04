using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Windows.Forms;
using CameraViewer.NetWorking;
using CameraViewer.Remoting;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using IntVideoSurv.Business;
using IntVideoSurv.DataAccess;
using IntVideoSurv.Entity;
using CameraViewer.Forms;
using System.IO;
using IntVideoSurv.Business.HiK;
using System.Threading;
using log4net;
using System.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Data.Configuration;
using CameraViewer.Player;
using DevExpress.XtraBars;
using CameraViewer.Tools;


namespace CameraViewer
{
    public partial class MainForm : XtraForm
    {
        public delegate void ImageDataChangeHandle(object sender, DataChangeEventArgs e);
        public delegate void FaceHandle(object sender, DataChangeEventArgs e);
        public delegate void EventHandle(object sender, DataChangeEventArgs e);
        public delegate void VehicleHandle(object sender, DataChangeEventArgs e);

        Dictionary<int, HikVideoServerDeviceDriver> _runningDeviceList;
        Dictionary<int, HikVideoServerCameraDriver> _runningCameraList;
        Dictionary<int, GroupInfo> _listGroup;
        string _errMessage = "";
        Dictionary<int, DeviceInfo> _listDevice;
        Dictionary<int, CameraInfo> _listCam;
        Dictionary<int, CameraInfo> _listAllCam;
        Dictionary<int, LongChang_CameraInfo> _listAllLongChang_Cam;
        Dictionary<string, CameraInfo> _listAllCamStr = new Dictionary<string, CameraInfo>();
        Dictionary<int, DecoderInfo> _listDecoder;
        Dictionary<int, DisplayChannelInfo> _listDisplayChannelInfo;
        Dictionary<int, AlarmIconInfo> _listCurrentAlarmIcon;
        Dictionary<int, CameraIconInfo> _listCurrentCameraIcon;
        Dictionary<int, AlarmIconInfo> _listAllAlarmIcon;
        Dictionary<int, CameraIconInfo> _listAllCameraIcon;
        Dictionary<int, AlarmInfo> _listAlarm;
        Dictionary<int, MapInfo> _listMap;
        OutputTVDeviceDriver _outputTv;
        TcpChannel chan1;
        private CameraWindow _currentcCameraWindow;

        private static readonly ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private GetTransPacket _getTransPacket;

        public MainForm()
        {
#if DEBUG
            while (Login(_inputUsername, _inputPassword, PromoteInfo) != true)
            {
                PromoteInfo = "请输入正确的用户名和密码!";
            }
#else
            CurrentUser = new UserInfo { UserId = 1, UserName = "admin", UserTypeId = 1, UserTypeName = "管理员" };
#endif
            Splash.Splash.Show();
            this.Visible = false;
            //Splash.Splash.Status = "启动.Net Remoting...";
            //BeginRemotingService();
            //Splash.Splash.Status = "启动流媒体服务...";
            //BeginStreamMediaService();

            InitializeComponent();


            _getTransPacket = new GetTransPacket();
            _getTransPacket.LiveDecoderPacketHandle.DataChange += LiveDecoderPacketHandleDataChange;

            //start tcp server
            var thread = new Thread(StartServerForDecoder) { IsBackground = true };
            thread.Start();

            var threadForRecognizer = new Thread(StartServerForRecognizer) { IsBackground = true };
            threadForRecognizer.Start();

            //注册热键
            RegisterHotKey(this.Handle, 201, (int)MyKeys.Alt, (int)Keys.D1); //注册热键Alt+1       
            RegisterHotKey(this.Handle, 202, (int)MyKeys.Alt, (int)Keys.D2); //注册热键Alt+1            
            RegisterHotKey(this.Handle, 203, (int)MyKeys.Alt, (int)Keys.D3); //注册热键Alt+1
            RegisterHotKey(this.Handle, 204, (int)MyKeys.Alt, (int)Keys.D4); //注册热键Alt+1
            RegisterHotKey(this.Handle, 205, (int)MyKeys.Alt, (int)Keys.D5); //注册热键Alt+1
            RegisterHotKey(this.Handle, 206, (int)MyKeys.Alt, (int)Keys.D6); //注册热键Alt+1
            RegisterHotKey(this.Handle, 207, (int)MyKeys.Alt, (int)Keys.D7); //注册热键Alt+1
            RegisterHotKey(this.Handle, 208, (int)MyKeys.Alt, (int)Keys.D8); //注册热键Alt+1
            RegisterHotKey(this.Handle, 209, (int)MyKeys.Alt, (int)Keys.D9); //注册热键Alt+1

            if (!Directory.Exists(Properties.Settings.Default.RecordTempVideoPath))
            {
                Directory.CreateDirectory(Properties.Settings.Default.RecordTempVideoPath);
            }

        }
        private void BeginRemotingService()
        {
            chan1 = new TcpChannel(8085);
            ChannelServices.RegisterChannel(chan1, false);
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

                if (mainMultiplexer.GetCurrentCameraWindow() == null)
                {
                    return;
                }
                string errMsg = "";
                int row = 0, col = 0;
                mainMultiplexer.GetCurrentCameraWindowPosition(ref row, ref col);
                WindowCameraBusiness.Instance.Insert(ref errMsg, new WindowCameraInfo { CameraId = int.Parse(strs[0]), Row = row, Col = col });
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
                    CameraWindow camwin = mainMultiplexer.GetCameraWindow(i, j);
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
            AironixControl.TMCC_PtzClose(ptzHandle);
            AironixControl.TMCC_Done(ptzHandle);
            for (int i = 201; i <=209; i++)
            {
                UnregisterHotKey(this.Handle, i); //注销热键                
            }


        }
        private void barbtnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Exit();

        }
        Dictionary<Keys, bool> _listNumKeyStatus = new Dictionary<Keys, bool>();
        private CameraWindow careCameraWindows = null;

        private void ChangeButtonState(Keys key)
        {
            switch (key)
            {
                case Keys.D1:
                    if (_listNumKeyStatus[key])
                    {
                        barButtonD1.Appearance.ForeColor = Color.Red;
                        barButtonD1.Appearance.Font = new Font("Tahoma",12);
                    }
                    else
                    {
                        barButtonD1.Appearance.ForeColor = Color.Black;
                        barButtonD1.Appearance.Font = new Font("Tahoma", 9);
                    }
                    break;
                case Keys.D2:
                    if (_listNumKeyStatus[key])
                    {
                        barButtonD2.Appearance.ForeColor = Color.Red;
                        barButtonD2.Appearance.Font = new Font("Tahoma", 12);
                    }
                    else
                    {
                        barButtonD2.Appearance.ForeColor = Color.Black;
                        barButtonD2.Appearance.Font = new Font("Tahoma", 9);
                    }
                    break;
                case Keys.D3:
                    if (_listNumKeyStatus[key])
                    {
                        barButtonD3.Appearance.ForeColor = Color.Red;
                        barButtonD3.Appearance.Font = new Font("Tahoma", 12);
                    }
                    else
                    {
                        barButtonD3.Appearance.ForeColor = Color.Black;
                        barButtonD3.Appearance.Font = new Font("Tahoma", 9);
                    }
                    break;
                case Keys.D4:
                    if (_listNumKeyStatus[key])
                    {
                        barButtonD4.Appearance.ForeColor = Color.Red;
                        barButtonD4.Appearance.Font = new Font("Tahoma", 12);
                    }
                    else
                    {
                        barButtonD4.Appearance.ForeColor = Color.Black;
                        barButtonD4.Appearance.Font = new Font("Tahoma", 9);
                    }
                    break;
                case Keys.D5:
                    if (_listNumKeyStatus[key])
                    {
                        barButtonD5.Appearance.ForeColor = Color.Red;
                        barButtonD5.Appearance.Font = new Font("Tahoma", 12);
                    }
                    else
                    {
                        barButtonD5.Appearance.ForeColor = Color.Black;
                        barButtonD5.Appearance.Font = new Font("Tahoma", 9);
                    }
                    break;
                case Keys.D6:
                    if (_listNumKeyStatus[key])
                    {
                        barButtonD6.Appearance.ForeColor = Color.Red;
                        barButtonD6.Appearance.Font = new Font("Tahoma", 12);
                    }
                    else
                    {
                        barButtonD6.Appearance.ForeColor = Color.Black;
                        barButtonD6.Appearance.Font = new Font("Tahoma", 9);
                    }
                    break;
                case Keys.D7:
                    if (_listNumKeyStatus[key])
                    {
                        barButtonD7.Appearance.ForeColor = Color.Red;
                        barButtonD7.Appearance.Font = new Font("Tahoma", 12);
                    }
                    else
                    {
                        barButtonD7.Appearance.ForeColor = Color.Black;
                        barButtonD7.Appearance.Font = new Font("Tahoma", 9);
                    }
                    break;
                case Keys.D8:
                    if (_listNumKeyStatus[key])
                    {
                        barButtonD8.Appearance.ForeColor = Color.Red;
                        barButtonD8.Appearance.Font = new Font("Tahoma", 12);
                    }
                    else
                    {
                        barButtonD8.Appearance.ForeColor = Color.Black;
                        barButtonD8.Appearance.Font = new Font("Tahoma", 9);
                    }
                    break;
                case Keys.D9:
                    if (_listNumKeyStatus[key])
                    {
                        barButtonD9.Appearance.ForeColor = Color.Red;
                        barButtonD9.Appearance.Font = new Font("Tahoma", 12);
                    }
                    else
                    {
                        barButtonD9.Appearance.ForeColor = Color.Black;
                        barButtonD9.Appearance.Font = new Font("Tahoma", 9);
                    }
                    break;
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
            iu = Properties.Settings.Default.LastUser;
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

        /*private void FilterInterface()
        {
            if (CurrentUser.UserTypeName != "管理员")
            {
                if (barButtonItem1 != null)
                {
                    this.barButtonItemSystemSettingMenu.ItemClick -= barButtonItem5_ItemClick;
                    this.barButtonItemSystemSettingMenu.ItemClick += this.barButtonItem1_ItemClick_UpdateUser;
                }
                if (barButtonItemSystemSetting != null)
                {
                    this.barButtonItemSystemSetting.ItemClick -= barButtonItem3_ItemClick_1;
                    this.barButtonItemSystemSetting.ItemClick += this.barButtonItem1_ItemClick_UpdateUser;
                }
            }
        }

        private void barButtonItem1_ItemClick_UpdateUser(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frmUser = new FrmUser(CurrentUser);
            frmUser.ShowDialog();
        }*/

        #endregion

        private void frmMain_Win_Load(object sender, EventArgs e)
        {
            this.Visible = false;
            //FilterInterface();
            InitDataBaseType();
            Splash.Splash.Status = "获取群组信息...";
            _runningDeviceList = new Dictionary<int, HikVideoServerDeviceDriver>();
            _listGroup = GroupBusiness.Instance.GetAllGroupInfos(ref _errMessage);
            cameraView1.ListGroup = _listGroup;
            // Splash.Splash.Status = "初始化设备...";
            //_outputTv = new OutputTVDeviceDriver();
            //_outputTv.Init();

            Splash.Splash.Status = "获取设备信息...";
            _listDevice = DeviceBusiness.Instance.GetAllDeviceInfo(ref _errMessage);
            Splash.Splash.Status = "获取摄像头信息...";
            //videoOutList = new Dictionary<VideoOutputInfo, VideoOutputDriver>();
            _runningCameraList = new Dictionary<int, HikVideoServerCameraDriver>();
            _listAllCam = CameraBusiness.Instance.GetAllCameraInfo(ref _errMessage);
            LoadCameraInCombox();
            InitDataTable();
            InitVehicleDataTable();
            InitEventDataTable();

            splitContainerControlFaceVideo.Visible = false;

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
            
            
            //******************************隆昌************************//
            MakeLongChangInterface();
            _listAllLongChang_Cam = LongChang_CameraBusiness.Instance.GetCamInfoByDeviceUserId(ref _errMessage, CurrentUser.UserId);
            barStaticItemCameraNo.Caption = _listAllLongChang_Cam.Count.ToString();
            LoadAllCameraInLongChang();

            //******************************隆昌************************//
            
            DateTime dtNow = DateTime.Now;
            teStartTimeFace.EditValue = dtNow.AddDays(-1);
            teStartTimeVehicle.EditValue = dtNow.AddDays(-1);
            teStartTimeEvent.EditValue = dtNow.AddDays(-1);

            teEndTimeFace.EditValue = dtNow;
            teEndTimeVehicle.EditValue = dtNow;
            teEndTimeEvent.EditValue = dtNow;

            this.Visible = true;
        }

        private void MakeLongChangInterface()
        {
            dockPanel1.Visible = dockPanelResult.Visible = dockPanelAlarm.Visible = false;
            int iRow = 3, iCol = 3;
            Util.GetRowCol(9, ref iRow, ref iCol);
            mainMultiplexer.SetRowCol(iRow, iCol);
            mainMultiplexer.Refresh();
            _listNumKeyStatus.Add(Keys.D1, false);
            _listNumKeyStatus.Add(Keys.D2, false);
            _listNumKeyStatus.Add(Keys.D3, false);
            _listNumKeyStatus.Add(Keys.D4, false);
            _listNumKeyStatus.Add(Keys.D5, false);
            _listNumKeyStatus.Add(Keys.D6, false);
            _listNumKeyStatus.Add(Keys.D7, false);
            _listNumKeyStatus.Add(Keys.D8, false);
            _listNumKeyStatus.Add(Keys.D9, false);

            dockPanelPtzControl.Visible = false;
            barStaticItemCurrentUser.Caption = CurrentUser.UserName;
            barSubItemMenuView.Visibility = BarItemVisibility.Never;
            barSubItemMenuQuery.Visibility = BarItemVisibility.Never;
            barButtonItem8.Visibility = BarItemVisibility.Never;
            barButtonItem9.Visibility = BarItemVisibility.Never;
            barButtonItem10.Visibility = BarItemVisibility.Never;
            barButtonItem11.Visibility = BarItemVisibility.Never;
            barButtonItem12.Visibility = BarItemVisibility.Never;
            barButtonItem13.Visibility = BarItemVisibility.Never;
            barButtonItem14.Visibility = BarItemVisibility.Never;
            barButtonItem15.Visibility = BarItemVisibility.Never;
            barButtonItem16.Visibility = BarItemVisibility.Never;
            barButtonItem17.Visibility = BarItemVisibility.Never;
            barButtonItem18.Visibility = BarItemVisibility.Never;
            barButtonItem19.Visibility = BarItemVisibility.Never;
            barButtonItem20.Visibility = BarItemVisibility.Never;
            barButtonItem21.Visibility = BarItemVisibility.Never;
            barButtonItemPlayTwoFiles.Visibility = BarItemVisibility.Never;
            barButtonItemGetPics.Visibility = BarItemVisibility.Never;
        }

        private void InitDataBaseType()
        {
            DatabaseSettings v = (DatabaseSettings)ConfigurationManager.GetSection("dataConfiguration");

            switch (v.DefaultDatabase)
            {
                case "SqlServerConn":
                    DbParasBusiness.SetDataBase(MyDBType.SqlServer);
                    break;
                case "AccessConn":
                    DbParasBusiness.SetDataBase(MyDBType.Access);
                    break;
                case "MySqlConn":
                    DbParasBusiness.SetDataBase(MyDBType.Mysql);
                    break;
                case "OracleConn":
                    DbParasBusiness.SetDataBase(MyDBType.Oracle);
                    break;
                default:
                    DbParasBusiness.SetDataBase(MyDBType.Oracle);
                    break;
            }
        }

        private void LoadCameraInCombox()
        {
            checkedComboBoxEditFaceCamera.Properties.Items.Add("当前摄像头", true);
            checkedComboBoxEditVehicleCamera.Properties.Items.Add("当前摄像头", true);
            checkedComboBoxEditEventCamera.Properties.Items.Add("当前摄像头", true);
            try
            {
                foreach (var VARIABLE in _listAllCam)
                {
                    _listAllCamStr.Add(VARIABLE.Value.DeviceName + ":" + VARIABLE.Value.Name, VARIABLE.Value);
                    checkedComboBoxEditFaceCamera.Properties.Items.Add(
                        VARIABLE.Value.DeviceName + ":" + VARIABLE.Value.Name, false);
                    checkedComboBoxEditVehicleCamera.Properties.Items.Add(
                        VARIABLE.Value.DeviceName + ":" + VARIABLE.Value.Name, false);
                    checkedComboBoxEditEventCamera.Properties.Items.Add(
                        VARIABLE.Value.DeviceName + ":" + VARIABLE.Value.Name, false);
                }
            }
            catch (System.Exception e)
            {
            	
            }

            checkedComboBoxEditUserSelection.Properties.Items.Add("无", true);
            checkedComboBoxEditUserSelection.Properties.Items.Add("停止", false);
            checkedComboBoxEditUserSelection.Properties.Items.Add("跨线", false);
            checkedComboBoxEditUserSelection.Properties.Items.Add("逆行", false);
            checkedComboBoxEditUserSelection.Properties.Items.Add("变道", false);
            
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
            if (_listDisplayChannelInfo == null) return;
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
                        CameraWindow camwin = mainMultiplexer.GetCameraWindow(i, j);
                        IntPtr intPtr = new IntPtr();
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

        private void LoadAllCameraInLongChang()
        {
            if (_listAllLongChang_Cam == null)
            {
                return;
            }

            int iRow = 3;
            int iCol = 3;
            int iCount = 0;
            mainMultiplexer.CloseAll();
            mainMultiplexer.CamerasVisible = true;
            mainMultiplexer.CellWidth = 320;
            mainMultiplexer.CellHeight = 240;
            mainMultiplexer.FitToWindow = true;
            mainMultiplexer.SetRowCol(3,3);
 
            iCount = 0;

            foreach (var VARIABLE in _listAllLongChang_Cam)
            {
                int i = iCount / iRow;
                int j = iCount % iCol;
                CameraWindow cameraWindow = mainMultiplexer.GetCameraWindow(i, j);
                AirnoixCamera airnoixCameraNew;
                //开始连接摄像头
                airnoixCameraNew = new AirnoixCamera(cameraWindow.Handle);
                airnoixCameraNew.DisplayPos = new Rectangle(0, 0, cameraWindow.Width, cameraWindow.Height);
                airnoixCameraNew.Ip = VARIABLE.Value.IP;
                airnoixCameraNew.Port = VARIABLE.Value.Port;
                airnoixCameraNew.UserName = VARIABLE.Value.UserName;
                airnoixCameraNew.Password = VARIABLE.Value.PassWord;
                airnoixCameraNew.Id = VARIABLE.Key;
                airnoixCameraNew.SaveTo = "c:\\";
                airnoixCameraNew.Type = VARIABLE.Value.Type;
                cameraWindow.AirnoixCamera = airnoixCameraNew;
                airnoixCameraNew.Start();

                //
                iCount = iCount + 1;
            }
            mainMultiplexer.Rows = iRow;
            mainMultiplexer.Cols = iCol;
            mainMultiplexer.SingleCameraMode = false;
            mainMultiplexer.CamerasVisible = true;
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var tag = ((ContextMenuStrip)((ToolStripMenuItem)sender).Owner).SourceControl.Tag;
            if (tag is AlarmIconInfo)
            {
                AlarmIconInfo alarmIconInfo = (AlarmIconInfo)tag;
                AlarmIconBusiness.Instance.Delete(ref _errMessage, alarmIconInfo.AlarmId);
                _listCurrentAlarmIcon.Remove(alarmIconInfo.AlarmId);
                _listAllAlarmIcon.Remove(alarmIconInfo.AlarmId);
                ((ContextMenuStrip)((ToolStripMenuItem)sender).Owner).SourceControl.Dispose();
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
                    if ((sites.Substring(i, 1) == "1"))
                    {
                        if ((_listAlarm.ContainsKey(sites.Length - i)) && _listAlarmSites.ContainsKey(sites.Length - i) == false)
                        {
                            _listAlarmSites.Add(sites.Length - i, _listAlarm[sites.Length - i]);
                        }
                        else if ((_listAlarm.ContainsKey(sites.Length - i)) && _listAlarmSites.ContainsKey(sites.Length - i) == true)
                        {
                            _listAlarmSites[sites.Length - i] = _listAlarm[sites.Length - i];
                        }

                    }
                }
                HikVideoServerCameraDriver.AlarmSites = null;
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
                    CameraWindow cameraWindow = mainMultiplexer.GetCameraWindow(windowCameraInfo.Value.Row, windowCameraInfo.Value.Col);
                    if (cameraWindow.CurrentImage != null) cameraWindow.CurrentImage.Dispose();
                    cameraWindow.CurrentImage = liveDecoderPacketHandle.CurrentNetImage.Image;
                    cameraWindow.CameraID = windowCameraInfo.Key;
                    cameraWindow.Refresh();
                }

            };
        }
        #region 人脸实时显示
        private void LiveFacePacketHandleDataChange(object sender, DataChangeEventArgs e)
        {
            if (radioGroupFace.SelectedIndex == 0)
            {
                var livePacketHandle = (LiveRecognizerFacePacketHandle)sender;
                if (livePacketHandle == null) return;
                //处理人脸 
                ShowLiveFace(livePacketHandle);
            }


        }
        List<Face> listLiveFace = new List<Face>();
        protected void ShowLiveFace(LiveRecognizerFacePacketHandle liveRecognizerFacePacket)
        {
            CrossThreadOperationControl crossAdd = delegate()
            {
                string errMsg = "";
                Face face = liveRecognizerFacePacket.CurrentFace;
                if (face == null) return;
                if (!isCameraWatched(face.CameraInfo.CameraId)) return;
                listLiveFace.Insert(0, face);
                if (listLiveFace.Count > _numberOfPerPage)
                {
                    listLiveFace.RemoveRange(_numberOfPerPage, listLiveFace.Count - _numberOfPerPage);
                }
                FillGridControlFaceDetail(listLiveFace);
            };
        }

        private bool isCameraWatched(int cameraid)
        {
            string[] selectCameras = checkedComboBoxEditFaceCamera.Text.Split(',');
            foreach (string selectCamera in selectCameras)
            {
                string changeselectCamera = selectCamera.Trim();
                if (changeselectCamera == "当前摄像头")
                {
                    CameraWindow currentCameraWindow = mainMultiplexer.GetCurrentCameraWindow();
                    if (currentCameraWindow != null)
                    {
                        if (cameraid == currentCameraWindow.CameraID)
                        {
                            return true;
                        }
                    }
                }
                else
                {
                    if (cameraid == _listAllCamStr[changeselectCamera].CameraId)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        #endregion

        #region 车牌实时显示
        private void LiveVehiclePacketHandleDataChange(object sender, DataChangeEventArgs e)
        {

            var livePacketHandle = (LiveRecognizerVehiclePacketHandle)sender;
            if (livePacketHandle == null) return;
            //处理车牌 
            ShowLiveVehicle(livePacketHandle);

        }
        protected void ShowLiveVehicle(LiveRecognizerVehiclePacketHandle liveRecognizerVehiclePacket)
        {
            CrossThreadOperationControl crossAdd = delegate()
            {
                string errMsg = "";

            };
        }

        #endregion


        #region 事件实时显示
        private void LiveEventePacketHandleDataChange(object sender, DataChangeEventArgs e)
        {

            var livePacketHandle = (LiveRecognizerEventPacketHandle)sender;
            if (livePacketHandle == null) return;
            //处理事件 
            ShowLiveEvent(livePacketHandle);

        }
        protected void ShowLiveEvent(LiveRecognizerEventPacketHandle liveRecognizerEventPacket)
        {
            CrossThreadOperationControl crossAdd = delegate()
            {
                string errMsg = "";

            };
        }

        #endregion

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
        private readonly TcpClient tcpClientDecoder = new TcpClient();

        private Socket _socket2Decoder;

        public void StartServerForDecoder()
        {
            try
            {
                _socket2Decoder = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                _socket2Decoder.Bind(new IPEndPoint(new IPAddress(new byte[] { 127, 0, 0, 1 }), 8888));
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
            try
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
            catch (Exception)
            {

                ;
            }

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

            recognizerClientConnectionConnection.LiveRecognizerEventPacketHandle.DataChange += LiveEventePacketHandleDataChange;
            recognizerClientConnectionConnection.LiveRecognizerFacePacketHandle.DataChange +=
                LiveFacePacketHandleDataChange;
            recognizerClientConnectionConnection.LiveRecognizerVehiclePacketHandle.DataChange +=
    LiveVehiclePacketHandleDataChange;

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
            CameraWindow cameraWindow = mainMultiplexer.GetCameraWindow(1, 1);
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
                testimage = !testimage;
                if (testimage)
                {
                    CameraWindow cameraWindow = mainMultiplexer.GetCameraWindow(1, 1);
                    if (cameraWindow.CurrentImage != null) cameraWindow.CurrentImage.Dispose();
                    cameraWindow.CurrentImage = Image.FromFile(@"C:\imm_2010_07_06_18_35_29_212.JPG");
                    cameraWindow.CameraID = 5;
                    cameraWindow.CurrentImageGuid = guidA;
                    cameraWindow.Refresh();

                }
                else
                {
                    CameraWindow cameraWindow = mainMultiplexer.GetCameraWindow(1, 1);
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
            mainMultiplexer.SetRowCol(iRow, iCol);
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
            long date = DateTime.Now.Ticks;
            DateTime theDate = new DateTime(date);

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
        public delegate void DelShowDrawingForm(Image[] image, int cameraId);
        private void ShowDrawingForm(Image[] image, int cameraId)
        {
            frmDrawing myfrmDrawing = new frmDrawing(image, cameraId);
            myfrmDrawing.ShowDialog();
        }
        private void CaptureImageThread()
        {
            //lock (lockerCurrentImage)
            //{
            try
            {
                _currentcCameraWindow = mainMultiplexer.GetCurrentCameraWindow();
                if (_currentcCameraWindow == null)
                {
                    XtraMessageBox.Show("请选中一个窗格!");
                    return;
                }
                _currentImageIndex = 0;
                currentGuid = _currentcCameraWindow.CurrentImageGuid;
                _ImageSerias[_currentImageIndex++] = (Image)(_currentcCameraWindow.CurrentImage.Clone());
                while (_currentImageIndex < 5)
                {
                    lock (lockerCurrentImage)
                    {
                        if (currentGuid != _currentcCameraWindow.CurrentImageGuid)
                        {
                            _ImageSerias[_currentImageIndex++] = (Image)(_currentcCameraWindow.CurrentImage.Clone());
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
                DelShowDrawingForm delShowDrawingForm = ShowDrawingForm;
                this.Invoke(delShowDrawingForm, new object[] { _ImageSerias, _currentcCameraWindow.CameraID });


            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString());
            }
            //}
        }

        #region 人脸显示相关

        private void radioGroupFace_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (radioGroupFace.SelectedIndex)
            {
                //实时
                case 0:
                    teStartTimeFace.Enabled = teEndTimeFace.Enabled = btnQueryFace.Enabled = false;
                    gridControlFace.DataSource = null;
                    break;
                case 1:
                    teStartTimeFace.Enabled = teEndTimeFace.Enabled = btnQueryFace.Enabled = true;
                    gridControlFace.DataSource = dataTableFace;
                    splitContainerControlFaceVideo.Visible = false;
                    if (_lastVideoPort != -1)
                    {
                        HikPlayer.PlayM4_CloseFile(_lastVideoPort);
                    }
                    break;
                default:
                    teStartTimeFace.Enabled = teEndTimeFace.Enabled = btnQueryFace.Enabled = false;
                    break;

            }
            pictureEditFace.Image = null;

            splitContainerControlFaceVideo.Visible = (1 == radioGroupFace.SelectedIndex);
        }

        private void btnQueryFace_Click(object sender, EventArgs e)
        {

            ReloadQueryData();
        }

        string GenerateFaceQueryCondition()
        {
            string str = " and CapturePicture.CameraId in (";
            string[] selectCameras = checkedComboBoxEditFaceCamera.Text.Split(',');
            foreach (string selectCamera in selectCameras)
            {
                string changeselectCamera = selectCamera.Trim();
                if (changeselectCamera == "当前摄像头")
                {
                    CameraWindow currentCameraWindow = mainMultiplexer.GetCurrentCameraWindow();
                    if (currentCameraWindow != null)
                    {
                        str += currentCameraWindow.CameraID + ",";
                    }
                    else
                    {
                        str += "null,";
                    }
                }
                else
                {
                    str += _listAllCamStr[changeselectCamera].CameraId + ",";
                }
            }
            str = str.Substring(0, str.Length - 1) + ") ";

            DateTime startTime = DateTime.Parse(teStartTimeFace.EditValue.ToString());
            DateTime endTime = DateTime.Parse(teEndTimeFace.EditValue.ToString());


            if (DateTime.Compare(startTime, endTime) == 0)
            {
                XtraMessageBox.Show("时间不能相等！");
                return "";
            }
            else if ((DateTime.Compare(startTime, endTime) > 0))
            {
                XtraMessageBox.Show("起始时间不能大于结束时间！");
                return "";
            }
            if (DataBaseParas.DBType ==MyDBType.SqlServer)
            {
                str += " and (CapturePicture.[DateTime] between convert(DateTime,'" + teStartTimeFace.EditValue + "') and convert(DateTime,'" + teEndTimeFace.EditValue + "'))";
             
            }
            else
            {
                str += " and (CapturePicture.DateTime between to_date('" + teStartTimeFace.EditValue + "','YYYY/MM/DD HH24:mi:ss' ) and to_date('" + teEndTimeFace.EditValue + "','YYYY/MM/DD HH24:mi:ss' ))";
               
            }

            return str;
        }
        DataTable dataTableFace = new DataTable();
        private byte[] GetImageData(string fileName)
        {
            Image img = Image.FromFile(fileName);
            MemoryStream mem = new MemoryStream();
            img.Save(mem, System.Drawing.Imaging.ImageFormat.Bmp);
            return mem.GetBuffer();
        }
        private void ReloadQueryData()
        {
            string errMessage = "";
            string faceQueryCondition = GenerateFaceQueryCondition();
            _totalCount = FaceBusiness.Instance.GetFaceQuantity(ref errMessage, faceQueryCondition);
            CaculatPages();
            Dictionary<int, Face> listFace = FaceBusiness.Instance.GetFaceCustom(ref errMessage, faceQueryCondition, _currentPage, _numberOfPerPage);
            //Dictionary<int, Face> listFace = new Dictionary<int, Face>();
            //listFace.Add(1, new Face() { CameraInfo = new CameraInfo() { CameraId = 1, Name = "test", DeviceName = "hello" }, FaceID = 101, CapturePicture = new CapturePicture() { CameraID = 1, Datetime = DateTime.Now, FilePath = @"c:\a.jpg" }, FacePath = @"c:\b.jpg", score = 0.333f, VideoInfo = new VideoInfo() { FilePath = @"D:\VideoOutput\68\2011\05\01\16\23.264" } });
            //listFace.Add(2, new Face() { CameraInfo = new CameraInfo() { CameraId = 2, Name = "abc", DeviceName = "world" }, FaceID = 102, CapturePicture = new CapturePicture() { CameraID = 1, Datetime = DateTime.Now.AddDays(-100), FilePath = @"c:\b.jpg" }, FacePath = @"c:\b.jpg", score = 0.555f, VideoInfo = new VideoInfo() { FilePath = @"D:\VideoOutput\68\2011\05\01\14\16.264" } });

            FillGridControlFaceDetail(listFace);
        }
        private void FillGridControlFaceDetail(Dictionary<int, Face> listFace)
        {

            dataTableFace.Rows.Clear();
            if (listFace == null) return;
            int i = (_currentPage - 1) * _numberOfPerPage + 1;


            foreach (var variable in listFace)
            {
                dataTableFace.Rows.Add(i++,
                                       GetImageData(variable.Value.FacePath),
                                       variable.Value.CapturePicture.Datetime,
                                       variable.Value.CameraInfo.Name,
                                       variable.Value.score,
                                       variable.Value);
            }
            GridColumn column;
            RepositoryItemPictureEdit pictureEdit = gridControlFace.RepositoryItems.Add("PictureEdit") as RepositoryItemPictureEdit;
            pictureEdit.SizeMode = PictureSizeMode.Zoom;
            pictureEdit.NullText = " ";
            column = advBandedGridViewFace.Columns["照片"];
            column.ColumnEdit = pictureEdit;
            gridControlFace.DataSource = dataTableFace;
            advBandedGridViewFace.Columns["时间"].DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            advBandedGridViewFace.Columns["人脸对象"].Visible = false;

            HikPlayer.PlayM4_CloseFile(_lastVideoPort);
            splitContainerControlFaceVideo.Panel1.Refresh();
            splitContainerControlFaceVideo.Visible = false;


        }

        private void FillGridControlFaceDetail(List<Face> listFace)
        {

            dataTableFace.Rows.Clear();
            if (listFace == null) return;
            int i = (_currentPage - 1) * _numberOfPerPage + 1;


            foreach (var variable in listFace)
            {
                dataTableFace.Rows.Add(i++,
                                       GetImageData(variable.FacePath),
                                       variable.CapturePicture.Datetime,
                                       variable.CameraInfo.Name,
                                       variable.score,
                                       variable);
            }
            GridColumn column;
            RepositoryItemPictureEdit pictureEdit = gridControlFace.RepositoryItems.Add("PictureEdit") as RepositoryItemPictureEdit;
            pictureEdit.SizeMode = PictureSizeMode.Zoom;
            pictureEdit.NullText = " ";
            column = advBandedGridViewFace.Columns["照片"];
            column.ColumnEdit = pictureEdit;
            gridControlFace.DataSource = dataTableFace;
            advBandedGridViewFace.Columns["时间"].DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            advBandedGridViewFace.Columns["人脸对象"].Visible = false;

            HikPlayer.PlayM4_CloseFile(_lastVideoPort);
            splitContainerControlFaceVideo.Panel1.Refresh();
            splitContainerControlFaceVideo.Visible = false;


        }


        private void InitDataTable()
        {
            dataTableFace.Columns.Add("索引号", typeof(int));
            dataTableFace.Columns.Add("照片", typeof(byte[]));

            dataTableFace.Columns.Add("时间", typeof(DateTime));
            dataTableFace.Columns.Add("地点");
            dataTableFace.Columns.Add("置信度", typeof(float));
            dataTableFace.Columns.Add("人脸对象", typeof(Face));
        }
        //


        private Face _selectedFace;
        private void advBandedGridViewFace_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (advBandedGridViewFace.SelectedRowsCount > 0)
            {
                int getSelectedRow = this.advBandedGridViewFace.GetSelectedRows()[0];
                _selectedFace = (Face)(this.advBandedGridViewFace.GetRowCellValue(getSelectedRow, "人脸对象"));
                FillPicVideo(_selectedFace);
            }
        }

        private int _lastVideoPort = -1;
        private void FillPicVideo(Face face)
        {
            if (File.Exists(face.CapturePicture.FilePath))
            {
                pictureEditFace.Image = Image.FromFile(face.CapturePicture.FilePath);
            }
            if (File.Exists(face.VideoInfo.FilePath))
            {
                if (_lastVideoPort != -1)
                {
                    bool ret = HikPlayer.PlayM4_CloseFile(_lastVideoPort);
                }
                if (File.Exists(face.VideoInfo.FilePath))
                {
                    _lastVideoPort = 1;
                    splitContainerControlFaceVideo.Visible = true;
                    HikPlayer.PlayM4_OpenFile(_lastVideoPort, face.VideoInfo.FilePath);
                    HikPlayer.PlayM4_Play(_lastVideoPort, splitContainerControlFaceVideo.Panel1.Handle);
                }

            }

        }


        private void advBandedGridViewFace_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            if (advBandedGridViewFace.SelectedRowsCount > 0)
            {
                int getSelectedRow = this.advBandedGridViewFace.GetSelectedRows()[0];
                _selectedFace = (Face)(this.advBandedGridViewFace.GetRowCellValue(getSelectedRow, "人脸对象"));
                FillPicVideo(_selectedFace);
            }
        }

        private void advBandedGridViewFace_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString().Trim();
            }
        }

        private void barButtonItem14_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            JustForTest justForTest = new JustForTest();
            justForTest.ShowDialog();
        }

        private void simpleButton7_Click(object sender, EventArgs e)
        {
            HikPlayer.PlayM4_Play(_lastVideoPort, splitContainerControlFaceVideo.Panel1.Handle);
        }

        private bool _isPaused;
        private void simpleButton8_Click(object sender, EventArgs e)
        {
            _isPaused = !_isPaused;
            HikPlayer.PlayM4_Pause(_lastVideoPort, _isPaused);
        }

        private void simpleButton9_Click(object sender, EventArgs e)
        {
            HikPlayer.PlayM4_CloseFile(_lastVideoPort);
            _lastVideoPort = -1;
            _isPaused = false;
        }

        private void splitContainerControl2_Panel2_SizeChanged(object sender, EventArgs e)
        {
            splitContainerControlFaceVideo.SplitterPosition = splitContainerControlFaceVideo.Height - 32;
        }
        private void LiveRegognizerFacePacketHandleDataChange(object sender, DataChangeEventArgs e)
        {

            var livePacketHandle = (LiveRecognizerFacePacketHandle)sender;
            if (livePacketHandle == null) return;
            //处理视频 
            //ShowLiveVideo(livePacketHandle);

        }

        private void cameraView1_Load(object sender, EventArgs e)
        {

        }

        private int _totalPages;
        private int _totalCount;
        private int _currentPage = 1;
        private int _numberOfPerPage = 20;

        private void btnFacePrePage_Click(object sender, EventArgs e)
        {
            _currentPage--;
            if (_currentPage < 1)
            {
                _currentPage++;
                return;
            }
            ReloadQueryData();
        }



        private void btnFaceNextPage_Click(object sender, EventArgs e)
        {
            _currentPage++;
            if (_currentPage > _totalPages)
            {
                _currentPage--;
                return;
            }
            ReloadQueryData();
        }

        private void btnFaceLastPage_Click(object sender, EventArgs e)
        {
            _currentPage = _totalPages;
            ReloadQueryData();
        }

        private void btnFaceFirstPage_Click(object sender, EventArgs e)
        {
            _currentPage = 1;
            ReloadQueryData();
        }

        private void cbeFaceNumberPerPage_SelectedValueChanged(object sender, EventArgs e)
        {

            _numberOfPerPage = int.Parse(cbeFaceNumberPerPage.Text);
            if (radioGroupFace.SelectedIndex == 1)
            {
                _currentPage = 1;
                CaculatPages();
                ReloadQueryData();
            }

        }
        private void CaculatPages()
        {
            if (_totalCount % _numberOfPerPage == 0)
            {
                _totalPages = _totalCount / _numberOfPerPage;
            }
            else
            {
                _totalPages = (int)((float)_totalCount / _numberOfPerPage) + 1;
            }
            lblFaceCurrentPage.Text = string.Format("当前：{0}/{1}页", _currentPage, _totalPages);
        }
        #endregion

        #region 车辆显示相关

        private int _totalPagesForVehicle;
        private int _totalCountForVehicle;
        private int _currentPageForVehicle = 1;
        private int _numberOfPerPageForVehicle = 20;
        private void radioGroupVehicle_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (radioGroupVehicle.SelectedIndex)
            {
                //实时
                case 0:
                    teStartTimeVehicle.Enabled = teEndTimeVehicle.Enabled = btnQueryVehicle.Enabled = false;
                    gridControlVehicle.DataSource = null;
                    break;
                case 1:
                    teStartTimeVehicle.Enabled = teEndTimeVehicle.Enabled = btnQueryVehicle.Enabled = true;
                    gridControlVehicle.DataSource = dataTableVehicle;
                    splitContainerControlVideoVehicle.Visible = false;
                    if (_lastVideoPort != -1)
                    {
                        HikPlayer.PlayM4_CloseFile(_lastVideoPort);
                    }
                    break;
                default:
                    teStartTimeVehicle.Enabled = teEndTimeVehicle.Enabled = btnQueryVehicle.Enabled = false;
                    break;

            }
            pictureEditVehicle.Image = null;

            splitContainerControlVideoVehicle.Visible = (1 == radioGroupVehicle.SelectedIndex);
        }

        private void btnQueryVehicle_Click(object sender, EventArgs e)
        {
            ReloadQueryDataForVehicle();
        }

        string GenerateVehicleQueryCondition()
        {
            string str = " and CapturePicture.CameraId in (";
            string[] selectCameras = checkedComboBoxEditVehicleCamera.Text.Split(',');
            foreach (string selectCamera in selectCameras)
            {
                string changeselectCamera = selectCamera.Trim();
                if (changeselectCamera == "当前摄像头")
                {
                    CameraWindow currentCameraWindow = mainMultiplexer.GetCurrentCameraWindow();
                    if (currentCameraWindow != null)
                    {
                        str += currentCameraWindow.CameraID + ",";
                    }
                    else
                    {
                        str += "null,";
                    }
                }
                else
                {
                    str += _listAllCamStr[changeselectCamera].CameraId + ",";
                }
            }
            str = str.Substring(0, str.Length - 1) + ") ";

            DateTime startTime = DateTime.Parse(teStartTimeVehicle.EditValue.ToString());
            DateTime endTime = DateTime.Parse(teEndTimeVehicle.EditValue.ToString());


            if (DateTime.Compare(startTime, endTime) == 0)
            {
                XtraMessageBox.Show("时间不能相等！");
                return "";
            }
            else if ((DateTime.Compare(startTime, endTime) > 0))
            {
                XtraMessageBox.Show("起始时间不能大于结束时间！");
                return "";
            }
            if (textEditPlateNumber.Text == "")
            {
                str += " and (CapturePicture.[DateTime] between convert(DateTime,'" + teStartTimeVehicle.EditValue + "') and convert(DateTime,'" + teEndTimeVehicle.EditValue + "'))";
            }
            else
            {
                //platenumber有没有记录
                if (VehicleBusiness.Instance.GetVehicleCountByPlateNumber(ref _errMessage,textEditPlateNumber.Text) == true)
                {
                    str += " and (CapturePicture.[DateTime] between convert(DateTime,'" + teStartTimeVehicle.EditValue + "') and convert(DateTime,'" + teEndTimeVehicle.EditValue + "'))";
                    str += " and (Vehicle.platenumber = " + textEditPlateNumber.Text + ")";
                }
                else
                {
                    XtraMessageBox.Show("没有对应的车牌号码！");
                    return "";
                }
                
            }

            return str;
        }
        DataTable dataTableVehicle = new DataTable();
        private void ReloadQueryDataForVehicle()
        {
            string errMessage = "";
            string faceQueryCondition = GenerateVehicleQueryCondition();
            if (faceQueryCondition=="")
            {
                return;
            }
            _totalCount = VehicleBusiness.Instance.GetVehicleQuantity(ref errMessage, faceQueryCondition);
            CaculatPagesForVehicle();
            Dictionary<int, Vehicle> listVehicle = VehicleBusiness.Instance.GetVehicleCustom(ref errMessage, faceQueryCondition, _currentPage, _numberOfPerPage);
            //Dictionary<int, Face> listFace = new Dictionary<int, Face>();
            //listFace.Add(1, new Face() { CameraInfo = new CameraInfo() { CameraId = 1, Name = "test", DeviceName = "hello" }, FaceID = 101, CapturePicture = new CapturePicture() { CameraID = 1, Datetime = DateTime.Now, FilePath = @"c:\a.jpg" }, FacePath = @"c:\b.jpg", score = 0.333f, VideoInfo = new VideoInfo() { FilePath = @"D:\VideoOutput\68\2011\05\01\16\23.264" } });
            //listFace.Add(2, new Face() { CameraInfo = new CameraInfo() { CameraId = 2, Name = "abc", DeviceName = "world" }, FaceID = 102, CapturePicture = new CapturePicture() { CameraID = 1, Datetime = DateTime.Now.AddDays(-100), FilePath = @"c:\b.jpg" }, FacePath = @"c:\b.jpg", score = 0.555f, VideoInfo = new VideoInfo() { FilePath = @"D:\VideoOutput\68\2011\05\01\14\16.264" } });
            if (listVehicle==null)
            {
                listVehicle = new Dictionary<int, Vehicle>();
                listVehicle.Add(1, new Vehicle() { accident = true, CameraInfo = new CameraInfo() { CameraId = 1, Name = "test", DeviceName = "hello" }, CapturePicture = new CapturePicture() { CameraID = 1, Datetime = DateTime.Now, FilePath = @"c:\a.jpg" },confidence = 35,linechange = false,PictureID = 1,platecolor = "000255000",
                platenumber = "川A12345",REctId=1,speed = 50});
                listVehicle.Add(2, new Vehicle()
                {
                    accident = true,
                    CameraInfo = new CameraInfo() { CameraId = 1, Name = "test", DeviceName = "hello" },
                    CapturePicture = new CapturePicture() { CameraID = 1, Datetime = DateTime.Now, FilePath = @"c:\a.jpg" },
                    confidence = 35,
                    linechange = false,
                    PictureID = 1,
                    platecolor = "000255000",
                    platenumber = "川A12345",
                    REctId = 1,
                    speed = 50
                });
            }

            FillGridControlVehicleDetail(listVehicle);
        }
        private void FillGridControlVehicleDetail(Dictionary<int, Vehicle> listVehicle)
        {
            dataTableVehicle.Rows.Clear();
            if (listVehicle == null) return;
            int i = (_currentPage - 1) * _numberOfPerPage + 1;


            foreach (var variable in listVehicle)
            {
                dataTableVehicle.Rows.Add(i++,
                                       variable.Value.platenumber,
                                       variable.Value.CapturePicture.Datetime,
                                       variable.Value.CameraInfo.Name,
                                       variable.Value.confidence,
                                       variable.Value.speed,
                                       variable.Value.stemagainst,
                                       variable.Value.stop,
                                       variable.Value.accident,
                                       variable.Value.linechange,
                                       variable.Value.platecolor,
                                       variable.Value.vehiclecolor,
                                       variable.Value
                                       );
            }
            //GridColumn column;
            //RepositoryItemPictureEdit pictureEdit = gridControlFace.RepositoryItems.Add("PictureEdit") as RepositoryItemPictureEdit;
            //pictureEdit.SizeMode = PictureSizeMode.Zoom;
            //pictureEdit.NullText = " ";
            //column = advBandedGridViewFace.Columns["照片"];
            //column.ColumnEdit = pictureEdit;
            gridControlVehicle.DataSource = dataTableVehicle;
            advBandedGridViewVehicle.Columns["时间"].DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            advBandedGridViewVehicle.Columns["车辆对象"].Visible = false;
            advBandedGridViewVehicle.Columns["speed"].Visible = false;
            advBandedGridViewVehicle.Columns["stemagainst"].Visible = false;
            advBandedGridViewVehicle.Columns["stop"].Visible = false;
            advBandedGridViewVehicle.Columns["accident"].Visible = false;
            advBandedGridViewVehicle.Columns["linechange"].Visible = false;
            advBandedGridViewVehicle.Columns["platecolor"].Visible = false;
            advBandedGridViewVehicle.Columns["vehiclecolor"].Visible = false;

            HikPlayer.PlayM4_CloseFile(_lastVideoPort1);
            splitContainerControlVideoVehicle.Panel1.Refresh();
            splitContainerControlVideoVehicle.Visible = false;
        }
        //
        private void InitVehicleDataTable()
        {
            dataTableVehicle.Columns.Add("索引号", typeof(int));
            dataTableVehicle.Columns.Add("车牌号", typeof(string));

            dataTableVehicle.Columns.Add("时间", typeof(DateTime));
            dataTableVehicle.Columns.Add("地点", typeof(string));
            dataTableVehicle.Columns.Add("置信度", typeof(float));
            dataTableVehicle.Columns.Add("speed", typeof(float));
            dataTableVehicle.Columns.Add("stemagainst", typeof(bool));
            dataTableVehicle.Columns.Add("stop", typeof(bool));
            dataTableVehicle.Columns.Add("accident", typeof(bool));
            dataTableVehicle.Columns.Add("linechange", typeof(bool));
            dataTableVehicle.Columns.Add("platecolor", typeof(string));
            dataTableVehicle.Columns.Add("vehiclecolor", typeof(string));
            dataTableVehicle.Columns.Add("车辆对象", typeof(Vehicle));
        }
       
        private Vehicle _selectedVehicle;
        private void advBandedGridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (advBandedGridViewVehicle.SelectedRowsCount > 0)
            {
                int getSelectedRow = this.advBandedGridViewVehicle.GetSelectedRows()[0];
                _selectedVehicle = (Vehicle)(this.advBandedGridViewVehicle.GetRowCellValue(getSelectedRow, "车辆对象"));
                FillPicVideoVehicle(_selectedVehicle);
            }
        }

        private int _lastVideoPort1 = -1;
        private void FillPicVideoVehicle(Vehicle ovehicle)
        {
            if (File.Exists(ovehicle.CapturePicture.FilePath))
            {
                pictureEditVehicle.Image = Image.FromFile(ovehicle.CapturePicture.FilePath);
            }
            if (File.Exists(ovehicle.VideoInfo.FilePath))
            {
                if (_lastVideoPort1 != -1)
                {
                    bool ret = HikPlayer.PlayM4_CloseFile(_lastVideoPort1);
                }
                if (File.Exists(ovehicle.VideoInfo.FilePath))
                {
                    _lastVideoPort1 = 1;
                    splitContainerControlFaceVideo.Visible = true;
                    HikPlayer.PlayM4_OpenFile(_lastVideoPort1, ovehicle.VideoInfo.FilePath);
                    HikPlayer.PlayM4_Play(_lastVideoPort1, splitContainerControlFaceVideo.Panel1.Handle);
                }

            }

        }

        private void advBandedGridView1_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            if (advBandedGridViewVehicle.SelectedRowsCount > 0)
            {
                int getSelectedRow = this.advBandedGridViewVehicle.GetSelectedRows()[0];
                _selectedVehicle = (Vehicle)(this.advBandedGridViewVehicle.GetRowCellValue(getSelectedRow, "车辆对象"));
                FillPicVideoVehicle(_selectedVehicle);
            }
        }

        private void advBandedGridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString().Trim();
            }
        }

        /*private void barButtonItem14_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
          {
              JustForTest justForTest = new JustForTest();
              justForTest.ShowDialog();
          }*/

        private void simpleButton11_Click(object sender, EventArgs e)
        {
            HikPlayer.PlayM4_Play(_lastVideoPort1, splitContainerControlVideoVehicle.Panel1.Handle);
        }

        private bool _isPausedForVehicle;
        private void simpleButton12_Click(object sender, EventArgs e)
        {
            _isPaused = !_isPausedForVehicle;
            HikPlayer.PlayM4_Pause(_lastVideoPort1, _isPausedForVehicle);
        }

        private void simpleButton13_Click(object sender, EventArgs e)
        {
            HikPlayer.PlayM4_CloseFile(_lastVideoPort1);
            _lastVideoPort1 = -1;
            _isPausedForVehicle = false;
        }

        //  private void splitContainerControl2_Panel2_SizeChanged(object sender, EventArgs e)
        //{
        //splitContainerControlFaceVideo.SplitterPosition = splitContainerControlFaceVideo.Height - 32;
        // }
        /*  private void LiveRegognizerFacePacketHandleDataChange(object sender, DataChangeEventArgs e)
          {

              var livePacketHandle = (LiveRecognizerFacePacketHandle)sender;
              if (livePacketHandle == null) return;
              //处理视频 
              //ShowLiveVideo(livePacketHandle);

          }*/

        //  private void cameraView1_Load(object sender, EventArgs e)
        // {

        // }
        private void btnVehiclePrePage_Click(object sender, EventArgs e)
        {
            _currentPageForVehicle--;
            if (_currentPageForVehicle < 1)
            {
                _currentPageForVehicle++;
                return;
            }
            ReloadQueryDataForVehicle();
        }



        private void btnVehicleNextPage_Click(object sender, EventArgs e)
        {
            _currentPageForVehicle++;
            if (_currentPageForVehicle > _totalPagesForVehicle)
            {
                _currentPageForVehicle--;
                return;
            }
            ReloadQueryDataForVehicle();
        }

        private void btnVehicleLastPage_Click(object sender, EventArgs e)
        {
            _currentPageForVehicle = _totalPagesForVehicle;
            ReloadQueryDataForVehicle();
        }

        private void btnVehicleFirstPage_Click(object sender, EventArgs e)
        {
            _currentPageForVehicle = 1;
            ReloadQueryDataForVehicle();
        }

        private void cbeVehicleNumberPerPage_SelectedValueChanged(object sender, EventArgs e)
        {

            _numberOfPerPageForVehicle = int.Parse(comboBoxEdit1.Text);
            if (radioGroupVehicle.SelectedIndex == 1)
            {
                _currentPageForVehicle = 1;
                CaculatPagesForVehicle();
                ReloadQueryDataForVehicle();
            }

        }
        private void CaculatPagesForVehicle()
        {
            if (_totalCountForVehicle % _numberOfPerPageForVehicle == 0)
            {
                _totalPagesForVehicle = _totalCountForVehicle / _numberOfPerPageForVehicle;
            }
            else
            {
                _totalPagesForVehicle = (int)((float)_totalCountForVehicle / _numberOfPerPageForVehicle) + 1;
            }
            lblVehicleCurrentPage.Text = string.Format("当前：{0}/{1}页", _currentPageForVehicle, _totalPagesForVehicle);
        }
        #endregion

        #region 事件显示部分
        private int _totalPagesForEvent;
        private int _totalCountForEvent;
        private int _currentPageForEvent = 1;
        private int _numberOfPerPageForEvent = 20;
        private bool stop = false;
        private bool crossline = false;
        private bool illegalDir = false;
        private bool changechannel = false;

        private void radioGroupEvent_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (radioGroupEvent.SelectedIndex)
            {
                //实时
                case 0:
                    teStartTimeEvent.Enabled = teEndTimeEvent.Enabled = btnQueryEvent.Enabled = false;
                    gridControlEvent.DataSource = null;
                    break;
                case 1:
                    teStartTimeEvent.Enabled = teEndTimeEvent.Enabled = btnQueryEvent.Enabled = true;
                    gridControlEvent.DataSource = dataTableFace;
                    splitContainerControlEventVideo.Visible = false;
                    if (_lastVideoPort != -1)
                    {
                        HikPlayer.PlayM4_CloseFile(_lastVideoPort);
                    }
                    break;
                default:
                    teStartTimeEvent.Enabled = teEndTimeEvent.Enabled = btnQueryEvent.Enabled = false;
                    break;

            }
            pictureEditEvent.Image = null;

            splitContainerControlEventVideo.Visible = (1 == radioGroupEvent.SelectedIndex);
        }

        private void btnQueryEvent_Click(object sender, EventArgs e)
        {
            ReloadQueryDataForEvent();
        }

        string GenerateEventQueryCondition()
        {
            string str = " and CapturePicture.CameraId in (";
            string[] selectCameras = checkedComboBoxEditEventCamera.Text.Split(',');
            foreach (string selectCamera in selectCameras)
            {
                string changeselectCamera = selectCamera.Trim();
                if (changeselectCamera == "当前摄像头")
                {
                    CameraWindow currentCameraWindow = mainMultiplexer.GetCurrentCameraWindow();
                    if (currentCameraWindow != null)
                    {
                        str += currentCameraWindow.CameraID + ",";
                    }
                    else
                    {
                        str += "null,";
                    }
                }
                else
                {
                    str += _listAllCamStr[changeselectCamera].CameraId + ",";
                }
            }
            str = str.Substring(0, str.Length - 1) + ") ";

            DateTime startTime = DateTime.Parse(teStartTimeEvent.EditValue.ToString());
            DateTime endTime = DateTime.Parse(teEndTimeEvent.EditValue.ToString());


            if (DateTime.Compare(startTime, endTime) == 0)
            {
                XtraMessageBox.Show("时间不能相等！");
                return "";
            }
            else if ((DateTime.Compare(startTime, endTime) > 0))
            {
                XtraMessageBox.Show("起始时间不能大于结束时间！");
                return "";
            }

            str += " and (CapturePicture.[DateTime] between convert(DateTime,'" + teStartTimeEvent.EditValue + "') and convert(DateTime,'" + teEndTimeEvent.EditValue + "'))";

            string[] userSelections = checkedComboBoxEditUserSelection.Text.Split(',');
            foreach(var selection in userSelections)
            {
                string changeselectCamera = selection.Trim();
                if (selection == "无")
                {
                    return "";
                }
                else
                {
                    if (selection == "停止")
                    {
                        stop = true;
                        str += " and (Event.listObject.Value.stop = {0}" + stop + ")";
                    }
                    else if (selection == "跨线")
                    {
                        crossline = true;
                        str += " and (Event.listObject.Value.CrossLine = {0}" + crossline + ")";

                    }
                    else if (selection == "逆行")
                    {
                        illegalDir = true;
                        str += " and (Event.listObject.Value.illegalDir = {0}" + illegalDir + ")";

                    }
                    else if (selection == "变道")
                    {
                        changechannel = true;
                        str += " and (Event.listObject.Value.changeChannel = {0}" + changechannel + ")";

                    }
                }

            }
            return str;
        }

        DataTable dataTableEvent = new DataTable();

        private void ReloadQueryDataForEvent()
        {
            string errMessage = "";
            string eventQueryCondition = GenerateEventQueryCondition();
            _totalCountForEvent = EventBusiness.Instance.GetEventQuantity(ref errMessage, eventQueryCondition);
            CaculatePagesForEvent();
            Dictionary<int, Event> listEvent = EventBusiness.Instance.GetEventCustom(ref errMessage, eventQueryCondition, _currentPageForEvent, _numberOfPerPageForEvent);

            //Dictionary<int, Face> listFace = new Dictionary<int, Face>();
            //listFace.Add(1, new Face() { CameraInfo = new CameraInfo() { CameraId = 1, Name = "test", DeviceName = "hello" }, FaceID = 101, CapturePicture = new CapturePicture() { CameraID = 1, Datetime = DateTime.Now, FilePath = @"c:\a.jpg" }, FacePath = @"c:\b.jpg", score = 0.333f, VideoInfo = new VideoInfo() { FilePath = @"D:\VideoOutput\68\2011\05\01\16\23.264" } });
            //listFace.Add(2, new Face() { CameraInfo = new CameraInfo() { CameraId = 2, Name = "abc", DeviceName = "world" }, FaceID = 102, CapturePicture = new CapturePicture() { CameraID = 1, Datetime = DateTime.Now.AddDays(-100), FilePath = @"c:\b.jpg" }, FacePath = @"c:\b.jpg", score = 0.555f, VideoInfo = new VideoInfo() { FilePath = @"D:\VideoOutput\68\2011\05\01\14\16.264" } });

            FillGridControlEventDetail(listEvent);
            string[] userSelections = checkedComboBoxEditUserSelection.Text.Split(',');
            if (listEvent == null)
            {
                return;
            }
            foreach (var variable in listEvent)
            {
                Dictionary<int, ObjectInfo> listObject = new Dictionary<int, ObjectInfo>();
                listObject = ObjectBusiness.Instance.GetEventObjectCustom(ref errMessage, variable.Value.EventId);
                foreach (var objcet in listObject)
                {
                    foreach (string selection in userSelections)
                    {
                        if (selection == "无")
                        {
                            return;
                        }
                        else
                        {
                            if (selection == "停止")
                            {
                                //显示objcet.Value.stop
                            }
                            else if (selection == "跨线")
                            {
                                //显示objcet.Value.CrossLine
                            }
                            else if (selection == "逆行")
                            {
                                //显示objcet.Value.illegalDir
                            }
                            else if (selection == "变道")
                            {
                                //显示objcet.Value.changeChannel
                            }
                        }
                    }
                }
      
            }
        }
        
        private void FillGridControlEventDetail(Dictionary<int, Event> listevent)
        {
            dataTableEvent.Rows.Clear();
            if (listevent == null) return;
            int i = 1;


            foreach (var variable in listevent)
            {
                dataTableEvent.Rows.Add(i++,
                                       variable.Value.CapturePicture.Datetime,
                                       variable.Value.CameraInfo.Name,
                                       variable.Value);
            }
            /*GridColumn column;
            RepositoryItemPictureEdit pictureEdit = gridControlFace.RepositoryItems.Add("PictureEdit") as RepositoryItemPictureEdit;
            pictureEdit.SizeMode = PictureSizeMode.Zoom;
            pictureEdit.NullText = " ";
            column = advBandedGridViewFace.Columns["照片"];
            column.ColumnEdit = pictureEdit;*/
            gridControlEvent.DataSource = dataTableFace;
            advBandedGridViewEvent.Columns["时间"].DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            advBandedGridViewEvent.Columns["事件对象"].Visible = false;

            HikPlayer.PlayM4_CloseFile(_lastVideoPort);
            splitContainerControlFaceVideo.Panel1.Refresh();
            splitContainerControlFaceVideo.Visible = false;

        }
        //DataTable dataTableEvent = new DataTable();
        private void InitEventDataTable()
        {
            dataTableEvent.Columns.Add("索引号", typeof(int));

            dataTableEvent.Columns.Add("时间", typeof(DateTime));
            dataTableEvent.Columns.Add("地点", typeof(string));
            dataTableEvent.Columns.Add("事件对象", typeof(Event));
        }
        private Event _selectedEvent;
        private void advBandedGridViewEvent_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (advBandedGridViewEvent.SelectedRowsCount > 0)
            {
                int getSelectedRow = this.advBandedGridViewEvent.GetSelectedRows()[0];
                _selectedEvent = (Event)(this.advBandedGridViewEvent.GetRowCellValue(getSelectedRow, "事件对象"));
                FillPicVideoEvent(_selectedEvent);
            }
        }

        private int _lastVideoPortEvent = -1;
        private void FillPicVideoEvent(Event oevent)
        {
            if (File.Exists(oevent.CapturePicture.FilePath))
            {
                pictureEditVehicle.Image = Image.FromFile(oevent.CapturePicture.FilePath);
            }
            if (File.Exists(oevent.VideoInfo.FilePath))
            {
                if (_lastVideoPortEvent != -1)
                {
                    bool ret = HikPlayer.PlayM4_CloseFile(_lastVideoPortEvent);
                }
                if (File.Exists(oevent.VideoInfo.FilePath))
                {
                    _lastVideoPortEvent = 1;
                    splitContainerControlEventVideo.Visible = true;
                    HikPlayer.PlayM4_OpenFile(_lastVideoPortEvent, oevent.VideoInfo.FilePath);
                    HikPlayer.PlayM4_Play(_lastVideoPortEvent, splitContainerControlEventVideo.Panel1.Handle);
                }

            }

        }

        private void advBandedGridViewEvent_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            if (advBandedGridViewEvent.SelectedRowsCount > 0)
            {
                int getSelectedRow = this.advBandedGridViewEvent.GetSelectedRows()[0];
                _selectedEvent = (Event)(this.advBandedGridViewEvent.GetRowCellValue(getSelectedRow, "事件对象"));
                FillPicVideoEvent(_selectedEvent);
            }
        }

        private void advBandedGridViewEvent_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString().Trim();
            }
        }

        /*private void barButtonItem14_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
          {
              JustForTest justForTest = new JustForTest();
              justForTest.ShowDialog();
          }

        private void simpleButton13_Click(object sender, EventArgs e)
        {
            HikPlayer.PlayM4_Play(_lastVideoPort1, splitContainerControlVideoVehicle.Panel1.Handle);
        }*/

        private bool _isPausedForEvent;
        private void simpleButton14_Click(object sender, EventArgs e)
        {
            _isPaused = !_isPausedForVehicle;
            HikPlayer.PlayM4_Pause(_lastVideoPortEvent, _isPausedForEvent);
        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
            HikPlayer.PlayM4_CloseFile(_lastVideoPortEvent);
            _lastVideoPortEvent = -1;
            _isPausedForEvent = false;
        }


        private void btnEventPrePage_Click(object sender, EventArgs e)
        {
            _currentPageForEvent--;
            if (_currentPageForEvent < 1)
            {
                _currentPageForEvent++;
                return;
            }
            ReloadQueryDataForEvent();
        }



        private void btnEventNextPage_Click(object sender, EventArgs e)
        {
            _currentPageForEvent++;
            if (_currentPageForEvent > _totalPagesForEvent)
            {
                _currentPageForEvent--;
                return;
            }
            ReloadQueryDataForEvent();
        }

        private void btnEventLastPage_Click(object sender, EventArgs e)
        {
            _currentPageForEvent = _totalPagesForEvent;
            ReloadQueryDataForEvent();
        }

        private void btnEventFirstPage_Click(object sender, EventArgs e)
        {
            _currentPageForEvent = 1;
            ReloadQueryDataForEvent();
        }

        private void cbeEventPerPage_SelectedValueChanged(object sender, EventArgs e)
        {

            _numberOfPerPageForEvent = int.Parse(cbeEventNumberPerPage.Text);
            if (radioGroupEvent.SelectedIndex == 1)
            {
                _currentPageForEvent = 1;
                CaculatePagesForEvent();
                ReloadQueryDataForEvent();
            }

        }
        private void CaculatePagesForEvent()
        {
            if (_totalCountForEvent % _numberOfPerPageForEvent == 0)
            {
                _totalPagesForEvent = _totalCountForEvent / _numberOfPerPageForEvent;
            }
            else
            {
                _totalPagesForEvent = (int)((float)_totalCountForEvent / _numberOfPerPageForEvent) + 1;
            }
            lblEventCurrentPage.Text = string.Format("当前：{0}/{1}页", _currentPageForEvent, _totalPagesForEvent);
        }
        #endregion

        private void barButtonItem15_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmCaptureLicense fcl = new frmCaptureLicense();
            fcl.ShowDialog();

        }

        private void barButtonItem16_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmCaptureLicensexxNotUsed frm = new frmCaptureLicensexxNotUsed();
            frm.ShowDialog();
        }

        private AirnoixCamera airnoixCamera;
        private void barButtonItem17_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //0x000A0000 
            CameraWindow cameraWindow = mainMultiplexer.GetCurrentCameraWindow();
            //IntPtr intPtr = AirnoixClient.MP4_ClientInit(cameraWindow.Handle, 0x000A0000, 0x00000200, 0);
            //tagRECT tc = new tagRECT() { top = 0, left = 0, right = cameraWindow.Width, bottom = cameraWindow.Height };
            //AirnoixClient.MP4_ClientSetDisPlayPos(intPtr, ref tc);
            //int  ret = AirnoixClient.MP4_ClientSetWaitTime(intPtr, 30000);
            //ret = AirnoixClient.MP4_ClientSetConnectUser(intPtr, "system", "system");
            //ret = AirnoixClient.MP4_ClientConnectEx(intPtr, "192.168.1.6", 6002, 0, 0, 0);

            airnoixCamera = new AirnoixCamera(cameraWindow.Handle);   
            airnoixCamera.DisplayPos = new Rectangle(0,0,cameraWindow.Width,cameraWindow.Height);
            airnoixCamera.Ip = "192.168.1.6";
            airnoixCamera.Port = 6002;
            airnoixCamera.UserName = "system";
            airnoixCamera.Password = "system";
            airnoixCamera.SaveTo = "c:\\";
            cameraWindow.AirnoixCamera = airnoixCamera;
            airnoixCamera.Start();


        }

        private void barButtonItem18_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            airnoixCamera.StartRecord();
        }

        private void barButtonItem19_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            airnoixCamera.StopRecord();
        }

        private void barButtonItem20_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            RelatedFile relatedFile = new RelatedFile("192.168.1.6",1,DateTime.Now,15);
        }

        private IntPtr retIntPtr;
        private void barButtonItem21_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Debug.WriteLine("Before Init\t"+DateTime.Now.ToString());
            IntPtr myIntPtr = mainMultiplexer.GetCameraWindow(0,2).Handle;
            retIntPtr = AirnoixPlayer.Avdec_Init(myIntPtr, 0, 512, 0);
            int ret = AirnoixPlayer.Avdec_SetFile(retIntPtr, @"Y:\data(Server@ASIPCAM(192.168.1.6))\2011-06-30\ch01ch\19-48-05_N(16).mkv", null, false);
            Thread.Sleep(40);
            int frames = AirnoixPlayer.Avdec_GetTotalFrames(retIntPtr);
            ret = AirnoixPlayer.Avdec_SetCurrentPosition(retIntPtr,600);
            ret = AirnoixPlayer.Avdec_Play(retIntPtr);
            Debug.WriteLine("Before Init\t" + DateTime.Now.ToString() + "\tFrames=" + frames);
            //ret = AirnoixPlayer.Avdec_Done(retIntPtr);

        }

        private void barButtonItemPlayTwoFiles_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmPlayTwoFiles test = new frmPlayTwoFiles();
            test.ShowDialog(this);
        }



        #region 球机控制
        private IntPtr ptzHandle = AironixControl.TMCC_Init(0);
        private uint ptzSpeed = 1;
        private void mainMultiplexer_SelectCameraWindow(object sender, EventArgs e, CameraWindow CurrentCameraWindow)
        {
            if (CurrentCameraWindow.AirnoixCamera == null)
            {
                if (dockPanelPtzControl.Visible)
                {
                    AironixControl.TMCC_Done(ptzHandle);
                    dockPanelPtzControl.Visible = false;
                }
                return;
            }
            if (CurrentCameraWindow.AirnoixCamera.Type == 1)
            {
                if (AironixControl.TMCC_IsConnect(ptzHandle))
                {
                    int iret = AironixControl.TMCC_PtzClose(ptzHandle);
                    iret = AironixControl.TMCC_DisConnect(ptzHandle);
                    iret = AironixControl.TMCC_Done(ptzHandle);
                }
                
                dockPanelPtzControl.Visible = false;
            }
            else if (CurrentCameraWindow.AirnoixCamera.Type == 2)
            {
                ptzHandle = AironixControl.TMCC_Init(0);
                tmConnectInfo_t connectInfo = new tmConnectInfo_t();
                connectInfo.pIp = CurrentCameraWindow.AirnoixCamera.Ip;
                connectInfo.iPort = CurrentCameraWindow.AirnoixCamera.Port;
                connectInfo.dwSize = 236;
                connectInfo.iUserLevel = 5;
                connectInfo.szUser = CurrentCameraWindow.AirnoixCamera.UserName;
                connectInfo.szPass = CurrentCameraWindow.AirnoixCamera.Password;
                connectInfo.pUserContext = "";
                int iret = AironixControl.TMCC_Connect(ptzHandle, ref connectInfo, true);
                if (iret!=0) return;
                iret = AironixControl.TMCC_PtzOpen(ptzHandle, 0, false);
                if (iret != 0) return;
                dockPanelPtzControl.Tag = CurrentCameraWindow.AirnoixCamera;
                dockPanelPtzControl.Visible = true;

            }


        }

        private PtzControlType ptzControType;

        private void PtzControl(bool start)
        {
            uint.TryParse(textEditPtzSpeed.Text, out ptzSpeed);
            AironixControl.TMCC_PtzControl(ptzHandle, (uint)ptzControType, start? (uint)1:(uint)0, ptzSpeed);
        }

        private void sbZoomAdd_Click(object sender, EventArgs e)
        {
            ptzControType = PtzControlType.PTZ_ZOOM_OUT;
            PtzControl(true);
        }

        private void right_MouseDown(object sender, MouseEventArgs e)
        {
            ptzControType = PtzControlType.PTZ_RIGHT;
            PtzControl(true);
        }

        private void right_MouseUp(object sender, MouseEventArgs e)
        {
            ptzControType = PtzControlType.PTZ_RIGHT;
            PtzControl(false);
        }



        private void up_MouseDown(object sender, MouseEventArgs e)
        {
            ptzControType = PtzControlType.PTZ_UP;
            PtzControl(true);
        }

        private void up_MouseUp(object sender, MouseEventArgs e)
        {
            ptzControType = PtzControlType.PTZ_UP;
            PtzControl(false);
        }

        private void left_MouseUp(object sender, MouseEventArgs e)
        {
            ptzControType = PtzControlType.PTZ_LEFT;
            PtzControl(false);
        }

        private void left_MouseDown(object sender, MouseEventArgs e)
        {
            ptzControType = PtzControlType.PTZ_LEFT;
            PtzControl(true);
        }

        private void Down_MouseDown(object sender, MouseEventArgs e)
        {
            ptzControType = PtzControlType.PTZ_DOWN;
            PtzControl(true);
        }

        private void Down_MouseUp(object sender, MouseEventArgs e)
        {
            ptzControType = PtzControlType.PTZ_DOWN;
            PtzControl(false);
        }

        private void sbZoomAdd_MouseDown(object sender, MouseEventArgs e)
        {
            ptzControType = PtzControlType.PTZ_ZOOM_IN;
            PtzControl(true);
        }

        private void sbZoomAdd_MouseUp(object sender, MouseEventArgs e)
        {
            ptzControType = PtzControlType.PTZ_ZOOM_IN;
            PtzControl(false);
        }

        private void sbZoomSub_MouseDown(object sender, MouseEventArgs e)
        {
            ptzControType = PtzControlType.PTZ_ZOOM_OUT;
            PtzControl(true);
        }

        private void sbZoomSub_MouseUp(object sender, MouseEventArgs e)
        {
            ptzControType = PtzControlType.PTZ_ZOOM_OUT;
            PtzControl(false);
        }

        private void sbIRISAdd_MouseUp(object sender, MouseEventArgs e)
        {
            ptzControType = PtzControlType.PTZ_IRIS_ENLARGE;
            PtzControl(false);
        }

        private void sbIRISAdd_MouseDown(object sender, MouseEventArgs e)
        {
            ptzControType = PtzControlType.PTZ_IRIS_ENLARGE;
            PtzControl(true);
        }

        private void sbIRISSub_MouseDown(object sender, MouseEventArgs e)
        {
            ptzControType = PtzControlType.PTZ_IRIS_SHRINK;
            PtzControl(true);
        }

        private void sbIRISSub_MouseUp(object sender, MouseEventArgs e)
        {
            ptzControType = PtzControlType.PTZ_IRIS_SHRINK;
            PtzControl(false);
        }

        private void sbFOCUSAdd_MouseUp(object sender, MouseEventArgs e)
        {
            ptzControType = PtzControlType.PTZ_FOCUS_FAR;
            PtzControl(false);
        }

        private void sbFOCUSAdd_MouseDown(object sender, MouseEventArgs e)
        {
            ptzControType = PtzControlType.PTZ_FOCUS_FAR;
            PtzControl(true);
        }

        private void sbFOCUSSub_MouseDown(object sender, MouseEventArgs e)
        {
            ptzControType = PtzControlType.PTZ_FOCUS_NEAR;
            PtzControl(true);
        }

        private void sbFOCUSSub_MouseUp(object sender, MouseEventArgs e)
        {
            ptzControType = PtzControlType.PTZ_FOCUS_NEAR;
            PtzControl(true);
        }

        private void sbCallGlobalCameraPosition_Click(object sender, EventArgs e)
        {
            ptzControType = PtzControlType.PTZ_SET_PRESET;
            int positionIndex = 99;
            bool isConcertSuccessful = int.TryParse(cbePreset.Text, out positionIndex);
            if (!isConcertSuccessful)
            {
                positionIndex = 99;
            }
            for (uint i = 0; i < 16; i++)
            {
                int ret = AironixControl.TMCC_PtzPreset(ptzHandle, (uint)ptzControType, i+1, ptzSpeed);                
            }

        }
        private void sbSaveGlobalCameraPosition_Click(object sender, EventArgs e)
        {
            ptzControType = PtzControlType.PTZ_GOTO_PRESET;
            int positionIndex = 99;
            bool isConcertSuccessful = int.TryParse(cbePreset.Text, out positionIndex);
            if (!isConcertSuccessful)
            {
                positionIndex = 99;
            }
            int ret = AironixControl.TMCC_PtzPreset(ptzHandle, (uint)ptzControType, (uint)positionIndex, ptzSpeed);
        }

        private void sbDeleteGlobalCameraPosition_Click(object sender, EventArgs e)
        {
            ptzControType = PtzControlType.PTZ_CLE_PRESET;
            int positionIndex = 99;
            bool isConcertSuccessful = int.TryParse(cbePreset.Text, out positionIndex);
            if (!isConcertSuccessful)
            {
                positionIndex = 99;
            }
            int ret = AironixControl.TMCC_PtzPreset(ptzHandle, (uint)ptzControType, (uint)positionIndex, ptzSpeed);
        }
        #endregion

        [DllImport("user32.dll", EntryPoint = "RegisterHotKey")]       
        public static extern bool RegisterHotKey       
             (       
                IntPtr hWnd,        //要注册热键的窗口句柄       
                int id,             //热键编号       
                int fsModifiers,    //特殊键如：Ctrl，Alt，Shift，Window       
                int vk              //一般键如：A B C F1，F2 等       
             );       
      
        [DllImportAttribute("user32.dll", EntryPoint = "UnregisterHotKey")]       
        public static extern bool UnregisterHotKey       
             (       
                 IntPtr hWnd,        //注册热键的窗口句柄       
                int id              //热键编号上面注册热键的编号       
             );
        const int WM_HOTKEY = 0x312;   
        private enum MyKeys
        {
            None = 0,
            Alt = 1,
            Ctrl = 2,
            Shift = 4,
            Win = 8
        }
        protected override void WndProc(ref Message m)
        {
            Keys key= Keys.D1;
            if (m.Msg == WM_HOTKEY)
            {
                switch (m.WParam.ToInt32())
                {
                    case 201:
                        careCameraWindows = mainMultiplexer.GetCameraWindow(0, 0);
                        key = Keys.D1;
                        break;
                    case 202:
                        careCameraWindows = mainMultiplexer.GetCameraWindow(0, 1);
                        key = Keys.D2;
                        break;
                    case 203:
                        careCameraWindows = mainMultiplexer.GetCameraWindow(0, 2);
                        key = Keys.D3;
                        break;
                    case 204:
                        careCameraWindows = mainMultiplexer.GetCameraWindow(1, 0);
                        key = Keys.D4;
                        break;
                    case 205:
                        careCameraWindows = mainMultiplexer.GetCameraWindow(1, 1);
                        key = Keys.D5;
                        break;
                    case 206:
                        careCameraWindows = mainMultiplexer.GetCameraWindow(1, 2);
                        key = Keys.D6;
                        break;
                    case 207:
                        careCameraWindows = mainMultiplexer.GetCameraWindow(2, 0);
                        key = Keys.D7;
                        break;
                    case 208:
                        careCameraWindows = mainMultiplexer.GetCameraWindow(2, 1);
                        key = Keys.D8;
                        break;
                    case 209:
                        careCameraWindows = mainMultiplexer.GetCameraWindow(2, 2);
                        key = Keys.D9;
                        break;
                }
                if (careCameraWindows.AirnoixCamera==null)
                {
                    return;
                }
                _listNumKeyStatus[key] = !_listNumKeyStatus[key];
                if (_listNumKeyStatus[key])
                {
                    //开始录像
                    careCameraWindows.AirnoixCamera.StartRecord();
                    mainMultiplexer_SelectCameraWindow(null, null, careCameraWindows);

                }
                else
                {
                    careCameraWindows.AirnoixCamera.StopRecord();
                    frmCaptureLicense fcl = new frmCaptureLicense(careCameraWindows.AirnoixCamera);
                    fcl.Show();
                    //结束录像
                }
                ChangeButtonState(key);

            }
        
            base.WndProc(ref m);
        }

        private void timerForDeleteTempFiles_Tick(object sender, EventArgs e)
        {
            DirectoryInfo Dir = new DirectoryInfo(Properties.Settings.Default.CapturePictureTempPath);
            
            //删除临时的图片文件
            foreach (FileInfo fileInfo in Dir.GetFiles("*.bmp"))//查找文件
            {
                if(fileInfo.LastAccessTime.AddSeconds(345600)<DateTime.Now)
                {
                    try
                    {
                        File.Delete(fileInfo.FullName);
                    }
                    catch (Exception ex)
                    {
                       logger.Error(ex.ToString());
                    }
                }
            }
            //删除临时的视频文件
            Dir = new DirectoryInfo(Properties.Settings.Default.RecordTempVideoPath);
            foreach (FileInfo fileInfo in Dir.GetFiles("*.avi").Union(Dir.GetFiles("*.mkv")) )//查找文件
            {
                if(fileInfo.LastAccessTime.AddSeconds(1000)<DateTime.Now)
                {
                    try
                    {
                        File.Delete(fileInfo.FullName);
                    }
                    catch (Exception ex)
                    {
                       logger.Error(ex.ToString());
                    }
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {


        }

        private void bbiHistroyVideoCondition_ItemClick(object sender, ItemClickEventArgs e)
        {
            UseWaitCursor = true;
            frmHistoryCaptureCondition frmhcc= new frmHistoryCaptureCondition();
            UseWaitCursor = false;
            frmhcc.ShowDialog();
            UseWaitCursor = true;
            frmCaptureHistroyLicense fchl = new frmCaptureHistroyLicense(frmhcc);
            UseWaitCursor = false;
            fchl.Show();

        }

        private void timerForReconnect_Tick(object sender, EventArgs e)
        {
            for (int row = 0; row < 2; row++)
            {
                for (int col = 0; col < 2; col++)
                {
                    CameraWindow cameraWindow = mainMultiplexer.GetCameraWindow(row, col);
                    if (cameraWindow.AirnoixCamera ==null)
                    {
                        continue;
                    }
                    if (cameraWindow.AirnoixCamera.IsAlive==false)
                    {
                        cameraWindow.AirnoixCamera.Start();
                    }
                }
            }
        }
    }
}