using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace CameraViewer
{
    public partial class frmDrawing : XtraForm
    {
        private int _cameraId;
        public frmDrawing()
        {
            InitializeComponent();
        }

        public frmDrawing(Image[] images)
        {
            InitializeComponent();
            for (int i = 0; i < images.Length; i++)
            {
                treeList1.AppendNode(new[] { images[i]}, -1);
            }
            pictureEdit1.Image = treeList1.Nodes[0].GetValue(0) as Image;

        }

        public frmDrawing(Image[] images,int cameraId)
        {
            InitializeComponent();
            _cameraId = cameraId;
            for (int i = 0; i < images.Length; i++)
            {
                treeList1.AppendNode(new[] { images[i] }, -1);
            }
            pictureEdit1.Image = treeList1.Nodes[0].GetValue(0) as Image;

        }

        private void treeList1_MouseClick(object sender, MouseEventArgs e)
        {
            pictureEdit1.Image = treeList1.FocusedNode.GetValue(0) as Image;
        }
    }
}
