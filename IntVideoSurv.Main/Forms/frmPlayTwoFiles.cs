using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using CameraViewer.Player;
using DevExpress.XtraEditors;
using System.Threading;

namespace CameraViewer.Forms
{
    public partial class frmPlayTwoFiles : XtraForm
    {
        private IntPtr intPtr;
        private int frameWidth;
        private int frameHeight;
        private AirnoixPlayerState _previousState;
        private int maunulSteps = 0;
        private object locks = new object();
        public frmPlayTwoFiles()
        {
            InitializeComponent();
            if (!Directory.Exists(Properties.Settings.Default.CapturePictureTempPath))
            {
                Directory.CreateDirectory(Properties.Settings.Default.CapturePictureTempPath);
            }
            intPtr = AirnoixPlayer.Avdec_Init(panelControlPlay.Handle, 0, 512, 0);
            int ret = AirnoixPlayer.Avdec_SetFile(intPtr, @"V:\项目代码备份\凯智\修改的美赞美\bin\RecoderFile\View_202722.264", null, false);
            frameWidth = AirnoixPlayer.Avdec_GetImageWidth(intPtr);
            frameHeight = AirnoixPlayer.Avdec_GetImageHeight(intPtr);
            //trackBarControl1.Properties.Minimum = 1;
            //trackBarControl1.Properties.Maximum = AirnoixPlayer.Avdec_GetTotalFrames(intPtr);
            trackBarProgressing.Minimum = 0;
            trackBarProgressing.Maximum = AirnoixPlayer.Avdec_GetTotalFrames(intPtr);
            //MessageBox.Show(trackBarProgressing.Maximum.ToString());
        }
        public void PlayTheFiles(int start, int end)
        {
            
        }
        //播放
        private void buttonPlay_Click(object sender, EventArgs e)
        {
            /*int ret;
            ret = AirnoixPlayer.Avdec_Play(intPtr);
            MessageBox.Show("dd");
            trackBarProgressing.Maximum = AirnoixPlayer.Avdec_GetTotalFrames(intPtr); 
            ret = AirnoixPlayer.Avdec_Pause(intPtr);
            
            if (trackBarProgressing.Maximum > 0)
            {
                trackBarProgressing.Value = 10000;
                ret = AirnoixPlayer.Avdec_SetCurrentPosition(intPtr, trackBarProgressing.Value);
            }

            ret = AirnoixPlayer.Avdec_Play(intPtr);*/
            

            int ret;
            ret = AirnoixPlayer.Avdec_SetCurrentPosition(intPtr, trackBarProgressing.Value);
            ret = AirnoixPlayer.Avdec_Play(intPtr);
        }
        //关闭文件
        private void frmPlayTwoFiles_FormClosed(object sender, FormClosedEventArgs e)
        {
            int ret = AirnoixPlayer.Avdec_Done(intPtr);
        }
        //暂停
        private void buttonPause_Click(object sender, EventArgs e)
        {
            AirnoixPlayer.Avdec_Pause(intPtr);
        }
        //停止
        private void buttonStop_Click(object sender, EventArgs e)
        {
            trackBarProgressing.Value = trackBarProgressing.Minimum;
            AirnoixPlayer.Avdec_Stop(intPtr);
        }
        //拖动滚动条事件
        private void trackBarProgressing_Scroll(object sender, EventArgs e)
        {
            AirnoixPlayerState state = AirnoixPlayer.Avdec_GetCurrentState(intPtr);
            if ((state == AirnoixPlayerState.PLAY_STATE_PAUSE) || (state == AirnoixPlayerState.PLAY_STATE_STOP))
            {
                int ret = AirnoixPlayer.Avdec_SetCurrentPosition(intPtr, trackBarProgressing.Value);
                ret = AirnoixPlayer.Avdec_Play(intPtr);
                ret = AirnoixPlayer.Avdec_Pause(intPtr);
            }
        }
        private bool isTimerChanged;
        //滚动条随播放时间增长而移动事件
        private void timerPlay_Tick(object sender, EventArgs e)
        {
            try
            {
                if (AirnoixPlayer.Avdec_GetCurrentState(intPtr) == AirnoixPlayerState.PLAY_STATE_PLAY)
                {
                    int currentPos = AirnoixPlayer.Avdec_GetCurrentPosition(intPtr);
                    if (trackBarProgressing.Maximum == 0)
                    {
                        trackBarProgressing.Maximum = AirnoixPlayer.Avdec_GetTotalFrames(intPtr);
                    }
                    if (currentPos < trackBarProgressing.Minimum)
                    {
                        currentPos = trackBarProgressing.Minimum;
                    }
                    else if (currentPos > trackBarProgressing.Maximum)
                    {
                        currentPos = trackBarProgressing.Maximum;
                    }

                    trackBarProgressing.Value = currentPos;
                    Trace.WriteLine("Value=" + trackBarProgressing.Value);
                    isTimerChanged = true;
                }
            }
            catch (Exception ex)
            {

                Debug.WriteLine("Error:" + ex.ToString());
            }


        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            if (trackBarProgressing.Value == 1050)
            {
                int ret;
                ret = AirnoixPlayer.Avdec_CloseFile(intPtr);
                ret = AirnoixPlayer.Avdec_SetFile(intPtr, @"C:\Users\Administrator.ltyong-win7.000\Desktop\16-17-33_N(16).mkv", null, true);
                timer1.Enabled = false;
            }
        }

        private void button_show_Click(object sender, EventArgs e)
        {

            int ret;
            ret = AirnoixPlayer.Avdec_Play(intPtr);
            ret = AirnoixPlayer.Avdec_Pause(intPtr);
            MessageBox.Show("播放从1000到1050帧，然后重新播放另一个视频");
            trackBarProgressing.Maximum = AirnoixPlayer.Avdec_GetTotalFrames(intPtr);

            if (trackBarProgressing.Maximum > 0)
            {
                trackBarProgressing.Value = 1000;
                ret = AirnoixPlayer.Avdec_SetCurrentPosition(intPtr, trackBarProgressing.Value);
            }
            ret = AirnoixPlayer.Avdec_Play(intPtr);

        }

    }
}