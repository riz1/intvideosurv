using System.Windows.Forms;

namespace CameraViewer
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.barMenu = new DevExpress.XtraBars.Bar();
            this.barSubItemMenuSystem = new DevExpress.XtraBars.BarSubItem();
            this.barButtonItem5 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem7 = new DevExpress.XtraBars.BarButtonItem();
            this.barSubItemMenuView = new DevExpress.XtraBars.BarSubItem();
            this.barButtonItemResultView = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemAlarmView = new DevExpress.XtraBars.BarButtonItem();
            this.barSubItemMenuQuery = new DevExpress.XtraBars.BarSubItem();
            this.barSubItem1 = new DevExpress.XtraBars.BarSubItem();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem8 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem9 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem10 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem11 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem12 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem13 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemGetPics = new DevExpress.XtraBars.BarButtonItem();
            this.bar4 = new DevExpress.XtraBars.Bar();
            this.barStaticItem1 = new DevExpress.XtraBars.BarStaticItem();
            this.barStaticItemCurrentUser = new DevExpress.XtraBars.BarStaticItem();
            this.barStaticItem3 = new DevExpress.XtraBars.BarStaticItem();
            this.barStaticItemCameraNo = new DevExpress.XtraBars.BarStaticItem();
            this.barStaticItem2 = new DevExpress.XtraBars.BarStaticItem();
            this.barStaticItemDecoderNo = new DevExpress.XtraBars.BarStaticItem();
            this.barStaticItem4 = new DevExpress.XtraBars.BarStaticItem();
            this.barStaticItemCurrentTime = new DevExpress.XtraBars.BarStaticItem();
            this.barStaticItem5 = new DevExpress.XtraBars.BarStaticItem();
            this.barStaticItemNetStatus = new DevExpress.XtraBars.BarStaticItem();
            this.barAndDockingController1 = new DevExpress.XtraBars.BarAndDockingController(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.dockManager1 = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.dockPanelResult = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel2_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.dockPanel1 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.cameraView1 = new CameraViewer.Controls.CameraView();
            this.simpleButton5 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton4 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton3 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.dockPanelAlarm = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel3_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.pcBottom = new DevExpress.XtraEditors.PanelControl();
            this.xtraTabControlResult = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPageEvent = new DevExpress.XtraTab.XtraTabPage();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.xtraTabPageVehicle = new DevExpress.XtraTab.XtraTabPage();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl4 = new DevExpress.XtraEditors.PanelControl();
            this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.simpleButton6 = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.timeEdit1 = new DevExpress.XtraEditors.TimeEdit();
            this.timeEdit2 = new DevExpress.XtraEditors.TimeEdit();
            this.checkedComboBoxEdit2 = new DevExpress.XtraEditors.CheckedComboBoxEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.radioGroup2 = new DevExpress.XtraEditors.RadioGroup();
            this.xtraTabPageFace = new DevExpress.XtraTab.XtraTabPage();
            this.panelControl5 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl8 = new DevExpress.XtraEditors.PanelControl();
            this.gridControlFace = new DevExpress.XtraGrid.GridControl();
            this.gridViewFace = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.panelControl9 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl7 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl6 = new DevExpress.XtraEditors.PanelControl();
            this.btnQueryFace = new DevExpress.XtraEditors.SimpleButton();
            this.lblStartTime = new DevExpress.XtraEditors.LabelControl();
            this.lblEndTime = new DevExpress.XtraEditors.LabelControl();
            this.teStartTimeFace = new DevExpress.XtraEditors.TimeEdit();
            this.teEndTimeFace = new DevExpress.XtraEditors.TimeEdit();
            this.checkedComboBoxEditFaceCamera = new DevExpress.XtraEditors.CheckedComboBoxEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.radioGroupFace = new DevExpress.XtraEditors.RadioGroup();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem4 = new DevExpress.XtraBars.BarButtonItem();
            this.barbtnClose = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem6 = new DevExpress.XtraBars.BarButtonItem();
            this.barSubItem3 = new DevExpress.XtraBars.BarSubItem();
            this.barStaticItem6 = new DevExpress.XtraBars.BarStaticItem();
            this.mainMultiplexer = new CameraViewer.Multiplexer();
            this.cmIcon = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.删除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timerCheckAlarmSites = new System.Windows.Forms.Timer(this.components);
            this.timerUpdateIcon = new System.Windows.Forms.Timer(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.timerCurretnTime = new System.Windows.Forms.Timer(this.components);
            this.timerTest = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barAndDockingController1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).BeginInit();
            this.dockPanelResult.SuspendLayout();
            this.dockPanel1.SuspendLayout();
            this.dockPanel1_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            this.dockPanelAlarm.SuspendLayout();
            this.dockPanel3_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcBottom)).BeginInit();
            this.pcBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControlResult)).BeginInit();
            this.xtraTabControlResult.SuspendLayout();
            this.xtraTabPageEvent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.xtraTabPageVehicle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).BeginInit();
            this.panelControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkedComboBoxEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup2.Properties)).BeginInit();
            this.xtraTabPageFace.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl5)).BeginInit();
            this.panelControl5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl8)).BeginInit();
            this.panelControl8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlFace)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewFace)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl6)).BeginInit();
            this.panelControl6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.teStartTimeFace.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teEndTimeFace.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkedComboBoxEditFaceCamera.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroupFace.Properties)).BeginInit();
            this.cmIcon.SuspendLayout();
            this.SuspendLayout();
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.barMenu,
            this.bar3,
            this.bar4});
            this.barManager1.Controller = this.barAndDockingController1;
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.DockManager = this.dockManager1;
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barButtonItem1,
            this.barButtonItem2,
            this.barButtonItem4,
            this.barbtnClose,
            this.barButtonItem6,
            this.barSubItemMenuSystem,
            this.barSubItemMenuView,
            this.barSubItem3,
            this.barSubItemMenuQuery,
            this.barSubItem1,
            this.barButtonItem3,
            this.barButtonItem5,
            this.barButtonItem7,
            this.barButtonItemResultView,
            this.barButtonItemAlarmView,
            this.barStaticItem1,
            this.barStaticItemCurrentUser,
            this.barStaticItem3,
            this.barStaticItemCameraNo,
            this.barStaticItem2,
            this.barStaticItemDecoderNo,
            this.barStaticItem4,
            this.barStaticItemCurrentTime,
            this.barStaticItem5,
            this.barStaticItem6,
            this.barStaticItemNetStatus,
            this.barButtonItem8,
            this.barButtonItem9,
            this.barButtonItem10,
            this.barButtonItem11,
            this.barButtonItem12,
            this.barButtonItem13,
            this.barButtonItemGetPics});
            this.barManager1.MainMenu = this.barMenu;
            this.barManager1.MaxItemId = 37;
            this.barManager1.StatusBar = this.bar4;
            // 
            // barMenu
            // 
            this.barMenu.BarName = "Custom 2";
            this.barMenu.DockCol = 0;
            this.barMenu.DockRow = 0;
            this.barMenu.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.barMenu.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barSubItemMenuSystem),
            new DevExpress.XtraBars.LinkPersistInfo(this.barSubItemMenuView),
            new DevExpress.XtraBars.LinkPersistInfo(this.barSubItemMenuQuery),
            new DevExpress.XtraBars.LinkPersistInfo(this.barSubItem1)});
            this.barMenu.OptionsBar.DrawDragBorder = false;
            this.barMenu.OptionsBar.MultiLine = true;
            this.barMenu.OptionsBar.UseWholeRow = true;
            this.barMenu.Text = "Custom 2";
            // 
            // barSubItemMenuSystem
            // 
            this.barSubItemMenuSystem.Caption = "系统(&S)";
            this.barSubItemMenuSystem.Id = 9;
            this.barSubItemMenuSystem.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem5),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem7)});
            this.barSubItemMenuSystem.Name = "barSubItemMenuSystem";
            // 
            // barButtonItem5
            // 
            this.barButtonItem5.Caption = "系统设置";
            this.barButtonItem5.Id = 15;
            this.barButtonItem5.Name = "barButtonItem5";
            this.barButtonItem5.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem5_ItemClick);
            // 
            // barButtonItem7
            // 
            this.barButtonItem7.Caption = "退出";
            this.barButtonItem7.Id = 16;
            this.barButtonItem7.Name = "barButtonItem7";
            this.barButtonItem7.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem7_ItemClick);
            // 
            // barSubItemMenuView
            // 
            this.barSubItemMenuView.Caption = "视图(&V)";
            this.barSubItemMenuView.Id = 10;
            this.barSubItemMenuView.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItemResultView),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItemAlarmView)});
            this.barSubItemMenuView.Name = "barSubItemMenuView";
            // 
            // barButtonItemResultView
            // 
            this.barButtonItemResultView.Caption = "结果视图";
            this.barButtonItemResultView.Id = 17;
            this.barButtonItemResultView.Name = "barButtonItemResultView";
            this.barButtonItemResultView.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemAlarmView_ItemClick);
            // 
            // barButtonItemAlarmView
            // 
            this.barButtonItemAlarmView.Caption = "报警视图";
            this.barButtonItemAlarmView.Id = 18;
            this.barButtonItemAlarmView.Name = "barButtonItemAlarmView";
            this.barButtonItemAlarmView.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemResultView_ItemClick);
            // 
            // barSubItemMenuQuery
            // 
            this.barSubItemMenuQuery.Caption = "查询(&Q)";
            this.barSubItemMenuQuery.Id = 12;
            this.barSubItemMenuQuery.Name = "barSubItemMenuQuery";
            // 
            // barSubItem1
            // 
            this.barSubItem1.Caption = "帮助(&H)";
            this.barSubItem1.Id = 13;
            this.barSubItem1.Name = "barSubItem1";
            // 
            // bar3
            // 
            this.bar3.BarName = "Custom 3";
            this.bar3.DockCol = 0;
            this.bar3.DockRow = 1;
            this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar3.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem3),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem8),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem9),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem10),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem11),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem12),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem13),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItemGetPics)});
            this.bar3.Offset = 4;
            this.bar3.Text = "Custom 3";
            // 
            // barButtonItem3
            // 
            this.barButtonItem3.Caption = "系统设置";
            this.barButtonItem3.Id = 14;
            this.barButtonItem3.Name = "barButtonItem3";
            this.barButtonItem3.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem3_ItemClick_1);
            // 
            // barButtonItem8
            // 
            this.barButtonItem8.Caption = "发送命令1";
            this.barButtonItem8.Id = 30;
            this.barButtonItem8.Name = "barButtonItem8";
            this.barButtonItem8.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem8_ItemClick_1);
            // 
            // barButtonItem9
            // 
            this.barButtonItem9.Caption = "发送命令2";
            this.barButtonItem9.Id = 31;
            this.barButtonItem9.Name = "barButtonItem9";
            this.barButtonItem9.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem9_ItemClick);
            // 
            // barButtonItem10
            // 
            this.barButtonItem10.Caption = "发送命令3";
            this.barButtonItem10.Id = 32;
            this.barButtonItem10.Name = "barButtonItem10";
            this.barButtonItem10.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem10_ItemClick);
            // 
            // barButtonItem11
            // 
            this.barButtonItem11.Caption = "发送命令4";
            this.barButtonItem11.Id = 33;
            this.barButtonItem11.Name = "barButtonItem11";
            this.barButtonItem11.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem11_ItemClick);
            // 
            // barButtonItem12
            // 
            this.barButtonItem12.Caption = "测试加图像";
            this.barButtonItem12.Id = 34;
            this.barButtonItem12.Name = "barButtonItem12";
            this.barButtonItem12.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem12_ItemClick);
            // 
            // barButtonItem13
            // 
            this.barButtonItem13.Caption = "测试";
            this.barButtonItem13.Id = 35;
            this.barButtonItem13.Name = "barButtonItem13";
            this.barButtonItem13.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem13_ItemClick);
            // 
            // barButtonItemGetPics
            // 
            this.barButtonItemGetPics.Caption = "获取图片";
            this.barButtonItemGetPics.Id = 36;
            this.barButtonItemGetPics.Name = "barButtonItemGetPics";
            this.barButtonItemGetPics.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemGetPics_ItemClick);
            // 
            // bar4
            // 
            this.bar4.BarName = "Custom 4";
            this.bar4.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar4.DockCol = 0;
            this.bar4.DockRow = 0;
            this.bar4.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar4.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barStaticItem1),
            new DevExpress.XtraBars.LinkPersistInfo(this.barStaticItemCurrentUser),
            new DevExpress.XtraBars.LinkPersistInfo(this.barStaticItem3),
            new DevExpress.XtraBars.LinkPersistInfo(this.barStaticItemCameraNo),
            new DevExpress.XtraBars.LinkPersistInfo(this.barStaticItem2),
            new DevExpress.XtraBars.LinkPersistInfo(this.barStaticItemDecoderNo),
            new DevExpress.XtraBars.LinkPersistInfo(this.barStaticItem4),
            new DevExpress.XtraBars.LinkPersistInfo(this.barStaticItemCurrentTime),
            new DevExpress.XtraBars.LinkPersistInfo(this.barStaticItem5),
            new DevExpress.XtraBars.LinkPersistInfo(this.barStaticItemNetStatus)});
            this.bar4.OptionsBar.AllowQuickCustomization = false;
            this.bar4.OptionsBar.DrawDragBorder = false;
            this.bar4.OptionsBar.UseWholeRow = true;
            this.bar4.Text = "Custom 4";
            // 
            // barStaticItem1
            // 
            this.barStaticItem1.Caption = "当前用户:";
            this.barStaticItem1.Id = 19;
            this.barStaticItem1.Name = "barStaticItem1";
            this.barStaticItem1.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // barStaticItemCurrentUser
            // 
            this.barStaticItemCurrentUser.Caption = "admin";
            this.barStaticItemCurrentUser.Id = 20;
            this.barStaticItemCurrentUser.Name = "barStaticItemCurrentUser";
            this.barStaticItemCurrentUser.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // barStaticItem3
            // 
            this.barStaticItem3.Caption = "摄像头数:";
            this.barStaticItem3.Id = 21;
            this.barStaticItem3.Name = "barStaticItem3";
            this.barStaticItem3.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // barStaticItemCameraNo
            // 
            this.barStaticItemCameraNo.Caption = "20";
            this.barStaticItemCameraNo.Id = 22;
            this.barStaticItemCameraNo.Name = "barStaticItemCameraNo";
            this.barStaticItemCameraNo.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // barStaticItem2
            // 
            this.barStaticItem2.Caption = "解码器数:";
            this.barStaticItem2.Id = 23;
            this.barStaticItem2.Name = "barStaticItem2";
            this.barStaticItem2.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // barStaticItemDecoderNo
            // 
            this.barStaticItemDecoderNo.Caption = "8";
            this.barStaticItemDecoderNo.Id = 24;
            this.barStaticItemDecoderNo.Name = "barStaticItemDecoderNo";
            this.barStaticItemDecoderNo.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // barStaticItem4
            // 
            this.barStaticItem4.Caption = "当前时间:";
            this.barStaticItem4.Id = 25;
            this.barStaticItem4.Name = "barStaticItem4";
            this.barStaticItem4.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // barStaticItemCurrentTime
            // 
            this.barStaticItemCurrentTime.Caption = "2011-02-20 22:22:22";
            this.barStaticItemCurrentTime.Id = 26;
            this.barStaticItemCurrentTime.Name = "barStaticItemCurrentTime";
            this.barStaticItemCurrentTime.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // barStaticItem5
            // 
            this.barStaticItem5.Caption = "网络状态:";
            this.barStaticItem5.Id = 27;
            this.barStaticItem5.Name = "barStaticItem5";
            this.barStaticItem5.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // barStaticItemNetStatus
            // 
            this.barStaticItemNetStatus.Caption = "正常";
            this.barStaticItemNetStatus.Id = 29;
            this.barStaticItemNetStatus.Name = "barStaticItemNetStatus";
            this.barStaticItemNetStatus.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // barAndDockingController1
            // 
            this.barAndDockingController1.PropertiesBar.AllowLinkLighting = false;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(1251, 55);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 724);
            this.barDockControlBottom.Size = new System.Drawing.Size(1251, 28);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 55);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 669);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1251, 55);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 669);
            // 
            // dockManager1
            // 
            this.dockManager1.Controller = this.barAndDockingController1;
            this.dockManager1.Form = this;
            this.dockManager1.RootPanels.AddRange(new DevExpress.XtraBars.Docking.DockPanel[] {
            this.dockPanelResult,
            this.dockPanel1,
            this.dockPanelAlarm});
            this.dockManager1.TopZIndexControls.AddRange(new string[] {
            "DevExpress.XtraBars.BarDockControl",
            "DevExpress.XtraBars.StandaloneBarDockControl",
            "System.Windows.Forms.StatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonStatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonControl"});
            // 
            // dockPanelResult
            // 
            this.dockPanelResult.Controls.Add(this.dockPanel2_Container);
            this.dockPanelResult.Dock = DevExpress.XtraBars.Docking.DockingStyle.Right;
            this.dockPanelResult.ID = new System.Guid("324e6132-3aa7-458f-848d-8ebbea578ea5");
            this.dockPanelResult.Location = new System.Drawing.Point(1051, 55);
            this.dockPanelResult.Name = "dockPanelResult";
            this.dockPanelResult.OriginalSize = new System.Drawing.Size(200, 200);
            this.dockPanelResult.Size = new System.Drawing.Size(200, 669);
            this.dockPanelResult.Text = "报警";
            // 
            // dockPanel2_Container
            // 
            this.dockPanel2_Container.Location = new System.Drawing.Point(4, 23);
            this.dockPanel2_Container.Name = "dockPanel2_Container";
            this.dockPanel2_Container.Size = new System.Drawing.Size(192, 642);
            this.dockPanel2_Container.TabIndex = 0;
            // 
            // dockPanel1
            // 
            this.dockPanel1.Controls.Add(this.dockPanel1_Container);
            this.dockPanel1.Dock = DevExpress.XtraBars.Docking.DockingStyle.Left;
            this.dockPanel1.ID = new System.Guid("e603f316-2b99-4234-84b6-2fcc0438bb24");
            this.dockPanel1.Location = new System.Drawing.Point(0, 55);
            this.dockPanel1.Name = "dockPanel1";
            this.dockPanel1.Options.AllowFloating = false;
            this.dockPanel1.Options.FloatOnDblClick = false;
            this.dockPanel1.Options.ShowAutoHideButton = false;
            this.dockPanel1.Options.ShowCloseButton = false;
            this.dockPanel1.OriginalSize = new System.Drawing.Size(200, 200);
            this.dockPanel1.Size = new System.Drawing.Size(200, 669);
            this.dockPanel1.Text = "导航";
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Controls.Add(this.splitContainerControl1);
            this.dockPanel1_Container.Location = new System.Drawing.Point(4, 23);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(192, 642);
            this.dockPanel1_Container.TabIndex = 0;
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Horizontal = false;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.cameraView1);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.simpleButton5);
            this.splitContainerControl1.Panel2.Controls.Add(this.simpleButton4);
            this.splitContainerControl1.Panel2.Controls.Add(this.simpleButton3);
            this.splitContainerControl1.Panel2.Controls.Add(this.simpleButton2);
            this.splitContainerControl1.Panel2.Controls.Add(this.simpleButton1);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(192, 642);
            this.splitContainerControl1.SplitterPosition = 603;
            this.splitContainerControl1.TabIndex = 0;
            this.splitContainerControl1.Text = "splitContainerControl1";
            this.splitContainerControl1.Resize += new System.EventHandler(this.splitContainerControl1_Resize);
            this.splitContainerControl1.SplitterPositionChanged += new System.EventHandler(this.splitContainerControl1_SplitterPositionChanged);
            // 
            // cameraView1
            // 
            this.cameraView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cameraView1.Location = new System.Drawing.Point(0, 0);
            this.cameraView1.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.cameraView1.Name = "cameraView1";
            this.cameraView1.Size = new System.Drawing.Size(188, 603);
            this.cameraView1.TabIndex = 4;
            // 
            // simpleButton5
            // 
            this.simpleButton5.Location = new System.Drawing.Point(153, 1);
            this.simpleButton5.Name = "simpleButton5";
            this.simpleButton5.Size = new System.Drawing.Size(32, 32);
            this.simpleButton5.TabIndex = 0;
            this.simpleButton5.Text = "25";
            this.simpleButton5.Click += new System.EventHandler(this.simpleButton5_Click);
            // 
            // simpleButton4
            // 
            this.simpleButton4.Location = new System.Drawing.Point(116, 1);
            this.simpleButton4.Name = "simpleButton4";
            this.simpleButton4.Size = new System.Drawing.Size(32, 32);
            this.simpleButton4.TabIndex = 0;
            this.simpleButton4.Text = "16";
            this.simpleButton4.Click += new System.EventHandler(this.simpleButton4_Click);
            // 
            // simpleButton3
            // 
            this.simpleButton3.Location = new System.Drawing.Point(78, 1);
            this.simpleButton3.Name = "simpleButton3";
            this.simpleButton3.Size = new System.Drawing.Size(32, 32);
            this.simpleButton3.TabIndex = 0;
            this.simpleButton3.Text = "9";
            this.simpleButton3.Click += new System.EventHandler(this.simpleButton3_Click);
            // 
            // simpleButton2
            // 
            this.simpleButton2.Location = new System.Drawing.Point(40, 1);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(32, 32);
            this.simpleButton2.TabIndex = 0;
            this.simpleButton2.Text = "4";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(2, 1);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(32, 32);
            this.simpleButton1.TabIndex = 0;
            this.simpleButton1.Text = "1";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // dockPanelAlarm
            // 
            this.dockPanelAlarm.Controls.Add(this.dockPanel3_Container);
            this.dockPanelAlarm.Dock = DevExpress.XtraBars.Docking.DockingStyle.Bottom;
            this.dockPanelAlarm.ID = new System.Guid("a9616fb8-8c7a-42f6-8822-ac9022a24a64");
            this.dockPanelAlarm.Location = new System.Drawing.Point(200, 411);
            this.dockPanelAlarm.Name = "dockPanelAlarm";
            this.dockPanelAlarm.OriginalSize = new System.Drawing.Size(200, 313);
            this.dockPanelAlarm.Size = new System.Drawing.Size(851, 313);
            this.dockPanelAlarm.Text = "结果";
            // 
            // dockPanel3_Container
            // 
            this.dockPanel3_Container.Controls.Add(this.pcBottom);
            this.dockPanel3_Container.Location = new System.Drawing.Point(4, 23);
            this.dockPanel3_Container.Name = "dockPanel3_Container";
            this.dockPanel3_Container.Size = new System.Drawing.Size(843, 286);
            this.dockPanel3_Container.TabIndex = 0;
            // 
            // pcBottom
            // 
            this.pcBottom.Controls.Add(this.xtraTabControlResult);
            this.pcBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcBottom.Location = new System.Drawing.Point(0, 0);
            this.pcBottom.Name = "pcBottom";
            this.pcBottom.Size = new System.Drawing.Size(843, 286);
            this.pcBottom.TabIndex = 6;
            // 
            // xtraTabControlResult
            // 
            this.xtraTabControlResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControlResult.Location = new System.Drawing.Point(2, 2);
            this.xtraTabControlResult.Name = "xtraTabControlResult";
            this.xtraTabControlResult.SelectedTabPage = this.xtraTabPageEvent;
            this.xtraTabControlResult.Size = new System.Drawing.Size(839, 282);
            this.xtraTabControlResult.TabIndex = 0;
            this.xtraTabControlResult.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPageEvent,
            this.xtraTabPageVehicle,
            this.xtraTabPageFace});
            // 
            // xtraTabPageEvent
            // 
            this.xtraTabPageEvent.Controls.Add(this.panelControl2);
            this.xtraTabPageEvent.Controls.Add(this.panelControl1);
            this.xtraTabPageEvent.Name = "xtraTabPageEvent";
            this.xtraTabPageEvent.Size = new System.Drawing.Size(833, 254);
            this.xtraTabPageEvent.Text = "事件";
            // 
            // panelControl2
            // 
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(0, 42);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(833, 212);
            this.panelControl2.TabIndex = 1;
            // 
            // panelControl1
            // 
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(833, 42);
            this.panelControl1.TabIndex = 0;
            // 
            // xtraTabPageVehicle
            // 
            this.xtraTabPageVehicle.Controls.Add(this.panelControl3);
            this.xtraTabPageVehicle.Controls.Add(this.panelControl4);
            this.xtraTabPageVehicle.Name = "xtraTabPageVehicle";
            this.xtraTabPageVehicle.Size = new System.Drawing.Size(833, 254);
            this.xtraTabPageVehicle.Text = "车牌";
            // 
            // panelControl3
            // 
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl3.Location = new System.Drawing.Point(0, 48);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(833, 206);
            this.panelControl3.TabIndex = 3;
            // 
            // panelControl4
            // 
            this.panelControl4.Controls.Add(this.textEdit1);
            this.panelControl4.Controls.Add(this.labelControl2);
            this.panelControl4.Controls.Add(this.simpleButton6);
            this.panelControl4.Controls.Add(this.labelControl3);
            this.panelControl4.Controls.Add(this.labelControl4);
            this.panelControl4.Controls.Add(this.timeEdit1);
            this.panelControl4.Controls.Add(this.timeEdit2);
            this.panelControl4.Controls.Add(this.checkedComboBoxEdit2);
            this.panelControl4.Controls.Add(this.labelControl5);
            this.panelControl4.Controls.Add(this.radioGroup2);
            this.panelControl4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl4.Location = new System.Drawing.Point(0, 0);
            this.panelControl4.Name = "panelControl4";
            this.panelControl4.Size = new System.Drawing.Size(833, 48);
            this.panelControl4.TabIndex = 2;
            // 
            // textEdit1
            // 
            this.textEdit1.Location = new System.Drawing.Point(591, 17);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textEdit1.Size = new System.Drawing.Size(102, 21);
            this.textEdit1.TabIndex = 32;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(525, 20);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(60, 14);
            this.labelControl2.TabIndex = 30;
            this.labelControl2.Text = "车牌号码：";
            // 
            // simpleButton6
            // 
            this.simpleButton6.Appearance.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton6.Appearance.Options.UseFont = true;
            this.simpleButton6.Dock = System.Windows.Forms.DockStyle.Right;
            this.simpleButton6.ImeMode = System.Windows.Forms.ImeMode.Alpha;
            this.simpleButton6.Location = new System.Drawing.Point(771, 2);
            this.simpleButton6.Name = "simpleButton6";
            this.simpleButton6.Size = new System.Drawing.Size(60, 44);
            this.simpleButton6.TabIndex = 34;
            this.simpleButton6.Text = "查询";
            // 
            // labelControl3
            // 
            this.labelControl3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.labelControl3.Location = new System.Drawing.Point(269, 1);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(60, 14);
            this.labelControl3.TabIndex = 28;
            this.labelControl3.Text = "开始时间：";
            // 
            // labelControl4
            // 
            this.labelControl4.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.labelControl4.Location = new System.Drawing.Point(269, 24);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(60, 14);
            this.labelControl4.TabIndex = 29;
            this.labelControl4.Text = "结束时间：";
            // 
            // timeEdit1
            // 
            this.timeEdit1.EditValue = new System.DateTime(2010, 10, 30, 0, 0, 0, 0);
            this.timeEdit1.Location = new System.Drawing.Point(335, -2);
            this.timeEdit1.Name = "timeEdit1";
            this.timeEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.timeEdit1.Properties.Mask.EditMask = "G";
            this.timeEdit1.Size = new System.Drawing.Size(155, 21);
            this.timeEdit1.TabIndex = 31;
            // 
            // timeEdit2
            // 
            this.timeEdit2.EditValue = new System.DateTime(2010, 1, 11, 0, 0, 0, 0);
            this.timeEdit2.Location = new System.Drawing.Point(335, 25);
            this.timeEdit2.Name = "timeEdit2";
            this.timeEdit2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.timeEdit2.Properties.Mask.EditMask = "G";
            this.timeEdit2.Size = new System.Drawing.Size(155, 21);
            this.timeEdit2.TabIndex = 33;
            // 
            // checkedComboBoxEdit2
            // 
            this.checkedComboBoxEdit2.Location = new System.Drawing.Point(111, 15);
            this.checkedComboBoxEdit2.MenuManager = this.barManager1;
            this.checkedComboBoxEdit2.Name = "checkedComboBoxEdit2";
            this.checkedComboBoxEdit2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.checkedComboBoxEdit2.Size = new System.Drawing.Size(117, 21);
            this.checkedComboBoxEdit2.TabIndex = 27;
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(65, 18);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(40, 14);
            this.labelControl5.TabIndex = 26;
            this.labelControl5.Text = "摄像头:";
            // 
            // radioGroup2
            // 
            this.radioGroup2.Dock = System.Windows.Forms.DockStyle.Left;
            this.radioGroup2.Location = new System.Drawing.Point(2, 2);
            this.radioGroup2.MenuManager = this.barManager1;
            this.radioGroup2.Name = "radioGroup2";
            this.radioGroup2.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "实时"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "历史")});
            this.radioGroup2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.radioGroup2.Size = new System.Drawing.Size(57, 44);
            this.radioGroup2.TabIndex = 25;
            // 
            // xtraTabPageFace
            // 
            this.xtraTabPageFace.Controls.Add(this.panelControl5);
            this.xtraTabPageFace.Controls.Add(this.panelControl6);
            this.xtraTabPageFace.Name = "xtraTabPageFace";
            this.xtraTabPageFace.Size = new System.Drawing.Size(833, 254);
            this.xtraTabPageFace.Text = "人脸";
            // 
            // panelControl5
            // 
            this.panelControl5.Controls.Add(this.panelControl8);
            this.panelControl5.Controls.Add(this.panelControl7);
            this.panelControl5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl5.Location = new System.Drawing.Point(0, 48);
            this.panelControl5.Name = "panelControl5";
            this.panelControl5.Size = new System.Drawing.Size(833, 206);
            this.panelControl5.TabIndex = 3;
            // 
            // panelControl8
            // 
            this.panelControl8.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl8.Controls.Add(this.gridControlFace);
            this.panelControl8.Controls.Add(this.panelControl9);
            this.panelControl8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl8.Location = new System.Drawing.Point(2, 2);
            this.panelControl8.Name = "panelControl8";
            this.panelControl8.Size = new System.Drawing.Size(629, 202);
            this.panelControl8.TabIndex = 1;
            // 
            // gridControlFace
            // 
            this.gridControlFace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlFace.Location = new System.Drawing.Point(0, 0);
            this.gridControlFace.MainView = this.gridViewFace;
            this.gridControlFace.MenuManager = this.barManager1;
            this.gridControlFace.Name = "gridControlFace";
            this.gridControlFace.Size = new System.Drawing.Size(429, 202);
            this.gridControlFace.TabIndex = 1;
            this.gridControlFace.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewFace});
            // 
            // gridViewFace
            // 
            this.gridViewFace.GridControl = this.gridControlFace;
            this.gridViewFace.Name = "gridViewFace";
            this.gridViewFace.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridViewFace.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridViewFace.OptionsBehavior.Editable = false;
            this.gridViewFace.OptionsBehavior.ReadOnly = true;
            this.gridViewFace.OptionsSelection.EnableAppearanceHideSelection = false;
            this.gridViewFace.OptionsSelection.InvertSelection = true;
            this.gridViewFace.OptionsView.RowAutoHeight = true;
            this.gridViewFace.OptionsView.ShowGroupPanel = false;
            // 
            // panelControl9
            // 
            this.panelControl9.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelControl9.Location = new System.Drawing.Point(429, 0);
            this.panelControl9.Name = "panelControl9";
            this.panelControl9.Size = new System.Drawing.Size(200, 202);
            this.panelControl9.TabIndex = 0;
            // 
            // panelControl7
            // 
            this.panelControl7.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelControl7.Location = new System.Drawing.Point(631, 2);
            this.panelControl7.Name = "panelControl7";
            this.panelControl7.Size = new System.Drawing.Size(200, 202);
            this.panelControl7.TabIndex = 0;
            // 
            // panelControl6
            // 
            this.panelControl6.Controls.Add(this.btnQueryFace);
            this.panelControl6.Controls.Add(this.lblStartTime);
            this.panelControl6.Controls.Add(this.lblEndTime);
            this.panelControl6.Controls.Add(this.teStartTimeFace);
            this.panelControl6.Controls.Add(this.teEndTimeFace);
            this.panelControl6.Controls.Add(this.checkedComboBoxEditFaceCamera);
            this.panelControl6.Controls.Add(this.labelControl1);
            this.panelControl6.Controls.Add(this.radioGroupFace);
            this.panelControl6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl6.Location = new System.Drawing.Point(0, 0);
            this.panelControl6.Name = "panelControl6";
            this.panelControl6.Size = new System.Drawing.Size(833, 48);
            this.panelControl6.TabIndex = 2;
            // 
            // btnQueryFace
            // 
            this.btnQueryFace.Appearance.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQueryFace.Appearance.Options.UseFont = true;
            this.btnQueryFace.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnQueryFace.Enabled = false;
            this.btnQueryFace.ImeMode = System.Windows.Forms.ImeMode.Alpha;
            this.btnQueryFace.Location = new System.Drawing.Point(771, 2);
            this.btnQueryFace.Name = "btnQueryFace";
            this.btnQueryFace.Size = new System.Drawing.Size(60, 44);
            this.btnQueryFace.TabIndex = 24;
            this.btnQueryFace.Text = "查询";
            this.btnQueryFace.Click += new System.EventHandler(this.btnQueryFace_Click);
            // 
            // lblStartTime
            // 
            this.lblStartTime.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.lblStartTime.Location = new System.Drawing.Point(271, 14);
            this.lblStartTime.Name = "lblStartTime";
            this.lblStartTime.Size = new System.Drawing.Size(60, 14);
            this.lblStartTime.TabIndex = 20;
            this.lblStartTime.Text = "开始时间：";
            // 
            // lblEndTime
            // 
            this.lblEndTime.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.lblEndTime.Location = new System.Drawing.Point(506, 14);
            this.lblEndTime.Name = "lblEndTime";
            this.lblEndTime.Size = new System.Drawing.Size(60, 14);
            this.lblEndTime.TabIndex = 21;
            this.lblEndTime.Text = "结束时间：";
            // 
            // teStartTimeFace
            // 
            this.teStartTimeFace.EditValue = new System.DateTime(2010, 10, 30, 11, 0, 0, 0);
            this.teStartTimeFace.Enabled = false;
            this.teStartTimeFace.Location = new System.Drawing.Point(337, 11);
            this.teStartTimeFace.Name = "teStartTimeFace";
            this.teStartTimeFace.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.teStartTimeFace.Properties.Mask.EditMask = "G";
            this.teStartTimeFace.Size = new System.Drawing.Size(145, 21);
            this.teStartTimeFace.TabIndex = 22;
            // 
            // teEndTimeFace
            // 
            this.teEndTimeFace.EditValue = new System.DateTime(2010, 1, 11, 10, 0, 0, 0);
            this.teEndTimeFace.Enabled = false;
            this.teEndTimeFace.Location = new System.Drawing.Point(572, 11);
            this.teEndTimeFace.Name = "teEndTimeFace";
            this.teEndTimeFace.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.teEndTimeFace.Properties.Mask.EditMask = "G";
            this.teEndTimeFace.Size = new System.Drawing.Size(138, 21);
            this.teEndTimeFace.TabIndex = 23;
            // 
            // checkedComboBoxEditFaceCamera
            // 
            this.checkedComboBoxEditFaceCamera.Location = new System.Drawing.Point(111, 11);
            this.checkedComboBoxEditFaceCamera.MenuManager = this.barManager1;
            this.checkedComboBoxEditFaceCamera.Name = "checkedComboBoxEditFaceCamera";
            this.checkedComboBoxEditFaceCamera.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.checkedComboBoxEditFaceCamera.Size = new System.Drawing.Size(117, 21);
            this.checkedComboBoxEditFaceCamera.TabIndex = 2;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(65, 14);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(40, 14);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "摄像头:";
            // 
            // radioGroupFace
            // 
            this.radioGroupFace.Dock = System.Windows.Forms.DockStyle.Left;
            this.radioGroupFace.Location = new System.Drawing.Point(2, 2);
            this.radioGroupFace.MenuManager = this.barManager1;
            this.radioGroupFace.Name = "radioGroupFace";
            this.radioGroupFace.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "实时"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "历史")});
            this.radioGroupFace.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.radioGroupFace.Size = new System.Drawing.Size(57, 44);
            this.radioGroupFace.TabIndex = 0;
            this.radioGroupFace.SelectedIndexChanged += new System.EventHandler(this.radioGroupFace_SelectedIndexChanged);
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "系统配置(&S)";
            this.barButtonItem1.Id = 0;
            this.barButtonItem1.Name = "barButtonItem1";
            this.barButtonItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem1_ItemClick);
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "视图(&V)";
            this.barButtonItem2.Id = 1;
            this.barButtonItem2.Name = "barButtonItem2";
            // 
            // barButtonItem4
            // 
            this.barButtonItem4.Caption = "查询(&Q)";
            this.barButtonItem4.Id = 3;
            this.barButtonItem4.Name = "barButtonItem4";
            // 
            // barbtnClose
            // 
            this.barbtnClose.Caption = "退出系统";
            this.barbtnClose.Id = 5;
            this.barbtnClose.Name = "barbtnClose";
            this.barbtnClose.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barbtnClose_ItemClick);
            // 
            // barButtonItem6
            // 
            this.barButtonItem6.Caption = "关于";
            this.barButtonItem6.Id = 6;
            this.barButtonItem6.Name = "barButtonItem6";
            // 
            // barSubItem3
            // 
            this.barSubItem3.Caption = "barSubItem3";
            this.barSubItem3.Id = 11;
            this.barSubItem3.Name = "barSubItem3";
            // 
            // barStaticItem6
            // 
            this.barStaticItem6.Caption = "正常";
            this.barStaticItem6.Id = 28;
            this.barStaticItem6.Name = "barStaticItem6";
            this.barStaticItem6.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // mainMultiplexer
            // 
            this.mainMultiplexer.CellHeight = 288;
            this.mainMultiplexer.CellWidth = 352;
            this.mainMultiplexer.Cols = 4;
            this.mainMultiplexer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainMultiplexer.Location = new System.Drawing.Point(200, 55);
            this.mainMultiplexer.Name = "mainMultiplexer";
            this.mainMultiplexer.Rows = 4;
            this.mainMultiplexer.Size = new System.Drawing.Size(851, 356);
            this.mainMultiplexer.TabIndex = 5;
            this.mainMultiplexer.DoubleCamera += new CameraViewer.Multiplexer.MyCurrentCamera(this.multiplexer1_DoubleCamera);
            // 
            // cmIcon
            // 
            this.cmIcon.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.删除ToolStripMenuItem});
            this.cmIcon.Name = "cmIcon";
            this.cmIcon.ShowImageMargin = false;
            this.cmIcon.Size = new System.Drawing.Size(76, 26);
            // 
            // 删除ToolStripMenuItem
            // 
            this.删除ToolStripMenuItem.Name = "删除ToolStripMenuItem";
            this.删除ToolStripMenuItem.Size = new System.Drawing.Size(75, 22);
            this.删除ToolStripMenuItem.Text = "删除";
            this.删除ToolStripMenuItem.Click += new System.EventHandler(this.删除ToolStripMenuItem_Click);
            // 
            // timerCheckAlarmSites
            // 
            this.timerCheckAlarmSites.Enabled = true;
            this.timerCheckAlarmSites.Interval = 10;
            this.timerCheckAlarmSites.Tick += new System.EventHandler(this.timerCheckAlarmSites_Tick);
            // 
            // timerUpdateIcon
            // 
            this.timerUpdateIcon.Enabled = true;
            this.timerUpdateIcon.Interval = 400;
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem1),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem2),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem4),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem6)});
            this.bar2.OptionsBar.DisableClose = true;
            this.bar2.OptionsBar.DrawDragBorder = false;
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // timerCurretnTime
            // 
            this.timerCurretnTime.Enabled = true;
            this.timerCurretnTime.Interval = 500;
            this.timerCurretnTime.Tick += new System.EventHandler(this.timerCurretnTime_Tick);
            // 
            // timerTest
            // 
            this.timerTest.Enabled = true;
            this.timerTest.Tick += new System.EventHandler(this.timerTest_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1251, 752);
            this.Controls.Add(this.mainMultiplexer);
            this.Controls.Add(this.dockPanelAlarm);
            this.Controls.Add(this.dockPanel1);
            this.Controls.Add(this.dockPanelResult);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.KeyPreview = true;
            this.Name = "MainForm";
            this.Text = "智能视频监控平台V1.0 Build110220";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMain_Win_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_Win_FormClosing);
            this.Resize += new System.EventHandler(this.frmMain_Win_Resize);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmMain_Win_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barAndDockingController1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).EndInit();
            this.dockPanelResult.ResumeLayout(false);
            this.dockPanel1.ResumeLayout(false);
            this.dockPanel1_Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            this.dockPanelAlarm.ResumeLayout(false);
            this.dockPanel3_Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pcBottom)).EndInit();
            this.pcBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControlResult)).EndInit();
            this.xtraTabControlResult.ResumeLayout(false);
            this.xtraTabPageEvent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.xtraTabPageVehicle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).EndInit();
            this.panelControl4.ResumeLayout(false);
            this.panelControl4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkedComboBoxEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup2.Properties)).EndInit();
            this.xtraTabPageFace.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl5)).EndInit();
            this.panelControl5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl8)).EndInit();
            this.panelControl8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlFace)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewFace)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl6)).EndInit();
            this.panelControl6.ResumeLayout(false);
            this.panelControl6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.teStartTimeFace.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teEndTimeFace.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkedComboBoxEditFaceCamera.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroupFace.Properties)).EndInit();
            this.cmIcon.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.BarButtonItem barButtonItem4;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private CameraViewer.Controls.CameraView cameraView1;
        private DevExpress.XtraBars.BarButtonItem barbtnClose;
        private DevExpress.XtraBars.BarButtonItem barButtonItem6;
        private Multiplexer mainMultiplexer;
        private DevExpress.XtraEditors.PanelControl pcBottom;
        private System.Windows.Forms.ContextMenuStrip cmIcon;
        private System.Windows.Forms.ToolStripMenuItem 删除ToolStripMenuItem;
        private Timer timerCheckAlarmSites;
        private Timer timerUpdateIcon;
        private DevExpress.XtraBars.BarAndDockingController barAndDockingController1;
        private DevExpress.XtraBars.Docking.DockManager dockManager1;
        private DevExpress.XtraBars.Docking.DockPanel dockPanelAlarm;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel3_Container;
        private DevExpress.XtraBars.Docking.DockPanel dockPanel1;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel1_Container;
        private DevExpress.XtraBars.Docking.DockPanel dockPanelResult;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel2_Container;
        private DevExpress.XtraBars.Bar barMenu;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.Bar bar4;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarSubItem barSubItemMenuSystem;
        private DevExpress.XtraBars.BarSubItem barSubItemMenuView;
        private DevExpress.XtraBars.BarSubItem barSubItem3;
        private DevExpress.XtraBars.BarSubItem barSubItemMenuQuery;
        private DevExpress.XtraBars.BarSubItem barSubItem1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem3;
        private DevExpress.XtraBars.BarButtonItem barButtonItem5;
        private DevExpress.XtraBars.BarButtonItem barButtonItem7;
        private DevExpress.XtraBars.BarButtonItem barButtonItemResultView;
        private DevExpress.XtraBars.BarButtonItem barButtonItemAlarmView;
        private DevExpress.XtraBars.BarStaticItem barStaticItem1;
        private DevExpress.XtraBars.BarStaticItem barStaticItemCurrentUser;
        private DevExpress.XtraBars.BarStaticItem barStaticItem3;
        private DevExpress.XtraBars.BarStaticItem barStaticItemCameraNo;
        private DevExpress.XtraBars.BarStaticItem barStaticItem2;
        private DevExpress.XtraBars.BarStaticItem barStaticItemDecoderNo;
        private DevExpress.XtraBars.BarStaticItem barStaticItem4;
        private DevExpress.XtraBars.BarStaticItem barStaticItemCurrentTime;
        private Timer timerCurretnTime;
        private DevExpress.XtraBars.BarStaticItem barStaticItem5;
        private DevExpress.XtraBars.BarStaticItem barStaticItemNetStatus;
        private DevExpress.XtraBars.BarStaticItem barStaticItem6;
        private DevExpress.XtraBars.BarButtonItem barButtonItem8;
        private DevExpress.XtraBars.BarButtonItem barButtonItem9;
        private DevExpress.XtraBars.BarButtonItem barButtonItem10;
        private DevExpress.XtraBars.BarButtonItem barButtonItem11;
        private DevExpress.XtraBars.BarButtonItem barButtonItem12;
        private Timer timerTest;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.SimpleButton simpleButton5;
        private DevExpress.XtraEditors.SimpleButton simpleButton4;
        private DevExpress.XtraEditors.SimpleButton simpleButton3;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem13;
        private DevExpress.XtraBars.BarButtonItem barButtonItemGetPics;
        private DevExpress.XtraTab.XtraTabControl xtraTabControlResult;
        private DevExpress.XtraTab.XtraTabPage xtraTabPageEvent;
        private DevExpress.XtraTab.XtraTabPage xtraTabPageVehicle;
        private DevExpress.XtraTab.XtraTabPage xtraTabPageFace;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraEditors.PanelControl panelControl4;
        private DevExpress.XtraEditors.PanelControl panelControl5;
        private DevExpress.XtraEditors.PanelControl panelControl6;
        private DevExpress.XtraEditors.RadioGroup radioGroupFace;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl lblStartTime;
        private DevExpress.XtraEditors.LabelControl lblEndTime;
        private DevExpress.XtraEditors.TimeEdit teStartTimeFace;
        private DevExpress.XtraEditors.TimeEdit teEndTimeFace;
        private DevExpress.XtraEditors.CheckedComboBoxEdit checkedComboBoxEditFaceCamera;
        private DevExpress.XtraEditors.SimpleButton btnQueryFace;
        private DevExpress.XtraEditors.TextEdit textEdit1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SimpleButton simpleButton6;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TimeEdit timeEdit1;
        private DevExpress.XtraEditors.TimeEdit timeEdit2;
        private DevExpress.XtraEditors.CheckedComboBoxEdit checkedComboBoxEdit2;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.RadioGroup radioGroup2;
        private DevExpress.XtraEditors.PanelControl panelControl8;
        private DevExpress.XtraEditors.PanelControl panelControl9;
        private DevExpress.XtraEditors.PanelControl panelControl7;
        private DevExpress.XtraGrid.GridControl gridControlFace;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewFace;
        
    }
}