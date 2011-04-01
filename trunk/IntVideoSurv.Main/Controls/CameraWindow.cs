// Camera Vision
//
// Copyright ?Andrew Kirillov, 2005-2006
// andrew.kirillov@gmail.com
//
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Threading;
using IntVideoSurv.Business;
using IntVideoSurv.Business.HiK;

namespace CameraViewer
{
	/// <summary>
	/// Summary description for CameraWindow.
	/// </summary>
	public class CameraWindow : System.Windows.Forms.Control
	{
        private HikVideoServerCameraDriver camera = null;
		private bool	autosize = false;
		private bool	needSizeUpdate = false;
		private bool	firstFrame = true;

		// AutoSize property
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
        bool _clickMe = false;
        public bool ClickMe
        {
            get
            {
             return _clickMe   ;
            }
            set
            {
                _clickMe =value;
                this.Refresh();
            }
        }
		// Camera property
		[Browsable(false)]
        public HikVideoServerCameraDriver Camera
		{
			get { return camera; }
			set
			{
				// lock
				Monitor.Enter(this);

				// detach event
			 
				camera = value;
				needSizeUpdate = true;
				firstFrame = true;

				// atach event
			 

				// unlock
				Monitor.Exit(this);
			}
		}

	    private Image _currentImage;
	    public Image CurrentImage
	    {
	        set
            {
                _currentImage = value;
            //实际使用时才打开
                //    _currentImageGuid = Guid.NewGuid();
            }
            get
            {
                return _currentImage;
            }
	    }

	    private int _cameraID;
        public int CameraID
        {
            set
            {
                _cameraID = value;
            }
            get
            {
                return _cameraID;
            }
        }

	    public Guid CurrentImageGuid
	    {
            set
            {
                //实际使用时关闭
                _currentImageGuid = Guid.NewGuid();
            }
            get
            {
                return _currentImageGuid;
            }	        
	    }
	    private Guid _currentImageGuid;
		// Constructor
		public CameraWindow()
		{
			SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer |
				ControlStyles.ResizeRedraw | ControlStyles.UserPaint, true);
		}
        private void MyDrawReversibleRectangle(Rectangle rc)
        {
            

            ControlPaint.DrawReversibleFrame(rc,
                           Color.Green, FrameStyle.Dashed);

        }
		// Paint control
		protected override void OnPaint(PaintEventArgs pe)
		{
			if ((needSizeUpdate) || (firstFrame))
			{
				UpdatePosition();
				needSizeUpdate = false;
			}

			// lock
			Monitor.Enter(this);

            Graphics g = pe.Graphics;
            Rectangle	rc = this.ClientRectangle;
            Pen pen;
            //if (ClickMe)
            //{
                
                
            //    pen = new Pen(Color.Green, 3);
            //    g.DrawRectangle(pen, rc.X, rc.Y, rc.Width - 2, rc.Height - 2);
            //}
            //else
            //{
            //    pen = new Pen(Color.Black, 1);
            //    g.DrawRectangle(pen, rc.X, rc.Y, rc.Width - 1, rc.Height - 1);
            //}
            pen = new Pen(Color.Black, 1);
            if (!ClickMe)
            {
               
                g.DrawRectangle(pen, rc.X, rc.Y, rc.Width - 1, rc.Height - 1);
            }
			// draw rectangle
            
            //有图像的话画图像

		    if (_currentImage!=null)
		    {
                g.DrawImage(_currentImage, rc.X, rc.Y, rc.Width, rc.Height);

		    }
		    if (camera==null)
		    {
                Font drawFont = new Font("Arial", 8);
                SolidBrush drawBrush = new SolidBrush(Color.White);

                g.DrawString("连接中 ...", drawFont, drawBrush, new PointF(3, 3));

                drawBrush.Dispose();
                drawFont.Dispose();
            }


			pen.Dispose();

			// unlock
			Monitor.Exit(this);

			base.OnPaint(pe);
		}

		// update position and size of the control
		public void UpdatePosition()
		{
			// lock
			Monitor.Enter(this);

			if (autosize)
			{
				Rectangle	rc = this.Parent.ClientRectangle;
				int			width = 320;
				int			height = 240;

			 

				//
				this.SuspendLayout();
				this.Location = new Point((rc.Width - width - 2) / 2, (rc.Height - height - 2) / 2);
				this.Size = new Size(width + 2, height + 2);
				this.ResumeLayout();

			}
			// unlock
			Monitor.Exit(this);
		}

		// On new frame ready
		private void camera_NewFrame(object sender, System.EventArgs e)
		{
			Invalidate();
		}

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // CameraWindow
            // 
            this.Click += new System.EventHandler(this.CameraWindow_Click);
            this.ResumeLayout(false);

        }

        private void CameraWindow_Click(object sender, EventArgs e)
        {
            this.ClickMe = true;
        }
	}
}
