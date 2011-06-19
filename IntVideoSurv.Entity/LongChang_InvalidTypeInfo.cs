using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Com.SS.Framework.Entity;

namespace IntVideoSurv.Entity
{
    [Serializable]
    public class LongChang_InvalidTypeInfo : EntityObject
    {


        #region construction
        public LongChang_InvalidTypeInfo() { }
        public LongChang_InvalidTypeInfo(IDataReader dataReader) : base(dataReader) { }
        public LongChang_InvalidTypeInfo(DataRow dataRow)
        {
            InvalidId = dataRow["WZYYBH"] is DBNull ? "" : Convert.ToString(dataRow["WZYYBH"]);
            InvalidName = dataRow["WZYY"] is DBNull ? "" : Convert.ToString(dataRow["WZYY"]);

        }
        #endregion

        [ColumnMapping()]
        public string InvalidId { get; set; }
        [ColumnMapping()]
        public string InvalidName { get; set; }

    }
}