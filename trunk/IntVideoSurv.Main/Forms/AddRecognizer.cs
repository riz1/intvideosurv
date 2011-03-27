using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using IntVideoSurv.Entity;
using IntVideoSurv.Business;

namespace CameraViewer.Forms
{
    public partial class AddRecognizer : DevExpress.XtraEditors.XtraForm
    {
        public AddRecognizer()
        {
            InitializeComponent();
        }
        public AddRecognizer(RecognizerInfo ri)
        {
            InitializeComponent();
            textEditname.Text = ri.Name;
            textEditname.Enabled = false;
            this.Text = "修改识别器";

        }
        public int Id
        {
            set;
            get;
        }
        private string errMessage = "";
        public CameraViewer.Util.Operateion Opt
        {
            set;
            get;
        }
        /// <summary>
        /// 增加识别器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButtonOk_Click(object sender, EventArgs e)
        {
            RecognizerInfo ri = new RecognizerInfo();
            ri.Id = Id;
            ri.Name = textEditname.Text;
            ri.Port = int.Parse(textEditport.Text);
            ri.Ip = textEditIp.Text;
            ri.MaxRecogNumber = int.Parse(textEditmax.Text);
            switch (Opt)
            {
                case Util.Operateion.Add:
                    //di.Name = textEditname.Text;
                    RecognizerBusiness.Instance.Insert(ref errMessage, ri);
                    OperateLog ol = new OperateLog
                    {
                        HappenTime = DateTime.Now,
                        OperateTypeId = (int)(OperateLogTypeId.RecognizerAdd),
                        OperateTypeName = OperateLogTypeName.RecognizerAdd,
                        Content = ri.ToString(),
                        Id = ri.Id,
                        OperateUserName = MainForm.CurrentUser.UserName,
                        ClientUserName = MainForm.CurrentUser.UserName,
                        ClientUserId = MainForm.CurrentUser.UserId
                    };
                    OperateLogBusiness.Instance.Insert(ref errMessage, ol);
                    break;
                case Util.Operateion.Update:
                    ri = RecognizerBusiness.Instance.GetRecognizerInfoByRecognizerId(ref errMessage,Id);
                    //di.Name = textEditname.Text;
                    ri.Port = int.Parse(textEditport.Text);
                    ri.Ip = textEditIp.Text;
                    ri.MaxRecogNumber = int.Parse(textEditmax.Text);
                    Id = RecognizerBusiness.Instance.Update(ref errMessage, ri);
                    OperateLogBusiness.Instance.Insert(ref errMessage, new OperateLog
                    {
                        HappenTime = DateTime.Now,
                        OperateTypeId = (int)(OperateLogTypeId.RecognizerUpdate),
                        OperateTypeName = OperateLogTypeName.RecognizerUpdate,
                        Content = ri.ToString(),
                        Id = ri.Id,
                        OperateUserName = MainForm.CurrentUser.UserName,
                        ClientUserName = MainForm.CurrentUser.UserName,
                        ClientUserId = MainForm.CurrentUser.UserId
                    });
                    break;
                case Util.Operateion.Delete:
                    break;
                default:
                    break;

            }
            Close();
            Dispose();
        }

        private void simpleButtoncancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}