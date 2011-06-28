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
    public partial class FrmUser : XtraForm
    {
        public enum UserMode
        {
            Add =1,
            UPDATE=2
        }

        private UserInfo userInfo;
        private UserMode userMode = UserMode.Add;
        public FrmUser()
        {
            userMode = UserMode.Add;
            InitializeComponent();
            this.Text = "添加用户";
            InitValidationRules();
        }
        public FrmUser(UserInfo ui)
        {
            userInfo = ui;
            userMode = UserMode.UPDATE;
            InitializeComponent();
            this.Text = "重置密码";
            textEditUserName.Text = ui.UserName;
            comboBoxEditUserType.Visible = false;
            labelControl4.Visible = false;
            textEditUserName.Enabled = false;
            InitValidationRules();
            if (userInfo.UserTypeName == "管理员")
            {
                lcOldPWD.Visible = teOldPWD.Visible = false;
            }

        }
        #region  数据验证
        
        private void InitValidationRules()
        {
            if (userMode == UserMode.Add)
            {
                var userNameValidationRule = new UserNameValidationRule();
                userNameValidationRule.ErrorText = "名称必须非空且还未被使用!";
                dxValidationProvider1.SetValidationRule(textEditUserName, userNameValidationRule);
                dxValidationProvider1.SetIconAlignment(textEditUserName, ErrorIconAlignment.MiddleRight);
                var userTypeValidationRule = new UserTypeValidationRule();
                userTypeValidationRule.ErrorText = "用户类型必须非空";   
                dxValidationProvider1.SetValidationRule(comboBoxEditUserType, userTypeValidationRule);  
                dxValidationProvider1.SetIconAlignment(comboBoxEditUserType, ErrorIconAlignment.MiddleRight);         
            }


            var userPasswordConfirmValidationRule = new UserPasswordConfirmValidationRule();
            userPasswordConfirmValidationRule.ErrorText = "密码长度至少为6";
            
            var userPasswordValidationRule = new UserPasswordValidationRule();
            userPasswordValidationRule.ErrorText = "两次密码不匹配";

            dxValidationProvider1.SetValidationRule(textEditPassword, userPasswordValidationRule);
            dxValidationProvider1.SetValidationRule(textEditPasswordConfirm, userPasswordConfirmValidationRule); 


            dxValidationProvider1.SetIconAlignment(textEditPasswordConfirm, ErrorIconAlignment.MiddleRight);     
            dxValidationProvider1.SetIconAlignment(textEditPassword, ErrorIconAlignment.MiddleRight);


        }
        #endregion

        private void buttonOK_Click(object sender, EventArgs e)
        { 
            string errMessage = "";
            if (userInfo.UserTypeName != "管理员")
            {
                if (teOldPWD.Text != userInfo.Password)
                {
                    XtraMessageBox.Show("原密码不正确!");
                    return;
                }
            }
            if (!dxValidationProvider1.Validate())
            {
                return;
            }
            var ui = new UserInfo
                         {
                             UserName = textEditUserName.Text,
                             Password = textEditPassword.Text,
                             CreateDateTime = DateTime.Now,
                             UserTypeName = comboBoxEditUserType.Text,
                             UserTypeId = comboBoxEditUserType.Text == "管理员" ? 1 : 2
                         };
            switch (userMode)
            {
                case UserMode.Add:
                    UserBusiness.Instance.Insert(ref errMessage, ui);
                    ui = UserBusiness.Instance.GetUserInfo(ref errMessage, ui.UserName);
                    OperateLog ol = new OperateLog
                                        {
                                            HappenTime = DateTime.Now,
                                            OperateTypeId = (int)(OperateLogTypeId.UserAdd),
                                            OperateTypeName = OperateLogTypeName.UserAdd,
                                            Content = ui.ToString(),
                                            OperateUserName = MainForm.CurrentUser.UserName,
                                            ClientUserName = MainForm.CurrentUser.UserName,
                                            ClientUserId = MainForm.CurrentUser.UserId
                                        };
                    OperateLogBusiness.Instance.Insert(ref errMessage, ol);
                    break;

                case UserMode.UPDATE:
                    UserBusiness.Instance.UpdatePassword(ref errMessage, userInfo.UserId, textEditPassword.Text);
                    OperateLogBusiness.Instance.Insert(ref errMessage, new OperateLog
                                       {
                                           HappenTime = DateTime.Now,
                                           OperateTypeId = (int)(OperateLogTypeId.UserUpdate),
                                           OperateTypeName = OperateLogTypeName.SynGroupUpdate,
                                           Content = ui.ToString(),
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
    }
    public class UserPasswordValidationRule : ValidationRule
    {
        public override bool Validate(Control control, object value)
        {
            var str = (string)value;
            return (str.Equals(UserPasswordConfirmValidationRule.StrPassword)) && !string.IsNullOrEmpty(str);
        }
    }

    public class UserNameValidationRule : ValidationRule
    {
        private string _errMessage = "";
        public override bool Validate(Control control, object value)
        {
            var str = (string)value;
            return !string.IsNullOrEmpty(str) && UserBusiness.Instance.IsUserNameExisted(ref _errMessage, str);

        }
    }

    public class UserTypeValidationRule : ValidationRule
    {
        public override bool Validate(Control control, object value)
        {
            var str = (string)value;
            return !string.IsNullOrEmpty(str);
        }
    }

    public class UserPasswordConfirmValidationRule : ValidationRule
    {
        public static string StrPassword;
        public static bool IsBeenValided = false;
        public override bool Validate(Control control, object value)
        {
            var str = (string)value;
            IsBeenValided = true;
            StrPassword = str;
            return (!string.IsNullOrEmpty(str)) && (str.Length >= 6);
        }
    }
}
