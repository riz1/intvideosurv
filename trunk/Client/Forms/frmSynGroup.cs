using System;
using IntVideoSurv.Business;
using IntVideoSurv.Entity;

namespace CameraViewer.Forms
{
    public partial class frmSynGroup : DevExpress.XtraEditors.XtraForm
    {
        private string errMessage = "";
        public CameraViewer.Util.Operateion Opt
        {
            set;
            get;
        }
        public frmSynGroup()
        {
            InitializeComponent();
        }
        public int GeroupId
        {
            set;
            get;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Trim()=="")
            {
                return;
            }
            SynGroup ogroup = new SynGroup();
            ogroup.Name = txtName.Text;
            ogroup.Description =txtDescription.Text;
            errMessage = "";
            switch (Opt)
            {
                case Util.Operateion.Add:
                    GeroupId = SynGroupBusiness.Instance.Insert(ref errMessage, ogroup);
                    OperateLogBusiness.Instance.Insert(ref errMessage, new OperateLog
                       {
                           HappenTime = DateTime.Now, 
                           ClientUserId = MainForm.CurrentUser.UserId,
                           ClientUserName = MainForm.CurrentUser.UserName,
                           Content = ogroup.ToString(),
                           OperateTypeId =(int) OperateLogTypeId.SynGroupAdd,
                           OperateTypeName = OperateLogTypeName.SynGroupAdd,
                           OperateUserName = MainForm.CurrentUser.UserName

                       });
                    break;
                case Util.Operateion.Update:
                    //ogroup.GroupID = GeroupId;
                    GeroupId = SynGroupBusiness.Instance.Update(ref errMessage, ogroup);
                    
                    OperateLogBusiness.Instance.Insert(ref errMessage, new OperateLog
                    {
                        HappenTime = DateTime.Now,
                        ClientUserId = MainForm.CurrentUser.UserId,
                        ClientUserName = MainForm.CurrentUser.UserName,
                        Content = ogroup.ToString(),
                        OperateTypeId = (int)OperateLogTypeId.SynGroupUpdate,
                        OperateTypeName = OperateLogTypeName.SynGroupUpdate,
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