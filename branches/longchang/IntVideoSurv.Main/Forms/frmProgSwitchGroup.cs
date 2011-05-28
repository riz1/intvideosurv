using System;
using System.Collections.Generic;
using System.Windows.Forms;
using IntVideoSurv.Business;
using IntVideoSurv.Entity;

namespace CameraViewer.Forms
{
    public partial class frmProgSwitchGroup : DevExpress.XtraEditors.XtraForm
    {
        private string errMessage = "";
        public CameraViewer.Util.Operateion Opt
        {
            set;
            get;
        }
        public frmProgSwitchGroup()
        {
            InitializeComponent();
        }
        public int GroupId
        {
            set;
            get;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            ProgSwitchInfo progSwitchInfo = new ProgSwitchInfo();
            if (txtName.Text.Trim() == "" || comboBoxEditDisplayChannel.Text.Trim() == "" || comboBoxEditDisplaySplitScreenNo.Text.Trim() == "")
            {
                return;
            }
            progSwitchInfo.Name = txtName.Text;
            progSwitchInfo.Description =txtDescription.Text;
            progSwitchInfo.DisplayChannelId = _listMonitorByName[comboBoxEditDisplayChannel.Text].DisplayChannelId;
            progSwitchInfo.DisplaySplitScreenNo = int.Parse(comboBoxEditDisplaySplitScreenNo.Text) - 1;
            errMessage = "";
            switch (Opt)
            {
                case Util.Operateion.Add:
                    GroupId = ProgSwitchBusiness.Instance.Insert(ref errMessage, progSwitchInfo);
                    OperateLogBusiness.Instance.Insert(ref errMessage, new OperateLog
                       {
                           HappenTime = DateTime.Now, 
                           ClientUserId = MainForm.CurrentUser.UserId,
                           ClientUserName = MainForm.CurrentUser.UserName,
                           Content = progSwitchInfo.ToString(),
                           OperateTypeId =(int) OperateLogTypeId.ProgSwitchAdd,
                           OperateTypeName = OperateLogTypeName.ProgSwitchAdd,
                           OperateUserName = MainForm.CurrentUser.UserName

                       });
                    break;
                case Util.Operateion.Update:
                    //ogroup.GroupID = GeroupId;
                    GroupId = ProgSwitchBusiness.Instance.Update(ref errMessage, progSwitchInfo);
                    
                    OperateLogBusiness.Instance.Insert(ref errMessage, new OperateLog
                    {
                        HappenTime = DateTime.Now,
                        ClientUserId = MainForm.CurrentUser.UserId,
                        ClientUserName = MainForm.CurrentUser.UserName,
                        Content = progSwitchInfo.ToString(),
                        OperateTypeId = (int)OperateLogTypeId.GroupSwitchUpdate,
                        OperateTypeName = OperateLogTypeName.GroupSwitchUpdate,
                        OperateUserName = MainForm.CurrentUser.UserName

                    });
                    break;
                case Util.Operateion.Delete:
                    break;
                default:
                    break;
            }
            if (errMessage.Length == 0)
            {
                this.Close();
            }
             
          
        }
        Dictionary<int, DisplayChannelInfo> _listMonitor;
        Dictionary<String, DisplayChannelInfo> _listMonitorByName = new Dictionary<string, DisplayChannelInfo>();
        private void frmProgSwitchGroup_Load(object sender, EventArgs e)
        {
            String message="";
            _listMonitor = DisplayChannelBusiness.Instance.GetAllDisplayChannelInfo(ref message);
            foreach (KeyValuePair<int, DisplayChannelInfo> item in _listMonitor)
            {
                comboBoxEditDisplayChannel.Properties.Items.Add(item.Value.DisplayChannelName);
                _listMonitorByName.Add(item.Value.DisplayChannelName, item.Value);
            }
        }

        private void comboBoxEditDisplayChannel_EditValueChanged(object sender, EventArgs e)
        {
            comboBoxEditDisplaySplitScreenNo.Properties.Items.Clear();
            for (int i = 0; i < _listMonitorByName[comboBoxEditDisplayChannel.Text].SplitScreenNo; i++)
            {
                comboBoxEditDisplaySplitScreenNo.Properties.Items.Add(i + 1);
            }
        }

    }
}