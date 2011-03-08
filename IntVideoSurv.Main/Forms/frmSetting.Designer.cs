namespace CameraViewer.Forms
{
    partial class frmSetting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSetting));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.navBarControl1 = new DevExpress.XtraNavBar.NavBarControl();
            this.navBarGroup1 = new DevExpress.XtraNavBar.NavBarGroup();
            this.nbDevice = new DevExpress.XtraNavBar.NavBarItem();
            this.nbUser = new DevExpress.XtraNavBar.NavBarItem();
            this.nbLog = new DevExpress.XtraNavBar.NavBarItem();
            this.nbMap = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem1 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem2 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem6 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem7 = new DevExpress.XtraNavBar.NavBarItem();
            this.gcDeviceManagement = new DevExpress.XtraEditors.GroupControl();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.treeViewDevice = new System.Windows.Forms.TreeView();
            this.contextMenuStripGroupAndDevice = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.AddGroupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EditGroupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteGroupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AddDeviceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EditDeviceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteDeviceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dgvDevice = new System.Windows.Forms.DataGridView();
            this.gcUserManagement = new DevExpress.XtraEditors.GroupControl();
            this.splitContainerControl6 = new DevExpress.XtraEditors.SplitContainerControl();
            this.dataGridViewUser = new System.Windows.Forms.DataGridView();
            this.buttonUserUpdate = new System.Windows.Forms.Button();
            this.buttonUserDelete = new System.Windows.Forms.Button();
            this.buttonUserAdd = new System.Windows.Forms.Button();
            this.gcLogManagement = new DevExpress.XtraEditors.GroupControl();
            this.splitContainerControl3 = new DevExpress.XtraEditors.SplitContainerControl();
            this.splitContainerControl4 = new DevExpress.XtraEditors.SplitContainerControl();
            this.treeViewCameraInLogManagement = new System.Windows.Forms.TreeView();
            this.checkBoxUser = new System.Windows.Forms.CheckBox();
            this.splitContainerControl5 = new DevExpress.XtraEditors.SplitContainerControl();
            this.buttonSearchLog = new System.Windows.Forms.Button();
            this.dateEditEndDate = new DevExpress.XtraEditors.DateEdit();
            this.dateEditBeginDate = new DevExpress.XtraEditors.DateEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.comboBoxEditSubLogType = new DevExpress.XtraEditors.ComboBoxEdit();
            this.comboBoxEditLogType = new DevExpress.XtraEditors.ComboBoxEdit();
            this.dataGridViewLog = new System.Windows.Forms.DataGridView();
            this.gcSynGroupManagement = new DevExpress.XtraEditors.GroupControl();
            this.pcSynGroupDisplay = new DevExpress.XtraEditors.PanelControl();
            this.lblSynCameraSplitScreenNo = new System.Windows.Forms.Label();
            this.cbDisplayScreenNo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblGroupName = new System.Windows.Forms.Label();
            this.dgvSynGroupDetail = new System.Windows.Forms.DataGridView();
            this.Device = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Camera = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Monitor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SplitScreen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonAddSynGroup = new System.Windows.Forms.Button();
            this.buttonDeleteSynGroup = new System.Windows.Forms.Button();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.treeViewSynGroup = new System.Windows.Forms.TreeView();
            this.contextMenuStripSynGroup = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ToolStripMenuItemAddSynGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemDeleteSynGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainerDeviceAndMonitor = new DevExpress.XtraEditors.SplitContainerControl();
            this.gcDevice = new DevExpress.XtraEditors.GroupControl();
            this.treeViewSynGroupCamera = new System.Windows.Forms.TreeView();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.treeViewMonitor = new System.Windows.Forms.TreeView();
            this.splitContainerControl2 = new DevExpress.XtraEditors.SplitContainerControl();
            this.DecoderManagement = new DevExpress.XtraEditors.GroupControl();
            this.splitContainerControl7 = new DevExpress.XtraEditors.SplitContainerControl();
            this.treeListShowDecoder = new DevExpress.XtraTreeList.TreeList();
            this.treeListColumn1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn2 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcSkin = new DevExpress.XtraEditors.GroupControl();
            this.panelControl5 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.cbeChangeSkin = new DevExpress.XtraEditors.ComboBoxEdit();
            this.gcDisplayChannelManagement = new DevExpress.XtraEditors.GroupControl();
            this.dgvDisplayChannel = new System.Windows.Forms.DataGridView();
            this.DisplayChannelID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DisplayChannelName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DisplayChannelSplitScreenNo = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.groupControl6 = new DevExpress.XtraEditors.GroupControl();
            this.tvDisplayChannel = new System.Windows.Forms.TreeView();
            this.gcProgSwitchManagement = new DevExpress.XtraEditors.GroupControl();
            this.pcProgSwitchDisplay = new DevExpress.XtraEditors.PanelControl();
            this.btnDeleteProgSwitchDetail = new System.Windows.Forms.Button();
            this.btnAddProgSwitchDetail = new System.Windows.Forms.Button();
            this.lblProgSwitchName = new System.Windows.Forms.Label();
            this.pcTickTimeInProgSwitch = new DevExpress.XtraEditors.PanelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.teTickTimeInProgSwitch = new DevExpress.XtraEditors.TextEdit();
            this.dgvProgSwitchDetail = new System.Windows.Forms.DataGridView();
            this.ProgSwitchDetailId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProgSwitchDevice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProgSwitchCamera = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProgSwitchTick = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProgSwitchMonitor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProgSwitchDisplaySplitScreenNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.gcDeviceInProSwitchManagement = new DevExpress.XtraEditors.GroupControl();
            this.groupControl5 = new DevExpress.XtraEditors.GroupControl();
            this.tvProgSwitch = new System.Windows.Forms.TreeView();
            this.cmAddProgSwitch = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.gcGroupSwitchManagement = new DevExpress.XtraEditors.GroupControl();
            this.pcGroupSwitchDisplay = new DevExpress.XtraEditors.PanelControl();
            this.btnDeleteGroupSwitchDetail = new System.Windows.Forms.Button();
            this.btnAddGroupSwitchDetail = new System.Windows.Forms.Button();
            this.lblGroupSwitchName = new System.Windows.Forms.Label();
            this.pcTickTime = new DevExpress.XtraEditors.PanelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.teGroupSwitchTick = new DevExpress.XtraEditors.TextEdit();
            this.dgvGroupSwitchDetail = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SynGroup = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tick = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.gcSynGroup = new DevExpress.XtraEditors.GroupControl();
            this.tvSynGroupTop = new System.Windows.Forms.TreeView();
            this.gcGroupSwitchGroup = new DevExpress.XtraEditors.GroupControl();
            this.tvGroupSwitchGroup = new System.Windows.Forms.TreeView();
            this.cmAddGroupSwitchGroup = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.添加群组切换ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gcMap = new DevExpress.XtraEditors.GroupControl();
            this.pcMapPreview = new DevExpress.XtraEditors.PanelControl();
            this.pictureBoxMap = new System.Windows.Forms.PictureBox();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.btnBrowserMap = new System.Windows.Forms.Button();
            this.btnAddMap = new System.Windows.Forms.Button();
            this.teMapName = new DevExpress.XtraEditors.TextEdit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.pcMapTreeview = new DevExpress.XtraEditors.PanelControl();
            this.tvMap = new System.Windows.Forms.TreeView();
            this.cmDeleteMap = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.删除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openMapFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.barButtonItem1AddDecoder = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem2EditDecoder = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem4AddCamera = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem5EditDecoder = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem6DeleteDecoder = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemDeleteCamera = new DevExpress.XtraBars.BarButtonItem();
            this.popupMenuDecoder = new DevExpress.XtraBars.PopupMenu(this.components);
            this.popupMenuCamera = new DevExpress.XtraBars.PopupMenu(this.components);
            this.popupMenu1 = new DevExpress.XtraBars.PopupMenu(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcDeviceManagement)).BeginInit();
            this.gcDeviceManagement.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            this.contextMenuStripGroupAndDevice.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDevice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcUserManagement)).BeginInit();
            this.gcUserManagement.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl6)).BeginInit();
            this.splitContainerControl6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcLogManagement)).BeginInit();
            this.gcLogManagement.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl3)).BeginInit();
            this.splitContainerControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl4)).BeginInit();
            this.splitContainerControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl5)).BeginInit();
            this.splitContainerControl5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditEndDate.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditEndDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditBeginDate.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditBeginDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditSubLogType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditLogType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLog)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcSynGroupManagement)).BeginInit();
            this.gcSynGroupManagement.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcSynGroupDisplay)).BeginInit();
            this.pcSynGroupDisplay.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSynGroupDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            this.contextMenuStripSynGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerDeviceAndMonitor)).BeginInit();
            this.splitContainerDeviceAndMonitor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcDevice)).BeginInit();
            this.gcDevice.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2)).BeginInit();
            this.splitContainerControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DecoderManagement)).BeginInit();
            this.DecoderManagement.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl7)).BeginInit();
            this.splitContainerControl7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeListShowDecoder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcSkin)).BeginInit();
            this.gcSkin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl5)).BeginInit();
            this.panelControl5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbeChangeSkin.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcDisplayChannelManagement)).BeginInit();
            this.gcDisplayChannelManagement.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDisplayChannel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl6)).BeginInit();
            this.groupControl6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcProgSwitchManagement)).BeginInit();
            this.gcProgSwitchManagement.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcProgSwitchDisplay)).BeginInit();
            this.pcProgSwitchDisplay.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcTickTimeInProgSwitch)).BeginInit();
            this.pcTickTimeInProgSwitch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.teTickTimeInProgSwitch.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProgSwitchDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcDeviceInProSwitchManagement)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl5)).BeginInit();
            this.groupControl5.SuspendLayout();
            this.cmAddProgSwitch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcGroupSwitchManagement)).BeginInit();
            this.gcGroupSwitchManagement.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcGroupSwitchDisplay)).BeginInit();
            this.pcGroupSwitchDisplay.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcTickTime)).BeginInit();
            this.pcTickTime.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.teGroupSwitchTick.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGroupSwitchDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcSynGroup)).BeginInit();
            this.gcSynGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcGroupSwitchGroup)).BeginInit();
            this.gcGroupSwitchGroup.SuspendLayout();
            this.cmAddGroupSwitchGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcMap)).BeginInit();
            this.gcMap.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcMapPreview)).BeginInit();
            this.pcMapPreview.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.teMapName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcMapTreeview)).BeginInit();
            this.pcMapTreeview.SuspendLayout();
            this.cmDeleteMap.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenuDecoder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenuCamera)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).BeginInit();
            this.SuspendLayout();
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.OptionsBar.DisableClose = true;
            this.bar2.OptionsBar.DrawDragBorder = false;
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // bar1
            // 
            this.bar1.BarName = "Main menu";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.OptionsBar.DisableClose = true;
            this.bar1.OptionsBar.DrawDragBorder = false;
            this.bar1.OptionsBar.MultiLine = true;
            this.bar1.OptionsBar.UseWholeRow = true;
            this.bar1.Text = "Main menu";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Magenta;
            this.imageList1.Images.SetKeyName(0, "");
            this.imageList1.Images.SetKeyName(1, "");
            this.imageList1.Images.SetKeyName(2, "");
            this.imageList1.Images.SetKeyName(3, "");
            this.imageList1.Images.SetKeyName(4, "");
            this.imageList1.Images.SetKeyName(5, "");
            this.imageList1.Images.SetKeyName(6, "");
            this.imageList1.Images.SetKeyName(7, "");
            this.imageList1.Images.SetKeyName(8, "");
            this.imageList1.Images.SetKeyName(9, "videocamera.ico");
            // 
            // imageList2
            // 
            this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
            this.imageList2.TransparentColor = System.Drawing.Color.Magenta;
            this.imageList2.Images.SetKeyName(0, "");
            this.imageList2.Images.SetKeyName(1, "");
            this.imageList2.Images.SetKeyName(2, "");
            this.imageList2.Images.SetKeyName(3, "");
            this.imageList2.Images.SetKeyName(4, "");
            this.imageList2.Images.SetKeyName(5, "");
            this.imageList2.Images.SetKeyName(6, "");
            this.imageList2.Images.SetKeyName(7, "");
            this.imageList2.Images.SetKeyName(8, "");
            this.imageList2.Images.SetKeyName(9, "videocamera.ico");
            // 
            // navBarControl1
            // 
            this.navBarControl1.ActiveGroup = this.navBarGroup1;
            this.navBarControl1.ContentButtonHint = null;
            this.navBarControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navBarControl1.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
            this.navBarGroup1});
            this.navBarControl1.Items.AddRange(new DevExpress.XtraNavBar.NavBarItem[] {
            this.nbDevice,
            this.nbUser,
            this.nbLog,
            this.navBarItem6,
            this.navBarItem7,
            this.nbMap,
            this.navBarItem1,
            this.navBarItem2});
            this.navBarControl1.LargeImages = this.imageList1;
            this.navBarControl1.Location = new System.Drawing.Point(0, 0);
            this.navBarControl1.Name = "navBarControl1";
            this.navBarControl1.OptionsNavPane.ExpandedWidth = 140;
            this.navBarControl1.Size = new System.Drawing.Size(128, 575);
            this.navBarControl1.SmallImages = this.imageList2;
            this.navBarControl1.StoreDefaultPaintStyleName = true;
            this.navBarControl1.TabIndex = 30;
            this.navBarControl1.Text = "navBarControl1";
            // 
            // navBarGroup1
            // 
            this.navBarGroup1.Caption = "系统管理";
            this.navBarGroup1.Expanded = true;
            this.navBarGroup1.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.SmallIconsText;
            this.navBarGroup1.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.nbDevice),
            new DevExpress.XtraNavBar.NavBarItemLink(this.nbUser),
            new DevExpress.XtraNavBar.NavBarItemLink(this.nbLog),
            new DevExpress.XtraNavBar.NavBarItemLink(this.nbMap),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem1),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem2)});
            this.navBarGroup1.Name = "navBarGroup1";
            // 
            // nbDevice
            // 
            this.nbDevice.Caption = "设备管理";
            this.nbDevice.LargeImageIndex = 9;
            this.nbDevice.Name = "nbDevice";
            this.nbDevice.SmallImageIndex = 0;
            this.nbDevice.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nbDevice_LinkClicked);
            // 
            // nbUser
            // 
            this.nbUser.Caption = "用户管理";
            this.nbUser.LargeImageIndex = 1;
            this.nbUser.Name = "nbUser";
            this.nbUser.SmallImageIndex = 1;
            this.nbUser.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nbUser_LinkClicked);
            // 
            // nbLog
            // 
            this.nbLog.Caption = "日志管理";
            this.nbLog.LargeImageIndex = 2;
            this.nbLog.Name = "nbLog";
            this.nbLog.SmallImageIndex = 2;
            this.nbLog.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nbLog_LinkClicked);
            // 
            // nbMap
            // 
            this.nbMap.Caption = "地图管理";
            this.nbMap.LargeImageIndex = 6;
            this.nbMap.Name = "nbMap";
            this.nbMap.SmallImageIndex = 6;
            this.nbMap.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nbMap_LinkClicked);
            // 
            // navBarItem1
            // 
            this.navBarItem1.Caption = "皮肤管理";
            this.navBarItem1.LargeImageIndex = 7;
            this.navBarItem1.Name = "navBarItem1";
            this.navBarItem1.SmallImageIndex = 7;
            this.navBarItem1.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem1_LinkClicked);
            // 
            // navBarItem2
            // 
            this.navBarItem2.Caption = "解码器管理";
            this.navBarItem2.LargeImageIndex = 7;
            this.navBarItem2.Name = "navBarItem2";
            this.navBarItem2.SmallImageIndex = 7;
            this.navBarItem2.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nbdecoder_click);
            // 
            // navBarItem6
            // 
            this.navBarItem6.Caption = "Calendar";
            this.navBarItem6.LargeImageIndex = 7;
            this.navBarItem6.Name = "navBarItem6";
            this.navBarItem6.SmallImageIndex = 7;
            // 
            // navBarItem7
            // 
            this.navBarItem7.Caption = "Task";
            this.navBarItem7.LargeImageIndex = 8;
            this.navBarItem7.Name = "navBarItem7";
            this.navBarItem7.SmallImageIndex = 8;
            // 
            // gcDeviceManagement
            // 
            this.gcDeviceManagement.Controls.Add(this.splitContainerControl1);
            this.gcDeviceManagement.Location = new System.Drawing.Point(317, 216);
            this.gcDeviceManagement.Name = "gcDeviceManagement";
            this.gcDeviceManagement.Size = new System.Drawing.Size(440, 290);
            this.gcDeviceManagement.TabIndex = 31;
            this.gcDeviceManagement.Text = "设备管理";
            this.gcDeviceManagement.Visible = false;
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(2, 23);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.treeViewDevice);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.dgvDevice);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(436, 265);
            this.splitContainerControl1.SplitterPosition = 198;
            this.splitContainerControl1.TabIndex = 7;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // treeViewDevice
            // 
            this.treeViewDevice.ContextMenuStrip = this.contextMenuStripGroupAndDevice;
            this.treeViewDevice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewDevice.Location = new System.Drawing.Point(0, 0);
            this.treeViewDevice.Name = "treeViewDevice";
            this.treeViewDevice.Size = new System.Drawing.Size(198, 265);
            this.treeViewDevice.TabIndex = 6;
            this.treeViewDevice.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseClick);
            // 
            // contextMenuStripGroupAndDevice
            // 
            this.contextMenuStripGroupAndDevice.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddGroupToolStripMenuItem,
            this.EditGroupToolStripMenuItem,
            this.DeleteGroupToolStripMenuItem,
            this.AddDeviceToolStripMenuItem,
            this.EditDeviceToolStripMenuItem,
            this.DeleteDeviceToolStripMenuItem});
            this.contextMenuStripGroupAndDevice.Name = "contextMenuStrip1";
            this.contextMenuStripGroupAndDevice.ShowImageMargin = false;
            this.contextMenuStripGroupAndDevice.Size = new System.Drawing.Size(100, 136);
            // 
            // AddGroupToolStripMenuItem
            // 
            this.AddGroupToolStripMenuItem.Name = "AddGroupToolStripMenuItem";
            this.AddGroupToolStripMenuItem.Size = new System.Drawing.Size(99, 22);
            this.AddGroupToolStripMenuItem.Text = "新增群组";
            this.AddGroupToolStripMenuItem.Click += new System.EventHandler(this.AddGroupToolStripMenuItem_Click);
            // 
            // EditGroupToolStripMenuItem
            // 
            this.EditGroupToolStripMenuItem.Name = "EditGroupToolStripMenuItem";
            this.EditGroupToolStripMenuItem.Size = new System.Drawing.Size(99, 22);
            this.EditGroupToolStripMenuItem.Text = "修改群组";
            this.EditGroupToolStripMenuItem.Click += new System.EventHandler(this.EditGroupToolStripMenuItem_Click);
            // 
            // DeleteGroupToolStripMenuItem
            // 
            this.DeleteGroupToolStripMenuItem.Name = "DeleteGroupToolStripMenuItem";
            this.DeleteGroupToolStripMenuItem.Size = new System.Drawing.Size(99, 22);
            this.DeleteGroupToolStripMenuItem.Text = "删除群组";
            this.DeleteGroupToolStripMenuItem.Click += new System.EventHandler(this.DeleteGroupToolStripMenuItem_Click);
            // 
            // AddDeviceToolStripMenuItem
            // 
            this.AddDeviceToolStripMenuItem.Name = "AddDeviceToolStripMenuItem";
            this.AddDeviceToolStripMenuItem.Size = new System.Drawing.Size(99, 22);
            this.AddDeviceToolStripMenuItem.Text = "新增设备";
            this.AddDeviceToolStripMenuItem.Click += new System.EventHandler(this.AddDeviceToolStripMenuItem_Click);
            // 
            // EditDeviceToolStripMenuItem
            // 
            this.EditDeviceToolStripMenuItem.Name = "EditDeviceToolStripMenuItem";
            this.EditDeviceToolStripMenuItem.Size = new System.Drawing.Size(99, 22);
            this.EditDeviceToolStripMenuItem.Text = "修改设备";
            this.EditDeviceToolStripMenuItem.Click += new System.EventHandler(this.EditDeviceToolStripMenuItem_Click);
            // 
            // DeleteDeviceToolStripMenuItem
            // 
            this.DeleteDeviceToolStripMenuItem.Name = "DeleteDeviceToolStripMenuItem";
            this.DeleteDeviceToolStripMenuItem.Size = new System.Drawing.Size(99, 22);
            this.DeleteDeviceToolStripMenuItem.Text = "删除设备";
            this.DeleteDeviceToolStripMenuItem.Click += new System.EventHandler(this.DeleteDeviceToolStripMenuItem_Click);
            // 
            // dgvDevice
            // 
            this.dgvDevice.AllowUserToAddRows = false;
            this.dgvDevice.AllowUserToDeleteRows = false;
            this.dgvDevice.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgvDevice.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvDevice.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDevice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDevice.Location = new System.Drawing.Point(0, 0);
            this.dgvDevice.Name = "dgvDevice";
            this.dgvDevice.ReadOnly = true;
            this.dgvDevice.RowHeadersVisible = false;
            this.dgvDevice.RowTemplate.Height = 23;
            this.dgvDevice.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDevice.Size = new System.Drawing.Size(233, 265);
            this.dgvDevice.TabIndex = 1;
            // 
            // gcUserManagement
            // 
            this.gcUserManagement.Controls.Add(this.splitContainerControl6);
            this.gcUserManagement.Location = new System.Drawing.Point(317, 12);
            this.gcUserManagement.Name = "gcUserManagement";
            this.gcUserManagement.Size = new System.Drawing.Size(99, 99);
            this.gcUserManagement.TabIndex = 8;
            this.gcUserManagement.Text = "用户管理";
            // 
            // splitContainerControl6
            // 
            this.splitContainerControl6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl6.Horizontal = false;
            this.splitContainerControl6.Location = new System.Drawing.Point(2, 23);
            this.splitContainerControl6.Name = "splitContainerControl6";
            this.splitContainerControl6.Panel1.Controls.Add(this.dataGridViewUser);
            this.splitContainerControl6.Panel1.Text = "Panel1";
            this.splitContainerControl6.Panel2.Controls.Add(this.buttonUserUpdate);
            this.splitContainerControl6.Panel2.Controls.Add(this.buttonUserDelete);
            this.splitContainerControl6.Panel2.Controls.Add(this.buttonUserAdd);
            this.splitContainerControl6.Panel2.Text = "Panel2";
            this.splitContainerControl6.Size = new System.Drawing.Size(95, 74);
            this.splitContainerControl6.SplitterPosition = 181;
            this.splitContainerControl6.TabIndex = 0;
            this.splitContainerControl6.Text = "splitContainerControl6";
            this.splitContainerControl6.Resize += new System.EventHandler(this.splitContainerControl6_Resize);
            // 
            // dataGridViewUser
            // 
            this.dataGridViewUser.AllowUserToAddRows = false;
            this.dataGridViewUser.AllowUserToDeleteRows = false;
            this.dataGridViewUser.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dataGridViewUser.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridViewUser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewUser.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewUser.Name = "dataGridViewUser";
            this.dataGridViewUser.ReadOnly = true;
            this.dataGridViewUser.RowHeadersVisible = false;
            this.dataGridViewUser.RowTemplate.Height = 23;
            this.dataGridViewUser.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewUser.Size = new System.Drawing.Size(95, 69);
            this.dataGridViewUser.TabIndex = 1;
            // 
            // buttonUserUpdate
            // 
            this.buttonUserUpdate.Location = new System.Drawing.Point(724, 9);
            this.buttonUserUpdate.Name = "buttonUserUpdate";
            this.buttonUserUpdate.Size = new System.Drawing.Size(72, 27);
            this.buttonUserUpdate.TabIndex = 2;
            this.buttonUserUpdate.Text = "更新";
            this.buttonUserUpdate.UseVisualStyleBackColor = true;
            this.buttonUserUpdate.Click += new System.EventHandler(this.buttonUserUpdate_Click);
            // 
            // buttonUserDelete
            // 
            this.buttonUserDelete.Location = new System.Drawing.Point(607, 9);
            this.buttonUserDelete.Name = "buttonUserDelete";
            this.buttonUserDelete.Size = new System.Drawing.Size(72, 27);
            this.buttonUserDelete.TabIndex = 1;
            this.buttonUserDelete.Text = "删除";
            this.buttonUserDelete.UseVisualStyleBackColor = true;
            this.buttonUserDelete.Click += new System.EventHandler(this.buttonUserDelete_Click);
            // 
            // buttonUserAdd
            // 
            this.buttonUserAdd.Location = new System.Drawing.Point(486, 9);
            this.buttonUserAdd.Name = "buttonUserAdd";
            this.buttonUserAdd.Size = new System.Drawing.Size(72, 27);
            this.buttonUserAdd.TabIndex = 0;
            this.buttonUserAdd.Text = "添加";
            this.buttonUserAdd.UseVisualStyleBackColor = true;
            this.buttonUserAdd.Click += new System.EventHandler(this.buttonUserAdd_Click);
            // 
            // gcLogManagement
            // 
            this.gcLogManagement.Controls.Add(this.splitContainerControl3);
            this.gcLogManagement.Location = new System.Drawing.Point(64, 3);
            this.gcLogManagement.Name = "gcLogManagement";
            this.gcLogManagement.Size = new System.Drawing.Size(50, 68);
            this.gcLogManagement.TabIndex = 8;
            this.gcLogManagement.Text = "日志管理";
            // 
            // splitContainerControl3
            // 
            this.splitContainerControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl3.Location = new System.Drawing.Point(2, 23);
            this.splitContainerControl3.Name = "splitContainerControl3";
            this.splitContainerControl3.Panel1.Controls.Add(this.splitContainerControl4);
            this.splitContainerControl3.Panel1.Text = "Panel1";
            this.splitContainerControl3.Panel2.Controls.Add(this.splitContainerControl5);
            this.splitContainerControl3.Panel2.Text = "Panel2";
            this.splitContainerControl3.Size = new System.Drawing.Size(46, 43);
            this.splitContainerControl3.SplitterPosition = 255;
            this.splitContainerControl3.TabIndex = 0;
            this.splitContainerControl3.Text = "splitContainerControl3";
            // 
            // splitContainerControl4
            // 
            this.splitContainerControl4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl4.Horizontal = false;
            this.splitContainerControl4.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl4.Name = "splitContainerControl4";
            this.splitContainerControl4.Panel1.Controls.Add(this.treeViewCameraInLogManagement);
            this.splitContainerControl4.Panel1.Text = "Panel1";
            this.splitContainerControl4.Panel2.Controls.Add(this.checkBoxUser);
            this.splitContainerControl4.Panel2.Text = "Panel2";
            this.splitContainerControl4.Size = new System.Drawing.Size(41, 43);
            this.splitContainerControl4.SplitterPosition = 469;
            this.splitContainerControl4.TabIndex = 0;
            this.splitContainerControl4.Text = "splitContainerControl4";
            this.splitContainerControl4.Resize += new System.EventHandler(this.splitContainerControl4_Resize);
            // 
            // treeViewCameraInLogManagement
            // 
            this.treeViewCameraInLogManagement.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewCameraInLogManagement.Location = new System.Drawing.Point(0, 0);
            this.treeViewCameraInLogManagement.Name = "treeViewCameraInLogManagement";
            this.treeViewCameraInLogManagement.Size = new System.Drawing.Size(41, 38);
            this.treeViewCameraInLogManagement.TabIndex = 1;
            this.treeViewCameraInLogManagement.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewCameraInLogManagement_AfterSelect);
            this.treeViewCameraInLogManagement.Leave += new System.EventHandler(this.treeViewCameraInLogManagement_Leave);
            // 
            // checkBoxUser
            // 
            this.checkBoxUser.AutoSize = true;
            this.checkBoxUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBoxUser.Location = new System.Drawing.Point(0, 0);
            this.checkBoxUser.Name = "checkBoxUser";
            this.checkBoxUser.Size = new System.Drawing.Size(0, 0);
            this.checkBoxUser.TabIndex = 0;
            this.checkBoxUser.Text = "按用户";
            this.checkBoxUser.UseVisualStyleBackColor = true;
            this.checkBoxUser.CheckedChanged += new System.EventHandler(this.checkBoxUser_CheckedChanged);
            // 
            // splitContainerControl5
            // 
            this.splitContainerControl5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl5.Horizontal = false;
            this.splitContainerControl5.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl5.Name = "splitContainerControl5";
            this.splitContainerControl5.Panel1.Controls.Add(this.buttonSearchLog);
            this.splitContainerControl5.Panel1.Controls.Add(this.dateEditEndDate);
            this.splitContainerControl5.Panel1.Controls.Add(this.dateEditBeginDate);
            this.splitContainerControl5.Panel1.Controls.Add(this.labelControl2);
            this.splitContainerControl5.Panel1.Controls.Add(this.labelControl4);
            this.splitContainerControl5.Panel1.Controls.Add(this.labelControl3);
            this.splitContainerControl5.Panel1.Controls.Add(this.labelControl1);
            this.splitContainerControl5.Panel1.Controls.Add(this.comboBoxEditSubLogType);
            this.splitContainerControl5.Panel1.Controls.Add(this.comboBoxEditLogType);
            this.splitContainerControl5.Panel1.Text = "Panel1";
            this.splitContainerControl5.Panel2.Controls.Add(this.dataGridViewLog);
            this.splitContainerControl5.Panel2.Text = "Panel2";
            this.splitContainerControl5.Size = new System.Drawing.Size(0, 0);
            this.splitContainerControl5.SplitterPosition = 124;
            this.splitContainerControl5.TabIndex = 0;
            this.splitContainerControl5.Text = "splitContainerControl5";
            // 
            // buttonSearchLog
            // 
            this.buttonSearchLog.Location = new System.Drawing.Point(378, 56);
            this.buttonSearchLog.Name = "buttonSearchLog";
            this.buttonSearchLog.Size = new System.Drawing.Size(106, 55);
            this.buttonSearchLog.TabIndex = 4;
            this.buttonSearchLog.Text = "查询";
            this.buttonSearchLog.UseVisualStyleBackColor = true;
            this.buttonSearchLog.Click += new System.EventHandler(this.buttonSearchLog_Click);
            // 
            // dateEditEndDate
            // 
            this.dateEditEndDate.EditValue = new System.DateTime(2010, 7, 24, 0, 0, 0, 0);
            this.dateEditEndDate.Location = new System.Drawing.Point(87, 90);
            this.dateEditEndDate.Name = "dateEditEndDate";
            this.dateEditEndDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditEndDate.Properties.DisplayFormat.FormatString = "yyyy/MM/dd HH:mm:ss";
            this.dateEditEndDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateEditEndDate.Properties.EditFormat.FormatString = "yyyy/MM/dd HH:mm:ss";
            this.dateEditEndDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateEditEndDate.Properties.Mask.EditMask = "";
            this.dateEditEndDate.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateEditEndDate.Size = new System.Drawing.Size(161, 21);
            this.dateEditEndDate.TabIndex = 2;
            // 
            // dateEditBeginDate
            // 
            this.dateEditBeginDate.EditValue = new System.DateTime(2010, 7, 24, 0, 0, 0, 0);
            this.dateEditBeginDate.Location = new System.Drawing.Point(87, 55);
            this.dateEditBeginDate.Name = "dateEditBeginDate";
            this.dateEditBeginDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditBeginDate.Properties.DisplayFormat.FormatString = "yyyy/MM/dd hh:mm:ss";
            this.dateEditBeginDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateEditBeginDate.Properties.EditFormat.FormatString = "yyyy/MM/dd hh:mm:ss";
            this.dateEditBeginDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateEditBeginDate.Properties.Mask.EditMask = "";
            this.dateEditBeginDate.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateEditBeginDate.Size = new System.Drawing.Size(161, 21);
            this.dateEditBeginDate.TabIndex = 2;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(287, 6);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(48, 14);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "子类型：";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(15, 93);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(60, 14);
            this.labelControl4.TabIndex = 1;
            this.labelControl4.Text = "结束时间：";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(15, 58);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(60, 14);
            this.labelControl3.TabIndex = 1;
            this.labelControl3.Text = "开始时间：";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(15, 6);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(60, 14);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "日志类型：";
            // 
            // comboBoxEditSubLogType
            // 
            this.comboBoxEditSubLogType.AllowDrop = true;
            this.comboBoxEditSubLogType.Location = new System.Drawing.Point(363, 3);
            this.comboBoxEditSubLogType.Name = "comboBoxEditSubLogType";
            this.comboBoxEditSubLogType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEditSubLogType.Size = new System.Drawing.Size(162, 21);
            this.comboBoxEditSubLogType.TabIndex = 0;
            this.comboBoxEditSubLogType.SelectedIndexChanged += new System.EventHandler(this.comboBoxEditSubLogType_SelectedIndexChanged);
            // 
            // comboBoxEditLogType
            // 
            this.comboBoxEditLogType.AllowDrop = true;
            this.comboBoxEditLogType.Location = new System.Drawing.Point(87, 3);
            this.comboBoxEditLogType.Name = "comboBoxEditLogType";
            this.comboBoxEditLogType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEditLogType.Properties.Items.AddRange(new object[] {
            "系统日志",
            "操作日志"});
            this.comboBoxEditLogType.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.comboBoxEditLogType.Size = new System.Drawing.Size(161, 21);
            this.comboBoxEditLogType.TabIndex = 0;
            this.comboBoxEditLogType.SelectedIndexChanged += new System.EventHandler(this.comboBoxEditLogType_SelectedIndexChanged);
            // 
            // dataGridViewLog
            // 
            this.dataGridViewLog.AllowUserToAddRows = false;
            this.dataGridViewLog.AllowUserToDeleteRows = false;
            this.dataGridViewLog.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dataGridViewLog.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridViewLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewLog.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewLog.Name = "dataGridViewLog";
            this.dataGridViewLog.ReadOnly = true;
            this.dataGridViewLog.RowHeadersVisible = false;
            this.dataGridViewLog.RowTemplate.Height = 23;
            this.dataGridViewLog.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewLog.Size = new System.Drawing.Size(0, 0);
            this.dataGridViewLog.TabIndex = 0;
            // 
            // gcSynGroupManagement
            // 
            this.gcSynGroupManagement.Controls.Add(this.pcSynGroupDisplay);
            this.gcSynGroupManagement.Controls.Add(this.groupControl3);
            this.gcSynGroupManagement.Controls.Add(this.splitContainerDeviceAndMonitor);
            this.gcSynGroupManagement.Location = new System.Drawing.Point(868, 7);
            this.gcSynGroupManagement.Name = "gcSynGroupManagement";
            this.gcSynGroupManagement.Size = new System.Drawing.Size(78, 64);
            this.gcSynGroupManagement.TabIndex = 8;
            this.gcSynGroupManagement.Text = "同步群组管理";
            // 
            // pcSynGroupDisplay
            // 
            this.pcSynGroupDisplay.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pcSynGroupDisplay.Controls.Add(this.lblSynCameraSplitScreenNo);
            this.pcSynGroupDisplay.Controls.Add(this.cbDisplayScreenNo);
            this.pcSynGroupDisplay.Controls.Add(this.label1);
            this.pcSynGroupDisplay.Controls.Add(this.lblGroupName);
            this.pcSynGroupDisplay.Controls.Add(this.dgvSynGroupDetail);
            this.pcSynGroupDisplay.Controls.Add(this.buttonAddSynGroup);
            this.pcSynGroupDisplay.Controls.Add(this.buttonDeleteSynGroup);
            this.pcSynGroupDisplay.Location = new System.Drawing.Point(298, 60);
            this.pcSynGroupDisplay.Name = "pcSynGroupDisplay";
            this.pcSynGroupDisplay.Size = new System.Drawing.Size(410, 306);
            this.pcSynGroupDisplay.TabIndex = 13;
            // 
            // lblSynCameraSplitScreenNo
            // 
            this.lblSynCameraSplitScreenNo.AutoSize = true;
            this.lblSynCameraSplitScreenNo.Location = new System.Drawing.Point(158, 30);
            this.lblSynCameraSplitScreenNo.Name = "lblSynCameraSplitScreenNo";
            this.lblSynCameraSplitScreenNo.Size = new System.Drawing.Size(55, 14);
            this.lblSynCameraSplitScreenNo.TabIndex = 15;
            this.lblSynCameraSplitScreenNo.Text = "分屏号：";
            // 
            // cbDisplayScreenNo
            // 
            this.cbDisplayScreenNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDisplayScreenNo.FormattingEnabled = true;
            this.cbDisplayScreenNo.Location = new System.Drawing.Point(217, 27);
            this.cbDisplayScreenNo.Name = "cbDisplayScreenNo";
            this.cbDisplayScreenNo.Size = new System.Drawing.Size(37, 22);
            this.cbDisplayScreenNo.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 158);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 14);
            this.label1.TabIndex = 13;
            this.label1.Text = "当前同步群组:";
            // 
            // lblGroupName
            // 
            this.lblGroupName.AutoSize = true;
            this.lblGroupName.Location = new System.Drawing.Point(92, 158);
            this.lblGroupName.Name = "lblGroupName";
            this.lblGroupName.Size = new System.Drawing.Size(0, 14);
            this.lblGroupName.TabIndex = 12;
            // 
            // dgvSynGroupDetail
            // 
            this.dgvSynGroupDetail.AllowUserToAddRows = false;
            this.dgvSynGroupDetail.AllowUserToDeleteRows = false;
            this.dgvSynGroupDetail.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvSynGroupDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSynGroupDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Device,
            this.Camera,
            this.Monitor,
            this.SplitScreen});
            this.dgvSynGroupDetail.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvSynGroupDetail.Location = new System.Drawing.Point(0, 182);
            this.dgvSynGroupDetail.Name = "dgvSynGroupDetail";
            this.dgvSynGroupDetail.ReadOnly = true;
            this.dgvSynGroupDetail.RowHeadersVisible = false;
            this.dgvSynGroupDetail.RowTemplate.Height = 23;
            this.dgvSynGroupDetail.Size = new System.Drawing.Size(410, 124);
            this.dgvSynGroupDetail.TabIndex = 11;
            // 
            // Device
            // 
            this.Device.HeaderText = "设备";
            this.Device.Name = "Device";
            this.Device.ReadOnly = true;
            // 
            // Camera
            // 
            this.Camera.HeaderText = "摄像头";
            this.Camera.Name = "Camera";
            this.Camera.ReadOnly = true;
            // 
            // Monitor
            // 
            this.Monitor.HeaderText = "显示通道";
            this.Monitor.Name = "Monitor";
            this.Monitor.ReadOnly = true;
            // 
            // SplitScreen
            // 
            this.SplitScreen.HeaderText = "分屏";
            this.SplitScreen.Name = "SplitScreen";
            this.SplitScreen.ReadOnly = true;
            // 
            // buttonAddSynGroup
            // 
            this.buttonAddSynGroup.Location = new System.Drawing.Point(167, 78);
            this.buttonAddSynGroup.Name = "buttonAddSynGroup";
            this.buttonAddSynGroup.Size = new System.Drawing.Size(75, 23);
            this.buttonAddSynGroup.TabIndex = 9;
            this.buttonAddSynGroup.Text = "=》";
            this.buttonAddSynGroup.UseVisualStyleBackColor = true;
            this.buttonAddSynGroup.Click += new System.EventHandler(this.buttonAddSynGroup_Click);
            // 
            // buttonDeleteSynGroup
            // 
            this.buttonDeleteSynGroup.Location = new System.Drawing.Point(167, 129);
            this.buttonDeleteSynGroup.Name = "buttonDeleteSynGroup";
            this.buttonDeleteSynGroup.Size = new System.Drawing.Size(75, 23);
            this.buttonDeleteSynGroup.TabIndex = 10;
            this.buttonDeleteSynGroup.Text = "《=";
            this.buttonDeleteSynGroup.UseVisualStyleBackColor = true;
            this.buttonDeleteSynGroup.Click += new System.EventHandler(this.buttonDeleteSynGroup_Click);
            // 
            // groupControl3
            // 
            this.groupControl3.Controls.Add(this.treeViewSynGroup);
            this.groupControl3.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupControl3.Location = new System.Drawing.Point(-194, 23);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(270, 39);
            this.groupControl3.TabIndex = 12;
            this.groupControl3.Text = "同步群组";
            // 
            // treeViewSynGroup
            // 
            this.treeViewSynGroup.ContextMenuStrip = this.contextMenuStripSynGroup;
            this.treeViewSynGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewSynGroup.Location = new System.Drawing.Point(2, 23);
            this.treeViewSynGroup.Name = "treeViewSynGroup";
            this.treeViewSynGroup.Size = new System.Drawing.Size(266, 14);
            this.treeViewSynGroup.TabIndex = 8;
            this.treeViewSynGroup.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewSynGroup_AfterSelect);
            this.treeViewSynGroup.Leave += new System.EventHandler(this.treeViewSynGroup_Leave);
            // 
            // contextMenuStripSynGroup
            // 
            this.contextMenuStripSynGroup.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemAddSynGroup,
            this.ToolStripMenuItemDeleteSynGroup});
            this.contextMenuStripSynGroup.Name = "contextMenuStripSynGroup";
            this.contextMenuStripSynGroup.ShowImageMargin = false;
            this.contextMenuStripSynGroup.Size = new System.Drawing.Size(124, 48);
            // 
            // ToolStripMenuItemAddSynGroup
            // 
            this.ToolStripMenuItemAddSynGroup.Name = "ToolStripMenuItemAddSynGroup";
            this.ToolStripMenuItemAddSynGroup.Size = new System.Drawing.Size(123, 22);
            this.ToolStripMenuItemAddSynGroup.Text = "添加同步群组";
            this.ToolStripMenuItemAddSynGroup.Click += new System.EventHandler(this.ToolStripMenuItemAddSynGroup_Click);
            // 
            // ToolStripMenuItemDeleteSynGroup
            // 
            this.ToolStripMenuItemDeleteSynGroup.Name = "ToolStripMenuItemDeleteSynGroup";
            this.ToolStripMenuItemDeleteSynGroup.Size = new System.Drawing.Size(123, 22);
            this.ToolStripMenuItemDeleteSynGroup.Text = "删除同步群组";
            this.ToolStripMenuItemDeleteSynGroup.Click += new System.EventHandler(this.ToolStripMenuItemDeleteSynGroup_Click);
            // 
            // splitContainerDeviceAndMonitor
            // 
            this.splitContainerDeviceAndMonitor.Dock = System.Windows.Forms.DockStyle.Left;
            this.splitContainerDeviceAndMonitor.Horizontal = false;
            this.splitContainerDeviceAndMonitor.Location = new System.Drawing.Point(2, 23);
            this.splitContainerDeviceAndMonitor.Name = "splitContainerDeviceAndMonitor";
            this.splitContainerDeviceAndMonitor.Panel1.Controls.Add(this.gcDevice);
            this.splitContainerDeviceAndMonitor.Panel1.Text = "Panel1";
            this.splitContainerDeviceAndMonitor.Panel2.Controls.Add(this.groupControl2);
            this.splitContainerDeviceAndMonitor.Panel2.Text = "Panel2";
            this.splitContainerDeviceAndMonitor.Size = new System.Drawing.Size(234, 39);
            this.splitContainerDeviceAndMonitor.SplitterPosition = 293;
            this.splitContainerDeviceAndMonitor.TabIndex = 11;
            this.splitContainerDeviceAndMonitor.Text = "splitContainerControl7";
            // 
            // gcDevice
            // 
            this.gcDevice.Controls.Add(this.treeViewSynGroupCamera);
            this.gcDevice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcDevice.Location = new System.Drawing.Point(0, 0);
            this.gcDevice.Name = "gcDevice";
            this.gcDevice.Size = new System.Drawing.Size(234, 34);
            this.gcDevice.TabIndex = 12;
            this.gcDevice.Text = "输入";
            // 
            // treeViewSynGroupCamera
            // 
            this.treeViewSynGroupCamera.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewSynGroupCamera.Location = new System.Drawing.Point(2, 23);
            this.treeViewSynGroupCamera.Name = "treeViewSynGroupCamera";
            this.treeViewSynGroupCamera.Size = new System.Drawing.Size(230, 9);
            this.treeViewSynGroupCamera.TabIndex = 8;
            this.treeViewSynGroupCamera.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewSynGroupCamera_AfterSelect);
            this.treeViewSynGroupCamera.Leave += new System.EventHandler(this.treeViewSynGroupCamera_Leave);
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.treeViewMonitor);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl2.Location = new System.Drawing.Point(0, 0);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(0, 0);
            this.groupControl2.TabIndex = 0;
            this.groupControl2.Text = "输出";
            // 
            // treeViewMonitor
            // 
            this.treeViewMonitor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewMonitor.Location = new System.Drawing.Point(0, 0);
            this.treeViewMonitor.Name = "treeViewMonitor";
            this.treeViewMonitor.Size = new System.Drawing.Size(0, 0);
            this.treeViewMonitor.TabIndex = 0;
            this.treeViewMonitor.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewMonitor_AfterSelect);
            this.treeViewMonitor.Leave += new System.EventHandler(this.treeViewMonitor_Leave);
            // 
            // splitContainerControl2
            // 
            this.splitContainerControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl2.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl2.Name = "splitContainerControl2";
            this.splitContainerControl2.Panel1.Controls.Add(this.navBarControl1);
            this.splitContainerControl2.Panel1.Text = "Panel1";
            this.splitContainerControl2.Panel2.Controls.Add(this.gcUserManagement);
            this.splitContainerControl2.Panel2.Controls.Add(this.DecoderManagement);
            this.splitContainerControl2.Panel2.Controls.Add(this.gcDeviceManagement);
            this.splitContainerControl2.Panel2.Controls.Add(this.gcSkin);
            this.splitContainerControl2.Panel2.Controls.Add(this.gcDisplayChannelManagement);
            this.splitContainerControl2.Panel2.Controls.Add(this.gcSynGroupManagement);
            this.splitContainerControl2.Panel2.Controls.Add(this.gcLogManagement);
            this.splitContainerControl2.Panel2.Controls.Add(this.gcProgSwitchManagement);
            this.splitContainerControl2.Panel2.Controls.Add(this.gcGroupSwitchManagement);
            this.splitContainerControl2.Panel2.Controls.Add(this.gcMap);
            this.splitContainerControl2.Panel2.Text = "Panel2";
            this.splitContainerControl2.Size = new System.Drawing.Size(1182, 575);
            this.splitContainerControl2.SplitterPosition = 128;
            this.splitContainerControl2.TabIndex = 32;
            this.splitContainerControl2.Text = "splitContainerControl2";
            this.splitContainerControl2.Resize += new System.EventHandler(this.splitContainerControl2_Resize);
            // 
            // DecoderManagement
            // 
            this.DecoderManagement.Controls.Add(this.splitContainerControl7);
            this.DecoderManagement.Location = new System.Drawing.Point(103, 225);
            this.DecoderManagement.Name = "DecoderManagement";
            this.DecoderManagement.Size = new System.Drawing.Size(173, 179);
            this.DecoderManagement.TabIndex = 34;
            this.DecoderManagement.Text = "解码器管理";
            this.DecoderManagement.Paint += new System.Windows.Forms.PaintEventHandler(this.DecoderManagement_Paint);
            // 
            // splitContainerControl7
            // 
            this.splitContainerControl7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl7.Location = new System.Drawing.Point(2, 23);
            this.splitContainerControl7.Name = "splitContainerControl7";
            this.splitContainerControl7.Panel1.Controls.Add(this.treeListShowDecoder);
            this.splitContainerControl7.Panel1.Text = "Panel1";
            this.splitContainerControl7.Panel2.Controls.Add(this.gridControl1);
            this.splitContainerControl7.Panel2.Text = "Panel2";
            this.splitContainerControl7.Size = new System.Drawing.Size(169, 154);
            this.splitContainerControl7.SplitterPosition = 158;
            this.splitContainerControl7.TabIndex = 0;
            this.splitContainerControl7.Text = "splitContainerControl7";
            // 
            // treeListShowDecoder
            // 
            this.treeListShowDecoder.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumn1,
            this.treeListColumn2});
            this.treeListShowDecoder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeListShowDecoder.Location = new System.Drawing.Point(0, 0);
            this.treeListShowDecoder.Name = "treeListShowDecoder";
            this.treeListShowDecoder.OptionsBehavior.Editable = false;
            this.treeListShowDecoder.OptionsSelection.InvertSelection = true;
            this.treeListShowDecoder.OptionsSelection.UseIndicatorForSelection = true;
            this.treeListShowDecoder.OptionsView.ShowColumns = false;
            this.treeListShowDecoder.OptionsView.ShowHorzLines = false;
            this.treeListShowDecoder.OptionsView.ShowIndicator = false;
            this.treeListShowDecoder.OptionsView.ShowVertLines = false;
            this.treeListShowDecoder.Size = new System.Drawing.Size(158, 154);
            this.treeListShowDecoder.TabIndex = 0;
            this.treeListShowDecoder.MouseUp += new System.Windows.Forms.MouseEventHandler(this.treeListShowDecoder_MouseUp);
            this.treeListShowDecoder.Click += new System.EventHandler(this.ShowDecoderAndCameraDataInGridView);
            // 
            // treeListColumn1
            // 
            this.treeListColumn1.Caption = "解码器管理";
            this.treeListColumn1.FieldName = "解码器管理";
            this.treeListColumn1.Name = "treeListColumn1";
            this.treeListColumn1.OptionsColumn.AllowEdit = false;
            this.treeListColumn1.Visible = true;
            this.treeListColumn1.VisibleIndex = 0;
            // 
            // treeListColumn2
            // 
            this.treeListColumn2.Caption = "tag";
            this.treeListColumn2.FieldName = "tag";
            this.treeListColumn2.Name = "treeListColumn2";
            this.treeListColumn2.OptionsColumn.AllowEdit = false;
            this.treeListColumn2.Visible = true;
            this.treeListColumn2.VisibleIndex = 1;
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(6, 154);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1,
            this.gridView2});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsSelection.InvertSelection = true;
            // 
            // gridView2
            // 
            this.gridView2.GridControl = this.gridControl1;
            this.gridView2.Name = "gridView2";
            // 
            // gcSkin
            // 
            this.gcSkin.Controls.Add(this.panelControl5);
            this.gcSkin.Location = new System.Drawing.Point(493, 77);
            this.gcSkin.Name = "gcSkin";
            this.gcSkin.Size = new System.Drawing.Size(153, 127);
            this.gcSkin.TabIndex = 33;
            this.gcSkin.Text = "皮肤管理";
            // 
            // panelControl5
            // 
            this.panelControl5.Controls.Add(this.labelControl7);
            this.panelControl5.Controls.Add(this.cbeChangeSkin);
            this.panelControl5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl5.Location = new System.Drawing.Point(2, 23);
            this.panelControl5.Name = "panelControl5";
            this.panelControl5.Size = new System.Drawing.Size(149, 102);
            this.panelControl5.TabIndex = 3;
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(207, 116);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(84, 14);
            this.labelControl7.TabIndex = 3;
            this.labelControl7.Text = "选择皮肤名称：";
            // 
            // cbeChangeSkin
            // 
            this.cbeChangeSkin.Location = new System.Drawing.Point(205, 136);
            this.cbeChangeSkin.Name = "cbeChangeSkin";
            this.cbeChangeSkin.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbeChangeSkin.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbeChangeSkin.Size = new System.Drawing.Size(123, 21);
            this.cbeChangeSkin.TabIndex = 2;
            this.cbeChangeSkin.SelectedIndexChanged += new System.EventHandler(this.cbeChangeSkin_SelectedIndexChanged);
            // 
            // gcDisplayChannelManagement
            // 
            this.gcDisplayChannelManagement.Controls.Add(this.dgvDisplayChannel);
            this.gcDisplayChannelManagement.Controls.Add(this.groupControl6);
            this.gcDisplayChannelManagement.Location = new System.Drawing.Point(965, 10);
            this.gcDisplayChannelManagement.Name = "gcDisplayChannelManagement";
            this.gcDisplayChannelManagement.Size = new System.Drawing.Size(81, 49);
            this.gcDisplayChannelManagement.TabIndex = 8;
            this.gcDisplayChannelManagement.Text = "输出管理";
            // 
            // dgvDisplayChannel
            // 
            this.dgvDisplayChannel.AllowUserToAddRows = false;
            this.dgvDisplayChannel.AllowUserToDeleteRows = false;
            this.dgvDisplayChannel.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvDisplayChannel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDisplayChannel.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DisplayChannelID,
            this.DisplayChannelName,
            this.DisplayChannelSplitScreenNo});
            this.dgvDisplayChannel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDisplayChannel.Location = new System.Drawing.Point(210, 23);
            this.dgvDisplayChannel.Name = "dgvDisplayChannel";
            this.dgvDisplayChannel.RowHeadersVisible = false;
            this.dgvDisplayChannel.RowTemplate.Height = 23;
            this.dgvDisplayChannel.Size = new System.Drawing.Size(0, 24);
            this.dgvDisplayChannel.TabIndex = 26;
            this.dgvDisplayChannel.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDisplayChannel_CellEndEdit);
            // 
            // DisplayChannelID
            // 
            this.DisplayChannelID.HeaderText = "Id";
            this.DisplayChannelID.Name = "DisplayChannelID";
            this.DisplayChannelID.ReadOnly = true;
            this.DisplayChannelID.Visible = false;
            // 
            // DisplayChannelName
            // 
            this.DisplayChannelName.HeaderText = "输出ID";
            this.DisplayChannelName.Name = "DisplayChannelName";
            this.DisplayChannelName.ReadOnly = true;
            // 
            // DisplayChannelSplitScreenNo
            // 
            this.DisplayChannelSplitScreenNo.HeaderText = "分屏";
            this.DisplayChannelSplitScreenNo.Items.AddRange(new object[] {
            "1",
            "4",
            "9",
            "16"});
            this.DisplayChannelSplitScreenNo.Name = "DisplayChannelSplitScreenNo";
            this.DisplayChannelSplitScreenNo.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.DisplayChannelSplitScreenNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // groupControl6
            // 
            this.groupControl6.Controls.Add(this.tvDisplayChannel);
            this.groupControl6.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupControl6.Location = new System.Drawing.Point(2, 23);
            this.groupControl6.Name = "groupControl6";
            this.groupControl6.Size = new System.Drawing.Size(208, 24);
            this.groupControl6.TabIndex = 12;
            this.groupControl6.Text = "输出";
            // 
            // tvDisplayChannel
            // 
            this.tvDisplayChannel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvDisplayChannel.Location = new System.Drawing.Point(2, 23);
            this.tvDisplayChannel.Name = "tvDisplayChannel";
            this.tvDisplayChannel.Size = new System.Drawing.Size(204, 0);
            this.tvDisplayChannel.TabIndex = 8;
            this.tvDisplayChannel.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvDisplayChannel_AfterSelect);
            this.tvDisplayChannel.Leave += new System.EventHandler(this.tvDisplayChannel_Leave);
            // 
            // gcProgSwitchManagement
            // 
            this.gcProgSwitchManagement.Controls.Add(this.pcProgSwitchDisplay);
            this.gcProgSwitchManagement.Controls.Add(this.gcDeviceInProSwitchManagement);
            this.gcProgSwitchManagement.Controls.Add(this.groupControl5);
            this.gcProgSwitchManagement.Location = new System.Drawing.Point(880, 89);
            this.gcProgSwitchManagement.Name = "gcProgSwitchManagement";
            this.gcProgSwitchManagement.Size = new System.Drawing.Size(62, 48);
            this.gcProgSwitchManagement.TabIndex = 14;
            this.gcProgSwitchManagement.Text = "程序切换管理";
            this.gcProgSwitchManagement.Resize += new System.EventHandler(this.gcProgSwitchManagement_Resize);
            // 
            // pcProgSwitchDisplay
            // 
            this.pcProgSwitchDisplay.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pcProgSwitchDisplay.Controls.Add(this.btnDeleteProgSwitchDetail);
            this.pcProgSwitchDisplay.Controls.Add(this.btnAddProgSwitchDetail);
            this.pcProgSwitchDisplay.Controls.Add(this.lblProgSwitchName);
            this.pcProgSwitchDisplay.Controls.Add(this.pcTickTimeInProgSwitch);
            this.pcProgSwitchDisplay.Controls.Add(this.dgvProgSwitchDetail);
            this.pcProgSwitchDisplay.Controls.Add(this.label3);
            this.pcProgSwitchDisplay.Location = new System.Drawing.Point(325, 89);
            this.pcProgSwitchDisplay.Name = "pcProgSwitchDisplay";
            this.pcProgSwitchDisplay.Size = new System.Drawing.Size(386, 322);
            this.pcProgSwitchDisplay.TabIndex = 27;
            // 
            // btnDeleteProgSwitchDetail
            // 
            this.btnDeleteProgSwitchDetail.Location = new System.Drawing.Point(162, 124);
            this.btnDeleteProgSwitchDetail.Name = "btnDeleteProgSwitchDetail";
            this.btnDeleteProgSwitchDetail.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteProgSwitchDetail.TabIndex = 23;
            this.btnDeleteProgSwitchDetail.Text = "《=";
            this.btnDeleteProgSwitchDetail.UseVisualStyleBackColor = true;
            this.btnDeleteProgSwitchDetail.Click += new System.EventHandler(this.btnDeleteProgSwitchDetail_Click);
            // 
            // btnAddProgSwitchDetail
            // 
            this.btnAddProgSwitchDetail.Location = new System.Drawing.Point(162, 79);
            this.btnAddProgSwitchDetail.Name = "btnAddProgSwitchDetail";
            this.btnAddProgSwitchDetail.Size = new System.Drawing.Size(75, 23);
            this.btnAddProgSwitchDetail.TabIndex = 22;
            this.btnAddProgSwitchDetail.Text = "=》";
            this.btnAddProgSwitchDetail.UseVisualStyleBackColor = true;
            this.btnAddProgSwitchDetail.Click += new System.EventHandler(this.btnAddProgSwitchDetail_Click);
            // 
            // lblProgSwitchName
            // 
            this.lblProgSwitchName.AutoSize = true;
            this.lblProgSwitchName.Location = new System.Drawing.Point(89, 163);
            this.lblProgSwitchName.Name = "lblProgSwitchName";
            this.lblProgSwitchName.Size = new System.Drawing.Size(0, 14);
            this.lblProgSwitchName.TabIndex = 27;
            // 
            // pcTickTimeInProgSwitch
            // 
            this.pcTickTimeInProgSwitch.Controls.Add(this.labelControl6);
            this.pcTickTimeInProgSwitch.Controls.Add(this.teTickTimeInProgSwitch);
            this.pcTickTimeInProgSwitch.Location = new System.Drawing.Point(138, 36);
            this.pcTickTimeInProgSwitch.Name = "pcTickTimeInProgSwitch";
            this.pcTickTimeInProgSwitch.Size = new System.Drawing.Size(127, 27);
            this.pcTickTimeInProgSwitch.TabIndex = 24;
            // 
            // labelControl6
            // 
            this.labelControl6.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelControl6.Location = new System.Drawing.Point(2, 2);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(74, 23);
            this.labelControl6.TabIndex = 18;
            this.labelControl6.Text = "时间间隔(秒):";
            // 
            // teTickTimeInProgSwitch
            // 
            this.teTickTimeInProgSwitch.Dock = System.Windows.Forms.DockStyle.Right;
            this.teTickTimeInProgSwitch.EditValue = "30";
            this.teTickTimeInProgSwitch.Location = new System.Drawing.Point(87, 2);
            this.teTickTimeInProgSwitch.Name = "teTickTimeInProgSwitch";
            this.teTickTimeInProgSwitch.Size = new System.Drawing.Size(38, 21);
            this.teTickTimeInProgSwitch.TabIndex = 17;
            // 
            // dgvProgSwitchDetail
            // 
            this.dgvProgSwitchDetail.AllowUserToAddRows = false;
            this.dgvProgSwitchDetail.AllowUserToDeleteRows = false;
            this.dgvProgSwitchDetail.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvProgSwitchDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProgSwitchDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ProgSwitchDetailId,
            this.ProgSwitchDevice,
            this.ProgSwitchCamera,
            this.ProgSwitchTick,
            this.ProgSwitchMonitor,
            this.ProgSwitchDisplaySplitScreenNo});
            this.dgvProgSwitchDetail.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvProgSwitchDetail.Location = new System.Drawing.Point(0, 187);
            this.dgvProgSwitchDetail.Name = "dgvProgSwitchDetail";
            this.dgvProgSwitchDetail.RowHeadersVisible = false;
            this.dgvProgSwitchDetail.RowTemplate.Height = 23;
            this.dgvProgSwitchDetail.Size = new System.Drawing.Size(386, 135);
            this.dgvProgSwitchDetail.TabIndex = 25;
            this.dgvProgSwitchDetail.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProgSwitchDetail_CellEndEdit);
            // 
            // ProgSwitchDetailId
            // 
            this.ProgSwitchDetailId.HeaderText = "Id";
            this.ProgSwitchDetailId.Name = "ProgSwitchDetailId";
            this.ProgSwitchDetailId.Visible = false;
            // 
            // ProgSwitchDevice
            // 
            this.ProgSwitchDevice.HeaderText = "设备";
            this.ProgSwitchDevice.Name = "ProgSwitchDevice";
            this.ProgSwitchDevice.ReadOnly = true;
            // 
            // ProgSwitchCamera
            // 
            this.ProgSwitchCamera.HeaderText = "摄像机";
            this.ProgSwitchCamera.Name = "ProgSwitchCamera";
            this.ProgSwitchCamera.ReadOnly = true;
            // 
            // ProgSwitchTick
            // 
            this.ProgSwitchTick.HeaderText = "时间间隔(秒)";
            this.ProgSwitchTick.Name = "ProgSwitchTick";
            // 
            // ProgSwitchMonitor
            // 
            this.ProgSwitchMonitor.HeaderText = "显示通道";
            this.ProgSwitchMonitor.Name = "ProgSwitchMonitor";
            this.ProgSwitchMonitor.ReadOnly = true;
            // 
            // ProgSwitchDisplaySplitScreenNo
            // 
            this.ProgSwitchDisplaySplitScreenNo.HeaderText = "分屏";
            this.ProgSwitchDisplaySplitScreenNo.Name = "ProgSwitchDisplaySplitScreenNo";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(0, 163);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 14);
            this.label3.TabIndex = 26;
            this.label3.Text = "当前程序切换:";
            // 
            // gcDeviceInProSwitchManagement
            // 
            this.gcDeviceInProSwitchManagement.Dock = System.Windows.Forms.DockStyle.Left;
            this.gcDeviceInProSwitchManagement.Location = new System.Drawing.Point(2, 23);
            this.gcDeviceInProSwitchManagement.Name = "gcDeviceInProSwitchManagement";
            this.gcDeviceInProSwitchManagement.Size = new System.Drawing.Size(237, 23);
            this.gcDeviceInProSwitchManagement.TabIndex = 21;
            this.gcDeviceInProSwitchManagement.Text = "设备";
            // 
            // groupControl5
            // 
            this.groupControl5.Controls.Add(this.tvProgSwitch);
            this.groupControl5.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupControl5.Location = new System.Drawing.Point(-158, 23);
            this.groupControl5.Name = "groupControl5";
            this.groupControl5.Size = new System.Drawing.Size(218, 23);
            this.groupControl5.TabIndex = 20;
            this.groupControl5.Text = "程序切换";
            // 
            // tvProgSwitch
            // 
            this.tvProgSwitch.ContextMenuStrip = this.cmAddProgSwitch;
            this.tvProgSwitch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvProgSwitch.Location = new System.Drawing.Point(2, 23);
            this.tvProgSwitch.Name = "tvProgSwitch";
            this.tvProgSwitch.Size = new System.Drawing.Size(214, 0);
            this.tvProgSwitch.TabIndex = 8;
            this.tvProgSwitch.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvProgSwitch_AfterSelect);
            this.tvProgSwitch.Leave += new System.EventHandler(this.tvProgSwitch_Leave);
            // 
            // cmAddProgSwitch
            // 
            this.cmAddProgSwitch.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.cmAddProgSwitch.Name = "cmAddGroupSwitchGroup";
            this.cmAddProgSwitch.ShowImageMargin = false;
            this.cmAddProgSwitch.Size = new System.Drawing.Size(124, 26);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(123, 22);
            this.toolStripMenuItem1.Text = "添加程序切换";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // gcGroupSwitchManagement
            // 
            this.gcGroupSwitchManagement.Controls.Add(this.pcGroupSwitchDisplay);
            this.gcGroupSwitchManagement.Controls.Add(this.gcSynGroup);
            this.gcGroupSwitchManagement.Controls.Add(this.gcGroupSwitchGroup);
            this.gcGroupSwitchManagement.Location = new System.Drawing.Point(961, 70);
            this.gcGroupSwitchManagement.Name = "gcGroupSwitchManagement";
            this.gcGroupSwitchManagement.Size = new System.Drawing.Size(88, 50);
            this.gcGroupSwitchManagement.TabIndex = 13;
            this.gcGroupSwitchManagement.Text = "群组切换管理";
            this.gcGroupSwitchManagement.Resize += new System.EventHandler(this.gcGroupSwitchManagement_Resize);
            // 
            // pcGroupSwitchDisplay
            // 
            this.pcGroupSwitchDisplay.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pcGroupSwitchDisplay.Controls.Add(this.btnDeleteGroupSwitchDetail);
            this.pcGroupSwitchDisplay.Controls.Add(this.btnAddGroupSwitchDetail);
            this.pcGroupSwitchDisplay.Controls.Add(this.lblGroupSwitchName);
            this.pcGroupSwitchDisplay.Controls.Add(this.pcTickTime);
            this.pcGroupSwitchDisplay.Controls.Add(this.dgvGroupSwitchDetail);
            this.pcGroupSwitchDisplay.Controls.Add(this.label2);
            this.pcGroupSwitchDisplay.Location = new System.Drawing.Point(267, 82);
            this.pcGroupSwitchDisplay.Name = "pcGroupSwitchDisplay";
            this.pcGroupSwitchDisplay.Size = new System.Drawing.Size(349, 299);
            this.pcGroupSwitchDisplay.TabIndex = 22;
            // 
            // btnDeleteGroupSwitchDetail
            // 
            this.btnDeleteGroupSwitchDetail.Location = new System.Drawing.Point(138, 108);
            this.btnDeleteGroupSwitchDetail.Name = "btnDeleteGroupSwitchDetail";
            this.btnDeleteGroupSwitchDetail.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteGroupSwitchDetail.TabIndex = 16;
            this.btnDeleteGroupSwitchDetail.Text = "《=";
            this.btnDeleteGroupSwitchDetail.UseVisualStyleBackColor = true;
            this.btnDeleteGroupSwitchDetail.Click += new System.EventHandler(this.btnDeleteGroupSwitchDetail_Click);
            // 
            // btnAddGroupSwitchDetail
            // 
            this.btnAddGroupSwitchDetail.Location = new System.Drawing.Point(138, 57);
            this.btnAddGroupSwitchDetail.Name = "btnAddGroupSwitchDetail";
            this.btnAddGroupSwitchDetail.Size = new System.Drawing.Size(75, 23);
            this.btnAddGroupSwitchDetail.TabIndex = 15;
            this.btnAddGroupSwitchDetail.Text = "=》";
            this.btnAddGroupSwitchDetail.UseVisualStyleBackColor = true;
            this.btnAddGroupSwitchDetail.Click += new System.EventHandler(this.btnAddGroupSwitchDetail_Click);
            // 
            // lblGroupSwitchName
            // 
            this.lblGroupSwitchName.AutoSize = true;
            this.lblGroupSwitchName.Location = new System.Drawing.Point(92, 154);
            this.lblGroupSwitchName.Name = "lblGroupSwitchName";
            this.lblGroupSwitchName.Size = new System.Drawing.Size(0, 14);
            this.lblGroupSwitchName.TabIndex = 22;
            // 
            // pcTickTime
            // 
            this.pcTickTime.Controls.Add(this.labelControl5);
            this.pcTickTime.Controls.Add(this.teGroupSwitchTick);
            this.pcTickTime.Location = new System.Drawing.Point(113, 7);
            this.pcTickTime.Name = "pcTickTime";
            this.pcTickTime.Size = new System.Drawing.Size(127, 27);
            this.pcTickTime.TabIndex = 19;
            // 
            // labelControl5
            // 
            this.labelControl5.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelControl5.Location = new System.Drawing.Point(2, 2);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(74, 23);
            this.labelControl5.TabIndex = 18;
            this.labelControl5.Text = "时间间隔(秒):";
            // 
            // teGroupSwitchTick
            // 
            this.teGroupSwitchTick.Dock = System.Windows.Forms.DockStyle.Right;
            this.teGroupSwitchTick.EditValue = "30";
            this.teGroupSwitchTick.Location = new System.Drawing.Point(87, 2);
            this.teGroupSwitchTick.Name = "teGroupSwitchTick";
            this.teGroupSwitchTick.Size = new System.Drawing.Size(38, 21);
            this.teGroupSwitchTick.TabIndex = 17;
            // 
            // dgvGroupSwitchDetail
            // 
            this.dgvGroupSwitchDetail.AllowUserToAddRows = false;
            this.dgvGroupSwitchDetail.AllowUserToDeleteRows = false;
            this.dgvGroupSwitchDetail.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvGroupSwitchDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGroupSwitchDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.SynGroup,
            this.Tick});
            this.dgvGroupSwitchDetail.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvGroupSwitchDetail.Location = new System.Drawing.Point(0, 175);
            this.dgvGroupSwitchDetail.Name = "dgvGroupSwitchDetail";
            this.dgvGroupSwitchDetail.RowHeadersVisible = false;
            this.dgvGroupSwitchDetail.RowTemplate.Height = 23;
            this.dgvGroupSwitchDetail.Size = new System.Drawing.Size(349, 124);
            this.dgvGroupSwitchDetail.TabIndex = 20;
            this.dgvGroupSwitchDetail.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGroupSwitchDetail_CellEndEdit);
            // 
            // Id
            // 
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.Visible = false;
            // 
            // SynGroup
            // 
            this.SynGroup.HeaderText = "同步群组";
            this.SynGroup.Name = "SynGroup";
            this.SynGroup.ReadOnly = true;
            // 
            // Tick
            // 
            dataGridViewCellStyle1.Format = "N0";
            dataGridViewCellStyle1.NullValue = null;
            this.Tick.DefaultCellStyle = dataGridViewCellStyle1;
            this.Tick.HeaderText = "时间间隔(秒)";
            this.Tick.Name = "Tick";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 154);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 14);
            this.label2.TabIndex = 21;
            this.label2.Text = "当前群组切换:";
            // 
            // gcSynGroup
            // 
            this.gcSynGroup.Controls.Add(this.tvSynGroupTop);
            this.gcSynGroup.Dock = System.Windows.Forms.DockStyle.Left;
            this.gcSynGroup.Location = new System.Drawing.Point(2, 23);
            this.gcSynGroup.Name = "gcSynGroup";
            this.gcSynGroup.Size = new System.Drawing.Size(237, 25);
            this.gcSynGroup.TabIndex = 14;
            this.gcSynGroup.Text = "同步群组";
            // 
            // tvSynGroupTop
            // 
            this.tvSynGroupTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvSynGroupTop.Location = new System.Drawing.Point(2, 23);
            this.tvSynGroupTop.Name = "tvSynGroupTop";
            this.tvSynGroupTop.Size = new System.Drawing.Size(233, 0);
            this.tvSynGroupTop.TabIndex = 8;
            this.tvSynGroupTop.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvSynGroupTop_AfterSelect);
            this.tvSynGroupTop.Leave += new System.EventHandler(this.tvSynGroupTop_Leave);
            // 
            // gcGroupSwitchGroup
            // 
            this.gcGroupSwitchGroup.Controls.Add(this.tvGroupSwitchGroup);
            this.gcGroupSwitchGroup.Dock = System.Windows.Forms.DockStyle.Right;
            this.gcGroupSwitchGroup.Location = new System.Drawing.Point(-132, 23);
            this.gcGroupSwitchGroup.Name = "gcGroupSwitchGroup";
            this.gcGroupSwitchGroup.Size = new System.Drawing.Size(218, 25);
            this.gcGroupSwitchGroup.TabIndex = 13;
            this.gcGroupSwitchGroup.Text = "群组切换";
            // 
            // tvGroupSwitchGroup
            // 
            this.tvGroupSwitchGroup.ContextMenuStrip = this.cmAddGroupSwitchGroup;
            this.tvGroupSwitchGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvGroupSwitchGroup.Location = new System.Drawing.Point(2, 23);
            this.tvGroupSwitchGroup.Name = "tvGroupSwitchGroup";
            this.tvGroupSwitchGroup.Size = new System.Drawing.Size(214, 0);
            this.tvGroupSwitchGroup.TabIndex = 8;
            this.tvGroupSwitchGroup.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvGroupSwitchGroup_AfterSelect);
            this.tvGroupSwitchGroup.Leave += new System.EventHandler(this.tvGroupSwitchGroup_Leave);
            // 
            // cmAddGroupSwitchGroup
            // 
            this.cmAddGroupSwitchGroup.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.添加群组切换ToolStripMenuItem});
            this.cmAddGroupSwitchGroup.Name = "cmAddGroupSwitchGroup";
            this.cmAddGroupSwitchGroup.ShowImageMargin = false;
            this.cmAddGroupSwitchGroup.Size = new System.Drawing.Size(124, 26);
            // 
            // 添加群组切换ToolStripMenuItem
            // 
            this.添加群组切换ToolStripMenuItem.Name = "添加群组切换ToolStripMenuItem";
            this.添加群组切换ToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.添加群组切换ToolStripMenuItem.Text = "添加群组切换";
            this.添加群组切换ToolStripMenuItem.Click += new System.EventHandler(this.添加群组切换ToolStripMenuItem_Click);
            // 
            // gcMap
            // 
            this.gcMap.Controls.Add(this.pcMapPreview);
            this.gcMap.Controls.Add(this.panelControl1);
            this.gcMap.Controls.Add(this.pcMapTreeview);
            this.gcMap.Location = new System.Drawing.Point(66, 79);
            this.gcMap.Name = "gcMap";
            this.gcMap.Size = new System.Drawing.Size(248, 123);
            this.gcMap.TabIndex = 32;
            this.gcMap.Text = "地图管理";
            // 
            // pcMapPreview
            // 
            this.pcMapPreview.Controls.Add(this.pictureBoxMap);
            this.pcMapPreview.Controls.Add(this.panelControl2);
            this.pcMapPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcMapPreview.Location = new System.Drawing.Point(188, 23);
            this.pcMapPreview.Name = "pcMapPreview";
            this.pcMapPreview.Size = new System.Drawing.Size(58, 98);
            this.pcMapPreview.TabIndex = 1;
            // 
            // pictureBoxMap
            // 
            this.pictureBoxMap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxMap.Location = new System.Drawing.Point(2, 2);
            this.pictureBoxMap.Name = "pictureBoxMap";
            this.pictureBoxMap.Size = new System.Drawing.Size(54, 69);
            this.pictureBoxMap.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxMap.TabIndex = 4;
            this.pictureBoxMap.TabStop = false;
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.btnBrowserMap);
            this.panelControl2.Controls.Add(this.btnAddMap);
            this.panelControl2.Controls.Add(this.teMapName);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl2.Location = new System.Drawing.Point(2, 71);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(54, 25);
            this.panelControl2.TabIndex = 3;
            // 
            // btnBrowserMap
            // 
            this.btnBrowserMap.Location = new System.Drawing.Point(5, 2);
            this.btnBrowserMap.Name = "btnBrowserMap";
            this.btnBrowserMap.Size = new System.Drawing.Size(75, 23);
            this.btnBrowserMap.TabIndex = 3;
            this.btnBrowserMap.Text = "浏览...";
            this.btnBrowserMap.UseVisualStyleBackColor = true;
            this.btnBrowserMap.Click += new System.EventHandler(this.btnBrowserMap_Click);
            // 
            // btnAddMap
            // 
            this.btnAddMap.Location = new System.Drawing.Point(226, 2);
            this.btnAddMap.Name = "btnAddMap";
            this.btnAddMap.Size = new System.Drawing.Size(75, 23);
            this.btnAddMap.TabIndex = 2;
            this.btnAddMap.Text = "添加地图";
            this.btnAddMap.UseVisualStyleBackColor = true;
            this.btnAddMap.Click += new System.EventHandler(this.btnAddMap_Click);
            // 
            // teMapName
            // 
            this.teMapName.Location = new System.Drawing.Point(108, 3);
            this.teMapName.Name = "teMapName";
            this.teMapName.Size = new System.Drawing.Size(100, 21);
            this.teMapName.TabIndex = 1;
            // 
            // panelControl1
            // 
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(188, 23);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(58, 98);
            this.panelControl1.TabIndex = 3;
            // 
            // pcMapTreeview
            // 
            this.pcMapTreeview.Controls.Add(this.tvMap);
            this.pcMapTreeview.Dock = System.Windows.Forms.DockStyle.Left;
            this.pcMapTreeview.Location = new System.Drawing.Point(2, 23);
            this.pcMapTreeview.Name = "pcMapTreeview";
            this.pcMapTreeview.Size = new System.Drawing.Size(186, 98);
            this.pcMapTreeview.TabIndex = 0;
            // 
            // tvMap
            // 
            this.tvMap.ContextMenuStrip = this.cmDeleteMap;
            this.tvMap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvMap.Location = new System.Drawing.Point(2, 2);
            this.tvMap.Name = "tvMap";
            this.tvMap.Size = new System.Drawing.Size(182, 94);
            this.tvMap.TabIndex = 0;
            this.tvMap.DoubleClick += new System.EventHandler(this.tvMap_DoubleClick);
            // 
            // cmDeleteMap
            // 
            this.cmDeleteMap.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.删除ToolStripMenuItem});
            this.cmDeleteMap.Name = "cmDeleteMap";
            this.cmDeleteMap.ShowImageMargin = false;
            this.cmDeleteMap.Size = new System.Drawing.Size(76, 26);
            // 
            // 删除ToolStripMenuItem
            // 
            this.删除ToolStripMenuItem.Name = "删除ToolStripMenuItem";
            this.删除ToolStripMenuItem.Size = new System.Drawing.Size(75, 22);
            this.删除ToolStripMenuItem.Text = "删除";
            this.删除ToolStripMenuItem.Click += new System.EventHandler(this.删除ToolStripMenuItem_Click);
            // 
            // openMapFileDialog
            // 
            this.openMapFileDialog.FileName = "openFileDialog1";
            this.openMapFileDialog.Filter = "“JPEG文件(*.jpg)|*.jpg|BMP文件(*.bmp)|*.bmp”";
            // 
            // barManager1
            // 
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barButtonItem1AddDecoder,
            this.barButtonItem2EditDecoder,
            this.barButtonItem3,
            this.barButtonItem4AddCamera,
            this.barButtonItem5EditDecoder,
            this.barButtonItem6DeleteDecoder,
            this.barButtonItemDeleteCamera});
            this.barManager1.MaxItemId = 7;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(1182, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 575);
            this.barDockControlBottom.Size = new System.Drawing.Size(1182, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 575);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1182, 0);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 575);
            // 
            // barButtonItem1AddDecoder
            // 
            this.barButtonItem1AddDecoder.Caption = "添加解码器";
            this.barButtonItem1AddDecoder.Id = 0;
            this.barButtonItem1AddDecoder.Name = "barButtonItem1AddDecoder";
            this.barButtonItem1AddDecoder.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem1AddDecoder_ItemClick);
            // 
            // barButtonItem2EditDecoder
            // 
            this.barButtonItem2EditDecoder.Caption = "修改解码器";
            this.barButtonItem2EditDecoder.Id = 1;
            this.barButtonItem2EditDecoder.Name = "barButtonItem2EditDecoder";
            this.barButtonItem2EditDecoder.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem2EditDecoder_ItemClick);
            // 
            // barButtonItem3
            // 
            this.barButtonItem3.Caption = "删除解码器";
            this.barButtonItem3.Id = 2;
            this.barButtonItem3.Name = "barButtonItem3";
            // 
            // barButtonItem4AddCamera
            // 
            this.barButtonItem4AddCamera.Caption = "添加摄像头";
            this.barButtonItem4AddCamera.Id = 3;
            this.barButtonItem4AddCamera.Name = "barButtonItem4AddCamera";
            this.barButtonItem4AddCamera.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem4AddCamera_ItemClick);
            // 
            // barButtonItem5EditDecoder
            // 
            this.barButtonItem5EditDecoder.Caption = "修改解码器";
            this.barButtonItem5EditDecoder.Id = 4;
            this.barButtonItem5EditDecoder.Name = "barButtonItem5EditDecoder";
            this.barButtonItem5EditDecoder.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem5EditDecoder_ItemClick);
            // 
            // barButtonItem6DeleteDecoder
            // 
            this.barButtonItem6DeleteDecoder.Caption = "删除解码器";
            this.barButtonItem6DeleteDecoder.Id = 5;
            this.barButtonItem6DeleteDecoder.Name = "barButtonItem6DeleteDecoder";
            this.barButtonItem6DeleteDecoder.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem6DeleteDecoder_ItemClick);
            // 
            // barButtonItemDeleteCamera
            // 
            this.barButtonItemDeleteCamera.Caption = "删除摄像头";
            this.barButtonItemDeleteCamera.Id = 6;
            this.barButtonItemDeleteCamera.Name = "barButtonItemDeleteCamera";
            this.barButtonItemDeleteCamera.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemDeleteCamera_ItemClick);
            // 
            // popupMenuDecoder
            // 
            this.popupMenuDecoder.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem1AddDecoder)});
            this.popupMenuDecoder.Manager = this.barManager1;
            this.popupMenuDecoder.Name = "popupMenuDecoder";
            // 
            // popupMenuCamera
            // 
            this.popupMenuCamera.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem4AddCamera),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem5EditDecoder),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem6DeleteDecoder)});
            this.popupMenuCamera.Manager = this.barManager1;
            this.popupMenuCamera.Name = "popupMenuCamera";
            // 
            // popupMenu1
            // 
            this.popupMenu1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItemDeleteCamera)});
            this.popupMenu1.Manager = this.barManager1;
            this.popupMenu1.Name = "popupMenu1";
            // 
            // frmSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1182, 575);
            this.Controls.Add(this.splitContainerControl2);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmSetting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "系统配置";
            this.Load += new System.EventHandler(this.frmSetting_Load);
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcDeviceManagement)).EndInit();
            this.gcDeviceManagement.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            this.contextMenuStripGroupAndDevice.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDevice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcUserManagement)).EndInit();
            this.gcUserManagement.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl6)).EndInit();
            this.splitContainerControl6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcLogManagement)).EndInit();
            this.gcLogManagement.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl3)).EndInit();
            this.splitContainerControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl4)).EndInit();
            this.splitContainerControl4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl5)).EndInit();
            this.splitContainerControl5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dateEditEndDate.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditEndDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditBeginDate.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditBeginDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditSubLogType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditLogType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLog)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcSynGroupManagement)).EndInit();
            this.gcSynGroupManagement.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pcSynGroupDisplay)).EndInit();
            this.pcSynGroupDisplay.ResumeLayout(false);
            this.pcSynGroupDisplay.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSynGroupDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            this.contextMenuStripSynGroup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerDeviceAndMonitor)).EndInit();
            this.splitContainerDeviceAndMonitor.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcDevice)).EndInit();
            this.gcDevice.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2)).EndInit();
            this.splitContainerControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DecoderManagement)).EndInit();
            this.DecoderManagement.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl7)).EndInit();
            this.splitContainerControl7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeListShowDecoder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcSkin)).EndInit();
            this.gcSkin.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl5)).EndInit();
            this.panelControl5.ResumeLayout(false);
            this.panelControl5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbeChangeSkin.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcDisplayChannelManagement)).EndInit();
            this.gcDisplayChannelManagement.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDisplayChannel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl6)).EndInit();
            this.groupControl6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcProgSwitchManagement)).EndInit();
            this.gcProgSwitchManagement.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pcProgSwitchDisplay)).EndInit();
            this.pcProgSwitchDisplay.ResumeLayout(false);
            this.pcProgSwitchDisplay.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcTickTimeInProgSwitch)).EndInit();
            this.pcTickTimeInProgSwitch.ResumeLayout(false);
            this.pcTickTimeInProgSwitch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.teTickTimeInProgSwitch.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProgSwitchDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcDeviceInProSwitchManagement)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl5)).EndInit();
            this.groupControl5.ResumeLayout(false);
            this.cmAddProgSwitch.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcGroupSwitchManagement)).EndInit();
            this.gcGroupSwitchManagement.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pcGroupSwitchDisplay)).EndInit();
            this.pcGroupSwitchDisplay.ResumeLayout(false);
            this.pcGroupSwitchDisplay.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcTickTime)).EndInit();
            this.pcTickTime.ResumeLayout(false);
            this.pcTickTime.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.teGroupSwitchTick.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGroupSwitchDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcSynGroup)).EndInit();
            this.gcSynGroup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcGroupSwitchGroup)).EndInit();
            this.gcGroupSwitchGroup.ResumeLayout(false);
            this.cmAddGroupSwitchGroup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcMap)).EndInit();
            this.gcMap.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pcMapPreview)).EndInit();
            this.pcMapPreview.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.teMapName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcMapTreeview)).EndInit();
            this.pcMapTreeview.ResumeLayout(false);
            this.cmDeleteMap.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenuDecoder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenuCamera)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.Bar bar1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ImageList imageList2;
        private DevExpress.XtraNavBar.NavBarControl navBarControl1;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroup1;
        private DevExpress.XtraNavBar.NavBarItem nbDevice;
        private DevExpress.XtraNavBar.NavBarItem nbUser;
        private DevExpress.XtraNavBar.NavBarItem nbLog;
        private DevExpress.XtraNavBar.NavBarItem navBarItem6;
        private DevExpress.XtraNavBar.NavBarItem navBarItem7;
        private DevExpress.XtraEditors.GroupControl gcDeviceManagement;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripGroupAndDevice;
        private System.Windows.Forms.ToolStripMenuItem AddGroupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem EditGroupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DeleteGroupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AddDeviceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem EditDeviceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DeleteDeviceToolStripMenuItem;
        private System.Windows.Forms.TreeView treeViewDevice;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripSynGroup;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemAddSynGroup;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemDeleteSynGroup;
        private System.Windows.Forms.Button buttonDeleteSynGroup;
        private System.Windows.Forms.Button buttonAddSynGroup;
        private System.Windows.Forms.TreeView treeViewSynGroup;
        private DevExpress.XtraEditors.GroupControl gcSynGroupManagement;
        private System.Windows.Forms.TreeView treeViewSynGroupCamera;
        private DevExpress.XtraEditors.GroupControl gcUserManagement;
        private DevExpress.XtraEditors.GroupControl gcLogManagement;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl2;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl3;
        private System.Windows.Forms.TreeView treeViewCameraInLogManagement;
        private System.Windows.Forms.CheckBox checkBoxUser;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl4;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl5;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxEditLogType;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxEditSubLogType;
        private System.Windows.Forms.Button buttonSearchLog;
        private DevExpress.XtraEditors.DateEdit dateEditEndDate;
        private DevExpress.XtraEditors.DateEdit dateEditBeginDate;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private System.Windows.Forms.DataGridView dataGridViewLog;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl6;
        private System.Windows.Forms.DataGridView dataGridViewUser;
        private System.Windows.Forms.Button buttonUserAdd;
        private System.Windows.Forms.Button buttonUserUpdate;
        private System.Windows.Forms.Button buttonUserDelete;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerDeviceAndMonitor;
        private System.Windows.Forms.TreeView treeViewMonitor;
        private DevExpress.XtraEditors.GroupControl gcDevice;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        private DevExpress.XtraEditors.GroupControl gcGroupSwitchManagement;
        private DevExpress.XtraEditors.GroupControl gcProgSwitchManagement;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.TextEdit teGroupSwitchTick;
        private System.Windows.Forms.Button btnDeleteGroupSwitchDetail;
        private System.Windows.Forms.Button btnAddGroupSwitchDetail;
        private DevExpress.XtraEditors.GroupControl gcSynGroup;
        private System.Windows.Forms.TreeView tvSynGroupTop;
        private DevExpress.XtraEditors.GroupControl gcGroupSwitchGroup;
        private System.Windows.Forms.TreeView tvGroupSwitchGroup;
        private DevExpress.XtraEditors.PanelControl pcTickTime;
        private System.Windows.Forms.ContextMenuStrip cmAddGroupSwitchGroup;
        private System.Windows.Forms.ToolStripMenuItem 添加群组切换ToolStripMenuItem;
        private DevExpress.XtraEditors.PanelControl pcTickTimeInProgSwitch;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.TextEdit teTickTimeInProgSwitch;
        private System.Windows.Forms.Button btnDeleteProgSwitchDetail;
        private System.Windows.Forms.Button btnAddProgSwitchDetail;
        private DevExpress.XtraEditors.GroupControl gcDeviceInProSwitchManagement;
        private DevExpress.XtraEditors.GroupControl groupControl5;
        private System.Windows.Forms.TreeView tvProgSwitch;
        private System.Windows.Forms.ContextMenuStrip cmAddProgSwitch;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private DevExpress.XtraEditors.PanelControl pcSynGroupDisplay;
        private System.Windows.Forms.Label lblGroupName;
        private System.Windows.Forms.DataGridView dgvSynGroupDetail;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvGroupSwitchDetail;
        private DevExpress.XtraEditors.PanelControl pcGroupSwitchDisplay;
        private System.Windows.Forms.Label lblGroupSwitchName;
        private DevExpress.XtraEditors.PanelControl pcProgSwitchDisplay;
        private System.Windows.Forms.Label lblProgSwitchName;
        private System.Windows.Forms.DataGridView dgvProgSwitchDetail;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvDevice;
        private DevExpress.XtraEditors.GroupControl gcDisplayChannelManagement;
        private DevExpress.XtraEditors.GroupControl groupControl6;
        private System.Windows.Forms.TreeView tvDisplayChannel;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn SynGroup;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tick;
        private System.Windows.Forms.DataGridView dgvDisplayChannel;
        private System.Windows.Forms.DataGridViewTextBoxColumn DisplayChannelID;
        private System.Windows.Forms.DataGridViewTextBoxColumn DisplayChannelName;
        private System.Windows.Forms.DataGridViewComboBoxColumn DisplayChannelSplitScreenNo;
        private System.Windows.Forms.Label lblSynCameraSplitScreenNo;
        private System.Windows.Forms.ComboBox cbDisplayScreenNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Device;
        private System.Windows.Forms.DataGridViewTextBoxColumn Camera;
        private System.Windows.Forms.DataGridViewTextBoxColumn Monitor;
        private System.Windows.Forms.DataGridViewTextBoxColumn SplitScreen;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProgSwitchDetailId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProgSwitchDevice;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProgSwitchCamera;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProgSwitchTick;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProgSwitchMonitor;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProgSwitchDisplaySplitScreenNo;
        private DevExpress.XtraNavBar.NavBarItem nbMap;
        private DevExpress.XtraEditors.GroupControl gcMap;
        private DevExpress.XtraEditors.PanelControl pcMapPreview;
        private DevExpress.XtraEditors.PanelControl pcMapTreeview;
        private System.Windows.Forms.Button btnAddMap;
        private DevExpress.XtraEditors.TextEdit teMapName;
        private System.Windows.Forms.TreeView tvMap;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private System.Windows.Forms.Button btnBrowserMap;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.OpenFileDialog openMapFileDialog;
        private System.Windows.Forms.PictureBox pictureBoxMap;
        private System.Windows.Forms.ContextMenuStrip cmDeleteMap;
        private System.Windows.Forms.ToolStripMenuItem 删除ToolStripMenuItem;
        private DevExpress.XtraNavBar.NavBarItem navBarItem1;
        private DevExpress.XtraEditors.GroupControl gcSkin;
        private DevExpress.XtraEditors.PanelControl panelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.ComboBoxEdit cbeChangeSkin;
        private DevExpress.XtraNavBar.NavBarItem navBarItem2;
        private DevExpress.XtraEditors.GroupControl DecoderManagement;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl7;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraTreeList.TreeList treeListShowDecoder;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn2;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1AddDecoder;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2EditDecoder;
        private DevExpress.XtraBars.BarButtonItem barButtonItem3;
        private DevExpress.XtraBars.PopupMenu popupMenuDecoder;
        private DevExpress.XtraBars.PopupMenu popupMenuCamera;
        private DevExpress.XtraBars.BarButtonItem barButtonItem4AddCamera;
        private DevExpress.XtraBars.BarButtonItem barButtonItem5EditDecoder;
        private DevExpress.XtraBars.BarButtonItem barButtonItem6DeleteDecoder;
        private DevExpress.XtraBars.BarButtonItem barButtonItemDeleteCamera;
        private DevExpress.XtraBars.PopupMenu popupMenu1;
    }
}