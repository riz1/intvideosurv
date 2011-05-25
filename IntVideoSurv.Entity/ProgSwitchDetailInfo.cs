using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Com.SS.Framework.Entity;
using System.Data;
namespace IntVideoSurv.Entity
{
    [Serializable]
    public class ProgSwitchDetailInfo : EntityObject
    {

        #region construction

        public ProgSwitchDetailInfo() { }
        public ProgSwitchDetailInfo(IDataReader dataReader) : base(dataReader) { }
        public ProgSwitchDetailInfo(DataRow dataRow)
        {
            ProgSwitchDetailId = Convert.ToInt32(dataRow["ProgSwitchDetailId"]);
            CameraId = Convert.ToInt32(dataRow["CameraId"]);
            TickTime = Convert.ToInt32(dataRow["TickTime"]);
            CameraName = Convert.ToString(dataRow["CameraName"]);
            DeviceId = Convert.ToInt32(dataRow["DeviceId"]);
            DeviceName = Convert.ToString(dataRow["DeviceName"]);
        }
       
        #endregion

        [ColumnMapping()]
        public int ProgSwitchDetailId
        {
            get; set;
        }

        [ColumnMapping()]
        public int CameraId
        {
            get; set;
        }

        [ColumnMapping()]
        public int TickTime
        {
            get;
            set;
        }

        [ColumnMapping()]
        public string CameraName
        {
            get;
            set;
        }
        [ColumnMapping()]
        public int DeviceId
        {
             set; get;
        }

        [ColumnMapping()]
        public String DeviceName
        {
            get;
            set;
        }

        public override string ToString()
        {
            return String.Format("ID:{0} 摄像机ID:{1} 时间间隔:{2} 摄像机名:{3} 设备ID:{4} 设备名:{5}", ProgSwitchDetailId, CameraId, TickTime, CameraName, DeviceId, DeviceName);
        }
    }

}
