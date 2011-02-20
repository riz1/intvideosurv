// Camara Vision
//
// Copyright ?Andrew Kirillov, 2005-2006
// andrew.kirillov@gmail.com
//

using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using videosource;
using System.Collections.Generic;
using IntVideoSurv.Entity;

namespace SANYO
{
	/// <summary>
	/// Summary description for PanasonicCameraSetupPage.
	/// </summary>
	public class PanasonicCameraSetupPage : System.Windows.Forms.UserControl, IVideoSourcePage
	{
		private static int[] frameIntervals = new int[] {0, 100, 142, 200, 333, 1000,
															5000, 10000, 15000, 20000, 30000, 60000};
	 	private bool completed = false;
		private System.Windows.Forms.ComboBox rateCombo;
        private System.Windows.Forms.Label label6;
		private System.Windows.Forms.ComboBox sizeCombo;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox passwordBox;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox loginBox;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox serverBox;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.ComboBox qualityCombo;
        private Label label5;
        private TextBox txtConnUrl;
        private Label label8;
        private TextBox txtAddressId;
        private Label label9;
        private TextBox txtOutputpath;
        private Label label10;
        private Label label11;
        private CheckBox ckIsDetect;
        private CheckBox ckIsValid;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		// new frame event
		public event EventHandler StateChanged;

		// Constructor
		public PanasonicCameraSetupPage()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitForm call
			sizeCombo.SelectedIndex = 1;
			
			rateCombo.SelectedIndex = 0;
			qualityCombo.SelectedIndex = 1;
		}
        public List<CameraInfo> CameraList { get; set; }
		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.rateCombo = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.sizeCombo = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.passwordBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.loginBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.serverBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.qualityCombo = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtConnUrl = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtAddressId = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtOutputpath = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.ckIsDetect = new System.Windows.Forms.CheckBox();
            this.ckIsValid = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // rateCombo
            // 
            this.rateCombo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rateCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.rateCombo.Items.AddRange(new object[] {
            "Uncontrolled",
            "10 frames per second",
            "7 frames per second",
            "5 frames per second",
            "3 frames per second",
            "1 frame per second",
            "12 frames per minute",
            "6 frames per minute",
            "4 frames per minute",
            "3 frames per minute",
            "2 frames per minute",
            "1 frame per minute"});
            this.rateCombo.Location = new System.Drawing.Point(109, 160);
            this.rateCombo.Name = "rateCombo";
            this.rateCombo.Size = new System.Drawing.Size(225, 21);
            this.rateCombo.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(10, 163);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 14);
            this.label6.TabIndex = 12;
            this.label6.Text = "每秒帧数:";
            // 
            // sizeCombo
            // 
            this.sizeCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sizeCombo.Items.AddRange(new object[] {
            "160x120",
            "320x240",
            "640x480"});
            this.sizeCombo.Location = new System.Drawing.Point(109, 100);
            this.sizeCombo.Name = "sizeCombo";
            this.sizeCombo.Size = new System.Drawing.Size(98, 21);
            this.sizeCombo.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(10, 103);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 14);
            this.label4.TabIndex = 6;
            this.label4.Text = "分辨率:";
            // 
            // passwordBox
            // 
            this.passwordBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.passwordBox.Location = new System.Drawing.Point(109, 70);
            this.passwordBox.Name = "passwordBox";
            this.passwordBox.Size = new System.Drawing.Size(225, 20);
            this.passwordBox.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(10, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 14);
            this.label3.TabIndex = 4;
            this.label3.Text = "密码:";
            // 
            // loginBox
            // 
            this.loginBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.loginBox.Location = new System.Drawing.Point(109, 40);
            this.loginBox.Name = "loginBox";
            this.loginBox.Size = new System.Drawing.Size(225, 20);
            this.loginBox.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(10, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 14);
            this.label2.TabIndex = 2;
            this.label2.Text = "用户:";
            // 
            // serverBox
            // 
            this.serverBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.serverBox.Location = new System.Drawing.Point(109, 10);
            this.serverBox.Name = "serverBox";
            this.serverBox.Size = new System.Drawing.Size(225, 20);
            this.serverBox.TabIndex = 1;
            this.serverBox.TextChanged += new System.EventHandler(this.serverBox_TextChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(10, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "IP地址:";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(10, 133);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 15);
            this.label7.TabIndex = 10;
            this.label7.Text = "质量:";
            // 
            // qualityCombo
            // 
            this.qualityCombo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.qualityCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.qualityCombo.Items.AddRange(new object[] {
            "Motion",
            "Standard",
            "Clarity"});
            this.qualityCombo.Location = new System.Drawing.Point(109, 130);
            this.qualityCombo.Name = "qualityCombo";
            this.qualityCombo.Size = new System.Drawing.Size(225, 21);
            this.qualityCombo.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(10, 190);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 14);
            this.label5.TabIndex = 2;
            this.label5.Text = "云台控制端口:";
            // 
            // txtConnUrl
            // 
            this.txtConnUrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtConnUrl.Location = new System.Drawing.Point(109, 187);
            this.txtConnUrl.Name = "txtConnUrl";
            this.txtConnUrl.Size = new System.Drawing.Size(225, 20);
            this.txtConnUrl.TabIndex = 3;
            this.txtConnUrl.Text = "Com1";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(10, 216);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(83, 14);
            this.label8.TabIndex = 2;
            this.label8.Text = "云台地址:";
            // 
            // txtAddressId
            // 
            this.txtAddressId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAddressId.Location = new System.Drawing.Point(109, 213);
            this.txtAddressId.Name = "txtAddressId";
            this.txtAddressId.Size = new System.Drawing.Size(225, 20);
            this.txtAddressId.TabIndex = 3;
            this.txtAddressId.Text = "1";
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(10, 262);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(83, 14);
            this.label9.TabIndex = 2;
            this.label9.Text = "是否入侵检测:";
            // 
            // txtOutputpath
            // 
            this.txtOutputpath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOutputpath.Location = new System.Drawing.Point(109, 236);
            this.txtOutputpath.Name = "txtOutputpath";
            this.txtOutputpath.Size = new System.Drawing.Size(225, 20);
            this.txtOutputpath.TabIndex = 3;
            this.txtOutputpath.Text = "d:\\videoOutput";
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(10, 242);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(83, 14);
            this.label10.TabIndex = 2;
            this.label10.Text = "录像路径:";
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(10, 281);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(83, 14);
            this.label11.TabIndex = 2;
            this.label11.Text = "是否激活:";
            // 
            // ckIsDetect
            // 
            this.ckIsDetect.AutoSize = true;
            this.ckIsDetect.Location = new System.Drawing.Point(109, 263);
            this.ckIsDetect.Name = "ckIsDetect";
            this.ckIsDetect.Size = new System.Drawing.Size(15, 14);
            this.ckIsDetect.TabIndex = 14;
            this.ckIsDetect.UseVisualStyleBackColor = true;
            // 
            // ckIsValid
            // 
            this.ckIsValid.AutoSize = true;
            this.ckIsValid.Checked = true;
            this.ckIsValid.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckIsValid.Location = new System.Drawing.Point(109, 283);
            this.ckIsValid.Name = "ckIsValid";
            this.ckIsValid.Size = new System.Drawing.Size(15, 14);
            this.ckIsValid.TabIndex = 14;
            this.ckIsValid.UseVisualStyleBackColor = true;
            // 
            // PanasonicCameraSetupPage
            // 
            this.Controls.Add(this.ckIsValid);
            this.Controls.Add(this.ckIsDetect);
            this.Controls.Add(this.qualityCombo);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.rateCombo);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.sizeCombo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.passwordBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtOutputpath);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtAddressId);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtConnUrl);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.loginBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.serverBox);
            this.Controls.Add(this.label1);
            this.Name = "PanasonicCameraSetupPage";
            this.Size = new System.Drawing.Size(349, 303);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		// Completed property
		public bool Completed
		{
			get { return completed; }
		}

		// Show the page
		public void Display()
		{
			serverBox.Focus();
			serverBox.SelectionStart = serverBox.TextLength;
		}

		// Apply the page
		public bool Apply()
		{
			return true;
		}
        
       
        List<CameraInfo> _listCam =null;
        public List<CameraInfo> ListCam
        {
            get
            {
                return _listCam;
            }
            set
            {

                _listCam = value;
                sizeCombo.Text = _listCam[0].resolution;
                qualityCombo.Text = _listCam[0].quality;
                rateCombo.SelectedIndex = Array.IndexOf(frameIntervals, _listCam[0].frameInterval);
                txtOutputpath.Text=_listCam[0].Oupputpath;
                ckIsDetect.Checked = _listCam[0].IsDetect; ;
                ckIsValid.Checked = _listCam[0].IsValid; ;
                txtConnUrl.Text = _listCam[0].ConnURL; ;
                txtAddressId.Text = _listCam[0].AddressID.ToString(); ;
            }
        }
        public object GetConfiguration()
        {
            DeviceInfo config = new DeviceInfo();
            config.Name = _DeviceName;
            config.source = serverBox.Text;
            config.login = loginBox.Text;
            config.pwd = passwordBox.Text;
            config.IsCamera = 1;
            _listCam = new List<CameraInfo>();
            CameraInfo ocamera = new CameraInfo();
            ocamera.Name = _DeviceName;
            ocamera.resolution = sizeCombo.Text;
            ocamera.StreamType = 0;
            ocamera.quality = qualityCombo.Text;
            ocamera.frameInterval = frameIntervals[rateCombo.SelectedIndex];
            ocamera.Oupputpath = txtOutputpath.Text;
            ocamera.IsDetect = ckIsDetect.Checked;
            ocamera.IsValid = ckIsValid.Checked;
            ocamera.ConnURL = txtConnUrl.Text;
            ocamera.AddressID = int.Parse(txtAddressId.Text);
            _listCam.Add(ocamera);
            return (object)config;
        }
     
        public void SetConfiguration(object config)
        {

            DeviceInfo cfg = (DeviceInfo)config;
            if (cfg != null)
            {
                serverBox.Text = cfg.source;
                loginBox.Text = cfg.login;
                passwordBox.Text = cfg.pwd;

                /*
                  oCameraInfo.Name = string.Format("摄象机{0}", i+1);
                oCameraInfo.AddressID = i+1;
                oCameraInfo.ChannelNo = iViddeoStartNo;
                oCameraInfo.ConnURL = "Com1";
                oCameraInfo.Oupputpath = "d:\\videoutput";
                oCameraInfo.IsValid = true;
                oCameraInfo.IsDetect = false;
                list.Add(oCameraInfo);
                 
                 */

            }
        }
 

		// Server edit box changed
		private void serverBox_TextChanged(object sender, System.EventArgs e)
		{
			completed = (serverBox.TextLength != 0);

			if (StateChanged != null)
				StateChanged(this, new EventArgs());
		}
 

        #region IVideoSourcePage 成员

        private string _DeviceName = "";
        public string DeviceName
        {
            set { _DeviceName=value; }
        }

        #endregion

        #region IVideoSourcePage 成员


    

        #endregion
    }
}
