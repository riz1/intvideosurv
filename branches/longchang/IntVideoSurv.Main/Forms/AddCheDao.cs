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
    public partial class AddCheDao : DevExpress.XtraEditors.XtraForm
    {
        private string errMessage = "";
        public string directionNum{ get;set;}
        public AddCheDao(string name)
        {
            InitializeComponent();
            Opt = Util.Operateion.Add;
            textEditParentNum.Text = name;
            textEditParentNum.Enabled = false;
        }
        public AddCheDao(LongChang_TollGateInfo lt)
        {
            InitializeComponent();
            this.Text = "更新车道";
            textEditParentNum.Text = lt.tollParentNum;
            textEditParentNum.Enabled = false;
            textEditTollGateNum.Text = lt.tollNum;
            textEditTollGateName.Text = lt.tollName;
            textEditTollGateShorter.Text = lt.tollShort;
            textEditVehicleCamera.Text = lt.cameraNum.ToString();
        }
        private void simpleButtonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public CameraViewer.Util.Operateion Opt
        {
            set;
            get;
        }
        public string Id
        {
            set;
            get;
        }
        private void simpleButtonOk_Click(object sender, EventArgs e)
        {
            LongChang_TollGateInfo tollgate = new LongChang_TollGateInfo();
            switch (Opt)
            {
                case Util.Operateion.Add:
                    tollgate.tollParentNum = directionNum;
                    tollgate.tollNum = textEditTollGateNum.Text;
                    tollgate.tollName = textEditTollGateName.Text;
                    tollgate.tollShort = textEditTollGateShorter.Text;
                    tollgate.cameraNum = int.Parse(textEditVehicleCamera.Text);
                    int i = LongChang_TollGateBusiness.Instance.InsertCheDao(ref errMessage, tollgate);
                    XtraMessageBox.Show("添加成功");
                    OperateLogBusiness.Instance.Insert(ref errMessage, new OperateLog
                    {
                        HappenTime = DateTime.Now,
                        OperateTypeId = (int)(OperateLogTypeId.TollGateCheDaoAdd),
                        OperateTypeName = OperateLogTypeName.TollGateCheDaoAdd,
                        Content = tollgate.ToString(),
                        Id = int.Parse(tollgate.tollNum),
                        OperateUserName = MainForm.CurrentUser.UserName,
                        ClientUserName = MainForm.CurrentUser.UserName,
                        ClientUserId = MainForm.CurrentUser.UserId
                    });
                    this.Close();

                    break;
                case Util.Operateion.Update:
                    tollgate = LongChang_TollGateBusiness.Instance.GetTollGateInfoByKaKouID(ref errMessage, Id);
                    tollgate.tollNum = textEditTollGateNum.Text;
                    tollgate.tollName = textEditTollGateName.Text;
                    tollgate.tollShort = textEditTollGateShorter.Text;
                    tollgate.cameraNum = int.Parse(textEditVehicleCamera.Text);
                    LongChang_TollGateBusiness.Instance.Update(ref errMessage, tollgate);
                    XtraMessageBox.Show("添加成功");
                    OperateLogBusiness.Instance.Insert(ref errMessage, new OperateLog
                    {
                        HappenTime = DateTime.Now,
                        OperateTypeId = (int)(OperateLogTypeId.TollGateCheDaoUpdate),
                        OperateTypeName = OperateLogTypeName.TollGateCheDaoUpdate,
                        Content = tollgate.ToString(),
                        Id = int.Parse(tollgate.tollNum),
                        OperateUserName = MainForm.CurrentUser.UserName,
                        ClientUserName = MainForm.CurrentUser.UserName,
                        ClientUserId = MainForm.CurrentUser.UserId
                    });
                    break;
            }
           
            
        }
    }
}