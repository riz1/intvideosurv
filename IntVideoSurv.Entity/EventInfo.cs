using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Com.SS.Framework.Entity;
using System.Data;
namespace IntVideoSurv.Entity
{
    public class Event : EntityObject
    {
        #region construction
        public Event() { }
        public Event(IDataReader dataReader) : base(dataReader) { }
        public Event(DataRow dataRow)
            : base(dataRow)
        {
        }
        #endregion
        [ColumnMapping()]
        public int EventId { get; set; }
        [ColumnMapping()]
        public int CarNum { get; set; }
        [ColumnMapping()]
        public int Congestion { get; set; }
        [ColumnMapping()]
        public int PictureID { get; set; }
    }
}
