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
    public partial class AddDirection : DevExpress.XtraEditors.XtraForm
    {
        public AddDirection()
        {
            InitializeComponent();
        }
        public AddDirection(int i,string str)
        {
            InitializeComponent();
            update = i;
            if(i==0)
            {
                textEditfbh.Text= str;
                textEditfbh.Enabled = false;

                
            }
            if(i==1)
              {
                  temp = LongChang_TollGateBusiness.Instance.GetTollGateInfoByKaKouID(ref errMessage, str);
                  textEditbh.Text = temp.tollNum;
                  textEditmc.Text = temp.tollName;
                  textEditjc.Text = temp.tollShort;
                  textEditfbh.Text = temp.tollParentNum;
                    
              }

            
        }
        private void simpleButtonCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public int update = 0;
        public string str;
        public string errMessage = "";
        public LongChang_TollGateInfo temp = new LongChang_TollGateInfo();                 
        private void simpleButtonOK_Click(object sender, EventArgs e)
        {
            if(update==0)
            {
                temp.tollNum = textEditbh.Text;
                temp.tollName = textEditmc.Text;
                temp.tollShort = textEditjc.Text;
                temp.tollParentNum = textEditfbh.Text;
                LongChang_TollGateBusiness.Instance.Insert(ref errMessage, temp);
                XtraMessageBox.Show("添加方向成功");
                this.Close();
            }
            if(update==1)
            {

                temp.tollNum = textEditbh.Text;
                temp.tollName = textEditmc.Text;
                temp.tollShort = textEditjc.Text;
                temp.tollParentNum = textEditfbh.Text;
                LongChang_TollGateBusiness.Instance.Delete(ref errMessage, temp.tollNum);
                LongChang_TollGateBusiness.Instance.Insert(ref errMessage, temp);
                XtraMessageBox.Show("更新方向成功");
                this.Close();
                
            }
        }
    }
}