using System;
using System.IO;
using System.Net;
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
            string path1, path2, path3;
            path1 = path + ds.Tables[0].Rows[0][9].ToString();
            path2 = path + ds.Tables[0].Rows[0][10].ToString();
            path3 = path + ds.Tables[0].Rows[0][11].ToString();
            if (File.Exists(path1))
            {
                pictureEdit1.Image = Image.FromFile(path1);
            }
            else
            {
                //downloadfile
                DownloadFile(path, ds.Tables[0].Rows[0][9].ToString());
                pictureEdit1.Image = Image.FromFile(path1);
            }
            if (File.Exists(path2))
            {
                pictureEdit2.Image = Image.FromFile(path2);
            }
            else
            {
                //downloadfile
                DownloadFile(path, ds.Tables[0].Rows[0][10].ToString());
                pictureEdit2.Image = Image.FromFile(path2);
            }
            if (File.Exists(path3))
            {
                pictureEdit3.Image = Image.FromFile(path3);
            }
            else
            {
                //downloadfile
                DownloadFile(path, ds.Tables[0].Rows[0][11].ToString());
                pictureEdit3.Image = Image.FromFile(path3);
            }
        }

        private void DownloadFile(string filePath, string filename)
        {
            FtpWebRequest reqFTP;

            try
            {
                FileStream outputStream = new FileStream(filePath + @"\" + filename, FileMode.Create);

                reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(Properties.Settings.Default.FtpFilePath + filename));

                reqFTP.Method = WebRequestMethods.Ftp.DownloadFile;

                reqFTP.UseBinary = true;

                reqFTP.Credentials = new NetworkCredential("Administrator", "");

                FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();

                Stream ftpStream = response.GetResponseStream();

                long cl = response.ContentLength;

                int bufferSize = 1024;

                int readCount;

                byte[] buffer = new byte[bufferSize];

                readCount = ftpStream.Read(buffer, 0, bufferSize);

                while (readCount > 0)
                {
                    outputStream.Write(buffer, 0, readCount);

                    readCount = ftpStream.Read(buffer, 0, bufferSize);
                }

                ftpStream.Close();

                outputStream.Close();

                response.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void simpleButtonOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}