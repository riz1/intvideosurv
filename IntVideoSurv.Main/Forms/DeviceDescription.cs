using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using IntVideoSurv.Entity;
using videosource;
using System.Reflection;
namespace CameraViewer.Forms
{
    public partial class DeviceDescription : DevExpress.XtraEditors.XtraUserControl
    {
        public DeviceDescription()
        {
            InitializeComponent();
        }
        private DeviceInfo oDeviceInfo;
        public DeviceInfo DeviceEntity
        {
            set {
                oDeviceInfo = value;
                txtName.Text = oDeviceInfo.Name;
                txtDescription.Text = oDeviceInfo.Remark;
                videoSourceCombo.SelectedItem = oDeviceInfo.ProviderName;
       
            }
            get
            {
                oDeviceInfo = new DeviceInfo();
                oDeviceInfo.Name = txtName.Text;
                oDeviceInfo.Remark = txtDescription.Text;
                oDeviceInfo.ProviderName = videoSourceCombo.SelectedItem.ToString();
                return oDeviceInfo;
            }
        }
        private Dictionary<string,IVideoSourceDescription> providers = null;
        public Dictionary<string, IVideoSourceDescription> VideoProviders
        {
            get { return providers; }
            set
            {
                providers = value;
                BuildSourceCombo();
            }
        }
        private void BuildSourceCombo()
        {
            // clean combo
              videoSourceCombo.DataBindings.Clear();
              List<string> listDesc = new List<string>();
              if (providers != null)
              {

                  foreach (KeyValuePair<string,IVideoSourceDescription> item in providers)
                  {
                      videoSourceCombo.Properties.Items.Add(item.Value.Name);
                    
                  }
                  
                 
              }

         
        }
        public IVideoSourceDescription VideoDesc
        {
            get
            {
                return VideoProviders[videoSourceCombo.SelectedItem.ToString()];
            }
        }

        private void DeviceDescription_Load(object sender, EventArgs e)
        {

        }

        private void videoSourceCombo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
