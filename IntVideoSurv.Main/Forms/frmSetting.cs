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
        Dictionary<int, RecognizerInfo> listRecognizer;
        private int CurrentParentId = 0;

        Dictionary<int, SynGroup> _listSynGroup;
        Dictionary<int, DisplayChannelInfo> _listDisplayChannel;
        Dictionary<int, MapInfo> _listMapInfo;
        Dictionary<int, DecoderInfo> listDecoder;
        Dictionary<int, CameraInfo> clist = new Dictionary<int, CameraInfo>();
        Dictionary<int, LongChang_CameraInfo> clist1 = new Dictionary<int, LongChang_CameraInfo>();
        Dictionary<int, UserInfo> listUser = new Dictionary<int, UserInfo>();
        private DisplayTypes _displaytype = DisplayTypes.DeviceManagement;
        public Dictionary<int,VirtualGroupInfo> listVirtualGroup;
        public frmSetting()
        {
            InitializeComponent();
            BuildDeviceTree();
            BuildCameraTreeInSynGroupManagement();
            BuildCameraTreeInLogManagement();
            //显示DecoderTree
            BuildDecoderTree();
            //显示RecognizerTree
            BuildRecognizerTree();
            LoadUsers();
            BuildDisplayChannelTreeInSynGroupManagement();
            BuildDisplayChannelTreeInDisplayChannelManagement();
            dateEditEndDate.DateTime = DateTime.Now;
            DisplayRightPanel();
            showDecoderInfo();
            ShowRecognizerInfo();
            //
            BuildVirtualGroupTree();
            showVirtualGroupInfo();
            //查询用户显示
            loadUserInfo();
            //针对隆昌，隐藏不必要的信息
            showLongChangCameraInfo();
            showLongChangTollGateInfo();
            FilterInterFaceForLongChang();
        }

        private void FilterInterFaceForLongChang()
        {
            if (MainForm.CurrentUser.UserTypeId == 1)//管理员
            {
                nbDevice.Visible = false;
                nbMap.Visible = false;
                navBarItem2.Visible = false;
                navBarItem3.Visible = false;
                nbLog.Visible = false;
                nbCode.Visible = false;
                _displaytype = DisplayTypes.UserManagement;
                DisplayRightPanel();
            }
            else if (MainForm.CurrentUser.UserTypeId == 2)//操作员
            {
                nbUser.Visible = false;
                nbVirtualGroup.Visible = false;
                nbDevice.Visible = false;
                nbMap.Visible = false;
                navBarItem2.Visible = false;
                navBarItem3.Visible = false;
                nbLog.Visible = false;
                nbTogDevice.Visible = false;
                nbTollGate.Visible = false;
                _displaytype = DisplayTypes.SkinManagement;
                DisplayRightPanel();
            }
            
        }

        /// <summary>
        /// 显示识别器信息
        /// </summary>
        private void BuildRecognizerTree()
        {
            listRecognizer = RecognizerBusiness.Instance.GetAllRecognizerInfo(ref errMessage);
            Cursor currentCursor = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;
            TreeListNode node;
            TreeListNode camnode;

            treeListShowRecognizer.Nodes.Clear();
            TreeListNode treeListNodeRoot = treeListShowRecognizer.AppendNode(new[] { "识别器管理", 0 + ";T" }, -1, 0, 3, 1, CheckState.Checked);
            treeListNodeRoot.Tag = 0 + ";T";
            if (listRecognizer != null)
            {

                foreach (KeyValuePair<int, RecognizerInfo> item in listRecognizer)
                {
                    TreeListNode treeListNodeReconizer = treeListShowRecognizer.AppendNode(new[] { item.Value.Name, item.Key + ";R" }, treeListNodeRoot.Id, 1, 3, 1, CheckState.Checked);
                    treeListNodeReconizer.Tag = item.Key + ";R";
                    foreach (KeyValuePair<int, CameraInfo> cam in item.Value.ListCameras)
                    {
                        DeviceInfo di = DecoderBusiness.Instance.GetDeviceInfoByCameraId(ref errMessage, cam.Value.CameraId);
                        camnode = treeListShowRecognizer.AppendNode(new[] { di.Name + ":" + cam.Value.Name, item.Key + ";C" }, treeListNodeReconizer.Id, 1, 3, 1, CheckState.Checked);
                        camnode.Tag = cam.Key.ToString() + ";C";
                    }
                }
            }
            treeListShowRecognizer.Columns[1].Visible = false;
            treeListShowRecognizer.ExpandAll();
            Cursor.Current = currentCursor;

        }
        private void BuildDeviceTree()
        {
            listGroup = GroupBusiness.Instance.GetAllGroupInfos(ref errMessage);
            Cursor currentCursor = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;
            TreeListNode node;
            treeListDevice.Nodes.Clear();
            foreach (KeyValuePair<int, GroupInfo> item in listGroup)
            {
                if (item.Value.ParentId == 0)
                {
                    node = treeListDevice.AppendNode(new[] { item.Value.Name, 0 + ";R" }, -1, 1, 3, 1, CheckState.Checked);
                    node.Tag = item.Key.ToString() + ";R";
                    AppendDeviceNode(node, item.Key);
                    //treeListDevice.Nodes.Add(node);

                }

            }
            treeListDevice.ExpandAll();
            treeListDevice.Columns[1].Visible = false;
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

        private void AppendDeviceNode(TreeListNode aNode, int ParentId)
        {
            try
            {
                TreeListNode node;
                TreeListNode devicenode;
                TreeListNode camnode;
                foreach (KeyValuePair<int, GroupInfo> item in listGroup)
                {
                    if (item.Value.ParentId == ParentId)
                    {
                        
                        node = treeListDevice.AppendNode(new[] { item.Value.Name, item.Key + ";G" }, aNode.Id, 1, 3, 1, CheckState.Checked);
                        node.Tag = item.Key.ToString() + ";G";
                        
                        foreach (KeyValuePair<int, DeviceInfo> device in item.Value.ListDevice)
                        {
                            devicenode = treeListDevice.AppendNode(new[] { device.Value.Name, device.Key + ";D" }, node.Id, 1, 3, 1, CheckState.Checked);
                            devicenode.Tag = device.Key.ToString() + ";D";


                            foreach (KeyValuePair<int, CameraInfo> cam in device.Value.ListCamera)
                            {
                                camnode = treeListDevice.AppendNode(new[] { cam.Value.Name, cam.Key + ";C" }, devicenode.Id, 1, 3, 1, CheckState.Checked);
                                camnode.Tag = cam.Key.ToString() + ";C";
                            }

                        }
                        AppendDeviceNode(node, item.Key);
                        if(aNode==null)
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
            if (tag.IndexOf("C") >= 0)
                {
                    contextMenuStripGroupAndDevice.Visible = true;
                    AddGroupToolStripMenuItem.Visible = false;
                    EditGroupToolStripMenuItem.Visible = false;
                    DeleteGroupToolStripMenuItem.Visible = false;
                    AddDeviceToolStripMenuItem.Visible = false;
                    EditDeviceToolStripMenuItem.Visible = false;
                    DeleteDeviceToolStripMenuItem.Visible = false;

                }
                else if (tag.IndexOf("D") >= 0)
                {
                    string[] str = tag.Split(';');
                    CurrentParentId = int.Parse(str[0]);
                    contextMenuStripGroupAndDevice.Visible = true;
                    AddGroupToolStripMenuItem.Visible = false;
                    EditGroupToolStripMenuItem.Visible = false;
                    DeleteGroupToolStripMenuItem.Visible = false;
                    AddDeviceToolStripMenuItem.Visible = false;
                    EditDeviceToolStripMenuItem.Visible = true;
                    DeleteDeviceToolStripMenuItem.Visible = true;
                    contextMenuStripGroupAndDevice.Show(Cursor.Position);
                }
                else if (tag.IndexOf("R") >= 0)
                {
                    string[] str = tag.Split(';');
                    CurrentParentId = int.Parse(str[0]);
                    contextMenuStripGroupAndDevice.Visible = true;
                    AddDeviceToolStripMenuItem.Visible = false;
                    EditDeviceToolStripMenuItem.Visible = false;
                    DeleteDeviceToolStripMenuItem.Visible = false;
                    AddGroupToolStripMenuItem.Visible = true;
                    EditGroupToolStripMenuItem.Visible = false;
                    DeleteGroupToolStripMenuItem.Visible = false;
                    contextMenuStripGroupAndDevice.Show(Cursor.Position);
                }
                else if (tag.IndexOf("G") >= 0)
                {
                     string[] str = tag.Split(';');
                     CurrentParentId = int.Parse(str[0]);
                    contextMenuStripGroupAndDevice.Visible = true;
                    AddGroupToolStripMenuItem.Visible = false;
                    EditGroupToolStripMenuItem.Visible = true;
                    DeleteGroupToolStripMenuItem.Visible = true;
                    AddDeviceToolStripMenuItem.Visible = true;
                    EditDeviceToolStripMenuItem.Visible = false;
                    DeleteDeviceToolStripMenuItem.Visible = false;
                    contextMenuStripGroupAndDevice.Show(Cursor.Position);
                }
            
        }


        private void treeList2_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {

        }

        private void AddGroupToolStripMenuItem_Click(object sender, EventArgs e)
        {
          //  if (CurrentParentId == 0)
           // {
                
                //return;
           // }
            frmGroup group = new frmGroup();
            group.Opt = Util.Operateion.Add;
            group.ParentGroupId =CurrentParentId;//根目录的ID为1
            group.ShowDialog(this);
            treeListDevice.Nodes.Clear();
            BuildDeviceTree();

        }

        private void treeList1_TreeListMenuItemClick(object sender, DevExpress.XtraTreeList.TreeListMenuItemClickEventArgs e)
        {

        }
        //右键响应函数
        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            string tag = e.Node.Tag.ToString();
            Setmenu(tag);
            
            // string[] str = tag.Split(';');
            // CurrentParentId = int.Parse(str[0]);

            //alDevices.Clear();
            //getDevicess(e.Node);
            //ShowDataInGridView(dgvDevice, DeviceBusiness.Instance.GetDisplayDeviceByDeviceList(ref errMessage, makeDeviceList()));

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
            treeListDevice.Nodes.Clear();
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
            //查询管理
            gcSearchManagement.Visible = false;
            //解码器
            DecoderManagement.Visible = false;
            //识别器
            RecognizerManagement.Visible = false;
            //组管理
            gcVritualGroupManegement.Visible = false;
            //
            gcTogDeviceManagement.Visible = false;
            groupControl_TollGate.Visible = false;
            gcCodeManagement.Visible = false;
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
                //识别器管理
                case DisplayTypes.RecognizerManagement:
                    RecognizerManagement.Visible = true;
                    RecognizerManagement.Dock = DockStyle.Fill;
                    gridView5.OptionsView.ShowGroupPanel = false;
                    break;
                case DisplayTypes.VirtualGroupManagement:
                    gcVritualGroupManegement.Visible = true;
                    gcVritualGroupManegement.Dock = DockStyle.Fill;
                    gridView6.OptionsView.ShowGroupPanel = false;
                    break;
                case DisplayTypes.SearchManagement:
                    gcSearchManagement.Visible = true;
                    gcSearchManagement.Dock = DockStyle.Fill;
                    gridView7.OptionsView.ShowGroupPanel = false;
                    break;
                case DisplayTypes.ToGDeviceManagement:
                    gcTogDeviceManagement.Visible = true;
                    gcTogDeviceManagement.Dock = DockStyle.Fill;
                    gridViewToGDevice.OptionsView.ShowGroupPanel = false;
                    break;
                case DisplayTypes.TollGateManagement:
                    groupControl_TollGate.Visible = true;
                    groupControl_TollGate.Dock = DockStyle.Fill;
                    gridView_TollGate.OptionsView.ShowGroupPanel = false;
                    break;
                case DisplayTypes.CodeManagement:
                    gcCodeManagement.Visible = true;
                    gcCodeManagement.Dock = DockStyle.Fill;
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
        //GRIDCONTROL显示用户信息
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
            if (dataTable==null)
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
            catch(Exception ex)
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
                    int userid = Convert.ToInt32(gridView3.GetFocusedRowCellValue("索引号").ToString());
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
            TreeListNode tn = treeListDevice.FocusedNode;
            if (tn == null)
            {
                return;
            }
            //此处由tn.FirstNode==null改为tn.FirstNode!=null
            if ((tn.Tag.ToString().IndexOf("G") >= 0) && tn.FirstNode ==null)
            {
                string[] strs = tn.Tag.ToString().Split(';');
                int groupid = int.Parse(strs[0]);
                GroupInfo gi = GroupBusiness.Instance.GetGroupInfoByGroupId(ref errMessage, groupid);
                GroupBusiness.Instance.Delete(ref errMessage, groupid);
                OperateLogBusiness.Instance.Insert(ref errMessage, new OperateLog
                   {
                       GroupId = gi.GroupID,
                       ClientUserId = MainForm.CurrentUser.UserId,
                       ClientUserName =MainForm.CurrentUser.UserName,  
                       Content = gi.ToString(),
                       HappenTime = DateTime.Now,
                       OperateTypeId =(int) (OperateLogTypeId.GroupDelete),  
                       OperateTypeName =OperateLogTypeName.GroupDelete,
                       OperateUserName =MainForm.CurrentUser.UserName    
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
            int groupId = int.Parse(treeListDevice.FocusedNode.Tag.ToString().Split(';')[0]);
            frmGroup group = new frmGroup();
            group.Opt = Util.Operateion.Update;
            group.GroupId = groupId;
            group.ShowDialog(this);
            BuildDeviceTree();
        }

        private void DeleteDeviceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeListNode tn = treeListDevice.FocusedNode;
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
            if (LastMapInfo != null)
            {
                pictureBoxMap.Image = Image.FromFile(Path.Combine(Application.StartupPath, LastMapInfo.FileName));
                teMapName.Text = LastMapInfo.Name;
            }
            Cursor.Current = currentCursor;

        }

        private Image CurrentImage;
        private string CurrentFileName;
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
            frmDecoder addDecoder = new frmDecoder();
            addDecoder.Opt = Util.Operateion.Add;
            addDecoder.ShowDialog(this);
            BuildDecoderTree();
            showDecoderInfo();
        }
        
        private void barButtonItem2EditDecoder_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmDecoder addDecoder = new frmDecoder();
            addDecoder.Opt = Util.Operateion.Update;
            //addDecoder.Id = int.Parse(treeListShowDecoder.FocusedNode.Tag.ToString().Split(';')[0]);
            addDecoder.ShowDialog(this);
        }
        //修改解码器
        private void barButtonItem5EditDecoder_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int decoderId = int.Parse(treeListShowDecoder.FocusedNode.Tag.ToString().Split(';')[0]);
            frmDecoder addDecoder = new frmDecoder(listDecoder[decoderId]);
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
            addCamera.Opt1 = Util.OptionSelect.Decoder;
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
            if ((tn.Tag.ToString().IndexOf("D") >= 0))
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
        //右键单击出现删除、更新、增加设备信息
        private void TreeListDeviceRightClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                TreeListNode node = treeListDevice.FocusedNode;
                Setmenu(node.Tag.ToString());
            }
        }
        //增加地图
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
        //右键单击出现删除地图按钮
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
        //删除地图
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
        //单击不同的节点显示不同的信息
        private void treeListDevice_Click(object sender, EventArgs e)
        {
            
            string str = treeListDevice.FocusedNode.Tag.ToString();
            if(str.IndexOf("R") >= 0)
            {
                showAllDeviceInfo(DeviceBusiness.Instance.GetAllDeviceInfo(ref errMessage));
            }
            else if(str.IndexOf("G") >= 0)
            {
                int groupId = int.Parse(str.Split(';')[0]);
                showAllDeviceInfo(DeviceBusiness.Instance.GetDeviceInfoByGroupId(ref errMessage,groupId));

            }
            else if(str.IndexOf("D") >= 0)
            {
                int DeviceId = int.Parse(str.Split(';')[0]);
                showAllCameraInfo(DeviceId);

            }
        }
        void showAllDeviceInfo(Dictionary<int, DeviceInfo> listDevice)
        {
            if(listDevice==null)
            {
                return;

            }
            //Dictionary<int, DeviceInfo> listDevice = DeviceBusiness.Instance.GetAllDeviceInfo(ref errMessage);
            var dataTable = new System.Data.DataTable("DeviceInfo");
            dataTable.Columns.Add("编号", typeof(int));
            // dataTable.Columns.Add("id", typeof(int));
            dataTable.Columns.Add("设备号", typeof(int));
            dataTable.Columns.Add("设备名称", typeof(string));
            dataTable.Columns.Add("设备IP地址", typeof(string));
            dataTable.Columns.Add("设备端口号", typeof(int));
            int i = 1;
            foreach (var node in listDevice)
            {

                dataTable.Rows.Add(i++, node.Value.DeviceId, node.Value.Name, node.Value.source, node.Value.Port);
            }

            gridControlShowDevice.DataSource = dataTable;
            gridControlShowDevice.MainView.PopulateColumns();
            gridView4.Columns["编号"].Width = 10;
            //gridView1.Columns["id"].Width = 20;
            //gridView4.Columns["设备号"].Width = 30;
            gridView4.Columns["设备名称"].Width = 10;
            gridView4.Columns["设备IP地址"].Width = 30;
            gridView4.Columns["设备端口号"].Width = 10;
            gridView4.Columns["设备号"].Visible = false;

        }

        void showAllCameraInfo(int DeviceId)
        {
            Dictionary<int,CameraInfo> cameraList = CameraBusiness.Instance.GetCamInfoByDeviceId(ref errMessage, DeviceId);
            if(cameraList==null)
            {
                return;

            }
            var dataTable = new System.Data.DataTable("CameraInfo");
            dataTable.Columns.Add("编号", typeof(int));
            //dataTable.Columns.Add("id", typeof(int));
            dataTable.Columns.Add("摄像头号", typeof(int));
            dataTable.Columns.Add("摄像头名称", typeof(string));
            dataTable.Columns.Add("设备名称", typeof(string));
            dataTable.Columns.Add("描述", typeof(string));
            int i = 1;
            foreach (var node in cameraList)
            {
                DeviceInfo di = DecoderBusiness.Instance.GetDeviceInfoByCameraId(ref errMessage, node.Value.CameraId);
                dataTable.Rows.Add(i++, node.Value.CameraId, node.Value.Name, di.Name,node.Value.Description);
            }

            gridControlShowDevice.DataSource = dataTable;
            gridControlShowDevice.MainView.PopulateColumns();
            gridView4.Columns["编号"].Width = 10;
            //gridView1.Columns["id"].Width = 20;
            //gridView4.Columns["设备号"].Width = 30;
            gridView4.Columns["摄像头名称"].Width = 10;
            gridView4.Columns["设备名称"].Width = 20;
            gridView4.Columns["描述"].Width = 30;
            gridView4.Columns["摄像头号"].Visible = false;

        }
        //识别器显示
        private void nbRecognizer_link(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            _displaytype = DisplayTypes.RecognizerManagement;
            DisplayRightPanel();
        }
        /// <summary>
        /// 显示识别器信息
        /// </summary>
        private void ShowRecognizerInfo()
        {
            listRecognizer = RecognizerBusiness.Instance.GetAllRecognizerInfo(ref errMessage);
            var dataTable = new System.Data.DataTable("RecognizerInfo");
            dataTable.Columns.Add("编号", typeof(int));
            // dataTable.Columns.Add("id", typeof(int));
            dataTable.Columns.Add("识别器名称", typeof(string));
            dataTable.Columns.Add("识别器端口", typeof(int));
            dataTable.Columns.Add("识别器Ip地址", typeof(string));
            dataTable.Columns.Add("识别器最大解码数", typeof(int));
            dataTable.Columns.Add("识别器类型", typeof(string));
            int i = 1;
            string recoginzerType="";
            /*if (listRecognizer==null)
            {
                return;
            }*/
            foreach (var node in listRecognizer)
            {
                switch (node.Value.RecogType)
                {
                   case 1:
                      recoginzerType = "Event";
                	  break;
                    case 2:
                      recoginzerType = "Vehicle";
                      break;
                    case 4:
                      recoginzerType = "Face";
                      break;
                    default:
                      break;
                }
                dataTable.Rows.Add(i++, node.Value.Name, node.Value.Port, node.Value.Ip, node.Value.MaxRecogNumber,recoginzerType);
            }

            gridControlShowRecognizer.DataSource = dataTable;
            gridControlShowRecognizer.MainView.PopulateColumns();
            gridView5.Columns["编号"].Width = 10;
            //gridView1.Columns["id"].Width = 20;
            gridView5.Columns["识别器名称"].Width = 30;
            gridView5.Columns["识别器端口"].Width = 10;
            gridView5.Columns["识别器Ip地址"].Width = 30;
            gridView5.Columns["识别器最大解码数"].Width = 10;
            gridView5.Columns["识别器类型"].Width = 30;
        }
        /// <summary>
        /// 右键单击识别器管理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeListShowRecognizer_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                TreeListNode node = treeListShowRecognizer.FocusedNode;
                if ((node.Tag.ToString()).IndexOf("T") >= 0)
                {
                    popupMenuAddRecognizer.ShowPopup(Cursor.Position);

                }
                else if ((node.Tag.ToString()).IndexOf("R") >= 0)
                {
                    popupMenuAddCameraInRecognizer.ShowPopup(Cursor.Position);
                }
                else if ((node.Tag.ToString()).IndexOf("C") >= 0)
                {
                    popupMenuDeleteCamera.ShowPopup(Cursor.Position);
                }
            }
        }
        //新增识别器
        private void barButtonItemRecognizer_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            AddRecognizer addRecognizer = new AddRecognizer();
            addRecognizer.Opt = Util.Operateion.Add;
            addRecognizer.ShowDialog(this);
            BuildRecognizerTree();
            ShowRecognizerInfo();
        }
        //修改识别器
        private void barButtonItemEditRecognizer_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            RecognizerInfo ri = RecognizerBusiness.Instance.GetRecognizerInfoByRecognizerId(ref errMessage, int.Parse(treeListShowRecognizer.FocusedNode.Tag.ToString().Split(';')[0]));
            AddRecognizer editRecognizer = new AddRecognizer(ri);
            editRecognizer.Opt = Util.Operateion.Update;
            editRecognizer.Id = int.Parse(treeListShowRecognizer.FocusedNode.Tag.ToString().Split(';')[0]);
            editRecognizer.ShowDialog(this);
            BuildRecognizerTree();
            ShowRecognizerInfo();
        }
        //删除识别器
        private void barButtonItemDeleteRecognizer_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            TreeListNode tn = treeListShowRecognizer.FocusedNode;
            if (tn == null)
            {
                return;
            }
            if ((tn.Tag.ToString().IndexOf("R") >= 0))
            {
                if (XtraMessageBox.Show("确定要删除该识别器吗?", "提示", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
                {
                    string[] strs = tn.Tag.ToString().Split(';');
                    int Recognizerid = int.Parse(strs[0]);
                    RecognizerInfo ri = RecognizerBusiness.Instance.GetRecognizerInfoByRecognizerId(ref errMessage, Recognizerid);
                    //DecoderBusiness.Instance.DeleteByDecoderId(ref errMessage, decoderid);
                    RecognizerBusiness.Instance.Delete(ref errMessage, Recognizerid);
                    OperateLogBusiness.Instance.Insert(ref errMessage, new OperateLog
                    {
                        DeviceId = ri.Id,
                        ClientUserId = MainForm.CurrentUser.UserId,
                        ClientUserName = MainForm.CurrentUser.UserName,
                        Content = ri.ToString(),
                        HappenTime = DateTime.Now,
                        OperateTypeId = (int)(OperateLogTypeId.RecognizerDelete),
                        OperateTypeName = OperateLogTypeName.RecognizerDelete,
                        OperateUserName = MainForm.CurrentUser.UserName
                    });
                    BuildRecognizerTree();
                    ShowRecognizerInfo();
                }

            }
        }
        //为识别器增加摄像头
        private void barButtonItemAddCameraInRecognizer_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            AddCameraInDecoder addCamera = new AddCameraInDecoder();
            addCamera.RecognizerID = int.Parse(treeListShowRecognizer.FocusedNode.Tag.ToString().Split(';')[0]);
            addCamera.Opt1 = Util.OptionSelect.Recognizer;
            addCamera.ShowDialog(this);
            BuildRecognizerTree();
        }
        //识别器删除摄像头
        private void barButtonItemDeleteCameraInRecognizer_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            TreeListNode tn = treeListShowRecognizer.FocusedNode;
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
                    RecognizerBusiness.Instance.DeleteCamera(ref errMessage, cameraid);
                    OperateLogBusiness.Instance.Insert(ref errMessage, new OperateLog
                    {
                        DeviceId = di.CameraId,
                        ClientUserId = MainForm.CurrentUser.UserId,
                        ClientUserName = MainForm.CurrentUser.UserName,
                        Content = di.ToString(),
                        HappenTime = DateTime.Now,
                        OperateTypeId = (int)(OperateLogTypeId.CameraDeleteInRecognizer),
                        OperateTypeName = OperateLogTypeName.CameraDeleteInRecognizer,
                        OperateUserName = MainForm.CurrentUser.UserName
                    });
                    BuildRecognizerTree();

                }

            }
        }

        private void nbVirtualGroup_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            _displaytype = DisplayTypes.VirtualGroupManagement;
            DisplayRightPanel();
        }

        public void BuildVirtualGroupTree()
        {
            /*listVirtualGroup =VirtualGroupBusiness.Instance.GetAllVirtualGroupInfo(ref errMessage);
            Cursor currentCursor = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;
            TreeListNode node;
            TreeListNode camnode;
            

            treeListVirtualGroup.Nodes.Clear();
            TreeListNode treeListNodeRoot = treeListVirtualGroup.AppendNode(new[] { "组管理", 0 + ";A" }, -1, 0, 3, 1, CheckState.Checked);
            treeListNodeRoot.Tag = 0 + ";A";
            if (listVirtualGroup != null)
            {

                foreach (KeyValuePair<int, VirtualGroupInfo> item in listVirtualGroup)
                {
                    TreeListNode treeListNodeG = treeListVirtualGroup.AppendNode(new[] { item.Value.Name, item.Key + ";B" }, treeListNodeRoot.Id, 1, 3, 1, CheckState.Checked);
                    treeListNodeG.Tag = item.Key + ";B";
                    TreeListNode treeListNodeGQ = treeListVirtualGroup.AppendNode(new[] { "摄像头管理", item.Key + ";C" }, treeListNodeG.Id, 1, 3, 1, CheckState.Checked);
                    treeListNodeGQ.Tag = item.Key + ";C";
                    TreeListNode treeListNodeUQ = treeListVirtualGroup.AppendNode(new[] { "用户管理", item.Key + ";E" }, treeListNodeG.Id, 1, 3, 1, CheckState.Checked);
                    treeListNodeUQ.Tag = item.Key + ";E";
                    clist = CameraGroupBusiness.Instance.GetAllCameraInfo(ref errMessage,item.Key);
                    listUser = UserGroupBusiness.Instance.GetAllCameraInfo(ref errMessage, item.Key);
                    foreach(KeyValuePair<int, CameraInfo> itemcamera in clist)
                    {
                       // TreeListNode treeListNodeC = treeListVirtualGroup.AppendNode(new[] { itemcamera.Value.Name, itemcamera.Key + ";D" }, treeListNodeGQ.Id, 1, 3, 1, CheckState.Checked);
                        //treeListNodeC.Tag = itemcamera.Key + ";D";
                        DeviceInfo di = DecoderBusiness.Instance.GetDeviceInfoByCameraId(ref errMessage, itemcamera.Value.CameraId);
                        TreeListNode treeListNodeC = treeListVirtualGroup.AppendNode(new[] { di.Name + ":" + itemcamera.Value.Name, itemcamera.Key + ";D" }, treeListNodeGQ.Id, 1, 3, 1, CheckState.Checked);
                        treeListNodeC.Tag = itemcamera.Key + ";D";
                    }
                    foreach (KeyValuePair<int, UserInfo> itemuser in listUser)
                    {
                        TreeListNode treeListNodeU = treeListVirtualGroup.AppendNode(new[] { itemuser.Value.UserName, itemuser.Key + ";F" }, treeListNodeUQ.Id, 1, 3, 1, CheckState.Checked);
                        treeListNodeU.Tag = itemuser.Key + ";F";
                    }
                }
            }
            treeListVirtualGroup.Columns[1].Visible = false;
            treeListVirtualGroup.ExpandAll();
            Cursor.Current = currentCursor;*/
            listVirtualGroup = VirtualGroupBusiness.Instance.GetAllVirtualGroupInfo(ref errMessage);
            Cursor currentCursor = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;
            TreeListNode node;
            TreeListNode camnode;


            treeListVirtualGroup.Nodes.Clear();
            TreeListNode treeListNodeRoot = treeListVirtualGroup.AppendNode(new[] { "组管理", 0 + ";A" }, -1, 0, 3, 1, CheckState.Checked);
            treeListNodeRoot.Tag = 0 + ";A";
            if (listVirtualGroup != null)
            {

                foreach (KeyValuePair<int, VirtualGroupInfo> item in listVirtualGroup)
                {
                    TreeListNode treeListNodeG = treeListVirtualGroup.AppendNode(new[] { item.Value.Name, item.Key + ";B" }, treeListNodeRoot.Id, 1, 3, 1, CheckState.Checked);
                    treeListNodeG.Tag = item.Key + ";B";
                    TreeListNode treeListNodeGQ = treeListVirtualGroup.AppendNode(new[] { "摄像头管理", item.Key + ";C" }, treeListNodeG.Id, 1, 3, 1, CheckState.Checked);
                    treeListNodeGQ.Tag = item.Key + ";C";
                    TreeListNode treeListNodeUQ = treeListVirtualGroup.AppendNode(new[] { "用户管理", item.Key + ";E" }, treeListNodeG.Id, 1, 3, 1, CheckState.Checked);
                    treeListNodeUQ.Tag = item.Key + ";E";
                    clist1 = CameraGroupBusiness.Instance.GetAllLongChangCameraInfo(ref errMessage, item.Key);
                    listUser = UserGroupBusiness.Instance.GetAllCameraInfo(ref errMessage, item.Key);
                    foreach (KeyValuePair<int, LongChang_CameraInfo> itemcamera in clist1)
                    {
                        // TreeListNode treeListNodeC = treeListVirtualGroup.AppendNode(new[] { itemcamera.Value.Name, itemcamera.Key + ";D" }, treeListNodeGQ.Id, 1, 3, 1, CheckState.Checked);
                        //treeListNodeC.Tag = itemcamera.Key + ";D"
                        TreeListNode treeListNodeC = treeListVirtualGroup.AppendNode(new[] { itemcamera.Value.TollGateName + ":" + itemcamera.Value.Name, itemcamera.Key + ";D" }, treeListNodeGQ.Id, 1, 3, 1, CheckState.Checked);
                        treeListNodeC.Tag = itemcamera.Key + ";D";
                    }
                    foreach (KeyValuePair<int, UserInfo> itemuser in listUser)
                    {
                        TreeListNode treeListNodeU = treeListVirtualGroup.AppendNode(new[] { itemuser.Value.UserName, itemuser.Key + ";F" }, treeListNodeUQ.Id, 1, 3, 1, CheckState.Checked);
                        treeListNodeU.Tag = itemuser.Key + ";F";
                    }
                }
            }
            treeListVirtualGroup.Columns[1].Visible = false;
            treeListVirtualGroup.ExpandAll();
            Cursor.Current = currentCursor;

        }
        /// <summary>
        /// 右键单击组管理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeListVirtualGroup_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                TreeListNode node = treeListVirtualGroup.FocusedNode;
                if ((node.Tag.ToString()).IndexOf("A") >= 0)
                {
                    //添加组
                    popupMenuAddVirtualGroup.ShowPopup(Cursor.Position);

                }
                else if ((node.Tag.ToString()).IndexOf("B") >= 0)
                {
                    //删除和修改组，。。。。。
                    popupMenuDeleteAndEditVirtualGroup.ShowPopup(Cursor.Position);
                }
                else if ((node.Tag.ToString()).IndexOf("C") >= 0)
                {
                    //添加摄像头，。。。。。
                    popupMenuAddCameraInVirtualGroup.ShowPopup(Cursor.Position);
                }
                else if ((node.Tag.ToString()).IndexOf("D") >= 0)
                {
                    //删除摄像头，。。。。。
                    popupMenuDeleteCameraInVritualGroup.ShowPopup(Cursor.Position);
                }
                else if ((node.Tag.ToString()).IndexOf("E") >= 0)
                {
                    //添加用户，
                    popupMenuAddUser.ShowPopup(Cursor.Position);
                }
                else if ((node.Tag.ToString()).IndexOf("F") >= 0)
                {
                    //删除用户，
                    popupMenuDeleteUser.ShowPopup(Cursor.Position);
                }
                else
                {

                }
                
                
            }
        }
        //从组中删除摄像头
        void DeleteCameraFromVirtualGroup(int GroupID,int CameraID)
        {
            int err;
            err = CameraGroupBusiness.Instance.DeleteByGroupIDandCamID(ref errMessage, GroupID, CameraID);
        }
        //添加摄像头
        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            AddCameraInVirtualGroup fdialog = new AddCameraInVirtualGroup();
            fdialog.Groupid = int.Parse(treeListVirtualGroup.FocusedNode.Tag.ToString().Split(';')[0]);
            fdialog.ShowDialog(this);
            BuildVirtualGroupTree();
           
        }
        //删除组
        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int Gid = int.Parse(treeListVirtualGroup.FocusedNode.Tag.ToString().Split(';')[0]);
            int err;
           err=VirtualGroupBusiness.Instance.DeleteByGroupID(ref errMessage, Gid);
           BuildVirtualGroupTree();
        }
        //添加组
        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            AddVirtualGroup fdialog = new AddVirtualGroup();
            fdialog.ShowDialog(this);
            BuildVirtualGroupTree();
        }
        //添加用户
        private void barButtonItem9_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            AddUserInVirtualGroup user = new AddUserInVirtualGroup();
            user.Groupid = int.Parse(treeListVirtualGroup.FocusedNode.Tag.ToString().Split(';')[0]);
            user.ShowDialog(this);
            BuildVirtualGroupTree();
        }
        //删除用户
        private void barButtonItemDeleteUser_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            TreeListNode tn = treeListVirtualGroup.FocusedNode;
            if (tn == null)
            {
                return;
            }
            if ((tn.Tag.ToString().IndexOf("F") >= 0))
            {
                if (XtraMessageBox.Show("确定要删除该用户吗?", "提示", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
                {
                    string[] strs = tn.Tag.ToString().Split(';');
                    int userid = int.Parse(strs[0]);
                    UserInfo di = UserBusiness.Instance.GetUserInfo(ref errMessage, userid);
                    UserGroupBusiness.Instance.DeleteUser(ref errMessage, userid);
                    OperateLogBusiness.Instance.Insert(ref errMessage, new OperateLog
                    {
                        DeviceId = di.UserId,
                        ClientUserId = MainForm.CurrentUser.UserId,
                        ClientUserName = MainForm.CurrentUser.UserName,
                        Content = di.ToString(),
                        HappenTime = DateTime.Now,
                        OperateTypeId = (int)(OperateLogTypeId.UserDeleteVirtualGroup),
                        OperateTypeName = OperateLogTypeName.UserDeleteInVirtualGroup,
                        OperateUserName = MainForm.CurrentUser.UserName
                    });
                    BuildVirtualGroupTree();

                }

            }
        }
        //删除组
        private void barButtonItemDeleteVirtualGroup_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int Gid = int.Parse(treeListVirtualGroup.FocusedNode.Tag.ToString().Split(';')[0]);
            int err;
            err = VirtualGroupBusiness.Instance.DeleteByGroupID(ref errMessage, Gid);
            err = UserGroupBusiness.Instance.DeleteByVirtualGroupID(ref errMessage,Gid);
            err = CameraGroupBusiness.Instance.DeleteByVirtualGroupID(ref errMessage,Gid);
            BuildVirtualGroupTree();
        }
        //修改组
        private void barButtonItemEditVirtualGroup_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
           // ChangeVirtualGroup frmcv = new ChangeVirtualGroup();
           // frmcv.Show();
        }
        //组中添加摄像头
        private void barButtonItemAddCameraInVritualGroup_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            AddCameraInVirtualGroup fdialog = new AddCameraInVirtualGroup();
            fdialog.Groupid = int.Parse(treeListVirtualGroup.FocusedNode.Tag.ToString().Split(';')[0]);
            fdialog.ShowDialog(this);
            BuildVirtualGroupTree();
        }
        //从组中删除摄像头
        private void barButtonItemDeleteCameraInVirtualGroup_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int i;
            i = int.Parse(treeListVirtualGroup.FocusedNode.Tag.ToString().Split(';')[0]);
            CameraGroupBusiness.Instance.DeleteByCamID(ref errMessage, i);
            BuildVirtualGroupTree();
        }
        Dictionary<int, VirtualGroupInfo> listVG=new Dictionary<int,VirtualGroupInfo>();
        void showVirtualGroupInfo()
        {
            listVG = VirtualGroupBusiness.Instance.GetAllVirtualGroupInfo(ref errMessage);

            var dataTable = new System.Data.DataTable("VirtualGroupInfo");
            dataTable.Columns.Add("编号", typeof(int));
            dataTable.Columns.Add("组名称", typeof(string));
            int i = 1;
            foreach (var node in listVG)
            {

                dataTable.Rows.Add(i++, node.Value.Name);
            }

            gridControlShowVirtualGroup.DataSource = dataTable;
            gridControlShowVirtualGroup.MainView.PopulateColumns();
            gridView6.Columns["编号"].Width = 40;
            gridView6.Columns["组名称"].Width = 40;

        }

        private void nbSearch_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            _displaytype = DisplayTypes.SearchManagement;
            DisplayRightPanel();
        }
        Dictionary<int,UserInfo> listuser = new Dictionary<int,UserInfo>();
        private void loadUserInfo()
        {
            DateTime dt = DateTime.Now;
            teStartTime.EditValue = dt.Year.ToString() + "/" + dt.Month.ToString() + "/" + "01" + " " + "00:00:00";
            teEndTime.EditValue = dt.Year.ToString() + "/" + dt.Month.ToString() + "/" + dt.Day.ToString() + " " + dt.Hour.ToString() + ":" + dt.Minute.ToString() + ":" + dt.Second.ToString();
            comboBoxEditUser.Text = "admin";
            if (MainForm.CurrentUser.UserTypeId == 1)//管理员
            {
                listuser = UserBusiness.Instance.GetAllUserInfo(ref errMessage);
                foreach (var v in listuser)
                {
                    comboBoxEditUser.Properties.Items.Add(v.Value.UserName);
                    comboBoxEditUser.Properties.Tag = v.Key.ToString();
                }

            }
            else if (MainForm.CurrentUser.UserTypeId == 2)//操作员
            {
                gcUserManagement.Visible = false;
                comboBoxEditUser.Properties.Items.Add(MainForm.CurrentUser.UserName);
                comboBoxEditUser.Properties.Tag = MainForm.CurrentUser.UserId.ToString();
            }
        }

        private void simpleButtonSearch_Click(object sender, EventArgs e)
        {
            int i;
            DataSet ds = new DataSet();
            Dictionary<string, string> listIllegalreason = new Dictionary<string, string>();
            DateTime startTime = DateTime.Parse(teStartTime.EditValue.ToString());
            DateTime endTime = DateTime.Parse(teEndTime.EditValue.ToString());

            if (DateTime.Compare(startTime,endTime)>0)
            {
                MessageBox.Show("起始时间不能大于终止时间");
                return;
            }
            ds = LongChang_UserVehMonBusiness.Instance.GetTimeAndIllegalreasonByUserId(ref errMessage, "1",startTime ,endTime);
            var datatable = new System.Data.DataTable("Search");
            datatable.Columns.Add("编号", typeof(int));
            datatable.Columns.Add("用户名", typeof(string));
            datatable.Columns.Add("抓拍违法行为", typeof(string));
            datatable.Columns.Add("时间", typeof(string));
            datatable.Columns.Add("地点", typeof(string));
            for (i = 0; i < ds.Tables[0].Rows.Count;i++ )
            {
                datatable.Rows.Add(i + 1, comboBoxEditUser.Text, ds.Tables[0].Rows[i][0].ToString(), ds.Tables[0].Rows[i][1].ToString(),ds.Tables[0].Rows[i][2].ToString());
            }
            gridControlSearch.DataSource = datatable;
            gridControlSearch.MainView.PopulateColumns();
            gridView7.Columns["编号"].Width = 20;
            gridView7.Columns["用户名"].Width = 40;
            gridView7.Columns["抓拍违法行为"].Width = 140;
            gridView7.Columns["时间"].Width = 70;
            gridView7.Columns["地点"].Width = 60;
            
        }

        private void nbCode_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            _displaytype = DisplayTypes.CodeManagement;
            textBoxName.Text = MainForm.CurrentUser.UserName;
            textBoxName.Enabled = false;
            DisplayRightPanel();
        }

        void showLongChangCameraInfo()
        {
            Dictionary<int, LongChang_CameraInfo> listLongChangcl;
            listLongChangcl = LongChang_CameraBusiness.Instance.GetAllCameraInfo(ref errMessage);

            var dataTable = new System.Data.DataTable("LongChangCameraInfo");
            dataTable.Columns.Add("设备编号", typeof(int));
            dataTable.Columns.Add("设备名称", typeof(string));
            dataTable.Columns.Add("IP地址", typeof(string));
            dataTable.Columns.Add("端口号", typeof(int));
            dataTable.Columns.Add("登陆用户", typeof(string));
            dataTable.Columns.Add("登陆密码", typeof(string));
            dataTable.Columns.Add("设备类型", typeof(string));
            string str;
            foreach (var node in listLongChangcl)
            {
                if (node.Value.Type == 1)
                    str = "枪机";
                else
                    str = "球机";
                dataTable.Rows.Add(node.Value.CameraId, node.Value.Name, node.Value.IP, node.Value.Port, node.Value.UserName, node.Value.PassWord, str);
            }

            gridControlTogDevice.DataSource = dataTable;
            gridControlTogDevice.MainView.PopulateColumns();
            gridViewToGDevice.Columns["设备编号"].Width = 40;
            gridViewToGDevice.Columns["设备名称"].Width = 40;
            gridViewToGDevice.Columns["IP地址"].Width = 40;
            gridViewToGDevice.Columns["端口号"].Width = 40;
            gridViewToGDevice.Columns["登陆用户"].Width = 40;
            gridViewToGDevice.Columns["登陆密码"].Width = 40;
            gridViewToGDevice.Columns["设备类型"].Width = 40;
        }
        void showLongChangTollGateInfo()
        {
            Dictionary<string, LongChang_TollGateInfo> listLongChangtl;
            listLongChangtl = LongChang_TollGateBusiness.Instance.GetAllTollGateInfo(ref errMessage);

            var dataTable = new System.Data.DataTable("LongChangTollGateInfo");
            dataTable.Columns.Add("卡口编号", typeof(string));
            dataTable.Columns.Add("卡口名称", typeof(string));
            dataTable.Columns.Add("卡口简称", typeof(string));
            dataTable.Columns.Add("卡口位置", typeof(string));
            dataTable.Columns.Add("管辖单位编号", typeof(string));
            dataTable.Columns.Add("行政区划", typeof(string));
            dataTable.Columns.Add("卡口类型", typeof(string));
            dataTable.Columns.Add("摄像机编号", typeof(int));
            dataTable.Columns.Add("道路编号", typeof(string));
            dataTable.Columns.Add("道路名称", typeof(string));

            string str;
            foreach (var node in listLongChangtl)
            {
                dataTable.Rows.Add(node.Value.tollNum, node.Value.tollName, node.Value.tollShort, node.Value.tollPosition,
                    node.Value.departmentNum, node.Value.administrationDivsion, node.Value.tollType, node.Value.cameraNum, node.Value.roadNum, node.Value.roadName);
            }

            gridControl_TollGateManagement.DataSource = dataTable;
            gridControl_TollGateManagement.MainView.PopulateColumns();
            gridView_TollGate.Columns["卡口编号"].Width = 30;
            gridView_TollGate.Columns["卡口名称"].Width = 30;
            gridView_TollGate.Columns["卡口简称"].Width = 30;
            gridView_TollGate.Columns["卡口位置"].Width = 30;
            gridView_TollGate.Columns["管辖单位编号"].Width = 30;
            gridView_TollGate.Columns["行政区划"].Width = 30;
            gridView_TollGate.Columns["卡口类型"].Width = 30;
            gridView_TollGate.Columns["摄像机编号"].Width = 30;
            gridView_TollGate.Columns["道路编号"].Width = 30;
            gridView_TollGate.Columns["道路名称"].Width = 30;
        }

        private void nbTogDevice_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            _displaytype = DisplayTypes.ToGDeviceManagement;
            DisplayRightPanel();
        }

        private void nbTollGate_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            _displaytype = DisplayTypes.TollGateManagement;
            DisplayRightPanel();
        }

        private void simpleButtonOK_Click(object sender, EventArgs e)
        {
            if (textBoxFormerCode.Text!=MainForm.CurrentUser.Password.ToString())
            {
                MessageBox.Show("原密码不对");
                return;
            } 
            else
            {
                if (textBoxNowCode.Text!=textBoxNowCodeFirm.Text)
                {
                    MessageBox.Show("新密码不匹配");
                    return;
                }
                string code = textBoxNowCode.Text;
                UserBusiness.Instance.UpdatePassword(ref errMessage, MainForm.CurrentUser.UserId, code);
                MessageBox.Show("修改密码成功");
            }
        }

        private void gcVritualGroupManegement_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button_Delete_Click(object sender, EventArgs e)
        {
            try
            {
                if (XtraMessageBox.Show("确实要删除摄像头?", "提醒", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
                {
                    int CameraID = Convert.ToInt32(gridViewToGDevice.GetFocusedRowCellValue("设备编号").ToString());
                    LongChang_CameraInfo ci = LongChang_CameraBusiness.Instance.GetCameraInfoByCameraId(ref errMessage, CameraID);
                    String cnt = ci.ToString();
                    LongChang_CameraBusiness.Instance.Delete(ref errMessage, CameraID);
                    OperateLogBusiness.Instance.Insert(ref errMessage,
                                                       new OperateLog
                                                       {
                                                           ClientUserId = MainForm.CurrentUser.UserId,
                                                           ClientUserName = MainForm.CurrentUser.UserName,
                                                           Content = ci.ToString(),
                                                           HappenTime = DateTime.Now,
                                                           OperateTypeId = (int)(OperateLogTypeId.ToGDeviceDelete),
                                                           OperateTypeName = OperateLogTypeName.ToGDeviceDelete,
                                                           OperateUserName = MainForm.CurrentUser.UserName
                                                       });
                    
                }
                showLongChangCameraInfo();
            }
            catch (Exception ex)
            {
                return;
            }

        }

        private void TollGate_Delete_Click(object sender, EventArgs e)
        {
            try
            {
                if (XtraMessageBox.Show("确实要删除卡口?", "提醒", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
                {
                    string TollID = gridView_TollGate.GetFocusedRowCellValue("卡口编号").ToString();
                    LongChang_TollGateInfo ki = LongChang_TollGateBusiness.Instance.GetTollGateInfoByKaKouID(ref errMessage, TollID);
                    String cnt = ki.ToString();
                    LongChang_TollGateBusiness.Instance.Delete(ref errMessage, TollID);
                    OperateLogBusiness.Instance.Insert(ref errMessage,
                                                       new OperateLog
                                                       {
                                                           ClientUserId = MainForm.CurrentUser.UserId,
                                                           ClientUserName = MainForm.CurrentUser.UserName,
                                                           Content = ki.ToString(),
                                                           HappenTime = DateTime.Now,
                                                           OperateTypeId = (int)(OperateLogTypeId.ToGDeviceDelete),
                                                           OperateTypeName = OperateLogTypeName.ToGDeviceDelete,
                                                           OperateUserName = MainForm.CurrentUser.UserName
                                                       });
                    
                }
                showLongChangTollGateInfo();

            }
            catch (Exception ex)
            {
                return;
            }
        }
        //修改组名
        private void barButtonItem10_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int Gid = int.Parse(treeListVirtualGroup.FocusedNode.Tag.ToString().Split(';')[0]);
            int err;
            ChangeVirtualGroup frmch=new ChangeVirtualGroup();
            frmch.Gid = Gid;
            frmch.ShowDialog(this);
            BuildVirtualGroupTree();
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
        DecoderManagement = 1024,
        RecognizerManagement = 2048,
        VirtualGroupManagement = 4096,
        SearchManagement = 8192,
        ToGDeviceManagement=3,
        TollGateManagement=5,
        CodeManagement=7
    }
}