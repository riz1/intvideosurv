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
    public partial class AddVirtualGroup : DevExpress.XtraEditors.XtraForm
    {
        public AddVirtualGroup()
        {
            InitializeComponent();
        }

        private void simpleButtonGroupOK_Click(object sender, EventArgs e)
        {
            string err="";
            VirtualGroupInfo item=new VirtualGroupInfo();
            item.Name=textEditVirtualGroup.Text;
            VirtualGroupBusiness.Instance.Insert(ref err,item);
            Close();
            Dispose();
        }

        private void simpleButtonGroupcancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}