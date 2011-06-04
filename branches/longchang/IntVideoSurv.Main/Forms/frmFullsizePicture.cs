using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CameraViewer.Forms
{
    public partial class frmFullsizePicture : Form
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
    }
}
