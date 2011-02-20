using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using IntVideoSurv.Entity;
using IntVideoSurv.Business;

namespace CameraViewer.Forms
{
    public partial class frmSetting : DevExpress.XtraEditors.XtraForm
    {
        #region 同步群组管理

        TreeNode selectedTreeNode = null;
        private void BuildSynGroupTree()
        {
            _listSynGroup = SynGroupBusiness.Instance.GetAllSynGroups(ref errMessage);
            Cursor currentCursor = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;
            TreeNode node;
            treeViewSynGroup.Nodes.Clear();

            foreach (KeyValuePair<int, SynGroup> item in _listSynGroup)
            {
                node = new TreeNode(item.Value.Name);
                node.Tag = item.Key.ToString() + ";S";
                if (_lastSelectedTreeNode != null)
                {
                    if (_lastSelectedTreeNode.Tag.ToString() == node.Tag.ToString())
                    {
                        node.BackColor = Color.Gray;
                        selectedTreeNode = node;
                    }
                }
                AppendSynGroupNode(node);
                treeViewSynGroup.Nodes.Add(node);

            }
            contextMenuStripSynGroup.Visible = false;

            treeViewSynGroup.ExpandAll();
            if (selectedTreeNode != null)
            {
                treeViewSynGroup.SelectedNode = selectedTreeNode;
            }
            Cursor.Current = currentCursor;
        }

        private void BuildCameraTreeInSynGroupManagement()
        {
            //listGroup = GroupBusiness.Instance.GetAllGroupInfo(ref errMessage);
            Cursor currentCursor = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;
            TreeNode node;
            treeViewSynGroupCamera.Nodes.Clear();
            foreach (KeyValuePair<int, GroupInfo> item in listGroup)
            {
                if (item.Value.ParentId == 0)
                {
                    node = new TreeNode(item.Value.Name);
                    node.Tag = item.Key.ToString() + ";G";
                    AppendNode(node, item.Key);
                    treeViewSynGroupCamera.Nodes.Add(node);

                }

            }
            treeViewSynGroupCamera.ExpandAll();
            contextMenuStripGroupAndDevice.Visible = false;
            Cursor.Current = currentCursor;
        }

        private void AppendSynGroupNode(TreeNode aNode)
        {
            string[] str = aNode.Tag.ToString().Split(';');
            int key = int.Parse(str[0]);
            SynGroup synGroup = _listSynGroup[key];
            if (synGroup.ListCameraMonitorPair == null)
            {
                return;
            }
            foreach (KeyValuePair<int, CameraMonitorPairInfo> camPair in synGroup.ListCameraMonitorPair)
            {
                var node = new TreeNode(camPair.Value.DeviceName + "_" + camPair.Value.Name + "_" + camPair.Value.DisplayChannelName);
                node.Tag = camPair.Key.ToString() + ";P;" + key.ToString() + ";G;" + camPair.Value.CameraId.ToString() + ";C;" + camPair.Value.DisplayChannelId + ";M";
                if (_lastSelectedTreeNode != null)
                {
                    if (_lastSelectedTreeNode.Tag.ToString() == node.Tag.ToString())
                    {
                        node.BackColor = Color.Gray;
                        selectedTreeNode = node;
                        //treeViewSynGroup.SelectedNode = node;
                    }
                }
                aNode.Nodes.Add(node);

            }
        }

        private TreeNode _lastSelectedTreeNode = null;
        private Color _treeNodeDefaultColor;
        private bool _isTreeNodeClicked = false;


        private void treeViewSynGroup_Click(object sender, EventArgs e)
        {

        }

        private void treeViewSynGroup_Leave(object sender, EventArgs e)
        {
            if (_isTreeNodeClicked)
            {
                _lastSelectedTreeNode.BackColor = Color.Gray;
            }
        }

        private void treeViewSynGroup_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (!_isTreeNodeClicked)
            {
                _treeNodeDefaultColor = treeViewSynGroup.SelectedNode.BackColor;
                _isTreeNodeClicked = true;
            }
            if (_lastSelectedTreeNode != null)
            {
                _lastSelectedTreeNode.BackColor = _treeNodeDefaultColor;
            }

            _lastSelectedTreeNode = treeViewSynGroup.SelectedNode;

            //显示当前选中的节点的细节
            DisplaySynGroupDetail();
        }

        private void DisplaySynGroupDetail()
        {

            dgvSynGroupDetail.Rows.Clear();
            lblGroupName.Text = "";
            if (_lastSelectedTreeNode==null)
            {
                return;
            }
            string str = _lastSelectedTreeNode.Tag.ToString();
            if (str.IndexOf("S")>=0)
            {
                string[] strs = str.Split(';');
                int key = int.Parse(strs[0]);
                SynGroup synGroup = _listSynGroup[key];
                lblGroupName.Text =  synGroup.Name;
                foreach (KeyValuePair<int, CameraMonitorPairInfo> camPair in synGroup.ListCameraMonitorPair)
                {
                    int index = dgvSynGroupDetail.Rows.Add();
                    DataGridViewRow dgvr = dgvSynGroupDetail.Rows[index];
                    dgvr.Cells["Device"].Value = camPair.Value.DeviceName;
                    dgvr.Cells["Camera"].Value = camPair.Value.Name;
                    dgvr.Cells["Monitor"].Value = camPair.Value.DisplayChannelName;
                    dgvr.Cells["SplitScreen"].Value = camPair.Value.DisplaySplitScreenNo+1;
                }
            }
            else if(str.IndexOf("P")>=0)
            {
                string[] strs = str.Split(';');
                int synId = int.Parse(strs[2]);
                SynGroup synGroup = _listSynGroup[synId];
                lblGroupName.Text = synGroup.Name;
                int camPairId=int.Parse(strs[0]);
                CameraMonitorPairInfo cameraMonitorPairInfo = synGroup.ListCameraMonitorPair[camPairId];
                int index = dgvSynGroupDetail.Rows.Add();
                DataGridViewRow dgvr = dgvSynGroupDetail.Rows[index];
                dgvr.Cells["Device"].Value = cameraMonitorPairInfo.DeviceName;
                dgvr.Cells["Camera"].Value = cameraMonitorPairInfo.Name;
                dgvr.Cells["Monitor"].Value = cameraMonitorPairInfo.DisplayChannelName;
                dgvr.Cells["SplitScreen"].Value = cameraMonitorPairInfo.DisplaySplitScreenNo+1;
            }
        }

        private void buttonAddSynGroup_Click(object sender, EventArgs e)
        {
            if (treeViewSynGroupCamera.SelectedNode == null)
            {
                return;
            }
            if (treeViewSynGroup.SelectedNode == null)
            {
                return;
            }
            if (treeViewMonitor.SelectedNode == null)
            {
                return;
            }
            if (cbDisplayScreenNo.Text=="")
            {
                MessageBox.Show("请正确选择输出通道!");
                return;
            }
            alCameras.Clear();
            getCameras(treeViewSynGroupCamera.SelectedNode);
            int synGroupToAdd = getSynGroupId(treeViewSynGroup.SelectedNode);
            alDisplayChannels.Clear();
            getDisplayChannels(treeViewMonitor.SelectedNode);
            int splitScreenNo = int.Parse(cbDisplayScreenNo.Text) - 1;
            foreach (int camid in alCameras)
            {
                foreach (int dc in alDisplayChannels)
                {
                    int addId = addCamera2SynGroup(synGroupToAdd, camid, dc, splitScreenNo);
                    if (addId == -1)
                    {

                        CameraInfo ci = CameraBusiness.Instance.GetCameraInfoByCameraId(ref errMessage, camid);
                        SynGroup sg = SynGroupBusiness.Instance.GetSynGroupBySynGroupId(ref errMessage, synGroupToAdd);
                        DisplayChannelInfo mi = DisplayChannelBusiness.Instance.GetDisplayChannelInfoById(ref errMessage, dc);
                        MessageBox.Show(ci.DeviceName + "_" + ci.Name + "_" + mi.DisplayChannelName + " 在 " + sg.Name + " 组中已存在!");
                    }                    
                }

            }
            BuildSynGroupTree();
            DisplaySynGroupDetail();
        }
        private void buttonDeleteSynGroup_Click(object sender, EventArgs e)
        {
            if (treeViewSynGroup.SelectedNode == null)
            {
                return;
            }
            string selectTagStr = treeViewSynGroup.SelectedNode.Tag.ToString();

            if (selectTagStr.IndexOf("S") > 0)
            {

                if (treeViewSynGroup.SelectedNode.FirstNode != null)
                {
                    XtraMessageBox.Show("同步群组非空，不能直接删除!");
                }
                else
                {
                    string[] strs = selectTagStr.Split(';');
                    int synGroupId = int.Parse(strs[0]);
                    _lastSelectedTreeNode = treeViewSynGroup.SelectedNode.PrevNode;
                    SynGroupBusiness.Instance.Delete(ref errMessage, synGroupId);
                }
            }
            else if (selectTagStr.IndexOf("C") > 0)
            {
                string[] tagStrs = selectTagStr.Split(';');
                int synGroupCameraId = int.Parse(tagStrs[0]);
                int synGroupId = int.Parse(tagStrs[2]);
                int cameraId = int.Parse(tagStrs[4]);
                int monitorId = int.Parse(tagStrs[6]);

                string parentTagStr = treeViewSynGroup.SelectedNode.Parent.Tag.ToString();
                string[] parentTags = parentTagStr.Split(';');
                int parentTagId = int.Parse(parentTags[0]);


                deleteCamera2SynGroup(synGroupCameraId);

                if (treeViewSynGroup.SelectedNode.PrevNode == null)
                {
                    _lastSelectedTreeNode = treeViewSynGroup.SelectedNode.Parent;
                }
                else
                {
                    _lastSelectedTreeNode = treeViewSynGroup.SelectedNode.PrevNode;
                }
            }

            BuildSynGroupTree();
            DisplaySynGroupDetail();

        }

        private int addCamera2SynGroup(int synGroupId, int cameraId)
        {

            return SynGroupBusiness.Instance.InsertSynGroupCamera(ref errMessage, synGroupId, cameraId);
        }

        private int addCamera2SynGroup(int synGroupId, int cameraId, int monitorId)
        {

            return SynGroupBusiness.Instance.InsertSynGroupCamera(ref errMessage, synGroupId, cameraId, monitorId);
        }

        private int addCamera2SynGroup(int synGroupId, int cameraId, int monitorId, int splitScreenNo)
        {

            return SynGroupBusiness.Instance.InsertSynGroupCamera(ref errMessage, synGroupId, cameraId, monitorId, splitScreenNo);
        }

        private void deleteCamera2SynGroup(int synGroupId, int cameraId)
        {

            SynGroupBusiness.Instance.DeleteSynGroupCamera(ref errMessage, synGroupId, cameraId);
        }
        private void deleteCamera2SynGroup(int synGroupId, int cameraId, int monitorId)
        {

            SynGroupBusiness.Instance.DeleteSynGroupCamera(ref errMessage, synGroupId, cameraId, monitorId);
        }

        private void deleteCamera2SynGroup( int synGroupCameraId)
        {

            SynGroupBusiness.Instance.DeleteSynGroupCamera(ref errMessage, synGroupCameraId);
        }

        private ArrayList alCameras = new ArrayList();


        private void getCameras(TreeNode tnParent)
        {

            if (tnParent == null) return;

            if (tnParent.Tag.ToString().IndexOf("C") > 0)
            {
                string[] str = tnParent.Tag.ToString().Split(';');
                alCameras.Add(int.Parse(str[0]));
            }


            foreach (TreeNode tn in tnParent.Nodes)
            {
                getCameras(tn);
            }
        }


        private int getSynGroupId(TreeNode tn)
        {
            int synGroupId = -1;
            string tagStr = tn.Tag.ToString();
            string[] tags = tagStr.Split(';');
            if (tagStr.IndexOf("S") > 0)
            {
                synGroupId = int.Parse(tags[0]);
            }
            else if (tagStr.IndexOf("C") > 0)
            {
                tagStr = tn.Parent.Tag.ToString();
                tags = tagStr.Split(';');
                synGroupId = int.Parse(tags[0]);
            }

            return synGroupId;
        }
        private ArrayList alDisplayChannels = new ArrayList();
        private void getDisplayChannels(TreeNode tn)
        {
            int monitorId = -1;
            string tagStr = tn.Tag.ToString();
            string[] tags = tagStr.Split(';');
            if (tagStr.IndexOf("C") > 0)
            {
                alDisplayChannels.Add(int.Parse(tags[0]));
            }
            else if(tagStr.IndexOf("T") > 0)
            {
                foreach (TreeNode tnChannel in tn.Nodes)
                {
                    tagStr = tnChannel.Tag.ToString();
                    tags = tagStr.Split(';');
                    if (tagStr.IndexOf('C') >= 0)
                    {
                        alDisplayChannels.Add(int.Parse(tags[0]));
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            treeViewSynGroup.SelectedNode = treeViewSynGroup.Nodes[1].FirstNode;
        }

        private void nbLog_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            _displaytype = DisplayTypes.LogManagement;
            DisplayRightPanel();
        }

        private void splitContainerControl2_Resize(object sender, EventArgs e)
        {
            //buttonAddSynGroup.Left = treeViewSynGroupCamera.Width + (gcSynGroupManagement.Width - treeViewSynGroupCamera.Width - treeViewSynGroup.Width -
            //                          buttonAddSynGroup.Width) / 2;

            //buttonDeleteSynGroup.Left = treeViewSynGroupCamera.Width + (gcSynGroupManagement.Width - treeViewSynGroupCamera.Width - treeViewSynGroup.Width -
            //              buttonDeleteSynGroup.Width) / 2;
            //const int spaceBetween2Buttons = 50;
            //buttonAddSynGroup.Top = (gcSynGroupManagement.Height - buttonAddSynGroup.Height -
            //                         buttonAddSynGroup.Height - spaceBetween2Buttons) / 2;
            //buttonDeleteSynGroup.Top = buttonAddSynGroup.Top + spaceBetween2Buttons;
            pcSynGroupDisplay.Left = treeViewSynGroupCamera.Width + (gcSynGroupManagement.Width - treeViewSynGroupCamera.Width - treeViewSynGroup.Width -
                                      pcSynGroupDisplay.Width) / 2;
            pcSynGroupDisplay.Top = (gcSynGroupManagement.Height - pcSynGroupDisplay.Height) / 2;

        }

        private void nbSynGroup_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            BuildSynGroupTree();
            treeViewSynGroup.ExpandAll();
            _displaytype = DisplayTypes.SynGroupManagement;
            DisplayRightPanel();
            //splitContainerDeviceAndMonitor.Panel1.Controls.Add(treeViewSynGroupCamera);
            gcDevice.Controls.Add(treeViewSynGroupCamera);
        }

        private void ToolStripMenuItemAddSynGroup_Click(object sender, EventArgs e)
        {
            frmSynGroup group = new frmSynGroup();
            group.Opt = Util.Operateion.Add;
            group.ShowDialog(this);
            BuildSynGroupTree();
        }

        private void ToolStripMenuItemDeleteSynGroup_Click(object sender, EventArgs e)
        {
            if (treeViewSynGroup.SelectedNode.Nodes.Count != 0)
            {
                MessageBox.Show("要删除的节点的子节点必须为空!");
                return;
            }
            string nodeText = treeViewSynGroup.SelectedNode.Tag.ToString();
            string[] nodes = nodeText.Split(';');
            SynGroup sg = SynGroupBusiness.Instance.GetSynGroupBySynGroupId(ref errMessage, int.Parse(nodes[0]));
            if (sg!=null)
            {
                SynGroupBusiness.Instance.Delete(ref errMessage, int.Parse(nodes[0]));
                OperateLogBusiness.Instance.Insert(ref errMessage,
                       new OperateLog
                           {
                               HappenTime = DateTime.Now,
                               ClientUserId = MainForm.CurrentUser.UserId,
                               ClientUserName = MainForm.CurrentUser.UserName,
                               Content = sg.ToString(),
                               OperateTypeId = (int) OperateLogTypeId.SynGroupDelete,
                               OperateTypeName = OperateLogTypeName.SynGroupDelete,
                               OperateUserName = MainForm.CurrentUser.UserName
                           });            
            }

        }

        #endregion

    }
}
