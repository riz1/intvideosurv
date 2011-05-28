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
    public class REct : EntityObject
    {
        #region construction
        public REct() { }
        public REct(IDataReader dataReader) : base(dataReader) { }
        public REct(DataRow dataRow)
        {
            RectID = Convert.ToInt32(dataRow["RectID"]);
            X = Convert.ToInt32(dataRow["X"]);
            Y = Convert.ToInt32(dataRow["Y"]);
            W = Convert.ToInt32(dataRow["W"]);
            H = Convert.ToInt32(dataRow["H"]);

        }
#endregion
        [ColumnMapping()]
        public int RectID {get;set;}
        [ColumnMapping()]
        public int X { get; set; }
        [ColumnMapping()]
        public int Y { get; set; }
        [ColumnMapping()]
        public int W { get; set; }
        [ColumnMapping()]
        public int H { get;set; }
    }
}
