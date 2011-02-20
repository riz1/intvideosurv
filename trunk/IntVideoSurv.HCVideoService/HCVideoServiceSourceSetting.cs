using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using videosource;
using IntVideoSurv.Entity;

namespace HCVideoService
{
    public partial class HCVideoServiceSourceSetting : DevExpress.XtraEditors.XtraUserControl, IVideoSourcePage
    {
        public HCVideoServiceSourceSetting()
        {
            InitializeComponent();
        }

        #region IVideoSourcePage 成员

        public event EventHandler StateChanged;

        public bool Completed
        {
            get { return true; }
        }

        public void Display()
        {
            throw new NotImplementedException();
        }

        public bool Apply()
        {
            throw new NotImplementedException();
        }
        public string DeviceName
        {
            set
            {
                txtName.Text = value;
            }
        }
        public List<CameraInfo> ListCam
        {
            get
            {
                return (List<CameraInfo>)gdCamera.DataSource;
            }
            set
            {
                gdCamera.DataSource = value;
            }
        }
        public object GetConfiguration()
        {
            DeviceInfo config = new DeviceInfo();
            config.Name = txtName.Text;
            config.source = urlBox.Text;
            config.login = loginBox.Text;
            config.pwd = passwordBox.Text;
            config.Port = ushort.Parse(txtPort.Text);
            config.VideoCount = int.Parse(txtVideoCount.Text);
            config.ViddeoStartNo = int.Parse(txtViddeoStartNo.Text);
            config.WarningOutputCount = int.Parse(txtWarningOutputCount.Text);
            config.WarningInputNo = int.Parse(txtWarningInputNo.Text);
            config.WarningCount = int.Parse(txtWarningCount.Text);
            config.FileExtName = Util.VIDEOFILEEXTNAME;
            return (object)config;
        }
        public   List<CameraInfo> CameraList { get; set; }
        public void SetConfiguration(object config)
        {
              
            DeviceInfo cfg = (DeviceInfo)config;
            if (cfg != null)
            {
                txtName.Text = cfg.Name;
                urlBox.Text = cfg.source;
                loginBox.Text = cfg.login;
                passwordBox.Text = cfg.pwd;
                txtPort.Text = cfg.Port.ToString();
                txtViddeoStartNo.Text = cfg.ViddeoStartNo.ToString();
                txtVideoCount.Text = cfg.VideoCount.ToString();
                txtWarningOutputCount.Text = cfg.WarningOutputCount.ToString();
                txtWarningInputNo.Text = cfg.WarningInputNo.ToString();
                txtWarningCount.Text = cfg.WarningCount.ToString();
            }
        }

        #endregion

        private void txtVideoCount_Leave(object sender, EventArgs e)
        {
          
        }
        private void GenerateInputCam()
        {
            int iVideoCount = 0;
            int iViddeoStartNo=0;
             
            List<CameraInfo> list = new List<CameraInfo>();
            if (!int.TryParse(txtVideoCount.Text, out iVideoCount))
            {
                XtraMessageBox.Show("视频输入数不可为空?", "请注意");
                return ;
            }
            if (iVideoCount <= 0)
            {
                XtraMessageBox.Show("视频输入数必须大于零?", "请注意");
                return ;
            }
            if (!int.TryParse(txtViddeoStartNo.Text, out iViddeoStartNo))
            {
                XtraMessageBox.Show("视频输入开始号不可为空?", "请注意");
                return;
            }
            if (iViddeoStartNo < 0)
            {
                XtraMessageBox.Show("视频输入开始号必须大于或等于零?", "请注意");
                return;
            }
            //txtViddeoStartNo
            CameraInfo oCameraInfo = new CameraInfo();
            for (int i = 0; i < iVideoCount; i++)
            {
                oCameraInfo = new CameraInfo();
                oCameraInfo.Name = string.Format("摄象机{0}", i+1);
                oCameraInfo.AddressID = i+1;
                oCameraInfo.ChannelNo = iViddeoStartNo;
                oCameraInfo.ConnURL = "Com1";
                oCameraInfo.Oupputpath = "d:\\videoutput";
                oCameraInfo.IsValid = true;
                oCameraInfo.IsDetect = false;
                list.Add(oCameraInfo);
                iViddeoStartNo = iViddeoStartNo + 1;

            }
            gdCamera.DataSource = list;


            
        }

        private void txtViddeoStartNo_Leave(object sender, EventArgs e)
        {
            GenerateInputCam();
        }

    }
}
