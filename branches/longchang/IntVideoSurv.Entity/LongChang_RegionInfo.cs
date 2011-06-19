using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Com.SS.Framework.Entity;

namespace IntVideoSurv.Entity
{
    [Serializable]
    public class LongChang_RegionInfo : EntityObject
    {


        #region construction
        public LongChang_RegionInfo() { }
        public LongChang_RegionInfo(IDataReader dataReader) : base(dataReader) { }
        public LongChang_RegionInfo(DataRow dataRow)
        {
            RegionId = dataRow["xzqhdm"] is DBNull ? "" : Convert.ToString(dataRow["xzqhdm"]);
            RegionName = dataRow["xzqh"] is DBNull ? "" : Convert.ToString(dataRow["xzqh"]);

        }
        #endregion

        [ColumnMapping()]
        public string RegionId { get; set; }
        [ColumnMapping()]
        public string RegionName { get; set; }

    }
}
