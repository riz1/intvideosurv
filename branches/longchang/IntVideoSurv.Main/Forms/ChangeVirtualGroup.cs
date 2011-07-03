using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraTreeList.Nodes;
using IntVideoSurv.Business;
using IntVideoSurv.Entity;

namespace CameraViewer.Forms
{
    public partial class ChangeVirtualGroup: XtraForm
    {
        public ChangeVirtualGroup()
        {
            InitializeComponent();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            string err = "";
            VirtualGroupInfo item = new VirtualGroupInfo();
            item.Name = textBox_name.Text;
            item.ID = Gid;
            VirtualGroupBusiness.Instance.ChangeVirtualGroup(ref err, item.ID, item.Name);
            Close();
            Dispose();
        }

        private void buttoncancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public int Gid { get; set; }
    }
}
