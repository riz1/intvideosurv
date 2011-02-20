using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace CameraViewer
{
    public partial class MainWin : Form
    {
        private static string title = "Camera Vision";
        private Configuration config = new Configuration(Path.GetDirectoryName(Application.ExecutablePath));
        private RunningPool runningPool = new RunningPool();
        private FinalizationPool finalizationPool = new FinalizationPool();

        private const int statLength = 15;
        private int statIndex = 0, statReady = 0;
        private long[] statReceived = new long[statLength];
        private int[] statCount = new int[statLength];

        private Camera cameraToEdit;
        private View viewToEdit;
        private TreeNode nodeToEdit;

        private int openedID;
        private bool viewOpened;

        public MainWin()
        {
            InitializeComponent();
           // multiplexer1.ParentWin = this;
            this.camerasTree.Init();
            //LoadAllCamera();
        }
        /// <summary>
        /// load all camera
        /// </summary>
        private void LoadAllCamera()
        {
            multiplexer1.CloseAll();
            multiplexer1.CamerasVisible = true;
            multiplexer1.CellWidth = 320;
            multiplexer1.CellHeight = 240;
            multiplexer1.FitToWindow = true;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    // get camera

                    Camera camera = new Camera("aa");
                    multiplexer1.SetCamera(i, j, camera);


                }
            }

            multiplexer1.Rows = 5;
            multiplexer1.Cols = 5;
            multiplexer1.SingleCameraMode = false;
            multiplexer1.CamerasVisible = true;
        }
        public void FullScreen(bool isFullScreen)
        {
            pnTop.Visible = !isFullScreen;
            pnLeft.Visible = !isFullScreen;
            toolStrip1.Visible = !isFullScreen;
        }
        private void CloseView()
        {
            if (runningPool.Count != 0)
            {
                // detach any cameras from view
                multiplexer1.CloseAll();
                multiplexer1.CamerasVisible = false;

                // stop timer
                //timer.Stop();

                //fpsPanel.Text = "";
                //bpsPanel.Text = "";

                // move all cameras from running pool to finalization pool
                while (runningPool.Count != 0)
                {
                    Camera camera = runningPool[0];

                    // remove camera from running pool
                    runningPool.Remove(camera);
                    // add camera to finilization pool
                    finalizationPool.Add(camera);
                }

                // set default title
                this.Text = title;

                openedID = 0;
            }
        }
        private void OpenView(TreeNode node)
        {
            string fullName = camerasTree.GetViewFullName(node);

            // get view
            View view = config.GetViewByName(fullName);

            // check if it is already running
            if ((viewOpened == true) && (openedID == view.ID))
                return;

            // close previous view
            CloseView();

            // run all cameras
            for (int i = 0; i < view.Rows; i++)
            {
                for (int j = 0; j < view.Cols; j++)
                {
                    // get camera
                    Camera camera = config.cameras.GetCamera(view.GetCamera(i, j));

                    if (camera == null)
                    {
                        continue;
                    }

                    // abort it, if it is in finalization pool
                    finalizationPool.Remove(camera);

                    // add it to running pool
                    if (runningPool.Add(camera))
                    {
                        multiplexer1.SetCamera(i, j, camera);

                    }
                }
            }

            multiplexer1.Rows = view.Rows;
            multiplexer1.Cols = view.Cols;
            multiplexer1.SingleCameraMode = false;
            multiplexer1.CamerasVisible = true;
            multiplexer1.FitToWindow = true;
            multiplexer1.CellWidth = view.CellWidth;
            multiplexer1.CellHeight = view.CellHeight;


            // set title
            this.Text = title + " - " + fullName;

            // reset statistics indexes
            statIndex = 0;
            statReady = 0;

            //
            openedID = view.ID;
            viewOpened = true;

            // start timer
            //timer.Start();
        }

        private void MainWin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void MainWin_Load(object sender, EventArgs e)
        {
            if (config.LoadSettings())
            {
                // set window location and size
               // this.Location = config.mainWindowLocation;
               // this.Size = config.mainWindowSize;

                // show cameras bar
               // ShowCamarasBar(config.showCameraBar);
               // this.camerasTree.Width = config.cameraBarWidth;

               // FitToScreen(config.fitToScreen);
                //if (config.fullScreen)
                 //   FullScreen(config.fullScreen);
            }

            // load providers
            config.providers.Load(Path.GetDirectoryName(Application.ExecutablePath));

            // load cameras tree
            config.LoadCameras();
            // load view tree
            config.LoadViews();

            // build cameras & views tree
            camerasTree.BuildCamerasTree(config.camerasGroups, config.cameras);
            camerasTree.BuildViewsTree(config.viewsGroups, config.views);

            // start finalization pool
            finalizationPool.Start();
        }

        private void camerasTree_DoubleClick(object sender, EventArgs e)
        {
            NodeType type = camerasTree.GetNodeType(camerasTree.SelectedNode);

            switch (type)
            {
                case NodeType.Camera:	// open camera
                   // OpenCamera(camerasTree.SelectedNode);
                    break;
                case NodeType.View:		// open view
                    OpenView(camerasTree.SelectedNode);
                    break;
            }
        }
    }
}
