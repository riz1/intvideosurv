using System.Collections.Generic;
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


    public partial class CameraView : XtraUserControl
    {
        public CameraView()
        {
            InitializeComponent();
        }
        Dictionary<int, GroupInfo> _listGroup;
        Dictionary<int, DecoderInfo> _listDecoder;
        Dictionary<int, LongChang_CameraInfo> _listLongChangCamera;

        public delegate void TouchCamera(string tag);
        public event TouchCamera DoubleDevCam;
        public event TouchCamera ClickDevCam;
        public event TouchCamera DoubleDecoderCam;
        
        private string _errMessage = "";

        public EnumViewType ViewType = EnumViewType.Normal;

        public Dictionary<int, GroupInfo> ListGroup
        {
            set
            {
                _listGroup = value;
                BuildCameraTree();
            }

        }
        public Dictionary<int, MapInfo> ListMap
        {
            set
            {
                BuildCameraTree();
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
        public Dictionary<int, LongChang_CameraInfo> ListLongChangCamera
        {
            set
            {
                _listLongChangCamera = value;
                BuildLongChangCameraTree();
            }

        }

        private void BuildDecoderTree()
        {

            Cursor currentCursor = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;
            TreeListNode node;
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
                        DeviceInfo di = DecoderBusiness.Instance.GetDeviceInfoByCameraId(ref _errMessage, cam.Value.CameraId);
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

        private void BuildCameraTree()
        {
            Cursor currentCursor = Cursor.Current;
            TreeNode node;
            try
            {
                switch (ViewType)
                {
                    case EnumViewType.Normal:
                        tlCamera.Nodes.Clear();
                        foreach (KeyValuePair<int, GroupInfo> item in _listGroup)
                        {
                            TreeListNode treeListNodeGroup = tlCamera.AppendNode(new[] { item.Value.Name, item.Key + ";G" }, -1, 0, 3, 1, CheckState.Checked);
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
                        Cursor.Current = currentCursor;
                        break;

                    case EnumViewType.SynSwitch:

                        if (_listDecoder == null)
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
                        foreach (KeyValuePair<int, DecoderInfo> item in _listDecoder)
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
            catch (System.Exception e)
            {
            	
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

        private void xtraTabControl2_SelectedPageChanging(object sender, DevExpress.XtraTab.TabPageChangingEventArgs e)
        {
            switch (xtraTabControl2.SelectedTabPageIndex)
            {
                case 0:
                    ListGroup = GroupBusiness.Instance.GetAllGroupInfos(ref _errMessage);
                    break;
                case 1:
                    ListDecoder = DecoderBusiness.Instance.GetAllDecoderInfo(ref _errMessage);
                    break;
                default:
                    break;
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
            if (strTag.IndexOf("C") >= 0)
            {
                //显示该设备下的所有摄像头
                if (DoubleDevCam != null)
                {
                    DoubleDevCam(strTag);
                }
            }

        }
        private void BuildLongChangCameraTree()
        {
            Cursor currentCursor = Cursor.Current;
            TreeNode node;
            try
            {
                    tlCamera.Nodes.Clear();
                    foreach (KeyValuePair<int, LongChang_CameraInfo> item in _listLongChangCamera)
                    {
                        TreeListNode treeListNodeCamera = tlCamera.AppendNode(new[] { item.Value.Name, item.Key + ";C" }, -1, 2, 3, 1, CheckState.Checked);
                        treeListNodeCamera.Tag = item.Key + ";C";
                    }
                    tlCamera.ExpandAll();
                    Cursor.Current = currentCursor;
                
            }
            catch (System.Exception e)
            {

            }
        }

    }
}



