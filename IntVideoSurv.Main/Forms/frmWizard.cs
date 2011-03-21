using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using IntVideoSurv.Entity;
using IntVideoSurv.Business;
using videosource;

namespace CameraViewer.Forms
{
    public partial class frmWizard : XtraForm
    {
        private int nPageIndex = 0;
        IVideoSourcePage sourcePage;
        private string errMessage = "";
        public frmWizard()
        {
            InitializeComponent();

            DeviceBusiness.Instance.Load(AppDomain.CurrentDomain.BaseDirectory);
            if (deviceDescription1 != null)
            {
                deviceDescription1.VideoProviders = DeviceBusiness.Instance.ListVideoProvider;
            }


        }
        public int GroupId
        {
            set;
            get;
        }
        private void btnNext_Click(object sender, EventArgs e)
        {
            if (nPageIndex == 0)
            {
                if (deviceDescription1.DeviceEntity.Name == "")
                {
                    XtraMessageBox.Show("设备名称不可为空?", "请注意");
                    return;

                }
                if (deviceDescription1.DeviceEntity.ProviderName == "")
                {
                    XtraMessageBox.Show("设备类型不可为空?", "请注意");
                    return;

                }
                btnNext.Text = "完成";
                nPageIndex = 1;
                btnBack.Visible = true;
                LoadPageSetting();
                return;
            }
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
                oDevice.GroupId = GroupId;
                oDevice.ProviderName = deviceDescription1.DeviceEntity.ProviderName;
                List<CameraInfo> listCam = sourcePage.ListCam;
                DeviceBusiness.Instance.Insert(ref  errMessage, listCam, oDevice);
                oDevice = DeviceBusiness.Instance.GetDeviceInfoByDeviceName(ref errMessage, oDevice.Name);
                OperateLogBusiness.Instance.Insert(ref errMessage, new OperateLog
                   {
                       //插入有问题，此处为给GroupId,CameraId赋值
                       ClientUserId = MainForm.CurrentUser.UserId,
                       ClientUserName = MainForm.CurrentUser.UserName,
                       Content = oDevice.ToString(),
                       DeviceId = oDevice.DeviceId,
                       HappenTime = DateTime.Now,
                       OperateTypeId =(int) OperateLogTypeId.DeviceAdd,
                       OperateTypeName = OperateLogTypeName.DeviceAdd,
                       OperateUserName = MainForm.CurrentUser.UserName
                   });
                foreach (var cameraInfo in listCam)
                {
                    CameraInfo camInfo = CameraBusiness.Instance.GetCamInfoByDeviceIdAndCameraName(ref errMessage, oDevice.DeviceId,
                                                                              cameraInfo.Name);
                    OperateLogBusiness.Instance.Insert(ref errMessage, new OperateLog
                    {
                        ClientUserId = MainForm.CurrentUser.UserId,
                        ClientUserName = MainForm.CurrentUser.UserName,
                        Content = cameraInfo.ToString(),
                        DeviceId = oDevice.DeviceId,
                        CameraId =  camInfo.CameraId,
                        HappenTime = DateTime.Now,
                        OperateTypeId = (int)OperateLogTypeId.CameraAdd,
                        OperateTypeName = OperateLogTypeName.CameraAdd,
                        OperateUserName = MainForm.CurrentUser.UserName
                    });                    
                }

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
            if (sourcePage != null)
            {
                Controls.Remove((Control)sourcePage);
            }
            deviceDescription1.Visible = false;
            IVideoSourceDescription videoDesc = deviceDescription1.VideoDesc;
            sourcePage = videoDesc.GetSettingsPage();
           

            sourcePage.DeviceName = deviceDescription1.DeviceEntity.Name;
            Control control = (Control)sourcePage;
            this.Width = control.Width;
            this.Height = control.Height + pnBottom.Height + 30;
            pbBtContainer.Left = (this.Width - pbBtContainer.Width) / 2;
             
            control.Dock = DockStyle.Fill;
            pnTop.Controls.Add(control);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Left = (Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            nPageIndex =0;
            btnBack.Visible =false;
            btnNext.Text = "下一步>";
            foreach (Control item in pnTop.Controls)
            {
                item.Visible = false;
                
            }
            deviceDescription1.Visible = true; ;
            this.Width = deviceDescription1.Width;
            this.Height = deviceDescription1.Height + pnBottom.Height + 30;
            pbBtContainer.Left = (this.Width - pbBtContainer.Width) / 2;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Left = (Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}