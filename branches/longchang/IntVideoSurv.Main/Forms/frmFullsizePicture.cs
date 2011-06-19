using System.Drawing;
using DevExpress.XtraEditors;

namespace CameraViewer.Forms
{
    public partial class frmFullsizePicture : XtraForm
    {
        public frmFullsizePicture()
        {
            InitializeComponent();
        }
        public frmFullsizePicture(Image image)
        {
            InitializeComponent();
            this.Height = image.Height+100;
            this.Width = image.Width+100;
            pictureEdit1.Height = image.Height;
            pictureEdit1.Width = image.Width;
            pictureEdit1.Image = image;
        }

        private void pictureEdit1_DoubleClick(object sender, System.EventArgs e)
        {
            this.Close();
        }
    }
}
