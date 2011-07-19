using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Reactive.Linq;
using System.Threading;
using System.Windows.Forms;
using CameraViewer.Player;
using DevExpress.XtraEditors;
using DevExpress.XtraTreeList.Nodes;
using IntVideoSurv.Entity;
//using IntVideoSurv.Business;
using log4net;
using CameraViewer.Tools;
using System.Threading.Tasks;

namespace CameraViewer.Forms
{
    public partial class frmCaptureLicense : XtraForm
    {
        private static readonly ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private const int PicNum = 5;
        private DateTime _captureTime;
        private Model.Camera _cameraSpec;

        private IList<HistroyVideoFile> _videoFiles = new BindingList<HistroyVideoFile>();
        private string _videoFilePath;

        public frmCaptureLicense()
        {
            InitializeComponent();
            // LoadBaseInfo();
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

        protected virtual void InitializeVideoList()
        {
            var listbox = new ListBoxControl();
            listbox.Dock = DockStyle.Fill;
            listbox.DoubleClick += this.listBoxControl1_DoubleClick;
            this.videoListContainer.Controls.Add(listbox);

            //获取所有相关的视频文件
            if (!DesignMode)
            {
                _relatedFile = new RelatedFile(_airnoixCamera.Ip, 1, _airnoixCamera.BeginCaptureTime, Properties.Settings.Default.PreVideoSeconds);

                listbox.Items.Clear();
                if (_relatedFile.RelatedFile1 != null && File.Exists(_relatedFile.RelatedFile1))
                {
                    listbox.Items.Add("1");
                }
                if (_relatedFile.RelatedFile2 != null && File.Exists(_relatedFile.RelatedFile2))
                {
                    listbox.Items.Add("2");
                }
                listbox.Items.Add("3");
            }


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
            : this()
        {
            _airnoixCamera = airnoixCamera;

            if (!Directory.Exists(Properties.Settings.Default.CapturePictureTempPath))
            {
                Directory.CreateDirectory(Properties.Settings.Default.CapturePictureTempPath);
            }
            if (!Directory.Exists(Properties.Settings.Default.CapturePictureFilePath))
            {
                Directory.CreateDirectory(Properties.Settings.Default.CapturePictureFilePath);
            }

            intPtr = AirnoixPlayer.Avdec_Init(panelControlVideo.Handle, 0, 512, 0);
            int ret = 0;
            if (File.Exists(_airnoixCamera.VideoPath))
            {
                //listBoxVideoFiles.SelectedIndex = listBoxVideoFiles.Items.Count - 1;
                _videoFilePath = _airnoixCamera.VideoPath;
                PlayMyVideoFile();
            }


            trackBar1.Minimum = 0;
            trackBar1.Maximum = _totalFrames;
            timerForUpdatingTrack.Start();
        }

        private void PlayReletedFile2()
        {
            int ret;
            video2FrameValid = false;
            ret = AirnoixPlayer.Avdec_CloseFile(intPtr);
            ret = AirnoixPlayer.Avdec_SetFile(intPtr, _relatedFile.RelatedFile2, null, true);
            ret = AirnoixPlayer.Avdec_Pause(intPtr);
            Thread.Sleep(40);
            _totalFrames = AirnoixPlayer.Avdec_GetTotalFrames(intPtr);

            ret = AirnoixPlayer.Avdec_Play(intPtr);
            play_state = PlayState.SecondVideoState;
            trackBar1.Maximum = _totalFrames;

        }
        private void PlayReletedFile1()
        {

            int ret;
            video1FrameValid = false;
            ret = AirnoixPlayer.Avdec_CloseFile(intPtr);
            ret = AirnoixPlayer.Avdec_SetFile(intPtr, _relatedFile.RelatedFile1, null, false);
            ret = AirnoixPlayer.Avdec_Pause(intPtr);
            Thread.Sleep(40);
            _totalFrames = AirnoixPlayer.Avdec_GetTotalFrames(intPtr);

            ret = AirnoixPlayer.Avdec_Play(intPtr);
            play_state = PlayState.FirstVideoState;
            trackBar1.Maximum = _totalFrames;
        }

        public void PlayVideoFile(string videoFilePath)
        {
            _videoFilePath = videoFilePath;
            PlayMyVideoFile();
        }

        private bool video1FrameValid;
        private bool video2FrameValid;
        private void PlayMyVideoFile()
        {
            int ret;
            ret = AirnoixPlayer.Avdec_CloseFile(intPtr);
            ret = AirnoixPlayer.Avdec_SetFile(intPtr, _videoFilePath, null, false);
            play_state = PlayState.ThirdVideoState;
            Thread.Sleep(40);
            frameWidth = AirnoixPlayer.Avdec_GetImageWidth(intPtr);
            frameHeight = AirnoixPlayer.Avdec_GetImageHeight(intPtr);
            _totalFrames = AirnoixPlayer.Avdec_GetTotalFrames(intPtr);
            ret = AirnoixPlayer.Avdec_Play(intPtr);

            trackBar1.Minimum = 0;
            trackBar1.Maximum = _totalFrames;
            trackBar1.Enabled = true;
            timerForUpdatingTrack.Start();
        }

        private int GetFrames(string videofile)
        {
            IntPtr memoryHandle = new IntPtr(0x4321);
            IntPtr memoryIntPtr = AirnoixPlayer.Avdec_Init(memoryHandle, 0, 512, 0);
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
        private double frameInterval = 1;
        private void simpleButtonPrevious_Click(object sender, EventArgs e)
        {
            if (sender == simpleButtonPrevious)
            {
                CaptureImages(treeListPicturesBefore);
                return;
            }

            if (sender == simpleButtonCurrent)
            {
                CaptureImages(treeListPicturesCurrent);
                return;
            }

            if (sender == simpleButtonLast)
            {
                CaptureImages(treeListPicturesAfter);
                return;
            }
        }

        private void CaptureImages(DevExpress.XtraTreeList.TreeList treeList)
        {
            try
            {

                frameInterval = double.Parse(cbeFrameInterval.Text);
                treeList.Nodes.Clear();
                var node = treeList.AppendNode(new[]
                                                   { 
                                                       repositoryItemPictureEdit8.InitialImage,
                                                       repositoryItemPictureEdit8.InitialImage,
                                                       repositoryItemPictureEdit8.InitialImage,
                                                       repositoryItemPictureEdit8.InitialImage,
                                                       repositoryItemPictureEdit8.InitialImage,
                                                   }, -1);

                var images = GetImages(frameInterval);
                int count = 0;
                images.ObserveOn(this).Subscribe(bmp => { node[count++] = bmp; });
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());
                return;
            }
        }

        private IObservable<Image> GetImages(double interval)
        {
            var timer = Observable.Interval(TimeSpan.FromSeconds(interval), System.Reactive.Concurrency.Scheduler.ThreadPool).Take(5);
            var images = timer.Select(t =>
                                          {
                                              var guid = Guid.NewGuid().ToString();
                                              AirnoixPlayer.Avdec_CapturePicture(intPtr, guid, "BMP");
                                              var img = AForge.Imaging.Image.FromFile(guid);
                                              File.Delete(guid);
                                              return (Image)img;
                                          });

            return images;
        }

        private void treeListPicturesCurrent_MouseClick(object sender, MouseEventArgs e)
        {

            var treeList = sender as DevExpress.XtraTreeList.TreeList;
            if (treeList != null)
            {
                //我添加的一句代码
                if (treeList.FocusedNode == null) return;
                if (treeList.FocusedNode.GetValue(treeList.FocusedColumn.AbsoluteIndex) == null)
                {
                    return;
                }

                var img = treeList.FocusedNode.GetValue(treeList.FocusedColumn.AbsoluteIndex) as Image;
                if (img != null)
                {
                    pictureEditSelectedPicture.Image = new Bitmap(img);
                    this.ActiveControl = this.pictureEditSelectedPicture.PictureBox;
                }

            }
        }


        private bool isTimerChanged;
        private bool isfirstvideo = true;
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
                if (currentPos > _totalFrames || _totalFrames == 0)
                {
                    _totalFrames = AirnoixPlayer.Avdec_GetTotalFrames(intPtr);
                    trackBar1.Maximum = _totalFrames;
                }
                if (currentPos > trackBar1.Maximum)
                {
                    trackBar1.Value = trackBar1.Maximum;
                }
                else
                {
                    trackBar1.Value = currentPos;
                }


            }
            catch (Exception ex)
            {

                Debug.WriteLine("Error:" + ex.ToString());
            }


        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            int mum;
            int count;
            AirnoixPlayerState state = AirnoixPlayer.Avdec_GetCurrentState(intPtr);
            if (state == AirnoixPlayerState.PLAY_STATE_PLAY)
            {
                int ret = AirnoixPlayer.Avdec_Pause(intPtr);
                ret = AirnoixPlayer.Avdec_SetCurrentPosition(intPtr, trackBar1.Value);
                ret = AirnoixPlayer.Avdec_Play(intPtr);
            }
            else if (state == AirnoixPlayerState.PLAY_STATE_STOP)
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
            if (StartPlay == true)
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
            timerForUpdatingTrack.Enabled = true;
            timer2.Enabled = true;
            first = true;
            FirstLoad = true;
            IsEnd = false;
            isfirstvideo = true;
            StartPlay = true;

        }
        private int GetTotalFrames()
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
            timerForUpdatingTrack.Enabled = true;
            timer2.Enabled = true;
            first = true;
            FirstLoad = true;
            IsEnd = false;
        }


        #region 抓拍证据(从CaptureLicense控件移植过来)

        //        private static string staticErrMessage = "";
        //        private static Dictionary<string, LongChang_LptColorInfo> _listLongChang_LptColorInfo =
        //    LongChang_LptColorBusiness.Instance.GetAllLptColorInfo(ref staticErrMessage);
        //        private static Dictionary<string, LongChang_LptTypeInfo> _listLongChang_LptTypeInfo =
        //            LongChang_LptTypeBusiness.Instance.GetAllLptTypeInfo(ref staticErrMessage);
        //        private static Dictionary<string, LongChang_TollGateInfo> _listLongChang_TollGateInfo =
        //    LongChang_TollGateBusiness.Instance.GetAllTollGateInfo(ref staticErrMessage);
        //        private static Dictionary<string, LongChang_VehColorInfo> _listLongChang_VehColorInfo =
        //    LongChang_VehColorBusiness.Instance.GetAllVehColorInfo(ref staticErrMessage);
        //        private static Dictionary<string, LongChang_VehTypeInfo> _listLongChang_VehTypeInfo =
        //    LongChang_VehTypeBusiness.Instance.GetAllVehTypeInfo(ref staticErrMessage);

        //        private static Dictionary<string, LongChang_RegionInfo> _listLongChang_RegionInfo =
        //LongChang_RegionBusiness.Instance.GetAllRegionInfo(ref staticErrMessage);
        //        private static Dictionary<string, LongChang_CaptureDepartmentInfo> _listLongChang_CaptureDepartmentInfo =
        //LongChang_CaptureDepartmentBusiness.Instance.GetAllCaptureDepartmentInfo(ref staticErrMessage);
        //        private static Dictionary<string, LongChang_InvalidTypeInfo> _listLongChang_InvalidTypeInfo =
        //LongChang_InvalidTypeBusiness.Instance.GetAllInvalidTypeInfo(ref staticErrMessage);


        //private void LoadBaseInfo()
        //{

        //    cbeRegion.Properties.Items.Clear();
        //    foreach (var v in _listLongChang_RegionInfo)
        //    {
        //        cbeRegion.Properties.Items.Add(v.Value.RegionName);
        //    }
        //    if (cbeRegion.Properties.Items.Count > 0)
        //    {
        //        cbeRegion.EditValue = cbeRegion.Properties.Items[0];
        //    }

        //    cbeCaptureDepartment.Properties.Items.Clear();
        //    foreach (var v in _listLongChang_CaptureDepartmentInfo)
        //    {
        //        cbeCaptureDepartment.Properties.Items.Add(v.Value.CaptureDepartmentName);
        //    }
        //    if (cbeCaptureDepartment.Properties.Items.Count > 0)
        //    {
        //        cbeCaptureDepartment.EditValue = cbeCaptureDepartment.Properties.Items[0];
        //    }

        //    if (_airnoixCamera == null)
        //    {
        //        return;
        //    }
        //    comboBoxEditRoadName.Properties.Items.Clear();
        //    foreach (var v in _listLongChang_TollGateInfo)
        //    {
        //        bool isexisted = false;
        //        foreach (var VARIABLE in comboBoxEditRoadName.Properties.Items)
        //        {
        //            if (VARIABLE.ToString() == v.Value.roadName)
        //            {
        //                isexisted = true;
        //                break;
        //            }
        //        }
        //        if (!isexisted)
        //        {
        //            comboBoxEditRoadName.Properties.Items.Add(v.Value.roadName);
        //        }

        //    }
        //    if (comboBoxEditRoadName.Properties.Items.Count > 0)
        //    {
        //        comboBoxEditRoadName.EditValue = comboBoxEditRoadName.Properties.Items[0];
        //    }
        //    LongChang_TollGateInfo tollgate = new LongChang_TollGateInfo();
        //    if (_airnoixCamera == null)
        //    {
        //        MessageBox.Show("此摄像头不存在");
        //        return;
        //    }
        //    if ((tollgate = LongChang_TollGateBusiness.Instance.GetTollGateInfoByCameraId(ref errMessage, _airnoixCamera.Id)) == null)
        //    {
        //        comboBoxEditRoadName.Text = "未知";
        //    }
        //    else
        //    {
        //        comboBoxEditRoadName.Text = tollgate.roadName;
        //    }


        //    if (_airnoixCamera == null) return;
        //    teCaptureTime.EditValue = _airnoixCamera.BeginCaptureTime == default(DateTime)
        //                         ? DateTime.Now
        //                         : _airnoixCamera.BeginCaptureTime;
        //}

        #endregion
        private string errMessage = "";
        private async void buttonSave_Click(object sender, EventArgs e)
        {

            if (treeListPicturesBefore.FocusedNode == null || treeListPicturesCurrent.FocusedNode == null || treeListPicturesAfter.FocusedNode == null)
            {
                XtraMessageBox.Show("三张照片未完全生成!");
                return;
            }
            if (textEditPlateNumber.Text.Length < 7)
            {
                XtraMessageBox.Show("录入的车牌号不正确!");
                return;
            }
            if (_airnoixCamera == null)
            {
                MessageBox.Show("此摄像头不存在");
                return;
            }

            var camera = Model.Repository.Instance.GetCamera(_airnoixCamera.Id.ToString());
            if (camera == null)
            {
                MessageBox.Show("没有对应的卡口信息");
                return;
            }

            _cameraSpec = camera;
            _captureTime = _airnoixCamera.BeginCaptureTime != default(DateTime) ? _airnoixCamera.BeginCaptureTime : DateTime.Now;

            this.UseWaitCursor = true;

            try
            {
                await UploadImages();
                SaveCaptureRecord();

                AirnoixPlayer.Avdec_Stop(intPtr);
                AirnoixPlayer.Avdec_CloseFile(intPtr);

                MessageBox.Show(this, "保存成功。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (System.Net.WebException ex)
            {
                MessageBox.Show(this, "保存记录时发生错误\r\n\r\n" + ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.UseWaitCursor = false;
            }
        }

        private async Task UploadImages()
        {
            var images = GetImageArray();
            await UploadImagesAsync(images);
            //image1 = AddTextInImage(image1, vehmon.tollName, 18, Color.White, 8, 46);
            //image2 = AddTextInImage(image2, vehmon.tollName, 18, Color.White, 8, 46);
            //image3 = AddTextInImage(image3, vehmon.tollName, 18, Color.White, 8, 46);
        }

        private void SaveCaptureRecord()
        {
            var images = GetImageArray();
            var record = new Model.TogVehmon();
            //地点信息
            record.KKBH = _cameraSpec.KaKouNo;
            record.KKMC = _cameraSpec.KakouName;
            record.FXBH = _cameraSpec.DirectionNo;
            record.FXMC = _cameraSpec.DirectionName;
            record.CDBH = _cameraSpec.LaneNo;
            record.CDMC = _cameraSpec.LaneName;
            //事件
            record.WZYY = (string)punishReason.EditValue;
            //时间
            record.JGSK = _captureTime;
            record.TJRQ = Model.TimeConverter.ToTongJiRiQi(_captureTime);
            //车牌信息
            record.HPHM = (string)textEditPlateNumber.EditValue;
            var lprType = (Model.LprType)lookUpEditLprType.EditValue;
            record.HPZL = lprType.HPZLDM;
            record.HPZLMC = lprType.HPMC;
            //图片
            record.TXMC1 = Path.GetFileName(images[0].Item2);
            record.TXMC2 = Path.GetFileName(images[1].Item2);
            record.TXMC3 = Path.GetFileName(images[2].Item2);

            record.Save();
        }

        private Tuple<Image, string>[] GetImageArray()
        {
            //图片
            var image1 = treeListPicturesBefore.FocusedNode.GetValue(0) as Image;
            var image2 = treeListPicturesCurrent.FocusedNode.GetValue(0) as Image;
            var image3 = treeListPicturesAfter.FocusedNode.GetValue(0) as Image;
            var image1Path = GetRelativeImagePath(_captureTime, _cameraSpec, 1);
            var image2Path = GetRelativeImagePath(_captureTime, _cameraSpec, 2);
            var image3Path = GetRelativeImagePath(_captureTime, _cameraSpec, 3);

            return new[]
                       {
                           new Tuple<Image, string>(image1, image1Path),
                           new Tuple<Image, string>(image2, image2Path),
                           new Tuple<Image, string>(image3, image3Path)
                       };
        }

        private async Task UploadImagesAsync(IEnumerable<Tuple<Image, string>> images)
        {
            foreach (var tuple in images)
            {
                await new FtpService().UploadImageAsync(tuple.Item1, tuple.Item2);
            }
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
            var lb = (sender as ListBoxControl);
            switch ((string)(lb.Items[lb.SelectedIndex]))
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
            if (e.Alt && e.KeyCode == Keys.A)
            {
                //simpleButtonPrevious_Click(treeListPicturesBefore, null);
            }
            else if (e.Alt && e.KeyCode == Keys.S)
            {
                //simpleButtonPrevious_Click(treeListPicturesCurrent, null);
            }
            else if (e.Alt && e.KeyCode == Keys.D)
            {
                //simpleButtonPrevious_Click(treeListPicturesAfter, null);
            }
        }

        private void treeListPicturesBefore_FocusedColumnChanged(object sender, DevExpress.XtraTreeList.FocusedColumnChangedEventArgs e)
        {

        }

        private void pictureEditSelectedPicture_DoubleClick_1(object sender, EventArgs e)
        {
            if (pictureEditSelectedPicture.Image != null)
            {
                frmFullsizePicture ffp = new frmFullsizePicture(pictureEditSelectedPicture.Image);
                ffp.Show();
            }
        }

        private string GetRelativeImagePath(DateTime captureTime, Model.Camera captureFrom, int index)
        {
            return string.Format("{0:d4}/{1:d2}/{2:d2}/{3}-{4:d4}{5:d2}{6:d2}{7:d2}{8:d2}{9:d2}-{10}.jpg",
                                 captureTime.Year, captureTime.Month, captureTime.Day,
                                 captureFrom.LaneNo,
                                 captureTime.Year, captureTime.Month, captureTime.Day, captureTime.Hour,
                                 captureTime.Minute, captureTime.Second,
                                 index);
        }

        private void frmCaptureLicense_Load(object sender, EventArgs e)
        {
            InitializeVideoList();
        }
    }
}
