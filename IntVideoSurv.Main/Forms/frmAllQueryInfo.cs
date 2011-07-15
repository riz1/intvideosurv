using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using IntVideoSurv.Entity;
using IntVideoSurv.Business;

namespace CameraViewer.Forms
{
    public partial class frmAllQueryInfo : DevExpress.XtraEditors.XtraForm
    {
        private string errMessage = "";
        public frmAllQueryInfo()
        {
            InitializeComponent();
        }
        public frmAllQueryInfo(DataSet ds)
        {
            InitializeComponent();
            int i;
            UserInfo ui = new UserInfo();
            var datatable = new System.Data.DataTable("Search");
            datatable.Columns.Add("编号", typeof(int));
            datatable.Columns.Add("用户名", typeof(string));
            datatable.Columns.Add("抓拍违法记录数", typeof(string));
            for (i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ui = UserBusiness.Instance.GetUserInfo(ref errMessage, int.Parse(ds.Tables[0].Rows[i][0].ToString()));
                datatable.Rows.Add(i + 1, ui.UserName, ds.Tables[0].Rows[i][1].ToString());
            }
            gridControlShowAllQueryInfo.DataSource = datatable;
            gridControlShowAllQueryInfo.MainView.PopulateColumns();
            gridView1.Columns["编号"].Width = 20;
            gridView1.Columns["用户名"].Width = 40;
            gridView1.Columns["抓拍违法记录数"].Width = 140;


        }

        private void gridControlShowAllQueryInfo_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void gridView1_MouseDown(object sender, MouseEventArgs e)
        {
            UserInfo ui = new UserInfo();
            DataSet ds = new DataSet();
            DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo hInfo = gridView1.CalcHitInfo(new Point(e.X, e.Y));
            if (e.Button == MouseButtons.Left && e.Clicks == 2)
            {

                if (hInfo.InRow)
                {
                    //取得选定行信息
                    string userName = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "用户名").ToString();
                    ui = UserBusiness.Instance.GetUserInfo(ref errMessage, userName);
                    ds = LongChang_UserVehMonBusiness.Instance.GetUserQueryInfoByUserId(ref errMessage, ui.UserId.ToString());
                    frmQueryInfoByUser fqi = new frmQueryInfoByUser(ds,ui.UserName);
                    fqi.ShowDialog(this);
                }
            }

        }
    }
}