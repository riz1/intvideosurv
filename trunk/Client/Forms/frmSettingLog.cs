using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using CameraViewer.Properties;
using IntVideoSurv.Entity;
using IntVideoSurv.Business;

namespace CameraViewer.Forms
{
    public partial class frmSetting
    {
        #region 日志管理

        private DateTime _logBeginDateTime;
        private DateTime _logEndDateTime;

        private void BuildCameraTreeInLogManagement()
        {
            //listGroup = GroupBusiness.Instance.GetAllGroupInfo(ref errMessage);
            Cursor currentCursor = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;
            TreeNode node;
            treeViewCameraInLogManagement.Nodes.Clear();
            foreach (KeyValuePair<int, GroupInfo> item in listGroup)
            {
                if (item.Value.ParentId == 0)
                {
                    node = new TreeNode(item.Value.Name);
                    node.Tag = item.Key + ";G";
                    AppendNode(node, item.Key);
                    treeViewCameraInLogManagement.Nodes.Add(node);

                }

            }
            treeViewCameraInLogManagement.ExpandAll();
            contextMenuStripGroupAndDevice.Visible = false;
            Cursor.Current = currentCursor;
        }

        private void buttonSearchLog_Click(object sender, EventArgs e)
        {
            if (comboBoxEditLogType.Text == "")
            {
                MessageBox.Show(Resources.frmSetting_buttonSearchLog_Click_日志类型不能为空_);
                return;
            }
            if (dateEditBeginDate.Text == "")
            {
                MessageBox.Show(Resources.frmSetting_buttonSearchLog_Click_起始时间不能为空_);
                return;
            }

            if (dateEditEndDate.Text == "")
            {
                MessageBox.Show(Resources.frmSetting_buttonSearchLog_Click_结束时间不能为空_);
                return;
            }

            _logBeginDateTime = dateEditBeginDate.DateTime;
            _logEndDateTime = dateEditEndDate.DateTime;
            LoadLog();

        }

        void LoadLog()
        {

            MakeFileter();
            switch (_logType)
            {
                case LogType.System:
                    //dataGridViewLog.DataSource = SystemLogBusiness.Instance.GetSystemLogDataSet(ref errMessage, filters);
                    //dataGridViewLog.Columns[dataGridViewLog.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    ////设置日期时间栏的宽度和数据格式
                    //dataGridViewLog.Columns[1].Width = 160;
                    //dataGridViewLog.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    //dataGridViewLog.Columns[0].Visible = false;
                    //dataGridViewLog.Columns[1].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss ";

                    ShowDataInGridView(dataGridViewLog, SystemLogBusiness.Instance.GetSystemLogDataSet(ref errMessage, filters));

                    break;
                case LogType.Operate:
                    //dataGridViewLog.DataSource = OperateLogBusiness.Instance.GetOperateLogDataSet(ref errMessage, filters);
                    //dataGridViewLog.Columns[dataGridViewLog.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    ////设置日期时间栏的宽度和数据格式
                    //dataGridViewLog.Columns[4].Width = 160;
                    //dataGridViewLog.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    //dataGridViewLog.Columns[0].Visible = false;
                    //dataGridViewLog.Columns[4].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss ";
                    ShowDataInGridView(dataGridViewLog, OperateLogBusiness.Instance.GetOperateLogDataSet(ref errMessage, filters));
                    break;
                default:
                    break;
            }

        }

        private string filters = "";
        private void MakeFileter()
        {
            filters = " where ";
            filters += string.Format("happentime>=#{0}# and happentime<=#{1}# ", _logBeginDateTime, _logEndDateTime);


            //根据用户选择系统日志
            if ((_isLogByUser) && (_logType == LogType.System))
            {

                //子类型
                if (_subLogType != "")
                {
                    filters += string.Format(" and systemtypename=\'{0}\' ", comboBoxEditSubLogType.Text);
                }
                if (_lastSelectedTreeNodeInLog==null)
                {
                    return;
                }
                string strTag = _lastSelectedTreeNodeInLog.Tag.ToString();
                string[] tags = strTag.Split(';');
                int userId = int.Parse(tags[0]);
                if (strTag.IndexOf("U") >=0)
                {
                    filters += string.Format(" and clientuserid={0} ", userId);

                }

            }
            //根据用户选择操作日志
            if ((_isLogByUser) && (_logType == LogType.Operate))
            {


                //子类型
                if (_subLogType != "")
                {
                    filters += string.Format(" and operatetypename=\'{0}\' ", comboBoxEditSubLogType.Text);
                }

                if (_lastSelectedTreeNodeInLog == null)
                {
                    return;
                }
                string strTag = _lastSelectedTreeNodeInLog.Tag.ToString();
                string[] tags = strTag.Split(';');
                int userId = int.Parse(tags[0]);
                if (strTag.IndexOf("U") >= 0)
                {
                    filters += string.Format(" and clientuserid={0} ", userId);

                }
            }
            //根据设备选择操作日志
            else if ((_isLogByUser == false) && (_logType == LogType.Operate))
            {
                //子类型
                if (_subLogType != "")
                {
                    filters += string.Format(" and operatetypename=\'{0}\' ", comboBoxEditSubLogType.Text);
                }

                if (_lastSelectedTreeNodeInLog == null)
                {
                    return;
                }
                alGroupid.Clear();
                alDeviceid.Clear();
                alCameraid.Clear();
                GetGroupDeveiceCamera(_lastSelectedTreeNodeInLog);
                if (alGroupid.Count > 0 || alDeviceid.Count > 0 || alCameraid.Count > 0)
                {
                    filters += string.Format(" and (");
                    bool isExistedGroupDevice = false;
                    //以集合方式获取GroupID
                    if (alGroupid.Count > 0)
                    {
                        filters += string.Format(" (OperateLog.Groupid in (");
                        foreach (int groupId in alGroupid)
                        {
                            filters += string.Format("{0},", groupId);
                        }
                        filters = filters.Substring(0, filters.Length - 1) + ")) ";
                        isExistedGroupDevice = true;
                    }

                    //以集合方式获取DeviceID
                    if (alDeviceid.Count > 0)
                    {
                        if (isExistedGroupDevice)
                        {
                            filters += " OR ";
                        }
                        filters += string.Format(" (OperateLog.Deviceid in (");

                        foreach (int deviceId in alDeviceid)
                        {
                            filters += string.Format("{0},", deviceId);
                        }

                        filters = filters.Substring(0, filters.Length - 1) + ")) ";
                        isExistedGroupDevice = true;
                    }
                    //以集合方式获取CameraID
                    if (alCameraid.Count > 0)
                    {
                        if (isExistedGroupDevice)
                        {
                            filters += " OR ";
                        }
                        filters += string.Format(" (OperateLog.Cameraid in (");

                        foreach (int cameraId in alCameraid)
                        {
                            filters += string.Format("{0},", cameraId);
                        }

                        filters = filters.Substring(0, filters.Length - 1) + ")) ";
                    }

                    filters += string.Format(" ) ");
                }

            }
            //根据设备选择操作日志
            else if ((_isLogByUser == false) && (_logType == LogType.System))
            {
                filters = " where ";
                filters += string.Format("happentime>=#9999-12-31#");

            }


        }
        private LogType _logType = LogType.System;
        private enum LogType{System,Operate}
        private string _subLogType = "";
        private void comboBoxEditLogType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ArrayList alLogTypes = new ArrayList();
            switch (comboBoxEditLogType.Text)
            {
                case "系统日志":
                    _logType = LogType.System;
                    alLogTypes = SystemLogBusiness.Instance.GetSystemLogTypes(ref errMessage);
                    break;
                case "操作日志":
                    _logType = LogType.Operate;
                    alLogTypes = OperateLogBusiness.Instance.GetOperateLogTypes(ref errMessage);
                    break;
                default:
                    break;
            }
            AddLogTypes(alLogTypes);
        }

        private void AddLogTypes(ArrayList alLogTypes)
        {
            comboBoxEditSubLogType.Text = "";
            comboBoxEditSubLogType.Properties.Items.Clear();
            foreach (string item in alLogTypes)
            {
                comboBoxEditSubLogType.Properties.Items.Add(item);
            }
        }

        private void comboBoxEditSubLogType_SelectedIndexChanged(object sender, EventArgs e)
        {
            _subLogType = comboBoxEditSubLogType.Text;
        }

        private bool _isLogByUser = false;

        private void checkBoxUser_CheckedChanged(object sender, EventArgs e)
        {
            _lastSelectedTreeNodeInLog = null;
            _isLogByUser = checkBoxUser.Checked;
            if (_isLogByUser)
            {
                BuildUserTree();
            }
            else
            {
                BuildCameraTreeInLogManagement();
            }

        }

        private void BuildUserTree()
        {
            Dictionary<int, UserInfo> listUsers = UserBusiness.Instance.GetAllUserInfo(ref errMessage);
            Cursor currentCursor = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;
            TreeNode node;
            treeViewCameraInLogManagement.Nodes.Clear();
            node = new TreeNode("所有用户");
            node.Tag = 0 + ";T";
            treeViewCameraInLogManagement.Nodes.Add(node);

            foreach (KeyValuePair<int, UserInfo> item in listUsers)
            {
                node = new TreeNode(item.Value.UserName);
                node.Tag = item.Key.ToString() + ";U";
                treeViewCameraInLogManagement.Nodes[0].Nodes.Add(node);

            }
            treeViewCameraInLogManagement.ExpandAll();
            contextMenuStripGroupAndDevice.Visible = false;
            Cursor.Current = currentCursor;
        }
        TreeNode _lastSelectedTreeNodeInLog = null;

        private void treeViewCameraInLogManagement_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (_lastSelectedTreeNodeInLog != null)
            {
                _lastSelectedTreeNodeInLog.BackColor = _treeNodeDefaultColor;
            }
            _lastSelectedTreeNodeInLog = treeViewCameraInLogManagement.SelectedNode;
        }

        private void treeViewCameraInLogManagement_Leave(object sender, EventArgs e)
        {
            _lastSelectedTreeNodeInLog.BackColor = Color.Gray;
        }

        ArrayList alGroupid = new ArrayList();
        ArrayList alDeviceid = new ArrayList();
        ArrayList alCameraid = new ArrayList();

        private void GetGroupDeveiceCamera(TreeNode tnParent)
        {

            if (tnParent == null) return;
            if (int.Parse(tnParent.Tag.ToString().Split(';')[0])==1)
            {
                return;
            }

            if (tnParent.Tag.ToString().IndexOf("G") > 0)
            {
                string[] str = tnParent.Tag.ToString().Split(';');
                alGroupid.Add(int.Parse(str[0]));
            }
            else if (tnParent.Tag.ToString().IndexOf("D") > 0)
            {
                string[] str = tnParent.Tag.ToString().Split(';');
                alDeviceid.Add(int.Parse(str[0]));
            }
            else if (tnParent.Tag.ToString().IndexOf("C") > 0)
            {
                string[] str = tnParent.Tag.ToString().Split(';');
                alCameraid.Add(int.Parse(str[0]));
            }

            foreach (TreeNode tn in tnParent.Nodes)
            {
                GetGroupDeveiceCamera(tn);
            }
        }

        private void splitContainerControl4_Resize(object sender, EventArgs e)
        {
            splitContainerControl4.SplitterPosition = splitContainerControl4.Height - 30;
        }

        #endregion
    }
}
