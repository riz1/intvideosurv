using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using DevExpress.Skins;
using DevExpress.XtraEditors;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using IntVideoSurv.Entity;
using IntVideoSurv.Business;

namespace CameraViewer.Forms
{
    public partial class SearchForm : DevExpress.XtraEditors.XtraForm
    {
        Dictionary<int, UserInfo> listuser = new Dictionary<int, UserInfo>();
        string errMessage = "";
        public SearchForm()
        {
            InitializeComponent();
            DateTime dt = DateTime.Now;
            teStartTime.EditValue = dt.Year.ToString() + "/" + dt.Month.ToString() + "/" + "01" + " " + "00:00:00";
            teEndTime.EditValue = dt.Year.ToString() + "/" + dt.Month.ToString() + "/" + dt.Day.ToString() + " " + dt.Hour.ToString() + ":" + dt.Minute.ToString() + ":" + dt.Second.ToString();
            if (MainForm.CurrentUser.UserTypeId == 1)//管理员
            {
                comboBoxEditUser.Text = "admin";
                listuser = UserBusiness.Instance.GetAllUserInfo(ref errMessage);
                foreach (var v in listuser)
                {
                    comboBoxEditUser.Properties.Items.Add(v.Value.UserName);
                    comboBoxEditUser.Properties.Tag = v.Key.ToString();
                }

            }
            else if (MainForm.CurrentUser.UserTypeId == 2)//操作员
            {
                comboBoxEditUser.Text = MainForm.CurrentUser.UserName;
                //comboBoxEditUser.Properties.Items.Add(MainForm.CurrentUser.UserName);
                comboBoxEditUser.Enabled = false;
                comboBoxEditUser.Properties.Tag = MainForm.CurrentUser.UserId.ToString();
            }
        }

        private void simpleButtonSearch_Click(object sender, EventArgs e)
        {
            int i;
            string errMessage = "";
            DataSet ds = new DataSet();
            UserInfo ui = new UserInfo();
            ui = UserBusiness.Instance.GetUserInfo(ref errMessage,comboBoxEditUser.Text);
            Dictionary<string, string> listIllegalreason = new Dictionary<string, string>();
            DateTime startTime = DateTime.Parse(teStartTime.EditValue.ToString());
            DateTime endTime = DateTime.Parse(teEndTime.EditValue.ToString());

            if (DateTime.Compare(startTime, endTime) > 0)
            {
                MessageBox.Show("起始时间不能大于终止时间");
                return;
            }
            ds = LongChang_UserVehMonBusiness.Instance.GetTimeAndIllegalreasonByUserId(ref errMessage, ui.UserId.ToString(), startTime, endTime);

            var datatable = new System.Data.DataTable("Search");
            datatable.Columns.Add("编号", typeof(int));
            datatable.Columns.Add("用户名", typeof(string));
            datatable.Columns.Add("抓拍违法行为", typeof(string));
            datatable.Columns.Add("时间", typeof(string));
            datatable.Columns.Add("地点", typeof(string));
            for (i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                datatable.Rows.Add(i + 1, comboBoxEditUser.Text, ds.Tables[0].Rows[i][0].ToString(), ds.Tables[0].Rows[i][1].ToString(), ds.Tables[0].Rows[i][2].ToString());
            }
            gridControlSearch.DataSource = datatable;
            gridControlSearch.MainView.PopulateColumns();
            gridView7.Columns["编号"].Width = 20;
            gridView7.Columns["用户名"].Width = 40;
            gridView7.Columns["抓拍违法行为"].Width = 140;
            gridView7.Columns["时间"].Width = 70;
            gridView7.Columns["地点"].Width = 60;
        }

        private void gridView7_MouseDown(object sender, MouseEventArgs e)
        {
            DataSet ds = new DataSet();
            UserInfo ui = new UserInfo();
            string errMessage = "";
            DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo hInfo = gridView7.CalcHitInfo(new Point(e.X, e.Y));
            if (e.Button == MouseButtons.Left && e.Clicks == 2)
            {

                if (hInfo.InRow)
                {
                    //取得选定行信息
                    string userName = gridView7.GetRowCellValue(gridView7.FocusedRowHandle, "用户名").ToString();
                    string illegalReason = gridView7.GetRowCellValue(gridView7.FocusedRowHandle, "抓拍违法行为").ToString();
                    DateTime time = DateTime.Parse(gridView7.GetRowCellValue(gridView7.FocusedRowHandle, "时间").ToString());
                    string place = gridView7.GetRowCellValue(gridView7.FocusedRowHandle, "地点").ToString();
                    ui = UserBusiness.Instance.GetUserInfo(ref errMessage, userName);
                    ds = LongChang_UserVehMonBusiness.Instance.GetRecordDetail(ref errMessage, ui.UserId.ToString(), illegalReason, place, time);
                    frmRecordDetail frd = new frmRecordDetail(ds, userName);
                    frd.ShowDialog(this);

                }
            }
        }
    }
}