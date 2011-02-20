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
using IntVideoSurv.Entity;
using IntVideoSurv.Business;
using CameraViewer.Controls;

namespace CameraViewer
{
    /// <summary>
    /// Summary description for Multiplexer.
    /// </summary>
    public class Multiplayer : System.Windows.Forms.Panel
    {
        private const int MaxRows = 5;
        private const int MaxCols = 5;
        private CameraPlay[,] camWindows;

        private bool fitToWindow = false;
        private bool singleCameraMode = true;
        private bool camerasVisible = false;

        private int rows = 1;
        private int cols = 1;
        private int cellWidth = 320;
        private int cellHeight = 240;

        private CameraPlay lastClicked;
        private CameraPlay doubleClicked;
        private CameraViewer.Controls.CameraPlay cameraPlay1;
        private CameraViewer.Controls.CameraPlay cameraPlay2;
        private CameraViewer.Controls.CameraPlay cameraPlay3;
        private CameraViewer.Controls.CameraPlay cameraPlay4;
        private CameraViewer.Controls.CameraPlay cameraPlay5;
        private CameraViewer.Controls.CameraPlay cameraPlay6;
        private CameraViewer.Controls.CameraPlay cameraPlay7;
        private CameraViewer.Controls.CameraPlay cameraPlay8;
        private CameraViewer.Controls.CameraPlay cameraPlay9;
        private CameraViewer.Controls.CameraPlay cameraPlay10;
        private CameraViewer.Controls.CameraPlay cameraPlay11;
        private CameraViewer.Controls.CameraPlay cameraPlay12;
        private CameraViewer.Controls.CameraPlay cameraPlay13;
        private CameraViewer.Controls.CameraPlay cameraPlay14;
        private CameraViewer.Controls.CameraPlay cameraPlay15;
        private CameraViewer.Controls.CameraPlay cameraPlay16;
        private CameraViewer.Controls.CameraPlay cameraPlay17;
        private CameraViewer.Controls.CameraPlay cameraPlay18;
        private CameraViewer.Controls.CameraPlay cameraPlay19;
        private CameraViewer.Controls.CameraPlay cameraPlay20;
        private CameraViewer.Controls.CameraPlay cameraPlay21;
        private CameraViewer.Controls.CameraPlay cameraPlay22;
        private CameraViewer.Controls.CameraPlay cameraPlay23;
        private CameraViewer.Controls.CameraPlay cameraPlay24;
        private CameraViewer.Controls.CameraPlay cameraPlay25;
    
        public delegate void MyCurrentCamera(bool isFullScreen,CameraInfo camera);
        public event MyCurrentCamera DoubleCamera;



        // public event CameraEventHandler NewFrame;
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        // FitToWindow property
        [DefaultValue(false)]
        public bool FitToWindow
        {
            get { return fitToWindow; }
            set
            {
                fitToWindow = value;

                if ((camWindows[0, 0].AutoSize = (!fitToWindow && singleCameraMode)) == true)
                {
                    camWindows[0, 0].UpdatePosition();
                }
                else
                {
                    UpdateSize();
                }
            }
        }
        // SingleCameraMode property
        [DefaultValue(true)]
        public bool SingleCameraMode
        {
            get { return singleCameraMode; }
            set
            {
                singleCameraMode = value;
                if (!fitToWindow)
                    camWindows[0, 0].AutoSize = value;
            }
        }
        // CamerasVisible property
        [DefaultValue(false)]
        public bool CamerasVisible
        {
            get { return camerasVisible; }
            set
            {
                camerasVisible = value;

                // show/hide all cameras
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        camWindows[i, j].Visible = value;
                    }
                }
            }
        }
        // Rows property
        [DefaultValue(1)]
        public int Rows
        {
            get { return rows; }
            set
            {
                rows = Math.Max(1, Math.Min(MaxRows, value));
                UpdateVisiblity();
                UpdateSize();
            }
        }
        // Cols property
        [DefaultValue(1)]
        public int Cols
        {
            get { return cols; }
            set
            {
                cols = Math.Max(1, Math.Min(MaxCols, value));
                UpdateVisiblity();
                UpdateSize();
            }
        }
        // CellWidth
        [DefaultValue(320)]
        public int CellWidth
        {
            get { return cellWidth; }
            set
            {
                cellWidth = Math.Max(50, Math.Min(800, value));
                UpdateSize();
            }
        }
        // CellHeight
        [DefaultValue(240)]
        public int CellHeight
        {
            get { return cellHeight; }
            set
            {
                cellHeight = Math.Max(50, Math.Min(800, value));
                UpdateSize();
            }
        }
        // Context menu for cameras windows
        [DefaultValue(null)]
        public ContextMenu CamerasContextMenu
        {
            get { return camWindows[0, 0].ContextMenu; }
            set
            {
                for (int i = 0; i < MaxRows; i++)
                {
                    for (int j = 0; j < MaxCols; j++)
                    {
                        camWindows[i, j].ContextMenu = value;
                    }
                }
            }
        }
        // Camera of the last click
        [Browsable(false)]
        public CameraInfo ContextCamera
        {
            get { return (lastClicked == null) ? null : lastClicked.Camera.CurrentCamera; }
        }

        [Browsable(false)]
        public CameraInfo DoubleContextCamera
        {
            get { return (doubleClicked == null) ? null : doubleClicked.Camera.CurrentCamera; }
        }

        public DeviceDriver GetCurrentCameraDriver
        {
            get { return (lastClicked == null) ? null : lastClicked.Camera; }
        }

        // Constructors
        public Multiplayer()
        {
            // This call is required by the Windows.Forms Form Designer.
            InitializeComponent();

            // TODO: Add any initialization after the InitForm call
            camWindows = new CameraPlay[MaxRows, MaxCols];

            // row 1
            camWindows[0, 0] = cameraPlay1;
            camWindows[0, 1] = cameraPlay2;
            camWindows[0, 2] = cameraPlay3;
            camWindows[0, 3] = cameraPlay4;
            camWindows[0, 4] = cameraPlay5;
            // row 2
            camWindows[1, 0] = cameraPlay6;
            camWindows[1, 1] = cameraPlay7;
            camWindows[1, 2] = cameraPlay8;
            camWindows[1, 3] = cameraPlay9;
            camWindows[1, 4] = cameraPlay10;
            // row 3
            camWindows[2, 0] = cameraPlay11;
            camWindows[2, 1] = cameraPlay12;
            camWindows[2, 2] = cameraPlay13;
            camWindows[2, 3] = cameraPlay14;
            camWindows[2, 4] = cameraPlay15;
            // row 4
            camWindows[3, 0] = cameraPlay16;
            camWindows[3, 1] = cameraPlay17;
            camWindows[3, 2] = cameraPlay18;
            camWindows[3, 3] = cameraPlay19;
            camWindows[3, 4] = cameraPlay20;
            // row 5
            camWindows[4, 0] = cameraPlay21;
            camWindows[4, 1] = cameraPlay22;
            camWindows[4, 2] = cameraPlay23;
            camWindows[4, 3] = cameraPlay24;
            camWindows[4, 4] = cameraPlay25;
        }

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code
        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cameraPlay1 = new CameraViewer.Controls.CameraPlay();
            this.cameraPlay2 = new CameraViewer.Controls.CameraPlay();
            this.cameraPlay3 = new CameraViewer.Controls.CameraPlay();
            this.cameraPlay4 = new CameraViewer.Controls.CameraPlay();
            this.cameraPlay5 = new CameraViewer.Controls.CameraPlay();
            this.cameraPlay6 = new CameraViewer.Controls.CameraPlay();
            this.cameraPlay7 = new CameraViewer.Controls.CameraPlay();
            this.cameraPlay8 = new CameraViewer.Controls.CameraPlay();
            this.cameraPlay9 = new CameraViewer.Controls.CameraPlay();
            this.cameraPlay10 = new CameraViewer.Controls.CameraPlay();
            this.cameraPlay11 = new CameraViewer.Controls.CameraPlay();
            this.cameraPlay12 = new CameraViewer.Controls.CameraPlay();
            this.cameraPlay13 = new CameraViewer.Controls.CameraPlay();
            this.cameraPlay14 = new CameraViewer.Controls.CameraPlay();
            this.cameraPlay15 = new CameraViewer.Controls.CameraPlay();
            this.cameraPlay16 = new CameraViewer.Controls.CameraPlay();
            this.cameraPlay17 = new CameraViewer.Controls.CameraPlay();
            this.cameraPlay18 = new CameraViewer.Controls.CameraPlay();
            this.cameraPlay19 = new CameraViewer.Controls.CameraPlay();
            this.cameraPlay20 = new CameraViewer.Controls.CameraPlay();
            this.cameraPlay21 = new CameraViewer.Controls.CameraPlay();
            this.cameraPlay22 = new CameraViewer.Controls.CameraPlay();
            this.cameraPlay23 = new CameraViewer.Controls.CameraPlay();
            this.cameraPlay24 = new CameraViewer.Controls.CameraPlay();
            this.cameraPlay25 = new CameraViewer.Controls.CameraPlay();
            this.SuspendLayout();
            // 
            // cameraPlay1
            // 
            this.cameraPlay1.Camera = null;
            this.cameraPlay1.ClickMe = false;
            this.cameraPlay1.Location = new System.Drawing.Point(0, 0);
            this.cameraPlay1.Name = "cameraPlay1";
            this.cameraPlay1.Size = new System.Drawing.Size(266, 182);
            this.cameraPlay1.TabIndex = 0;
            this.cameraPlay1.ClickVideo += new System.EventHandler(this.cameraPlay_Click);
            this.cameraPlay1.DoubleClickVideo += new System.EventHandler(this.cameraPlay_DoubleClickVideo);
            // 
            // cameraPlay2
            // 
            this.cameraPlay2.Camera = null;
            this.cameraPlay2.ClickMe = false;
            this.cameraPlay2.Location = new System.Drawing.Point(0, 0);
            this.cameraPlay2.Name = "cameraPlay2";
            this.cameraPlay2.Size = new System.Drawing.Size(266, 182);
            this.cameraPlay2.TabIndex = 0;
            this.cameraPlay2.ClickVideo += new System.EventHandler(this.cameraPlay_Click);
            this.cameraPlay2.DoubleClickVideo += new System.EventHandler(this.cameraPlay_DoubleClickVideo);
            // 
            // cameraPlay3
            // 
            this.cameraPlay3.Camera = null;
            this.cameraPlay3.ClickMe = false;
            this.cameraPlay3.Location = new System.Drawing.Point(0, 0);
            this.cameraPlay3.Name = "cameraPlay3";
            this.cameraPlay3.Size = new System.Drawing.Size(266, 182);
            this.cameraPlay3.TabIndex = 0;
            this.cameraPlay3.ClickVideo += new System.EventHandler(this.cameraPlay_Click);
            this.cameraPlay3.DoubleClickVideo += new System.EventHandler(this.cameraPlay_DoubleClickVideo);
            // 
            // cameraPlay4
            // 
            this.cameraPlay4.Camera = null;
            this.cameraPlay4.ClickMe = false;
            this.cameraPlay4.Location = new System.Drawing.Point(0, 0);
            this.cameraPlay4.Name = "cameraPlay4";
            this.cameraPlay4.Size = new System.Drawing.Size(266, 182);
            this.cameraPlay4.TabIndex = 0;
            this.cameraPlay4.ClickVideo += new System.EventHandler(this.cameraPlay_Click);
            this.cameraPlay4.DoubleClickVideo += new System.EventHandler(this.cameraPlay_DoubleClickVideo);
            // 
            // cameraPlay5
            // 
            this.cameraPlay5.Camera = null;
            this.cameraPlay5.ClickMe = false;
            this.cameraPlay5.Location = new System.Drawing.Point(0, 0);
            this.cameraPlay5.Name = "cameraPlay5";
            this.cameraPlay5.Size = new System.Drawing.Size(266, 182);
            this.cameraPlay5.TabIndex = 0;
            this.cameraPlay5.ClickVideo += new System.EventHandler(this.cameraPlay_Click);
            this.cameraPlay5.DoubleClickVideo += new System.EventHandler(this.cameraPlay_DoubleClickVideo);
            // 
            // cameraPlay6
            // 
            this.cameraPlay6.Camera = null;
            this.cameraPlay6.ClickMe = false;
            this.cameraPlay6.Location = new System.Drawing.Point(0, 0);
            this.cameraPlay6.Name = "cameraPlay6";
            this.cameraPlay6.Size = new System.Drawing.Size(266, 182);
            this.cameraPlay6.TabIndex = 0;
            this.cameraPlay6.ClickVideo += new System.EventHandler(this.cameraPlay_Click);
            this.cameraPlay6.DoubleClickVideo += new System.EventHandler(this.cameraPlay_DoubleClickVideo);
            // 
            // cameraPlay7
            // 
            this.cameraPlay7.Camera = null;
            this.cameraPlay7.ClickMe = false;
            this.cameraPlay7.Location = new System.Drawing.Point(0, 0);
            this.cameraPlay7.Name = "cameraPlay7";
            this.cameraPlay7.Size = new System.Drawing.Size(266, 182);
            this.cameraPlay7.TabIndex = 0;
            this.cameraPlay7.ClickVideo += new System.EventHandler(this.cameraPlay_Click);
            this.cameraPlay7.DoubleClickVideo += new System.EventHandler(this.cameraPlay_DoubleClickVideo);
            // 
            // cameraPlay8
            // 
            this.cameraPlay8.Camera = null;
            this.cameraPlay8.ClickMe = false;
            this.cameraPlay8.Location = new System.Drawing.Point(0, 0);
            this.cameraPlay8.Name = "cameraPlay8";
            this.cameraPlay8.Size = new System.Drawing.Size(266, 182);
            this.cameraPlay8.TabIndex = 0;
            this.cameraPlay8.ClickVideo += new System.EventHandler(this.cameraPlay_Click);
            this.cameraPlay8.DoubleClickVideo += new System.EventHandler(this.cameraPlay_DoubleClickVideo);
            // 
            // cameraPlay9
            // 
            this.cameraPlay9.Camera = null;
            this.cameraPlay9.ClickMe = false;
            this.cameraPlay9.Location = new System.Drawing.Point(0, 0);
            this.cameraPlay9.Name = "cameraPlay9";
            this.cameraPlay9.Size = new System.Drawing.Size(266, 182);
            this.cameraPlay9.TabIndex = 0;
            this.cameraPlay9.ClickVideo += new System.EventHandler(this.cameraPlay_Click);
            this.cameraPlay9.DoubleClickVideo += new System.EventHandler(this.cameraPlay_DoubleClickVideo);
            // 
            // cameraPlay10
            // 
            this.cameraPlay10.Camera = null;
            this.cameraPlay10.ClickMe = false;
            this.cameraPlay10.Location = new System.Drawing.Point(0, 0);
            this.cameraPlay10.Name = "cameraPlay10";
            this.cameraPlay10.Size = new System.Drawing.Size(266, 182);
            this.cameraPlay10.TabIndex = 0;
            this.cameraPlay10.ClickVideo += new System.EventHandler(this.cameraPlay_Click);
            this.cameraPlay10.DoubleClickVideo += new System.EventHandler(this.cameraPlay_DoubleClickVideo);
            // 
            // cameraPlay11
            // 
            this.cameraPlay11.Camera = null;
            this.cameraPlay11.ClickMe = false;
            this.cameraPlay11.Location = new System.Drawing.Point(0, 0);
            this.cameraPlay11.Name = "cameraPlay11";
            this.cameraPlay11.Size = new System.Drawing.Size(266, 182);
            this.cameraPlay11.TabIndex = 0;
            this.cameraPlay11.ClickVideo += new System.EventHandler(this.cameraPlay_Click);
            this.cameraPlay11.DoubleClickVideo += new System.EventHandler(this.cameraPlay_DoubleClickVideo);
            // 
            // cameraPlay12
            // 
            this.cameraPlay12.Camera = null;
            this.cameraPlay12.ClickMe = false;
            this.cameraPlay12.Location = new System.Drawing.Point(0, 0);
            this.cameraPlay12.Name = "cameraPlay12";
            this.cameraPlay12.Size = new System.Drawing.Size(266, 182);
            this.cameraPlay12.TabIndex = 0;
            this.cameraPlay12.ClickVideo += new System.EventHandler(this.cameraPlay_Click);
            this.cameraPlay12.DoubleClickVideo += new System.EventHandler(this.cameraPlay_DoubleClickVideo);
            // 
            // cameraPlay13
            // 
            this.cameraPlay13.Camera = null;
            this.cameraPlay13.ClickMe = false;
            this.cameraPlay13.Location = new System.Drawing.Point(0, 0);
            this.cameraPlay13.Name = "cameraPlay13";
            this.cameraPlay13.Size = new System.Drawing.Size(266, 182);
            this.cameraPlay13.TabIndex = 0;
            this.cameraPlay13.ClickVideo += new System.EventHandler(this.cameraPlay_Click);
            this.cameraPlay13.DoubleClickVideo += new System.EventHandler(this.cameraPlay_DoubleClickVideo);
            // 
            // cameraPlay14
            // 
            this.cameraPlay14.Camera = null;
            this.cameraPlay14.ClickMe = false;
            this.cameraPlay14.Location = new System.Drawing.Point(0, 0);
            this.cameraPlay14.Name = "cameraPlay14";
            this.cameraPlay14.Size = new System.Drawing.Size(266, 182);
            this.cameraPlay14.TabIndex = 0;
            this.cameraPlay14.ClickVideo += new System.EventHandler(this.cameraPlay_Click);
            this.cameraPlay14.DoubleClickVideo += new System.EventHandler(this.cameraPlay_DoubleClickVideo);
            // 
            // cameraPlay15
            // 
            this.cameraPlay15.Camera = null;
            this.cameraPlay15.ClickMe = false;
            this.cameraPlay15.Location = new System.Drawing.Point(0, 0);
            this.cameraPlay15.Name = "cameraPlay15";
            this.cameraPlay15.Size = new System.Drawing.Size(266, 182);
            this.cameraPlay15.TabIndex = 0;
            this.cameraPlay15.ClickVideo += new System.EventHandler(this.cameraPlay_Click);
            this.cameraPlay15.DoubleClickVideo += new System.EventHandler(this.cameraPlay_DoubleClickVideo);
            // 
            // cameraPlay16
            // 
            this.cameraPlay16.Camera = null;
            this.cameraPlay16.ClickMe = false;
            this.cameraPlay16.Location = new System.Drawing.Point(0, 0);
            this.cameraPlay16.Name = "cameraPlay16";
            this.cameraPlay16.Size = new System.Drawing.Size(266, 182);
            this.cameraPlay16.TabIndex = 0;
            this.cameraPlay16.ClickVideo += new System.EventHandler(this.cameraPlay_Click);
            this.cameraPlay16.DoubleClickVideo += new System.EventHandler(this.cameraPlay_DoubleClickVideo);
            // 
            // cameraPlay17
            // 
            this.cameraPlay17.Camera = null;
            this.cameraPlay17.ClickMe = false;
            this.cameraPlay17.Location = new System.Drawing.Point(0, 0);
            this.cameraPlay17.Name = "cameraPlay17";
            this.cameraPlay17.Size = new System.Drawing.Size(266, 182);
            this.cameraPlay17.TabIndex = 0;
            this.cameraPlay17.ClickVideo += new System.EventHandler(this.cameraPlay_Click);
            this.cameraPlay17.DoubleClickVideo += new System.EventHandler(this.cameraPlay_DoubleClickVideo);
            // 
            // cameraPlay18
            // 
            this.cameraPlay18.Camera = null;
            this.cameraPlay18.ClickMe = false;
            this.cameraPlay18.Location = new System.Drawing.Point(0, 0);
            this.cameraPlay18.Name = "cameraPlay18";
            this.cameraPlay18.Size = new System.Drawing.Size(266, 182);
            this.cameraPlay18.TabIndex = 0;
            this.cameraPlay18.ClickVideo += new System.EventHandler(this.cameraPlay_Click);
            this.cameraPlay18.DoubleClickVideo += new System.EventHandler(this.cameraPlay_DoubleClickVideo);
            // 
            // cameraPlay19
            // 
            this.cameraPlay19.Camera = null;
            this.cameraPlay19.ClickMe = false;
            this.cameraPlay19.Location = new System.Drawing.Point(0, 0);
            this.cameraPlay19.Name = "cameraPlay19";
            this.cameraPlay19.Size = new System.Drawing.Size(266, 182);
            this.cameraPlay19.TabIndex = 0;
            this.cameraPlay19.ClickVideo += new System.EventHandler(this.cameraPlay_Click);
            this.cameraPlay19.DoubleClickVideo += new System.EventHandler(this.cameraPlay_DoubleClickVideo);
            // 
            // cameraPlay20
            // 
            this.cameraPlay20.Camera = null;
            this.cameraPlay20.ClickMe = false;
            this.cameraPlay20.Location = new System.Drawing.Point(0, 0);
            this.cameraPlay20.Name = "cameraPlay20";
            this.cameraPlay20.Size = new System.Drawing.Size(266, 182);
            this.cameraPlay20.TabIndex = 0;
            this.cameraPlay20.ClickVideo += new System.EventHandler(this.cameraPlay_Click);
            this.cameraPlay20.DoubleClickVideo += new System.EventHandler(this.cameraPlay_DoubleClickVideo);
            // 
            // cameraPlay21
            // 
            this.cameraPlay21.Camera = null;
            this.cameraPlay21.ClickMe = false;
            this.cameraPlay21.Location = new System.Drawing.Point(0, 0);
            this.cameraPlay21.Name = "cameraPlay21";
            this.cameraPlay21.Size = new System.Drawing.Size(266, 182);
            this.cameraPlay21.TabIndex = 0;
            this.cameraPlay21.ClickVideo += new System.EventHandler(this.cameraPlay_Click);
            this.cameraPlay21.DoubleClickVideo += new System.EventHandler(this.cameraPlay_DoubleClickVideo);
            // 
            // cameraPlay22
            // 
            this.cameraPlay22.Camera = null;
            this.cameraPlay22.ClickMe = false;
            this.cameraPlay22.Location = new System.Drawing.Point(0, 0);
            this.cameraPlay22.Name = "cameraPlay22";
            this.cameraPlay22.Size = new System.Drawing.Size(266, 182);
            this.cameraPlay22.TabIndex = 0;
            this.cameraPlay22.ClickVideo += new System.EventHandler(this.cameraPlay_Click);
            this.cameraPlay22.DoubleClickVideo += new System.EventHandler(this.cameraPlay_DoubleClickVideo);
            // 
            // cameraPlay23
            // 
            this.cameraPlay23.Camera = null;
            this.cameraPlay23.ClickMe = false;
            this.cameraPlay23.Location = new System.Drawing.Point(0, 0);
            this.cameraPlay23.Name = "cameraPlay23";
            this.cameraPlay23.Size = new System.Drawing.Size(266, 182);
            this.cameraPlay23.TabIndex = 0;
            this.cameraPlay23.ClickVideo += new System.EventHandler(this.cameraPlay_Click);
            this.cameraPlay23.DoubleClickVideo += new System.EventHandler(this.cameraPlay_DoubleClickVideo);
            // 
            // cameraPlay24
            // 
            this.cameraPlay24.Camera = null;
            this.cameraPlay24.ClickMe = false;
            this.cameraPlay24.Location = new System.Drawing.Point(0, 0);
            this.cameraPlay24.Name = "cameraPlay24";
            this.cameraPlay24.Size = new System.Drawing.Size(266, 182);
            this.cameraPlay24.TabIndex = 0;
            this.cameraPlay24.ClickVideo += new System.EventHandler(this.cameraPlay_Click);
            this.cameraPlay24.DoubleClickVideo += new System.EventHandler(this.cameraPlay_DoubleClickVideo);
            // 
            // cameraPlay25
            // 
            this.cameraPlay25.Camera = null;
            this.cameraPlay25.ClickMe = false;
            this.cameraPlay25.Location = new System.Drawing.Point(0, 0);
            this.cameraPlay25.Name = "cameraPlay25";
            this.cameraPlay25.Size = new System.Drawing.Size(266, 182);
            this.cameraPlay25.TabIndex = 0;
            this.cameraPlay25.ClickVideo += new System.EventHandler(this.cameraPlay_Click);
            this.cameraPlay25.DoubleClickVideo += new System.EventHandler(this.cameraPlay_DoubleClickVideo);
            // 
            // Multiplayer
            // 
            this.Size = new System.Drawing.Size(424, 376);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Multiplayer_Paint);
            this.Click += new System.EventHandler(this.cameraPlay_Click);
            this.Resize += new System.EventHandler(this.Multiplexer_Resize);
            this.ResumeLayout(false);

        }
        #endregion


        // Close all cameras
        public void CloseAll()
        {
            for (int i = 0; i < MaxRows; i++)
            {
                for (int j = 0; j < MaxCols; j++)
                {
                    camWindows[i, j].Camera = null;
                }
            }
        }

        // Set camera to the specified position of the multiplexer
        public CameraPlay SetCamera(int row, int col, DeviceDriver camera)
        {
            if ((row >= 0) && (col >= 0) && (row < MaxRows) && (col < MaxCols))
            {
                camWindows[row, col].Camera = camera;
                return camWindows[row, col];
            }
            return null;
        }
        public CameraPlay GetCamera(int row, int col)
        {
            CameraPlay rtncameraPlay = null;
            if ((row >= 0) && (col >= 0) && (row < MaxRows) && (col < MaxCols))
            {
                rtncameraPlay = camWindows[row, col];
            }
            return rtncameraPlay;
        }
        // Set multiplexer size
        public void SetSize(int rows, int cols, int cellWidth, int cellHeight)
        {
            this.rows = rows;
            this.cols = cols;
            this.cellWidth = cellWidth;
            this.cellHeight = cellHeight;
            UpdateSize();
        }

        // Update cameras visibility
        private void UpdateVisiblity()
        {
            if (camerasVisible)
            {
                for (int i = 0; i < MaxRows; i++)
                {
                    for (int j = 0; j < MaxCols; j++)
                    {
                        camWindows[i, j].Visible = ((i < rows) && (j < cols));
                    }
                }
            }
        }

        // Update cameras size and position
        private void UpdateSize()
        {
           
            int width, height;
            width = (ClientRectangle.Width - 4 * (cols - 1)) / cols;//a single pic width in partition
            height = (ClientRectangle.Height - 4 * (rows - 1)) / rows;//a single pic height in partition
          
            int startX = (ClientRectangle.Width - cols * (width)) / 2;
            int startY = (ClientRectangle.Height - rows * (height)) / 2;
            if (isFullScreen)
            {

                height = ClientRectangle.Height - 4;
                width = ClientRectangle.Width;
                startX = 0;
                startY = 0;
            }
            this.SuspendLayout();
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (!isFullScreen)
                    {
                        camWindows[i, j].Visible = true;
                        camWindows[i, j].Location = new Point(startX + (width+4) * j , startY + (height+4) * i );
                        camWindows[i, j].Size = new Size(width, height);
                    }
                    else
                    {

                        if (lastClicked.Camera.CurrentCamera.CameraId == camWindows[i, j].Camera.CurrentCamera.CameraId)
                        {
                            camWindows[i, j].Visible = true;
                            camWindows[i, j].Location = new Point(startX, startY);
                            camWindows[i, j].Size = new Size(width, height);
                        }
                        else
                        {
                            camWindows[i, j].Visible = false;
                        }
                    }
                }
            }

            this.ResumeLayout(false);
        }

        // On size changed
        private void Multiplexer_Resize(object sender, System.EventArgs e)
        {
            UpdateSize();
        }

        // On mouse down in camera window
        private void cameraPlay_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            lastClicked = (CameraPlay)sender;
        }
        private bool isFullScreen = false;
        private CameraPlay currentWin = null;
       

        private void cameraPlay_MouseDoubleClick(object sender, MouseEventArgs e)
        {
          

        }

        private void cameraPlay_Click(object sender, EventArgs e)
        {

            try
            {
                if (sender != null)
                {
                    SetClickON((CameraPlay)sender);
                }
            }
            catch (Exception ex)
            {

            }
        }
        private void SetClickON(CameraPlay cameraPlay)
        {
            string winName = "cameraPlay";
            for (int i = 0; i < 25; i++)
            {
                Control[] control = this.Controls.Find(string.Format("{0}{1}", winName, i), false);
                if (control != null && control.Length > 0)
                {
                    CameraPlay ctr = (CameraPlay)control[0];

                    if (ctr != null)
                    {
                        ctr.ClickMe = false;
                    }
                }

            }
            cameraPlay.ClickMe = true;
        }

        private void cameraPlay_DoubleClickVideo(object sender, EventArgs e)
        {
            try
            {
                if (!isFullScreen)
                {
                    SingleCameraMode = true;
                    FitToWindow = true;
                    currentWin = lastClicked;
                }
                else
                {
                    SingleCameraMode = false;
                    currentWin.ClickMe = true;
                }
                doubleClicked = (CameraPlay)sender;
                if (DoubleCamera != null)
                {
                    DoubleCamera(!isFullScreen, currentWin.Camera.CurrentCamera);
                }

                isFullScreen = !isFullScreen;
                UpdateSize();


            }
            catch (Exception ex)
            {

            }
        }

        private void Multiplayer_Paint(object sender, PaintEventArgs e)
        {
            Graphics pe = e.Graphics;

        }
    }
}
