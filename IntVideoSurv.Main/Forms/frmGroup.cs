using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using IntVideoSurv.Business;
using IntVideoSurv.Entity;

namespace CameraViewer.Forms
{
    public partial class frmGroup : DevExpress.XtraEditors.XtraForm
    {
        private string errMessage = "";
        public CameraViewer.Util.Operateion Opt
        {
            set;
            get;
        }
        public frmGroup()
        {
            InitializeComponent();
        }
        public int GroupId
        {
            set;
            get;
        }
        public int ParentGroupId
        {
            set;
            get;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            GroupInfo ogroup=new GroupInfo();
            ogroup.Name = txtName.Text;
            ogroup.Description =txtDescription.Text;
            ogroup.ParentId = ParentGroupId;
            ogroup.GroupID = GroupId;
            errMessage = "";
            switch (Opt)
            {
                case Util.Operateion.Add:
                    GroupId = GroupBusiness.Instance.Insert(ref errMessage, ogroup);
                    ogroup = GroupBusiness.Instance.GetGroupInfoByGroupName(ref errMessage, ogroup.Name);
                    OperateLogBusiness.Instance.Insert(ref errMessage, new OperateLog
                    {
                        HappenTime = DateTime.Now,
                        OperateTypeId = (int)(OperateLogTypeId.GroupAdd),
                        OperateTypeName = OperateLogTypeName.GroupAdd,
                        Content = ogroup.ToString(),
                        GroupId = ogroup.GroupID,
                        OperateUserName = MainForm.CurrentUser.UserName,
                        ClientUserName = MainForm.CurrentUser.UserName,
                        ClientUserId = MainForm.CurrentUser.UserId
                    });
                    break;
                case Util.Operateion.Update:
                    ogroup = GroupBusiness.Instance.GetGroupInfoByGroupId(ref errMessage, GroupId);
                    ogroup.Name = txtName.Text;
                    ogroup.Description = txtDescription.Text;
                    GroupId = GroupBusiness.Instance.Update(ref errMessage, ogroup);
                    OperateLogBusiness.Instance.Insert(ref errMessage, new OperateLog
                    {
                        HappenTime = DateTime.Now,
                        OperateTypeId = (int)(OperateLogTypeId.GroupUpdate),
                        OperateTypeName = OperateLogTypeName.GroupUpdate,
                        Content = ogroup.ToString(),
                        GroupId = ogroup.GroupID,
                        OperateUserName = MainForm.CurrentUser.UserName,
                        ClientUserName = MainForm.CurrentUser.UserName,
                        ClientUserId = MainForm.CurrentUser.UserId
                    });
                    break;
                case Util.Operateion.Delete:
                    ogroup = GroupBusiness.Instance.GetGroupInfoByGroupId(ref errMessage, GroupId);
                    GroupId = GroupBusiness.Instance.Delete(ref errMessage, GroupId);
                    OperateLogBusiness.Instance.Insert(ref errMessage, new OperateLog
                        {
                            HappenTime = DateTime.Now,
                            OperateTypeId = (int)(OperateLogTypeId.GroupDelete),
                            OperateTypeName = OperateLogTypeName.GroupDelete ,
                            Content = ogroup.ToString(),
                            GroupId = ogroup.GroupID,
                            OperateUserName = MainForm.CurrentUser.UserName,
                            ClientUserName = MainForm.CurrentUser.UserName,
                            ClientUserId = MainForm.CurrentUser.UserId
                        });
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