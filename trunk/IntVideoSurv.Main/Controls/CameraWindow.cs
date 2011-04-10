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
using System.Xml;
using IntVideoSurv.Entity;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using DevExpress.XtraEditors;

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
        //private List<MyShape> ListXMLShapes = new List<MyShape>();
        private Pen arrowpen;
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
		    else
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

            GetDrawingXmlInfo(g);//获取相应xml信息,并画图

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

        private void GetDrawingXmlInfo(Graphics g)
        {
            string errMessage = "";
            //ListXMLShapes.Clear();
            XmlNodeList xml_lines,xml_arrows,xml_rects,xml_regions;
            XmlDocument xmlDoc = new XmlDocument();
            RecognizerInfo ri = RecognizerBusiness.Instance.GetRecognizerInfoByCameraId(ref errMessage, 76);
            if (ri==null)
            {
                if (XtraMessageBox.Show("对不起，您使用的照片没有对应的识别器，请另选", "提示", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
                {
                    return;
                }
            }
            string name = @"c:\" + ri.Id.ToString() + "." + "0" + "admin" + ".xml";
            xmlDoc.Load(@name);
                //直线
            xml_lines = xmlDoc.SelectSingleNode("/pr/cameras/camera/lines").ChildNodes;
            foreach (XmlNode lineitem in xml_lines)
            {

                MyLine line = new MyLine();
                line.MyPen = new Pen(Color.Red, 1);
                XmlElement xe = (XmlElement)lineitem;
                line.P1.X = Convert.ToInt32(xe.GetAttribute("X1"));
                line.P1.Y = Convert.ToInt32(xe.GetAttribute("Y1"));
                line.P2.X = Convert.ToInt32(xe.GetAttribute("X2"));
                line.P2.Y = Convert.ToInt32(xe.GetAttribute("Y2"));
                line.MyPen.Color = ColorTranslator.FromHtml(xe.GetAttribute("PenColor"));
                line.MyPen.Width = Convert.ToInt32(xe.GetAttribute("PenWidth"));
                g.DrawLine(line.MyPen, line.P1, line.P2);
                //ListXMLShapes.Add(line);
            }
            //箭头
            xml_arrows = xmlDoc.SelectSingleNode("/pr/cameras/camera/arrows").ChildNodes;
            foreach (XmlNode arrowitem in xml_arrows)
            {

                MyArrow arrow = new MyArrow();
                arrow.MyPen = new Pen(Color.Red, 1);
                XmlElement xa = (XmlElement)arrowitem;
                arrow.P1.X = Convert.ToInt32(xa.GetAttribute("X1"));
                arrow.P1.Y = Convert.ToInt32(xa.GetAttribute("Y1"));
                arrow.P2.X = Convert.ToInt32(xa.GetAttribute("X2"));
                arrow.P2.Y = Convert.ToInt32(xa.GetAttribute("Y2"));
                arrow.MyPen.Color = ColorTranslator.FromHtml(xa.GetAttribute("PenColor"));
                arrow.MyPen.Width = Convert.ToInt32(xa.GetAttribute("PenWidth"));
                g.DrawLine(arrow.MyPen, arrow.P1, arrow.P2);
                //ListXMLShapes.Add(arrow);
            }
            //矩形
            xml_rects = xmlDoc.SelectSingleNode("/pr/cameras/camera/rects").ChildNodes;
            foreach (XmlNode rectitem in xml_rects)
            {

                MyRect rect = new MyRect();
                rect.MyPen = new Pen(Color.Red, 1);
                XmlElement xr = (XmlElement)rectitem;
                rect.P1.X = Convert.ToInt32(xr.GetAttribute("X"));
                rect.P1.Y = Convert.ToInt32(xr.GetAttribute("Y"));
                rect.Width = Convert.ToInt32(xr.GetAttribute("W"));
                rect.Height = Convert.ToInt32(xr.GetAttribute("H"));
                rect.MyPen.Color = ColorTranslator.FromHtml(xr.GetAttribute("PenColor"));
                rect.MyPen.Width = Convert.ToInt32(xr.GetAttribute("PenWidth"));
                g.DrawRectangle(rect.MyPen,rect.P1.X,rect.P1.Y,rect.Width,rect.Height);
                //ListXMLShapes.Add(rect);
            }
            //多边形
            xml_regions = xmlDoc.SelectSingleNode("/pr/cameras/camera/regions").ChildNodes;
            foreach (XmlNode regionitem in xml_regions)
            {

                MyPoly poly = new MyPoly();
                poly.MyPen = new Pen(Color.Red, 1);
                XmlElement xp = (XmlElement)regionitem;
                poly.MyPen.Color = ColorTranslator.FromHtml(xp.GetAttribute("PenColor"));
                poly.MyPen.Width = Convert.ToInt32(xp.GetAttribute("PenWidth"));
                XmlNodeList pointlist = regionitem.ChildNodes;
                foreach (XmlNode pitem in pointlist)
                {
                    Point p = new Point();
                    XmlElement test = (XmlElement)pitem;
                    p.X = Convert.ToInt32(test.GetAttribute("X"));
                    p.Y = Convert.ToInt32(test.GetAttribute("Y"));
                    poly.ListPoint.Add(p);
                }
                //IsFinished=true
                poly.IsFinished = true;
                g.DrawPolygon(poly.MyPen, poly.ListPoint.ToArray());
                //ListXMLShapes.Add(poly);
            }
            
        }
        
	}
}
