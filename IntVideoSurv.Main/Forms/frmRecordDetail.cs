using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace CameraViewer.Forms
{
    public partial class frmRecordDetail : DevExpress.XtraEditors.XtraForm
    {
        public frmRecordDetail()
        {
            InitializeComponent();
        }
        public frmRecordDetail(DataSet ds,string username)
        {
            InitializeComponent();
            labelControlTollName.Text = ds.Tables[0].Rows[0][0].ToString();
            labelControlDirectionNum.Text = ds.Tables[0].Rows[0][1].ToString();
            labelControlRoadName.Text = ds.Tables[0].Rows[0][2].ToString();
            labelControlUserName.Text = username.ToString();
            labelControlIllegalReason.Text = ds.Tables[0].Rows[0][3].ToString();
            labelControlPlateNumberType.Text = ds.Tables[0].Rows[0][4].ToString();
            labelControlCollectDate.Text = ds.Tables[0].Rows[0][5].ToString();
            labelControlDepartmentNum.Text = ds.Tables[0].Rows[0][6].ToString();
            labelControlDepartmentName.Text = ds.Tables[0].Rows[0][7].ToString();
            labelControlPlateNum.Text = ds.Tables[0].Rows[0][8].ToString();
            DateTime dt = DateTime.Parse(ds.Tables[0].Rows[0][5].ToString());
            string path = Properties.Settings.Default.CapturePictureFilePath + @"\" + dt.ToString(@"yyyy\\MM\\dd") + @"\";
            pictureEdit1.Image = Image.FromFile(path+ds.Tables[0].Rows[0][9].ToString());
            pictureEdit2.Image = Image.FromFile(path+ds.Tables[0].Rows[0][10].ToString());
            pictureEdit3.Image = Image.FromFile(path+ds.Tables[0].Rows[0][11].ToString());
        }

        private void simpleButtonOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}