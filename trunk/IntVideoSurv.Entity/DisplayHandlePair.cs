using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IntVideoSurv.Entity
{
    public class DisplayHandlePair
    {
        public int DisplayChannelId
        { set; get; }
        public int DisplaySplitScreenNo { set; get; }
        public IntPtr Handle { set; get; }
    }
}
