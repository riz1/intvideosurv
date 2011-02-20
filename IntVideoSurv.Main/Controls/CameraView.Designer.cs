namespace CameraViewer.Controls
{
    partial class CameraView
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CameraView));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.panNav1 = new Damany.Controls.PanNav();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            this.cameraNav1 = new Damany.Controls.CameraNav();
            this.navBarControl1 = new DevExpress.XtraNavBar.NavBarControl();
            this.navBarItem1 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem2 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem3 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem4 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem5 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem6 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem7 = new DevExpress.XtraNavBar.NavBarItem();
            this.xtraTabControl2 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPageCameraList = new DevExpress.XtraTab.XtraTabPage();
            this.trCamera = new System.Windows.Forms.TreeView();
            this.imageListForTreeView = new System.Windows.Forms.ImageList(this.components);
            this.xtraTabPageDecoderList = new DevExpress.XtraTab.XtraTabPage();
            this.tvSynGroup = new System.Windows.Forms.TreeView();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            this.xtraTabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl2)).BeginInit();
            this.xtraTabControl2.SuspendLayout();
            this.xtraTabPageCameraList.SuspendLayout();
            this.xtraTabPageDecoderList.SuspendLayout();
            this.SuspendLayout();
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
            // xtraTabControl1
            // 
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.xtraTabControl1.Location = new System.Drawing.Point(0, 299);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
            this.xtraTabControl1.Size = new System.Drawing.Size(213, 188);
            this.xtraTabControl1.TabIndex = 28;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1,
            this.xtraTabPage2});
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.panNav1);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(207, 160);
            this.xtraTabPage1.Text = "云台";
            // 
            // panNav1
            // 
            this.panNav1.Location = new System.Drawing.Point(3, 0);
            this.panNav1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.panNav1.Name = "panNav1";
            this.panNav1.Size = new System.Drawing.Size(169, 162);
            this.panNav1.TabIndex = 0;
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.Controls.Add(this.cameraNav1);
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Size = new System.Drawing.Size(207, 160);
            this.xtraTabPage2.Text = "相机";
            // 
            // cameraNav1
            // 
            this.cameraNav1.Location = new System.Drawing.Point(0, 0);
            this.cameraNav1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.cameraNav1.Name = "cameraNav1";
            this.cameraNav1.Size = new System.Drawing.Size(204, 149);
            this.cameraNav1.TabIndex = 0;
            // 
            // navBarControl1
            // 
            this.navBarControl1.ActiveGroup = null;
            this.navBarControl1.ContentButtonHint = null;
            this.navBarControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navBarControl1.Items.AddRange(new DevExpress.XtraNavBar.NavBarItem[] {
            this.navBarItem1,
            this.navBarItem2,
            this.navBarItem3,
            this.navBarItem4,
            this.navBarItem5,
            this.navBarItem6,
            this.navBarItem7});
            this.navBarControl1.LargeImages = this.imageList1;
            this.navBarControl1.Location = new System.Drawing.Point(0, 0);
            this.navBarControl1.Name = "navBarControl1";
            this.navBarControl1.OptionsNavPane.ExpandedWidth = 140;
            this.navBarControl1.Size = new System.Drawing.Size(213, 299);
            this.navBarControl1.SmallImages = this.imageList2;
            this.navBarControl1.StoreDefaultPaintStyleName = true;
            this.navBarControl1.TabIndex = 29;
            this.navBarControl1.Text = "navBarControl1";
            // 
            // navBarItem1
            // 
            this.navBarItem1.Caption = "Inbox";
            this.navBarItem1.LargeImageIndex = 0;
            this.navBarItem1.Name = "navBarItem1";
            this.navBarItem1.SmallImageIndex = 0;
            // 
            // navBarItem2
            // 
            this.navBarItem2.Caption = "Outbox";
            this.navBarItem2.LargeImageIndex = 1;
            this.navBarItem2.Name = "navBarItem2";
            this.navBarItem2.SmallImageIndex = 1;
            // 
            // navBarItem3
            // 
            this.navBarItem3.Caption = "Sent Items";
            this.navBarItem3.Enabled = false;
            this.navBarItem3.LargeImageIndex = 2;
            this.navBarItem3.Name = "navBarItem3";
            this.navBarItem3.SmallImageIndex = 2;
            // 
            // navBarItem4
            // 
            this.navBarItem4.Caption = "Deleted Items";
            this.navBarItem4.Enabled = false;
            this.navBarItem4.LargeImageIndex = 3;
            this.navBarItem4.Name = "navBarItem4";
            this.navBarItem4.SmallImageIndex = 3;
            // 
            // navBarItem5
            // 
            this.navBarItem5.Caption = "Report";
            this.navBarItem5.LargeImageIndex = 4;
            this.navBarItem5.Name = "navBarItem5";
            this.navBarItem5.SmallImageIndex = 4;
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
            // xtraTabControl2
            // 
            this.xtraTabControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl2.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControl2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.xtraTabControl2.Name = "xtraTabControl2";
            this.xtraTabControl2.SelectedTabPage = this.xtraTabPageCameraList;
            this.xtraTabControl2.Size = new System.Drawing.Size(213, 299);
            this.xtraTabControl2.TabIndex = 30;
            this.xtraTabControl2.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPageCameraList,
            this.xtraTabPageDecoderList});
            this.xtraTabControl2.SelectedPageChanging += new DevExpress.XtraTab.TabPageChangingEventHandler(this.xtraTabControl2_SelectedPageChanging);
            // 
            // xtraTabPageCameraList
            // 
            this.xtraTabPageCameraList.Controls.Add(this.trCamera);
            this.xtraTabPageCameraList.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.xtraTabPageCameraList.Name = "xtraTabPageCameraList";
            this.xtraTabPageCameraList.Size = new System.Drawing.Size(207, 271);
            this.xtraTabPageCameraList.Text = "摄像头";
            // 
            // trCamera
            // 
            this.trCamera.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trCamera.ImageIndex = 0;
            this.trCamera.ImageList = this.imageListForTreeView;
            this.trCamera.Location = new System.Drawing.Point(0, 0);
            this.trCamera.Name = "trCamera";
            this.trCamera.SelectedImageKey = "selected.bmp";
            this.trCamera.Size = new System.Drawing.Size(207, 271);
            this.trCamera.TabIndex = 1;
            this.trCamera.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.trCamera_NodeMouseDoubleClick);
            this.trCamera.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.trCamera_NodeMouseClick);
            // 
            // imageListForTreeView
            // 
            this.imageListForTreeView.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListForTreeView.ImageStream")));
            this.imageListForTreeView.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListForTreeView.Images.SetKeyName(0, "tree.bmp");
            this.imageListForTreeView.Images.SetKeyName(1, "videosrv.bmp");
            this.imageListForTreeView.Images.SetKeyName(2, "CAM2.BMP");
            this.imageListForTreeView.Images.SetKeyName(3, "GroupSwitch.bmp");
            this.imageListForTreeView.Images.SetKeyName(4, "ProgSwitch.bmp");
            this.imageListForTreeView.Images.SetKeyName(5, "SynSwitch.bmp");
            this.imageListForTreeView.Images.SetKeyName(6, "cam2b.bmp");
            this.imageListForTreeView.Images.SetKeyName(7, "CAM3.BMP");
            this.imageListForTreeView.Images.SetKeyName(8, "cam3b.bmp");
            this.imageListForTreeView.Images.SetKeyName(9, "selected.bmp");
            this.imageListForTreeView.Images.SetKeyName(10, "Alarm_Host.bmp");
            // 
            // xtraTabPageDecoderList
            // 
            this.xtraTabPageDecoderList.Controls.Add(this.tvSynGroup);
            this.xtraTabPageDecoderList.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.xtraTabPageDecoderList.Name = "xtraTabPageDecoderList";
            this.xtraTabPageDecoderList.Size = new System.Drawing.Size(207, 271);
            this.xtraTabPageDecoderList.Text = "解码器";
            // 
            // tvSynGroup
            // 
            this.tvSynGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvSynGroup.ImageKey = "CAM2.BMP";
            this.tvSynGroup.ImageList = this.imageListForTreeView;
            this.tvSynGroup.Location = new System.Drawing.Point(0, 0);
            this.tvSynGroup.Name = "tvSynGroup";
            this.tvSynGroup.SelectedImageKey = "selected.bmp";
            this.tvSynGroup.Size = new System.Drawing.Size(207, 271);
            this.tvSynGroup.TabIndex = 1;
            this.tvSynGroup.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvSynGroup_NodeMouseDoubleClick);
            this.tvSynGroup.DoubleClick += new System.EventHandler(this.tvSynGroup_DoubleClick);
            this.tvSynGroup.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvSynGroup_NodeMouseClick);
            // 
            // CameraView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.xtraTabControl2);
            this.Controls.Add(this.navBarControl1);
            this.Controls.Add(this.xtraTabControl1);
            this.Name = "CameraView";
            this.Size = new System.Drawing.Size(213, 487);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            this.xtraTabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl2)).EndInit();
            this.xtraTabControl2.ResumeLayout(false);
            this.xtraTabPageCameraList.ResumeLayout(false);
            this.xtraTabPageDecoderList.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ImageList imageList2;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
        private DevExpress.XtraNavBar.NavBarControl navBarControl1;
        private DevExpress.XtraNavBar.NavBarItem navBarItem6;
        private DevExpress.XtraNavBar.NavBarItem navBarItem7;
        private DevExpress.XtraNavBar.NavBarItem navBarItem5;
        private DevExpress.XtraNavBar.NavBarItem navBarItem1;
        private DevExpress.XtraNavBar.NavBarItem navBarItem2;
        private DevExpress.XtraNavBar.NavBarItem navBarItem3;
        private DevExpress.XtraNavBar.NavBarItem navBarItem4;
        private Damany.Controls.PanNav panNav1;
        private Damany.Controls.CameraNav cameraNav1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPageDecoderList;
        private DevExpress.XtraTab.XtraTabPage xtraTabPageCameraList;
        public System.Windows.Forms.TreeView tvSynGroup;
        public System.Windows.Forms.TreeView trCamera;
        public DevExpress.XtraTab.XtraTabControl xtraTabControl2;
        private System.Windows.Forms.ImageList imageListForTreeView;
    }
}
