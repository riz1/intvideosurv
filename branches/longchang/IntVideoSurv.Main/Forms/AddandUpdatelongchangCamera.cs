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
using IntVideoSurv.Business;
using IntVideoSurv.Entity;

namespace CameraViewer.Forms
{
    public partial class AddandUpdatelongchangCamera : DevExpress.XtraEditors.XtraForm
    {
        public enum UserMode
        {
            Add = 1,
            UPDATE = 2
        }
        public AddandUpdatelongchangCamera()
        {
            mymode = UserMode.Add;
            InitializeComponent();
            Dictionary<string, LongChang_TollGateInfo> listtogate =
                LongChang_TollGateBusiness.Instance.GetAllTollGateInfo(ref errMessage);
            //comboBoxEditKaKou
            comboBoxEditKaKou.Properties.Items.Clear();
            foreach (var v in listtogate)
            {
                if(v.Value.tollParentNum=="moniroot")
                comboBoxEditKaKou.Properties.Items.Add(v.Value.tollName);
            }
            if (comboBoxEditKaKou.Properties.Items.Count > 0)
            {
                comboBoxEditKaKou.EditValue = comboBoxEditKaKou.Properties.Items[0];
            }
        }
        //
        public AddandUpdatelongchangCamera(LongChang_CameraInfo ocamera)
        {
            mymode = UserMode.UPDATE;
            oc = ocamera;
            InitializeComponent();
            textEditNum.Text = oc.CameraId.ToString();
            textEditName.Text = oc.Name;
            textEditIP.Text = oc.IP;
            textEditPort.Text = oc.Port.ToString();
            textEditUser.Text = oc.UserName;
            textEditPassword.Text = oc.PassWord;
            comboBoxEditCType.Text = oc.Type == 1 ? "枪机" : "球机";
            comboBoxEditKaKou.Text = oc.TollGateName;

        }

        public UserMode mymode;
        public LongChang_CameraInfo oc;
        private string errMessage = "";
        private void simpleButtonOk_Click(object sender, EventArgs e)
        {
            string errMessage = "";
            var ci = new LongChang_CameraInfo
                         {
                             CameraId = int.Parse(textEditNum.Text),
                             Name = textEditName.Text,
                             IP = textEditIP.Text,
                             Port = int.Parse(textEditPort.Text),
                             UserName = textEditUser.Text,
                             PassWord = textEditPassword.Text,
                             Type = comboBoxEditCType.Text == "枪机" ? 1 : 2,
                             TollGateName = comboBoxEditKaKou.Text
            };

            switch (mymode)
            {
                case UserMode.Add:
                    LongChang_CameraBusiness.Instance.Insert(ref errMessage, ci);
                    OperateLog ol = new OperateLog
                    {
                        HappenTime = DateTime.Now,
                        OperateTypeId = (int)(OperateLogTypeId.ToGDeviceAdd),
                        OperateTypeName = OperateLogTypeName.ToGDeviceAdd,
                        Content = ci.ToString(),
                        OperateUserName = MainForm.CurrentUser.UserName,
                        ClientUserName = MainForm.CurrentUser.UserName,
                        ClientUserId = MainForm.CurrentUser.UserId
                    };
                    OperateLogBusiness.Instance.Insert(ref errMessage, ol);
                    break;

                case UserMode.UPDATE:
                    //UserBusiness.Instance.UpdatePassword(ref errMessage, userInfo.UserId, textEditPassword.Text);
                    LongChang_CameraBusiness.Instance.Delete(ref errMessage, oc.CameraId);
                    LongChang_CameraBusiness.Instance.Insert(ref errMessage, ci);
                    OperateLogBusiness.Instance.Insert(ref errMessage, new OperateLog
                    {
                        HappenTime = DateTime.Now,
                        OperateTypeId = (int)(OperateLogTypeId.ToGDeviceUpdate),
                        OperateTypeName = OperateLogTypeName.ToGDeviceUpdate,
                        Content = oc.ToString(),
                        OperateUserName = MainForm.CurrentUser.UserName,
                        ClientUserName = MainForm.CurrentUser.UserName,
                        ClientUserId = MainForm.CurrentUser.UserId
                    });

                    break;
                default:
                    break;

            }
            Close();
            Dispose();
        }

        private void simpleButtonCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}