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
    public class Track : EntityObject
    {
         #region construction
        public Track() { }
        public Track(IDataReader dataReader) : base(dataReader) { }
        public Track(DataRow dataRow)
        {
            Id = Convert.ToInt32(dataRow["Id"]);
            REct = Convert.ToInt32(dataRow["REct"]);
        }
#endregion
        [ColumnMapping()]
        public int Id {get;set;}
        [ColumnMapping()]
        public int REct { get; set; }
    }
}
