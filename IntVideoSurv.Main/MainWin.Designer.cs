namespace CameraViewer
{
    partial class MainWin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWin));
            this.cameraImageList = new System.Windows.Forms.ImageList(this.components);
            this.tmWait = new System.Windows.Forms.Timer(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbSaveImg = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbCallBackVideo = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tmMaxTime = new System.Windows.Forms.Timer(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.pnLeft = new System.Windows.Forms.Panel();
            this.pnPan = new System.Windows.Forms.Panel();
            this.pnCam = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.camNav1 = new Damany.Controls.CamNav();
            this.eightWayNavigator1 = new Damany.Controls.EightWayNavigator();
            this.tsbSystemConfig = new System.Windows.Forms.ToolStripButton();
            this.tsbConnect = new System.Windows.Forms.ToolStripButton();
            this.tsbDisconnect = new System.Windows.Forms.ToolStripButton();
            this.tsbQueryHistory = new System.Windows.Forms.ToolStripButton();
            this.tsbSetMonitorArea = new System.Windows.Forms.ToolStripButton();
            this.toolPlayAD = new System.Windows.Forms.ToolStripButton();
            this.toolExit = new System.Windows.Forms.ToolStripButton();
            this.pnTop = new System.Windows.Forms.Panel();
            this.multiplexer1 = new CameraViewer.Multiplexer();
            this.camerasTree = new CameraViewer.CamerasTreeView();
            this.toolStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.pnLeft.SuspendLayout();
            this.pnPan.SuspendLayout();
            this.pnCam.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cameraImageList
            // 
            this.cameraImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("cameraImageList.ImageStream")));
            this.cameraImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.cameraImageList.Images.SetKeyName(0, "Cameras16.gif");
            this.cameraImageList.Images.SetKeyName(1, "Camera16.gif");
            this.cameraImageList.Images.SetKeyName(2, "spanner16.gif");
            this.cameraImageList.Images.SetKeyName(3, "property.gif");
            this.cameraImageList.Images.SetKeyName(4, "ip16.gif");
            this.cameraImageList.Images.SetKeyName(5, "id16.gif");
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbSystemConfig,
            this.tsbConnect,
            this.toolStripSeparator4,
            this.toolStripSeparator2,
            this.tsbDisconnect,
            this.toolStripSeparator5,
            this.tsbSaveImg,
            this.toolStripSeparator1,
            this.tsbQueryHistory,
            this.toolStripSeparator3,
            this.tsbSetMonitorArea,
            this.toolStripSeparator6,
            this.tsbCallBackVideo,
            this.toolPlayAD,
            this.toolStripSeparator7,
            this.toolExit});
            this.toolStrip1.Location = new System.Drawing.Point(0, 66);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(820, 25);
            this.toolStrip1.TabIndex = 23;
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            this.toolStripSeparator4.Visible = false;
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            this.toolStripSeparator5.Visible = false;
            // 
            // tsbSaveImg
            // 
            this.tsbSaveImg.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.tsbSaveImg.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSaveImg.Name = "tsbSaveImg";
            this.tsbSaveImg.Size = new System.Drawing.Size(59, 22);
            this.tsbSaveImg.Text = "抓拍图片";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbCallBackVideo
            // 
            this.tsbCallBackVideo.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.tsbCallBackVideo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCallBackVideo.Name = "tsbCallBackVideo";
            this.tsbCallBackVideo.Size = new System.Drawing.Size(59, 22);
            this.tsbCallBackVideo.Text = "视频回放";
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 25);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Cameras16.gif");
            this.imageList1.Images.SetKeyName(1, "Camera16.gif");
            this.imageList1.Images.SetKeyName(2, "spanner16.gif");
            this.imageList1.Images.SetKeyName(3, "property.gif");
            this.imageList1.Images.SetKeyName(4, "ip16.gif");
            this.imageList1.Images.SetKeyName(5, "id16.gif");
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(147, 26);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(146, 22);
            this.toolStripMenuItem1.Text = "修改相机信息";
            // 
            // pnLeft
            // 
            this.pnLeft.Controls.Add(this.pnCam);
            this.pnLeft.Controls.Add(this.pnPan);
            this.pnLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnLeft.Location = new System.Drawing.Point(0, 91);
            this.pnLeft.Name = "pnLeft";
            this.pnLeft.Size = new System.Drawing.Size(163, 464);
            this.pnLeft.TabIndex = 25;
            // 
            // pnPan
            // 
            this.pnPan.Controls.Add(this.tabControl1);
            this.pnPan.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnPan.Location = new System.Drawing.Point(0, 287);
            this.pnPan.Name = "pnPan";
            this.pnPan.Size = new System.Drawing.Size(163, 177);
            this.pnPan.TabIndex = 0;
            // 
            // pnCam
            // 
            this.pnCam.Controls.Add(this.camerasTree);
            this.pnCam.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnCam.Location = new System.Drawing.Point(0, 0);
            this.pnCam.Name = "pnCam";
            this.pnCam.Size = new System.Drawing.Size(163, 287);
            this.pnCam.TabIndex = 1;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(4, 7);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(153, 191);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.eightWayNavigator1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(145, 165);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "云台";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.camNav1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(145, 165);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "镜头";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // camNav1
            // 
            this.camNav1.Location = new System.Drawing.Point(8, 3);
            this.camNav1.Name = "camNav1";
            this.camNav1.Size = new System.Drawing.Size(131, 109);
            this.camNav1.TabIndex = 1;
            // 
            // eightWayNavigator1
            // 
            this.eightWayNavigator1.Location = new System.Drawing.Point(4, 6);
            this.eightWayNavigator1.Name = "eightWayNavigator1";
            this.eightWayNavigator1.Size = new System.Drawing.Size(127, 135);
            this.eightWayNavigator1.TabIndex = 0;
            // 
            // tsbSystemConfig
            // 
            this.tsbSystemConfig.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.tsbSystemConfig.Image = global::CameraViewer.Properties.Resources.syss;
            this.tsbSystemConfig.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSystemConfig.Name = "tsbSystemConfig";
            this.tsbSystemConfig.Size = new System.Drawing.Size(75, 22);
            this.tsbSystemConfig.Text = "系统设置";
            // 
            // tsbConnect
            // 
            this.tsbConnect.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.tsbConnect.Image = ((System.Drawing.Image)(resources.GetObject("tsbConnect.Image")));
            this.tsbConnect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbConnect.Name = "tsbConnect";
            this.tsbConnect.Size = new System.Drawing.Size(51, 22);
            this.tsbConnect.Text = "连接";
            this.tsbConnect.Visible = false;
            // 
            // tsbDisconnect
            // 
            this.tsbDisconnect.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.tsbDisconnect.Image = ((System.Drawing.Image)(resources.GetObject("tsbDisconnect.Image")));
            this.tsbDisconnect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDisconnect.Name = "tsbDisconnect";
            this.tsbDisconnect.Size = new System.Drawing.Size(51, 22);
            this.tsbDisconnect.Text = "断开";
            this.tsbDisconnect.Visible = false;
            // 
            // tsbQueryHistory
            // 
            this.tsbQueryHistory.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.tsbQueryHistory.Image = ((System.Drawing.Image)(resources.GetObject("tsbQueryHistory.Image")));
            this.tsbQueryHistory.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbQueryHistory.Name = "tsbQueryHistory";
            this.tsbQueryHistory.Size = new System.Drawing.Size(75, 22);
            this.tsbQueryHistory.Text = "记录查询";
            // 
            // tsbSetMonitorArea
            // 
            this.tsbSetMonitorArea.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.tsbSetMonitorArea.Image = ((System.Drawing.Image)(resources.GetObject("tsbSetMonitorArea.Image")));
            this.tsbSetMonitorArea.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSetMonitorArea.Name = "tsbSetMonitorArea";
            this.tsbSetMonitorArea.Size = new System.Drawing.Size(51, 22);
            this.tsbSetMonitorArea.Text = "布防";
            // 
            // toolPlayAD
            // 
            this.toolPlayAD.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.toolPlayAD.Image = ((System.Drawing.Image)(resources.GetObject("toolPlayAD.Image")));
            this.toolPlayAD.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolPlayAD.Name = "toolPlayAD";
            this.toolPlayAD.Size = new System.Drawing.Size(75, 22);
            this.toolPlayAD.Text = "录像播放";
            // 
            // toolExit
            // 
            this.toolExit.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.toolExit.Image = ((System.Drawing.Image)(resources.GetObject("toolExit.Image")));
            this.toolExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolExit.Name = "toolExit";
            this.toolExit.Size = new System.Drawing.Size(51, 22);
            this.toolExit.Text = "关闭";
            // 
            // pnTop
            // 
            this.pnTop.BackgroundImage = global::CameraViewer.Properties.Resources.logo_2;
            this.pnTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnTop.Location = new System.Drawing.Point(0, 0);
            this.pnTop.Name = "pnTop";
            this.pnTop.Size = new System.Drawing.Size(820, 66);
            this.pnTop.TabIndex = 0;
            // 
            // multiplexer1
            // 
            this.multiplexer1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.multiplexer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.multiplexer1.Location = new System.Drawing.Point(163, 91);
            this.multiplexer1.Name = "multiplexer1";
            this.multiplexer1.ParentWin = null;
            this.multiplexer1.Size = new System.Drawing.Size(657, 464);
            this.multiplexer1.TabIndex = 27;
            // 
            // camerasTree
            // 
            this.camerasTree.CameraImage = 2;
            this.camerasTree.CameraSelectedImage = 2;
            this.camerasTree.CamerasFolderSelectedImage = 1;
            this.camerasTree.Dock = System.Windows.Forms.DockStyle.Left;
            this.camerasTree.HideSelection = false;
            this.camerasTree.Location = new System.Drawing.Point(0, 0);
            this.camerasTree.Name = "camerasTree";
            this.camerasTree.Size = new System.Drawing.Size(176, 287);
            this.camerasTree.Sorted = true;
            this.camerasTree.TabIndex = 1;
            this.camerasTree.ViewImage = 5;
            this.camerasTree.ViewSelectedImage = 5;
            this.camerasTree.ViewsFolderImage = 3;
            this.camerasTree.ViewsFolderSelectedImage = 4;
            this.camerasTree.DoubleClick += new System.EventHandler(this.camerasTree_DoubleClick);
            // 
            // MainWin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(820, 555);
            this.Controls.Add(this.multiplexer1);
            this.Controls.Add(this.pnLeft);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.pnTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "MainWin";
            this.Text = "MainWin";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainWin_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainWin_KeyDown);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.pnLeft.ResumeLayout(false);
            this.pnPan.ResumeLayout(false);
            this.pnCam.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnTop;
        private System.Windows.Forms.ImageList cameraImageList;
        private System.Windows.Forms.Timer tmWait;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbSystemConfig;
        private System.Windows.Forms.ToolStripButton tsbConnect;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsbDisconnect;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton tsbSaveImg;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbQueryHistory;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton tsbSetMonitorArea;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton tsbCallBackVideo;
        private System.Windows.Forms.ToolStripButton toolPlayAD;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripButton toolExit;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Timer tmMaxTime;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.Panel pnLeft;
        private Multiplexer multiplexer1;
        private System.Windows.Forms.Panel pnCam;
        private System.Windows.Forms.Panel pnPan;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private Damany.Controls.EightWayNavigator eightWayNavigator1;
        private Damany.Controls.CamNav camNav1;
        private CamerasTreeView camerasTree;
    }
}