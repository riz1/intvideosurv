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

        private void sbOK_Click(object sender, EventArgs e)
        {
            if (tePassword.Text == MainForm.CurrentUser.Password)
            {
                sbOK.DialogResult = DialogResult.OK;
                return;
            }
            else
            {
                XtraMessageBox.Show("密码错误!","提示");

            }              
        }
    }
}
