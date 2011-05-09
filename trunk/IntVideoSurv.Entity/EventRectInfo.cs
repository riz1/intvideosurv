using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Com.SS.Framework.Entity;
using System.Data;

namespace IntVideoSurv.Entity
{
    [Serializable]
    public class EventRect : EntityObject
    {
        #region construction
        public EventRect() { }
        public EventRect(IDataReader dataReader) : base(dataReader) { }
        public EventRect(DataRow dataRow)
            : base(dataRow)
        {
        }
#endregion
        [ColumnMapping()]
        public int EventRectId {get;set;}
        [ColumnMapping()]
        public int x { get; set; }
        [ColumnMapping]
        public int y { get; set; }
        [ColumnMapping]
        public int w { get; set; }
        [ColumnMapping]
        public int h { get; set; }
        [ColumnMapping]
        public int ObjectId { get; set; } 
    }
}
