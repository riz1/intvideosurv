using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Com.SS.Framework.Entity;

namespace IntVideoSurv.Entity
{
    [Serializable]
    public class LongChang_CaptureDepartmentInfo : EntityObject
    {


        #region construction
        public LongChang_CaptureDepartmentInfo() { }
        public LongChang_CaptureDepartmentInfo(IDataReader dataReader) : base(dataReader) { }
        public LongChang_CaptureDepartmentInfo(DataRow dataRow)
        {
            CaptureDepartmentId = dataRow["ORGID"] is DBNull ? "" : Convert.ToString(dataRow["ORGID"]);
            CaptureDepartmentName = dataRow["ORGName"] is DBNull ? "" : Convert.ToString(dataRow["ORGName"]);

        }
        #endregion

        [ColumnMapping()]
        public string CaptureDepartmentId { get; set; }
        [ColumnMapping()]
        public string CaptureDepartmentName { get; set; }

    }
}