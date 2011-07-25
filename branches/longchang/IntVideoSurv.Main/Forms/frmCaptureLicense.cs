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
using DevExpress.XtraEditors.Controls;
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

        private IList<HistroyVideoFile> _videoFiles = new BindingList<HistroyVideoFile>();
        private string _videoFilePath;


        private Model.Camera _cameraSpec;
        public Model.Camera CameraSpec
        {
            get { return _cameraSpec; }
            set
            {
                _cameraSpec = value;
                UpdateLocationInfo();
            }
        }

        private DateTime _captureTime;
        public DateTime CaptureTime
        {
            get { return _captureTime; }
            set
            {
                _captureTime = value;
                UpdateCaptureTime();
            }
        }


        public frmCaptureLicense()
        {
            InitializeComponent();
            if (!Directory.Exists(Properties.Settings.Default.CapturePictureTempPath))
            {
                Directory.CreateDirectory(Properties.Settings.Default.CapturePictureTempPath);
            }
            if (!Directory.Exists(Properties.Settings.Default.CapturePictureFilePath))
            {
                Directory.CreateDirectory(Properties.Settings.Default.CapturePictureFilePath);
            }
            _playerHandle = AirnoixPlayer.Avdec_Init(panelControlVideo.Handle, 0, 512, 0);

            trackBar1.Minimum = 0;
            trackBar1.Maximum = GetTotalFrames();
            StartPlay = true;

        }

        protected void ShowBusyMessage(string message)
        {
            busyIndicator.Text = message;
            busyIndicator.Visible = true;
        }

        protected void HideBusyMessage()
        {
            busyIndicator.Visible = false;
        }

        protected virtual void InitializeVideoList()
        {
            var listbox = new ListBoxControl();
            listbox.DisplayMember = "Item1";
            listbox.Dock = DockStyle.Fill;
            listbox.DoubleClick += this.listBoxControl1_DoubleClick;
            this.videoListContainer.Controls.Add(listbox);

            var videoList = new List<Tuple<string, string>>();
            listbox.DataSource = videoList;

            //获取所有相关的视频文件
            if (!DesignMode)
            {
                _relatedFile = new RelatedFile(_airnoixCamera.Ip, 1, _airnoixCamera.BeginCaptureTime, Properties.Settings.Default.PreVideoSeconds);

                listbox.Items.Clear();
                if (_relatedFile.RelatedFile1 != null && File.Exists(_relatedFile.RelatedFile1))
                {
                    var item1 = new Tuple<string, string>("1", _relatedFile.RelatedFile1);
                    videoList.Add(item1);
                }
                if (_relatedFile.RelatedFile2 != null && File.Exists(_relatedFile.RelatedFile2))
                {
                    var item2 = new Tuple<string, string>("2", _relatedFile.RelatedFile2);
                    videoList.Add(item2);
                }

                var item3 = new Tuple<string, string>("3", _airnoixCamera.VideoPath);
                videoList.Add(item3);
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
            if (airnoixCamera == null) throw new ArgumentNullException("airnoixCamera");
            _airnoixCamera = airnoixCamera;

            if (!DesignMode)
            {
                CameraSpec = Model.Repository.Instance.GetCamera(_airnoixCamera.Id.ToString());
            }

            CaptureTime = _airnoixCamera.BeginCaptureTime != default(DateTime) ? _airnoixCamera.BeginCaptureTime : DateTime.Now;

            if (!Directory.Exists(Properties.Settings.Default.CapturePictureTempPath))
            {
                Directory.CreateDirectory(Properties.Settings.Default.CapturePictureTempPath);
            }
            if (!Directory.Exists(Properties.Settings.Default.CapturePictureFilePath))
            {
                Directory.CreateDirectory(Properties.Settings.Default.CapturePictureFilePath);
            }

            int ret = 0;
            if (File.Exists(_airnoixCamera.VideoPath))
            {
                _videoFilePath = _airnoixCamera.VideoPath;
                SetCurrentVideoFile();
                Play();
            }
        }



        public void PlayVideoFile(string videoFilePath)
        {
            _videoFilePath = videoFilePath;
            SetCurrentVideoFile();
            Play();
        }

        private bool video1FrameValid;
        private bool video2FrameValid;


        public void SetCurrentVideoFile()
        {
            AirnoixPlayer.Avdec_Stop(_playerHandle);
            AirnoixPlayer.Avdec_CloseFile(_playerHandle);
            AirnoixPlayer.Avdec_SetFile(_playerHandle, _videoFilePath, null, true);

            play_state = PlayState.ThirdVideoState;
            Thread.Sleep(400);

            trackBar1.Minimum = 0;
            trackBar1.Maximum = AirnoixPlayer.Avdec_GetTotalFrames(_playerHandle);
            trackBar1.Value = 0;

            trackBar1.Enabled = true;
        }

        private void UpdatePlayerPosition()
        {
            if (_playerHandle != IntPtr.Zero)
            {
                var pos = AirnoixPlayer.Avdec_GetCurrentPosition(_playerHandle);
                if (pos >= trackBar1.Minimum && pos <= trackBar1.Maximum)
                {
                    trackBar1.Value = pos;
                }
            }

        }

        public void Play()
        {
            if (_playerHandle != IntPtr.Zero)
            {
                AirnoixPlayer.Avdec_Play(_playerHandle);
                timerForUpdatingTrack.Start();
            }
        }

        public void Pause()
        {
            if (_playerHandle != IntPtr.Zero)
            {
                AirnoixPlayer.Avdec_Pause(_playerHandle);
                timerForUpdatingTrack.Stop();
            }
        }

        public void Stop()
        {
            if (_playerHandle != IntPtr.Zero)
            {
                AirnoixPlayer.Avdec_Stop(_playerHandle);
                timerForUpdatingTrack.Stop();
            }
        }

        public void SetPosition(int position)
        {
            if (_playerHandle != IntPtr.Zero)
            {
                AirnoixPlayer.Avdec_SetCurrentPosition(_playerHandle, position);
            }
        }

        private int GetFrames(string videofile)
        {
            IntPtr memoryHandle = new IntPtr(0x4321);
            IntPtr memoryIntPtr = AirnoixPlayer.Avdec_Init(memoryHandle, 0, 512, 0);
            int ret = AirnoixPlayer.Avdec_SetFile(memoryIntPtr, videofile, null, true);
            Thread.Sleep(40);
            ret = AirnoixPlayer.Avdec_Pause(memoryIntPtr);
            int frames = AirnoixPlayer.Avdec_GetTotalFrames(memoryIntPtr);
            ret = AirnoixPlayer.Avdec_CloseFile(memoryIntPtr);
            ret = AirnoixPlayer.Avdec_Done(memoryIntPtr);
            return frames;
        }

        private AirnoixCamera _airnoixCamera;
        private IntPtr _playerHandle;
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
                                              var res = AirnoixPlayer.Avdec_CapturePicture(_playerHandle, guid, "BMP");
                                              if (File.Exists(guid))
                                              {
                                                  var img = AForge.Imaging.Image.FromFile(guid);
                                                  File.Delete(guid);
                                                  return (Image)img;
                                              }

                                              return null;
                                          }).SkipWhile(i => i == null);

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
            UpdatePlayerPosition();
        }

        private void frmCaptureLicense_FormClosed(object sender, FormClosedEventArgs e)
        {
            int ret = AirnoixPlayer.Avdec_Done(_playerHandle);
            //删除临时BMP文件
            DeleteTempBmp();
        }


        private void buttonPlay_Click(object sender, EventArgs e)
        {
            Play();
        }

        private void buttonPause_Click(object sender, EventArgs e)
        {
            Pause();
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            Stop();
        }

        private int GetTotalFrames()
        {
            int Maximum;
            int count;

            Maximum = 0;
            Maximum += Change_Frame;//十五秒对应的帧数
            int ret = AirnoixPlayer.Avdec_SetFile(_playerHandle, @"C:\18-55-28.AVI", null, false);

            Thread.Sleep(1000);
            ret = AirnoixPlayer.Avdec_Play(_playerHandle);
            Thread.Sleep(1000);
            Maximum += AirnoixPlayer.Avdec_GetTotalFrames(_playerHandle);
            AirnoixPlayer.Avdec_CloseFile(_playerHandle);
            return Maximum;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            //try
            //{
            //    AirnoixPlayerState state = AirnoixPlayer.Avdec_GetCurrentState(_playerHandle);
            //    if (trackBar1.Value >= Change_Frame && trackBar1.Value <= Change_Frame + 100 && isfirstvideo == true && state == AirnoixPlayerState.PLAY_STATE_PLAY)
            //    {
            //        int ret;
            //        ret = AirnoixPlayer.Avdec_CloseFile(_playerHandle);
            //        ret = AirnoixPlayer.Avdec_SetFile(_playerHandle, @"C:\18-55-28.avi", null, true);
            //        changecount = trackBar1.Value;
            //        isfirstvideo = false;
            //        timer2.Enabled = false;
            //    }
            //}
            //catch (Exception ex)
            //{

            //}

        }

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
            if (CameraSpec == null)
            {
                MessageBox.Show("此摄像头不存在");
                return;
            }


            this.UseWaitCursor = true;
            Pause();

            try
            {
                ShowBusyMessage("正在保存记录...");
                await UploadImages();
                SaveCaptureRecord();
                MessageBox.Show(this, "保存成功。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();

            }
            catch (WebException ex)
            {
                MessageBox.Show(this, "保存记录时发生错误\r\n\r\n" + ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.UseWaitCursor = false;
                HideBusyMessage();
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
            record.KKBH = CameraSpec.KaKouNo;
            record.KKMC = CameraSpec.KakouName;
            record.FXBH = CameraSpec.DirectionNo;
            record.FXMC = CameraSpec.DirectionName;
            record.CDBH = CameraSpec.LaneNo;
            record.CDMC = CameraSpec.LaneName;
            //事件
            record.WZYY = (string)punishReason.EditValue;
            //时间
            record.JGSK = CaptureTime;
            record.TJRQ = Model.TimeConverter.ToTongJiRiQi(CaptureTime);
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
            var image1Path = GetRelativeImagePath(CaptureTime, _cameraSpec, 1);
            var image2Path = GetRelativeImagePath(CaptureTime, _cameraSpec, 2);
            var image3Path = GetRelativeImagePath(CaptureTime, _cameraSpec, 3);

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
            var item = lb.SelectedItem as Tuple<string, string>;
            _videoFilePath = item.Item2;
            SetCurrentVideoFile();
            Play();
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

        private void UpdateLocationInfo()
        {
            if (CameraSpec != null)
            {
                var dept = Model.Repository.Instance.GetDepartment(CameraSpec.RegionNo);
                if (dept != null)
                {
                    cbeRegion.EditValue = dept.XZQH;
                }

                var tolGate = Model.Repository.Instance.GetTollGate(CameraSpec.LaneNo);
                if (tolGate != null)
                {
                    comboBoxEditRoadName.EditValue = tolGate.KKMC;
                }

                var org = Model.Repository.Instance.GetOrganization(CameraSpec.OrgNo);
                if (org != null)
                {
                    cbeCaptureDepartment.EditValue = org.ORGNAME;
                }
            }
        }

        private void UpdateCaptureTime()
        {
            teCaptureTime.EditValue = CaptureTime;
        }

        private void trackBar1_MouseDown(object sender, MouseEventArgs e)
        {
            Pause();
        }

        private void trackBar1_MouseUp(object sender, MouseEventArgs e)
        {
            SetPosition(trackBar1.Value);
            Play();
        }
    }
}
