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
    public class LongChang_WzyyInfo : EntityObject
    {



        #region construction
        public LongChang_WzyyInfo() { }
        public LongChang_WzyyInfo(IDataReader dataReader) : base(dataReader) { }
        public LongChang_WzyyInfo(DataRow dataRow)
        {
            illeagalReasonNum = dataRow["wzyybh"] is DBNull ? "" : Convert.ToString(dataRow["wzyybh"]);
            illeagalReason = dataRow["wzyy"] is DBNull ? "" : Convert.ToString(dataRow["wzyy"]);
            sorting = dataRow["px"] is DBNull ? -1 : Convert.ToInt32(dataRow["px"]);
            illeagalReason = dataRow["ztbj"] is DBNull ? "" : Convert.ToString(dataRow["ztbj"]);
            illeagalReason = dataRow["bz"] is DBNull ? "" : Convert.ToString(dataRow["bz"]);

        }
        #endregion

        [ColumnMapping()]
        public string illeagalReasonNum { get; set; }
        [ColumnMapping()]
        public string illeagalReason { get; set; }
        [ColumnMapping()]
        public int sorting { get; set; }
        [ColumnMapping()]
        public string stateTag { get; set; }
        [ColumnMapping()]
        public string remarks { get; set; }
        
    }
}

