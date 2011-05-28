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
        #region 程序切换

        private void nbProgSwitch_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            _displaytype = DisplayTypes.ProSwitchManagement;
            DisplayRightPanel();
            gcDeviceInProSwitchManagement.Controls.Add(treeViewSynGroupCamera);
            LoadProgSwitch();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var groupSwitchGroup = new frmProgSwitchGroup();
            groupSwitchGroup.Opt = Util.Operateion.Add;
            groupSwitchGroup.ShowDialog(this);
            LoadProgSwitch();
        }

        private Dictionary<int, ProgSwitchInfo> _listProgSwitch = new Dictionary<int, ProgSwitchInfo>();

        private void LoadProgSwitch()
        {
            Trace.WriteLine("1:" + DateTime.Now.ToString("yyyy-MM-dd   HH:mm:ss   fff "));
            _listProgSwitch = ProgSwitchBusiness.Instance.GetAllProgSwitchs(ref errMessage);

            Cursor currentCursor = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;
            TreeNode node;
            tvProgSwitch.Nodes.Clear();
            Trace.WriteLine("2:" + DateTime.Now.ToString("yyyy-MM-dd   HH:mm:ss   fff "));
            foreach (var variable in _listProgSwitch)
            {
                node = new TreeNode(variable.Value.Name);
                node.Tag = variable.Key + ";P";
                AppendProgSwitchNode(node);
                tvProgSwitch.Nodes.Add(node);
            }
            Trace.WriteLine("3:" + DateTime.Now.ToString("yyyy-MM-dd   HH:mm:ss   fff "));
            tvProgSwitch.ExpandAll();
            Cursor.Current = currentCursor;
            DisplayProgSwitchDetail();

        }

        private void AppendProgSwitchNode(TreeNode aNode)
        {
            string[] str = aNode.Tag.ToString().Split(';');
            int key = int.Parse(str[0]);
            ProgSwitchInfo groupSwitchGroup = _listProgSwitch[key];
            if (groupSwitchGroup.ListProgSwitchDetailInfo == null)
            {
                return;
            }
            foreach (KeyValuePair<int, ProgSwitchDetailInfo> keyValuePair in groupSwitchGroup.ListProgSwitchDetailInfo)
            {
                var node = new TreeNode(keyValuePair.Value.DeviceName + "_" + keyValuePair.Value.CameraName + "_" + keyValuePair.Value.TickTime);
                //P-程序切换群组ID
                //C-摄像头ID
                //D-Detail ID
                //T-TickYime
                node.Tag = keyValuePair.Key + ";D;" + key + ";P;" + keyValuePair.Value.CameraId + ";C;" + keyValuePair.Value.TickTime + ";T";
                if (_lastSelectedProgSwitchTreeNode != null)
                {
                    if (_lastSelectedProgSwitchTreeNode.Tag.ToString() == node.Tag.ToString())
                    {
                        node.BackColor = Color.Gray;
                        _lastSelectedProgSwitchTreeNode = node;
                    }
                }
                aNode.Nodes.Add(node);

            }
        }

        private bool _isTreeNodeClickedInProgSwitchGroup = false;
        private TreeNode _lastSelectedProgSwitchTreeNode = null;

        private void tvProgSwitch_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (!_isTreeNodeClickedInProgSwitchGroup)
            {
                _isTreeNodeClickedInProgSwitchGroup = true;
            }

            if (_lastSelectedProgSwitchTreeNode != null)
            {
                _lastSelectedProgSwitchTreeNode.BackColor = _treeNodeDefaultColor;
            }

            _lastSelectedProgSwitchTreeNode = tvProgSwitch.SelectedNode;
            //显示被选节点详情
            DisplayProgSwitchDetail();
        }
        private void DisplayProgSwitchDetail()
        {

            dgvProgSwitchDetail.Rows.Clear();
            lblProgSwitchName.Text = "";
            if (_lastSelectedProgSwitchTreeNode == null)
            {
                return;
            }
            string str = _lastSelectedProgSwitchTreeNode.Tag.ToString();
            if (str.IndexOf("D") < 0)
            {
                string[] strs = str.Split(';');
                int psID = int.Parse(strs[0]);
                ProgSwitchInfo progSwitchInfo = _listProgSwitch[psID];
                lblProgSwitchName.Text = progSwitchInfo.Name;
                foreach (KeyValuePair<int, ProgSwitchDetailInfo> keyValuePair in progSwitchInfo.ListProgSwitchDetailInfo)
                {
                    int index = dgvProgSwitchDetail.Rows.Add();
                    DataGridViewRow dgvr = dgvProgSwitchDetail.Rows[index];
                    dgvr.Cells["ProgSwitchDevice"].Value = keyValuePair.Value.DeviceName;
                    dgvr.Cells["ProgSwitchCamera"].Value = keyValuePair.Value.CameraName;
                    dgvr.Cells["ProgSwitchMonitor"].Value =progSwitchInfo.DisplayChannelName;
                    dgvr.Cells["ProgSwitchTick"].Value = keyValuePair.Value.TickTime;
                    dgvr.Cells["ProgSwitchDetailId"].Value = keyValuePair.Key;
                    dgvr.Cells["ProgSwitchDisplaySplitScreenNo"].Value = progSwitchInfo.DisplaySplitScreenNo;

                }
            }
            else if (str.IndexOf("D") >= 0)
            {
                string[] strs = str.Split(';');
                int psID = int.Parse(strs[2]);
                ProgSwitchInfo progSwitchInfo = _listProgSwitch[psID];
                lblProgSwitchName.Text = progSwitchInfo.Name;
                int detailId = int.Parse(strs[0]);
                ProgSwitchDetailInfo progSwitchDetailInfo = progSwitchInfo.ListProgSwitchDetailInfo[detailId];
                int index = dgvProgSwitchDetail.Rows.Add();
                DataGridViewRow dgvr = dgvProgSwitchDetail.Rows[index];
                dgvr.Cells["ProgSwitchDevice"].Value = progSwitchDetailInfo.DeviceName;
                dgvr.Cells["ProgSwitchCamera"].Value = progSwitchDetailInfo.CameraName;
                dgvr.Cells["ProgSwitchMonitor"].Value = progSwitchInfo.DisplayChannelName;
                dgvr.Cells["ProgSwitchTick"].Value = progSwitchDetailInfo.TickTime;
                dgvr.Cells["ProgSwitchDetailId"].Value = progSwitchDetailInfo.ProgSwitchDetailId;
                dgvr.Cells["ProgSwitchDisplaySplitScreenNo"].Value = progSwitchInfo.DisplaySplitScreenNo;

            }
        }

        private void tvProgSwitch_Leave(object sender, EventArgs e)
        {
            if (_isTreeNodeClickedInProgSwitchGroup)
            {
                _lastSelectedProgSwitchTreeNode.BackColor = Color.Gray;
            }
        }

        private void gcProgSwitchManagement_Resize(object sender, EventArgs e)
        {
            //btnAddProgSwitchDetail.Left = gcDeviceInProSwitchManagement.Width + (gcProgSwitchManagement.Width - gcDeviceInProSwitchManagement.Width - groupControl5.Width -
            //  btnAddProgSwitchDetail.Width) / 2;

            //btnDeleteProgSwitchDetail.Left = btnAddProgSwitchDetail.Left;

            //pcTickTimeInProgSwitch.Left = btnAddProgSwitchDetail.Left - 26;

            //const int spaceBetween2Buttons = 50;
            //btnAddProgSwitchDetail.Top = (gcProgSwitchManagement.Height - btnAddProgSwitchDetail.Height -
            //                         btnDeleteProgSwitchDetail.Height - spaceBetween2Buttons) / 2;
            //btnDeleteProgSwitchDetail.Top = btnAddProgSwitchDetail.Top + spaceBetween2Buttons;
            //pcTickTimeInProgSwitch.Top = btnAddProgSwitchDetail.Top - spaceBetween2Buttons;

            pcProgSwitchDisplay.Left = gcDeviceInProSwitchManagement.Width + (gcProgSwitchManagement.Width - gcDeviceInProSwitchManagement.Width - groupControl5.Width -
              pcProgSwitchDisplay.Width) / 2;
            pcProgSwitchDisplay.Top = (gcProgSwitchManagement.Height - pcProgSwitchDisplay.Height) / 2;
        }

        private void btnAddProgSwitchDetail_Click(object sender, EventArgs e)
        {
            int TickTime = 0;
            if (_lastSelectedProgSwitchTreeNode == null)
            {
                return;
            }

            try
            {
                TickTime = int.Parse(teTickTimeInProgSwitch.Text);
            }
            catch (Exception)
            {
                XtraMessageBox.Show("请填入正确的间隔时间!");
                return;
            }

            alCameras.Clear();
            getCameras(treeViewSynGroupCamera.SelectedNode);
            String str = _lastSelectedProgSwitchTreeNode.Tag.ToString();
            int progSwitchId = int.Parse(str.IndexOf("D") > 0 ? str.Split(';')[2] : str.Split(';')[0]);
            foreach (int camId in alCameras)
            {
                ProgSwitchDetailBusiness.Instance.InsertProgSwitchDetailById(ref errMessage, progSwitchId, camId,
                                                                             TickTime);
            }
            LoadProgSwitch();
        }

        private void btnDeleteProgSwitchDetail_Click(object sender, EventArgs e)
        {
            if (_lastSelectedProgSwitchTreeNode == null)
            {
                return;
            }
            string selectTagStr = _lastSelectedProgSwitchTreeNode.Tag.ToString();

            if (selectTagStr.IndexOf("D") < 0)
            {

                if (_lastSelectedProgSwitchTreeNode.FirstNode != null)
                {
                    XtraMessageBox.Show("程序切换非空，不能直接删除!");
                }
                else
                {
                    string[] strs = selectTagStr.Split(';');
                    int progSwitchId = int.Parse(strs[0]);
                    _lastSelectedProgSwitchTreeNode = tvProgSwitch.SelectedNode.PrevNode;

                    ProgSwitchInfo progSwitchInfo = ProgSwitchBusiness.Instance.GetProgSwitchById(ref errMessage,
                                                                                                    progSwitchId);
                    ProgSwitchBusiness.Instance.Delete(ref errMessage, progSwitchId);

                    OperateLogBusiness.Instance.Insert(ref errMessage,
                                   new OperateLog
                                   {
                                       ClientUserId = MainForm.CurrentUser.UserId,
                                       ClientUserName = MainForm.CurrentUser.UserName,
                                       Content = progSwitchInfo.ToString(),
                                       HappenTime = DateTime.Now,
                                       OperateTypeId = (int)(OperateLogTypeId.ProgSwitchDelete),
                                       OperateTypeName = OperateLogTypeName.ProgSwitchDelete,
                                       OperateUserName = MainForm.CurrentUser.UserName
                                   });
                }
            }
            else
            {
                string[] tagStrs = selectTagStr.Split(';');
                int detailId = int.Parse(tagStrs[0]);
                ProgSwitchDetailInfo progSwitchDetailInfo =
                    ProgSwitchDetailBusiness.Instance.GetProgSwitchDetailByDetailId(ref errMessage, detailId);

                ProgSwitchDetailBusiness.Instance.DeleteProgSwitchDetailById(ref errMessage, detailId);

                OperateLogBusiness.Instance.Insert(ref errMessage,
                    new OperateLog
                    {
                        ClientUserId = MainForm.CurrentUser.UserId,
                        ClientUserName = MainForm.CurrentUser.UserName,
                        Content = progSwitchDetailInfo.ToString(),
                        HappenTime = DateTime.Now,
                        OperateTypeId = (int)(OperateLogTypeId.ProgSwitchGroupDelete),
                        OperateTypeName = OperateLogTypeName.ProgSwitchDetailDelete,
                        OperateUserName = MainForm.CurrentUser.UserName
                    });

                _lastSelectedProgSwitchTreeNode = _lastSelectedProgSwitchTreeNode.PrevNode ??
                                                        _lastSelectedProgSwitchTreeNode.Parent;
            }

            LoadProgSwitch();
        }


        #endregion

    }
}
