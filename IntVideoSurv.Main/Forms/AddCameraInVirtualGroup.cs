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
        public int Groupid{get;set;}
        public AddCameraInVirtualGroup()
        {
            InitializeComponent();
            LoadCameraInfo();
        }
        public void LoadCameraInfo()
        {
            treeList1CameraInVirtualGroup.Nodes.Clear();
            _listGroup = GroupBusiness.Instance.GetAllGroupInfos(ref errMessage);
            foreach (KeyValuePair<int, GroupInfo> item in _listGroup)
            {
                TreeListNode treeListNodeGroup = treeList1CameraInVirtualGroup.AppendNode(new[] { item.Value.Name, item.Key + ";G" }, -1, 0, 3, 1, CheckState.Checked);
                treeListNodeGroup.Tag = item.Key.ToString() + ";G";
                foreach (var vDevice in item.Value.ListDevice)
                {
                    TreeListNode treeListNodeDevice = treeList1CameraInVirtualGroup.AppendNode(new[] { vDevice.Value.Name, vDevice.Key + ";D" }, treeListNodeGroup.Id, 1, 3, 1, CheckState.Checked);
                    treeListNodeDevice.Tag = vDevice.Key.ToString() + ";D";
                    foreach (var vCamera in vDevice.Value.ListCamera)
                    {
                        TreeListNode treeListNodeCamera = treeList1CameraInVirtualGroup.AppendNode(new[] { vCamera.Value.Name, vCamera.Key + ";C" }, treeListNodeDevice.Id, 1, 3, 1, CheckState.Checked);
                        treeListNodeCamera.Tag = vCamera.Key.ToString() + ";C";

                    }

                }
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