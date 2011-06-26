using System;
using System.Collections;
using System.Collections.Generic;
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

namespace CameraViewer.Forms
{
    public partial class frmCaptureLicense : XtraForm
    {


        private static readonly ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public frmCaptureLicense()
        {
            InitializeComponent();
            LoadBaseInfo();
            if (!Directory.Exists(Properties.Settings.Default.CapturePictureTempPath))
            {
                Directory.CreateDirectory(Properties.Settings.Default.CapturePictureTempPath);
            }
            if (!Directory.Exists(Properties.Settings.Default.CapturePictureFilePath))
            {
                Directory.CreateDirectory(Properties.Settings.Default.CapturePictureFilePath);
            }
            intPtr = AirnoixPlayer.Avdec_Init(panelControlVideo.Handle, 0, 512, 0);
            //int ret = AirnoixPlayer.Avdec_SetFile(intPtr, @"C:\123.AVI", null, false);

            frameWidth = AirnoixPlayer.Avdec_GetImageWidth(intPtr);
            frameHeight = AirnoixPlayer.Avdec_GetImageHeight(intPtr);
            trackBar1.Minimum = 0;
            trackBar1.Maximum = GetTotalFrames();
            StartPlay = true;

        }

        public frmCaptureLicense(AirnoixCamera airnoixCamera)
        {
            InitializeComponent();
            _airnoixCamera = airnoixCamera;
            LoadBaseInfo();
            if (!Directory.Exists(Properties.Settings.Default.CapturePictureTempPath))
            {
                Directory.CreateDirectory(Properties.Settings.Default.CapturePictureTempPath);
            }
            if (!Directory.Exists(Properties.Settings.Default.CapturePictureFilePath))
            {
                Directory.CreateDirectory(Properties.Settings.Default.CapturePictureFilePath);
            }
            intPtr = AirnoixPlayer.Avdec_Init(panelControlVideo.Handle, 0, 512, 0);
            int ret = AirnoixPlayer.Avdec_SetFile(intPtr, airnoixCamera.VideoPath, null, true);

            frameWidth = AirnoixPlayer.Avdec_GetImageWidth(intPtr);
            frameHeight = AirnoixPlayer.Avdec_GetImageHeight(intPtr);
            _totalFrames = AirnoixPlayer.Avdec_GetTotalFrames(intPtr);
            trackBar1.Minimum = 0;
            trackBar1.Maximum = _totalFrames;


        }

        private AirnoixCamera _airnoixCamera;
        private IntPtr intPtr;
        private int frameWidth;
        private int frameHeight;
        private AirnoixPlayerState _previousState;
        private int maunulSteps = 0;
        private int _totalFrames;
        private int Change_Frame = 1200;//第一个视频播放的帧数
        private int Start_Frame = 5000;
        private ArrayList alTempFiles = new ArrayList();
        private void simpleButtonPrevious_Click(object sender, EventArgs e)
        {
            try
            {
                treeListPicturesBefore.Nodes.Clear();
                Image[] images = GetImages();
                treeListPicturesBefore.AppendNode(new[] { images[0], images[1], images[2], images[3], images[4], images[5], images[6] }, -1);
            }
            catch (Exception)
            {
                
                return;
            }

        }

        private void simpleButtonCurrent_Click(object sender, EventArgs e)
        {
            try
            {
                treeListPicturesCurrent.Nodes.Clear();
                Image[] images = GetImages();
                treeListPicturesCurrent.AppendNode(new[] { images[0], images[1], images[2], images[3], images[4], images[5], images[6] }, -1);
            }
            catch (Exception)
            {
                
                return;
            }
        }

        private void simpleButtonLast_Click(object sender, EventArgs e)
        {
            try
            {
                treeListPicturesAfter.Nodes.Clear();
                Image[] images = GetImages();
                treeListPicturesAfter.AppendNode(new[] { images[0], images[1], images[2], images[3], images[4], images[5], images[6] }, -1);
            }
            catch (Exception)
            {
                
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
            if (_totalFrames - currentPos <= 7)
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
            Image[] images = new Image[7];
            for (int i = 0; i < 7; i++)
            {
                string fmt = string.Format("BMP {0:0000}{1:0000}{2:0000}", frameWidth, frameHeight, 24);
                string filename = Properties.Settings.Default.CapturePictureTempPath + "\\" + Guid.NewGuid() + ".bmp";
                ret = AirnoixPlayer.Avdec_Play(intPtr);
                ret = AirnoixPlayer.Avdec_Pause(intPtr);
                ret = AirnoixPlayer.Avdec_CapturePicture(intPtr, filename, fmt);
                
                images[i] = Image.FromFile(filename);
                alTempFiles.Add(filename);
                //ret = AirnoixPlayer.Avdec_StepFrame(intPtr, true);

            }
            if (_previousState == AirnoixPlayerState.PLAY_STATE_PLAY)
            {
                ret = AirnoixPlayer.Avdec_Play(intPtr);
            }
            return images;
        }

        private void treeListPicturesBefore_MouseClick(object sender, MouseEventArgs e)
        {
            pictureEditSelectedPicture.Image = treeListPicturesBefore.FocusedNode.GetValue(0) as Image;
        }

        private void treeListPicturesCurrent_MouseClick(object sender, MouseEventArgs e)
        {
            pictureEditSelectedPicture.Image = treeListPicturesCurrent.FocusedNode.GetValue(0) as Image;
        }

        private void treeListPicturesAfter_MouseClick(object sender, MouseEventArgs e)
        {
            pictureEditSelectedPicture.Image = treeListPicturesAfter.FocusedNode.GetValue(0) as Image;
        }

        private void pictureEditSelectedPicture_DoubleClick(object sender, EventArgs e)
        {
            frmFullsizePicture ffp = new frmFullsizePicture(pictureEditSelectedPicture.Image);
            ffp.Show();
        }

        private bool isTimerChanged;
        private bool isfirstvideo=true;
        private bool first;
        private int tmpcount;
        private int changecount;
        private bool StartPlay;
        private bool FirstLoad;
        private bool IsEnd;
        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                //播放第一段视频
                if(isfirstvideo==true)
                {
                   // if (_totalFrames == 0)
                   // {
                        int currentPos = AirnoixPlayer.Avdec_GetCurrentPosition(intPtr);
                         if (first == true)
                        {
                            tmpcount = currentPos;
                            first = false;
                        }
                        if (currentPos>=tmpcount)
                            currentPos -= tmpcount;
                        if (currentPos < trackBar1.Minimum )
                        {
                            currentPos = trackBar1.Minimum;
                        }
                        else if (currentPos >= trackBar1.Maximum )
                        {
                            currentPos = trackBar1.Maximum;
                        }
                        if (currentPos > 0)
                              trackBar1.Value = currentPos;
                        Trace.WriteLine("Value=" + trackBar1.Value);
                        isTimerChanged = true;
                  //  }
                }
                else
                {
                    //if (AirnoixPlayer.Avdec_GetCurrentState(intPtr) == AirnoixPlayerState.PLAY_STATE_PLAY)
                   // {
                        int currentPos2 = AirnoixPlayer.Avdec_GetCurrentPosition(intPtr);
                        if(isfirstvideo==false)
                        {
                            if (changecount != 0)
                            {
                                currentPos2 += changecount;
                            }
                            else currentPos2 += Change_Frame + 50;//1250
                        }
                        if (currentPos2 < trackBar1.Minimum)
                        {
                            currentPos2 = trackBar1.Minimum;
                        }
                        else if (currentPos2 >= trackBar1.Maximum)
                        {
                            currentPos2 = trackBar1.Maximum;
                            IsEnd = true;
                        }
                        if(IsEnd==false)
                            trackBar1.Value = currentPos2;
                        Trace.WriteLine("Value=" + trackBar1.Value);
                        isTimerChanged = true;
                   // }
                }

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
                int ret = 0;//= AirnoixPlayer.Avdec_SetCurrentPosition(intPtr, trackBar1.Value);
                //处在第一个视频
                if(trackBar1.Value<=Change_Frame)
                {
                    //Thread.Sleep(2500);
                    ret = AirnoixPlayer.Avdec_SetCurrentPosition(intPtr, trackBar1.Value + Start_Frame);
                    mum = AirnoixPlayer.Avdec_GetCurrentPosition(intPtr);
                    count = trackBar1.Value + Start_Frame - mum;
                    while (count > 0)
                    {
                        ret = AirnoixPlayer.Avdec_StepFrame(intPtr, true);
                        count--;
                    }
                }
                else
                {
                    isfirstvideo = false;
                    int i;
                    i = trackBar1.Value - Change_Frame;
                    if (FirstLoad == true)
                    {
                        ret = AirnoixPlayer.Avdec_SetFile(intPtr, @"C:\18-55-28.AVI", null, false);
                        FirstLoad = false;
                        //Thread.Sleep(1000);
                        ret = AirnoixPlayer.Avdec_Play(intPtr);
                        ret = AirnoixPlayer.Avdec_Pause(intPtr);
                       // Thread.Sleep(1500);
                    }
                    ret = AirnoixPlayer.Avdec_SetCurrentPosition(intPtr, i);
                    mum = AirnoixPlayer.Avdec_GetCurrentPosition(intPtr);
                    count = i - mum;
                    while (count > 0)
                    {
                        ret = AirnoixPlayer.Avdec_StepFrame(intPtr, true);
                        count--;
                    }  
                }
            }
        }

        private void frmCaptureLicense_FormClosed(object sender, FormClosedEventArgs e)
        {
            int ret = AirnoixPlayer.Avdec_Done(intPtr);
            //删除临时BMP文件
            DeleteTempBmp();
        }


        private void buttonPlay_Click(object sender, EventArgs e)
        {
            //第一次播放
            if (StartPlay==true)
            {
                FirstPlay(Start_Frame);//从Start_Frame帧开始播放
                StartPlay = false;
            }
            else
            {
                AirnoixPlayer.Avdec_Play(intPtr);
            }


        }

        private void buttonPause_Click(object sender, EventArgs e)
        {
            AirnoixPlayer.Avdec_Pause(intPtr);
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            trackBar1.Value = trackBar1.Minimum;
            AirnoixPlayer.Avdec_Stop(intPtr);
            timer1.Enabled = true;
            timer2.Enabled = true;
            first = true;
            FirstLoad = true;
            IsEnd = false;
            isfirstvideo = true;
            StartPlay = true;
            
        }
        private  int GetTotalFrames()
        {
            int Maximum;
            int count;
            
            Maximum = 0;
            Maximum += Change_Frame;//十五秒对应的帧数
            int ret = AirnoixPlayer.Avdec_SetFile(intPtr, @"C:\18-55-28.AVI", null, false);

            Thread.Sleep(1000);
            ret = AirnoixPlayer.Avdec_Play(intPtr);
            Thread.Sleep(1000);
            Maximum += AirnoixPlayer.Avdec_GetTotalFrames(intPtr); ;
            AirnoixPlayer.Avdec_CloseFile(intPtr);
            return Maximum;
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            try
            {
                AirnoixPlayerState state = AirnoixPlayer.Avdec_GetCurrentState(intPtr);
                if (trackBar1.Value >= Change_Frame && trackBar1.Value <= Change_Frame + 100 && isfirstvideo == true && state == AirnoixPlayerState.PLAY_STATE_PLAY)
                {
                    int ret;
                    ret = AirnoixPlayer.Avdec_CloseFile(intPtr);
                    ret = AirnoixPlayer.Avdec_SetFile(intPtr, @"C:\18-55-28.avi", null, true);
                    changecount = trackBar1.Value;
                    isfirstvideo = false;
                    timer2.Enabled = false;
                }
            }
            catch (Exception ex)
            {
            	
            }

        }
        private void FirstPlay(int start_frame)
        {
            int totalframes;
            int ret;
            int count;
            int mum;
            isfirstvideo = true;
            ret = AirnoixPlayer.Avdec_SetFile(intPtr, @"C:\123.AVI", null, false);
            Thread.Sleep(1000);
            ret = AirnoixPlayer.Avdec_Play(intPtr);
            ret = AirnoixPlayer.Avdec_Pause(intPtr);
            
            if (trackBar1.Maximum > 0)
            {
                Thread.Sleep(2500);
                ret = AirnoixPlayer.Avdec_SetCurrentPosition(intPtr, start_frame);
                mum = AirnoixPlayer.Avdec_GetCurrentPosition(intPtr);
                count = start_frame - mum;
                while (count > 0)
                {
                    ret = AirnoixPlayer.Avdec_StepFrame(intPtr, true);
                    count--;
                }
            }
            Thread.Sleep(1000);
            ret = AirnoixPlayer.Avdec_Play(intPtr);
            timer1.Enabled = true;
            timer2.Enabled = true;
            first = true;
            FirstLoad = true;
            IsEnd = false;
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

            teCaptureTime.EditValue = _airnoixCamera.BeginCaptureTime == null
                                 ? DateTime.Now
                                 : _airnoixCamera.BeginCaptureTime;
        }

        #endregion
        private string errMessage = "";
        private void buttonSave_Click(object sender, EventArgs e)
        {
            LongChang_VehMonInfo vehmon = new LongChang_VehMonInfo();
            LongChang_TollGateInfo tollgate = new LongChang_TollGateInfo();
            string captureFileName = Properties.Settings.Default.CapturePictureFilePath
                         + @"\"+_airnoixCamera.BeginCaptureTime.ToString("yyyy-MM-dd")
                         + @"\" + _airnoixCamera.BeginCaptureTime.ToString("HH-mm") + @"\";
            if (!Directory.Exists(captureFileName))
            {
                Directory.CreateDirectory(captureFileName);
            }



            vehmon.plateNumberTypeName = cbeVehType.Text;
            vehmon.plateNumber = textEdit1.Text;
            vehmon.illegalReason = "dddd";//cbeInvalidType.Text;
            vehmon.adminDivisionName = cbeCaptureDepartment.Text;
            vehmon.adminDivisionNumber = int.Parse(cbeRegion.Text);
            vehmon.vehInfoNum = 0;
            vehmon.tollNum = 0;
            vehmon.tollName = "";
            vehmon.plateColorNum = 0;
            vehmon.plateColor = "";
            vehmon.imageCount = 0;
            vehmon.imageName1 = captureFileName + vehmon.plateNumber + "_1.jpg";
            vehmon.imageName2 = captureFileName + vehmon.plateNumber + "_2.jpg";
            vehmon.imageName3 = captureFileName + vehmon.plateNumber + "_3.jpg";
            vehmon.imageName4 = "";
            vehmon.vedioName = "";
            vehmon.vehicleColor = "";
            vehmon.vehicleType = 0;
            vehmon.vehicleTypeName = "";
            vehmon.plateNumberType = "A";
            vehmon.countTime = 0;

            if (_airnoixCamera == null)
            {
                MessageBox.Show("此摄像头不存在");
                return;
            }
            if ((tollgate=LongChang_TollGateBusiness.Instance.GetTollGateInfoByCameraId(ref errMessage, _airnoixCamera.Id)) == null)
            {
                MessageBox.Show("没有对应的卡口信息");
                return;
            }

            vehmon.roadNumber = tollgate.roadNum;
            vehmon.roadName = tollgate.roadName;
            vehmon.redLightTime = Convert.ToDateTime(teCaptureTime.Text);

            int i;
            i = LongChang_VehMonBusiness.Instance.Insert(ref errMessage, vehmon);

            //将三张图片写入到磁盘中
            (treeListPicturesBefore.FocusedNode.GetValue(0) as Image).Save(vehmon.imageName1,System.Drawing.Imaging.ImageFormat.Jpeg);
            (treeListPicturesCurrent.FocusedNode.GetValue(0) as Image).Save(vehmon.imageName2,System.Drawing.Imaging.ImageFormat.Jpeg);
            (treeListPicturesAfter.FocusedNode.GetValue(0) as Image).Save(vehmon.imageName3,System.Drawing.Imaging.ImageFormat.Jpeg);
        }


        private void DeleteTempBmp()
        {
            try
            {
                foreach (string alTempFile in alTempFiles)
                {
                    if (File.Exists(alTempFile))
                    {
                        File.Delete(alTempFile);
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());
            }
        }
    }
}
