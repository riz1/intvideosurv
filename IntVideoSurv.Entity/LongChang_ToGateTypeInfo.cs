using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Com.SS.Framework.Entity;
using System.Data;
using System.Drawing;
using System.Threading;
namespace IntVideoSurv.Entity
{
    [Serializable]
    public class LongChang_ToGateTypeInfo : EntityObject
    {


        #region construction
        public LongChang_ToGateTypeInfo() { }
        public LongChang_ToGateTypeInfo(IDataReader dataReader) : base(dataReader) { }
        public LongChang_ToGateTypeInfo(DataRow dataRow)
        {
            GateCaptureTypeId = dataRow["kklxdm"] is DBNull ? "" : Convert.ToString(dataRow["kklxdm"]);
            GateCaptureTypeName = dataRow["kklx"] is DBNull ? "" : Convert.ToString(dataRow["kklx"]);

        }
        #endregion

        [ColumnMapping()]
        public string GateCaptureTypeId { get; set; }
        [ColumnMapping()]
        public string GateCaptureTypeName { get; set; }

    }
}

