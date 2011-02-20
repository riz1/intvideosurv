using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using IntVideoSurv.Business;
using System.Threading;

namespace CameraViewer.Controls
{
    public partial class CameraPlay : UserControl
    {
        private DeviceDriver camera = null;
        private bool autosize = false;
        private bool needSizeUpdate = false;
        private bool firstFrame = true;
        public event EventHandler  ClickVideo;
        public event EventHandler DoubleClickVideo;


        [DefaultValue(false)]
        public bool AutoSize
        {
            get { return autosize; }
            set
            {
                autosize = value;
                UpdatePosition();
            }
        }
        public IntPtr VideoHandle
        {
            get { return pnVideo.Handle; }

        }
        bool _clickMe = false;
        public bool ClickMe
        {
            get
            {
                return _clickMe;
            }
            set
            {
                _clickMe = value;
                this.Refresh();
            }
        }
        // Camera property
        [Browsable(false)]
        public DeviceDriver Camera
        {
            get { return camera; }
            set
            {
                // lock
                Monitor.Enter(this);

                // detach event
                if (camera != null)
                {
                    camera.NewFrame -= new EventHandler(camera_NewFrame);
                }

                camera = value;
                needSizeUpdate = true;
                firstFrame = true;

                // atach event
                if (camera != null)
                {
                    camera.NewFrame += new EventHandler(camera_NewFrame);
                }

                // unlock
                Monitor.Exit(this);
            }
        }

        public CameraPlay()
        {
            InitializeComponent();
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer |
                ControlStyles.ResizeRedraw | ControlStyles.UserPaint, true);
        }

      
       
        // On new frame ready
        private void camera_NewFrame(object sender, System.EventArgs e)
        {
            Invalidate();
        }

        private void pnVideo_DoubleClick(object sender, EventArgs e)
        {
            if (DoubleClickVideo != null)
            {
                DoubleClickVideo(this, e);
            }

        }
        private void pnVideo_Click(object sender, EventArgs e)
        {
            if (ClickVideo != null)
            {
                ClickVideo(this, e);
            }
            this.ClickMe = true;


        }

        private void CameraPlay_Paint(object sender, PaintEventArgs pe)
        {
            if ((needSizeUpdate) || (firstFrame))
            {
                UpdatePosition();
                needSizeUpdate = false;
            }


            Monitor.Enter(pnVideo);
            Graphics g = pnVideo.CreateGraphics();
            Rectangle rc = this.ClientRectangle;
            Pen pen;
            if (ClickMe)
            {
                pen = new Pen(Color.Green, 3);
                g.DrawRectangle(pen, rc.X, rc.Y, rc.Width - 2, rc.Height - 2);
            }
            else
            {
                pen = new Pen(Color.Black, 1);
                g.DrawRectangle(pen, rc.X, rc.Y, rc.Width - 1, rc.Height - 1);
            }

            if (camera != null)
            {
                camera.Lock();

                // draw frame
                if (camera.LastFrame != null)
                {
                    g.DrawImage(camera.LastFrame, rc.X + 1, rc.Y + 1, rc.Width - 3, rc.Height - 3);
                    firstFrame = false;
                }
                else
                {
                    // Create font and brush
                    Font drawFont = new Font("Arial", 12);
                    SolidBrush drawBrush = new SolidBrush(Color.White);

                    g.DrawString("连接中 ...", drawFont, drawBrush, new PointF(5, 5));

                    drawBrush.Dispose();
                    drawFont.Dispose();
                }

                camera.Unlock();
            }

            pen.Dispose();

            // unlock
            Monitor.Exit(pnVideo);

            base.OnPaint(pe);
        }

        // update position and size of the control
        public void UpdatePosition()
        {
            // lock
            Monitor.Enter(this);

            if (autosize)
            {
                Rectangle rc = this.Parent.ClientRectangle;
                int width = 320;
                int height = 240;

                if (camera != null)
                {
                    camera.Lock();

                    // get frame dimension
                    if (camera.LastFrame != null)
                    {
                        width = camera.LastFrame.Width;
                        height = camera.LastFrame.Height;
                    }
                    camera.Unlock();
                }

                //
                this.SuspendLayout();
                this.Location = new Point((rc.Width - width - 2) / 2, (rc.Height - height - 2) / 2);
                this.Size = new Size(width + 2, height + 2);
                this.ResumeLayout();

            }
            // unlock
            Monitor.Exit(this);
        }
    }
}
