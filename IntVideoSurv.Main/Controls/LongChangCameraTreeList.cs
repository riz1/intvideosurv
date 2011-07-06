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

namespace CameraViewer.Controls
{
    public partial class LongChangCameraTreeList : DevExpress.XtraEditors.XtraUserControl
    {
        public LongChangCameraTreeList()
        {
            InitializeComponent();
            
        }
        Dictionary<int, LongChang_CameraInfo> _listLongChangCamera;
        private string _errMessage = "";

        public EnumViewType ViewType = EnumViewType.Normal;


        public Dictionary<int, LongChang_CameraInfo> ListLongChangCamera
        {
            set
            {
                _listLongChangCamera = value;
                BuildLongChangCameraTree();
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
