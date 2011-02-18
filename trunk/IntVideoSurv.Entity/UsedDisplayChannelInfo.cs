using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IntVideoSurv.Entity
{
    public class UsedDisplayChannelInfo
    {
        public UsedDisplayChannelInfo()
        {
            DisplayChannelId = DisplaySplitScreenNo =- 1;
            _defaultDisplayCameraId = -1;
            _synGroupId = _groupSwitchId = _progSwitchId = -1;
            Handle= new IntPtr(-1);
        }

        public int DisplayChannelId { get; set; }

        public int DisplaySplitScreenNo { get; set; }

        public int DefaultDisplayCameraId
        {
            set
            {
               Clear();
               _defaultDisplayCameraId = value;
            }
            get { return _defaultDisplayCameraId; }
        }
        public int SynGroupId
        {
            set {
               Clear();  
               _synGroupId = value; 
            }
            get { return _synGroupId; }
        }
        public int GroupSwitchId
        {
            set
            {
               Clear(); 
               _groupSwitchId = value;
            }
            get { return _groupSwitchId; }
        }

        public int ProgSwitchId
        {
            set
            {
               Clear();  
               _progSwitchId = value;
            }
            get { return _progSwitchId; }
        }

        public IntPtr Handle { get; set; }

        private void Clear()
        {
            _defaultDisplayCameraId = -1;
            _synGroupId = _groupSwitchId = _progSwitchId = -1;
        }
        private int _groupSwitchId;
        private int _progSwitchId;
        private int _defaultDisplayCameraId;
        private int _synGroupId;

        public bool IsUsed()
        {
            return (_defaultDisplayCameraId == -1 && _synGroupId == -1 && _groupSwitchId == -1 && _progSwitchId == -1)
                       ? false
                       : true;
        }
    }
}
