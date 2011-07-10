using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using IntVideoSurv.Business;
using IntVideoSurv.Entity;

namespace CameraViewer.Forms
{
    public partial class frmHistoryCaptureCondition : XtraForm
    {
        public frmHistoryCaptureCondition()
        {
            InitializeComponent();
            DateTime now = DateTime.Now;
            teStartTime.EditValue = now.AddHours(-2);
            teEndTime.EditValue = now;
            string errMsg = "";
            Dictionary<int, LongChang_CameraInfo> allCameras = LongChang_CameraBusiness.Instance.GetCamInfoByDeviceUserId(ref errMsg, MainForm.CurrentUser.UserId);
            foreach (var VARIABLE in allCameras)
            {
                ccbeCameras.Properties.Items.Add(VARIABLE.Value.Name);
                _listCamerasByName.Add(VARIABLE.Value.Name, VARIABLE.Value);
            }
            if (allCameras.Count>0)
            {
                ccbeCameras.Properties.Items[0].CheckState = CheckedListBoxItem.GetCheckState(true);
            }
        }

        private Dictionary<string,LongChang_CameraInfo> _listCamerasByName = new Dictionary<string, LongChang_CameraInfo>();
        public DateTime BeginTime;
        public DateTime EndTime;
        public Dictionary<int, LongChang_CameraInfo> ListSelectedCameras = new Dictionary<int, LongChang_CameraInfo>();
        public int flag;
        private void sbOK_Click(object sender, EventArgs e)
        {
            if (ccbeCameras.Text == "请选择摄像头")
            {
                XtraMessageBox.Show("至少选择一个摄像头!");
                this.DialogResult = DialogResult.No;
                return ;
            }
            if (teStartTime.Time > teEndTime.Time)
            {
                XtraMessageBox.Show("结束时间小于开始时间!");
                this.DialogResult = DialogResult.No;
                return ;
            }
            if ((teEndTime.Time-teStartTime.Time).TotalHours>24 )
            {
                XtraMessageBox.Show("结束时间与开始时间不能大于24小时!");
                this.DialogResult = DialogResult.No;
                return ;
            }
            BeginTime = teStartTime.Time;
            EndTime = teEndTime.Time;
            string[] cameras = ccbeCameras.Text.Split(',');
            ListSelectedCameras.Clear();
            foreach (var camera in cameras)
            {
                foreach (var VARIABLE in _listCamerasByName)
                {
                    if (camera.Trim() == VARIABLE.Key)
                    {
                        ListSelectedCameras.Add(VARIABLE.Value.CameraId,VARIABLE.Value);
                        break;
                    }
                }
            }
            this.Close();
           
        }
    }
}
