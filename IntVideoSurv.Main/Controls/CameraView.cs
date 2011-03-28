using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraTreeList.Nodes;
using IntVideoSurv.Entity;
using IntVideoSurv.Business;

namespace CameraViewer.Controls
{
    public enum EnumViewType
    {
        Normal = 0,
        SynSwitch = 1,
        GroupSwitch = 4,
        ProgSwitch =8

    }


    public partial class CameraView : DevExpress.XtraEditors.XtraUserControl
    {
        public CameraView()
        {
            InitializeComponent();
        }
        Dictionary<int, GroupInfo> _listGroup = null;
        Dictionary<int, SynGroup> _listSynGroup = null;
        Dictionary<int, GroupSwitchGroup> _listGroupSwitch = null;
        Dictionary<int, ProgSwitchInfo> _listProgSwitch = null;
        Dictionary<int, MapInfo> _listMap = null;
        Dictionary<int, DecoderInfo> _listDecoder = null;


        public delegate void TouchCamera(string tag);
        public delegate void TouchSynGroup(KeyValuePair<int, SynGroup> item);
        public event TouchCamera DoubleDevCam;
        public event TouchCamera ClickDevCam;
        public event TouchCamera DoubleSynGroup;
        public event TouchCamera DoubleSynSwitch;
        public event TouchCamera  DoubleProgSwitch;
        
        private string errMessage = "";

        public EnumViewType ViewType = EnumViewType.Normal;

        public Dictionary<int, GroupInfo> ListGroup
        {
            set
            {
                _listGroup = value;
                BuildTree();
            }

        }
        public Dictionary<int, MapInfo> ListMap
        {
            set
            {
                _listMap = value;
                BuildTree();
            }

        }
        public Dictionary<int, SynGroup> ListSynGroup
        {
            set
            {
                _listSynGroup = value;
                BuildSynGroupTree();
            }

        }

        public Dictionary<int, GroupSwitchGroup> ListGroupSwitch
        {
            set
            {
                _listGroupSwitch = value;
                BuildGroupSwitchGroupTree();
            }

        }
        public Dictionary<int, ProgSwitchInfo> ListProgSwitch
        {
            set
            {
                _listProgSwitch = value;
                BuildProgSwitchTree();
            }

        }

        public Dictionary<int, DecoderInfo> ListDecoder
        {
            set
            {
                _listDecoder = value;
                BuildDecoderTree();
            }

        }

        private TreeNode _lastSelectedTreeNode = null;
        private TreeListNode _lastSelectedTreeListNode = null;
        private Color _treeNodeDefaultColor;
        private bool _isTreeNodeClicked = false;
        private TreeNode selectedTreeNode = null;
        private TreeListNode selectedTreeListNode = null;
        private void BuildSynGroupTree()
        {
            //_listSynGroup = SynGroupBusiness.Instance.GetAllSynGroup(ref errMessage);
           /* if(_listSynGroup==null) return;
            Cursor currentCursor = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;
           // TreeListNode node;
            tvSynGroup.Nodes.Clear();

            foreach (KeyValuePair<int, SynGroup> item in _listSynGroup)
            {

                TreeListNode node = tvSynGroup.AppendNode(new[] { item.Value.Name, item.Key + ";S" }, -1, 1, 3, 1, CheckState.Checked);
                //node = new TreeListNode(item.Value.Name);
                node.Tag = item.Key + ";S";
                node.ImageIndex = 5;
                if (_lastSelectedTreeListNode != null)
                {
                    if (_lastSelectedTreeListNode.Tag.ToString() == node.Tag.ToString())
                    {
                        //node.BackColor = Color.Gray;
                        selectedTreeListNode = node;
                    }
                }
                AppendSynGroupNode(node);
                //tvSynGroup.Nodes.Add(node);
                tvSynGroup.Columns[1].Visible = false;

            }

            tvSynGroup.ExpandAll();
            if (selectedTreeNode != null)
            {
                tvSynGroup.FocusedNode = selectedTreeListNode;
            }
            Cursor.Current = currentCursor;*/
            Dictionary<int, DecoderInfo> listDecoder;
            listDecoder = DecoderBusiness.Instance.GetAllDecoderInfo(ref errMessage);
            Cursor currentCursor = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;
            TreeListNode node;
            TreeListNode camnode;

            tvSynGroup.Nodes.Clear();
            TreeListNode treeListNodeRoot = tvSynGroup.AppendNode(new[] { "解码器管理", 0 + ";T" }, -1, 0, 3, 1, CheckState.Checked);
            treeListNodeRoot.Tag = 0 + ";T";
            if (listDecoder != null)
            {

                foreach (KeyValuePair<int, DecoderInfo> item in listDecoder)
                {
                    TreeListNode treeListNodeDecoder = tvSynGroup.AppendNode(new[] { item.Value.Name, item.Key + ";D" }, treeListNodeRoot.Id, 1, 3, 1, CheckState.Checked);
                    treeListNodeDecoder.Tag = item.Key + ";D";
                    foreach (KeyValuePair<int, CameraInfo> cam in item.Value.ListCameras)
                    {
                        DeviceInfo di = DecoderBusiness.Instance.GetDeviceInfoByCameraId(ref errMessage, cam.Value.CameraId);
                        camnode = tvSynGroup.AppendNode(new[] { di.Name + ":" + cam.Value.Name, item.Key + ";C" }, treeListNodeDecoder.Id, 1, 3, 1, CheckState.Checked);
                        camnode.Tag = cam.Key + ";C";
                    }
                }
            }
            tvSynGroup.Columns[1].Visible = false;
            tvSynGroup.ExpandAll();
            Cursor.Current = currentCursor;
        }

        private void BuildDecoderTree()
        {
            Cursor currentCursor = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;
            TreeListNode camnode;

            tvSynGroup.Nodes.Clear();
            TreeListNode treeListNodeRoot = tvSynGroup.AppendNode(new[] { "解码器管理", 0 + ";T" }, -1, 0, 3, 1, CheckState.Checked);
            treeListNodeRoot.Tag = 0 + ";T";
            if (_listDecoder != null)
            {

                foreach (KeyValuePair<int, DecoderInfo> item in _listDecoder)
                {
                    TreeListNode treeListNodeDecoder = tvSynGroup.AppendNode(new[] { item.Value.Name, item.Key + ";D" }, treeListNodeRoot.Id, 1, 3, 1, CheckState.Checked);
                    treeListNodeDecoder.Tag = item.Key + ";D";
                    foreach (KeyValuePair<int, CameraInfo> cam in item.Value.ListCameras)
                    {
                        DeviceInfo di = DecoderBusiness.Instance.GetDeviceInfoByCameraId(ref errMessage, cam.Value.CameraId);
                        camnode = tvSynGroup.AppendNode(new[] { di.Name + ":" + cam.Value.Name, item.Key + ";C" }, treeListNodeDecoder.Id, 1, 3, 1, CheckState.Checked);
                        camnode.Tag = cam.Key + ";C";
                    }
                }
            }
            tvSynGroup.Columns[1].Visible = false;
            tvSynGroup.ExpandAll();
            Cursor.Current = currentCursor;
        }
        private static bool _isGroupOpened;

        private void BuildTree()
        {
            Cursor currentCursor = Cursor.Current;
            TreeNode node;

            switch (ViewType)
            {
                case EnumViewType.Normal:

                /*    if (_listGroup == null)
                    {
                        return;
                    }
                    Cursor.Current = Cursors.WaitCursor;
                    trCamera.Nodes.Clear();
                    foreach (KeyValuePair<int, GroupInfo> item in _listGroup)
                    {
                        if (item.Value.ParentId == 0)
                        {
                            node = new TreeNode(item.Value.Name);
                            node.Tag = item.Key + ";G";
                            node.ImageIndex = 0;
                            AppendNode(node, item.Key);
                            trCamera.Nodes.Add(node);
                            //treeList
                            
                        }
                    }*/
                    //测试TreeList
                    tlCamera.Nodes.Clear();
                    foreach (KeyValuePair<int, GroupInfo> item in _listGroup)
                    {
                        TreeListNode treeListNodeGroup = tlCamera.AppendNode(new[] {item.Value.Name, item.Key +";G"}, -1,0,3,1,CheckState.Checked);
                        treeListNodeGroup.Tag = item.Key + ";G";
                        foreach (var vDevice in item.Value.ListDevice)
                        {
                            TreeListNode treeListNodeDevice = tlCamera.AppendNode(new[] { vDevice.Value.Name, vDevice.Key + ";D" }, treeListNodeGroup.Id, 1, 3, 1, CheckState.Checked);
                            treeListNodeDevice.Tag = vDevice.Key + ";D";
                            foreach (var vCamera in vDevice.Value.ListCamera)
                            {
                                TreeListNode treeListNodeCamera = tlCamera.AppendNode(new[] { vCamera.Value.Name, vCamera.Key + ";C" }, treeListNodeDevice.Id, 2, 3, 1, CheckState.Checked);
                                treeListNodeCamera.Tag = vCamera.Key + ";C";
                            }

                        }
                    }
                    tlCamera.ExpandAll();

                    //添加地图
                    /*if (_listMap!=null)
                    {
                        node = new TreeNode("地图");
                        node.Tag = -1 + ";a";
                        foreach (KeyValuePair<int, MapInfo> item in _listMap)
                        {
                            TreeNode mapNode = new TreeNode(item.Value.Name);
                            mapNode.Tag = item.Key + ";m";
                            mapNode.ImageIndex = 0;
                            node.Nodes.Add(mapNode);
                        }

                        trCamera.Nodes.Add(node);                        
                    }*/


                    //trCamera.ExpandAll();
                    Cursor.Current = currentCursor;
                    break;

                case EnumViewType.SynSwitch:

                    if (_listSynGroup == null)
                    {
                        return;
                    }
                    if (!_isGroupOpened)
                    {
                        _isGroupOpened = true;
                    }
                    else
                    {
                        return;
                    }

                    Cursor.Current = Cursors.WaitCursor;
                    tvSynGroup.Nodes.Clear();
                    foreach (KeyValuePair<int, SynGroup> item in _listSynGroup)
                    {
                       // node = new TreeNode(item.Value.Name);
                        TreeListNode mynode = tvSynGroup.AppendNode(new[] { item.Value.Name, item.Key + ";S" }, -1, 1, 3, 1, CheckState.Checked);
                        mynode.Tag = item;
                        AppendNode(mynode);
                        //tvSynGroup.Nodes.Add(node);

                    }
                    tvSynGroup.ExpandAll();
                    Cursor.Current = currentCursor;
                    break;

                case EnumViewType.GroupSwitch:

                    break;
                default:
                    break;

            }


        }
        private void AppendNode(TreeListNode aNode)
        {
            foreach (KeyValuePair<int, CameraInfo> camPair in ((KeyValuePair<int, SynGroup>)(aNode.Tag)).Value.ListCamera)
            {
                TreeListNode node = tvSynGroup.AppendNode(new[] { camPair.Value.Name, camPair.Key + ";G" }, aNode.Id, 1, 3, 1, CheckState.Checked);
                node.Tag = camPair.Value;
               // aNode.Nodes.Add(node);

            }
        }
        private void AppendNode(TreeListNode aNode, int ParentId)
        {
            try
            {
                TreeListNode node;
                TreeListNode devicenode;
                TreeListNode camnode;
                foreach (KeyValuePair<int, GroupInfo> item in _listGroup)
                {
                    if (item.Value.ParentId == ParentId)
                    {
                        /*
                         * node = treeListDevice.AppendNode(new[] { item.Value.Name, item.Key + ";G" }, aNode.Id, 1, 3, 1, CheckState.Checked);
                        node.Tag = item.Key.ToString() + ";G";
                         */
                        //node = new TreeNode(item.Value.Name);
                        node=tvSynGroup.AppendNode(new[] { item.Value.Name, item.Key + ";G" }, aNode.Id, 1, 3, 1, CheckState.Checked);
                        node.Tag = item.Key.ToString() + ";G";
                        foreach (KeyValuePair<int, DeviceInfo> device in item.Value.ListDevice)
                        {
                            devicenode = tvSynGroup.AppendNode(new[] { device.Value.Name, device.Key + ";D" }, node.Id, 1, 3, 1, CheckState.Checked);
                            devicenode.Tag = device.Key.ToString() + ";D";
                            devicenode.ImageIndex = 1;
                            //加载摄像头
                            TreeListNode tnCameraList = tvSynGroup.AppendNode(new[] { "摄像头列表", "-1" + ";L" }, devicenode.Id, 1, 3, 1, CheckState.Checked);
                            tnCameraList.ImageIndex = 7;
                            tnCameraList.Tag = "-1" + ";L";
                            foreach (KeyValuePair<int, CameraInfo> cam in device.Value.ListCamera)
                            {
                                camnode = tvSynGroup.AppendNode(new[] { cam.Value.Name, cam.Key + ";C" }, tnCameraList.Id, 1, 3, 1, CheckState.Checked);
                                camnode.Tag = cam.Key.ToString() + ";C";
                                camnode.ImageIndex = 2;
                                //tnCameraList.Nodes.Add(camnode);
                            }
                            //devicenode.Nodes.Add(tnCameraList);
                            //加载报警器
                            TreeListNode tnAlarmList = tvSynGroup.AppendNode(new[] { "报警器列表", "-1" + ";N" }, devicenode.Id, 1, 3, 1, CheckState.Checked);
                            tnAlarmList.ImageIndex = 10;
                            tnAlarmList.Tag = "-1" + ";N";
                            foreach (KeyValuePair<int, AlarmInfo> alarm in device.Value.ListAlarm)
                            {
                                camnode = tvSynGroup.AppendNode(new[] { alarm.Value.Name, alarm.Key + ";A" }, tnAlarmList.Id, 1, 3, 1, CheckState.Checked);
                                camnode.Tag = alarm.Key.ToString() + ";A";
                                camnode.ImageIndex = 10;
                                //tnAlarmList.Nodes.Add(camnode);
                            }
                            //devicenode.Nodes.Add(tnAlarmList);
                            //node.Nodes.Add(devicenode);

                        }
                        AppendNode(node, item.Key);
                        if (aNode == null)
                        {
                            return;
                        }

                    }

                }

            }
            catch (Exception ex)
            {
            }

        }

        private void xtraTabControl2_SelectedPageChanging(object sender, DevExpress.XtraTab.TabPageChangingEventArgs e)
        {
            switch (xtraTabControl2.SelectedTabPageIndex)
            {
                case 0:
                    ListGroup = GroupBusiness.Instance.GetAllGroupInfos(ref errMessage);
                    break;
                case 1:
                    ListSynGroup = SynGroupBusiness.Instance.GetAllSynGroups(ref errMessage);
                    break;
                case 2:
                    ListGroupSwitch = GroupSwitchGroupBusiness.Instance.GetAllGroupSwitchGroups(ref errMessage);
                    break;
                case 3:
                    ListProgSwitch = ProgSwitchBusiness.Instance.GetAllProgSwitchs(ref errMessage);
                    break;
                default:
                    break;
            }
        }

        private void tvSynGroup_DoubleClick(object sender, EventArgs e)
        {

        }

        private void trCamera_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            
            if (ClickDevCam != null)
            {
                ClickDevCam(e.Node.Tag.ToString());
            }
        }

        private void trCamera_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (DoubleDevCam != null)
            {
                DoubleDevCam(e.Node.Tag.ToString());
            }
        }

        private void tvSynGroup_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {

        }

        private void tvSynGroup_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (DoubleSynGroup != null)
            {
                DoubleSynGroup(e.Node.Tag.ToString());
            }
        }

        private void BuildGroupSwitchGroupTree()
        {
            //_listSynGroup = SynGroupBusiness.Instance.GetAllSynGroup(ref errMessage);
            if (_listGroupSwitch==null)
            {
                return;
            }
            Cursor currentCursor = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;
            TreeNode node;
            //tvGroupSwitch.Nodes.Clear();

            foreach (KeyValuePair<int, GroupSwitchGroup> item in _listGroupSwitch)
            {
                node = new TreeNode(item.Value.Name);
                //G:群组切换组
                node.Tag = item.Key + ";G";
                node.ImageIndex = 3;
                if (_lastSelectedTreeListNode != null)
                {
                    if (_lastSelectedTreeNode.Tag.ToString() == node.Tag.ToString())
                    {
                        node.BackColor = Color.Gray;
                        
                        selectedTreeNode = node;
                    }
                }
                AppendGroupSwitchGroupNode(node);
                //tvGroupSwitch.Nodes.Add(node);

            }

            //tvGroupSwitch.ExpandAll();
            if (selectedTreeNode != null)
            {
                //tvGroupSwitch.SelectedNode = selectedTreeNode;
            }
            Cursor.Current = currentCursor;
        }

        private void AppendGroupSwitchGroupNode(TreeNode aNode)
        {
            string[] str = aNode.Tag.ToString().Split(';');
            int key = int.Parse(str[0]);
            GroupSwitchGroup groupSwitchGroup = _listGroupSwitch[key];
            if (groupSwitchGroup.ListGroupSwitchDetailInfo == null)
            {
                return;
            }
            foreach (KeyValuePair<int, GroupSwitchDetailInfo> gswi in groupSwitchGroup.ListGroupSwitchDetailInfo)
            {
                var node = new TreeNode(gswi.Value.SynGroupName);
                node.Tag = gswi.Key + ";D;" + gswi.Value.SynGroupId + ";S";
                node.ImageIndex = 5;
                if (_lastSelectedTreeNode != null)
                {
                    if (_lastSelectedTreeNode.Tag.ToString() == node.Tag.ToString())
                    {
                        node.BackColor = Color.Gray;
                        selectedTreeNode = node;
                        
                    }
                }
                aNode.Nodes.Add(node);

            }
        }
        private void BuildProgSwitchTree()
        {
            //_listSynGroup = SynGroupBusiness.Instance.GetAllSynGroup(ref errMessage);
            if (_listSynGroup == null) return;
            Cursor currentCursor = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;
            TreeNode node;
            //tvProgSwitch.Nodes.Clear();

            foreach (KeyValuePair<int, ProgSwitchInfo> item in _listProgSwitch)
            {
                node = new TreeNode(item.Value.Name);
                //P:程序切换
                node.Tag = item.Key + ";P";
                node.ImageIndex = 4;
                if (_lastSelectedTreeNode != null)
                {
                    if (_lastSelectedTreeNode.Tag.ToString() == node.Tag.ToString())
                    {
                        node.BackColor = Color.Gray;
                        
                        selectedTreeNode = node;
                    }
                }
                AppendProgSwitchDetailNode(node);
                //tvProgSwitch.Nodes.Add(node);

            }

            //tvProgSwitch.ExpandAll();
            if (selectedTreeNode != null)
            {
                //tvProgSwitch.SelectedNode = selectedTreeNode;
            }
            Cursor.Current = currentCursor;
        }

        private void AppendProgSwitchDetailNode(TreeNode aNode)
        {
            string[] str = aNode.Tag.ToString().Split(';');
            int key = int.Parse(str[0]);
            ProgSwitchInfo progSwitchInfo = _listProgSwitch[key];
            if (progSwitchInfo.ListProgSwitchDetailInfo == null)
            {
                return;
            }
            foreach (KeyValuePair<int, ProgSwitchDetailInfo> gswi in progSwitchInfo.ListProgSwitchDetailInfo)
            {
                var node = new TreeNode(gswi.Value.DeviceName + "_" + gswi.Value.CameraName);
                //S:ProgSwitchDetailInfo 的ID
                //D:DeviceId
                //C:CameraId
                //T:TickTime
                node.Tag = gswi.Key + ";S;" + gswi.Value.DeviceId + ";D;" + gswi.Value.CameraId + ";C;" + gswi.Value.TickTime + ";T";
                if (_lastSelectedTreeNode != null)
                {
                    if (_lastSelectedTreeNode.Tag.ToString() == node.Tag.ToString())
                    {
                        node.BackColor = Color.Gray;
                        node.ImageIndex = 2;
                        selectedTreeNode = node;
                        
                    }
                }
                aNode.Nodes.Add(node);

            }
        }

        private void xtraTabControl2_TabIndexChanged(object sender, EventArgs e)
        {

        }
        private void tvGroupSwitch_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (DoubleSynSwitch != null)
            {
                DoubleSynSwitch(e.Node.Tag.ToString());
            }
        }


        private void tlCamera_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            TreeListNode node = tlCamera.FocusedNode;
            if ((node.Tag==null)||e.Button==MouseButtons.Right)
            {
                return;
            }
            string strTag = node.Tag.ToString();

            if (strTag.IndexOf("T") >= 0)
            {
                //正常显示

            }
            else if (strTag.IndexOf("D") >= 0)
            {
                //显示该设备下的所有摄像头
                if (DoubleDevCam != null)
                {
                    DoubleDevCam(strTag);
                }
            }
            else if (strTag.IndexOf("C") >= 0)
            {
                //关联摄像头与CameraViewer
            }
        }

    }
}



