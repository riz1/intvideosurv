using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraTreeList.Nodes;
using IntVideoSurv.Business;
using IntVideoSurv.Entity;
namespace CameraViewer.Controls
{
    public partial class DeviceMaintain : DevExpress.XtraEditors.XtraUserControl
    {
        private string errMessage = "";
        Dictionary<int, GroupInfo> listGroup;
        public DeviceMaintain()
        {
            InitializeComponent();
            listGroup = GroupBusiness.Instance.GetAllGroupInfos(ref errMessage);
            BuildTree(null, 0);
        }
        private void BuildTree(TreeListNode aNode,int ParentId)
        {
            try
            {

                treeList1.BeginUnboundLoad();
                TreeListNode node;
                TreeListNode devicenode;
                TreeListNode camnode;
                foreach (KeyValuePair<int, GroupInfo> item in listGroup)
                {
                    if (item.Value.ParentId == ParentId)
                    {
                        node = treeList1.AppendNode(new object[] { item.Value.Name }, aNode);
                        node.Tag = item.Key.ToString() + ";G";
                        foreach (KeyValuePair<int, DeviceInfo> device in item.Value.ListDevice)
                        {
                            devicenode = treeList1.AppendNode(new object[] { device.Value.Name }, node);
                            devicenode.Tag = device.Key.ToString() + ";D";
                            foreach (KeyValuePair<int, CameraInfo> cam in device.Value.ListCamera)
                            {
                                camnode = treeList1.AppendNode(new object[] { cam.Value.Name }, devicenode);
                                camnode.Tag = cam.Key.ToString() + ";C";
                            }
                        }
                        BuildTree(node, item.Key);

                    }

                }
            }
            catch (Exception ex)
            {
            }

        }
       
    }
}
