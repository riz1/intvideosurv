namespace CameraViewer.Controls
{
    partial class CameraPlay
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CameraPlay));
            this.pnVideo = new System.Windows.Forms.Panel();
            this.cameraNav1 = new Damany.Controls.CameraNav();
            this.camNav1 = new Damany.Controls.CamNav();
            this.eightWayNavigator1 = new Damany.Controls.EightWayNavigator();
            this.panNav1 = new Damany.Controls.PanNav();
            this.panasonicCameraSetupPage1 = new SANYO.PanasonicCameraSetupPage();
            this.mjpegSourcePage1 = new mjpeg.MJPEGSourcePage();
            this.jpegSourcePage1 = new jpeg.JPEGSourcePage();
            this.hcVideoServiceSourceSetting1 = new HCVideoService.HCVideoServiceSourceSetting();
            this.cameraDescription1 = new CameraViewer.CameraDescription();
            this.hcVideoServiceSourceSetting2 = new HCVideoService.HCVideoServiceSourceSetting();
            this.cameraDescription2 = new CameraViewer.CameraDescription();
            this.cameraSettings1 = new CameraViewer.CameraSettings();
            this.camerasTreeView1 = new CameraViewer.CamerasTreeView();
            this.cameraWindow1 = new CameraViewer.CameraWindow();
            this.cameraView1 = new CameraViewer.Controls.CameraView();
            this.deviceDescription1 = new CameraViewer.Forms.DeviceDescription();
            this.multiplayer1 = new CameraViewer.Multiplayer();
            this.multiplexer1 = new CameraViewer.Multiplexer();
            this.viewDescription1 = new CameraViewer.ViewDescription();
            this.viewGrid1 = new CameraViewer.ViewGrid();
            this.viewStructure1 = new CameraViewer.ViewStructure();
            this.pnVideo.SuspendLayout();
            this.multiplayer1.SuspendLayout();
            this.multiplexer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnVideo
            // 
            this.pnVideo.Controls.Add(this.multiplayer1);
            this.pnVideo.Controls.Add(this.deviceDescription1);
            this.pnVideo.Controls.Add(this.cameraView1);
            this.pnVideo.Controls.Add(this.cameraWindow1);
            this.pnVideo.Controls.Add(this.camerasTreeView1);
            this.pnVideo.Controls.Add(this.cameraSettings1);
            this.pnVideo.Controls.Add(this.cameraDescription2);
            this.pnVideo.Controls.Add(this.hcVideoServiceSourceSetting2);
            this.pnVideo.Controls.Add(this.cameraDescription1);
            this.pnVideo.Controls.Add(this.hcVideoServiceSourceSetting1);
            this.pnVideo.Controls.Add(this.jpegSourcePage1);
            this.pnVideo.Controls.Add(this.mjpegSourcePage1);
            this.pnVideo.Controls.Add(this.panasonicCameraSetupPage1);
            this.pnVideo.Controls.Add(this.panNav1);
            this.pnVideo.Controls.Add(this.eightWayNavigator1);
            this.pnVideo.Controls.Add(this.camNav1);
            this.pnVideo.Controls.Add(this.cameraNav1);
            this.pnVideo.Location = new System.Drawing.Point(4, 4);
            this.pnVideo.Name = "pnVideo";
            this.pnVideo.Size = new System.Drawing.Size(259, 162);
            this.pnVideo.TabIndex = 0;
            this.pnVideo.DoubleClick += new System.EventHandler(this.pnVideo_DoubleClick);
            this.pnVideo.Click += new System.EventHandler(this.pnVideo_Click);
            // 
            // cameraNav1
            // 
            this.cameraNav1.Location = new System.Drawing.Point(0, 0);
            this.cameraNav1.Name = "cameraNav1";
            this.cameraNav1.Size = new System.Drawing.Size(191, 140);
            this.cameraNav1.TabIndex = 0;
            // 
            // camNav1
            // 
            this.camNav1.Location = new System.Drawing.Point(8, 8);
            this.camNav1.Name = "camNav1";
            this.camNav1.Size = new System.Drawing.Size(131, 101);
            this.camNav1.TabIndex = 1;
            // 
            // eightWayNavigator1
            // 
            this.eightWayNavigator1.Location = new System.Drawing.Point(16, 16);
            this.eightWayNavigator1.Name = "eightWayNavigator1";
            this.eightWayNavigator1.Size = new System.Drawing.Size(127, 125);
            this.eightWayNavigator1.TabIndex = 2;
            // 
            // panNav1
            // 
            this.panNav1.Location = new System.Drawing.Point(0, 0);
            this.panNav1.Name = "panNav1";
            this.panNav1.Size = new System.Drawing.Size(169, 162);
            this.panNav1.TabIndex = 3;
            // 
            // panasonicCameraSetupPage1
            // 
            this.panasonicCameraSetupPage1.CameraList = null;
            this.panasonicCameraSetupPage1.ListCam = null;
            this.panasonicCameraSetupPage1.Location = new System.Drawing.Point(0, 0);
            this.panasonicCameraSetupPage1.Name = "panasonicCameraSetupPage1";
            this.panasonicCameraSetupPage1.Size = new System.Drawing.Size(349, 303);
            this.panasonicCameraSetupPage1.TabIndex = 4;
            // 
            // mjpegSourcePage1
            // 
            this.mjpegSourcePage1.CameraList = null;
            this.mjpegSourcePage1.Location = new System.Drawing.Point(0, 0);
            this.mjpegSourcePage1.Name = "mjpegSourcePage1";
            this.mjpegSourcePage1.Size = new System.Drawing.Size(300, 150);
            this.mjpegSourcePage1.TabIndex = 5;
            // 
            // jpegSourcePage1
            // 
            this.jpegSourcePage1.CameraList = null;
            this.jpegSourcePage1.Location = new System.Drawing.Point(0, 0);
            this.jpegSourcePage1.Name = "jpegSourcePage1";
            this.jpegSourcePage1.Size = new System.Drawing.Size(300, 150);
            this.jpegSourcePage1.TabIndex = 6;
            // 
            // hcVideoServiceSourceSetting1
            // 
            this.hcVideoServiceSourceSetting1.CameraList = null;
            this.hcVideoServiceSourceSetting1.ListCam = null;
            this.hcVideoServiceSourceSetting1.Location = new System.Drawing.Point(0, 0);
            this.hcVideoServiceSourceSetting1.Name = "hcVideoServiceSourceSetting1";
            this.hcVideoServiceSourceSetting1.Size = new System.Drawing.Size(1045, 317);
            this.hcVideoServiceSourceSetting1.TabIndex = 7;
            // 
            // cameraDescription1
            // 
            this.cameraDescription1.Camera = null;
            this.cameraDescription1.ControlHeight = 0;
            this.cameraDescription1.ControlWidth = 0;
            this.cameraDescription1.Location = new System.Drawing.Point(0, 0);
            this.cameraDescription1.Name = "cameraDescription1";
            this.cameraDescription1.Size = new System.Drawing.Size(320, 180);
            this.cameraDescription1.TabIndex = 8;
            this.cameraDescription1.VideoProviders = null;
            // 
            // hcVideoServiceSourceSetting2
            // 
            this.hcVideoServiceSourceSetting2.CameraList = null;
            this.hcVideoServiceSourceSetting2.ListCam = null;
            this.hcVideoServiceSourceSetting2.Location = new System.Drawing.Point(0, 0);
            this.hcVideoServiceSourceSetting2.Name = "hcVideoServiceSourceSetting2";
            this.hcVideoServiceSourceSetting2.Size = new System.Drawing.Size(1045, 317);
            this.hcVideoServiceSourceSetting2.TabIndex = 9;
            // 
            // cameraDescription2
            // 
            this.cameraDescription2.Camera = null;
            this.cameraDescription2.ControlHeight = 0;
            this.cameraDescription2.ControlWidth = 0;
            this.cameraDescription2.Location = new System.Drawing.Point(0, 0);
            this.cameraDescription2.Name = "cameraDescription2";
            this.cameraDescription2.Size = new System.Drawing.Size(320, 180);
            this.cameraDescription2.TabIndex = 10;
            this.cameraDescription2.VideoProviders = null;
            // 
            // cameraSettings1
            // 
            this.cameraSettings1.Camera = null;
            this.cameraSettings1.ControlHeight = 0;
            this.cameraSettings1.ControlWidth = 0;
            this.cameraSettings1.Location = new System.Drawing.Point(0, 0);
            this.cameraSettings1.Name = "cameraSettings1";
            this.cameraSettings1.Provider = null;
            this.cameraSettings1.Size = new System.Drawing.Size(475, 243);
            this.cameraSettings1.TabIndex = 11;
            // 
            // camerasTreeView1
            // 
            this.camerasTreeView1.Location = new System.Drawing.Point(8, 8);
            this.camerasTreeView1.Name = "camerasTreeView1";
            this.camerasTreeView1.Size = new System.Drawing.Size(121, 97);
            this.camerasTreeView1.TabIndex = 12;
            // 
            // cameraWindow1
            // 
            this.cameraWindow1.Camera = null;
            this.cameraWindow1.ClickMe = false;
            this.cameraWindow1.Location = new System.Drawing.Point(16, 16);
            this.cameraWindow1.Name = "cameraWindow1";
            this.cameraWindow1.Size = new System.Drawing.Size(75, 23);
            this.cameraWindow1.TabIndex = 13;
            this.cameraWindow1.Text = "cameraWindow1";
            // 
            // cameraView1
            // 
            this.cameraView1.Location = new System.Drawing.Point(0, 0);
            this.cameraView1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cameraView1.Name = "cameraView1";
            this.cameraView1.Size = new System.Drawing.Size(214, 487);
            this.cameraView1.TabIndex = 14;
            // 
            // deviceDescription1
            // 
            this.deviceDescription1.DeviceEntity = ((IntVideoSurv.Entity.DeviceInfo)(resources.GetObject("deviceDescription1.DeviceEntity")));
            this.deviceDescription1.Location = new System.Drawing.Point(0, 0);
            this.deviceDescription1.Name = "deviceDescription1";
            this.deviceDescription1.Size = new System.Drawing.Size(449, 171);
            this.deviceDescription1.TabIndex = 15;
            this.deviceDescription1.VideoProviders = null;
            // 
            // multiplayer1
            // 
            this.multiplayer1.Controls.Add(this.multiplexer1);
            this.multiplayer1.Location = new System.Drawing.Point(0, 0);
            this.multiplayer1.Name = "multiplayer1";
            this.multiplayer1.Size = new System.Drawing.Size(424, 376);
            this.multiplayer1.TabIndex = 16;
            // 
            // multiplexer1
            // 
            this.multiplexer1.Controls.Add(this.viewStructure1);
            this.multiplexer1.Controls.Add(this.viewGrid1);
            this.multiplexer1.Controls.Add(this.viewDescription1);
            this.multiplexer1.Location = new System.Drawing.Point(0, 0);
            this.multiplexer1.Name = "multiplexer1";
            this.multiplexer1.Size = new System.Drawing.Size(424, 376);
            this.multiplexer1.TabIndex = 0;
            // 
            // viewDescription1
            // 
            this.viewDescription1.ControlHeight = 0;
            this.viewDescription1.ControlWidth = 0;
            this.viewDescription1.Location = new System.Drawing.Point(0, 0);
            this.viewDescription1.Name = "viewDescription1";
            this.viewDescription1.Size = new System.Drawing.Size(360, 240);
            this.viewDescription1.TabIndex = 25;
            this.viewDescription1.View = null;
            // 
            // viewGrid1
            // 
            this.viewGrid1.Cols = ((short)(2));
            this.viewGrid1.Location = new System.Drawing.Point(8, 8);
            this.viewGrid1.Name = "viewGrid1";
            this.viewGrid1.Rows = ((short)(2));
            this.viewGrid1.Size = new System.Drawing.Size(75, 23);
            this.viewGrid1.TabIndex = 26;
            this.viewGrid1.Text = "viewGrid1";
            // 
            // viewStructure1
            // 
            this.viewStructure1.ControlHeight = 0;
            this.viewStructure1.ControlWidth = 0;
            this.viewStructure1.Location = new System.Drawing.Point(0, 0);
            this.viewStructure1.Name = "viewStructure1";
            this.viewStructure1.Size = new System.Drawing.Size(430, 180);
            this.viewStructure1.TabIndex = 27;
            this.viewStructure1.View = null;
            // 
            // CameraPlay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnVideo);
            this.Name = "CameraPlay";
            this.Size = new System.Drawing.Size(266, 168);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.CameraPlay_Paint);
            this.pnVideo.ResumeLayout(false);
            this.multiplayer1.ResumeLayout(false);
            this.multiplexer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnVideo;
        private Multiplayer multiplayer1;
        private Multiplexer multiplexer1;
        private ViewStructure viewStructure1;
        private ViewGrid viewGrid1;
        private ViewDescription viewDescription1;
        private CameraViewer.Forms.DeviceDescription deviceDescription1;
        private CameraView cameraView1;
        private CameraWindow cameraWindow1;
        private CamerasTreeView camerasTreeView1;
        private CameraSettings cameraSettings1;
        private CameraDescription cameraDescription2;
        private HCVideoService.HCVideoServiceSourceSetting hcVideoServiceSourceSetting2;
        private CameraDescription cameraDescription1;
        private HCVideoService.HCVideoServiceSourceSetting hcVideoServiceSourceSetting1;
        private jpeg.JPEGSourcePage jpegSourcePage1;
        private mjpeg.MJPEGSourcePage mjpegSourcePage1;
        private SANYO.PanasonicCameraSetupPage panasonicCameraSetupPage1;
        private Damany.Controls.PanNav panNav1;
        private Damany.Controls.EightWayNavigator eightWayNavigator1;
        private Damany.Controls.CamNav camNav1;
        private Damany.Controls.CameraNav cameraNav1;
    }
}
