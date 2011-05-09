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
            : base(dataRow)
        {
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
        public bool stop { get; set; }
        [ColumnMapping()]
        public bool changeChannel { get; set; }
        [ColumnMapping()]
        public int EventId { get; set; }
    }
}
