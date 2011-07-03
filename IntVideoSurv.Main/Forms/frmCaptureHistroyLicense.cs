using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using CameraViewer.Player;
using DevExpress.XtraEditors;
using IntVideoSurv.Entity;
using IntVideoSurv.Business;
using log4net;
using CameraViewer.Tools;

namespace CameraViewer.Forms
{
    public partial class frmCaptureHistroyLicense : XtraForm
    {


        private static readonly ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private const int PicNum = 5;
        private const int fps = 25;
        DataTable dataTableHistroyFile = new DataTable();
        private void InitDataTable()
        {
            dataTableHistroyFile.Columns.Add("编号", typeof(int));
            dataTableHistroyFile.Columns.Add("摄像头", typeof(string));
            dataTableHistroyFile.Columns.Add("时间", typeof(DateTime));
            dataTableHistroyFile.Columns.Add("文件", typeof(string));
            dataTableHistroyFile.Columns.Add("CameraTag", typeof(LongChang_CameraInfo));
        }
        public frmCaptureHistroyLicense(frmHistoryCaptureCondition frmhcc)
        {

            InitializeComponent();

            UseWaitCursor = true;
            InitDataTable();
            dataTableHistroyFile.Rows.Clear();
            int i = 1;
            foreach (var camera in frmhcc.ListSelectedCameras)
            {
                RelatedHistroyVideoFile relatedHistroyVideoFile = new RelatedHistroyVideoFile(camera.Value,1,frmhcc.BeginTime,frmhcc.EndTime);
                
                //加入到摄像头文件列表
                foreach (var histroyVideoFile in relatedHistroyVideoFile.ListHistroyVideoFile)
                {
                    dataTableHistroyFile.Rows.Add(i++,
                                                  camera.Value.Name,
                                                  histroyVideoFile.CaptureTime,
                                                  histroyVideoFile.FileName,
                                                  camera.Value
                        );
                }
            }

            gridControl1.DataSource = dataTableHistroyFile;
            LoadBaseInfo();
            if (!Directory.Exists(Properties.Settings.Default.CapturePictureTempPath))
            {
                Directory.CreateDirectory(Properties.Settings.Default.CapturePictureTempPath);
            }
            if (!Directory.Exists(Properties.Settings.Default.CapturePictureFilePath))
            {
                Directory.CreateDirectory(Properties.Settings.Default.CapturePictureFilePath);
            }
            UseWaitCursor = false;
            intPtr = AirnoixPlayer.Avdec_Init(panelControlVideo.Handle, 0, 512, 0);


        }
        private IntPtr intPtr;
        private int frameWidth;
        private int frameHeight;
        private AirnoixPlayerState _previousState;
        private int _totalFrames;
        private void simpleButtonPrevious_Click(object sender, EventArgs e)
        {
            try
            {
                treeListPicturesBefore.Nodes.Clear();
                Image[] images = GetImages();
                treeListPicturesBefore.AppendNode(new[] { images[0], images[1], images[2], images[3], images[4] }, -1);
                int currentPos = AirnoixPlayer.Avdec_GetCurrentPosition(intPtr);
                teCaptureTime.EditValue = _beginCaptureTime.AddSeconds(currentPos / fps);
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());
                return;
            }

        }

        private void simpleButtonCurrent_Click(object sender, EventArgs e)
        {
            try
            {
                treeListPicturesCurrent.Nodes.Clear();
                Image[] images = GetImages();
                treeListPicturesCurrent.AppendNode(new[] { images[0], images[1], images[2], images[3], images[4] }, -1);
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());
                return;
            }
        }

        private void simpleButtonLast_Click(object sender, EventArgs e)
        {
            try
            {
                treeListPicturesAfter.Nodes.Clear();
                Image[] images = GetImages();
                treeListPicturesAfter.AppendNode(new[] { images[0], images[1], images[2], images[3], images[4] }, -1);
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());
                return;
            }
        }

        private Image[] GetImages()
        {
            _previousState = AirnoixPlayer.Avdec_GetCurrentState(intPtr);

            int ret = AirnoixPlayer.Avdec_Pause(intPtr);
            int currentPos = AirnoixPlayer.Avdec_GetCurrentPosition(intPtr);
            if (currentPos >= 3)
            {
                for (int i = 0; i < 3; i++)
                {
                    AirnoixPlayer.Avdec_StepFrame(intPtr, false);                    
                }

            }
            if (_totalFrames - currentPos <= PicNum)
            {
                for (int i = 0; i < _totalFrames - currentPos; i++)
                {
                    AirnoixPlayer.Avdec_StepFrame(intPtr, false);
                }
            }
            while (frameWidth == 0 || frameHeight == 0)
            {
                frameWidth = AirnoixPlayer.Avdec_GetImageWidth(intPtr);
                frameHeight = AirnoixPlayer.Avdec_GetImageHeight(intPtr);
            }
            Image[] images = new Image[PicNum];
            for (int i = 0; i < PicNum; i++)
            {
                string fmt = string.Format("JPG {0:0000}{1:0000}{2:0000}", frameWidth>0?frameWidth:1280, frameHeight>0?frameHeight:720, 24);
                string filename = Properties.Settings.Default.CapturePictureTempPath + "\\" + Guid.NewGuid() + ".bmp";
                ret = AirnoixPlayer.Avdec_Play(intPtr);
                ret = AirnoixPlayer.Avdec_Pause(intPtr);
                ret = AirnoixPlayer.Avdec_CapturePicture(intPtr, filename, fmt);
                
                images[i] = Image.FromFile(filename);

            }
            if (_previousState == AirnoixPlayerState.PLAY_STATE_PLAY)
            {
                ret = AirnoixPlayer.Avdec_Play(intPtr);
            }
            return images;
        }

        private void treeListPicturesBefore_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (treeListPicturesBefore.FocusedNode.GetValue(0) == null)
                {
                    return;
                }
                pictureEditSelectedPicture.Image = treeListPicturesBefore.FocusedNode.GetValue(0) as Image;

            }
            catch (Exception)
            {
                
                ;
            }

        }

        private void treeListPicturesCurrent_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (treeListPicturesCurrent.FocusedNode.GetValue(0) == null)
                {
                    return;
                }
                pictureEditSelectedPicture.Image = treeListPicturesCurrent.FocusedNode.GetValue(0) as Image;
            }
            catch (Exception)
            {
                
                ;
            }

        }

        private void treeListPicturesAfter_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (treeListPicturesAfter.FocusedNode.GetValue(0) == null)
                {
                    return;
                }
                pictureEditSelectedPicture.Image = treeListPicturesAfter.FocusedNode.GetValue(0) as Image;
            }
            catch (Exception)
            {
                
                ;
            }

        }

        private void pictureEditSelectedPicture_DoubleClick(object sender, EventArgs e)
        {
            if (pictureEditSelectedPicture.Image!=null)
            {
                frmFullsizePicture ffp = new frmFullsizePicture(pictureEditSelectedPicture.Image);
                ffp.Show();                
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                if (trackBar1.Maximum == trackBar1.Minimum)
                {
                    _totalFrames = AirnoixPlayer.Avdec_GetTotalFrames(intPtr);
                    trackBar1.Maximum = _totalFrames;
                }

                int currentPos = AirnoixPlayer.Avdec_GetCurrentPosition(intPtr);
                trackBar1.Value = currentPos; 

            }
            catch (Exception ex)
            {
                
                Debug.WriteLine("Error:"+ex.ToString());
            }


        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            int mum;
            int count;
            AirnoixPlayerState state = AirnoixPlayer.Avdec_GetCurrentState(intPtr);
            if ( state == AirnoixPlayerState.PLAY_STATE_STOP)
            {
                AirnoixPlayer.Avdec_Play(intPtr);
                AirnoixPlayer.Avdec_Pause(intPtr);
            }
            if ((state == AirnoixPlayerState.PLAY_STATE_PAUSE))
            {
                int ret = AirnoixPlayer.Avdec_SetCurrentPosition(intPtr, trackBar1.Value);
                mum = AirnoixPlayer.Avdec_GetCurrentPosition(intPtr);
                count = trackBar1.Value - mum;
                while (count > 0)
                {
                    ret = AirnoixPlayer.Avdec_StepFrame(intPtr, true);
                    count--;
                }
            }
        }

        private void frmCaptureHistroyLicense_FormClosed(object sender, FormClosedEventArgs e)
        {
            int ret = AirnoixPlayer.Avdec_Done(intPtr);
        }


        private void buttonPlay_Click(object sender, EventArgs e)
        {
            AirnoixPlayer.Avdec_Play(intPtr);
        }

        private void buttonPause_Click(object sender, EventArgs e)
        {
            AirnoixPlayer.Avdec_Pause(intPtr);
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            trackBar1.Value = trackBar1.Minimum;
            AirnoixPlayer.Avdec_Stop(intPtr);
            
        }

        #region 抓拍证据(从CaptureLicense控件移植过来)
        
        private static string staticErrMessage = "";
        private static Dictionary<string, LongChang_LptColorInfo> _listLongChang_LptColorInfo =
    LongChang_LptColorBusiness.Instance.GetAllLptColorInfo(ref staticErrMessage);
        private static Dictionary<string, LongChang_LptTypeInfo> _listLongChang_LptTypeInfo =
            LongChang_LptTypeBusiness.Instance.GetAllLptTypeInfo(ref staticErrMessage);
        private static Dictionary<string, LongChang_TollGateInfo> _listLongChang_TollGateInfo =
    LongChang_TollGateBusiness.Instance.GetAllTollGateInfo(ref staticErrMessage);
        private static Dictionary<string, LongChang_VehColorInfo> _listLongChang_VehColorInfo =
    LongChang_VehColorBusiness.Instance.GetAllVehColorInfo(ref staticErrMessage);
        private static Dictionary<string, LongChang_VehTypeInfo> _listLongChang_VehTypeInfo =
    LongChang_VehTypeBusiness.Instance.GetAllVehTypeInfo(ref staticErrMessage);

        private static Dictionary<string, LongChang_RegionInfo> _listLongChang_RegionInfo =
LongChang_RegionBusiness.Instance.GetAllRegionInfo(ref staticErrMessage);
        private static Dictionary<string, LongChang_CaptureDepartmentInfo> _listLongChang_CaptureDepartmentInfo =
LongChang_CaptureDepartmentBusiness.Instance.GetAllCaptureDepartmentInfo(ref staticErrMessage);
        private static Dictionary<string, LongChang_InvalidTypeInfo> _listLongChang_InvalidTypeInfo =
LongChang_InvalidTypeBusiness.Instance.GetAllInvalidTypeInfo(ref staticErrMessage);


        private void LoadBaseInfo()
        {
            cbeVehType.Properties.Items.Clear();
            foreach (var v in _listLongChang_VehTypeInfo)
            {
                cbeVehType.Properties.Items.Add(v.Value.VehicleType);
            }
            if (cbeVehType.Properties.Items.Count > 0)
            {
                cbeVehType.EditValue = cbeVehType.Properties.Items[0];
            }

            cbeRegion.Properties.Items.Clear();
            foreach (var v in _listLongChang_RegionInfo)
            {
                cbeRegion.Properties.Items.Add(v.Value.RegionName);
            }
            if (cbeRegion.Properties.Items.Count > 0)
            {
                cbeRegion.EditValue = cbeRegion.Properties.Items[0];
            }

            cbeCaptureDepartment.Properties.Items.Clear();
            foreach (var v in _listLongChang_CaptureDepartmentInfo)
            {
                cbeCaptureDepartment.Properties.Items.Add(v.Value.CaptureDepartmentName);
            }
            if (cbeCaptureDepartment.Properties.Items.Count > 0)
            {
                cbeCaptureDepartment.EditValue = cbeCaptureDepartment.Properties.Items[0];
            }

            cbeInvalidType.Properties.Items.Clear();
            foreach (var v in _listLongChang_InvalidTypeInfo)
            {
                cbeInvalidType.Properties.Items.Add(v.Value.InvalidName);
            }
            if (cbeInvalidType.Properties.Items.Count > 0)
            {
                cbeInvalidType.EditValue = cbeInvalidType.Properties.Items[0];
            }
            if (_selectedCamera==null)
            {
                return;
            }
            comboBoxEditRoadName.Properties.Items.Clear();
            foreach (var v in _listLongChang_TollGateInfo)
            {
                bool isexisted = false;
                foreach (var VARIABLE in comboBoxEditRoadName.Properties.Items)
                {
                    if (VARIABLE.ToString()==v.Value.roadName)
                    {
                        isexisted = true;
                        break;
                    }
                }
                if (!isexisted)
                {
                    comboBoxEditRoadName.Properties.Items.Add(v.Value.roadName);  
                }

            }
            if (comboBoxEditRoadName.Properties.Items.Count > 0)
            {
                comboBoxEditRoadName.EditValue = comboBoxEditRoadName.Properties.Items[0];
            }
            LongChang_TollGateInfo tollgate = new LongChang_TollGateInfo();
            if (_selectedCamera == null)
            {
                MessageBox.Show("此摄像头不存在");
                return;
            }


        }

        #endregion
        private string errMessage = "";
        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (treeListPicturesBefore.FocusedNode == null || treeListPicturesCurrent.FocusedNode == null || treeListPicturesAfter.FocusedNode == null)
            {
                XtraMessageBox.Show("三张照片未完全生成!");
                return;
            }
            if (textEdit1.Text.Length<7)
            {
                XtraMessageBox.Show("录入的车牌号不正确!");
                return;
            }
            LongChang_VehMonInfo vehmon = new LongChang_VehMonInfo();
            LongChang_TollGateInfo tollgate = new LongChang_TollGateInfo();
            LongChang_InvalidTypeInfo reason = new LongChang_InvalidTypeInfo();
            LongChang_UserVehMonInfo uservehmon = new LongChang_UserVehMonInfo();
            string captureFileName = Properties.Settings.Default.CapturePictureFilePath
                                     + @"\" + ((DateTime)teCaptureTime.EditValue).ToString(@"yyyy\\MM\\dd")
                                     + @"\";
            if (!Directory.Exists(captureFileName))
            {
                Directory.CreateDirectory(captureFileName);
            }

            vehmon.plateNumberTypeName = cbeVehType.Text;
            vehmon.plateNumber = textEdit1.Text;
            vehmon.illegalReason = cbeInvalidType.Text;
            reason = LongChang_InvalidTypeBusiness.Instance.GetInvalidTypeInfoByWzyy(ref errMessage, vehmon.illegalReason);
            vehmon.adminDivisionName = cbeCaptureDepartment.Text;
            vehmon.adminDivisionNumber = int.Parse(cbeRegion.Text);
            vehmon.vehInfoNum = 0;
            vehmon.tollNum = 0;
            vehmon.tollName = "成都市西门车站营门口路11190号";
            vehmon.plateColorNum = 0;
            vehmon.plateColor = "";
            vehmon.imageCount = 0;
            vehmon.imageName1 = captureFileName + ((DateTime)teCaptureTime.EditValue).ToString("HHmmss") + "_" + vehmon.plateNumber + "_1.jpg";
            vehmon.imageName2 = captureFileName + ((DateTime)teCaptureTime.EditValue).ToString("HHmmss") + "_" + vehmon.plateNumber + "_2.jpg";
            vehmon.imageName3 = captureFileName + ((DateTime)teCaptureTime.EditValue).ToString("HHmmss") + "_" + vehmon.plateNumber + "_3.jpg";
            vehmon.imageName4 = "";
            vehmon.vedioName = "";
            vehmon.vedioName1 = "";
            vehmon.vedioName2 = "";
            vehmon.vehicleColor = "";
            vehmon.vehicleType = 0;
            vehmon.vehicleTypeName = "";
            vehmon.plateNumberType = "A";
            vehmon.countTime = 0;

            if (_selectedCamera == null)
            {
                MessageBox.Show("此摄像头不存在");
                return;
            }
            if ((tollgate=LongChang_TollGateBusiness.Instance.GetTollGateInfoByCameraId(ref errMessage, _selectedCamera.CameraId)) == null)
            {
                MessageBox.Show("没有对应的卡口信息");
                return;
            }

            vehmon.roadName = tollgate.roadName;
            vehmon.redLightTime = Convert.ToDateTime(teCaptureTime.Text);
            //写入vehmon信息
            string i;
            i = LongChang_VehMonBusiness.Instance.Insert(ref errMessage, vehmon);
            
            //写入uservehmon信息
            uservehmon.VehMonId = i;
            uservehmon.UserId = MainForm.CurrentUser.UserId;
            uservehmon.TheTime = DateTime.Now;
            LongChang_UserVehMonBusiness.Instance.Insert(ref errMessage, uservehmon);
            //将三张图片写入到磁盘中
            Image image1 = treeListPicturesBefore.FocusedNode.GetValue(0) as Image;
            Image image2 = treeListPicturesCurrent.FocusedNode.GetValue(0) as Image;
            Image image3 = treeListPicturesAfter.FocusedNode.GetValue(0) as Image;
            image1 = AddTextInImage(image1, vehmon.tollName, 18, Color.White, 8, 46);
            image2 = AddTextInImage(image2, vehmon.tollName, 18, Color.White, 8, 46);
            image3 = AddTextInImage(image3, vehmon.tollName, 18, Color.White, 8, 46);
            image1.Save(vehmon.imageName1, System.Drawing.Imaging.ImageFormat.Jpeg);
            image2.Save(vehmon.imageName2, System.Drawing.Imaging.ImageFormat.Jpeg);
            image3.Save(vehmon.imageName3, System.Drawing.Imaging.ImageFormat.Jpeg);

            //重置图片
            treeListPicturesBefore.Nodes.Clear();
            treeListPicturesCurrent.Nodes.Clear();
            treeListPicturesAfter.Nodes.Clear();
            pictureEditSelectedPicture.Image = null;
            textEdit1.Text = "川K";
        }

        private Image AddTextInImage(Image image, string addText, int fonesize, Color brushColor, int x, int y)
        {
            Graphics g = Graphics.FromImage(image);
            g.DrawImage(image, 0, 0, image.Width, image.Height);
            Font f = new Font("Verdana", fonesize);
            Brush b = new SolidBrush(brushColor);

            g.DrawString(addText, f, b, x, y);
            g.Dispose();
            return image;
        }
        private void frmCaptureHistroyLicense_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt&&e.KeyCode==Keys.A)
            {
                simpleButtonPrevious_Click(sender, null);
            }
            else if (e.Alt && e.KeyCode == Keys.S)
            {
                simpleButtonCurrent_Click(sender, null);
            }
            else if (e.Alt && e.KeyCode == Keys.D)
            {
                simpleButtonLast_Click(sender, null);
            }
        }

        private LongChang_CameraInfo _selectedCamera;
        private string _selectedFile;
        private DateTime _beginCaptureTime;
        private void bandedGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (bandedGridView1.SelectedRowsCount > 0)
            {
                int getSelectedRow = this.bandedGridView1.GetSelectedRows()[0];
                _selectedCamera = (LongChang_CameraInfo)(this.bandedGridView1.GetRowCellValue(getSelectedRow, "CameraTag"));
                _selectedFile = (string)(this.bandedGridView1.GetRowCellValue(getSelectedRow, "文件"));
                _beginCaptureTime = (DateTime)(this.bandedGridView1.GetRowCellValue(getSelectedRow, "时间"));
                AirnoixPlayer.Avdec_CloseFile(intPtr);
                AirnoixPlayer.Avdec_SetFile(intPtr, _selectedFile, null, false);
                frameWidth = AirnoixPlayer.Avdec_GetImageWidth(intPtr);
                frameHeight = AirnoixPlayer.Avdec_GetImageHeight(intPtr);
                trackBar1.Minimum = 0;
                trackBar1.Maximum = AirnoixPlayer.Avdec_GetTotalFrames(intPtr);
                AirnoixPlayer.Avdec_Play(intPtr);
                if (timerForUpdateTrack.Enabled==false)
                {
                    timerForUpdateTrack.Enabled = true;
                }
                LongChang_TollGateInfo tollgate;
                if ((tollgate = LongChang_TollGateBusiness.Instance.GetTollGateInfoByCameraId(ref errMessage, _selectedCamera.CameraId)) == null)
                {
                    comboBoxEditRoadName.Text = "未知";
                }
                else
                {
                    comboBoxEditRoadName.Text = tollgate.roadName;
                }
            }
        }
    }
}
