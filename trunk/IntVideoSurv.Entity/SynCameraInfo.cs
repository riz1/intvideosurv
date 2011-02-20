using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Com.SS.Framework.Entity;

namespace IntVideoSurv.Entity
{
    public class SynCameraInfo: EntityObject
    {

        #region construction
        public SynCameraInfo() { }
        public SynCameraInfo(IDataReader dataReader) : base(dataReader) { }
        public SynCameraInfo(DataRow dataRow)
            : base(dataRow)
        {
            //Name = dataRow["CameraInfo.Name"].ToString();
            //DeviceName = dataRow["DeviceInfo.Name"].ToString();
        }
        #endregion
        [ColumnMapping()]
        public int SynGroupId { get; set; }
        [ColumnMapping()]
        public int CameraId { get; set; }
        [ColumnMapping()]
        public int DispalyChannelNoInCurrentCard
        {
            get;
            set;

        }
        [ColumnMapping()]
        public int DecodeCardNo
        {
            get;
            set;

        }

        [ColumnMapping()]
        public int SplitScreenNo
        {
            get;
            set;

        }

        [ColumnMapping()]
        public int DisplaySplitScreenNo
        {
            get;
            set;

        }

        [ColumnMapping()]
        public int DisplayChannelId { get; set; }

        public IntPtr Handle { get; set; }

        public override string ToString()
        {
            return String.Format("ID:{0} 摄像机:{1} 显示通道号:{2} 总分屏:{3}  第{4}分屏", SynGroupId, CameraId, DisplayChannelId, SplitScreenNo, DisplaySplitScreenNo);
        }
       

    }
}
