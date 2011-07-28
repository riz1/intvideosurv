using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CameraViewer.Model;
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
           
        }

        private Dictionary<string,LongChang_CameraInfo> _listCamerasByName = new Dictionary<string, LongChang_CameraInfo>();
        public DateTime BeginTime;
        public DateTime EndTime;
        public List<Model.TOG_DEVICE> ListSelectedCameraIds = new List<TOG_DEVICE>();
        public int flag;
        private void sbOK_Click(object sender, EventArgs e)
        {
            if (ccbeCameras.Text == "请选择摄像头")
            {
                XtraMessageBox.Show("至少选择一个摄像头!");
                return ;
            }
            if (teStartTime.Time > teEndTime.Time)
            {
                XtraMessageBox.Show("结束时间小于开始时间!");
                return ;
            }
            if ((teEndTime.Time-teStartTime.Time).TotalHours>24 )
            {
                XtraMessageBox.Show("结束时间与开始时间不能大于24小时!");
                return ;
            }
            BeginTime = teStartTime.Time;
            EndTime = teEndTime.Time;
            var cameraIds = ccbeCameras.Properties.Items.GetCheckedValues();

            ListSelectedCameraIds = cameraIds.OfType<Model.TOG_DEVICE>().ToList();
           
            DialogResult = DialogResult.OK;
        }
    }
}
