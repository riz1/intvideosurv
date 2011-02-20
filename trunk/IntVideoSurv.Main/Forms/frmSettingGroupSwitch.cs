using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using IntVideoSurv.Entity;
using IntVideoSurv.Business;

namespace CameraViewer.Forms
{
    public partial class frmSetting
    {

        #region 群组切换

        private Dictionary<int, GroupSwitchGroup> _listGroupSwitchGroup = new Dictionary<int, GroupSwitchGroup>();

        private void LoadGroupSwitch()
        {
            Trace.WriteLine("1:" + DateTime.Now.ToString("yyyy-MM-dd   HH:mm:ss   fff "));
            _listGroupSwitchGroup = GroupSwitchGroupBusiness.Instance.GetAllGroupSwitchGroups(ref errMessage);
            Trace.WriteLine("2:" + DateTime.Now.ToString("yyyy-MM-dd   HH:mm:ss   fff "));
            _listSynGroup = SynGroupBusiness.Instance.GetAllSynGroups(ref errMessage);

            Cursor currentCursor = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;
            TreeNode node;
            tvSynGroupTop.Nodes.Clear();
            tvGroupSwitchGroup.Nodes.Clear();
            Trace.WriteLine("3:" + DateTime.Now.ToString("yyyy-MM-dd   HH:mm:ss   fff "));
            foreach (var variable in _listSynGroup)
            {
                node = new TreeNode(variable.Value.Name);
                node.Tag = variable.Key + ";S";
                tvSynGroupTop.Nodes.Add(node);
            }
            Trace.WriteLine("4:" + DateTime.Now.ToString("yyyy-MM-dd   HH:mm:ss   fff "));
            foreach (var variable in _listGroupSwitchGroup)
            {
                node = new TreeNode(variable.Value.Name);
                node.Tag = variable.Key + ";G";
                AppendGroupSwitchNode(node);
                tvGroupSwitchGroup.Nodes.Add(node);
            }
            Trace.WriteLine("5:" + DateTime.Now.ToString("yyyy-MM-dd   HH:mm:ss   fff "));
            tvSynGroupTop.ExpandAll();
            tvGroupSwitchGroup.ExpandAll();
            Cursor.Current = currentCursor;
            DisplayGroupSwitchDetail();

        }

        private void AppendGroupSwitchNode(TreeNode aNode)
        {
            string[] str = aNode.Tag.ToString().Split(';');
            int key = int.Parse(str[0]);
            GroupSwitchGroup groupSwitchGroup = _listGroupSwitchGroup[key];
            if (groupSwitchGroup.ListGroupSwitchDetailInfo == null)
            {
                return;
            }
            foreach (KeyValuePair<int, GroupSwitchDetailInfo> keyValuePair in groupSwitchGroup.ListGroupSwitchDetailInfo)
            {
                var node = new TreeNode(keyValuePair.Value.SynGroupName + "_" + keyValuePair.Value.TickTime);
                //G-群组切换群组ID
                //S-同步群组ID
                //D-Detail ID
                //T-TickYime
                node.Tag = keyValuePair.Key + ";D;" + key + ";G;" + keyValuePair.Value.SynGroupId + ";S;" + keyValuePair.Value.TickTime + ";T";
                if (_lastSelectedGroupSwitchGroupTreeNode != null)
                {
                    if (_lastSelectedGroupSwitchGroupTreeNode.Tag.ToString() == node.Tag.ToString())
                    {
                        node.BackColor = Color.Gray;
                        _lastSelectedGroupSwitchGroupTreeNode = node;
                    }
                }
                aNode.Nodes.Add(node);

            }
        }

        private void navBarItemGroupSwitch_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            _displaytype = DisplayTypes.GroupSwitchManagement;
            DisplayRightPanel();
            LoadGroupSwitch();
        }


        private bool _isTreeNodeClickedInGroupSwitchGroup = false;
        private TreeNode _lastSelectedGroupSwitchGroupTreeNode = null;

        private bool _isTreeNodeClickedInSynGroupTop = false;
        private TreeNode _lastSelectedSynGroupTop = null;

        private void tvGroupSwitchGroup_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (!_isTreeNodeClickedInGroupSwitchGroup)
            {
                _isTreeNodeClickedInGroupSwitchGroup = true;
            }

            if (_lastSelectedGroupSwitchGroupTreeNode != null)
            {
                _lastSelectedGroupSwitchGroupTreeNode.BackColor = _treeNodeDefaultColor;
            }

            _lastSelectedGroupSwitchGroupTreeNode = tvGroupSwitchGroup.SelectedNode;
            DisplayGroupSwitchDetail();
        }
        private void DisplayGroupSwitchDetail()
        {

            dgvGroupSwitchDetail.Rows.Clear();
            lblGroupSwitchName.Text = "";
            if (_lastSelectedGroupSwitchGroupTreeNode == null)
            {
                return;
            }
            string str = _lastSelectedGroupSwitchGroupTreeNode.Tag.ToString();
            if (str.IndexOf("D") < 0)
            {
                string[] strs = str.Split(';');
                int gsID = int.Parse(strs[0]);
                GroupSwitchGroup groupSwitchGroup = _listGroupSwitchGroup[gsID];
                lblGroupSwitchName.Text = groupSwitchGroup.Name;
                foreach (KeyValuePair<int,GroupSwitchDetailInfo> keyValuePair in groupSwitchGroup.ListGroupSwitchDetailInfo)
                {
                    int index = dgvGroupSwitchDetail.Rows.Add();
                    DataGridViewRow dgvr = dgvGroupSwitchDetail.Rows[index];
                    dgvr.Cells["SynGroup"].Value = keyValuePair.Value.SynGroupName;
                    dgvr.Cells["Tick"].Value = keyValuePair.Value.TickTime;
                    dgvr.Cells["Id"].Value = keyValuePair.Key;
                }
            }
            else if (str.IndexOf("D") >= 0)
            {
                string[] strs = str.Split(';');
                int gsID = int.Parse(strs[2]);
                GroupSwitchGroup groupSwitchGroup = _listGroupSwitchGroup[gsID];
                lblGroupSwitchName.Text = groupSwitchGroup.Name;
                int detailId = int.Parse(strs[0]);
                GroupSwitchDetailInfo groupSwitchDetailInfo = groupSwitchGroup.ListGroupSwitchDetailInfo[detailId];
                int index = dgvGroupSwitchDetail.Rows.Add();
                DataGridViewRow dgvr = dgvGroupSwitchDetail.Rows[index];
                dgvr.Cells["SynGroup"].Value = groupSwitchDetailInfo.SynGroupName;
                dgvr.Cells["Tick"].Value = groupSwitchDetailInfo.TickTime;
                dgvr.Cells["Id"].Value = groupSwitchDetailInfo.Id;

            }
        }


        private void tvGroupSwitchGroup_Leave(object sender, EventArgs e)
        {
            if (_isTreeNodeClickedInGroupSwitchGroup)
            {
                _lastSelectedGroupSwitchGroupTreeNode.BackColor = Color.Gray;
            }
        }

        private void tvSynGroupTop_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (!_isTreeNodeClickedInSynGroupTop)
            {
                _isTreeNodeClickedInSynGroupTop = true;
            }

            if (_lastSelectedSynGroupTop != null)
            {
                _lastSelectedSynGroupTop.BackColor = _treeNodeDefaultColor;
            }

            _lastSelectedSynGroupTop = tvSynGroupTop.SelectedNode;
        }

        private void tvSynGroupTop_Leave(object sender, EventArgs e)
        {
            if (_isTreeNodeClickedInSynGroupTop)
            {
                _lastSelectedSynGroupTop.BackColor = Color.Gray;
            }
        }


        private void gcGroupSwitchManagement_Resize(object sender, EventArgs e)
        {
            //btnAddGroupSwitchDetail.Left = tvSynGroupTop.Width + (gcGroupSwitchManagement.Width - tvSynGroupTop.Width - tvGroupSwitchGroup.Width -
            //              buttonAddSynGroup.Width) / 2;

            //btnDeleteGroupSwitchDetail.Left = btnAddGroupSwitchDetail.Left;

            //pcTickTime.Left = btnAddGroupSwitchDetail.Left - 26;

            //const int spaceBetween2Buttons = 50;
            //btnAddGroupSwitchDetail.Top = (gcGroupSwitchManagement.Height - btnAddGroupSwitchDetail.Height -
            //                         btnDeleteGroupSwitchDetail.Height - spaceBetween2Buttons) / 2;
            //btnDeleteGroupSwitchDetail.Top = btnAddGroupSwitchDetail.Top + spaceBetween2Buttons;
            //pcTickTime.Top = btnAddGroupSwitchDetail.Top - spaceBetween2Buttons;

            pcGroupSwitchDisplay.Left = tvSynGroupTop.Width + (gcGroupSwitchManagement.Width - tvSynGroupTop.Width - tvGroupSwitchGroup.Width -
                          pcGroupSwitchDisplay.Width) / 2;
            pcGroupSwitchDisplay.Top = (gcGroupSwitchManagement.Height - pcGroupSwitchDisplay.Height) / 2;
        }

        private void btnAddGroupSwitchDetail_Click(object sender, EventArgs e)
        {
            int TickTime = 0;
            if (_lastSelectedGroupSwitchGroupTreeNode == null)
            {
                return;
            }
            if (_lastSelectedSynGroupTop == null)
            {
                return;
            }
            try
            {
                TickTime = int.Parse(teGroupSwitchTick.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("请填入正确的间隔时间!");
                return;
            }

            alCameras.Clear();
            getCameras(treeViewSynGroupCamera.SelectedNode);
            int synGroupToAdd = int.Parse(_lastSelectedSynGroupTop.Tag.ToString().Split(';')[0]);
            String str = _lastSelectedGroupSwitchGroupTreeNode.Tag.ToString();
            int groupSwitchGroupId = int.Parse(str.IndexOf("D") > 0 ? str.Split(';')[2] : str.Split(';')[0]);
            GroupSwitchDetailBusiness.Instance.InsertGroupSwitchDetailById(ref errMessage, groupSwitchGroupId,
                                                                           synGroupToAdd, TickTime);
            LoadGroupSwitch();
            
        }

        private void btnDeleteGroupSwitchDetail_Click(object sender, EventArgs e)
        {
            if (_lastSelectedGroupSwitchGroupTreeNode == null)
            {
                return;
            }
            string selectTagStr = _lastSelectedGroupSwitchGroupTreeNode.Tag.ToString();

            if (selectTagStr.IndexOf("D") < 0)
            {

                if (_lastSelectedGroupSwitchGroupTreeNode.FirstNode != null)
                {
                    XtraMessageBox.Show("群组切换非空，不能直接删除!");
                }
                else
                {
                    string[] strs = selectTagStr.Split(';');
                    int groupSwitchGroupId = int.Parse(strs[0]);
                    _lastSelectedGroupSwitchGroupTreeNode = tvGroupSwitchGroup.SelectedNode.PrevNode;

                    GroupSwitchGroup groupSwitchGroup = GroupSwitchGroupBusiness.Instance.GetGroupSwitchGroupById(ref errMessage,
                                                                                                    groupSwitchGroupId);
                    GroupSwitchGroupBusiness.Instance.Delete(ref errMessage, groupSwitchGroupId);

                    OperateLogBusiness.Instance.Insert(ref errMessage,
                                   new OperateLog
                                   {
                                       ClientUserId = MainForm.CurrentUser.UserId,
                                       ClientUserName = MainForm.CurrentUser.UserName,
                                       Content = groupSwitchGroup.ToString(),
                                       HappenTime = DateTime.Now,
                                       OperateTypeId = (int)(OperateLogTypeId.GroupSwitchDelete),
                                       OperateTypeName = OperateLogTypeName.GroupSwitchDelete,
                                       OperateUserName = MainForm.CurrentUser.UserName
                                   });
                }
            }
            else
            {
                string[] tagStrs = selectTagStr.Split(';');
                int detailId = int.Parse(tagStrs[0]);
                GroupSwitchDetailInfo groupSwitchDetailInfo =
                    GroupSwitchDetailBusiness.Instance.GetGroupSwitchDetailById(ref errMessage, detailId);

                GroupSwitchDetailBusiness.Instance.DeleteGroupSwitchDetailById(ref errMessage, detailId);

                OperateLogBusiness.Instance.Insert(ref errMessage,
                    new OperateLog
                    {
                        ClientUserId = MainForm.CurrentUser.UserId,
                        ClientUserName = MainForm.CurrentUser.UserName,
                        Content = groupSwitchDetailInfo.ToString(),
                        HappenTime = DateTime.Now,
                        OperateTypeId = (int)(OperateLogTypeId.GroupSwitchDetailDelete),
                        OperateTypeName = OperateLogTypeName.GroupSwitchDetailDelete,
                        OperateUserName = MainForm.CurrentUser.UserName
                    });

                _lastSelectedGroupSwitchGroupTreeNode = _lastSelectedGroupSwitchGroupTreeNode.PrevNode ??
                                                        _lastSelectedGroupSwitchGroupTreeNode.Parent;
            }

            LoadGroupSwitch();

        }



        private void 添加群组切换ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var groupSwitchGroup = new frmGroupSwitchGroup();
            groupSwitchGroup.Opt = Util.Operateion.Add;
            groupSwitchGroup.ShowDialog(this);
            LoadGroupSwitch();
        }

        #endregion
    }
}
