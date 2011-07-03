using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IntVideoSurv.Entity;

namespace CameraViewer.Tools
{
    public class HistroyVideoFile
    {
        public LongChang_CameraInfo Camera { set; get; }
        public DateTime CaptureTime { set; get; }
        public string FileName { set; get; }
    }
}
