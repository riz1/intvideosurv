using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace CameraViewer.Forms
{
    public partial class frmLogout : XtraForm
    {
        public frmLogout()
        {
            InitializeComponent();
        }
        public bool LogoutOK = false;

        private void sbOK_Click(object sender, EventArgs e)
        {
            if (tePassword.Text == MainForm.CurrentUser.Password)
            {
                LogoutOK = true;
            }
            else
            {
                XtraMessageBox.Show("密码错误!","提示");
                LogoutOK = false;

            }              
        }
    }
}
