using System;
using System.Collections.Generic;
using DevExpress.XtraEditors;
using IntVideoSurv.Business;
using IntVideoSurv.Entity;


namespace IntVideoSurv
{
    public partial class MainForm : XtraForm
    {
        public MainForm()
        {
            InitializeComponent();
            barStaticItemStartTime.Caption = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        private void timerCurrentTime_Tick(object sender, EventArgs e)
        {
            barStaticItemCurrentTime.Caption = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }
    }
}
