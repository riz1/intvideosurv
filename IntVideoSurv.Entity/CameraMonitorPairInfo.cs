using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Com.SS.Framework.Entity;
using System.Data;
using System.Drawing;
using System.Threading;
namespace IntVideoSurv.Entity
{
    [Serializable]
    public class CameraMonitorPairInfo : EntityObject
    {
             




        #region construction
        public CameraMonitorPairInfo() { }
        public CameraMonitorPairInfo(IDataReader dataReader) : base(dataReader) { }
        public CameraMonitorPairInfo(DataRow dataRow)
            : base(dataRow)
        {
            //Name = dataRow["CameraInfo.Name"].ToString();
            //DeviceName = dataRow["DeviceInfo.Name"].ToString();
        }
        #endregion

        [ColumnMapping()]
        public int DeviceId { get; set; }
        [ColumnMapping()]
        public int CameraId { get; set; }
        [ColumnMapping()]
        public string Name { get; set; }
        [ColumnMapping()]
        public string Description { get; set; }

        [ColumnMapping()]
        public bool IsValid { get; set; }
        [ColumnMapping()]
        public int ChannelNo { get; set; }
        [ColumnMapping()]
        public int AddressID { get; set; }
        [ColumnMapping()]
        public string ConnURL { get; set; }
        [ColumnMapping()]
        public bool IsDetect { get; set; }
        public IntPtr Handle { get; set; }
        [ColumnMapping()]
        public string Remark { set; get; }
        [ColumnMapping()]
        public string Oupputpath { get; set; }

        [ColumnMapping()]
        public string AddBy { set; get; }
        [ColumnMapping()]
        public string AddTime { set; get; }
        [ColumnMapping()]
        public string ModifyBy { set; get; }
        [ColumnMapping()]
        public string ModifyTime { set; get; }
        [ColumnMapping()]
        public int frameInterval { get; set; }
        [ColumnMapping()]
        public string resolution { get; set; }
        [ColumnMapping()]
        public string quality { get; set; }
        [ColumnMapping()]
        public int StreamType { get; set; }
        public int Width
        {
            get;
            set;
        }
        // Height property
        public int Height
        {
            get;
            set;
        }
        public bool IsRunning
        {
            get;
            set;
        }
        public int PlayHandle { set; get; }
        [ColumnMapping()]
        public string DeviceName { get; set; }

        [ColumnMapping()]
        public int DisplayChannelId { get; set; }
        [ColumnMapping()]
        public int DisplaySplitScreenNo { get; set; }
        [ColumnMapping()]
        public string DisplayChannelName { get; set; }
        [ColumnMapping()]
        public int CameraMonitorPairId { get; set; }
    }
}
