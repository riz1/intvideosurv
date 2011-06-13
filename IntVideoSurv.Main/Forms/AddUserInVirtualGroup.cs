using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraTreeList.Nodes;
using IntVideoSurv.Business;
using IntVideoSurv.Entity;

namespace CameraViewer.Forms
{
    public partial class AddUserInVirtualGroup : DevExpress.XtraEditors.XtraForm
    {
        Dictionary<int, UserInfo> list = null;
        private string errMessage = "";
        public AddUserInVirtualGroup()
        {
            InitializeComponent();
            LoadUser();
        }
        private void LoadUser()
        {
            treeList1UserInVirtualGroup.Nodes.Clear();
            TreeListNode treeUserNode;
            TreeListNode treeListNodeRoot = treeList1UserInVirtualGroup.AppendNode(new[] { "用户管理", 0 + ";G" }, -1, 0, 3, 1, CheckState.Checked);
            treeListNodeRoot.Tag = "0" + ";G";
            list = UserBusiness.Instance.GetAllUserInfo(ref errMessage);
            foreach (KeyValuePair<int, UserInfo> item in list)
            {
                treeUserNode = treeList1UserInVirtualGroup.AppendNode(new[] { item.Value.UserName, item.Key + ";A" }, treeListNodeRoot.Id, 0, 3, 1, CheckState.Checked);
                treeUserNode.Tag = item.Key.ToString() + ";A";
            }
            treeList1UserInVirtualGroup.Columns[1].Visible = false;
            treeList1UserInVirtualGroup.ExpandAll();

        }
        public int Groupid { get; set; }
        private void simpleButton1AddUserInVirtualGroup_Click(object sender, EventArgs e)
        {
            int userid;
            userid = int.Parse(treeList1UserInVirtualGroup.FocusedNode.Tag.ToString().Split(';')[0]);
            int id = UserGroupBusiness.Instance.InsertUser(ref errMessage, userid, Groupid);
            if (-1 == id)
            {
                XtraMessageBox.Show("对不起，您添加的用户已经被其他的组使用，请另选");
            }
            else
            {
                OperateLog ol = new OperateLog
                {
                    HappenTime = DateTime.Now,
                    OperateTypeId = (int)(OperateLogTypeId.CameraAddInVirtualGroup),
                    OperateTypeName = OperateLogTypeName.CameraAddInVirtualGroup,
                    Content = id.ToString(),
                    OperateUserName = MainForm.CurrentUser.UserName,
                    ClientUserName = MainForm.CurrentUser.UserName,
                    ClientUserId = MainForm.CurrentUser.UserId
                };
                OperateLogBusiness.Instance.Insert(ref errMessage, ol);
            }
            Close();
            Dispose();
        }

        private void simpleButtonuserCancelInVG_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}