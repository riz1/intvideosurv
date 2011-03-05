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
namespace CameraViewer.Forms
{
    public partial class AddCameraInDecoder : DevExpress.XtraEditors.XtraForm
    {
        private string errMessage = "";
        Dictionary<int, CameraInfo> addCamera;
        public AddCameraInDecoder()
        {
            InitializeComponent();
            LoadCameraInfo();
        }
        public void LoadCameraInfo()
        {
            listBoxControl1AddCamera.Items.Clear();
            addCamera = CameraBusiness.Instance.GetAllCameraInfo(ref errMessage);
            foreach (KeyValuePair<int, CameraInfo> item in addCamera)
            {
                listBoxControl1AddCamera.Items.Add(item.Value.CameraId.ToString()+":"+item.Value.Name);

            }

        }
        private void panelControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        public int DecoderID { set; get; }
        
        private void simpleButton1AddCamera_Click(object sender, EventArgs e)
        {
            int cameraid = int.Parse(listBoxControl1AddCamera.SelectedItem.ToString().Split(':')[0]);
            int id = DecoderBusiness.Instance.InsertCamera(ref errMessage, DecoderID, cameraid);
            OperateLog ol = new OperateLog
            {
                HappenTime = DateTime.Now,
                OperateTypeId = (int)(OperateLogTypeId.CameraAddInDecoder),
                OperateTypeName = OperateLogTypeName.CameraAddInDecoder,
                Content = id.ToString(),
                OperateUserName = MainForm.CurrentUser.UserName,
                ClientUserName = MainForm.CurrentUser.UserName,
                ClientUserId = MainForm.CurrentUser.UserId
            };
            OperateLogBusiness.Instance.Insert(ref errMessage, ol);
            Close();
            Dispose();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}