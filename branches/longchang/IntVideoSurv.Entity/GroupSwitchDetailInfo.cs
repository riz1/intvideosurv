using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Com.SS.Framework.Entity;
using System.Data;
 

namespace IntVideoSurv.Entity
{
    public class GroupSwitchDetailInfo : EntityObject
    {
        #region construction
        public GroupSwitchDetailInfo() { }
        public GroupSwitchDetailInfo(IDataReader dataReader) : base(dataReader) { }
        public GroupSwitchDetailInfo(DataRow dataRow)
        {
            Id = Convert.ToInt32(dataRow["Id"]);
            SynGroupId = Convert.ToInt32(dataRow["SynGroupId"]);
            SynGroupName = Convert.ToString(dataRow["SynGroupName"]);
            TickTime = Convert.ToInt32(dataRow["TickTime"]);
            GroupSwitchGroupId = Convert.ToInt32(dataRow["GroupSwitchGroupId"]);
            GroupSwitchGroupName = Convert.ToInt32(dataRow["GroupSwitchGroupName"]);
        }
        #endregion

        [ColumnMapping()]
        public int Id { get; set; }
        [ColumnMapping()]
        public int SynGroupId { get; set; }
        [ColumnMapping()]
        public string SynGroupName { get; set; }
        [ColumnMapping()]
        public int TickTime { get; set; }
        [ColumnMapping()]
        public int GroupSwitchGroupId { get; set; }
        [ColumnMapping()]
        public int GroupSwitchGroupName { get; set; }

        public Dictionary<int, CameraMonitorPairInfo> ListCameraMonitorPair
        {
            get;
            set;
        }
        public override string ToString()
        {
            return String.Format("ID:{0} 同步号:{1} 同步名:{2} 时间间隔:{3} 群组切换ID:{4} 群组切换名:{5}", Id, SynGroupId, SynGroupName, TickTime, GroupSwitchGroupId, GroupSwitchGroupName);
        }
    }

}
