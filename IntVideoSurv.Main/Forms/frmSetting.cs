using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using DevExpress.Skins;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using IntVideoSurv.Entity;
using IntVideoSurv.Business;

namespace CameraViewer.Forms
{
    public partial class frmSetting
    {
        private string errMessage = "";
        Dictionary<int, GroupInfo> listGroup;
        private int CurrentParentId = 0;

        Dictionary<int, SynGroup> _listSynGroup;
        Dictionary<int, DisplayChannelInfo> _listDisplayChannel;
        Dictionary<int, MapInfo> _listMapInfo;
        Dictionary<int, DecoderInfo> listDecoder;

        private DisplayTypes _displaytype = DisplayTypes.DeviceManagement;

        public frmSetting()
        {
            InitializeComponent();
            BuildDeviceTree();
            BuildCameraTreeInSynGroupManagement();
            BuildCameraTreeInLogManagement();
            //显示DecoderTree
            BuildDecoderTree();
            LoadUsers();
            BuildDisplayChannelTreeInSynGroupManagement();
            BuildDisplayChannelTreeInDisplayChannelManagement();
            dateEditEndDate.DateTime = DateTime.Now;
            DisplayRightPanel();
            showDecoderInfo();

        }
        private void BuildDeviceTree()
        {
            listGroup = GroupBusiness.Instance.GetAllGroupInfos(ref errMessage);
            Cursor currentCursor = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;
            TreeNode node;
            treeViewDevice.Nodes.Clear();
            foreach (KeyValuePair<int, GroupInfo> item in listGroup)
            {
                if (item.Value.ParentId == 0)
                {
                    node = new TreeNode(item.Value.Name);
                    node.Tag = item.Key.ToString() + ";T";
                    AppendNode(node, item.Key);
                    treeViewDevice.Nodes.Add(node);

                }

            }
            treeViewDevice.ExpandAll();
            contextMenuStripGroupAndDevice.Visible = false;
            Cursor.Current = currentCursor;
        }
        /// <summary>
        /// 显示解码器的树形
        /// </summary>
        private void BuildDecoderTree()
        {
            listDecoder = DecoderBusiness.Instance.GetAllDecoderInfo(ref errMessage);
            Cursor currentCursor = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;
            TreeListNode node;
            TreeListNode camnode;

            treeListShowDecoder.Nodes.Clear();
            TreeListNode treeListNodeRoot = treeListShowDecoder.AppendNode(new[] { "解码器管理", 0 + ";T" }, -1, 0, 3, 1, CheckState.Checked);
            treeListNodeRoot.Tag = 0 + ";T";
            if (listDecoder != null)
            {

                foreach (KeyValuePair<int, DecoderInfo> item in listDecoder)
                {
                    TreeListNode treeListNodeDecoder = treeListShowDecoder.AppendNode(new[] { item.Value.Name, item.Key + ";D" }, treeListNodeRoot.Id, 1, 3, 1, CheckState.Checked);
                    treeListNodeDecoder.Tag = item.Key + ";D";
                    foreach (KeyValuePair<int, CameraInfo> cam in item.Value.ListCameras)
                    {
                        DeviceInfo di = DecoderBusiness.Instance.GetDeviceInfoByCameraId(ref errMessage, cam.Value.CameraId);
                        camnode = treeListShowDecoder.AppendNode(new[] { di.Name+":"+cam.Value.Name, item.Key + ";C" }, treeListNodeDecoder.Id, 1, 3, 1, CheckState.Checked);
                        camnode.Tag = cam.Key.ToString() + ";C";
                    }
                }
            }
            treeListShowDecoder.Columns[1].Visible = false;
            treeListShowDecoder.ExpandAll();
            Cursor.Current = currentCursor;

         
        }

        private void AppendNode(TreeNode aNode, int ParentId)
        {
            try
            {
                TreeNode node;
                TreeNode devicenode;
                TreeNode camnode;
                foreach (KeyValuePair<int, GroupInfo> item in listGroup)
                {
                    if (item.Value.ParentId == ParentId)
                    {
                        node = new TreeNode(item.Value.Name);
                        node.Tag = item.Key.ToString() + ";G";
                        foreach (KeyValuePair<int, DeviceInfo> device in item.Value.ListDevice)
                        {
                            devicenode = new TreeNode(device.Value.Name);
                            devicenode.Tag = device.Key.ToString() + ";D";


                            foreach (KeyValuePair<int, CameraInfo> cam in device.Value.ListCamera)
                            {
                                camnode = new TreeNode(cam.Value.Name);
                                camnode.Tag = cam.Key.ToString() + ";C";
                                devicenode.Nodes.Add(camnode);
                            }
                            node.Nodes.Add(devicenode);

                        }
                        AppendNode(node, item.Key);
                        if (aNode != null)
                        {
                            aNode.Nodes.Add(node);
                        }

                    }

                }

            }
            catch (Exception ex)
            {
            }

        }

        private void Setmenu(string tag)
        {
            if (tag.IndexOf("C") > 0)
            {
                AddGroupToolStripMenuItem.Visible = false;
                EditGroupToolStripMenuItem.Visible = false;
                DeleteGroupToolStripMenuItem.Visible = false;
                AddDeviceToolStripMenuItem.Visible = false;
                EditDeviceToolStripMenuItem.Visible = false;
                DeleteDeviceToolStripMenuItem.Visible = false;
            }
            else if (tag.IndexOf("D") > 0)
            {

                AddGroupToolStripMenuItem.Visible = false;
                EditGroupToolStripMenuItem.Visible = false;
                DeleteGroupToolStripMenuItem.Visible = false;
                AddDeviceToolStripMenuItem.Visible = false;
                EditDeviceToolStripMenuItem.Visible = true;
                DeleteDeviceToolStripMenuItem.Visible = true;
            }
            else if (tag.IndexOf("T") > 0)
            {
                AddDeviceToolStripMenuItem.Visible = false;
                EditDeviceToolStripMenuItem.Visible = false;
                DeleteDeviceToolStripMenuItem.Visible = false;
                AddGroupToolStripMenuItem.Visible = true;
                EditGroupToolStripMenuItem.Visible = false;
                DeleteGroupToolStripMenuItem.Visible = false;
            }
            else if (tag.IndexOf("G") > 0)
            {
                AddGroupToolStripMenuItem.Visible = false;
                EditGroupToolStripMenuItem.Visible = true;
                DeleteGroupToolStripMenuItem.Visible = true;
                AddDeviceToolStripMenuItem.Visible = true;
                EditDeviceToolStripMenuItem.Visible = false;
                DeleteDeviceToolStripMenuItem.Visible = false;
            }
        }


        private void treeList2_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {

        }

        private void AddGroupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CurrentParentId == 0)
            {
                //frmModifyDeviceInfo
                return;
            }
            frmGroup group = new frmGroup();
            group.Opt = Util.Operateion.Add;
            group.ParentGroupId = CurrentParentId;
            group.ShowDialog(this);
            treeViewDevice.Nodes.Clear();
            BuildDeviceTree();


        }

        private void treeList1_TreeListMenuItemClick(object sender, DevExpress.XtraTreeList.TreeListMenuItemClickEventArgs e)
        {

        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            string tag = e.Node.Tag.ToString();
            Setmenu(tag);

            string[] str = tag.Split(';');
            CurrentParentId = int.Parse(str[0]);

            alDevices.Clear();
            getDevicess(e.Node);
            ShowDataInGridView(dgvDevice, DeviceBusiness.Instance.GetDisplayDeviceByDeviceList(ref errMessage, makeDeviceList()));

        }

        private void AddDeviceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CurrentParentId == 0)
            {
                return;
            }

            frmWizard group = new frmWizard();

            group.GroupId = CurrentParentId;
            group.ShowDialog(this);
            treeViewDevice.Nodes.Clear();
            BuildDeviceTree();

        }

        private void EditDeviceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CurrentParentId == 0)
            {
                return;
            }
            frmModifyDeviceInfo modDevice = new frmModifyDeviceInfo();
            modDevice.DeviceId = CurrentParentId;
            modDevice.ShowDialog(this);
            BuildDeviceTree();

        }

        private string getDeviceName(int deviceId)
        {
            return DeviceBusiness.Instance.GetDeviceInfoByDeviceId(ref errMessage, deviceId).Name;
        }
        private void MarkTreeNode(TreeNode tn, TreeNode root)
        {

            if (tn == null) return;
            if (root.Tag == tn.Tag)
            {
                tn.BackColor = Color.Gray;
                return;
            }
            foreach (TreeNode t in tn.Nodes)
            {
                MarkTreeNode(tn, root);
            }
        }


        private void nbDevice_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            _displaytype = DisplayTypes.DeviceManagement;
            DisplayRightPanel();
        }
        private void DisplayRightPanel()
        {
            //全隐藏
            gcDeviceManagement.Visible = false;
            gcUserManagement.Visible = false;
            gcLogManagement.Visible = false;
            gcSynGroupManagement.Visible = false;
            gcGroupSwitchManagement.Visible = false;
            gcProgSwitchManagement.Visible = false;
            gcDisplayChannelManagement.Visible = false;
            gcMap.Visible = false;
            gcSkin.Visible = false;
            //解码器
            DecoderManagement.Visible = false;            
            switch (_displaytype)
            {
                case DisplayTypes.DeviceManagement:
                    gcDeviceManagement.Visible = true;
                    gcDeviceManagement.Dock = DockStyle.Fill;
                    break;

                case DisplayTypes.UserManagement:
                    gcUserManagement.Visible = true;
                    gcUserManagement.Dock = DockStyle.Fill;

                    break;
                case DisplayTypes.LogManagement:
                    gcLogManagement.Visible = true;
                    gcLogManagement.Dock = DockStyle.Fill;
                    break;
                case DisplayTypes.SynGroupManagement:
                    gcSynGroupManagement.Visible = true;
                    gcSynGroupManagement.Dock = DockStyle.Fill;
                    break;
                case DisplayTypes.GroupSwitchManagement:
                    gcGroupSwitchManagement.Visible = true;
                    gcGroupSwitchManagement.Dock = DockStyle.Fill;
                    break;

                case DisplayTypes.ProSwitchManagement:
                    gcProgSwitchManagement.Visible = true;
                    gcProgSwitchManagement.Dock = DockStyle.Fill;
                    break;

                case DisplayTypes.DisplayChannelManagement:
                    gcDisplayChannelManagement.Visible = true;
                    gcDisplayChannelManagement.Dock = DockStyle.Fill;
                    break;

                case DisplayTypes.MapManagement:
                    gcMap.Visible = true;
                    gcMap.Dock = DockStyle.Fill;
                    break;
                case DisplayTypes.SkinManagement:
                    gcSkin.Visible = true;
                    gcSkin.Dock = DockStyle.Fill;
                    break;
                    //解码器
                case DisplayTypes.DecoderManagement:
                    DecoderManagement.Visible = true;
                    DecoderManagement.Dock = DockStyle.Fill;
                    gridView1.OptionsView.ShowGroupPanel = false;
                    break;
            }

        }

        #region 用户管理

        private void nbUser_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            _displaytype = DisplayTypes.UserManagement;
            DisplayRightPanel();
        }

        private void LoadUsers()
        {
            //dataGridViewUser.DataSource = UserBusiness.Instance.GetUserDataSet(ref errMessage);
            //dataGridViewUser.Columns[dataGridViewUser.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            //设置日期时间栏的宽度和数据格式

            //dataGridViewUser.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //dataGridViewUser.Columns[3].Width = 160;
            //dataGridViewUser.Columns[3].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss ";
            ShowUserDataInGridControl();
        }

        private void ShowUserDataInGridControl()
        {
            Dictionary<int, UserInfo> listuser = UserBusiness.Instance.GetAllUserInfo(ref errMessage);
            var dataTable1 = new System.Data.DataTable("UserInfo");
            dataTable1.Columns.Add("编号", typeof(int));
            dataTable1.Columns.Add("索引号", typeof(int));
            dataTable1.Columns.Add("用户名", typeof(string));
            dataTable1.Columns.Add("用户类型", typeof(int));
            dataTable1.Columns.Add("创建时间", typeof(DateTime));

            int i = 1;
            foreach (var node in listuser)
                dataTable1.Rows.Add(i++, node.Value.UserId, node.Value.UserName, node.Value.UserTypeId, node.Value.CreateDateTime);
            gridControlUserData.DataSource = dataTable1;
            gridControl1.MainView.PopulateColumns();
            try
            {
                //编号的宽度为40
                gridView3.Columns["编号"].Width = 10;
                gridView3.Columns["用户名"].Width = 40;
                gridView3.Columns["用户类型"].Width = 10;
                //gridView3.Columns[].Width = 40;
                //编号右对齐
                // gridView3.Columns["编号"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                //索引号不显示
                gridView3.Columns["索引号"].Visible = false;
                //gridView3.Columns[gridView3.Columns.Count - 1] = DataGridViewAutoSizeColumnMode.Fill;

            }
            catch (Exception ex)
            {
                ;
            }

        }

        private void ShowDataInGridView(DataGridView dataGridView, DataTable dataTable)
        {
            if (dataTable == null)
            {
                return;
            }

            dataGridView.Columns.Clear();
            dataGridView.Rows.Clear();
            dataGridView.Columns.Add("编号", "编号");
            foreach (DataColumn dc in dataTable.Columns)
            {
                dataGridView.Columns.Add(dc.ColumnName, dc.ColumnName);
            }
            foreach (DataRow dr in dataTable.Rows)
            {
                int index = dataGridView.Rows.Add();
                DataGridViewRow dgvr = dataGridView.Rows[index];
                dgvr.Cells["编号"].Value = index + 1;
                foreach (DataColumn dc in dataTable.Columns)
                {
                    dgvr.Cells[dc.ColumnName].Value = dr[dc.ColumnName];
                }

            }
            //设置格式
            try
            {
                //编号的宽度为40
                dataGridView.Columns["编号"].Width = 40;
                //编号右对齐
                dataGridView.Columns["编号"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                //索引号不显示
                dataGridView.Columns["索引号"].Visible = false;
                dataGridView.Columns[dataGridView.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            }
            catch (Exception ex)
            {
                ;
            }


        }

        private void BuildDisplayChannelTreeInSynGroupManagement()
        {
            _listDisplayChannel = DisplayChannelBusiness.Instance.GetAllDisplayChannelInfo(ref errMessage);
            Cursor currentCursor = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;
            TreeNode node;
            treeViewMonitor.Nodes.Clear();
            int CurrentCardNo = -1;
            foreach (KeyValuePair<int, DisplayChannelInfo> item in _listDisplayChannel)
            {
                if (CurrentCardNo != item.Value.DecodeCardNo)
                {
                    string NodeText = "Card_" + (item.Value.DecodeCardNo + 1);
                    node = new TreeNode(NodeText);
                    node.Tag = item.Value.DecodeCardNo.ToString() + ";T";
                    treeViewMonitor.Nodes.Add(node);
                    CurrentCardNo = item.Value.DecodeCardNo;
                }

            }

            foreach (KeyValuePair<int, DisplayChannelInfo> item in _listDisplayChannel)
            {
                foreach (TreeNode cardNode in treeViewMonitor.Nodes)
                {
                    if ((cardNode.Tag.ToString().IndexOf("T") >= 0) &&
                        (int.Parse(cardNode.Tag.ToString().Split(';')[0]) == item.Value.DecodeCardNo))
                    {
                        node = new TreeNode(item.Value.DisplayChannelName);
                        node.Tag = item.Key.ToString() + ";C";
                        cardNode.Nodes.Add(node);
                        break;
                    }
                }

            }
            treeViewMonitor.ExpandAll();
            Cursor.Current = currentCursor;
        }

        private void BuildDisplayChannelTreeInDisplayChannelManagement()
        {
            _listDisplayChannel = DisplayChannelBusiness.Instance.GetAllDisplayChannelInfo(ref errMessage);
            Cursor currentCursor = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;
            TreeNode node;
            tvDisplayChannel.Nodes.Clear();
            int CurrentCardNo = -1;
            foreach (KeyValuePair<int, DisplayChannelInfo> item in _listDisplayChannel)
            {
                if (CurrentCardNo != item.Value.DecodeCardNo)
                {
                    string NodeText = "Card_" + (item.Value.DecodeCardNo + 1);
                    node = new TreeNode(NodeText);
                    node.Tag = item.Value.DecodeCardNo.ToString() + ";T";
                    tvDisplayChannel.Nodes.Add(node);
                    CurrentCardNo = item.Value.DecodeCardNo;
                }

            }

            foreach (KeyValuePair<int, DisplayChannelInfo> item in _listDisplayChannel)
            {
                foreach (TreeNode cardNode in tvDisplayChannel.Nodes)
                {
                    if ((cardNode.Tag.ToString().IndexOf("T") >= 0) &&
                        (int.Parse(cardNode.Tag.ToString().Split(';')[0]) == item.Value.DecodeCardNo))
                    {
                        node = new TreeNode(item.Value.DisplayChannelName);
                        node.Tag = item.Key.ToString() + ";C";
                        cardNode.Nodes.Add(node);
                        break;
                    }
                }

            }
            tvDisplayChannel.ExpandAll();
            Cursor.Current = currentCursor;
        }


        private void splitContainerControl6_Resize(object sender, EventArgs e)
        {
            splitContainerControl6.SplitterPosition = splitContainerControl6.Height - buttonUserAdd.Height - 20;
        }

        private void buttonUserAdd_Click(object sender, EventArgs e)
        {
            FrmUser frmUser = new FrmUser();
            frmUser.ShowDialog();
            LoadUsers();
        }

        private void buttonUserDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (XtraMessageBox.Show("确实要删除用户?", "提醒", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
                {
                    int userid = Convert.ToInt32(gridView3.GetFocusedRowCellValue("索引号").ToString());//SelectedRows[0].Cells["索引号"].Value);
                    UserInfo ui = UserBusiness.Instance.GetUserInfo(ref errMessage, userid);
                    String cnt = ui.ToString();
                    UserBusiness.Instance.Delete(ref errMessage, userid);
                    OperateLogBusiness.Instance.Insert(ref errMessage,
                                                       new OperateLog
                                                           {
                                                               ClientUserId = MainForm.CurrentUser.UserId,
                                                               ClientUserName = MainForm.CurrentUser.UserName,
                                                               Content = ui.ToString(),
                                                               HappenTime = DateTime.Now,
                                                               OperateTypeId = (int)(OperateLogTypeId.UserDelete),
                                                               OperateTypeName = OperateLogTypeName.UserDelete,
                                                               OperateUserName = MainForm.CurrentUser.UserName
                                                           });
                    LoadUsers();
                }

            }
            catch (Exception ex)
            {
                return;
            }

        }

        private void buttonUserUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                var userInfo = UserBusiness.Instance.GetUserInfo(ref errMessage, Convert.ToInt32(gridView3.GetFocusedRowCellValue("索引号").ToString()));
                var frmUser = new FrmUser(userInfo);
                frmUser.ShowDialog();
                LoadUsers();
            }
            catch (Exception ex)
            {
                return;
            }
        }
        #endregion

        private bool _isTreeNodeClickedInSynGroupCamera = false;
        private TreeNode _lastSelectedTreeNodeInSynGroupCamera;

        private void treeViewSynGroupCamera_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (!_isTreeNodeClickedInSynGroupCamera)
            {
                _treeNodeDefaultColor = treeViewSynGroupCamera.SelectedNode.BackColor;
                _isTreeNodeClickedInSynGroupCamera = true;
            }
            if (_lastSelectedTreeNodeInSynGroupCamera != null)
            {
                _lastSelectedTreeNodeInSynGroupCamera.BackColor = _treeNodeDefaultColor;
            }

            _lastSelectedTreeNodeInSynGroupCamera = treeViewSynGroupCamera.SelectedNode;

        }

        private void treeViewSynGroupCamera_Leave(object sender, EventArgs e)
        {
            if (_isTreeNodeClickedInSynGroupCamera)
            {
                _lastSelectedTreeNodeInSynGroupCamera.BackColor = Color.Gray;
            }
        }


        private bool _isTreeNodeClickedInMonitor = false;
        private TreeNode _lastSelectedTreeNodeInMonitor;

        private void treeViewMonitor_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (!_isTreeNodeClickedInMonitor)
            {
                _treeNodeDefaultColor = treeViewMonitor.SelectedNode.BackColor;
                _isTreeNodeClickedInMonitor = true;
            }
            if (_lastSelectedTreeNodeInMonitor != null)
            {
                _lastSelectedTreeNodeInMonitor.BackColor = _treeNodeDefaultColor;
            }

            _lastSelectedTreeNodeInMonitor = treeViewMonitor.SelectedNode;
            
            //添加对应该显示通道的分屏号
            cbDisplayScreenNo.Items.Clear();
            string tagStr = treeViewMonitor.SelectedNode.Tag.ToString();
            if (tagStr.IndexOf('C')>=0)
            {
                int displayChannelId = int.Parse(tagStr.Split(';')[0]);
                for (int i = 0; i < _listDisplayChannel[displayChannelId].SplitScreenNo;i++)
                {
                    cbDisplayScreenNo.Items.Add(i+1);
                }
            }



        }

        private void treeViewMonitor_Leave(object sender, EventArgs e)
        {
            if (_isTreeNodeClickedInMonitor)
            {
                _lastSelectedTreeNodeInMonitor.BackColor = Color.Gray;
            }
        }


        private bool _isTreeNodeClickedInDisplayChannel = false;
        private TreeNode _lastSelectedTreeNodeInDisplayChannel;

        private void tvDisplayChannel_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (!_isTreeNodeClickedInDisplayChannel)
            {
                _treeNodeDefaultColor = tvDisplayChannel.SelectedNode.BackColor;
                _isTreeNodeClickedInDisplayChannel = true;
            }
            if (_lastSelectedTreeNodeInDisplayChannel != null)
            {
                _lastSelectedTreeNodeInDisplayChannel.BackColor = _treeNodeDefaultColor;
            }

            _lastSelectedTreeNodeInDisplayChannel = tvDisplayChannel.SelectedNode;
            ShowDisplayChannel();

        }
        private void ShowDisplayChannel()
        {
            dgvDisplayChannel.Rows.Clear();
            if (_lastSelectedTreeNodeInDisplayChannel == null)
            {
                return;
            }
            string str = _lastSelectedTreeNodeInDisplayChannel.Tag.ToString();
            if (str.IndexOf("T") >=0)
            {
                string[] strs = str.Split(';');
                int psID = int.Parse(strs[0]);

                foreach (KeyValuePair<int, DisplayChannelInfo> keyValuePair in _listDisplayChannel)
                {
                    if (psID == keyValuePair.Value.DecodeCardNo)
                    {
                        int index = dgvDisplayChannel.Rows.Add();
                        DataGridViewRow dgvr = dgvDisplayChannel.Rows[index];
                        DataGridViewComboBoxCell dgc = (DataGridViewComboBoxCell)dgvr.Cells["DisplayChannelSplitScreenNo"];
                        dgc.Value = keyValuePair.Value.SplitScreenNo.ToString();
                        dgvr.Cells["DisplayChannelName"].Value = keyValuePair.Value.DisplayChannelName;
                        dgvr.Cells["DisplayChannelId"].Value = keyValuePair.Value.DisplayChannelId;                        
                    }


                }
            }
            else if (str.IndexOf("C") >= 0)
            {
                string[] strs = str.Split(';');
                int psID = int.Parse(strs[0]);
                DisplayChannelInfo dci = _listDisplayChannel[psID];
                int index = dgvDisplayChannel.Rows.Add();
                DataGridViewRow dgvr = dgvDisplayChannel.Rows[index];
                DataGridViewComboBoxCell dgc = (DataGridViewComboBoxCell)dgvr.Cells["DisplayChannelSplitScreenNo"];
                dgc.Value = dci.SplitScreenNo.ToString();
                dgvr.Cells["DisplayChannelName"].Value = dci.DisplayChannelName;
                dgvr.Cells["DisplayChannelId"].Value = dci.DisplayChannelId; 

            }
        }
        private void tvDisplayChannel_Leave(object sender, EventArgs e)
        {
            if (_isTreeNodeClickedInDisplayChannel)
            {
                _lastSelectedTreeNodeInDisplayChannel.BackColor = Color.Gray;
            }
        }

        ArrayList alDevices = new ArrayList();
        private void getDevicess(TreeNode selectTreeNode)
        {

            if (selectTreeNode == null) return;

            if (selectTreeNode.Tag.ToString().IndexOf("D") > 0)
            {
                string[] str = selectTreeNode.Tag.ToString().Split(';');
                alDevices.Add(int.Parse(str[0]));
            }


            foreach (TreeNode tn in selectTreeNode.Nodes)
            {
                getDevicess(tn);
            }
        }
        private string makeDeviceList()
        {
            string filter = " (";
            alDevices.Add(int.MinValue);
            foreach (int deviceid in alDevices)
            {
                filter += deviceid + ",";
            }
            filter = filter.Substring(0, filter.Length - 1);
            filter += ") ";
            return filter;
        }

        private void DeleteGroupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode tn = treeViewDevice.SelectedNode;
            if (tn == null)
            {
                return;
            }
            if ((tn.Tag.ToString().IndexOf("G") >= 0) && tn.FirstNode == null)
            {
                string[] strs = tn.Tag.ToString().Split(';');
                int groupid = int.Parse(strs[0]);
                GroupInfo gi = GroupBusiness.Instance.GetGroupInfoByGroupId(ref errMessage, groupid);
                GroupBusiness.Instance.Delete(ref errMessage, groupid);
                OperateLogBusiness.Instance.Insert(ref errMessage, new OperateLog
                   {
                       GroupId = gi.GroupID,
                       ClientUserId = MainForm.CurrentUser.UserId,
                       ClientUserName =
                           MainForm.CurrentUser.UserName,
                       Content = gi.ToString(),
                       HappenTime = DateTime.Now,
                       OperateTypeId =
                           (int) (OperateLogTypeId.GroupDelete),
                       OperateTypeName =
                           OperateLogTypeName.GroupDelete,
                       OperateUserName =
                           MainForm.CurrentUser.UserName
                   });
                BuildDeviceTree();
            }
        }

        private void EditGroupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CurrentParentId == 0)
            {
                //frmModifyDeviceInfo
                return;
            }
            frmGroup group = new frmGroup();
            group.Opt = Util.Operateion.Update;
            group.GroupId = int.Parse(treeViewDevice.SelectedNode.Tag.ToString().Split(';')[0]);
            group.ShowDialog(this);
            BuildDeviceTree();
        }

        private void DeleteDeviceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode tn = treeViewDevice.SelectedNode;
            if (tn == null)
            {
                return;
            }
            if ((tn.Tag.ToString().IndexOf("D") >= 0))
            {
                if (XtraMessageBox.Show("确定要删除该设备?","提示", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
                {
                    string[] strs = tn.Tag.ToString().Split(';');
                    int deviceid = int.Parse(strs[0]);
                    DeviceInfo di = DeviceBusiness.Instance.GetDeviceInfoByDeviceId(ref errMessage, deviceid);
                    DeviceBusiness.Instance.Delete(ref errMessage, deviceid);
                    OperateLogBusiness.Instance.Insert(ref errMessage, new OperateLog
                    {
                        DeviceId = di.DeviceId,
                        ClientUserId = MainForm.CurrentUser.UserId,
                        ClientUserName =
                            MainForm.CurrentUser.UserName,
                        Content = di.ToString(),
                        HappenTime = DateTime.Now,
                        OperateTypeId =
                            (int)(OperateLogTypeId.DeviceDelete),
                        OperateTypeName =
                            OperateLogTypeName.DeviceDelete,
                        OperateUserName =
                            MainForm.CurrentUser.UserName
                    });
                    BuildDeviceTree();                                       
                    
                }

            }
        }

        private void nbDisplayChannel_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            _displaytype = DisplayTypes.DisplayChannelManagement;
            DisplayRightPanel();

        }

        private void dgvGroupSwitchDetail_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow dgvr = dgvGroupSwitchDetail.Rows[e.RowIndex];
                GroupSwitchDetailBusiness.Instance.UpdateTickTimeById(ref errMessage, int.Parse(dgvr.Cells["Id"].Value.ToString()), int.Parse(dgvr.Cells["Tick"].Value.ToString()));
                LoadGroupSwitch();
            }
            catch (Exception)
            {

                XtraMessageBox.Show("时间间隔必须是正整数!");
            }

        }

        private void dgvProgSwitchDetail_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow dgvr = dgvProgSwitchDetail.Rows[e.RowIndex];
                ProgSwitchDetailBusiness.Instance.UpdateTickTimeById(ref errMessage, int.Parse(dgvr.Cells["ProgSwitchDetailId"].Value.ToString()), int.Parse(dgvr.Cells["ProgSwitchTick"].Value.ToString()));
                LoadProgSwitch();
            }
            catch (Exception)
            {

                XtraMessageBox.Show("时间间隔必须是正整数!");
            }
        }



        private void dgvDisplayChannel_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex<0)
            {
                return;
            }
            if (e.ColumnIndex == 2)//ComboBoxCell的列
            {
                DataGridViewComboBoxCell cc = (DataGridViewComboBoxCell)dgvDisplayChannel.CurrentCell;
                DataGridViewRow dgvr = dgvDisplayChannel.Rows[e.RowIndex];
                if ((cc.Value != null)&&(dgvr.Cells["DisplayChannelId"].Value!=null)&&(dgvr.Cells["DisplayChannelSplitScreenNo"]!=null)) 
                { 
                    
                    DisplayChannelBusiness.Instance.UpdateSplitScreenById(ref errMessage, int.Parse(dgvr.Cells["DisplayChannelId"].Value.ToString()), int.Parse(dgvr.Cells["DisplayChannelSplitScreenNo"].Value.ToString()));
                    BuildDisplayChannelTreeInDisplayChannelManagement();
                }
            }
        }

        private void nbMap_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            _displaytype = DisplayTypes.MapManagement;
            BuildMapTree();
            DisplayRightPanel();
        }
        
        private void BuildMapTree()
        {
            _listMapInfo = MapBusiness.Instance.GetAllMapInfo(ref errMessage);
            Cursor currentCursor = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;

            tvMap.Nodes.Clear();
            MapInfo LastMapInfo = null;
            TreeListNode treeListNodeRoot = tvMap.AppendNode(new[] { "地图管理", 0 + ";T" }, -1, 0, 3, 1, CheckState.Checked);
            treeListNodeRoot.Tag = 0 + ";t";
            if (_listMapInfo != null)
            {

                foreach (KeyValuePair<int, MapInfo> item in _listMapInfo)
                {
                    TreeListNode treeListNodeMap = tvMap.AppendNode(new[] { item.Value.Name, item.Key + ";D" }, treeListNodeRoot.Id, 1, 3, 1, CheckState.Checked);
                    treeListNodeMap.Tag = item.Key + ";d";
                    LastMapInfo = item.Value;
                }
            }
            tvMap.Columns[1].Visible = false;
            tvMap.ExpandAll();
            if (LastMapInfo!=null)
            {
                pictureBoxMap.Image = Image.FromFile(Path.Combine(Application.StartupPath, LastMapInfo.FileName));
                teMapName.Text = LastMapInfo.Name;                
            }
            Cursor.Current = currentCursor;
            //添加地图
            /*TreeNode node;
            MapInfo LastMapInfo = null;
            tvMap.Nodes.Clear();
            if (_listMapInfo != null)
            {
                node = new TreeNode("地图");
                node.Tag = -1 + ";a";
                foreach (KeyValuePair<int, MapInfo> item in _listMapInfo)
                {
                    TreeNode mapNode = new TreeNode(item.Value.Name);
                    mapNode.Tag = item.Key + ";m";
                    node.Nodes.Add(mapNode);
                    LastMapInfo = item.Value;
                }

                tvMap.Nodes.Add(node);
            }
            tvMap.ExpandAll();
            if (LastMapInfo!=null)
            {
                pictureBoxMap.Image = Image.FromFile(Path.Combine(Application.StartupPath, LastMapInfo.FileName));
                teMapName.Text = LastMapInfo.Name;                
            }*/

        }

        private Image CurrentImage;
        private string CurrentFileName;
        //浏览地图
        private void btnBrowserMap_Click(object sender, EventArgs e)
        {
            if (openMapFileDialog.ShowDialog()==DialogResult.OK)
            {
                CurrentFileName = openMapFileDialog.FileName;
                CurrentImage = Image.FromFile(CurrentFileName);
                pictureBoxMap.Image = CurrentImage;
            }
        }

        private MapInfo CurrentMapInfo;
        private void tvMap_DoubleClick(object sender, EventArgs e)
        {
            /*string str = tvMap.SelectedNode.Tag.ToString();
            if (str.IndexOf('m')>=0)
            {
                string[] strs = str.Split(';');
                CurrentMapInfo = _listMapInfo[int.Parse(strs[0])];
                pictureBoxMap.Image = Image.FromFile(Path.Combine(Application.StartupPath, CurrentMapInfo.FileName));
                teMapName.Text = CurrentMapInfo.Name;

            }*/
        }
        //添加地图信息
        private void btnAddMap_Click(object sender, EventArgs e)
        {
            MapInfo mapInfo = new MapInfo();
            mapInfo.Name = teMapName.Text;
            mapInfo.Width = CurrentImage.Width;
            mapInfo.Height = CurrentImage.Height;
            mapInfo.FileName ="img\\maps\\" + Path.GetFileName(CurrentFileName);
            File.Copy(CurrentFileName, Path.Combine(Application.StartupPath,mapInfo.FileName));
            MapBusiness.Instance.Insert(ref errMessage, mapInfo);
            BuildMapTree();
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
               /*string str = tvMap.SelectedNode.Tag.ToString();
                if (str.IndexOf('m') >= 0)
                {
                    string[] strs = str.Split(';');
                    MapBusiness.Instance.Delete(ref errMessage, int.Parse(strs[0]));
                    BuildMapTree();
                }*/
            }
            catch (Exception)
            {
                
                throw;
            }

        }

        private void navBarItem1_ItemChanged(object sender, EventArgs e)
        {

        }

        private void cbeChangeSkin_SelectedIndexChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.DefaultSkinName = cbeChangeSkin.EditValue.ToString();
            DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle(Properties.Settings.Default.DefaultSkinName);
            Properties.Settings.Default.Save();
        }

        private void navBarItem1_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            _displaytype = DisplayTypes.SkinManagement;
            DisplayRightPanel();
            var listSkinName = (from SkinContainer skin in SkinManager.Default.Skins select skin.SkinName).ToList();
            listSkinName.Sort();
            cbeChangeSkin.Properties.Items.Clear();
            cbeChangeSkin.Properties.Items.AddRange(listSkinName);
            cbeChangeSkin.EditValue = Properties.Settings.Default.DefaultSkinName;
        }

        private void nbdecoder_click(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            _displaytype = DisplayTypes.DecoderManagement;
            DisplayRightPanel();

        }

        private void DecoderManagement_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmSetting_Load(object sender, EventArgs e)
        {

        }

        private void contextMenuStrip2_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

      //  private void treeViewDecoder_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
       // {
           // string tag = e.Node.Tag.ToString();
          //  SetDecodermenu();
          //  ShowDecoderAndCameraDataInGridView();

       // }
        //GridControl显示解码器信息
        void showDecoderInfo()
        {
            listDecoder = DecoderBusiness.Instance.GetAllDecoderInfo(ref errMessage);
            var dataTable = new System.Data.DataTable("DecoderInfo");
            dataTable.Columns.Add("编号", typeof(int));
            // dataTable.Columns.Add("id", typeof(int));
            dataTable.Columns.Add("解码器名称", typeof(string));
            dataTable.Columns.Add("解码器端口", typeof(int));
            dataTable.Columns.Add("Ip地址", typeof(string));
            dataTable.Columns.Add("最大解码数", typeof(int));
            int i = 1;
            foreach (var node in listDecoder)
            {

                dataTable.Rows.Add(i++, node.Value.Name, node.Value.Port, node.Value.Ip, node.Value.MaxDecodeChannelNo);
            }

            gridControl1.DataSource = dataTable;
            gridControl1.MainView.PopulateColumns();
            gridView1.Columns["编号"].Width = 10;
            //gridView1.Columns["id"].Width = 20;
            gridView1.Columns["解码器名称"].Width = 30;
            gridView1.Columns["解码器端口"].Width = 10;
            gridView1.Columns["Ip地址"].Width = 30;
            gridView1.Columns["最大解码数"].Width = 10;
            
        }
        private void ShowDecoderAndCameraDataInGridView(object sender, EventArgs e)
        {
            showDecoderInfo();
        }
      
       
        private void treeListShowDecoder_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                TreeListNode node = treeListShowDecoder.FocusedNode;
                if ((node.Tag.ToString()).IndexOf("T") >= 0)
                {
                    popupMenuDecoder.ShowPopup(Cursor.Position);

                }
                else if ((node.Tag.ToString()).IndexOf("D") >= 0)
                {
                    popupMenuCamera.ShowPopup(Cursor.Position);
                }
                else if ((node.Tag.ToString()).IndexOf("C") >= 0)
                {
                    popupMenu1.ShowPopup(Cursor.Position);
                }
            }
        }
        //添加解码器
        private void barButtonItem1AddDecoder_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            AddXtraForm addDecoder = new AddXtraForm();
            addDecoder.Opt = Util.Operateion.Add;
            addDecoder.ShowDialog(this);
            BuildDecoderTree();
            showDecoderInfo();
        }
        
        private void barButtonItem2EditDecoder_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            AddXtraForm addDecoder = new AddXtraForm();
            addDecoder.Opt = Util.Operateion.Update;
            //addDecoder.Id = int.Parse(treeListShowDecoder.FocusedNode.Tag.ToString().Split(';')[0]);
            addDecoder.ShowDialog(this);
        }
        //修改解码器
        private void barButtonItem5EditDecoder_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            AddXtraForm addDecoder = new AddXtraForm();
            addDecoder.Opt = Util.Operateion.Update;
            addDecoder.Id = int.Parse(treeListShowDecoder.FocusedNode.Tag.ToString().Split(';')[0]);
            addDecoder.ShowDialog(this);
            BuildDecoderTree();
            showDecoderInfo();
        }
        //添加摄像头
        private void barButtonItem4AddCamera_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            AddCameraInDecoder addCamera = new AddCameraInDecoder();
            addCamera.DecoderID = int.Parse(treeListShowDecoder.FocusedNode.Tag.ToString().Split(';')[0]);
            addCamera.ShowDialog(this);
            BuildDecoderTree();
        }
        //删除解码器
        private void barButtonItem6DeleteDecoder_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            TreeListNode tn = treeListShowDecoder.FocusedNode;
            if (tn == null)
            {
                return;
            }
            if ((tn.Tag.ToString().IndexOf("B") >= 0))
            {
                if (XtraMessageBox.Show("确定要删除该解码器?", "提示", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
                {
                    string[] strs = tn.Tag.ToString().Split(';');
                    int decoderid = int.Parse(strs[0]);
                    DecoderInfo di = DecoderBusiness.Instance.GetDecoderInfoByDecoderId(ref errMessage, decoderid);
                    DecoderBusiness.Instance.DeleteByDecoderId(ref errMessage, decoderid);
                    DecoderBusiness.Instance.Delete(ref errMessage, decoderid);
                    OperateLogBusiness.Instance.Insert(ref errMessage, new OperateLog
                    {
                        DeviceId = di.id,
                        ClientUserId = MainForm.CurrentUser.UserId,
                        ClientUserName =MainForm.CurrentUser.UserName,
                        Content = di.ToString(),
                        HappenTime = DateTime.Now,
                        OperateTypeId =(int)(OperateLogTypeId.DecoderDelete),
                        OperateTypeName =OperateLogTypeName.DecoderDelete,
                        OperateUserName =MainForm.CurrentUser.UserName
                    });
                    BuildDecoderTree();
                    showDecoderInfo();
                }

            }
        }
        //删除摄像头
        private void barButtonItemDeleteCamera_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            TreeListNode tn = treeListShowDecoder.FocusedNode;
            if (tn == null)
            {
                return;
            }
            if ((tn.Tag.ToString().IndexOf("C") >= 0))
            {
                if (XtraMessageBox.Show("确定要删除该摄像头?", "提示", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
                {
                    string[] strs = tn.Tag.ToString().Split(';');
                    int cameraid = int.Parse(strs[0]);
                    CameraInfo di = CameraBusiness.Instance.GetCameraInfoByCameraId(ref errMessage, cameraid);
                    DecoderBusiness.Instance.DeleteCamera(ref errMessage, cameraid);
                    OperateLogBusiness.Instance.Insert(ref errMessage, new OperateLog
                    {
                        DeviceId = di.CameraId,
                        ClientUserId = MainForm.CurrentUser.UserId,
                        ClientUserName = MainForm.CurrentUser.UserName,
                        Content = di.ToString(),
                        HappenTime = DateTime.Now,
                        OperateTypeId = (int)(OperateLogTypeId.CameraDeleteInDecoder),
                        OperateTypeName = OperateLogTypeName.CameraDeleteInDecoder,
                        OperateUserName = MainForm.CurrentUser.UserName
                    });
                    BuildDecoderTree();

                }

            }
        }
        //双击地图信息
        private void tvMap_DoubleClick_1(object sender, EventArgs e)
        {
            string str = tvMap.FocusedNode.Tag.ToString();
            if (str.IndexOf("d") >= 0)
            {
                string[] strs = str.Split(';');
                CurrentMapInfo = _listMapInfo[int.Parse(strs[0])];
                pictureBoxMap.Image = Image.FromFile(Path.Combine(Application.StartupPath, CurrentMapInfo.FileName));
                teMapName.Text = CurrentMapInfo.Name;

            }
        }
        //删除地图信息
        private void barButtonItemDeleteMap_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                string str = tvMap.FocusedNode.Tag.ToString();
                if (str.IndexOf("d") >= 0)
                {
                    string[] strs = str.Split(';');
                    MapBusiness.Instance.Delete(ref errMessage, int.Parse(strs[0]));
                    BuildMapTree();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        //右键弹出删除地图
        private void tvMap_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                TreeListNode node = tvMap.FocusedNode;
                if ((node.Tag.ToString()).IndexOf("d") >= 0)
                {
                    popupMenuDeleteMap.ShowPopup(Cursor.Position);

                }
            }
        }

    }
    public enum DisplayTypes
    {
        DeviceManagement = 1,
        UserManagement = 4,
        LogManagement = 8,
        SynGroupManagement = 16,
        GroupSwitchManagement = 32,
        ProSwitchManagement = 64,
        DisplayChannelManagement = 128,
        MapManagement = 256,
        SkinManagement = 512,
        DecoderManagement=1024

    }
}