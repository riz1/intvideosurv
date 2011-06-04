using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CameraViewer.Player;

namespace CameraViewer.Forms
{
    public partial class frmCaptureLicense : Form
    {
        public frmCaptureLicense()
        {
            InitializeComponent();
            if (!Directory.Exists(Properties.Settings.Default.CapturePictureTempPath))
            {
                Directory.CreateDirectory(Properties.Settings.Default.CapturePictureTempPath);
            }
            intPtr = AirnoixPlayer.Avdec_Init(panelControlVideo.Handle, 0, 512, 0);
            int ret = AirnoixPlayer.Avdec_SetFile(intPtr, @"V:\项目代码备份\凯智\修改的美赞美\bin\RecoderFile\View_162801(new).avi", null, true);
            
            frameWidth = AirnoixPlayer.Avdec_GetImageWidth(intPtr);
            frameHeight = AirnoixPlayer.Avdec_GetImageHeight(intPtr);
            //trackBarControl1.Properties.Minimum = 1;
            //trackBarControl1.Properties.Maximum = AirnoixPlayer.Avdec_GetTotalFrames(intPtr);
            trackBar1.Minimum = 0;
            trackBar1.Maximum = AirnoixPlayer.Avdec_GetTotalFrames(intPtr);
            ret = AirnoixPlayer.Avdec_Play(intPtr);

        }

        private IntPtr intPtr;
        private int frameWidth;
        private int frameHeight;
        private AirnoixPlayerState _previousState;
        private int maunulSteps = 0;
        private void simpleButtonPrevious_Click(object sender, EventArgs e)
        {
            treeListPicturesBefore.Nodes.Clear();
            Image[] images = GetImages();
            treeListPicturesBefore.AppendNode(new[] { images[0], images[1], images[2], images[3], images[4], images[5], images[6] }, -1);
        }

        private void simpleButtonCurrent_Click(object sender, EventArgs e)
        {
            treeListPicturesCurrent.Nodes.Clear();
            Image[] images = GetImages();
            treeListPicturesCurrent.AppendNode(new[] { images[0], images[1], images[2], images[3], images[4], images[5], images[6] }, -1);
        }

        private void simpleButtonLast_Click(object sender, EventArgs e)
        {
            treeListPicturesAfter.Nodes.Clear();
            Image[] images = GetImages();
            treeListPicturesAfter.AppendNode(new[] { images[0], images[1], images[2], images[3], images[4], images[5], images[6] }, -1);
        }

        private Image[] GetImages()
        {
            _previousState = AirnoixPlayer.Avdec_GetCurrentState(intPtr);

            int ret = AirnoixPlayer.Avdec_Pause(intPtr);
            int currentPos = AirnoixPlayer.Avdec_GetCurrentPosition(intPtr);
            if (currentPos >= 3)
            {
                ret = AirnoixPlayer.Avdec_StepFrame(intPtr, false);
                maunulSteps--;
                ret = AirnoixPlayer.Avdec_StepFrame(intPtr, false);
                maunulSteps--;
                ret = AirnoixPlayer.Avdec_StepFrame(intPtr, false);
                maunulSteps--;
            }
            if (AirnoixPlayer.Avdec_GetTotalFrames(intPtr) - currentPos <= 7)
            {
                for (int i = 0; i < AirnoixPlayer.Avdec_GetTotalFrames(intPtr) - currentPos + 1; i++)
                {
                    ret = AirnoixPlayer.Avdec_StepFrame(intPtr, false);
                    maunulSteps--;
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
                ret = AirnoixPlayer.Avdec_CapturePicture(intPtr, filename, fmt);
                ret = AirnoixPlayer.Avdec_Pause(intPtr);
                images[i] = Image.FromFile(filename);
                ret = AirnoixPlayer.Avdec_StepFrame(intPtr, true);
                maunulSteps++;

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
        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                if (AirnoixPlayer.Avdec_GetCurrentState(intPtr) == AirnoixPlayerState.PLAY_STATE_PLAY)
                {
                    int currentPos = AirnoixPlayer.Avdec_GetCurrentPosition(intPtr);
                    if (trackBar1.Maximum == 0)
                    {
                        trackBar1.Maximum = AirnoixPlayer.Avdec_GetTotalFrames(intPtr);
                    }
                    if (currentPos < trackBar1.Minimum)
                    {
                        currentPos = trackBar1.Minimum;
                    }
                    else if (currentPos > trackBar1.Maximum)
                    {
                        currentPos = trackBar1.Maximum;
                    }

                    trackBar1.Value = currentPos;
                    Trace.WriteLine("Value=" + trackBar1.Value);
                    isTimerChanged = true;
                }
            }
            catch (Exception ex)
            {
                
                Debug.WriteLine("Error:"+ex.ToString());
            }


        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            int ret = AirnoixPlayer.Avdec_SetCurrentPosition(intPtr, trackBar1.Value);
            ret = AirnoixPlayer.Avdec_Play(intPtr);
            AirnoixPlayer.Avdec_Pause(intPtr);
            

        }

        private void frmCaptureLicense_FormClosed(object sender, FormClosedEventArgs e)
        {
            int ret = AirnoixPlayer.Avdec_Done(intPtr);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int ret = AirnoixPlayer.Avdec_SetCurrentPosition(intPtr, 360);
            string fmt = string.Format("BMP {0:0000}{1:0000}{2:0000}", frameWidth, frameHeight, 24);
            string filename =  "C:\\" + Guid.NewGuid() + ".bmp";
            ret = AirnoixPlayer.Avdec_Play(intPtr);
            ret = AirnoixPlayer.Avdec_CapturePicture(intPtr, filename, fmt);
            ret = AirnoixPlayer.Avdec_Pause(intPtr);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int ret = AirnoixPlayer.Avdec_SetCurrentPosition(intPtr, 100);
            string fmt = string.Format("BMP {0:0000}{1:0000}{2:0000}", frameWidth, frameHeight, 24);
            string filename = "C:\\" + Guid.NewGuid() + ".bmp";
            ret = AirnoixPlayer.Avdec_Play(intPtr);
            ret = AirnoixPlayer.Avdec_CapturePicture(intPtr, filename, fmt);
            ret = AirnoixPlayer.Avdec_Pause(intPtr);
        }


    }
}
