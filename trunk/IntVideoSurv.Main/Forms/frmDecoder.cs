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
    public partial class frmDecoder : DevExpress.XtraEditors.XtraForm
    {
        public frmDecoder()
        {
            InitializeComponent();
            Opt = Util.Operateion.Add;  
            InitValidationRules();
        }

        private static string decoderOldName = "";
        public frmDecoder(DecoderInfo decoderInfo)
        {
            InitializeComponent();
            this.Text = "更新解码器";
            simpleButtonOk.TabIndex = 0;
            this.textEditname.Text = decoderInfo.Name;
            this.textEditIp.Text = decoderInfo.Ip;
            this.textEditport.Text = decoderInfo.Port.ToString();
            this.textEditmax.Text = decoderInfo.MaxDecodeChannelNo.ToString();
            Opt = Util.Operateion.Update;
            decoderOldName = decoderInfo.Name;
            InitValidationRules();

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
            if (!dxValidationProvider1.Validate())
            {
                return;
            }

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

        #region  数据验证
        public class DecoderNameValidationRule : ValidationRule
        {
            public override bool Validate(Control control, object value)
            {
                string errMessage = "";
                var str = (string)value;
                return !string.IsNullOrEmpty(str) && str.Length>=4 && ((DecoderBusiness.Instance.GetDecoderInfoByName(ref errMessage,str)).Count==0);

            }
        }

        public class DecoderUpdateNameValidationRule : ValidationRule
        {
            public override bool Validate(Control control, object value)
            {
                string errMessage = "";
                var str = (string)value;
                bool ret;
                if (decoderOldName != str)
                {
                    ret = !string.IsNullOrEmpty(str) && str.Length >= 4 && ((DecoderBusiness.Instance.GetDecoderInfoByName(ref errMessage, str)).Count == 0);
                }
                else
                {
                    ret = !string.IsNullOrEmpty(str) && str.Length >= 4;
                }
                return ret;

            }
        }

        public class IpValidationRule : ValidationRule
        {
            public override bool Validate(Control control, object value)
            {
                var str = (string)value;
                return !string.IsNullOrEmpty(str)&&Regex.IsMatch(str, @"^((2[0-4]\d|25[0-5]|[01]?\d\d?)\.){3}(2[0-4]\d|25[0-5]|[01]?\d\d?)$"); ;
            }
        }
        public class PortValidationRule : ValidationRule
        {
            public override bool Validate(Control control, object value)
            {
                var str = (string)value;
                int ret = -1;
                bool retbool = int.TryParse(str, out ret);
                return (!string.IsNullOrEmpty(str))&&retbool&& ret>0&&ret<65535;
            }
        }

        public class MaxDecodeChannelValidationRule : ValidationRule
        {
            public override bool Validate(Control control, object value)
            {
                var str = (string)value;
                int ret = -1;
                bool retbool = int.TryParse(str, out ret);
                return (!string.IsNullOrEmpty(str))&& retbool && ret > 0 && ret < 20;
            }
        }
        

        private void InitValidationRules()
        {
            if (Opt == Util.Operateion.Add)
            {
                var decoderNameValidationRule = new DecoderNameValidationRule();
                decoderNameValidationRule.ErrorText = "名称必须长度大于4且还未被使用!";
                dxValidationProvider1.SetValidationRule(textEditname, decoderNameValidationRule);
                dxValidationProvider1.SetIconAlignment(textEditname, ErrorIconAlignment.MiddleRight);
            }
            else if (Opt == Util.Operateion.Update)
            {
                var decoderNameValidationRule = new DecoderUpdateNameValidationRule();
                decoderNameValidationRule.ErrorText = "名称必须长度大于4且还未被使用!";
                dxValidationProvider1.SetValidationRule(textEditname, decoderNameValidationRule);
                dxValidationProvider1.SetIconAlignment(textEditname, ErrorIconAlignment.MiddleRight);
            }



            //IP地址验证
            var ipValidationRule = new IpValidationRule();
            ipValidationRule.ErrorText = "必须是合法的IP地址";

            dxValidationProvider1.SetValidationRule(textEditIp, ipValidationRule);
            dxValidationProvider1.SetIconAlignment(textEditIp, ErrorIconAlignment.MiddleRight);

            //端口验证
            var portValidationRule = new PortValidationRule();
            portValidationRule.ErrorText = "必须是合法的端口0-65535";

            dxValidationProvider1.SetValidationRule(textEditport, portValidationRule);
            dxValidationProvider1.SetIconAlignment(textEditport, ErrorIconAlignment.MiddleRight);

            //最大解码通道数验证
            var maxDecodeChannelValidationRule = new MaxDecodeChannelValidationRule();
            maxDecodeChannelValidationRule.ErrorText = "合法的解码通道1-20";

            dxValidationProvider1.SetValidationRule(textEditmax, maxDecodeChannelValidationRule);
            dxValidationProvider1.SetIconAlignment(textEditmax, ErrorIconAlignment.MiddleRight);


        }
        #endregion
    }
}