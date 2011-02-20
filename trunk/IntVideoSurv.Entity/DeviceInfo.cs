using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Com.SS.Framework.Entity;
using System.Data;
 
namespace IntVideoSurv.Entity
{
    [Serializable]
    public class DeviceInfo : EntityObject
    {
        #region construction
        public DeviceInfo() { }
        public DeviceInfo(IDataReader dataReader) : base(dataReader) { }
        public DeviceInfo(DataRow dataRow) : base(dataRow) { }
        #endregion
        [ColumnMapping()]
        public string Description { get; set; }
        [ColumnMapping()]
        public int DeviceId { get; set; }
        [ColumnMapping()]
        public string Name { get; set; }
        [ColumnMapping()]
        public string source { get; set; }
        [ColumnMapping()]
        public string login { get; set; }
        [ColumnMapping()]
        public string pwd { get; set; }
        [ColumnMapping()]
        public int Port { get; set; }
        [ColumnMapping()]
        public int VideoCount { get; set; }
        [ColumnMapping()]
        public int ViddeoStartNo { get; set; }
        [ColumnMapping()]
        public int WarningOutputCount { get; set; }
        [ColumnMapping()]
        public int WarningInputNo { get; set; }
        [ColumnMapping()]
        public int WarningCount { get; set; }
        [ColumnMapping()]
        public string FileExtName { get; set; }
        [ColumnMapping()]
        public int IsCamera { get; set; }
        [ColumnMapping()]
        public IntPtr Handle { get; set; }
        [ColumnMapping()]
        public int ServiceID { get; set; }
        [ColumnMapping()]
        public string Remark { set; get; }
        [ColumnMapping()]
        public string ProviderName { get; set; }
        [ColumnMapping()]
        public string AddBy { set; get; }
        [ColumnMapping()]
        public string AddTime { set; get; }
        [ColumnMapping()]
        public string ModifyBy { set; get; }
        [ColumnMapping()]
        public string ModifyTime { set; get; }

        public bool DeviceRunningStatus
        {
            set;
            get;
        }
        [ColumnMapping()]
        public int GroupId
        {
            get;
            set;
        }
        public Dictionary<int, CameraInfo> ListCamera{ get; set;}
        public Dictionary<int, AlarmInfo> ListAlarm { get; set; }
        public Dictionary<int, CameraInfo> RunningCameraList { get; set; }
        public bool IsReady { get; set; }
        public override String ToString()
        {
            return String.Format("设备ID:{0}  设备名称:{1}  设备描述:{2}", DeviceId, Name, Description);
        }
 
    
    }
}
