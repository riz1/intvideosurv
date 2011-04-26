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
using IntVideoSurv.Entity;
using IntVideoSurv.Business;

namespace CameraViewer.Forms
{
    public partial class AddRecognizer : DevExpress.XtraEditors.XtraForm
    {

        public AddRecognizer()
        {
            InitializeComponent();
            Opt = Util.Operateion.Add;  
            InitValidationRules();
        }

        private static string recognizerOldName = "";
        public AddRecognizer(RecognizerInfo decoderInfo)
        {
            InitializeComponent();
            this.Text = "更新识别器";
            simpleButtonOk.TabIndex = 0;
            this.textEditname.Text = decoderInfo.Name;
            this.textEditIp.Text = decoderInfo.Ip;
            this.textEditport.Text = decoderInfo.Port.ToString();
            this.textEditmax.Text = decoderInfo.MaxRecogNumber.ToString();
            if(decoderInfo.RecogType==1)
                this.comboBoxEdit_Type.Text ="Event";
            if (decoderInfo.RecogType == 2)
                this.comboBoxEdit_Type.Text = "Vehicle";
            if (decoderInfo.RecogType == 4)
                this.comboBoxEdit_Type.Text = "Face";
            Opt = Util.Operateion.Update;
            recognizerOldName = decoderInfo.Name;
            InitValidationRules();

        }

        public int Id
        {
            set;
            get;
        }
        //
        public enum E_Type
        {
            E_Event = 1,
            E_Vehicle = 2,
            E_Face = 4,
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
            if (!dxValidationProvider1.Validate())
            {
                return;
            }
            RecognizerInfo ri = new RecognizerInfo();
            ri.Id = Id;
            ri.Name = textEditname.Text;
            ri.Port = int.Parse(textEditport.Text);
            ri.Ip = textEditIp.Text;
            ri.MaxRecogNumber = int.Parse(textEditmax.Text);
            if (comboBoxEdit_Type.Text == "Event")
                ri.RecogType = (int)E_Type.E_Event;
            if (comboBoxEdit_Type.Text == "Vehicle")
                ri.RecogType = (int)E_Type.E_Vehicle;
            if (comboBoxEdit_Type.Text == "Face")
                ri.RecogType = (int)E_Type.E_Face;
            switch (Opt)
            {
                case Util.Operateion.Add:
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
                    ri.Name = textEditname.Text;
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

        #region  数据验证
        public class DecoderNameValidationRule : ValidationRule
        {
            public override bool Validate(Control control, object value)
            {
                string errMessage = "";
                var str = (string)value;
                return !string.IsNullOrEmpty(str) && str.Length >= 4 && ((DecoderBusiness.Instance.GetDecoderInfoByName(ref errMessage, str)).Count == 0);

            }
        }

        public class DecoderUpdateNameValidationRule : ValidationRule
        {
            public override bool Validate(Control control, object value)
            {
                string errMessage = "";
                var str = (string)value;
                bool ret;
                if (recognizerOldName != str)
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
                return !string.IsNullOrEmpty(str) && Regex.IsMatch(str, @"^((2[0-4]\d|25[0-5]|[01]?\d\d?)\.){3}(2[0-4]\d|25[0-5]|[01]?\d\d?)$"); ;
            }
        }
        public class PortValidationRule : ValidationRule
        {
            public override bool Validate(Control control, object value)
            {
                var str = (string)value;
                int ret = -1;
                bool retbool = int.TryParse(str, out ret);
                return (!string.IsNullOrEmpty(str)) && retbool && ret > 0 && ret < 65535;
            }
        }

        public class MaxDecodeChannelValidationRule : ValidationRule
        {
            public override bool Validate(Control control, object value)
            {
                var str = (string)value;
                int ret = -1;
                bool retbool = int.TryParse(str, out ret);
                return (!string.IsNullOrEmpty(str)) && retbool && ret > 0 && ret < 20;
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