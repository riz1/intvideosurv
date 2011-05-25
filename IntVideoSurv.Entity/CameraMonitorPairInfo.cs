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
        {
            DeviceId = Convert.ToInt32(dataRow["DeviceId"]);
            CameraId = Convert.ToInt32(dataRow["CameraId"]);
            Name = Convert.ToString(dataRow["Name"]);
            Description = Convert.ToString(dataRow["Description"]);
            IsValid = Convert.ToBoolean(dataRow["IsValid"]);
            ChannelNo = Convert.ToInt32(dataRow["ChannelNo"]);
            AddressID = Convert.ToInt32(dataRow["AddressID"]);
            ConnURL = Convert.ToString(dataRow["ConnURL"]);
            IsDetect = Convert.ToBoolean(dataRow["IsDetect"]);
            Remark = Convert.ToString(dataRow["Remark"]);
            Oupputpath = Convert.ToString(dataRow["Oupputpath"]);
            AddBy = Convert.ToString(dataRow["AddBy"]);
            AddTime = Convert.ToString(dataRow["AddTime"]);
            ModifyBy = Convert.ToString(dataRow["ModifyBy"]);
            ModifyTime = Convert.ToString(dataRow["ModifyTime"]);
            frameInterval = Convert.ToInt32(dataRow["frameInterval"]);
            resolution = Convert.ToString(dataRow["resolution"]);
            quality = Convert.ToString(dataRow["quality"]);
            StreamType = Convert.ToInt32(dataRow["StreamType"]);
            DeviceName = Convert.ToString(dataRow["DeviceName"]);
            DisplayChannelId = Convert.ToInt32(dataRow["DisplayChannelId"]);
            DisplaySplitScreenNo = Convert.ToInt32(dataRow["DisplaySplitScreenNo"]);
            DisplayChannelName = Convert.ToString(dataRow["DisplayChannelName"]);
            CameraMonitorPairId = Convert.ToInt32(dataRow["CameraMonitorPairId"]);

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
