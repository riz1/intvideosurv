using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using CameraViewer.Player;
using DevExpress.XtraEditors;

namespace CameraViewer.Forms
{
    public partial class frmCaptureLicense : XtraForm
    {
        public frmCaptureLicense()
        {
            InitializeComponent();
            if (!Directory.Exists(Properties.Settings.Default.CapturePictureTempPath))
            {
                Directory.CreateDirectory(Properties.Settings.Default.CapturePictureTempPath);
            }
            intPtr = AirnoixPlayer.Avdec_Init(panelControlVideo.Handle, 0, 512, 0);
            int ret = AirnoixPlayer.Avdec_SetFile(intPtr, @"C:\123.AVI", null, false);
            //V:\项目代码备份\凯智\修改的美赞美\bin\RecoderFile\View_162801(new).avi
            frameWidth = AirnoixPlayer.Avdec_GetImageWidth(intPtr);
            frameHeight = AirnoixPlayer.Avdec_GetImageHeight(intPtr);
            //trackBarControl1.Properties.Minimum = 1;
            //trackBarControl1.Properties.Maximum = AirnoixPlayer.Avdec_GetTotalFrames(intPtr);
            //trackBar1.Minimum = 0;
           // trackBar1.Maximum = AirnoixPlayer.Avdec_GetTotalFrames(intPtr);
            //ret = AirnoixPlayer.Avdec_Play(intPtr);

        }

        public frmCaptureLicense(string videoPath)
        {
            InitializeComponent();
            if (!Directory.Exists(Properties.Settings.Default.CapturePictureTempPath))
            {
                Directory.CreateDirectory(Properties.Settings.Default.CapturePictureTempPath);
            }
            intPtr = AirnoixPlayer.Avdec_Init(panelControlVideo.Handle, 0, 512, 0);
            int ret = AirnoixPlayer.Avdec_SetFile(intPtr, videoPath, null, true);

            frameWidth = AirnoixPlayer.Avdec_GetImageWidth(intPtr);
            frameHeight = AirnoixPlayer.Avdec_GetImageHeight(intPtr);
            _totalFrames = AirnoixPlayer.Avdec_GetTotalFrames(intPtr);
            trackBar1.Minimum = 0;
            trackBar1.Maximum = _totalFrames; 


        }

        private IntPtr intPtr;
        private int frameWidth;
        private int frameHeight;
        private AirnoixPlayerState _previousState;
        private int maunulSteps = 0;
        private int _totalFrames;
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
        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                //播放第一段视频
                if(isfirstvideo==true)
                {
                    int currentPos = AirnoixPlayer.Avdec_GetCurrentPosition(intPtr);
                    if (_totalFrames == 0)
                    {
                        //int currentPos = AirnoixPlayer.Avdec_GetCurrentPosition(intPtr);
                         if (first == true)
                        {
                            tmpcount = currentPos;
                            first = false;
                        }
                        if (currentPos>=tmpcount)
                            currentPos -= tmpcount;

                       /* if (trackBar1.Maximum == 0)
                        {
                            //trackBar1.Maximum = AirnoixPlayer.Avdec_GetTotalFrames(intPtr);
                        }*/
                        if (currentPos < trackBar1.Minimum )
                        {
                            currentPos = trackBar1.Minimum;
                        }
                        else if (currentPos > trackBar1.Maximum )
                        {
                            currentPos = trackBar1.Maximum;
                        }
                        if (currentPos > 0)
                              trackBar1.Value = currentPos;
                        Trace.WriteLine("Value=" + trackBar1.Value);
                        isTimerChanged = true;
                    }
                }
                else
                {
                    if (AirnoixPlayer.Avdec_GetCurrentState(intPtr) == AirnoixPlayerState.PLAY_STATE_PLAY)
                    {
                        int currentPos2 = AirnoixPlayer.Avdec_GetCurrentPosition(intPtr);
                        if(isfirstvideo==false)
                            currentPos2 += changecount;
                        /*if (trackBar1.Maximum == 0)
                        {
                            //trackBar1.Maximum = AirnoixPlayer.Avdec_GetTotalFrames(intPtr);
                        }*/
                        if (currentPos2 < trackBar1.Minimum)
                        {
                            currentPos2 = trackBar1.Minimum;
                        }
                        else if (currentPos2 > trackBar1.Maximum)
                        {
                            currentPos2 = trackBar1.Maximum;
                        }

                        trackBar1.Value = currentPos2;
                        Trace.WriteLine("Value=" + trackBar1.Value);
                        isTimerChanged = true;
                    }
                }

            }
            catch (Exception ex)
            {
                
                Debug.WriteLine("Error:"+ex.ToString());
            }


        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            AirnoixPlayerState state = AirnoixPlayer.Avdec_GetCurrentState(intPtr);
            if ( state == AirnoixPlayerState.PLAY_STATE_STOP)
            {
                AirnoixPlayer.Avdec_Play(intPtr);
                AirnoixPlayer.Avdec_Pause(intPtr);
            }
            if ((state == AirnoixPlayerState.PLAY_STATE_PAUSE))
            {
                int ret = 0;//= AirnoixPlayer.Avdec_SetCurrentPosition(intPtr, trackBar1.Value);
                if ((trackBar1.Value - 1) % 30 == 0)
                {
                    ret = AirnoixPlayer.Avdec_SetCurrentPosition(intPtr, trackBar1.Value);
                }
                else
                {
                    ret = AirnoixPlayer.Avdec_SetCurrentPosition(intPtr, trackBar1.Value);
                    for (int i = 0; i < (trackBar1.Value - 1) % 30; i++)
                    {
                        ret = AirnoixPlayer.Avdec_StepFrame(intPtr, true);
                    }
                }            
            }

        }

        private void frmCaptureLicense_FormClosed(object sender, FormClosedEventArgs e)
        {
            int ret = AirnoixPlayer.Avdec_Done(intPtr);
        }


        private void buttonPlay_Click(object sender, EventArgs e)
        {
            int totalframes;
            int ret;
            int value_frame;
            totalframes=GetTotalFrames();
            trackBar1.Minimum = 0;
            trackBar1.Maximum = totalframes;
            ret = AirnoixPlayer.Avdec_SetFile(intPtr, @"C:\123.AVI", null, false);
            isfirstvideo = true;
            
            ret = AirnoixPlayer.Avdec_Play(intPtr);
            ret = AirnoixPlayer.Avdec_Pause(intPtr);
            if (trackBar1.Maximum > 0)
            {
                value_frame = 9924;//可更改
                MessageBox.Show("播放从9924到9924+1200帧，然后重新播放另一个视频");
                ret = AirnoixPlayer.Avdec_SetCurrentPosition(intPtr, value_frame);
                int mum = AirnoixPlayer.Avdec_GetCurrentPosition(intPtr);
            }
            ret = AirnoixPlayer.Avdec_Play(intPtr);
            
            timer1.Enabled = true;
            //timer2.Enabled = true;
           first = true;
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
        private  int GetTotalFrames()
        {
            int Maximum;
            int count;
            intPtr = AirnoixPlayer.Avdec_Init(panelControlVideo.Handle, 0, 512, 0);
            Maximum = 0;
            Maximum += 1200;//十五秒对应的帧数
            int ret = AirnoixPlayer.Avdec_SetFile(intPtr, @"C:\18-55-28.AVI", null, false);
            MessageBox.Show("加载第二个视频");
            ret = AirnoixPlayer.Avdec_Play(intPtr);
            MessageBox.Show("加载第二个视频");
                Maximum += AirnoixPlayer.Avdec_GetTotalFrames(intPtr); ;

           
            
            AirnoixPlayer.Avdec_Stop(intPtr);
            return Maximum;
        }
        private void timer2_Tick(object sender, EventArgs e)
        {

            if (trackBar1.Value >=1200 && trackBar1.Value <= 1600 && isfirstvideo == true)
            {
                int ret;
                ret = AirnoixPlayer.Avdec_CloseFile(intPtr);
                ret = AirnoixPlayer.Avdec_SetFile(intPtr, @"C:\18-55-28.avi", null, true);
               // AirnoixPlayer.Avdec_Play(intPtr);
                changecount = trackBar1.Value;
                isfirstvideo = false;
                timer2.Enabled = false;
            }
        }

    }
}
