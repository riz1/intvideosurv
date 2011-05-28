using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Com.SS.Framework.Entity;
using System.Data;
namespace IntVideoSurv.Entity
{
    public class ObjectInfo : EntityObject
    {
        #region construction
        public ObjectInfo() { }
        public ObjectInfo(IDataReader dataReader) : base(dataReader) { }
        public ObjectInfo(DataRow dataRow)
        {
            ObjectId = Convert.ToInt32(dataRow["ObjectId"]);
            stop = Convert.ToBoolean(dataRow["stop"]);
            illegalDir = Convert.ToBoolean(dataRow["illegalDir"]);
            CrossLine = Convert.ToBoolean(dataRow["CrossLine"]);
            changeChannel = Convert.ToBoolean(dataRow["changeChannel"]);
            EventId = Convert.ToInt32(dataRow["EventId"]);
        }
        #endregion
        [ColumnMapping()]
        public int ObjectId { get; set; }
        [ColumnMapping()]
        public bool stop { get; set; }
        [ColumnMapping()]
        public bool illegalDir { get; set; }
        [ColumnMapping()]
        public bool CrossLine { get; set; }
        [ColumnMapping()]
        public bool changeChannel { get; set; }
        [ColumnMapping()]
        public int EventId { get; set; }
    }
}
