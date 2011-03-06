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
            this.barButtonItemAlarmView = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemResultView = new DevExpress.XtraBars.BarButtonItem();
            this.barSubItemMenuQuery = new DevExpress.XtraBars.BarSubItem();
            this.barSubItem1 = new DevExpress.XtraBars.BarSubItem();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            this.bar4 = new DevExpress.XtraBars.Bar();
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
            this.cameraView1 = new CameraViewer.Controls.CameraView();
            this.dockPanelAlarm = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel3_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.pcBottom = new DevExpress.XtraEditors.PanelControl();
            this.tlpBottom = new System.Windows.Forms.TableLayoutPanel();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnLinkageEnable = new System.Windows.Forms.Button();
            this.btnFortify = new System.Windows.Forms.Button();
            this.btnCancelAlarm = new System.Windows.Forms.Button();
            this.btnLinkageDisable = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.btnFortifyDisable = new System.Windows.Forms.Button();
            this.pcAlarmSwitch1 = new System.Windows.Forms.PictureBox();
            this.pcAlarmSwitch17 = new System.Windows.Forms.PictureBox();
            this.pcAlarmSwitch33 = new System.Windows.Forms.PictureBox();
            this.pcAlarmSwitch49 = new System.Windows.Forms.PictureBox();
            this.pcAlarmSwitch65 = new System.Windows.Forms.PictureBox();
            this.pcAlarmSwitch81 = new System.Windows.Forms.PictureBox();
            this.pcAlarmSwitch97 = new System.Windows.Forms.PictureBox();
            this.pcAlarmSwitch113 = new System.Windows.Forms.PictureBox();
            this.pcAlarmSwitch2 = new System.Windows.Forms.PictureBox();
            this.pcAlarmSwitch18 = new System.Windows.Forms.PictureBox();
            this.pcAlarmSwitch34 = new System.Windows.Forms.PictureBox();
            this.pcAlarmSwitch50 = new System.Windows.Forms.PictureBox();
            this.pcAlarmSwitch66 = new System.Windows.Forms.PictureBox();
            this.pcAlarmSwitch82 = new System.Windows.Forms.PictureBox();
            this.pcAlarmSwitch98 = new System.Windows.Forms.PictureBox();
            this.pcAlarmSwitch114 = new System.Windows.Forms.PictureBox();
            this.pcAlarmSwitch3 = new System.Windows.Forms.PictureBox();
            this.pcAlarmSwitch19 = new System.Windows.Forms.PictureBox();
            this.pcAlarmSwitch35 = new System.Windows.Forms.PictureBox();
            this.pcAlarmSwitch51 = new System.Windows.Forms.PictureBox();
            this.pcAlarmSwitch67 = new System.Windows.Forms.PictureBox();
            this.pcAlarmSwitch83 = new System.Windows.Forms.PictureBox();
            this.pcAlarmSwitch99 = new System.Windows.Forms.PictureBox();
            this.pcAlarmSwitch115 = new System.Windows.Forms.PictureBox();
            this.pcAlarmSwitch116 = new System.Windows.Forms.PictureBox();
            this.pcAlarmSwitch100 = new System.Windows.Forms.PictureBox();
            this.pcAlarmSwitch84 = new System.Windows.Forms.PictureBox();
            this.pcAlarmSwitch68 = new System.Windows.Forms.PictureBox();
            this.pcAlarmSwitch52 = new System.Windows.Forms.PictureBox();
            this.pcAlarmSwitch36 = new System.Windows.Forms.PictureBox();
            this.pcAlarmSwitch20 = new System.Windows.Forms.PictureBox();
            this.pcAlarmSwitch4 = new System.Windows.Forms.PictureBox();
            this.pcAlarmSwitch5 = new System.Windows.Forms.PictureBox();
            this.pcAlarmSwitch21 = new System.Windows.Forms.PictureBox();
            this.pcAlarmSwitch37 = new System.Windows.Forms.PictureBox();
            this.pcAlarmSwitch53 = new System.Windows.Forms.PictureBox();
            this.pcAlarmSwitch69 = new System.Windows.Forms.PictureBox();
            this.pcAlarmSwitch85 = new System.Windows.Forms.PictureBox();
            this.pictureBox40 = new System.Windows.Forms.PictureBox();
            this.pcAlarmSwitch117 = new System.Windows.Forms.PictureBox();
            this.pcAlarmSwitch118 = new System.Windows.Forms.PictureBox();
            this.pcAlarmSwitch102 = new System.Windows.Forms.PictureBox();
            this.pcAlarmSwitch86 = new System.Windows.Forms.PictureBox();
            this.pcAlarmSwitch70 = new System.Windows.Forms.PictureBox();
            this.pcAlarmSwitch54 = new System.Windows.Forms.PictureBox();
            this.pcAlarmSwitch38 = new System.Windows.Forms.PictureBox();
            this.pcAlarmSwitch22 = new System.Windows.Forms.PictureBox();
            this.pcAlarmSwitch6 = new System.Windows.Forms.PictureBox();
            this.pcAlarmSwitch7 = new System.Windows.Forms.PictureBox();
            this.pcAlarmSwitch23 = new System.Windows.Forms.PictureBox();
            this.pcAlarmSwitch39 = new System.Windows.Forms.PictureBox();
            this.pcAlarmSwitch55 = new System.Windows.Forms.PictureBox();
            this.pcAlarmSwitch71 = new System.Windows.Forms.PictureBox();
            this.pcAlarmSwitch87 = new System.Windows.Forms.PictureBox();
            this.pcAlarmSwitch103 = new System.Windows.Forms.PictureBox();
            this.pcAlarmSwitch119 = new System.Windows.Forms.PictureBox();
            this.pcAlarmSwitch8 = new System.Windows.Forms.PictureBox();
            this.pcAlarmSwitch24 = new System.Windows.Forms.PictureBox();
            this.pcAlarmSwitch40 = new System.Windows.Forms.PictureBox();
            this.pcAlarmSwitch56 = new System.Windows.Forms.PictureBox();
            this.pcAlarmSwitch72 = new System.Windows.Forms.PictureBox();
            this.pcAlarmSwitch88 = new System.Windows.Forms.PictureBox();
            this.pcAlarmSwitch104 = new System.Windows.Forms.PictureBox();
            this.pcAlarmSwitch120 = new System.Windows.Forms.PictureBox();
            this.pcAlarmSwitch121 = new System.Windows.Forms.PictureBox();
            this.pcAlarmSwitch105 = new System.Windows.Forms.PictureBox();
            this.pcAlarmSwitch89 = new System.Windows.Forms.PictureBox();
            this.pcAlarmSwitch73 = new System.Windows.Forms.PictureBox();
            this.pcAlarmSwitch57 = new System.Windows.Forms.PictureBox();
            this.pcAlarmSwitch41 = new System.Windows.Forms.PictureBox();
            this.pcAlarmSwitch25 = new System.Windows.Forms.PictureBox();
            this.pcAlarmSwitch9 = new System.Windows.Forms.PictureBox();
            this.pcAlarmSwitch10 = new System.Windows.Forms.PictureBox();
            this.pcAlarmSwitch26 = new System.Windows.Forms.PictureBox();
            this.pcAlarmSwitch42 = new System.Windows.Forms.PictureBox();
            this.pcAlarmSwitch58 = new System.Windows.Forms.PictureBox();
            this.pcAlarmSwitch74 = new System.Windows.Forms.PictureBox();
            this.pcAlarmSwitch90 = new System.Windows.Forms.PictureBox();
            this.pcAlarmSwitch106 = new System.Windows.Forms.PictureBox();
            this.pcAlarmSwitch122 = new System.Windows.Forms.PictureBox();
            this.pcAlarmSwitch123 = new System.Windows.Forms.PictureBox();
            this.pcAlarmSwitch107 = new System.Windows.Forms.PictureBox();
            this.pcAlarmSwitch91 = new System.Windows.Forms.PictureBox();
            this.pcAlarmSwitch75 = new System.Windows.Forms.PictureBox();
            this.pcAlarmSwitch59 = new System.Windows.Forms.PictureBox();
            this.pcAlarmSwitch43 = new System.Windows.Forms.PictureBox();
            this.pcAlarmSwitch27 = new System.Windows.Forms.PictureBox();
            this.pcAlarmSwitch11 = new System.Windows.Forms.PictureBox();
            this.pcAlarmSwitch12 = new System.Windows.Forms.PictureBox();
            this.pcAlarmSwitch28 = new System.Windows.Forms.PictureBox();
            this.pcAlarmSwitch44 = new System.Windows.Forms.PictureBox();
            this.pcAlarmSwitch60 = new System.Windows.Forms.PictureBox();
            this.pcAlarmSwitch76 = new System.Windows.Forms.PictureBox();
            this.pcAlarmSwitch92 = new System.Windows.Forms.PictureBox();
            this.pcAlarmSwitch108 = new System.Windows.Forms.PictureBox();
            this.pcAlarmSwitch124 = new System.Windows.Forms.PictureBox();
            this.pcAlarmSwitch125 = new System.Windows.Forms.PictureBox();
            this.pcAlarmSwitch109 = new System.Windows.Forms.PictureBox();
            this.pcAlarmSwitch93 = new System.Windows.Forms.PictureBox();
            this.pcAlarmSwitch77 = new System.Windows.Forms.PictureBox();
            this.pcAlarmSwitch61 = new System.Windows.Forms.PictureBox();
            this.pcAlarmSwitch45 = new System.Windows.Forms.PictureBox();
            this.pcAlarmSwitch29 = new System.Windows.Forms.PictureBox();
            this.pcAlarmSwitch13 = new System.Windows.Forms.PictureBox();
            this.pcAlarmSwitch14 = new System.Windows.Forms.PictureBox();
            this.pcAlarmSwitch30 = new System.Windows.Forms.PictureBox();
            this.pcAlarmSwitch46 = new System.Windows.Forms.PictureBox();
            this.pcAlarmSwitch62 = new System.Windows.Forms.PictureBox();
            this.pcAlarmSwitch78 = new System.Windows.Forms.PictureBox();
            this.pcAlarmSwitch94 = new System.Windows.Forms.PictureBox();
            this.pcAlarmSwitch110 = new System.Windows.Forms.PictureBox();
            this.pcAlarmSwitch126 = new System.Windows.Forms.PictureBox();
            this.pictureBox114 = new System.Windows.Forms.PictureBox();
            this.pcAlarmSwitch111 = new System.Windows.Forms.PictureBox();
            this.pcAlarmSwitch95 = new System.Windows.Forms.PictureBox();
            this.pcAlarmSwitch79 = new System.Windows.Forms.PictureBox();
            this.pcAlarmSwitch63 = new System.Windows.Forms.PictureBox();
            this.pcAlarmSwitch47 = new System.Windows.Forms.PictureBox();
            this.pcAlarmSwitch31 = new System.Windows.Forms.PictureBox();
            this.pcAlarmSwitch15 = new System.Windows.Forms.PictureBox();
            this.pcAlarmSwitch16 = new System.Windows.Forms.PictureBox();
            this.pcAlarmSwitch32 = new System.Windows.Forms.PictureBox();
            this.pcAlarmSwitch48 = new System.Windows.Forms.PictureBox();
            this.pcAlarmSwitch64 = new System.Windows.Forms.PictureBox();
            this.pcAlarmSwitch80 = new System.Windows.Forms.PictureBox();
            this.pcAlarmSwitch96 = new System.Windows.Forms.PictureBox();
            this.pcAlarmSwitch112 = new System.Windows.Forms.PictureBox();
            this.pcAlarmSwitch128 = new System.Windows.Forms.PictureBox();
            this.pcMap = new DevExpress.XtraEditors.PanelControl();
            this.pictureBoxMap = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblAlarmPosition = new System.Windows.Forms.Label();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem4 = new DevExpress.XtraBars.BarButtonItem();
            this.barbtnClose = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem6 = new DevExpress.XtraBars.BarButtonItem();
            this.barSubItem3 = new DevExpress.XtraBars.BarSubItem();
            this.mainMultiplexer = new CameraViewer.Multiplexer();
            this.cmIcon = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.删除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timerCheckAlarmSites = new System.Windows.Forms.Timer(this.components);
            this.timerUpdateIcon = new System.Windows.Forms.Timer(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.barStaticItem1 = new DevExpress.XtraBars.BarStaticItem();
            this.barStaticItemCurrentUser = new DevExpress.XtraBars.BarStaticItem();
            this.barStaticItem3 = new DevExpress.XtraBars.BarStaticItem();
            this.barStaticItemCameraNo = new DevExpress.XtraBars.BarStaticItem();
            this.barStaticItem2 = new DevExpress.XtraBars.BarStaticItem();
            this.barStaticItemDecoderNo = new DevExpress.XtraBars.BarStaticItem();
            this.barStaticItem4 = new DevExpress.XtraBars.BarStaticItem();
            this.barStaticItemCurrentTime = new DevExpress.XtraBars.BarStaticItem();
            this.timerCurretnTime = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barAndDockingController1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).BeginInit();
            this.dockPanelResult.SuspendLayout();
            this.dockPanel1.SuspendLayout();
            this.dockPanel1_Container.SuspendLayout();
            this.dockPanelAlarm.SuspendLayout();
            this.dockPanel3_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcBottom)).BeginInit();
            this.pcBottom.SuspendLayout();
            this.tlpBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch33)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch49)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch65)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch81)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch97)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch113)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch34)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch50)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch66)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch82)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch98)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch114)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch19)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch35)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch51)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch67)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch83)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch99)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch115)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch116)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch100)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch84)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch68)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch52)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch36)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch20)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch37)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch53)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch69)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch85)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox40)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch117)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch118)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch102)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch86)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch70)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch54)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch38)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch22)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch23)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch39)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch55)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch71)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch87)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch103)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch119)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch24)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch40)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch56)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch72)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch88)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch104)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch120)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch121)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch105)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch89)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch73)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch57)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch41)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch25)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch26)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch42)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch58)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch74)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch90)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch106)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch122)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch123)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch107)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch91)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch75)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch59)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch43)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch27)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch28)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch44)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch60)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch76)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch92)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch108)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch124)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch125)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch109)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch93)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch77)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch61)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch45)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch29)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch30)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch46)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch62)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch78)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch94)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch110)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch126)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox114)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch111)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch95)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch79)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch63)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch47)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch31)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch32)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch48)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch64)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch80)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch96)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch112)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch128)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcMap)).BeginInit();
            this.pcMap.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMap)).BeginInit();
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
            this.barButtonItemAlarmView,
            this.barButtonItemResultView,
            this.barStaticItem1,
            this.barStaticItemCurrentUser,
            this.barStaticItem3,
            this.barStaticItemCameraNo,
            this.barStaticItem2,
            this.barStaticItemDecoderNo,
            this.barStaticItem4,
            this.barStaticItemCurrentTime});
            this.barManager1.MainMenu = this.barMenu;
            this.barManager1.MaxItemId = 27;
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
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItemAlarmView),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItemResultView)});
            this.barSubItemMenuView.Name = "barSubItemMenuView";
            // 
            // barButtonItemAlarmView
            // 
            this.barButtonItemAlarmView.Caption = "报警视图";
            this.barButtonItemAlarmView.Id = 17;
            this.barButtonItemAlarmView.Name = "barButtonItemAlarmView";
            this.barButtonItemAlarmView.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemAlarmView_ItemClick);
            // 
            // barButtonItemResultView
            // 
            this.barButtonItemResultView.Caption = "结果视图";
            this.barButtonItemResultView.Id = 18;
            this.barButtonItemResultView.Name = "barButtonItemResultView";
            this.barButtonItemResultView.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemResultView_ItemClick);
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
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem3)});
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
            new DevExpress.XtraBars.LinkPersistInfo(this.barStaticItemCurrentTime)});
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
            // barAndDockingController1
            // 
            this.barAndDockingController1.PropertiesBar.AllowLinkLighting = false;
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
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 841);
            this.barDockControlBottom.Size = new System.Drawing.Size(1251, 28);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 55);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 786);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1251, 55);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 786);
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
            this.dockPanelResult.Size = new System.Drawing.Size(200, 786);
            this.dockPanelResult.Text = "结果";
            // 
            // dockPanel2_Container
            // 
            this.dockPanel2_Container.Location = new System.Drawing.Point(4, 23);
            this.dockPanel2_Container.Name = "dockPanel2_Container";
            this.dockPanel2_Container.Size = new System.Drawing.Size(192, 759);
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
            this.dockPanel1.Size = new System.Drawing.Size(200, 786);
            this.dockPanel1.Text = "导航";
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Controls.Add(this.cameraView1);
            this.dockPanel1_Container.Location = new System.Drawing.Point(4, 23);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(192, 759);
            this.dockPanel1_Container.TabIndex = 0;
            // 
            // cameraView1
            // 
            this.cameraView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cameraView1.Location = new System.Drawing.Point(0, 0);
            this.cameraView1.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.cameraView1.Name = "cameraView1";
            this.cameraView1.Size = new System.Drawing.Size(192, 759);
            this.cameraView1.TabIndex = 4;
            this.cameraView1.Load += new System.EventHandler(this.cameraView1_Load);
            // 
            // dockPanelAlarm
            // 
            this.dockPanelAlarm.Controls.Add(this.dockPanel3_Container);
            this.dockPanelAlarm.Dock = DevExpress.XtraBars.Docking.DockingStyle.Bottom;
            this.dockPanelAlarm.ID = new System.Guid("a9616fb8-8c7a-42f6-8822-ac9022a24a64");
            this.dockPanelAlarm.Location = new System.Drawing.Point(200, 652);
            this.dockPanelAlarm.Name = "dockPanelAlarm";
            this.dockPanelAlarm.OriginalSize = new System.Drawing.Size(200, 189);
            this.dockPanelAlarm.Size = new System.Drawing.Size(851, 189);
            this.dockPanelAlarm.Text = "报警";
            // 
            // dockPanel3_Container
            // 
            this.dockPanel3_Container.Controls.Add(this.pcBottom);
            this.dockPanel3_Container.Location = new System.Drawing.Point(4, 23);
            this.dockPanel3_Container.Name = "dockPanel3_Container";
            this.dockPanel3_Container.Size = new System.Drawing.Size(843, 162);
            this.dockPanel3_Container.TabIndex = 0;
            // 
            // pcBottom
            // 
            this.pcBottom.Controls.Add(this.tlpBottom);
            this.pcBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcBottom.Location = new System.Drawing.Point(0, 0);
            this.pcBottom.Name = "pcBottom";
            this.pcBottom.Size = new System.Drawing.Size(843, 162);
            this.pcBottom.TabIndex = 6;
            // 
            // tlpBottom
            // 
            this.tlpBottom.BackColor = System.Drawing.Color.Gray;
            this.tlpBottom.ColumnCount = 24;
            this.tlpBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tlpBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 73F));
            this.tlpBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 73F));
            this.tlpBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 318F));
            this.tlpBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 320F));
            this.tlpBottom.Controls.Add(this.panelControl1, 0, 0);
            this.tlpBottom.Controls.Add(this.btnLinkageEnable, 5, 6);
            this.tlpBottom.Controls.Add(this.btnFortify, 5, 4);
            this.tlpBottom.Controls.Add(this.btnCancelAlarm, 5, 2);
            this.tlpBottom.Controls.Add(this.btnLinkageDisable, 6, 6);
            this.tlpBottom.Controls.Add(this.button9, 6, 2);
            this.tlpBottom.Controls.Add(this.btnFortifyDisable, 6, 4);
            this.tlpBottom.Controls.Add(this.pcAlarmSwitch1, 7, 0);
            this.tlpBottom.Controls.Add(this.pcAlarmSwitch17, 7, 1);
            this.tlpBottom.Controls.Add(this.pcAlarmSwitch33, 7, 2);
            this.tlpBottom.Controls.Add(this.pcAlarmSwitch49, 7, 3);
            this.tlpBottom.Controls.Add(this.pcAlarmSwitch65, 7, 4);
            this.tlpBottom.Controls.Add(this.pcAlarmSwitch81, 7, 5);
            this.tlpBottom.Controls.Add(this.pcAlarmSwitch97, 7, 6);
            this.tlpBottom.Controls.Add(this.pcAlarmSwitch113, 7, 7);
            this.tlpBottom.Controls.Add(this.pcAlarmSwitch2, 8, 0);
            this.tlpBottom.Controls.Add(this.pcAlarmSwitch18, 8, 1);
            this.tlpBottom.Controls.Add(this.pcAlarmSwitch34, 8, 2);
            this.tlpBottom.Controls.Add(this.pcAlarmSwitch50, 8, 3);
            this.tlpBottom.Controls.Add(this.pcAlarmSwitch66, 8, 4);
            this.tlpBottom.Controls.Add(this.pcAlarmSwitch82, 8, 5);
            this.tlpBottom.Controls.Add(this.pcAlarmSwitch98, 8, 6);
            this.tlpBottom.Controls.Add(this.pcAlarmSwitch114, 8, 7);
            this.tlpBottom.Controls.Add(this.pcAlarmSwitch3, 9, 0);
            this.tlpBottom.Controls.Add(this.pcAlarmSwitch19, 9, 1);
            this.tlpBottom.Controls.Add(this.pcAlarmSwitch35, 9, 2);
            this.tlpBottom.Controls.Add(this.pcAlarmSwitch51, 9, 3);
            this.tlpBottom.Controls.Add(this.pcAlarmSwitch67, 9, 4);
            this.tlpBottom.Controls.Add(this.pcAlarmSwitch83, 9, 5);
            this.tlpBottom.Controls.Add(this.pcAlarmSwitch99, 9, 6);
            this.tlpBottom.Controls.Add(this.pcAlarmSwitch115, 9, 7);
            this.tlpBottom.Controls.Add(this.pcAlarmSwitch116, 10, 7);
            this.tlpBottom.Controls.Add(this.pcAlarmSwitch100, 10, 6);
            this.tlpBottom.Controls.Add(this.pcAlarmSwitch84, 10, 5);
            this.tlpBottom.Controls.Add(this.pcAlarmSwitch68, 10, 4);
            this.tlpBottom.Controls.Add(this.pcAlarmSwitch52, 10, 3);
            this.tlpBottom.Controls.Add(this.pcAlarmSwitch36, 10, 2);
            this.tlpBottom.Controls.Add(this.pcAlarmSwitch20, 10, 1);
            this.tlpBottom.Controls.Add(this.pcAlarmSwitch4, 10, 0);
            this.tlpBottom.Controls.Add(this.pcAlarmSwitch5, 11, 0);
            this.tlpBottom.Controls.Add(this.pcAlarmSwitch21, 11, 1);
            this.tlpBottom.Controls.Add(this.pcAlarmSwitch37, 11, 2);
            this.tlpBottom.Controls.Add(this.pcAlarmSwitch53, 11, 3);
            this.tlpBottom.Controls.Add(this.pcAlarmSwitch69, 11, 4);
            this.tlpBottom.Controls.Add(this.pcAlarmSwitch85, 11, 5);
            this.tlpBottom.Controls.Add(this.pictureBox40, 11, 6);
            this.tlpBottom.Controls.Add(this.pcAlarmSwitch117, 11, 7);
            this.tlpBottom.Controls.Add(this.pcAlarmSwitch118, 12, 7);
            this.tlpBottom.Controls.Add(this.pcAlarmSwitch102, 12, 6);
            this.tlpBottom.Controls.Add(this.pcAlarmSwitch86, 12, 5);
            this.tlpBottom.Controls.Add(this.pcAlarmSwitch70, 12, 4);
            this.tlpBottom.Controls.Add(this.pcAlarmSwitch54, 12, 3);
            this.tlpBottom.Controls.Add(this.pcAlarmSwitch38, 12, 2);
            this.tlpBottom.Controls.Add(this.pcAlarmSwitch22, 12, 1);
            this.tlpBottom.Controls.Add(this.pcAlarmSwitch6, 12, 0);
            this.tlpBottom.Controls.Add(this.pcAlarmSwitch7, 13, 0);
            this.tlpBottom.Controls.Add(this.pcAlarmSwitch23, 13, 1);
            this.tlpBottom.Controls.Add(this.pcAlarmSwitch39, 13, 2);
            this.tlpBottom.Controls.Add(this.pcAlarmSwitch55, 13, 3);
            this.tlpBottom.Controls.Add(this.pcAlarmSwitch71, 13, 4);
            this.tlpBottom.Controls.Add(this.pcAlarmSwitch87, 13, 5);
            this.tlpBottom.Controls.Add(this.pcAlarmSwitch103, 13, 6);
            this.tlpBottom.Controls.Add(this.pcAlarmSwitch119, 13, 7);
            this.tlpBottom.Controls.Add(this.pcAlarmSwitch8, 14, 0);
            this.tlpBottom.Controls.Add(this.pcAlarmSwitch24, 14, 1);
            this.tlpBottom.Controls.Add(this.pcAlarmSwitch40, 14, 2);
            this.tlpBottom.Controls.Add(this.pcAlarmSwitch56, 14, 3);
            this.tlpBottom.Controls.Add(this.pcAlarmSwitch72, 14, 4);
            this.tlpBottom.Controls.Add(this.pcAlarmSwitch88, 14, 5);
            this.tlpBottom.Controls.Add(this.pcAlarmSwitch104, 14, 6);
            this.tlpBottom.Controls.Add(this.pcAlarmSwitch120, 14, 7);
            this.tlpBottom.Controls.Add(this.pcAlarmSwitch121, 15, 7);
            this.tlpBottom.Controls.Add(this.pcAlarmSwitch105, 15, 6);
            this.tlpBottom.Controls.Add(this.pcAlarmSwitch89, 15, 5);
            this.tlpBottom.Controls.Add(this.pcAlarmSwitch73, 15, 4);
            this.tlpBottom.Controls.Add(this.pcAlarmSwitch57, 15, 3);
            this.tlpBottom.Controls.Add(this.pcAlarmSwitch41, 15, 2);
            this.tlpBottom.Controls.Add(this.pcAlarmSwitch25, 15, 1);
            this.tlpBottom.Controls.Add(this.pcAlarmSwitch9, 15, 0);
            this.tlpBottom.Controls.Add(this.pcAlarmSwitch10, 16, 0);
            this.tlpBottom.Controls.Add(this.pcAlarmSwitch26, 16, 1);
            this.tlpBottom.Controls.Add(this.pcAlarmSwitch42, 16, 2);
            this.tlpBottom.Controls.Add(this.pcAlarmSwitch58, 16, 3);
            this.tlpBottom.Controls.Add(this.pcAlarmSwitch74, 16, 4);
            this.tlpBottom.Controls.Add(this.pcAlarmSwitch90, 16, 5);
            this.tlpBottom.Controls.Add(this.pcAlarmSwitch106, 16, 6);
            this.tlpBottom.Controls.Add(this.pcAlarmSwitch122, 16, 7);
            this.tlpBottom.Controls.Add(this.pcAlarmSwitch123, 17, 7);
            this.tlpBottom.Controls.Add(this.pcAlarmSwitch107, 17, 6);
            this.tlpBottom.Controls.Add(this.pcAlarmSwitch91, 17, 5);
            this.tlpBottom.Controls.Add(this.pcAlarmSwitch75, 17, 4);
            this.tlpBottom.Controls.Add(this.pcAlarmSwitch59, 17, 3);
            this.tlpBottom.Controls.Add(this.pcAlarmSwitch43, 17, 2);
            this.tlpBottom.Controls.Add(this.pcAlarmSwitch27, 17, 1);
            this.tlpBottom.Controls.Add(this.pcAlarmSwitch11, 17, 0);
            this.tlpBottom.Controls.Add(this.pcAlarmSwitch12, 18, 0);
            this.tlpBottom.Controls.Add(this.pcAlarmSwitch28, 18, 1);
            this.tlpBottom.Controls.Add(this.pcAlarmSwitch44, 18, 2);
            this.tlpBottom.Controls.Add(this.pcAlarmSwitch60, 18, 3);
            this.tlpBottom.Controls.Add(this.pcAlarmSwitch76, 18, 4);
            this.tlpBottom.Controls.Add(this.pcAlarmSwitch92, 18, 5);
            this.tlpBottom.Controls.Add(this.pcAlarmSwitch108, 18, 6);
            this.tlpBottom.Controls.Add(this.pcAlarmSwitch124, 18, 7);
            this.tlpBottom.Controls.Add(this.pcAlarmSwitch125, 19, 7);
            this.tlpBottom.Controls.Add(this.pcAlarmSwitch109, 19, 6);
            this.tlpBottom.Controls.Add(this.pcAlarmSwitch93, 19, 5);
            this.tlpBottom.Controls.Add(this.pcAlarmSwitch77, 19, 4);
            this.tlpBottom.Controls.Add(this.pcAlarmSwitch61, 19, 3);
            this.tlpBottom.Controls.Add(this.pcAlarmSwitch45, 19, 2);
            this.tlpBottom.Controls.Add(this.pcAlarmSwitch29, 19, 1);
            this.tlpBottom.Controls.Add(this.pcAlarmSwitch13, 19, 0);
            this.tlpBottom.Controls.Add(this.pcAlarmSwitch14, 20, 0);
            this.tlpBottom.Controls.Add(this.pcAlarmSwitch30, 20, 1);
            this.tlpBottom.Controls.Add(this.pcAlarmSwitch46, 20, 2);
            this.tlpBottom.Controls.Add(this.pcAlarmSwitch62, 20, 3);
            this.tlpBottom.Controls.Add(this.pcAlarmSwitch78, 20, 4);
            this.tlpBottom.Controls.Add(this.pcAlarmSwitch94, 20, 5);
            this.tlpBottom.Controls.Add(this.pcAlarmSwitch110, 20, 6);
            this.tlpBottom.Controls.Add(this.pcAlarmSwitch126, 20, 7);
            this.tlpBottom.Controls.Add(this.pictureBox114, 21, 7);
            this.tlpBottom.Controls.Add(this.pcAlarmSwitch111, 21, 6);
            this.tlpBottom.Controls.Add(this.pcAlarmSwitch95, 21, 5);
            this.tlpBottom.Controls.Add(this.pcAlarmSwitch79, 21, 4);
            this.tlpBottom.Controls.Add(this.pcAlarmSwitch63, 21, 3);
            this.tlpBottom.Controls.Add(this.pcAlarmSwitch47, 21, 2);
            this.tlpBottom.Controls.Add(this.pcAlarmSwitch31, 21, 1);
            this.tlpBottom.Controls.Add(this.pcAlarmSwitch15, 21, 0);
            this.tlpBottom.Controls.Add(this.pcAlarmSwitch16, 22, 0);
            this.tlpBottom.Controls.Add(this.pcAlarmSwitch32, 22, 1);
            this.tlpBottom.Controls.Add(this.pcAlarmSwitch48, 22, 2);
            this.tlpBottom.Controls.Add(this.pcAlarmSwitch64, 22, 3);
            this.tlpBottom.Controls.Add(this.pcAlarmSwitch80, 22, 4);
            this.tlpBottom.Controls.Add(this.pcAlarmSwitch96, 22, 5);
            this.tlpBottom.Controls.Add(this.pcAlarmSwitch112, 22, 6);
            this.tlpBottom.Controls.Add(this.pcAlarmSwitch128, 22, 7);
            this.tlpBottom.Controls.Add(this.pcMap, 34, 0);
            this.tlpBottom.Controls.Add(this.label1, 5, 0);
            this.tlpBottom.Controls.Add(this.lblAlarmPosition, 6, 0);
            this.tlpBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpBottom.Location = new System.Drawing.Point(2, 2);
            this.tlpBottom.Name = "tlpBottom";
            this.tlpBottom.RowCount = 8;
            this.tlpBottom.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpBottom.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpBottom.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpBottom.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpBottom.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpBottom.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpBottom.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpBottom.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpBottom.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpBottom.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpBottom.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpBottom.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpBottom.Size = new System.Drawing.Size(839, 158);
            this.tlpBottom.TabIndex = 1;
            // 
            // panelControl1
            // 
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.tlpBottom.SetColumnSpan(this.panelControl1, 3);
            this.panelControl1.Controls.Add(this.button4);
            this.panelControl1.Controls.Add(this.button3);
            this.panelControl1.Controls.Add(this.button2);
            this.panelControl1.Controls.Add(this.button1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(3, 3);
            this.panelControl1.Name = "panelControl1";
            this.tlpBottom.SetRowSpan(this.panelControl1, 8);
            this.panelControl1.Size = new System.Drawing.Size(49, 154);
            this.panelControl1.TabIndex = 0;
            // 
            // button4
            // 
            this.button4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button4.BackgroundImage")));
            this.button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button4.Location = new System.Drawing.Point(1, 117);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(46, 40);
            this.button4.TabIndex = 3;
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button3.BackgroundImage")));
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button3.Location = new System.Drawing.Point(1, 77);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(46, 40);
            this.button3.TabIndex = 2;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button2.BackgroundImage")));
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.Location = new System.Drawing.Point(1, 37);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(46, 40);
            this.button2.TabIndex = 1;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Location = new System.Drawing.Point(1, -3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(46, 40);
            this.button1.TabIndex = 0;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnLinkageEnable
            // 
            this.btnLinkageEnable.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnLinkageEnable.Location = new System.Drawing.Point(58, 123);
            this.btnLinkageEnable.Name = "btnLinkageEnable";
            this.tlpBottom.SetRowSpan(this.btnLinkageEnable, 2);
            this.btnLinkageEnable.Size = new System.Drawing.Size(67, 23);
            this.btnLinkageEnable.TabIndex = 2;
            this.btnLinkageEnable.Text = "联动开";
            this.btnLinkageEnable.UseVisualStyleBackColor = true;
            this.btnLinkageEnable.Click += new System.EventHandler(this.LinkageEnable_Click);
            // 
            // btnFortify
            // 
            this.btnFortify.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnFortify.Location = new System.Drawing.Point(58, 83);
            this.btnFortify.Name = "btnFortify";
            this.tlpBottom.SetRowSpan(this.btnFortify, 2);
            this.btnFortify.Size = new System.Drawing.Size(67, 23);
            this.btnFortify.TabIndex = 2;
            this.btnFortify.Text = "设防";
            this.btnFortify.UseVisualStyleBackColor = true;
            this.btnFortify.Click += new System.EventHandler(this.Fortify_Click);
            // 
            // btnCancelAlarm
            // 
            this.btnCancelAlarm.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCancelAlarm.Location = new System.Drawing.Point(58, 43);
            this.btnCancelAlarm.Name = "btnCancelAlarm";
            this.tlpBottom.SetRowSpan(this.btnCancelAlarm, 2);
            this.btnCancelAlarm.Size = new System.Drawing.Size(67, 23);
            this.btnCancelAlarm.TabIndex = 2;
            this.btnCancelAlarm.Text = "消警";
            this.btnCancelAlarm.UseVisualStyleBackColor = true;
            this.btnCancelAlarm.Click += new System.EventHandler(this.btnCancelAlarm_Click);
            // 
            // btnLinkageDisable
            // 
            this.btnLinkageDisable.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnLinkageDisable.Location = new System.Drawing.Point(131, 123);
            this.btnLinkageDisable.Name = "btnLinkageDisable";
            this.tlpBottom.SetRowSpan(this.btnLinkageDisable, 2);
            this.btnLinkageDisable.Size = new System.Drawing.Size(67, 23);
            this.btnLinkageDisable.TabIndex = 3;
            this.btnLinkageDisable.Text = "联动关";
            this.btnLinkageDisable.UseVisualStyleBackColor = true;
            this.btnLinkageDisable.Click += new System.EventHandler(this.LinkageDisable_Click);
            // 
            // button9
            // 
            this.button9.Dock = System.Windows.Forms.DockStyle.Top;
            this.button9.Location = new System.Drawing.Point(131, 43);
            this.button9.Name = "button9";
            this.tlpBottom.SetRowSpan(this.button9, 2);
            this.button9.Size = new System.Drawing.Size(67, 23);
            this.button9.TabIndex = 4;
            this.button9.Text = "日志";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // btnFortifyDisable
            // 
            this.btnFortifyDisable.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnFortifyDisable.Location = new System.Drawing.Point(131, 83);
            this.btnFortifyDisable.Name = "btnFortifyDisable";
            this.tlpBottom.SetRowSpan(this.btnFortifyDisable, 2);
            this.btnFortifyDisable.Size = new System.Drawing.Size(67, 23);
            this.btnFortifyDisable.TabIndex = 5;
            this.btnFortifyDisable.Text = "撤防";
            this.btnFortifyDisable.UseVisualStyleBackColor = true;
            this.btnFortifyDisable.Click += new System.EventHandler(this.FortifyDisable_Click);
            // 
            // pcAlarmSwitch1
            // 
            this.pcAlarmSwitch1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcAlarmSwitch1.Image = global::CameraViewer.Properties.Resources.AR3;
            this.pcAlarmSwitch1.Location = new System.Drawing.Point(204, 3);
            this.pcAlarmSwitch1.Name = "pcAlarmSwitch1";
            this.pcAlarmSwitch1.Size = new System.Drawing.Size(14, 14);
            this.pcAlarmSwitch1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcAlarmSwitch1.TabIndex = 7;
            this.pcAlarmSwitch1.TabStop = false;
            // 
            // pcAlarmSwitch17
            // 
            this.pcAlarmSwitch17.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcAlarmSwitch17.Image = global::CameraViewer.Properties.Resources.AR3;
            this.pcAlarmSwitch17.Location = new System.Drawing.Point(204, 23);
            this.pcAlarmSwitch17.Name = "pcAlarmSwitch17";
            this.pcAlarmSwitch17.Size = new System.Drawing.Size(14, 14);
            this.pcAlarmSwitch17.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcAlarmSwitch17.TabIndex = 7;
            this.pcAlarmSwitch17.TabStop = false;
            // 
            // pcAlarmSwitch33
            // 
            this.pcAlarmSwitch33.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcAlarmSwitch33.Image = global::CameraViewer.Properties.Resources.AR3;
            this.pcAlarmSwitch33.Location = new System.Drawing.Point(204, 43);
            this.pcAlarmSwitch33.Name = "pcAlarmSwitch33";
            this.pcAlarmSwitch33.Size = new System.Drawing.Size(14, 14);
            this.pcAlarmSwitch33.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcAlarmSwitch33.TabIndex = 7;
            this.pcAlarmSwitch33.TabStop = false;
            // 
            // pcAlarmSwitch49
            // 
            this.pcAlarmSwitch49.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcAlarmSwitch49.Image = global::CameraViewer.Properties.Resources.AR3;
            this.pcAlarmSwitch49.Location = new System.Drawing.Point(204, 63);
            this.pcAlarmSwitch49.Name = "pcAlarmSwitch49";
            this.pcAlarmSwitch49.Size = new System.Drawing.Size(14, 14);
            this.pcAlarmSwitch49.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcAlarmSwitch49.TabIndex = 7;
            this.pcAlarmSwitch49.TabStop = false;
            // 
            // pcAlarmSwitch65
            // 
            this.pcAlarmSwitch65.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcAlarmSwitch65.Image = global::CameraViewer.Properties.Resources.AR3;
            this.pcAlarmSwitch65.Location = new System.Drawing.Point(204, 83);
            this.pcAlarmSwitch65.Name = "pcAlarmSwitch65";
            this.pcAlarmSwitch65.Size = new System.Drawing.Size(14, 14);
            this.pcAlarmSwitch65.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcAlarmSwitch65.TabIndex = 7;
            this.pcAlarmSwitch65.TabStop = false;
            // 
            // pcAlarmSwitch81
            // 
            this.pcAlarmSwitch81.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcAlarmSwitch81.Image = global::CameraViewer.Properties.Resources.AR3;
            this.pcAlarmSwitch81.Location = new System.Drawing.Point(204, 103);
            this.pcAlarmSwitch81.Name = "pcAlarmSwitch81";
            this.pcAlarmSwitch81.Size = new System.Drawing.Size(14, 14);
            this.pcAlarmSwitch81.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcAlarmSwitch81.TabIndex = 7;
            this.pcAlarmSwitch81.TabStop = false;
            // 
            // pcAlarmSwitch97
            // 
            this.pcAlarmSwitch97.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcAlarmSwitch97.Image = global::CameraViewer.Properties.Resources.AR3;
            this.pcAlarmSwitch97.Location = new System.Drawing.Point(204, 123);
            this.pcAlarmSwitch97.Name = "pcAlarmSwitch97";
            this.pcAlarmSwitch97.Size = new System.Drawing.Size(14, 14);
            this.pcAlarmSwitch97.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcAlarmSwitch97.TabIndex = 7;
            this.pcAlarmSwitch97.TabStop = false;
            // 
            // pcAlarmSwitch113
            // 
            this.pcAlarmSwitch113.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcAlarmSwitch113.Image = global::CameraViewer.Properties.Resources.AR3;
            this.pcAlarmSwitch113.Location = new System.Drawing.Point(204, 143);
            this.pcAlarmSwitch113.Name = "pcAlarmSwitch113";
            this.pcAlarmSwitch113.Size = new System.Drawing.Size(14, 14);
            this.pcAlarmSwitch113.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcAlarmSwitch113.TabIndex = 7;
            this.pcAlarmSwitch113.TabStop = false;
            // 
            // pcAlarmSwitch2
            // 
            this.pcAlarmSwitch2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcAlarmSwitch2.Image = global::CameraViewer.Properties.Resources.AR3;
            this.pcAlarmSwitch2.Location = new System.Drawing.Point(224, 3);
            this.pcAlarmSwitch2.Name = "pcAlarmSwitch2";
            this.pcAlarmSwitch2.Size = new System.Drawing.Size(14, 14);
            this.pcAlarmSwitch2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcAlarmSwitch2.TabIndex = 7;
            this.pcAlarmSwitch2.TabStop = false;
            // 
            // pcAlarmSwitch18
            // 
            this.pcAlarmSwitch18.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcAlarmSwitch18.Image = global::CameraViewer.Properties.Resources.AR3;
            this.pcAlarmSwitch18.Location = new System.Drawing.Point(224, 23);
            this.pcAlarmSwitch18.Name = "pcAlarmSwitch18";
            this.pcAlarmSwitch18.Size = new System.Drawing.Size(14, 14);
            this.pcAlarmSwitch18.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcAlarmSwitch18.TabIndex = 7;
            this.pcAlarmSwitch18.TabStop = false;
            // 
            // pcAlarmSwitch34
            // 
            this.pcAlarmSwitch34.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcAlarmSwitch34.Image = global::CameraViewer.Properties.Resources.AR3;
            this.pcAlarmSwitch34.Location = new System.Drawing.Point(224, 43);
            this.pcAlarmSwitch34.Name = "pcAlarmSwitch34";
            this.pcAlarmSwitch34.Size = new System.Drawing.Size(14, 14);
            this.pcAlarmSwitch34.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcAlarmSwitch34.TabIndex = 7;
            this.pcAlarmSwitch34.TabStop = false;
            // 
            // pcAlarmSwitch50
            // 
            this.pcAlarmSwitch50.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcAlarmSwitch50.Image = global::CameraViewer.Properties.Resources.AR3;
            this.pcAlarmSwitch50.Location = new System.Drawing.Point(224, 63);
            this.pcAlarmSwitch50.Name = "pcAlarmSwitch50";
            this.pcAlarmSwitch50.Size = new System.Drawing.Size(14, 14);
            this.pcAlarmSwitch50.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcAlarmSwitch50.TabIndex = 7;
            this.pcAlarmSwitch50.TabStop = false;
            // 
            // pcAlarmSwitch66
            // 
            this.pcAlarmSwitch66.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcAlarmSwitch66.Image = global::CameraViewer.Properties.Resources.AR3;
            this.pcAlarmSwitch66.Location = new System.Drawing.Point(224, 83);
            this.pcAlarmSwitch66.Name = "pcAlarmSwitch66";
            this.pcAlarmSwitch66.Size = new System.Drawing.Size(14, 14);
            this.pcAlarmSwitch66.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcAlarmSwitch66.TabIndex = 7;
            this.pcAlarmSwitch66.TabStop = false;
            // 
            // pcAlarmSwitch82
            // 
            this.pcAlarmSwitch82.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcAlarmSwitch82.Image = global::CameraViewer.Properties.Resources.AR3;
            this.pcAlarmSwitch82.Location = new System.Drawing.Point(224, 103);
            this.pcAlarmSwitch82.Name = "pcAlarmSwitch82";
            this.pcAlarmSwitch82.Size = new System.Drawing.Size(14, 14);
            this.pcAlarmSwitch82.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcAlarmSwitch82.TabIndex = 7;
            this.pcAlarmSwitch82.TabStop = false;
            // 
            // pcAlarmSwitch98
            // 
            this.pcAlarmSwitch98.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcAlarmSwitch98.Image = global::CameraViewer.Properties.Resources.AR3;
            this.pcAlarmSwitch98.Location = new System.Drawing.Point(224, 123);
            this.pcAlarmSwitch98.Name = "pcAlarmSwitch98";
            this.pcAlarmSwitch98.Size = new System.Drawing.Size(14, 14);
            this.pcAlarmSwitch98.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcAlarmSwitch98.TabIndex = 7;
            this.pcAlarmSwitch98.TabStop = false;
            // 
            // pcAlarmSwitch114
            // 
            this.pcAlarmSwitch114.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcAlarmSwitch114.Image = global::CameraViewer.Properties.Resources.AR3;
            this.pcAlarmSwitch114.Location = new System.Drawing.Point(224, 143);
            this.pcAlarmSwitch114.Name = "pcAlarmSwitch114";
            this.pcAlarmSwitch114.Size = new System.Drawing.Size(14, 14);
            this.pcAlarmSwitch114.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcAlarmSwitch114.TabIndex = 7;
            this.pcAlarmSwitch114.TabStop = false;
            // 
            // pcAlarmSwitch3
            // 
            this.pcAlarmSwitch3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcAlarmSwitch3.Image = global::CameraViewer.Properties.Resources.AR3;
            this.pcAlarmSwitch3.Location = new System.Drawing.Point(244, 3);
            this.pcAlarmSwitch3.Name = "pcAlarmSwitch3";
            this.pcAlarmSwitch3.Size = new System.Drawing.Size(14, 14);
            this.pcAlarmSwitch3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcAlarmSwitch3.TabIndex = 7;
            this.pcAlarmSwitch3.TabStop = false;
            // 
            // pcAlarmSwitch19
            // 
            this.pcAlarmSwitch19.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcAlarmSwitch19.Image = global::CameraViewer.Properties.Resources.AR3;
            this.pcAlarmSwitch19.Location = new System.Drawing.Point(244, 23);
            this.pcAlarmSwitch19.Name = "pcAlarmSwitch19";
            this.pcAlarmSwitch19.Size = new System.Drawing.Size(14, 14);
            this.pcAlarmSwitch19.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcAlarmSwitch19.TabIndex = 7;
            this.pcAlarmSwitch19.TabStop = false;
            // 
            // pcAlarmSwitch35
            // 
            this.pcAlarmSwitch35.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcAlarmSwitch35.Image = global::CameraViewer.Properties.Resources.AR3;
            this.pcAlarmSwitch35.Location = new System.Drawing.Point(244, 43);
            this.pcAlarmSwitch35.Name = "pcAlarmSwitch35";
            this.pcAlarmSwitch35.Size = new System.Drawing.Size(14, 14);
            this.pcAlarmSwitch35.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcAlarmSwitch35.TabIndex = 7;
            this.pcAlarmSwitch35.TabStop = false;
            // 
            // pcAlarmSwitch51
            // 
            this.pcAlarmSwitch51.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcAlarmSwitch51.Image = global::CameraViewer.Properties.Resources.AR3;
            this.pcAlarmSwitch51.Location = new System.Drawing.Point(244, 63);
            this.pcAlarmSwitch51.Name = "pcAlarmSwitch51";
            this.pcAlarmSwitch51.Size = new System.Drawing.Size(14, 14);
            this.pcAlarmSwitch51.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcAlarmSwitch51.TabIndex = 7;
            this.pcAlarmSwitch51.TabStop = false;
            // 
            // pcAlarmSwitch67
            // 
            this.pcAlarmSwitch67.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcAlarmSwitch67.Image = global::CameraViewer.Properties.Resources.AR3;
            this.pcAlarmSwitch67.Location = new System.Drawing.Point(244, 83);
            this.pcAlarmSwitch67.Name = "pcAlarmSwitch67";
            this.pcAlarmSwitch67.Size = new System.Drawing.Size(14, 14);
            this.pcAlarmSwitch67.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcAlarmSwitch67.TabIndex = 7;
            this.pcAlarmSwitch67.TabStop = false;
            // 
            // pcAlarmSwitch83
            // 
            this.pcAlarmSwitch83.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcAlarmSwitch83.Image = global::CameraViewer.Properties.Resources.AR3;
            this.pcAlarmSwitch83.Location = new System.Drawing.Point(244, 103);
            this.pcAlarmSwitch83.Name = "pcAlarmSwitch83";
            this.pcAlarmSwitch83.Size = new System.Drawing.Size(14, 14);
            this.pcAlarmSwitch83.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcAlarmSwitch83.TabIndex = 7;
            this.pcAlarmSwitch83.TabStop = false;
            // 
            // pcAlarmSwitch99
            // 
            this.pcAlarmSwitch99.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcAlarmSwitch99.Image = global::CameraViewer.Properties.Resources.AR3;
            this.pcAlarmSwitch99.Location = new System.Drawing.Point(244, 123);
            this.pcAlarmSwitch99.Name = "pcAlarmSwitch99";
            this.pcAlarmSwitch99.Size = new System.Drawing.Size(14, 14);
            this.pcAlarmSwitch99.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcAlarmSwitch99.TabIndex = 7;
            this.pcAlarmSwitch99.TabStop = false;
            // 
            // pcAlarmSwitch115
            // 
            this.pcAlarmSwitch115.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcAlarmSwitch115.Image = global::CameraViewer.Properties.Resources.AR3;
            this.pcAlarmSwitch115.Location = new System.Drawing.Point(244, 143);
            this.pcAlarmSwitch115.Name = "pcAlarmSwitch115";
            this.pcAlarmSwitch115.Size = new System.Drawing.Size(14, 14);
            this.pcAlarmSwitch115.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcAlarmSwitch115.TabIndex = 7;
            this.pcAlarmSwitch115.TabStop = false;
            // 
            // pcAlarmSwitch116
            // 
            this.pcAlarmSwitch116.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcAlarmSwitch116.Image = global::CameraViewer.Properties.Resources.AR3;
            this.pcAlarmSwitch116.Location = new System.Drawing.Point(264, 143);
            this.pcAlarmSwitch116.Name = "pcAlarmSwitch116";
            this.pcAlarmSwitch116.Size = new System.Drawing.Size(14, 14);
            this.pcAlarmSwitch116.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcAlarmSwitch116.TabIndex = 7;
            this.pcAlarmSwitch116.TabStop = false;
            // 
            // pcAlarmSwitch100
            // 
            this.pcAlarmSwitch100.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcAlarmSwitch100.Image = global::CameraViewer.Properties.Resources.AR3;
            this.pcAlarmSwitch100.Location = new System.Drawing.Point(264, 123);
            this.pcAlarmSwitch100.Name = "pcAlarmSwitch100";
            this.pcAlarmSwitch100.Size = new System.Drawing.Size(14, 14);
            this.pcAlarmSwitch100.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcAlarmSwitch100.TabIndex = 7;
            this.pcAlarmSwitch100.TabStop = false;
            // 
            // pcAlarmSwitch84
            // 
            this.pcAlarmSwitch84.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcAlarmSwitch84.Image = global::CameraViewer.Properties.Resources.AR3;
            this.pcAlarmSwitch84.Location = new System.Drawing.Point(264, 103);
            this.pcAlarmSwitch84.Name = "pcAlarmSwitch84";
            this.pcAlarmSwitch84.Size = new System.Drawing.Size(14, 14);
            this.pcAlarmSwitch84.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcAlarmSwitch84.TabIndex = 7;
            this.pcAlarmSwitch84.TabStop = false;
            // 
            // pcAlarmSwitch68
            // 
            this.pcAlarmSwitch68.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcAlarmSwitch68.Image = global::CameraViewer.Properties.Resources.AR3;
            this.pcAlarmSwitch68.Location = new System.Drawing.Point(264, 83);
            this.pcAlarmSwitch68.Name = "pcAlarmSwitch68";
            this.pcAlarmSwitch68.Size = new System.Drawing.Size(14, 14);
            this.pcAlarmSwitch68.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcAlarmSwitch68.TabIndex = 7;
            this.pcAlarmSwitch68.TabStop = false;
            // 
            // pcAlarmSwitch52
            // 
            this.pcAlarmSwitch52.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcAlarmSwitch52.Image = global::CameraViewer.Properties.Resources.AR3;
            this.pcAlarmSwitch52.Location = new System.Drawing.Point(264, 63);
            this.pcAlarmSwitch52.Name = "pcAlarmSwitch52";
            this.pcAlarmSwitch52.Size = new System.Drawing.Size(14, 14);
            this.pcAlarmSwitch52.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcAlarmSwitch52.TabIndex = 7;
            this.pcAlarmSwitch52.TabStop = false;
            // 
            // pcAlarmSwitch36
            // 
            this.pcAlarmSwitch36.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcAlarmSwitch36.Image = global::CameraViewer.Properties.Resources.AR3;
            this.pcAlarmSwitch36.Location = new System.Drawing.Point(264, 43);
            this.pcAlarmSwitch36.Name = "pcAlarmSwitch36";
            this.pcAlarmSwitch36.Size = new System.Drawing.Size(14, 14);
            this.pcAlarmSwitch36.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcAlarmSwitch36.TabIndex = 7;
            this.pcAlarmSwitch36.TabStop = false;
            // 
            // pcAlarmSwitch20
            // 
            this.pcAlarmSwitch20.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcAlarmSwitch20.Image = global::CameraViewer.Properties.Resources.AR3;
            this.pcAlarmSwitch20.Location = new System.Drawing.Point(264, 23);
            this.pcAlarmSwitch20.Name = "pcAlarmSwitch20";
            this.pcAlarmSwitch20.Size = new System.Drawing.Size(14, 14);
            this.pcAlarmSwitch20.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcAlarmSwitch20.TabIndex = 7;
            this.pcAlarmSwitch20.TabStop = false;
            // 
            // pcAlarmSwitch4
            // 
            this.pcAlarmSwitch4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcAlarmSwitch4.Image = global::CameraViewer.Properties.Resources.AR3;
            this.pcAlarmSwitch4.Location = new System.Drawing.Point(264, 3);
            this.pcAlarmSwitch4.Name = "pcAlarmSwitch4";
            this.pcAlarmSwitch4.Size = new System.Drawing.Size(14, 14);
            this.pcAlarmSwitch4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcAlarmSwitch4.TabIndex = 7;
            this.pcAlarmSwitch4.TabStop = false;
            // 
            // pcAlarmSwitch5
            // 
            this.pcAlarmSwitch5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcAlarmSwitch5.Image = global::CameraViewer.Properties.Resources.AR3;
            this.pcAlarmSwitch5.Location = new System.Drawing.Point(284, 3);
            this.pcAlarmSwitch5.Name = "pcAlarmSwitch5";
            this.pcAlarmSwitch5.Size = new System.Drawing.Size(14, 14);
            this.pcAlarmSwitch5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcAlarmSwitch5.TabIndex = 7;
            this.pcAlarmSwitch5.TabStop = false;
            // 
            // pcAlarmSwitch21
            // 
            this.pcAlarmSwitch21.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcAlarmSwitch21.Image = global::CameraViewer.Properties.Resources.AR3;
            this.pcAlarmSwitch21.Location = new System.Drawing.Point(284, 23);
            this.pcAlarmSwitch21.Name = "pcAlarmSwitch21";
            this.pcAlarmSwitch21.Size = new System.Drawing.Size(14, 14);
            this.pcAlarmSwitch21.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcAlarmSwitch21.TabIndex = 7;
            this.pcAlarmSwitch21.TabStop = false;
            // 
            // pcAlarmSwitch37
            // 
            this.pcAlarmSwitch37.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcAlarmSwitch37.Image = global::CameraViewer.Properties.Resources.AR3;
            this.pcAlarmSwitch37.Location = new System.Drawing.Point(284, 43);
            this.pcAlarmSwitch37.Name = "pcAlarmSwitch37";
            this.pcAlarmSwitch37.Size = new System.Drawing.Size(14, 14);
            this.pcAlarmSwitch37.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcAlarmSwitch37.TabIndex = 7;
            this.pcAlarmSwitch37.TabStop = false;
            // 
            // pcAlarmSwitch53
            // 
            this.pcAlarmSwitch53.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcAlarmSwitch53.Image = global::CameraViewer.Properties.Resources.AR3;
            this.pcAlarmSwitch53.Location = new System.Drawing.Point(284, 63);
            this.pcAlarmSwitch53.Name = "pcAlarmSwitch53";
            this.pcAlarmSwitch53.Size = new System.Drawing.Size(14, 14);
            this.pcAlarmSwitch53.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcAlarmSwitch53.TabIndex = 7;
            this.pcAlarmSwitch53.TabStop = false;
            // 
            // pcAlarmSwitch69
            // 
            this.pcAlarmSwitch69.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcAlarmSwitch69.Image = global::CameraViewer.Properties.Resources.AR3;
            this.pcAlarmSwitch69.Location = new System.Drawing.Point(284, 83);
            this.pcAlarmSwitch69.Name = "pcAlarmSwitch69";
            this.pcAlarmSwitch69.Size = new System.Drawing.Size(14, 14);
            this.pcAlarmSwitch69.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcAlarmSwitch69.TabIndex = 7;
            this.pcAlarmSwitch69.TabStop = false;
            // 
            // pcAlarmSwitch85
            // 
            this.pcAlarmSwitch85.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcAlarmSwitch85.Image = global::CameraViewer.Properties.Resources.AR3;
            this.pcAlarmSwitch85.Location = new System.Drawing.Point(284, 103);
            this.pcAlarmSwitch85.Name = "pcAlarmSwitch85";
            this.pcAlarmSwitch85.Size = new System.Drawing.Size(14, 14);
            this.pcAlarmSwitch85.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcAlarmSwitch85.TabIndex = 7;
            this.pcAlarmSwitch85.TabStop = false;
            // 
            // pictureBox40
            // 
            this.pictureBox40.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox40.Image = global::CameraViewer.Properties.Resources.AR3;
            this.pictureBox40.Location = new System.Drawing.Point(284, 123);
            this.pictureBox40.Name = "pictureBox40";
            this.pictureBox40.Size = new System.Drawing.Size(14, 14);
            this.pictureBox40.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox40.TabIndex = 7;
            this.pictureBox40.TabStop = false;
            // 
            // pcAlarmSwitch117
            // 
            this.pcAlarmSwitch117.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcAlarmSwitch117.Image = global::CameraViewer.Properties.Resources.AR3;
            this.pcAlarmSwitch117.Location = new System.Drawing.Point(284, 143);
            this.pcAlarmSwitch117.Name = "pcAlarmSwitch117";
            this.pcAlarmSwitch117.Size = new System.Drawing.Size(14, 14);
            this.pcAlarmSwitch117.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcAlarmSwitch117.TabIndex = 7;
            this.pcAlarmSwitch117.TabStop = false;
            // 
            // pcAlarmSwitch118
            // 
            this.pcAlarmSwitch118.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcAlarmSwitch118.Image = global::CameraViewer.Properties.Resources.AR3;
            this.pcAlarmSwitch118.Location = new System.Drawing.Point(304, 143);
            this.pcAlarmSwitch118.Name = "pcAlarmSwitch118";
            this.pcAlarmSwitch118.Size = new System.Drawing.Size(14, 14);
            this.pcAlarmSwitch118.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcAlarmSwitch118.TabIndex = 7;
            this.pcAlarmSwitch118.TabStop = false;
            // 
            // pcAlarmSwitch102
            // 
            this.pcAlarmSwitch102.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcAlarmSwitch102.Image = global::CameraViewer.Properties.Resources.AR3;
            this.pcAlarmSwitch102.Location = new System.Drawing.Point(304, 123);
            this.pcAlarmSwitch102.Name = "pcAlarmSwitch102";
            this.pcAlarmSwitch102.Size = new System.Drawing.Size(14, 14);
            this.pcAlarmSwitch102.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcAlarmSwitch102.TabIndex = 7;
            this.pcAlarmSwitch102.TabStop = false;
            // 
            // pcAlarmSwitch86
            // 
            this.pcAlarmSwitch86.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcAlarmSwitch86.Image = global::CameraViewer.Properties.Resources.AR3;
            this.pcAlarmSwitch86.Location = new System.Drawing.Point(304, 103);
            this.pcAlarmSwitch86.Name = "pcAlarmSwitch86";
            this.pcAlarmSwitch86.Size = new System.Drawing.Size(14, 14);
            this.pcAlarmSwitch86.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcAlarmSwitch86.TabIndex = 7;
            this.pcAlarmSwitch86.TabStop = false;
            // 
            // pcAlarmSwitch70
            // 
            this.pcAlarmSwitch70.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcAlarmSwitch70.Image = global::CameraViewer.Properties.Resources.AR3;
            this.pcAlarmSwitch70.Location = new System.Drawing.Point(304, 83);
            this.pcAlarmSwitch70.Name = "pcAlarmSwitch70";
            this.pcAlarmSwitch70.Size = new System.Drawing.Size(14, 14);
            this.pcAlarmSwitch70.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcAlarmSwitch70.TabIndex = 7;
            this.pcAlarmSwitch70.TabStop = false;
            // 
            // pcAlarmSwitch54
            // 
            this.pcAlarmSwitch54.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcAlarmSwitch54.Image = global::CameraViewer.Properties.Resources.AR3;
            this.pcAlarmSwitch54.Location = new System.Drawing.Point(304, 63);
            this.pcAlarmSwitch54.Name = "pcAlarmSwitch54";
            this.pcAlarmSwitch54.Size = new System.Drawing.Size(14, 14);
            this.pcAlarmSwitch54.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcAlarmSwitch54.TabIndex = 7;
            this.pcAlarmSwitch54.TabStop = false;
            // 
            // pcAlarmSwitch38
            // 
            this.pcAlarmSwitch38.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcAlarmSwitch38.Image = global::CameraViewer.Properties.Resources.AR3;
            this.pcAlarmSwitch38.Location = new System.Drawing.Point(304, 43);
            this.pcAlarmSwitch38.Name = "pcAlarmSwitch38";
            this.pcAlarmSwitch38.Size = new System.Drawing.Size(14, 14);
            this.pcAlarmSwitch38.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcAlarmSwitch38.TabIndex = 7;
            this.pcAlarmSwitch38.TabStop = false;
            // 
            // pcAlarmSwitch22
            // 
            this.pcAlarmSwitch22.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcAlarmSwitch22.Image = global::CameraViewer.Properties.Resources.AR3;
            this.pcAlarmSwitch22.Location = new System.Drawing.Point(304, 23);
            this.pcAlarmSwitch22.Name = "pcAlarmSwitch22";
            this.pcAlarmSwitch22.Size = new System.Drawing.Size(14, 14);
            this.pcAlarmSwitch22.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcAlarmSwitch22.TabIndex = 7;
            this.pcAlarmSwitch22.TabStop = false;
            // 
            // pcAlarmSwitch6
            // 
            this.pcAlarmSwitch6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcAlarmSwitch6.Image = global::CameraViewer.Properties.Resources.AR3;
            this.pcAlarmSwitch6.Location = new System.Drawing.Point(304, 3);
            this.pcAlarmSwitch6.Name = "pcAlarmSwitch6";
            this.pcAlarmSwitch6.Size = new System.Drawing.Size(14, 14);
            this.pcAlarmSwitch6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcAlarmSwitch6.TabIndex = 7;
            this.pcAlarmSwitch6.TabStop = false;
            // 
            // pcAlarmSwitch7
            // 
            this.pcAlarmSwitch7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcAlarmSwitch7.Image = global::CameraViewer.Properties.Resources.AR3;
            this.pcAlarmSwitch7.Location = new System.Drawing.Point(324, 3);
            this.pcAlarmSwitch7.Name = "pcAlarmSwitch7";
            this.pcAlarmSwitch7.Size = new System.Drawing.Size(14, 14);
            this.pcAlarmSwitch7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcAlarmSwitch7.TabIndex = 7;
            this.pcAlarmSwitch7.TabStop = false;
            // 
            // pcAlarmSwitch23
            // 
            this.pcAlarmSwitch23.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcAlarmSwitch23.Image = global::CameraViewer.Properties.Resources.AR3;
            this.pcAlarmSwitch23.Location = new System.Drawing.Point(324, 23);
            this.pcAlarmSwitch23.Name = "pcAlarmSwitch23";
            this.pcAlarmSwitch23.Size = new System.Drawing.Size(14, 14);
            this.pcAlarmSwitch23.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcAlarmSwitch23.TabIndex = 7;
            this.pcAlarmSwitch23.TabStop = false;
            // 
            // pcAlarmSwitch39
            // 
            this.pcAlarmSwitch39.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcAlarmSwitch39.Image = global::CameraViewer.Properties.Resources.AR3;
            this.pcAlarmSwitch39.Location = new System.Drawing.Point(324, 43);
            this.pcAlarmSwitch39.Name = "pcAlarmSwitch39";
            this.pcAlarmSwitch39.Size = new System.Drawing.Size(14, 14);
            this.pcAlarmSwitch39.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcAlarmSwitch39.TabIndex = 7;
            this.pcAlarmSwitch39.TabStop = false;
            // 
            // pcAlarmSwitch55
            // 
            this.pcAlarmSwitch55.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcAlarmSwitch55.Image = global::CameraViewer.Properties.Resources.AR3;
            this.pcAlarmSwitch55.Location = new System.Drawing.Point(324, 63);
            this.pcAlarmSwitch55.Name = "pcAlarmSwitch55";
            this.pcAlarmSwitch55.Size = new System.Drawing.Size(14, 14);
            this.pcAlarmSwitch55.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcAlarmSwitch55.TabIndex = 7;
            this.pcAlarmSwitch55.TabStop = false;
            // 
            // pcAlarmSwitch71
            // 
            this.pcAlarmSwitch71.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcAlarmSwitch71.Image = global::CameraViewer.Properties.Resources.AR3;
            this.pcAlarmSwitch71.Location = new System.Drawing.Point(324, 83);
            this.pcAlarmSwitch71.Name = "pcAlarmSwitch71";
            this.pcAlarmSwitch71.Size = new System.Drawing.Size(14, 14);
            this.pcAlarmSwitch71.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcAlarmSwitch71.TabIndex = 7;
            this.pcAlarmSwitch71.TabStop = false;
            // 
            // pcAlarmSwitch87
            // 
            this.pcAlarmSwitch87.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcAlarmSwitch87.Image = global::CameraViewer.Properties.Resources.AR3;
            this.pcAlarmSwitch87.Location = new System.Drawing.Point(324, 103);
            this.pcAlarmSwitch87.Name = "pcAlarmSwitch87";
            this.pcAlarmSwitch87.Size = new System.Drawing.Size(14, 14);
            this.pcAlarmSwitch87.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcAlarmSwitch87.TabIndex = 7;
            this.pcAlarmSwitch87.TabStop = false;
            // 
            // pcAlarmSwitch103
            // 
            this.pcAlarmSwitch103.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcAlarmSwitch103.Image = global::CameraViewer.Properties.Resources.AR3;
            this.pcAlarmSwitch103.Location = new System.Drawing.Point(324, 123);
            this.pcAlarmSwitch103.Name = "pcAlarmSwitch103";
            this.pcAlarmSwitch103.Size = new System.Drawing.Size(14, 14);
            this.pcAlarmSwitch103.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcAlarmSwitch103.TabIndex = 7;
            this.pcAlarmSwitch103.TabStop = false;
            // 
            // pcAlarmSwitch119
            // 
            this.pcAlarmSwitch119.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcAlarmSwitch119.Image = global::CameraViewer.Properties.Resources.AR3;
            this.pcAlarmSwitch119.Location = new System.Drawing.Point(324, 143);
            this.pcAlarmSwitch119.Name = "pcAlarmSwitch119";
            this.pcAlarmSwitch119.Size = new System.Drawing.Size(14, 14);
            this.pcAlarmSwitch119.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcAlarmSwitch119.TabIndex = 7;
            this.pcAlarmSwitch119.TabStop = false;
            // 
            // pcAlarmSwitch8
            // 
            this.pcAlarmSwitch8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcAlarmSwitch8.Image = global::CameraViewer.Properties.Resources.AR3;
            this.pcAlarmSwitch8.Location = new System.Drawing.Point(344, 3);
            this.pcAlarmSwitch8.Name = "pcAlarmSwitch8";
            this.pcAlarmSwitch8.Size = new System.Drawing.Size(14, 14);
            this.pcAlarmSwitch8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcAlarmSwitch8.TabIndex = 7;
            this.pcAlarmSwitch8.TabStop = false;
            // 
            // pcAlarmSwitch24
            // 
            this.pcAlarmSwitch24.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcAlarmSwitch24.Image = global::CameraViewer.Properties.Resources.AR3;
            this.pcAlarmSwitch24.Location = new System.Drawing.Point(344, 23);
            this.pcAlarmSwitch24.Name = "pcAlarmSwitch24";
            this.pcAlarmSwitch24.Size = new System.Drawing.Size(14, 14);
            this.pcAlarmSwitch24.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcAlarmSwitch24.TabIndex = 7;
            this.pcAlarmSwitch24.TabStop = false;
            // 
            // pcAlarmSwitch40
            // 
            this.pcAlarmSwitch40.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcAlarmSwitch40.Image = global::CameraViewer.Properties.Resources.AR3;
            this.pcAlarmSwitch40.Location = new System.Drawing.Point(344, 43);
            this.pcAlarmSwitch40.Name = "pcAlarmSwitch40";
            this.pcAlarmSwitch40.Size = new System.Drawing.Size(14, 14);
            this.pcAlarmSwitch40.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcAlarmSwitch40.TabIndex = 7;
            this.pcAlarmSwitch40.TabStop = false;
            // 
            // pcAlarmSwitch56
            // 
            this.pcAlarmSwitch56.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcAlarmSwitch56.Image = global::CameraViewer.Properties.Resources.AR3;
            this.pcAlarmSwitch56.Location = new System.Drawing.Point(344, 63);
            this.pcAlarmSwitch56.Name = "pcAlarmSwitch56";
            this.pcAlarmSwitch56.Size = new System.Drawing.Size(14, 14);
            this.pcAlarmSwitch56.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcAlarmSwitch56.TabIndex = 7;
            this.pcAlarmSwitch56.TabStop = false;
            // 
            // pcAlarmSwitch72
            // 
            this.pcAlarmSwitch72.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcAlarmSwitch72.Image = global::CameraViewer.Properties.Resources.AR3;
            this.pcAlarmSwitch72.Location = new System.Drawing.Point(344, 83);
            this.pcAlarmSwitch72.Name = "pcAlarmSwitch72";
            this.pcAlarmSwitch72.Size = new System.Drawing.Size(14, 14);
            this.pcAlarmSwitch72.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcAlarmSwitch72.TabIndex = 7;
            this.pcAlarmSwitch72.TabStop = false;
            // 
            // pcAlarmSwitch88
            // 
            this.pcAlarmSwitch88.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcAlarmSwitch88.Image = global::CameraViewer.Properties.Resources.AR3;
            this.pcAlarmSwitch88.Location = new System.Drawing.Point(344, 103);
            this.pcAlarmSwitch88.Name = "pcAlarmSwitch88";
            this.pcAlarmSwitch88.Size = new System.Drawing.Size(14, 14);
            this.pcAlarmSwitch88.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcAlarmSwitch88.TabIndex = 7;
            this.pcAlarmSwitch88.TabStop = false;
            // 
            // pcAlarmSwitch104
            // 
            this.pcAlarmSwitch104.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcAlarmSwitch104.Image = global::CameraViewer.Properties.Resources.AR3;
            this.pcAlarmSwitch104.Location = new System.Drawing.Point(344, 123);
            this.pcAlarmSwitch104.Name = "pcAlarmSwitch104";
            this.pcAlarmSwitch104.Size = new System.Drawing.Size(14, 14);
            this.pcAlarmSwitch104.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcAlarmSwitch104.TabIndex = 7;
            this.pcAlarmSwitch104.TabStop = false;
            // 
            // pcAlarmSwitch120
            // 
            this.pcAlarmSwitch120.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcAlarmSwitch120.Image = global::CameraViewer.Properties.Resources.AR3;
            this.pcAlarmSwitch120.Location = new System.Drawing.Point(344, 143);
            this.pcAlarmSwitch120.Name = "pcAlarmSwitch120";
            this.pcAlarmSwitch120.Size = new System.Drawing.Size(14, 14);
            this.pcAlarmSwitch120.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcAlarmSwitch120.TabIndex = 7;
            this.pcAlarmSwitch120.TabStop = false;
            // 
            // pcAlarmSwitch121
            // 
            this.pcAlarmSwitch121.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcAlarmSwitch121.Image = global::CameraViewer.Properties.Resources.AR3;
            this.pcAlarmSwitch121.Location = new System.Drawing.Point(364, 143);
            this.pcAlarmSwitch121.Name = "pcAlarmSwitch121";
            this.pcAlarmSwitch121.Size = new System.Drawing.Size(14, 14);
            this.pcAlarmSwitch121.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcAlarmSwitch121.TabIndex = 7;
            this.pcAlarmSwitch121.TabStop = false;
            // 
            // pcAlarmSwitch105
            // 
            this.pcAlarmSwitch105.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcAlarmSwitch105.Image = global::CameraViewer.Properties.Resources.AR3;
            this.pcAlarmSwitch105.Location = new System.Drawing.Point(364, 123);
            this.pcAlarmSwitch105.Name = "pcAlarmSwitch105";
            this.pcAlarmSwitch105.Size = new System.Drawing.Size(14, 14);
            this.pcAlarmSwitch105.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcAlarmSwitch105.TabIndex = 7;
            this.pcAlarmSwitch105.TabStop = false;
            // 
            // pcAlarmSwitch89
            // 
            this.pcAlarmSwitch89.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcAlarmSwitch89.Image = global::CameraViewer.Properties.Resources.AR3;
            this.pcAlarmSwitch89.Location = new System.Drawing.Point(364, 103);
            this.pcAlarmSwitch89.Name = "pcAlarmSwitch89";
            this.pcAlarmSwitch89.Size = new System.Drawing.Size(14, 14);
            this.pcAlarmSwitch89.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcAlarmSwitch89.TabIndex = 7;
            this.pcAlarmSwitch89.TabStop = false;
            // 
            // pcAlarmSwitch73
            // 
            this.pcAlarmSwitch73.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcAlarmSwitch73.Image = global::CameraViewer.Properties.Resources.AR3;
            this.pcAlarmSwitch73.Location = new System.Drawing.Point(364, 83);
            this.pcAlarmSwitch73.Name = "pcAlarmSwitch73";
            this.pcAlarmSwitch73.Size = new System.Drawing.Size(14, 14);
            this.pcAlarmSwitch73.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcAlarmSwitch73.TabIndex = 7;
            this.pcAlarmSwitch73.TabStop = false;
            // 
            // pcAlarmSwitch57
            // 
            this.pcAlarmSwitch57.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcAlarmSwitch57.Image = global::CameraViewer.Properties.Resources.AR3;
            this.pcAlarmSwitch57.Location = new System.Drawing.Point(364, 63);
            this.pcAlarmSwitch57.Name = "pcAlarmSwitch57";
            this.pcAlarmSwitch57.Size = new System.Drawing.Size(14, 14);
            this.pcAlarmSwitch57.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcAlarmSwitch57.TabIndex = 7;
            this.pcAlarmSwitch57.TabStop = false;
            // 
            // pcAlarmSwitch41
            // 
            this.pcAlarmSwitch41.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcAlarmSwitch41.Image = global::CameraViewer.Properties.Resources.AR3;
            this.pcAlarmSwitch41.Location = new System.Drawing.Point(364, 43);
            this.pcAlarmSwitch41.Name = "pcAlarmSwitch41";
            this.pcAlarmSwitch41.Size = new System.Drawing.Size(14, 14);
            this.pcAlarmSwitch41.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcAlarmSwitch41.TabIndex = 7;
            this.pcAlarmSwitch41.TabStop = false;
            // 
            // pcAlarmSwitch25
            // 
            this.pcAlarmSwitch25.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcAlarmSwitch25.Image = global::CameraViewer.Properties.Resources.AR3;
            this.pcAlarmSwitch25.Location = new System.Drawing.Point(364, 23);
            this.pcAlarmSwitch25.Name = "pcAlarmSwitch25";
            this.pcAlarmSwitch25.Size = new System.Drawing.Size(14, 14);
            this.pcAlarmSwitch25.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcAlarmSwitch25.TabIndex = 7;
            this.pcAlarmSwitch25.TabStop = false;
            // 
            // pcAlarmSwitch9
            // 
            this.pcAlarmSwitch9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcAlarmSwitch9.Image = global::CameraViewer.Properties.Resources.AR3;
            this.pcAlarmSwitch9.Location = new System.Drawing.Point(364, 3);
            this.pcAlarmSwitch9.Name = "pcAlarmSwitch9";
            this.pcAlarmSwitch9.Size = new System.Drawing.Size(14, 14);
            this.pcAlarmSwitch9.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcAlarmSwitch9.TabIndex = 7;
            this.pcAlarmSwitch9.TabStop = false;
            // 
            // pcAlarmSwitch10
            // 
            this.pcAlarmSwitch10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcAlarmSwitch10.Image = global::CameraViewer.Properties.Resources.AR3;
            this.pcAlarmSwitch10.Location = new System.Drawing.Point(384, 3);
            this.pcAlarmSwitch10.Name = "pcAlarmSwitch10";
            this.pcAlarmSwitch10.Size = new System.Drawing.Size(14, 14);
            this.pcAlarmSwitch10.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcAlarmSwitch10.TabIndex = 7;
            this.pcAlarmSwitch10.TabStop = false;
            // 
            // pcAlarmSwitch26
            // 
            this.pcAlarmSwitch26.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcAlarmSwitch26.Image = global::CameraViewer.Properties.Resources.AR3;
            this.pcAlarmSwitch26.Location = new System.Drawing.Point(384, 23);
            this.pcAlarmSwitch26.Name = "pcAlarmSwitch26";
            this.pcAlarmSwitch26.Size = new System.Drawing.Size(14, 14);
            this.pcAlarmSwitch26.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcAlarmSwitch26.TabIndex = 7;
            this.pcAlarmSwitch26.TabStop = false;
            // 
            // pcAlarmSwitch42
            // 
            this.pcAlarmSwitch42.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcAlarmSwitch42.Image = global::CameraViewer.Properties.Resources.AR3;
            this.pcAlarmSwitch42.Location = new System.Drawing.Point(384, 43);
            this.pcAlarmSwitch42.Name = "pcAlarmSwitch42";
            this.pcAlarmSwitch42.Size = new System.Drawing.Size(14, 14);
            this.pcAlarmSwitch42.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcAlarmSwitch42.TabIndex = 7;
            this.pcAlarmSwitch42.TabStop = false;
            // 
            // pcAlarmSwitch58
            // 
            this.pcAlarmSwitch58.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcAlarmSwitch58.Image = global::CameraViewer.Properties.Resources.AR3;
            this.pcAlarmSwitch58.Location = new System.Drawing.Point(384, 63);
            this.pcAlarmSwitch58.Name = "pcAlarmSwitch58";
            this.pcAlarmSwitch58.Size = new System.Drawing.Size(14, 14);
            this.pcAlarmSwitch58.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcAlarmSwitch58.TabIndex = 7;
            this.pcAlarmSwitch58.TabStop = false;
            // 
            // pcAlarmSwitch74
            // 
            this.pcAlarmSwitch74.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcAlarmSwitch74.Image = global::CameraViewer.Properties.Resources.AR3;
            this.pcAlarmSwitch74.Location = new System.Drawing.Point(384, 83);
            this.pcAlarmSwitch74.Name = "pcAlarmSwitch74";
            this.pcAlarmSwitch74.Size = new System.Drawing.Size(14, 14);
            this.pcAlarmSwitch74.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcAlarmSwitch74.TabIndex = 7;
            this.pcAlarmSwitch74.TabStop = false;
            // 
            // pcAlarmSwitch90
            // 
            this.pcAlarmSwitch90.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcAlarmSwitch90.Image = global::CameraViewer.Properties.Resources.AR3;
            this.pcAlarmSwitch90.Location = new System.Drawing.Point(384, 103);
            this.pcAlarmSwitch90.Name = "pcAlarmSwitch90";
            this.pcAlarmSwitch90.Size = new System.Drawing.Size(14, 14);
            this.pcAlarmSwitch90.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcAlarmSwitch90.TabIndex = 7;
            this.pcAlarmSwitch90.TabStop = false;
            // 
            // pcAlarmSwitch106
            // 
            this.pcAlarmSwitch106.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcAlarmSwitch106.Image = global::CameraViewer.Properties.Resources.AR3;
            this.pcAlarmSwitch106.Location = new System.Drawing.Point(384, 123);
            this.pcAlarmSwitch106.Name = "pcAlarmSwitch106";
            this.pcAlarmSwitch106.Size = new System.Drawing.Size(14, 14);
            this.pcAlarmSwitch106.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcAlarmSwitch106.TabIndex = 7;
            this.pcAlarmSwitch106.TabStop = false;
            // 
            // pcAlarmSwitch122
            // 
            this.pcAlarmSwitch122.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcAlarmSwitch122.Image = global::CameraViewer.Properties.Resources.AR3;
            this.pcAlarmSwitch122.Location = new System.Drawing.Point(384, 143);
            this.pcAlarmSwitch122.Name = "pcAlarmSwitch122";
            this.pcAlarmSwitch122.Size = new System.Drawing.Size(14, 14);
            this.pcAlarmSwitch122.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcAlarmSwitch122.TabIndex = 7;
            this.pcAlarmSwitch122.TabStop = false;
            // 
            // pcAlarmSwitch123
            // 
            this.pcAlarmSwitch123.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcAlarmSwitch123.Image = global::CameraViewer.Properties.Resources.AR3;
            this.pcAlarmSwitch123.Location = new System.Drawing.Point(404, 143);
            this.pcAlarmSwitch123.Name = "pcAlarmSwitch123";
            this.pcAlarmSwitch123.Size = new System.Drawing.Size(14, 14);
            this.pcAlarmSwitch123.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcAlarmSwitch123.TabIndex = 7;
            this.pcAlarmSwitch123.TabStop = false;
            // 
            // pcAlarmSwitch107
            // 
            this.pcAlarmSwitch107.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcAlarmSwitch107.Image = global::CameraViewer.Properties.Resources.AR3;
            this.pcAlarmSwitch107.Location = new System.Drawing.Point(404, 123);
            this.pcAlarmSwitch107.Name = "pcAlarmSwitch107";
            this.pcAlarmSwitch107.Size = new System.Drawing.Size(14, 14);
            this.pcAlarmSwitch107.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcAlarmSwitch107.TabIndex = 7;
            this.pcAlarmSwitch107.TabStop = false;
            // 
            // pcAlarmSwitch91
            // 
            this.pcAlarmSwitch91.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcAlarmSwitch91.Image = global::CameraViewer.Properties.Resources.AR3;
            this.pcAlarmSwitch91.Location = new System.Drawing.Point(404, 103);
            this.pcAlarmSwitch91.Name = "pcAlarmSwitch91";
            this.pcAlarmSwitch91.Size = new System.Drawing.Size(14, 14);
            this.pcAlarmSwitch91.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcAlarmSwitch91.TabIndex = 7;
            this.pcAlarmSwitch91.TabStop = false;
            // 
            // pcAlarmSwitch75
            // 
            this.pcAlarmSwitch75.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcAlarmSwitch75.Image = global::CameraViewer.Properties.Resources.AR3;
            this.pcAlarmSwitch75.Location = new System.Drawing.Point(404, 83);
            this.pcAlarmSwitch75.Name = "pcAlarmSwitch75";
            this.pcAlarmSwitch75.Size = new System.Drawing.Size(14, 14);
            this.pcAlarmSwitch75.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcAlarmSwitch75.TabIndex = 7;
            this.pcAlarmSwitch75.TabStop = false;
            // 
            // pcAlarmSwitch59
            // 
            this.pcAlarmSwitch59.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcAlarmSwitch59.Image = global::CameraViewer.Properties.Resources.AR3;
            this.pcAlarmSwitch59.Location = new System.Drawing.Point(404, 63);
            this.pcAlarmSwitch59.Name = "pcAlarmSwitch59";
            this.pcAlarmSwitch59.Size = new System.Drawing.Size(14, 14);
            this.pcAlarmSwitch59.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcAlarmSwitch59.TabIndex = 7;
            this.pcAlarmSwitch59.TabStop = false;
            // 
            // pcAlarmSwitch43
            // 
            this.pcAlarmSwitch43.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcAlarmSwitch43.Image = global::CameraViewer.Properties.Resources.AR3;
            this.pcAlarmSwitch43.Location = new System.Drawing.Point(404, 43);
            this.pcAlarmSwitch43.Name = "pcAlarmSwitch43";
            this.pcAlarmSwitch43.Size = new System.Drawing.Size(14, 14);
            this.pcAlarmSwitch43.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcAlarmSwitch43.TabIndex = 7;
            this.pcAlarmSwitch43.TabStop = false;
            // 
            // pcAlarmSwitch27
            // 
            this.pcAlarmSwitch27.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcAlarmSwitch27.Image = global::CameraViewer.Properties.Resources.AR3;
            this.pcAlarmSwitch27.Location = new System.Drawing.Point(404, 23);
            this.pcAlarmSwitch27.Name = "pcAlarmSwitch27";
            this.pcAlarmSwitch27.Size = new System.Drawing.Size(14, 14);
            this.pcAlarmSwitch27.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcAlarmSwitch27.TabIndex = 7;
            this.pcAlarmSwitch27.TabStop = false;
            // 
            // pcAlarmSwitch11
            // 
            this.pcAlarmSwitch11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcAlarmSwitch11.Image = global::CameraViewer.Properties.Resources.AR3;
            this.pcAlarmSwitch11.Location = new System.Drawing.Point(404, 3);
            this.pcAlarmSwitch11.Name = "pcAlarmSwitch11";
            this.pcAlarmSwitch11.Size = new System.Drawing.Size(14, 14);
            this.pcAlarmSwitch11.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcAlarmSwitch11.TabIndex = 7;
            this.pcAlarmSwitch11.TabStop = false;
            // 
            // pcAlarmSwitch12
            // 
            this.pcAlarmSwitch12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcAlarmSwitch12.Image = global::CameraViewer.Properties.Resources.AR3;
            this.pcAlarmSwitch12.Location = new System.Drawing.Point(424, 3);
            this.pcAlarmSwitch12.Name = "pcAlarmSwitch12";
            this.pcAlarmSwitch12.Size = new System.Drawing.Size(14, 14);
            this.pcAlarmSwitch12.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcAlarmSwitch12.TabIndex = 7;
            this.pcAlarmSwitch12.TabStop = false;
            // 
            // pcAlarmSwitch28
            // 
            this.pcAlarmSwitch28.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcAlarmSwitch28.Image = global::CameraViewer.Properties.Resources.AR3;
            this.pcAlarmSwitch28.Location = new System.Drawing.Point(424, 23);
            this.pcAlarmSwitch28.Name = "pcAlarmSwitch28";
            this.pcAlarmSwitch28.Size = new System.Drawing.Size(14, 14);
            this.pcAlarmSwitch28.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcAlarmSwitch28.TabIndex = 7;
            this.pcAlarmSwitch28.TabStop = false;
            // 
            // pcAlarmSwitch44
            // 
            this.pcAlarmSwitch44.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcAlarmSwitch44.Image = global::CameraViewer.Properties.Resources.AR3;
            this.pcAlarmSwitch44.Location = new System.Drawing.Point(424, 43);
            this.pcAlarmSwitch44.Name = "pcAlarmSwitch44";
            this.pcAlarmSwitch44.Size = new System.Drawing.Size(14, 14);
            this.pcAlarmSwitch44.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcAlarmSwitch44.TabIndex = 7;
            this.pcAlarmSwitch44.TabStop = false;
            // 
            // pcAlarmSwitch60
            // 
            this.pcAlarmSwitch60.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcAlarmSwitch60.Image = global::CameraViewer.Properties.Resources.AR3;
            this.pcAlarmSwitch60.Location = new System.Drawing.Point(424, 63);
            this.pcAlarmSwitch60.Name = "pcAlarmSwitch60";
            this.pcAlarmSwitch60.Size = new System.Drawing.Size(14, 14);
            this.pcAlarmSwitch60.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcAlarmSwitch60.TabIndex = 7;
            this.pcAlarmSwitch60.TabStop = false;
            // 
            // pcAlarmSwitch76
            // 
            this.pcAlarmSwitch76.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcAlarmSwitch76.Image = global::CameraViewer.Properties.Resources.AR3;
            this.pcAlarmSwitch76.Location = new System.Drawing.Point(424, 83);
            this.pcAlarmSwitch76.Name = "pcAlarmSwitch76";
            this.pcAlarmSwitch76.Size = new System.Drawing.Size(14, 14);
            this.pcAlarmSwitch76.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcAlarmSwitch76.TabIndex = 7;
            this.pcAlarmSwitch76.TabStop = false;
            // 
            // pcAlarmSwitch92
            // 
            this.pcAlarmSwitch92.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcAlarmSwitch92.Image = global::CameraViewer.Properties.Resources.AR3;
            this.pcAlarmSwitch92.Location = new System.Drawing.Point(424, 103);
            this.pcAlarmSwitch92.Name = "pcAlarmSwitch92";
            this.pcAlarmSwitch92.Size = new System.Drawing.Size(14, 14);
            this.pcAlarmSwitch92.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcAlarmSwitch92.TabIndex = 7;
            this.pcAlarmSwitch92.TabStop = false;
            // 
            // pcAlarmSwitch108
            // 
            this.pcAlarmSwitch108.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcAlarmSwitch108.Image = global::CameraViewer.Properties.Resources.AR3;
            this.pcAlarmSwitch108.Location = new System.Drawing.Point(424, 123);
            this.pcAlarmSwitch108.Name = "pcAlarmSwitch108";
            this.pcAlarmSwitch108.Size = new System.Drawing.Size(14, 14);
            this.pcAlarmSwitch108.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcAlarmSwitch108.TabIndex = 7;
            this.pcAlarmSwitch108.TabStop = false;
            // 
            // pcAlarmSwitch124
            // 
            this.pcAlarmSwitch124.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcAlarmSwitch124.Image = global::CameraViewer.Properties.Resources.AR3;
            this.pcAlarmSwitch124.Location = new System.Drawing.Point(424, 143);
            this.pcAlarmSwitch124.Name = "pcAlarmSwitch124";
            this.pcAlarmSwitch124.Size = new System.Drawing.Size(14, 14);
            this.pcAlarmSwitch124.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcAlarmSwitch124.TabIndex = 7;
            this.pcAlarmSwitch124.TabStop = false;
            // 
            // pcAlarmSwitch125
            // 
            this.pcAlarmSwitch125.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcAlarmSwitch125.Image = global::CameraViewer.Properties.Resources.AR3;
            this.pcAlarmSwitch125.Location = new System.Drawing.Point(444, 143);
            this.pcAlarmSwitch125.Name = "pcAlarmSwitch125";
            this.pcAlarmSwitch125.Size = new System.Drawing.Size(14, 14);
            this.pcAlarmSwitch125.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcAlarmSwitch125.TabIndex = 7;
            this.pcAlarmSwitch125.TabStop = false;
            // 
            // pcAlarmSwitch109
            // 
            this.pcAlarmSwitch109.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcAlarmSwitch109.Image = global::CameraViewer.Properties.Resources.AR3;
            this.pcAlarmSwitch109.Location = new System.Drawing.Point(444, 123);
            this.pcAlarmSwitch109.Name = "pcAlarmSwitch109";
            this.pcAlarmSwitch109.Size = new System.Drawing.Size(14, 14);
            this.pcAlarmSwitch109.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcAlarmSwitch109.TabIndex = 7;
            this.pcAlarmSwitch109.TabStop = false;
            // 
            // pcAlarmSwitch93
            // 
            this.pcAlarmSwitch93.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcAlarmSwitch93.Image = global::CameraViewer.Properties.Resources.AR3;
            this.pcAlarmSwitch93.Location = new System.Drawing.Point(444, 103);
            this.pcAlarmSwitch93.Name = "pcAlarmSwitch93";
            this.pcAlarmSwitch93.Size = new System.Drawing.Size(14, 14);
            this.pcAlarmSwitch93.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcAlarmSwitch93.TabIndex = 7;
            this.pcAlarmSwitch93.TabStop = false;
            // 
            // pcAlarmSwitch77
            // 
            this.pcAlarmSwitch77.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcAlarmSwitch77.Image = global::CameraViewer.Properties.Resources.AR3;
            this.pcAlarmSwitch77.Location = new System.Drawing.Point(444, 83);
            this.pcAlarmSwitch77.Name = "pcAlarmSwitch77";
            this.pcAlarmSwitch77.Size = new System.Drawing.Size(14, 14);
            this.pcAlarmSwitch77.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcAlarmSwitch77.TabIndex = 7;
            this.pcAlarmSwitch77.TabStop = false;
            // 
            // pcAlarmSwitch61
            // 
            this.pcAlarmSwitch61.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcAlarmSwitch61.Image = global::CameraViewer.Properties.Resources.AR3;
            this.pcAlarmSwitch61.Location = new System.Drawing.Point(444, 63);
            this.pcAlarmSwitch61.Name = "pcAlarmSwitch61";
            this.pcAlarmSwitch61.Size = new System.Drawing.Size(14, 14);
            this.pcAlarmSwitch61.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcAlarmSwitch61.TabIndex = 7;
            this.pcAlarmSwitch61.TabStop = false;
            // 
            // pcAlarmSwitch45
            // 
            this.pcAlarmSwitch45.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcAlarmSwitch45.Image = global::CameraViewer.Properties.Resources.AR3;
            this.pcAlarmSwitch45.Location = new System.Drawing.Point(444, 43);
            this.pcAlarmSwitch45.Name = "pcAlarmSwitch45";
            this.pcAlarmSwitch45.Size = new System.Drawing.Size(14, 14);
            this.pcAlarmSwitch45.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcAlarmSwitch45.TabIndex = 7;
            this.pcAlarmSwitch45.TabStop = false;
            // 
            // pcAlarmSwitch29
            // 
            this.pcAlarmSwitch29.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcAlarmSwitch29.Image = global::CameraViewer.Properties.Resources.AR3;
            this.pcAlarmSwitch29.Location = new System.Drawing.Point(444, 23);
            this.pcAlarmSwitch29.Name = "pcAlarmSwitch29";
            this.pcAlarmSwitch29.Size = new System.Drawing.Size(14, 14);
            this.pcAlarmSwitch29.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcAlarmSwitch29.TabIndex = 7;
            this.pcAlarmSwitch29.TabStop = false;
            // 
            // pcAlarmSwitch13
            // 
            this.pcAlarmSwitch13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcAlarmSwitch13.Image = global::CameraViewer.Properties.Resources.AR3;
            this.pcAlarmSwitch13.Location = new System.Drawing.Point(444, 3);
            this.pcAlarmSwitch13.Name = "pcAlarmSwitch13";
            this.pcAlarmSwitch13.Size = new System.Drawing.Size(14, 14);
            this.pcAlarmSwitch13.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcAlarmSwitch13.TabIndex = 7;
            this.pcAlarmSwitch13.TabStop = false;
            // 
            // pcAlarmSwitch14
            // 
            this.pcAlarmSwitch14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcAlarmSwitch14.Image = global::CameraViewer.Properties.Resources.AR3;
            this.pcAlarmSwitch14.Location = new System.Drawing.Point(464, 3);
            this.pcAlarmSwitch14.Name = "pcAlarmSwitch14";
            this.pcAlarmSwitch14.Size = new System.Drawing.Size(14, 14);
            this.pcAlarmSwitch14.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcAlarmSwitch14.TabIndex = 7;
            this.pcAlarmSwitch14.TabStop = false;
            // 
            // pcAlarmSwitch30
            // 
            this.pcAlarmSwitch30.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcAlarmSwitch30.Image = global::CameraViewer.Properties.Resources.AR3;
            this.pcAlarmSwitch30.Location = new System.Drawing.Point(464, 23);
            this.pcAlarmSwitch30.Name = "pcAlarmSwitch30";
            this.pcAlarmSwitch30.Size = new System.Drawing.Size(14, 14);
            this.pcAlarmSwitch30.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcAlarmSwitch30.TabIndex = 7;
            this.pcAlarmSwitch30.TabStop = false;
            // 
            // pcAlarmSwitch46
            // 
            this.pcAlarmSwitch46.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcAlarmSwitch46.Image = global::CameraViewer.Properties.Resources.AR3;
            this.pcAlarmSwitch46.Location = new System.Drawing.Point(464, 43);
            this.pcAlarmSwitch46.Name = "pcAlarmSwitch46";
            this.pcAlarmSwitch46.Size = new System.Drawing.Size(14, 14);
            this.pcAlarmSwitch46.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcAlarmSwitch46.TabIndex = 7;
            this.pcAlarmSwitch46.TabStop = false;
            // 
            // pcAlarmSwitch62
            // 
            this.pcAlarmSwitch62.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcAlarmSwitch62.Image = global::CameraViewer.Properties.Resources.AR3;
            this.pcAlarmSwitch62.Location = new System.Drawing.Point(464, 63);
            this.pcAlarmSwitch62.Name = "pcAlarmSwitch62";
            this.pcAlarmSwitch62.Size = new System.Drawing.Size(14, 14);
            this.pcAlarmSwitch62.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcAlarmSwitch62.TabIndex = 7;
            this.pcAlarmSwitch62.TabStop = false;
            // 
            // pcAlarmSwitch78
            // 
            this.pcAlarmSwitch78.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcAlarmSwitch78.Image = global::CameraViewer.Properties.Resources.AR3;
            this.pcAlarmSwitch78.Location = new System.Drawing.Point(464, 83);
            this.pcAlarmSwitch78.Name = "pcAlarmSwitch78";
            this.pcAlarmSwitch78.Size = new System.Drawing.Size(14, 14);
            this.pcAlarmSwitch78.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcAlarmSwitch78.TabIndex = 7;
            this.pcAlarmSwitch78.TabStop = false;
            // 
            // pcAlarmSwitch94
            // 
            this.pcAlarmSwitch94.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcAlarmSwitch94.Image = global::CameraViewer.Properties.Resources.AR3;
            this.pcAlarmSwitch94.Location = new System.Drawing.Point(464, 103);
            this.pcAlarmSwitch94.Name = "pcAlarmSwitch94";
            this.pcAlarmSwitch94.Size = new System.Drawing.Size(14, 14);
            this.pcAlarmSwitch94.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcAlarmSwitch94.TabIndex = 7;
            this.pcAlarmSwitch94.TabStop = false;
            // 
            // pcAlarmSwitch110
            // 
            this.pcAlarmSwitch110.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcAlarmSwitch110.Image = global::CameraViewer.Properties.Resources.AR3;
            this.pcAlarmSwitch110.Location = new System.Drawing.Point(464, 123);
            this.pcAlarmSwitch110.Name = "pcAlarmSwitch110";
            this.pcAlarmSwitch110.Size = new System.Drawing.Size(14, 14);
            this.pcAlarmSwitch110.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcAlarmSwitch110.TabIndex = 7;
            this.pcAlarmSwitch110.TabStop = false;
            // 
            // pcAlarmSwitch126
            // 
            this.pcAlarmSwitch126.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcAlarmSwitch126.Image = global::CameraViewer.Properties.Resources.AR3;
            this.pcAlarmSwitch126.Location = new System.Drawing.Point(464, 143);
            this.pcAlarmSwitch126.Name = "pcAlarmSwitch126";
            this.pcAlarmSwitch126.Size = new System.Drawing.Size(14, 14);
            this.pcAlarmSwitch126.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcAlarmSwitch126.TabIndex = 7;
            this.pcAlarmSwitch126.TabStop = false;
            // 
            // pictureBox114
            // 
            this.pictureBox114.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox114.Image = global::CameraViewer.Properties.Resources.AR3;
            this.pictureBox114.Location = new System.Drawing.Point(484, 143);
            this.pictureBox114.Name = "pictureBox114";
            this.pictureBox114.Size = new System.Drawing.Size(14, 14);
            this.pictureBox114.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox114.TabIndex = 7;
            this.pictureBox114.TabStop = false;
            // 
            // pcAlarmSwitch111
            // 
            this.pcAlarmSwitch111.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcAlarmSwitch111.Image = global::CameraViewer.Properties.Resources.AR3;
            this.pcAlarmSwitch111.Location = new System.Drawing.Point(484, 123);
            this.pcAlarmSwitch111.Name = "pcAlarmSwitch111";
            this.pcAlarmSwitch111.Size = new System.Drawing.Size(14, 14);
            this.pcAlarmSwitch111.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcAlarmSwitch111.TabIndex = 7;
            this.pcAlarmSwitch111.TabStop = false;
            // 
            // pcAlarmSwitch95
            // 
            this.pcAlarmSwitch95.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcAlarmSwitch95.Image = global::CameraViewer.Properties.Resources.AR3;
            this.pcAlarmSwitch95.Location = new System.Drawing.Point(484, 103);
            this.pcAlarmSwitch95.Name = "pcAlarmSwitch95";
            this.pcAlarmSwitch95.Size = new System.Drawing.Size(14, 14);
            this.pcAlarmSwitch95.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcAlarmSwitch95.TabIndex = 7;
            this.pcAlarmSwitch95.TabStop = false;
            // 
            // pcAlarmSwitch79
            // 
            this.pcAlarmSwitch79.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcAlarmSwitch79.Image = global::CameraViewer.Properties.Resources.AR3;
            this.pcAlarmSwitch79.Location = new System.Drawing.Point(484, 83);
            this.pcAlarmSwitch79.Name = "pcAlarmSwitch79";
            this.pcAlarmSwitch79.Size = new System.Drawing.Size(14, 14);
            this.pcAlarmSwitch79.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcAlarmSwitch79.TabIndex = 7;
            this.pcAlarmSwitch79.TabStop = false;
            // 
            // pcAlarmSwitch63
            // 
            this.pcAlarmSwitch63.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcAlarmSwitch63.Image = global::CameraViewer.Properties.Resources.AR3;
            this.pcAlarmSwitch63.Location = new System.Drawing.Point(484, 63);
            this.pcAlarmSwitch63.Name = "pcAlarmSwitch63";
            this.pcAlarmSwitch63.Size = new System.Drawing.Size(14, 14);
            this.pcAlarmSwitch63.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcAlarmSwitch63.TabIndex = 7;
            this.pcAlarmSwitch63.TabStop = false;
            // 
            // pcAlarmSwitch47
            // 
            this.pcAlarmSwitch47.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcAlarmSwitch47.Image = global::CameraViewer.Properties.Resources.AR3;
            this.pcAlarmSwitch47.Location = new System.Drawing.Point(484, 43);
            this.pcAlarmSwitch47.Name = "pcAlarmSwitch47";
            this.pcAlarmSwitch47.Size = new System.Drawing.Size(14, 14);
            this.pcAlarmSwitch47.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcAlarmSwitch47.TabIndex = 7;
            this.pcAlarmSwitch47.TabStop = false;
            // 
            // pcAlarmSwitch31
            // 
            this.pcAlarmSwitch31.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcAlarmSwitch31.Image = global::CameraViewer.Properties.Resources.AR3;
            this.pcAlarmSwitch31.Location = new System.Drawing.Point(484, 23);
            this.pcAlarmSwitch31.Name = "pcAlarmSwitch31";
            this.pcAlarmSwitch31.Size = new System.Drawing.Size(14, 14);
            this.pcAlarmSwitch31.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcAlarmSwitch31.TabIndex = 7;
            this.pcAlarmSwitch31.TabStop = false;
            // 
            // pcAlarmSwitch15
            // 
            this.pcAlarmSwitch15.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcAlarmSwitch15.Image = global::CameraViewer.Properties.Resources.AR3;
            this.pcAlarmSwitch15.Location = new System.Drawing.Point(484, 3);
            this.pcAlarmSwitch15.Name = "pcAlarmSwitch15";
            this.pcAlarmSwitch15.Size = new System.Drawing.Size(14, 14);
            this.pcAlarmSwitch15.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcAlarmSwitch15.TabIndex = 7;
            this.pcAlarmSwitch15.TabStop = false;
            // 
            // pcAlarmSwitch16
            // 
            this.pcAlarmSwitch16.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcAlarmSwitch16.Image = global::CameraViewer.Properties.Resources.AR3;
            this.pcAlarmSwitch16.Location = new System.Drawing.Point(504, 3);
            this.pcAlarmSwitch16.Name = "pcAlarmSwitch16";
            this.pcAlarmSwitch16.Size = new System.Drawing.Size(14, 14);
            this.pcAlarmSwitch16.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcAlarmSwitch16.TabIndex = 7;
            this.pcAlarmSwitch16.TabStop = false;
            // 
            // pcAlarmSwitch32
            // 
            this.pcAlarmSwitch32.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcAlarmSwitch32.Image = global::CameraViewer.Properties.Resources.AR3;
            this.pcAlarmSwitch32.Location = new System.Drawing.Point(504, 23);
            this.pcAlarmSwitch32.Name = "pcAlarmSwitch32";
            this.pcAlarmSwitch32.Size = new System.Drawing.Size(14, 14);
            this.pcAlarmSwitch32.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcAlarmSwitch32.TabIndex = 7;
            this.pcAlarmSwitch32.TabStop = false;
            // 
            // pcAlarmSwitch48
            // 
            this.pcAlarmSwitch48.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcAlarmSwitch48.Image = global::CameraViewer.Properties.Resources.AR3;
            this.pcAlarmSwitch48.Location = new System.Drawing.Point(504, 43);
            this.pcAlarmSwitch48.Name = "pcAlarmSwitch48";
            this.pcAlarmSwitch48.Size = new System.Drawing.Size(14, 14);
            this.pcAlarmSwitch48.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcAlarmSwitch48.TabIndex = 7;
            this.pcAlarmSwitch48.TabStop = false;
            // 
            // pcAlarmSwitch64
            // 
            this.pcAlarmSwitch64.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcAlarmSwitch64.Image = global::CameraViewer.Properties.Resources.AR3;
            this.pcAlarmSwitch64.Location = new System.Drawing.Point(504, 63);
            this.pcAlarmSwitch64.Name = "pcAlarmSwitch64";
            this.pcAlarmSwitch64.Size = new System.Drawing.Size(14, 14);
            this.pcAlarmSwitch64.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcAlarmSwitch64.TabIndex = 7;
            this.pcAlarmSwitch64.TabStop = false;
            // 
            // pcAlarmSwitch80
            // 
            this.pcAlarmSwitch80.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcAlarmSwitch80.Image = global::CameraViewer.Properties.Resources.AR3;
            this.pcAlarmSwitch80.Location = new System.Drawing.Point(504, 83);
            this.pcAlarmSwitch80.Name = "pcAlarmSwitch80";
            this.pcAlarmSwitch80.Size = new System.Drawing.Size(14, 14);
            this.pcAlarmSwitch80.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcAlarmSwitch80.TabIndex = 7;
            this.pcAlarmSwitch80.TabStop = false;
            // 
            // pcAlarmSwitch96
            // 
            this.pcAlarmSwitch96.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcAlarmSwitch96.Image = global::CameraViewer.Properties.Resources.AR3;
            this.pcAlarmSwitch96.Location = new System.Drawing.Point(504, 103);
            this.pcAlarmSwitch96.Name = "pcAlarmSwitch96";
            this.pcAlarmSwitch96.Size = new System.Drawing.Size(14, 14);
            this.pcAlarmSwitch96.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcAlarmSwitch96.TabIndex = 7;
            this.pcAlarmSwitch96.TabStop = false;
            // 
            // pcAlarmSwitch112
            // 
            this.pcAlarmSwitch112.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcAlarmSwitch112.Image = global::CameraViewer.Properties.Resources.AR3;
            this.pcAlarmSwitch112.Location = new System.Drawing.Point(504, 123);
            this.pcAlarmSwitch112.Name = "pcAlarmSwitch112";
            this.pcAlarmSwitch112.Size = new System.Drawing.Size(14, 14);
            this.pcAlarmSwitch112.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcAlarmSwitch112.TabIndex = 7;
            this.pcAlarmSwitch112.TabStop = false;
            // 
            // pcAlarmSwitch128
            // 
            this.pcAlarmSwitch128.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcAlarmSwitch128.Image = global::CameraViewer.Properties.Resources.AR3;
            this.pcAlarmSwitch128.Location = new System.Drawing.Point(504, 143);
            this.pcAlarmSwitch128.Name = "pcAlarmSwitch128";
            this.pcAlarmSwitch128.Size = new System.Drawing.Size(14, 14);
            this.pcAlarmSwitch128.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcAlarmSwitch128.TabIndex = 7;
            this.pcAlarmSwitch128.TabStop = false;
            // 
            // pcMap
            // 
            this.pcMap.Controls.Add(this.pictureBoxMap);
            this.pcMap.Dock = System.Windows.Forms.DockStyle.Right;
            this.pcMap.Location = new System.Drawing.Point(568, 3);
            this.pcMap.Name = "pcMap";
            this.tlpBottom.SetRowSpan(this.pcMap, 8);
            this.pcMap.Size = new System.Drawing.Size(268, 154);
            this.pcMap.TabIndex = 8;
            // 
            // pictureBoxMap
            // 
            this.pictureBoxMap.BackColor = System.Drawing.Color.Maroon;
            this.pictureBoxMap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxMap.Image = global::CameraViewer.Properties.Resources._1;
            this.pictureBoxMap.Location = new System.Drawing.Point(2, 2);
            this.pictureBoxMap.Name = "pictureBoxMap";
            this.pictureBoxMap.Size = new System.Drawing.Size(264, 150);
            this.pictureBoxMap.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxMap.TabIndex = 6;
            this.pictureBoxMap.TabStop = false;
            this.pictureBoxMap.DoubleClick += new System.EventHandler(this.pictureBoxMap_DoubleClick);
            this.pictureBoxMap.SizeChanged += new System.EventHandler(this.pictureBoxMap_SizeChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(58, 0);
            this.label1.Name = "label1";
            this.tlpBottom.SetRowSpan(this.label1, 2);
            this.label1.Size = new System.Drawing.Size(67, 14);
            this.label1.TabIndex = 9;
            this.label1.Text = "报警点:";
            // 
            // lblAlarmPosition
            // 
            this.lblAlarmPosition.AutoSize = true;
            this.lblAlarmPosition.Location = new System.Drawing.Point(131, 0);
            this.lblAlarmPosition.Name = "lblAlarmPosition";
            this.tlpBottom.SetRowSpan(this.lblAlarmPosition, 2);
            this.lblAlarmPosition.Size = new System.Drawing.Size(43, 14);
            this.lblAlarmPosition.TabIndex = 10;
            this.lblAlarmPosition.Text = "未选择";
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
            // mainMultiplexer
            // 
            this.mainMultiplexer.CellHeight = 288;
            this.mainMultiplexer.CellWidth = 352;
            this.mainMultiplexer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainMultiplexer.Location = new System.Drawing.Point(200, 55);
            this.mainMultiplexer.Name = "mainMultiplexer";
            this.mainMultiplexer.Size = new System.Drawing.Size(851, 597);
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
            this.timerUpdateIcon.Tick += new System.EventHandler(this.timerUpdateIcon_Tick);
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
            // timerCurretnTime
            // 
            this.timerCurretnTime.Enabled = true;
            this.timerCurretnTime.Interval = 500;
            this.timerCurretnTime.Tick += new System.EventHandler(this.timerCurretnTime_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1251, 869);
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
            this.dockPanelAlarm.ResumeLayout(false);
            this.dockPanel3_Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pcBottom)).EndInit();
            this.pcBottom.ResumeLayout(false);
            this.tlpBottom.ResumeLayout(false);
            this.tlpBottom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch33)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch49)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch65)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch81)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch97)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch113)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch34)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch50)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch66)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch82)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch98)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch114)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch19)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch35)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch51)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch67)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch83)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch99)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch115)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch116)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch100)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch84)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch68)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch52)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch36)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch20)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch37)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch53)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch69)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch85)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox40)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch117)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch118)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch102)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch86)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch70)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch54)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch38)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch22)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch23)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch39)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch55)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch71)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch87)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch103)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch119)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch24)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch40)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch56)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch72)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch88)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch104)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch120)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch121)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch105)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch89)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch73)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch57)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch41)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch25)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch26)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch42)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch58)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch74)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch90)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch106)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch122)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch123)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch107)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch91)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch75)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch59)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch43)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch27)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch28)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch44)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch60)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch76)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch92)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch108)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch124)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch125)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch109)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch93)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch77)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch61)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch45)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch29)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch30)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch46)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch62)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch78)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch94)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch110)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch126)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox114)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch111)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch95)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch79)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch63)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch47)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch31)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch32)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch48)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch64)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch80)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch96)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch112)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAlarmSwitch128)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcMap)).EndInit();
            this.pcMap.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMap)).EndInit();
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
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TableLayoutPanel tlpBottom;
        private DevExpress.XtraEditors.PanelControl pcBottom;
        private System.Windows.Forms.Button btnCancelAlarm;
        private System.Windows.Forms.Button btnFortify;
        private System.Windows.Forms.Button btnLinkageEnable;
        private System.Windows.Forms.Button btnLinkageDisable;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button btnFortifyDisable;
        private System.Windows.Forms.PictureBox pictureBoxMap;
        private System.Windows.Forms.PictureBox pcAlarmSwitch1;
        private System.Windows.Forms.PictureBox pcAlarmSwitch17;
        private System.Windows.Forms.PictureBox pcAlarmSwitch33;
        private System.Windows.Forms.PictureBox pcAlarmSwitch49;
        private System.Windows.Forms.PictureBox pcAlarmSwitch65;
        private System.Windows.Forms.PictureBox pcAlarmSwitch81;
        private System.Windows.Forms.PictureBox pcAlarmSwitch97;
        private System.Windows.Forms.PictureBox pcAlarmSwitch113;
        private System.Windows.Forms.PictureBox pcAlarmSwitch2;
        private System.Windows.Forms.PictureBox pcAlarmSwitch18;
        private System.Windows.Forms.PictureBox pcAlarmSwitch34;
        private System.Windows.Forms.PictureBox pcAlarmSwitch50;
        private System.Windows.Forms.PictureBox pcAlarmSwitch66;
        private System.Windows.Forms.PictureBox pcAlarmSwitch82;
        private System.Windows.Forms.PictureBox pcAlarmSwitch98;
        private System.Windows.Forms.PictureBox pcAlarmSwitch114;
        private System.Windows.Forms.PictureBox pcAlarmSwitch3;
        private System.Windows.Forms.PictureBox pcAlarmSwitch19;
        private System.Windows.Forms.PictureBox pcAlarmSwitch35;
        private System.Windows.Forms.PictureBox pcAlarmSwitch51;
        private System.Windows.Forms.PictureBox pcAlarmSwitch67;
        private System.Windows.Forms.PictureBox pcAlarmSwitch83;
        private System.Windows.Forms.PictureBox pcAlarmSwitch99;
        private System.Windows.Forms.PictureBox pcAlarmSwitch115;
        private System.Windows.Forms.PictureBox pcAlarmSwitch116;
        private System.Windows.Forms.PictureBox pcAlarmSwitch100;
        private System.Windows.Forms.PictureBox pcAlarmSwitch84;
        private System.Windows.Forms.PictureBox pcAlarmSwitch68;
        private System.Windows.Forms.PictureBox pcAlarmSwitch52;
        private System.Windows.Forms.PictureBox pcAlarmSwitch36;
        private System.Windows.Forms.PictureBox pcAlarmSwitch20;
        private System.Windows.Forms.PictureBox pcAlarmSwitch4;
        private System.Windows.Forms.PictureBox pcAlarmSwitch5;
        private System.Windows.Forms.PictureBox pcAlarmSwitch21;
        private System.Windows.Forms.PictureBox pcAlarmSwitch37;
        private System.Windows.Forms.PictureBox pcAlarmSwitch53;
        private System.Windows.Forms.PictureBox pcAlarmSwitch69;
        private System.Windows.Forms.PictureBox pcAlarmSwitch85;
        private System.Windows.Forms.PictureBox pictureBox40;
        private System.Windows.Forms.PictureBox pcAlarmSwitch117;
        private System.Windows.Forms.PictureBox pcAlarmSwitch118;
        private System.Windows.Forms.PictureBox pcAlarmSwitch102;
        private System.Windows.Forms.PictureBox pcAlarmSwitch86;
        private System.Windows.Forms.PictureBox pcAlarmSwitch70;
        private System.Windows.Forms.PictureBox pcAlarmSwitch54;
        private System.Windows.Forms.PictureBox pcAlarmSwitch38;
        private System.Windows.Forms.PictureBox pcAlarmSwitch22;
        private System.Windows.Forms.PictureBox pcAlarmSwitch6;
        private System.Windows.Forms.PictureBox pcAlarmSwitch7;
        private System.Windows.Forms.PictureBox pcAlarmSwitch23;
        private System.Windows.Forms.PictureBox pcAlarmSwitch39;
        private System.Windows.Forms.PictureBox pcAlarmSwitch55;
        private System.Windows.Forms.PictureBox pcAlarmSwitch71;
        private System.Windows.Forms.PictureBox pcAlarmSwitch87;
        private System.Windows.Forms.PictureBox pcAlarmSwitch103;
        private System.Windows.Forms.PictureBox pcAlarmSwitch119;
        private System.Windows.Forms.PictureBox pcAlarmSwitch8;
        private System.Windows.Forms.PictureBox pcAlarmSwitch24;
        private System.Windows.Forms.PictureBox pcAlarmSwitch40;
        private System.Windows.Forms.PictureBox pcAlarmSwitch56;
        private System.Windows.Forms.PictureBox pcAlarmSwitch72;
        private System.Windows.Forms.PictureBox pcAlarmSwitch88;
        private System.Windows.Forms.PictureBox pcAlarmSwitch104;
        private System.Windows.Forms.PictureBox pcAlarmSwitch120;
        private System.Windows.Forms.PictureBox pcAlarmSwitch121;
        private System.Windows.Forms.PictureBox pcAlarmSwitch105;
        private System.Windows.Forms.PictureBox pcAlarmSwitch89;
        private System.Windows.Forms.PictureBox pcAlarmSwitch73;
        private System.Windows.Forms.PictureBox pcAlarmSwitch57;
        private System.Windows.Forms.PictureBox pcAlarmSwitch41;
        private System.Windows.Forms.PictureBox pcAlarmSwitch25;
        private System.Windows.Forms.PictureBox pcAlarmSwitch9;
        private System.Windows.Forms.PictureBox pcAlarmSwitch10;
        private System.Windows.Forms.PictureBox pcAlarmSwitch26;
        private System.Windows.Forms.PictureBox pcAlarmSwitch42;
        private System.Windows.Forms.PictureBox pcAlarmSwitch58;
        private System.Windows.Forms.PictureBox pcAlarmSwitch74;
        private System.Windows.Forms.PictureBox pcAlarmSwitch90;
        private System.Windows.Forms.PictureBox pcAlarmSwitch106;
        private System.Windows.Forms.PictureBox pcAlarmSwitch122;
        private System.Windows.Forms.PictureBox pcAlarmSwitch123;
        private System.Windows.Forms.PictureBox pcAlarmSwitch107;
        private System.Windows.Forms.PictureBox pcAlarmSwitch91;
        private System.Windows.Forms.PictureBox pcAlarmSwitch75;
        private System.Windows.Forms.PictureBox pcAlarmSwitch59;
        private System.Windows.Forms.PictureBox pcAlarmSwitch43;
        private System.Windows.Forms.PictureBox pcAlarmSwitch27;
        private System.Windows.Forms.PictureBox pcAlarmSwitch11;
        private System.Windows.Forms.PictureBox pcAlarmSwitch12;
        private System.Windows.Forms.PictureBox pcAlarmSwitch28;
        private System.Windows.Forms.PictureBox pcAlarmSwitch44;
        private System.Windows.Forms.PictureBox pcAlarmSwitch60;
        private System.Windows.Forms.PictureBox pcAlarmSwitch76;
        private System.Windows.Forms.PictureBox pcAlarmSwitch92;
        private System.Windows.Forms.PictureBox pcAlarmSwitch108;
        private System.Windows.Forms.PictureBox pcAlarmSwitch124;
        private System.Windows.Forms.PictureBox pcAlarmSwitch125;
        private System.Windows.Forms.PictureBox pcAlarmSwitch109;
        private System.Windows.Forms.PictureBox pcAlarmSwitch93;
        private System.Windows.Forms.PictureBox pcAlarmSwitch77;
        private System.Windows.Forms.PictureBox pcAlarmSwitch61;
        private System.Windows.Forms.PictureBox pcAlarmSwitch45;
        private System.Windows.Forms.PictureBox pcAlarmSwitch29;
        private System.Windows.Forms.PictureBox pcAlarmSwitch13;
        private System.Windows.Forms.PictureBox pcAlarmSwitch14;
        private System.Windows.Forms.PictureBox pcAlarmSwitch30;
        private System.Windows.Forms.PictureBox pcAlarmSwitch46;
        private System.Windows.Forms.PictureBox pcAlarmSwitch62;
        private System.Windows.Forms.PictureBox pcAlarmSwitch78;
        private System.Windows.Forms.PictureBox pcAlarmSwitch94;
        private System.Windows.Forms.PictureBox pcAlarmSwitch110;
        private System.Windows.Forms.PictureBox pcAlarmSwitch126;
        private System.Windows.Forms.PictureBox pictureBox114;
        private System.Windows.Forms.PictureBox pcAlarmSwitch111;
        private System.Windows.Forms.PictureBox pcAlarmSwitch95;
        private System.Windows.Forms.PictureBox pcAlarmSwitch79;
        private System.Windows.Forms.PictureBox pcAlarmSwitch63;
        private System.Windows.Forms.PictureBox pcAlarmSwitch47;
        private System.Windows.Forms.PictureBox pcAlarmSwitch31;
        private System.Windows.Forms.PictureBox pcAlarmSwitch15;
        private System.Windows.Forms.PictureBox pcAlarmSwitch16;
        private System.Windows.Forms.PictureBox pcAlarmSwitch32;
        private System.Windows.Forms.PictureBox pcAlarmSwitch48;
        private System.Windows.Forms.PictureBox pcAlarmSwitch64;
        private System.Windows.Forms.PictureBox pcAlarmSwitch80;
        private System.Windows.Forms.PictureBox pcAlarmSwitch96;
        private System.Windows.Forms.PictureBox pcAlarmSwitch112;
        private System.Windows.Forms.PictureBox pcAlarmSwitch128;
        private DevExpress.XtraEditors.PanelControl pcMap;
        private System.Windows.Forms.ContextMenuStrip cmIcon;
        private System.Windows.Forms.ToolStripMenuItem 删除ToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblAlarmPosition;
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
        private DevExpress.XtraBars.BarButtonItem barButtonItemAlarmView;
        private DevExpress.XtraBars.BarButtonItem barButtonItemResultView;
        private DevExpress.XtraBars.BarStaticItem barStaticItem1;
        private DevExpress.XtraBars.BarStaticItem barStaticItemCurrentUser;
        private DevExpress.XtraBars.BarStaticItem barStaticItem3;
        private DevExpress.XtraBars.BarStaticItem barStaticItemCameraNo;
        private DevExpress.XtraBars.BarStaticItem barStaticItem2;
        private DevExpress.XtraBars.BarStaticItem barStaticItemDecoderNo;
        private DevExpress.XtraBars.BarStaticItem barStaticItem4;
        private DevExpress.XtraBars.BarStaticItem barStaticItemCurrentTime;
        private Timer timerCurretnTime;
        
    }
}