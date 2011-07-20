using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CameraViewer.Model
{
    public class Camera
    {
        public string No { get; set; }
        public string Name { get; set; }

        public string RegionNo { get; set; }

        public string OrgNo { get; set; }

        public string RoadNo { get; set; }
        public string RoadName { get; set; }

        public string LuKouNo { get; set; }
        public string LuKouName { get; set; }

        public string KaKouWeizhi { get; set; }

        public string KaKouNo { get; set; }
        public string KakouName { get; set; }

        public string DirectionNo { get; set; }
        public string DirectionName { get; set; }

        public string LaneNo { get; set; }
        public string LaneName { get; set; }
    }
}
