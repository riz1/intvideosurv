using System;
using System.Collections;
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
    public class AlarmInfo : EntityObject
    {
        #region construction
        
        public AlarmInfo() { }
        public AlarmInfo(IDataReader dataReader) : base(dataReader) { }
        public AlarmInfo(DataRow dataRow)
        {
            AlarmId = Convert.ToInt32(dataRow["AlarmId"]);
            Name = Convert.ToString(dataRow["Name"]);
            Description = Convert.ToString(dataRow["Description"]);
            DeviceId = Convert.ToInt32(dataRow["DeviceId"]);
            IsValid = Convert.ToBoolean(dataRow["IsValid"]);
            ChannelNo = Convert.ToInt32(dataRow["ChannelNo"]);
        }
        #endregion

        [ColumnMapping()]
        public int AlarmId { get; set; }
        [ColumnMapping()]
        public string Name { get; set; }
        [ColumnMapping()]
        public string Description { get; set; }

        [ColumnMapping()]
        public int DeviceId { get; set; }

        [ColumnMapping()]
        public string DeviceName { get; set; }

        [ColumnMapping()]
        public bool IsValid { get; set; }
        [ColumnMapping()]
        public int ChannelNo { get; set; }

        public override string ToString()
        {
            return String.Format("ID:{0}  名称:{1}  描述:{2}  设备ID:{3}  设备名:{4}", AlarmId, Name, Description, DeviceId, DeviceName);

        }
    }
}
