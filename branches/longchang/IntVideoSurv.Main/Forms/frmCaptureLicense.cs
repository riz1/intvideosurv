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
using CameraViewer.Tools;

namespace CameraViewer.Forms
{
    public partial class frmCaptureLicense : XtraForm
    {


        private static readonly ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private const int PicNum = 5;
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
        private enum PlayState
        {
            FirstVideoState = 1,
            SecondVideoState = 2,
            ThirdVideoState = 3
        }
        private PlayState play_state;
        private RelatedFile _relatedFile; 

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
            //获取所有相关的视频文件
            _relatedFile = new RelatedFile(_airnoixCamera.Ip, 1, _airnoixCamera.BeginCaptureTime, Properties.Settings.Default.PreVideoSeconds);

            //_relatedFile = new RelatedFile();

            listBoxControl1.Items.Clear();
            if (_relatedFile.RelatedFile1 != null && File.Exists(_relatedFile.RelatedFile1))
            {
                listBoxControl1.Items.Add("1");
            }
            if(_relatedFile.RelatedFile2 != null && File.Exists(_relatedFile.RelatedFile2))
            {
                listBoxControl1.Items.Add("2");
            }
            listBoxControl1.Items.Add("3");

            intPtr = AirnoixPlayer.Avdec_Init(panelControlVideo.Handle, 0, 512, 0);
            int ret = 0;
            if (File.Exists(_airnoixCamera.VideoPath))
            {
                listBoxControl1.SelectedIndex = listBoxControl1.Items.Count - 1;
                PlayMyVideoFile();
            }
            trackBar1.Minimum = 0;
            trackBar1.Maximum = _totalFrames;
            timer1.Start();

        }

        private void PlayReletedFile2()
        {
            //FileInfo fi = new FileInfo(_relatedFile.RelatedFile1);
            //DateTime oldWriteDateTime = fi.LastWriteTime;
            //while (true)
            //{
            //    fi = new FileInfo(_relatedFile.RelatedFile1);
            //    if (fi.LastWriteTime == oldWriteDateTime)
            //    {
            //        break;
            //    }
            //    else
            //    {
            //        oldWriteDateTime = fi.LastWriteTime;
            //    }
            //    Thread.Sleep(40);
            //    if (UseWaitCursor == false)
            //    {
            //        UseWaitCursor = true;
            //    }

            //}
            int ret;
            video2FrameValid = false;
            ret = AirnoixPlayer.Avdec_CloseFile(intPtr);
            ret = AirnoixPlayer.Avdec_SetFile(intPtr, _relatedFile.RelatedFile2, null, true);
            ret = AirnoixPlayer.Avdec_Pause(intPtr);
            Thread.Sleep(40);
            _totalFrames = 0;
            int frames = AirnoixPlayer.Avdec_GetTotalFrames(intPtr);
            if (frames > _relatedFile.RelatedStartFramePosition2 + _relatedFile.RelatedFrames2)
            {
                ret = AirnoixPlayer.Avdec_SetCurrentPosition(intPtr, _relatedFile.RelatedStartFramePosition2);
                if (ret == 0)
                {
                    _totalFrames = _relatedFile.RelatedFrames2;
                    video2FrameValid = true;
                }
            }

            ret = AirnoixPlayer.Avdec_Play(intPtr);
            play_state = PlayState.SecondVideoState;
            trackBar1.Maximum = _totalFrames;

        }
        private void PlayReletedFile1()
        {
            //FileInfo fi = new FileInfo(_relatedFile.RelatedFile1);
            //DateTime oldWriteDateTime = fi.LastWriteTime;
            //while (true)
            //{
            //    fi = new FileInfo(_relatedFile.RelatedFile1);
            //    if (fi.LastWriteTime == oldWriteDateTime)
            //    {
            //        break;
            //    }
            //    else
            //    {
            //        oldWriteDateTime = fi.LastWriteTime;
            //    }
            //    Thread.Sleep(40);
            //    if (UseWaitCursor == false)
            //    {
            //        UseWaitCursor = true;
            //    }

            //}
            int ret;
            video1FrameValid = false;
            ret = AirnoixPlayer.Avdec_CloseFile(intPtr);
            ret = AirnoixPlayer.Avdec_SetFile(intPtr, _relatedFile.RelatedFile1, null, true);
            ret = AirnoixPlayer.Avdec_Pause(intPtr);
            Thread.Sleep(40);
            _totalFrames = 0;
            int frames = AirnoixPlayer.Avdec_GetTotalFrames(intPtr);
            if (frames > _relatedFile.RelatedStartFramePosition1 + _relatedFile.RelatedFrames1)
            {
                ret = AirnoixPlayer.Avdec_SetCurrentPosition(intPtr, _relatedFile.RelatedStartFramePosition1);
                if (ret==0)
                {
                    _totalFrames = _relatedFile.RelatedFrames1;
                    video1FrameValid = true;
                }
            }

            ret = AirnoixPlayer.Avdec_Play(intPtr);
            play_state = PlayState.FirstVideoState;
            trackBar1.Maximum = _totalFrames;
        }

        private bool video1FrameValid;
        private bool video2FrameValid;
        private void PlayMyVideoFile()
        {
            int ret;
            ret = AirnoixPlayer.Avdec_CloseFile(intPtr);
            ret = AirnoixPlayer.Avdec_SetFile(intPtr, _airnoixCamera.VideoPath, null, true);
            play_state = PlayState.ThirdVideoState;  
            _totalFrames =  GetFrames(_airnoixCamera.VideoPath);
            trackBar1.Maximum = _totalFrames;
        }

        private int GetFrames(string videofile)
        {
            IntPtr memoryHandle = new IntPtr(0x4321);
            IntPtr memoryIntPtr = AirnoixPlayer.Avdec_Init(memoryHandle,0, 512, 0);
            int ret = AirnoixPlayer.Avdec_SetFile(memoryIntPtr, videofile, null, true);
            Thread.Sleep(40);
            ret = AirnoixPlayer.Avdec_Pause(memoryIntPtr);
            frameWidth = AirnoixPlayer.Avdec_GetImageWidth(intPtr);
            frameHeight = AirnoixPlayer.Avdec_GetImageHeight(intPtr);
            int frames = AirnoixPlayer.Avdec_GetTotalFrames(memoryIntPtr);
            ret = AirnoixPlayer.Avdec_CloseFile(memoryIntPtr);
            ret = AirnoixPlayer.Avdec_Done(memoryIntPtr);
            return frames;
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
                treeListPicturesBefore.AppendNode(new[] { images[0], images[1], images[2], images[3], images[4] }, -1);
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
                int ret = 0;


                int currentPos = AirnoixPlayer.Avdec_GetCurrentPosition(intPtr);

                switch (play_state)
                {
                       case PlayState.FirstVideoState:
                        if (video1FrameValid)
                        {
                            trackBar1.Value = currentPos - _relatedFile.RelatedStartFramePosition1;
                        } 
                        else 
                        {
                            _totalFrames = AirnoixPlayer.Avdec_GetTotalFrames(intPtr);
                            trackBar1.Maximum = _totalFrames;
                        }
                        break;
                       case PlayState.SecondVideoState:
                        if (video2FrameValid)
                        {
                            trackBar1.Value = currentPos - _relatedFile.RelatedStartFramePosition2;
                        }
                        else 
                        {
                            _totalFrames = AirnoixPlayer.Avdec_GetTotalFrames(intPtr);
                            trackBar1.Maximum = _totalFrames;
                        }
                        break;
                       case PlayState.ThirdVideoState:
                        
                        if (_totalFrames != AirnoixPlayer.Avdec_GetTotalFrames(intPtr))
                        {
                            _totalFrames = AirnoixPlayer.Avdec_GetTotalFrames(intPtr);
                            trackBar1.Maximum = _totalFrames;
                        }
                        trackBar1.Value = currentPos; 
                        break;
                }
                //switch ()
                //{
                //    
                //        if (currentPos <= trackBar1.Maximum)
                //        {
                //            trackBar1.Value = currentPos;
                //        }
                //        if ((AirnoixPlayer.Avdec_GetCurrentState(intPtr)==AirnoixPlayerState.PLAY_STATE_STOP))
                //        {
                //            if (_relatedFile.RelatedFile2 != null && File.Exists(_relatedFile.RelatedFile2))
                //            {
                //                ret = AirnoixPlayer.Avdec_CloseFile(intPtr);
                //                ret = AirnoixPlayer.Avdec_SetFile(intPtr, _relatedFile.RelatedFile2, null, false);
                //                ret = AirnoixPlayer.Avdec_SetCurrentPosition(intPtr, _relatedFile.RelatedStartFramePosition2);
                //                ret = AirnoixPlayer.Avdec_Play(intPtr);
                //                play_state = PlayState.SecondVideoState;
                //            }
                //            else
                //            {
                //                ret = AirnoixPlayer.Avdec_CloseFile(intPtr);
                //                ret = AirnoixPlayer.Avdec_SetFile(intPtr, _airnoixCamera.VideoPath, null, true);
                //                play_state = PlayState.ThirdVideoState;
                //            }
                //        }
                //        break;
                //    case PlayState.SecondVideoState:
                //        if (_relatedFile.RelatedFrames1 + currentPos <= trackBar1.Maximum)
                //        {
                //            trackBar1.Value = _relatedFile.RelatedFrames1 + currentPos;
                //        }
                //        if ((currentPos > _relatedFile.RelatedStartFramePosition2 + _relatedFile.RelatedFrames2) || (AirnoixPlayer.Avdec_GetCurrentState(intPtr) == AirnoixPlayerState.PLAY_STATE_STOP))
                //        {
                //                ret = AirnoixPlayer.Avdec_CloseFile(intPtr);
                //                ret = AirnoixPlayer.Avdec_SetFile(intPtr, _airnoixCamera.VideoPath, null, true);
                //                play_state = PlayState.ThirdVideoState;
                //        }
                //        break;
                //    case PlayState.ThirdVideoState:
                //        if (_relatedFile.RelatedFrames1 + _relatedFile.RelatedFrames2 + currentPos <= trackBar1.Maximum)
                //        {
                //            trackBar1.Value = _relatedFile.RelatedFrames1 + _relatedFile.RelatedFrames2 + currentPos;
                //        }
                //        break;

                //}
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
            if (_airnoixCamera==null)
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
            if (_airnoixCamera == null)
            {
                MessageBox.Show("此摄像头不存在");
                return;
            }
            if ((tollgate = LongChang_TollGateBusiness.Instance.GetTollGateInfoByCameraId(ref errMessage, _airnoixCamera.Id)) == null)
            {
                comboBoxEditRoadName.Text = "未知";
            }
            else
            {
                comboBoxEditRoadName.Text = tollgate.roadName;                
            }


            if (_airnoixCamera == null) return;
            teCaptureTime.EditValue = _airnoixCamera.BeginCaptureTime == null
                                 ? DateTime.Now
                                 : _airnoixCamera.BeginCaptureTime;
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
            if (textEdit1.Text.Length < 7)
            {
                XtraMessageBox.Show("录入的车牌号不正确!");
                return;
            }
            LongChang_VehMonInfo vehmon = new LongChang_VehMonInfo();
            LongChang_TollGateInfo tollgate = new LongChang_TollGateInfo();
            LongChang_InvalidTypeInfo reason = new LongChang_InvalidTypeInfo();
            LongChang_UserVehMonInfo uservehmon = new LongChang_UserVehMonInfo();
            string captureFileName = Properties.Settings.Default.CapturePictureFilePath
                                     + @"\" + _airnoixCamera.BeginCaptureTime.ToString(@"yyyy\MM\dd")
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
            //vehmon.vehInfoNum = 0;//CLXXBH_SEQ.NEXTVAL
            vehmon.tollNum = 1000;
            vehmon.tollName = "测试路口";
            vehmon.plateColorNum = 0;
            vehmon.plateColor = "";
            vehmon.imageCount = 3;
            vehmon.imageName1 = captureFileName + _airnoixCamera.BeginCaptureTime.ToString("HHmmss") +"_" + vehmon.plateNumber + "_1.jpg";
            vehmon.imageName2 = captureFileName + _airnoixCamera.BeginCaptureTime.ToString("HHmmss") +"_" + vehmon.plateNumber + "_2.jpg";
            vehmon.imageName3 = captureFileName + _airnoixCamera.BeginCaptureTime.ToString("HHmmss") +"_" + vehmon.plateNumber + "_3.jpg";
            vehmon.imageName4 = "";
            vehmon.vedioName = "";
            vehmon.vedioName1 = "";
            vehmon.vedioName2 = "";
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
            (treeListPicturesBefore.FocusedNode.GetValue(0) as Image).Save(vehmon.imageName1,System.Drawing.Imaging.ImageFormat.Jpeg);
            (treeListPicturesCurrent.FocusedNode.GetValue(0) as Image).Save(vehmon.imageName2,System.Drawing.Imaging.ImageFormat.Jpeg);
            (treeListPicturesAfter.FocusedNode.GetValue(0) as Image).Save(vehmon.imageName3,System.Drawing.Imaging.ImageFormat.Jpeg);
            MessageBox.Show("保存成功");
            this.Close();
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

        private void listBoxControl1_DoubleClick(object sender, EventArgs e)
        {
            switch ((string)(listBoxControl1.Items[listBoxControl1.SelectedIndex]))
            {
                case "1":
                    PlayReletedFile1();
                    break;
                case "2":
                    PlayReletedFile2();
                    break;
                case "3":
                    PlayMyVideoFile();
                    break;
            }
        }

        private void frmCaptureLicense_KeyDown(object sender, KeyEventArgs e)
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
    }
}
