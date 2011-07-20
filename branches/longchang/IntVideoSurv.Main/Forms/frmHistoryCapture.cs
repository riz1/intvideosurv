using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CameraViewer.Tools;
using DevExpress.Utils;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using IntVideoSurv.Entity;

namespace CameraViewer.Forms
{
    public partial class frmHistoryCapture : frmCaptureLicense
    {
        private readonly IEnumerable<LongChang_CameraInfo> _selectedCameras;

        public DateTime BeginTime { get; set; }
        public DateTime EndTime { get; set; }

        public frmHistoryCapture()
            : base()
        {
            InitializeComponent();
        }

        public frmHistoryCapture(IEnumerable<LongChang_CameraInfo> selectedCameras)
            : this()
        {
            _selectedCameras = selectedCameras;
        }

        protected override async void InitializeVideoList()
        {
            var gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            gridView.OptionsBehavior.Editable = false;
            gridView.OptionsBehavior.AutoPopulateColumns = false;
            gridView.OptionsView.ShowGroupPanel = false;

            var c1 = new GridColumn();
            c1.FieldName = "Camera.Name";
            c1.Caption = "摄像头名称";
            c1.Visible = true;
            c1.VisibleIndex = 0;

            var c2 = new GridColumn();
            c2.FieldName = "CaptureTime";
            c2.DisplayFormat.FormatString = "t";
            c2.DisplayFormat.FormatType = FormatType.DateTime;
            c2.Caption = "录像时间";
            c2.Visible = true;
            c2.VisibleIndex = 1;


            gridView.Columns.AddRange(new[]
                                          {
                                              c1,
                                              c2
                                          });

            gridView.DoubleClick += new EventHandler(gridView_DoubleClick);

            var grid = new DevExpress.XtraGrid.GridControl();
            grid.MainView = gridView;
            grid.Dock = DockStyle.Fill;
            grid.ViewCollection.Add(gridView);

            this.videoListContainer.Controls.Add(grid);

            if (!DesignMode)
            {
                if (_selectedCameras != null)
                {
                    ShowBusyMessage("正在刷新录像列表...");

                    foreach (var camera in _selectedCameras)
                    {
                        RelatedHistroyVideoFile file = null;

                        LongChang_CameraInfo camera1 = camera;

                        await System.Threading.Tasks.TaskEx.Run( ()=>file = new RelatedHistroyVideoFile(camera1, 1, BeginTime, EndTime) );

                        if (file != null)
                        {
                            grid.DataSource = file.ListHistroyVideoFile;
                        }

                        HideBusyMessage();
                    }
                }
            }

        }

        void gridView_DoubleClick(object sender, EventArgs e)
        {
            var gridview = sender as DevExpress.XtraGrid.Views.Grid.GridView;
            if (gridview.SelectedRowsCount > 0)
            {
                int rh = gridview.GetSelectedRows()[0];
                var dataRow = gridview.GetRow(rh) as HistroyVideoFile;
                if (dataRow != null)
                {
                    if (File.Exists(dataRow.FileName))
                    {
                        PlayVideoFile(dataRow.FileName);
                    }

                    if (dataRow.Camera != null)
                    {
                        var spec = Model.Repository.Instance.GetCamera(dataRow.Camera.CameraId.ToString());
                        CameraSpec = spec;
                    }

                    CaptureTime = dataRow.CaptureTime;
                }
            }
        }
    }
}
