using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Diagnostics;
using IntVideoSurv.Business;
using IntVideoSurv.Entity;


namespace CameraViewer.Forms
{

    public partial class FormLogin : Form
    {
        public UserInfo currentUser = new UserInfo();
        public bool isLoginOK = false;
        public string InputUsername;
        public string InputPassword;

        public FormLogin()
        {
            InitializeComponent();
        }

        public FormLogin(string iu, string ip, string pi)
        {
            InitializeComponent();
            txtUserID.Text = iu;
            txtPassword.Text = ip;
            labelPromoteInfo.Text = pi;
            if (string.IsNullOrEmpty(iu)==false)
            {
                txtPassword.TabIndex = 0;
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            InputUsername = txtUserID.Text;
            InputPassword = txtPassword.Text;
            string errMessage = "";
            isLoginOK = UserBusiness.Instance.IsUserValid(ref errMessage, InputUsername, InputPassword);
            if (isLoginOK)
            {
                //登录成功日志
                currentUser = UserBusiness.Instance.GetUserInfo(ref errMessage, InputUsername);

                SystemLogBusiness.Instance.Insert(ref errMessage,new SystemLog
                                                                     {
                                                                         HappenTime =DateTime.Now,
                                                                         SystemTypeId = 1,
                                                                         SystemTypeName ="用户登录成功",
                                                                         Content = "用户登录成功",
                                                                         SyeUserName = currentUser.UserName,
                                                                         ClientUserId=currentUser.UserId,
                                                                         ClientUserName = currentUser.UserName

                                                                     });
                Properties.Settings.Default.LastUser = currentUser.UserName;
                Properties.Settings.Default.Save();
            }
            else
            {
               //登录失败日志
                currentUser = UserBusiness.Instance.GetUserInfo(ref errMessage, InputUsername);
                int userid = currentUser == null ? -1 : currentUser.UserId;
                SystemLogBusiness.Instance.Insert(ref errMessage, new SystemLog
                {
                    HappenTime = DateTime.Now,
                    SystemTypeId = 2,
                    SystemTypeName = "用户登录失败",
                    Content = "用户登录失败",
                    SyeUserName = InputUsername,
                    ClientUserId = userid,
                    ClientUserName = InputUsername

                });                    


            }
        }
    }

}
