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
        {
            EventRectId = Convert.ToInt32(dataRow["EventRectId"]);
            x = Convert.ToInt32(dataRow["x"]);
            y = Convert.ToInt32(dataRow["y"]);
            w = Convert.ToInt32(dataRow["w"]);
            h = Convert.ToInt32(dataRow["h"]);
            ObjectId = Convert.ToInt32(dataRow["ObjectId"]);
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
