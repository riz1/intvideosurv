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
    public partial class AddCameraInVirtualGroup : DevExpress.XtraEditors.XtraForm
    {
        private string errMessage = "";
        Dictionary<int, CameraInfo> addCamera;
        Dictionary<int, GroupInfo> _listGroup = null;
        Dictionary<int, LongChang_CameraInfo> listCamera;
        public int Groupid{get;set;}
        public AddCameraInVirtualGroup()
        {
            InitializeComponent();
            LoadCameraInfo();
        }
        public void LoadCameraInfo()
        {
            listCamera = LongChang_CameraBusiness.Instance.GetAllCameraInfo(ref errMessage);
            TreeListNode root = treeList1CameraInVirtualGroup.AppendNode(new[] { "设备名称", "0" + ";R" }, -1, 0, 3, 1, CheckState.Checked);
            root.Tag = "0" + ";R";
            foreach (KeyValuePair<int,LongChang_CameraInfo> item in listCamera)
            {
                TreeListNode node = treeList1CameraInVirtualGroup.AppendNode(new[] { item.Value.TollGateName + item.Value.Name, item.Key + ";G" }, root.Id, 0, 3, 1, CheckState.Checked);
                node.Tag = item.Key.ToString() + ";G";
            }
            treeList1CameraInVirtualGroup.Columns[1].Visible = false;
            treeList1CameraInVirtualGroup.ExpandAll();

        }

        private void simpleButton1AddCameraInVirtualGroup_Click(object sender, EventArgs e)
        {
            int cameraid;
            cameraid = int.Parse(treeList1CameraInVirtualGroup.FocusedNode.Tag.ToString().Split(';')[0]);
            CameraGroupInfo item=new CameraGroupInfo();
            item.CameraID=cameraid;
            item.GroupID=Groupid;
            int id = CameraGroupBusiness.Instance.InsertCamera(ref errMessage, item);
                    if (-1 == id)
                    {
                        XtraMessageBox.Show("对不起，您添加的摄像头已经被其他的组使用，请另选");
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

        private void simpleButtonCancelInVG_Click(object sender, EventArgs e)
        {
            this.Close();
        }
           
        

    }
}