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
    public partial class frmQueryInfoByUser : DevExpress.XtraEditors.XtraForm
    {
        public frmQueryInfoByUser()
        {
            InitializeComponent();
        }
        public frmQueryInfoByUser(DataSet ds,string username)
        {
            InitializeComponent();
            int i;
            var datatable = new System.Data.DataTable("Search");
            datatable.Columns.Add("编号", typeof(int));
            datatable.Columns.Add("用户名", typeof(string));
            datatable.Columns.Add("抓拍违法行为", typeof(string));
            datatable.Columns.Add("时间", typeof(string));
            datatable.Columns.Add("地点", typeof(string));
            for (i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                datatable.Rows.Add(i + 1, username, ds.Tables[0].Rows[i][0].ToString(), ds.Tables[0].Rows[i][1].ToString(), ds.Tables[0].Rows[i][2].ToString());
            }
            gridControlShowQueryInfoByUser.DataSource = datatable;
            gridControlShowQueryInfoByUser.MainView.PopulateColumns();
            gridView1.Columns["编号"].Width = 20;
            gridView1.Columns["用户名"].Width = 40;
            gridView1.Columns["抓拍违法行为"].Width = 140;
            gridView1.Columns["时间"].Width = 40;
            gridView1.Columns["地点"].Width = 140;
        }

        private void sbOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gridView1_MouseDown(object sender, MouseEventArgs e)
        {
            DataSet ds = new DataSet();
            UserInfo ui = new UserInfo();
            string errMessage="";
            DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo hInfo = gridView1.CalcHitInfo(new Point(e.X, e.Y));
            if (e.Button == MouseButtons.Left && e.Clicks == 2)
            {

                if (hInfo.InRow)
                {
                    //取得选定行信息
                    string userName = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "用户名").ToString();
                    string illegalReason = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "抓拍违法行为").ToString();
                    DateTime time = DateTime.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "时间").ToString());
                    string place = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "地点").ToString();
                    ui = UserBusiness.Instance.GetUserInfo(ref errMessage,userName);
                    ds = LongChang_UserVehMonBusiness.Instance.GetRecordDetail(ref errMessage, ui.UserId.ToString(),illegalReason,place,time);
                    frmRecordDetail frd = new frmRecordDetail(ds, userName);
                    frd.ShowDialog(this);

                }
            }
        }
    }
}