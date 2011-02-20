using System;
using IntVideoSurv.Business;
using IntVideoSurv.Entity;

namespace CameraViewer.Forms
{
    public partial class frmGroupSwitchGroup : DevExpress.XtraEditors.XtraForm
    {
        private string errMessage = "";
        public CameraViewer.Util.Operateion Opt
        {
            set;
            get;
        }
        public frmGroupSwitchGroup()
        {
            InitializeComponent();
        }
        public int GroupId
        {
            set;
            get;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            ProgSwitchInfo progSwitchInfo = new ProgSwitchInfo();
            progSwitchInfo.Name = txtName.Text;
            progSwitchInfo.Description =txtDescription.Text;
            errMessage = "";
            switch (Opt)
            {
                case Util.Operateion.Add:
                    GroupId = ProgSwitchBusiness.Instance.Insert(ref errMessage, progSwitchInfo);
                    OperateLogBusiness.Instance.Insert(ref errMessage, new OperateLog
                       {
                           HappenTime = DateTime.Now, 
                           ClientUserId = MainForm.CurrentUser.UserId,
                           ClientUserName = MainForm.CurrentUser.UserName,
                           Content = progSwitchInfo.ToString(),
                           OperateTypeId =(int) OperateLogTypeId.ProgSwitchAdd,
                           OperateTypeName = OperateLogTypeName.ProgSwitchAdd,
                           OperateUserName = MainForm.CurrentUser.UserName

                       });
                    break;
                case Util.Operateion.Update:
                    //ogroup.GroupID = GeroupId;
                    GroupId = ProgSwitchBusiness.Instance.Update(ref errMessage, progSwitchInfo);
                    
                    OperateLogBusiness.Instance.Insert(ref errMessage, new OperateLog
                    {
                        HappenTime = DateTime.Now,
                        ClientUserId = MainForm.CurrentUser.UserId,
                        ClientUserName = MainForm.CurrentUser.UserName,
                        Content = progSwitchInfo.ToString(),
                        OperateTypeId = (int)OperateLogTypeId.ProgSwitchUpdate,
                        OperateTypeName = OperateLogTypeName.ProgSwitchUpdate,
                        OperateUserName = MainForm.CurrentUser.UserName

                    });
                    break;
                case Util.Operateion.Delete:
                    break;
                default:
                    break;
            }
            if (errMessage.Length == 0)
            {
                this.Close();
            }
             
          
        }

    }
}