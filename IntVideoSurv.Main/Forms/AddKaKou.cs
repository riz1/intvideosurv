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
    public partial class AddKaKou : DevExpress.XtraEditors.XtraForm
    {
        public AddKaKou()
        {
            InitializeComponent();
        }
        public AddKaKou(int i,string str)
        {
            InitializeComponent();
            update = i;
            if(i==0)
            {
                textEditfbh.Text = "moniroot";
                textEditfbh.Enabled = false;
                
            }
            if(i==1)
            {
                temp = LongChang_TollGateBusiness.Instance.GetTollGateInfoByKaKouID(ref errMessage, str);
                textEditNum.Text = temp.tollNum;
                textEditName.Text = temp.tollName;
                textEditJianCh.Text = temp.tollShort;
                textEditwzhi.Text = temp.tollPosition;
                textEditLeixing.Text = temp.tollType;
                textEditgxdwbh.Text = temp.departmentNum;
                textEditxzh.Text = temp.administrationDivsion;
                textEditshxtbh.Text = temp.cameraNum.ToString();
                textEditdlbh.Text = temp.roadNum;
                textEditdlmc.Text = temp.roadName;
                textEditfbh.Text = temp.tollParentNum;
                
            }
            
        }

        private void simpleButtoncancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //
        public int update;
        public LongChang_TollGateInfo temp = new LongChang_TollGateInfo();
        string errMessage = "";
        private void simpleButtonOK_Click(object sender, EventArgs e)
        {
            if(update==0)
            {
               // string errMessage = "";
                //LongChang_TollGateInfo temp = new LongChang_TollGateInfo();
                temp.tollNum = textEditNum.Text;
                temp.tollName = textEditName.Text;
                temp.tollShort = textEditJianCh.Text;
                temp.tollPosition = textEditwzhi.Text;
                temp.tollType = textEditLeixing.Text;
                temp.departmentNum = textEditgxdwbh.Text;
                temp.administrationDivsion = textEditxzh.Text;
                if (textEditshxtbh.Text == "")
                    temp.cameraNum = 0;
                else
                   temp.cameraNum = int.Parse(textEditshxtbh.Text);
                temp.roadNum = textEditdlbh.Text;
                temp.roadName = textEditdlmc.Text;
                temp.tollParentNum = textEditfbh.Text;
                LongChang_TollGateBusiness.Instance.Insert(ref errMessage, temp);
                XtraMessageBox.Show("添加卡口成功");
                this.Close();
                OperateLogBusiness.Instance.Insert(ref errMessage,
                                                   new OperateLog
                                                   {
                                                       ClientUserId = MainForm.CurrentUser.UserId,
                                                       ClientUserName = MainForm.CurrentUser.UserName,
                                                       Content = temp.ToString(),
                                                       HappenTime = DateTime.Now,
                                                       OperateTypeId = (int)(OperateLogTypeId.TollGateKaKouAdd),
                                                       OperateTypeName = OperateLogTypeName.TollGateKaKouAdd,
                                                       OperateUserName = MainForm.CurrentUser.UserName
                                                   });
            }
            if (update==1)
            {

                temp.tollNum = textEditNum.Text;
                temp.tollName = textEditName.Text;
                temp.tollShort = textEditJianCh.Text;
                temp.tollPosition = textEditwzhi.Text;
                temp.tollType = textEditLeixing.Text;
                temp.departmentNum = textEditgxdwbh.Text;
                temp.administrationDivsion = textEditxzh.Text;
                if (textEditshxtbh.Text == "")
                    temp.cameraNum = 0;
                else
                    temp.cameraNum = int.Parse(textEditshxtbh.Text);
                temp.roadNum = textEditdlbh.Text;
                temp.roadName = textEditdlmc.Text;
                temp.tollParentNum = textEditfbh.Text;
                LongChang_TollGateBusiness.Instance.Delete(ref errMessage, temp.tollNum);
                LongChang_TollGateBusiness.Instance.Insert(ref errMessage, temp);
                XtraMessageBox.Show("更新卡口成功");
                this.Close();
                OperateLogBusiness.Instance.Insert(ref errMessage,
                                   new OperateLog
                                   {
                                       ClientUserId = MainForm.CurrentUser.UserId,
                                       ClientUserName = MainForm.CurrentUser.UserName,
                                       Content = temp.ToString(),
                                       HappenTime = DateTime.Now,
                                       OperateTypeId = (int)(OperateLogTypeId.TollGateKaKouUpdate),
                                       OperateTypeName = OperateLogTypeName.TollGateKaKouUpdate,
                                       OperateUserName = MainForm.CurrentUser.UserName
                                   });
            }

        }
    }
}