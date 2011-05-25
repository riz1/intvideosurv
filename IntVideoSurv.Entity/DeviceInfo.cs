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
        public DeviceInfo(DataRow dataRow)
        {
            Description = Convert.ToString(dataRow["Description"]);
            DeviceId = Convert.ToInt32(dataRow["DeviceId"]);
            Name = Convert.ToString(dataRow["Name"]);
            source = Convert.ToString(dataRow["source"]);
            login = Convert.ToString(dataRow["login"]);
            pwd = Convert.ToString(dataRow["pwd"]);
            Port = Convert.ToInt32(dataRow["Port"]);
            VideoCount = Convert.ToInt32(dataRow["VideoCount"]);
            ViddeoStartNo = Convert.ToInt32(dataRow["ViddeoStartNo"]);
            WarningOutputCount = Convert.ToInt32(dataRow["WarningOutputCount"]);
            WarningInputNo = Convert.ToInt32(dataRow["WarningInputNo"]);
            WarningCount = Convert.ToInt32(dataRow["WarningCount"]);
            FileExtName = Convert.ToString(dataRow["FileExtName"]);
            IsCamera = Convert.ToInt32(dataRow["IsCamera"]);
            Remark = Convert.ToString(dataRow["Remark"]);
            ProviderName = Convert.ToString(dataRow["ProviderName"]);
            AddBy = Convert.ToString(dataRow["AddBy"]);
            AddTime = Convert.ToString(dataRow["AddTime"]);
            ModifyBy = Convert.ToString(dataRow["ModifyBy"]);
            ModifyTime = Convert.ToString(dataRow["ModifyTime"]);
            GroupId = Convert.ToInt32(dataRow["GroupId"]);
        }
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
