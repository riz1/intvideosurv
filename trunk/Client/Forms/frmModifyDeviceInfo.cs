using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using IntVideoSurv.Business;
using IntVideoSurv.Entity;
using videosource;
using System.Reflection;
namespace CameraViewer.Forms
{
    public partial class frmModifyDeviceInfo : DevExpress.XtraEditors.XtraForm
    {
        private int nPageIndex = 0;
        IVideoSourcePage sourcePage;
        private string errMessage = "";
        private Dictionary<string,IVideoSourceDescription> ListVideoProvider=null;
        DeviceInfo _DeviceInfo = null;
        public frmModifyDeviceInfo()
        {
            InitializeComponent();

           
      
        }
        int _DeviceId = 0;
        public int DeviceId
        {
            set
            {
                _DeviceId = value;
                _DeviceInfo = DeviceBusiness.Instance.GetDeviceInfoByDeviceId(ref errMessage, value);
                DeviceBusiness.Instance.Load(AppDomain.CurrentDomain.BaseDirectory);
                ListVideoProvider = DeviceBusiness.Instance.ListVideoProvider;
                GroupId = _DeviceInfo.GroupId;
                LoadPageSetting();

            }
           
        }
        public int GroupId
        {
            set;
            get;
        }
        private void btnNext_Click(object sender, EventArgs e)
        { 
            if (Save())
            {
                this.Close();
            }

            
            //List<CameraInfo > listCam= sourcePage.
           
        }
        private bool Save()
        {
            if (sourcePage == null)
            {
                XtraMessageBox.Show("不能找到设备物件?", "请注意");
                return false;
            }
            try
            {
                DeviceInfo oDevice = (DeviceInfo)sourcePage.GetConfiguration();
                List<CameraInfo> listCam = sourcePage.ListCam;
                oDevice.GroupId = GroupId;
                oDevice.ProviderName = _DeviceInfo.ProviderName;
                oDevice.Description = _DeviceInfo.Description;
                oDevice.DeviceId = _DeviceInfo.DeviceId;
                //oDevice.Name = _DeviceInfo.Name;
                oDevice.Description = _DeviceInfo.Description;
                DeviceBusiness.Instance.Update(ref  errMessage, listCam, oDevice);
                if (errMessage.Length > 0)
                {
                    XtraMessageBox.Show("错误信息:" + errMessage, "请注意");
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("错误信息:"+ex.Message, "请注意");
                return false;
            }
        }
        private void LoadPageSetting()
        {
            IVideoSourceDescription videoDesc = ListVideoProvider[_DeviceInfo.ProviderName];
            sourcePage = videoDesc.GetSettingsPage();
            sourcePage.SetConfiguration((object)_DeviceInfo);
            List<CameraInfo> listCam = new List<CameraInfo>();
            if (_DeviceInfo.ListCamera != null)
            {
                foreach (KeyValuePair<int,CameraInfo> item in _DeviceInfo.ListCamera)
                {
                    listCam.Add(item.Value);
                }
            }
            sourcePage.DeviceName = _DeviceInfo.Name;
            sourcePage.ListCam = listCam;
            Control control = (Control)sourcePage;
            this.Width = control.Width;
            this.Height = control.Height + pnBottom.Height + 30;
            pbBtContainer.Left = (this.Width - pbBtContainer.Width) / 2;
             
            control.Dock = DockStyle.Fill;
            pnTop.Controls.Add(control);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Left = (Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       

    }
}