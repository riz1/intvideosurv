using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace CameraViewer.NetWorking
{
    public class NetImage
    {
        public Image Image { set; get; }
        public int CameraId { set; get; }
        public DateTime CaptureTime { set; get; }
        public int Width{ set; get; }
        public int Height{ set; get; }
        public int Format{ set; get; }
    }
}
