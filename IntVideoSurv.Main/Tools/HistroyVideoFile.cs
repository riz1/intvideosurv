using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IntVideoSurv.Entity;

namespace CameraViewer.Tools
{
    public class HistroyVideoFile
    {
        public Model.TOG_DEVICE Camera { set; get; }
        public DateTime CaptureTime { set; get; }
        public string FileName { set; get; }
    }
}
