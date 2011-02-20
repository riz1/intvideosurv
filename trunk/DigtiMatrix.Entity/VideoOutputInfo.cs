using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
namespace IntVideoSurv.Entity
{
    [Serializable]
    public class VideoOutputInfo
    {
        public int CameraId { get; set; }
        public Panel  VideoPlayPanel { get; set; }
        public int OutputPort { set; get; }
        public int VideoStandard { set; get; }

    }
}
