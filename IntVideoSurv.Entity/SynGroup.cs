using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Com.SS.Framework.Entity;
using System.Data;
namespace IntVideoSurv.Entity
{
    [Serializable]
    public class SynGroup : EntityObject
    {
        private int _id = 0;
        private string _name;
        private string _description = "";
        private int _monitorId = 0;

        #region construction
        public SynGroup() { }
        public SynGroup(IDataReader dataReader) : base(dataReader) { }
        public SynGroup(DataRow dataRow) : base(dataRow) { }
        #endregion
        [ColumnMapping()]
        public int SynGroupId
        {
            get { return _id; }
            set { _id = value; }
        }
        [ColumnMapping()]
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        [ColumnMapping()]
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public Dictionary<int, CameraInfo> ListCamera
        {
            get;
            set;
        }

        public Dictionary<int, CameraMonitorPairInfo> ListCameraMonitorPair
        {
            get;
            set;
        }

        [ColumnMapping()]
        public int MonitorId
        {
            get { return _monitorId; }
            set { _monitorId = value; }
        }

        public override string ToString()
        {
            return String.Format("ID:{0}  名称:{1} 描述:{2}  监视器ID:{3}",SynGroupId,Name,Description,MonitorId);
        }
    }

}
