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
    public partial class AddXtraForm : DevExpress.XtraEditors.XtraForm
    {
        public AddXtraForm()
        {
            InitializeComponent();
        }

        private string errMessage = "";
        public CameraViewer.Util.Operateion Opt
        {
            set;
            get;
        }

        public int Id
        {
            set; 
            get;
        }
        private void AddDecoderButton(object sender, EventArgs e)
        {
            //string errMessage = "";
            DecoderInfo di = new DecoderInfo();
            di.id = Id;
            di.Name = textEditname.Text;
            di.Port = int.Parse(textEditport.Text);
            di.Ip = textEditIp.Text;
            di.MaxDecodeChannelNo = int.Parse(textEditmax.Text);
            switch(Opt)
            {
                case Util.Operateion.Add:
                    
                    DecoderBusiness.Instance.Insert(ref errMessage, di);
                    OperateLog ol = new OperateLog
                    {
                        HappenTime = DateTime.Now,
                        OperateTypeId = (int)(OperateLogTypeId.DecoderAdd),
                        OperateTypeName = OperateLogTypeName.DecoderAdd,
                        Content = di.ToString(),
                        Id = di.id,
                        OperateUserName = MainForm.CurrentUser.UserName,
                        ClientUserName = MainForm.CurrentUser.UserName,
                        ClientUserId = MainForm.CurrentUser.UserId
                    };
                    OperateLogBusiness.Instance.Insert(ref errMessage, ol);
                    break;
                case Util.Operateion.Update:
                    di = DecoderBusiness.Instance.GetDecoderInfoByDecoderId(ref errMessage, Id);
                    di.Name = textEditname.Text;
                    di.Port = int.Parse(textEditport.Text);
                    di.Ip = textEditIp.Text;
                    di.MaxDecodeChannelNo = int.Parse(textEditmax.Text);
                    Id = DecoderBusiness.Instance.Update(ref errMessage, di);
                    OperateLogBusiness.Instance.Insert(ref errMessage, new OperateLog
                    {
                        HappenTime = DateTime.Now,
                        OperateTypeId = (int)(OperateLogTypeId.DecoderUpdate),
                        OperateTypeName = OperateLogTypeName.DecoderUpdate,
                        Content = di.ToString(),
                        Id = di.id,
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