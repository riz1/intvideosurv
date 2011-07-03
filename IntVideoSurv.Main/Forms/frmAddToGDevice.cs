using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.DXErrorProvider;
using IntVideoSurv.Entity;
using IntVideoSurv.Business;

namespace CameraViewer.Forms
{
    public partial class frmAddToGDevice : XtraForm
    {
        public frmAddToGDevice()
        {
            InitializeComponent();
        }

        private string errMessage;
        private void button_OK_Click(object sender, EventArgs e)
        {
            LongChang_CameraInfo ci = new LongChang_CameraInfo();
            ci.CameraId =int.Parse(textBox_CameraId.Text);
            ci.Name = textBox_CameraId.Text;
            ci.Port = int.Parse(textBox_Port.Text);
            ci.IP = textBox_IP.Text;
            if (comboBox_type.Text == "枪机")
                ci.Type = 1;
            if (comboBox_type.Text == "球机")
                ci.Type = 2;
            LongChang_CameraBusiness.Instance.Insert(ref errMessage, ci);
            OperateLog ol = new OperateLog
            {
                HappenTime = DateTime.Now,
                OperateTypeId = (int)(OperateLogTypeId.ToGDeviceAdd),
                OperateTypeName = OperateLogTypeName.ToGDeviceAdd,
                Content = ci.ToString(),
                Id = ci.CameraId,
                OperateUserName = MainForm.CurrentUser.UserName,
                ClientUserName = MainForm.CurrentUser.UserName,
                ClientUserId = MainForm.CurrentUser.UserId
            };
            OperateLogBusiness.Instance.Insert(ref errMessage, ol);
            Close();
            Dispose();
        }
    }
}
