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
    public class LongChang_UserVehMonInfo : EntityObject
    {



        #region construction
        public LongChang_UserVehMonInfo() { }
        public LongChang_UserVehMonInfo(IDataReader dataReader) : base(dataReader) { }
        public LongChang_UserVehMonInfo(DataRow dataRow)
        {
            UserVehMonId = dataRow["USERVEHMONID"] is DBNull ? "" : Convert.ToString(dataRow["USERVEHMONID"]);
            VehMonId = dataRow["VEHMONID"] is DBNull ? "" : Convert.ToString(dataRow["VEHMONID"]);
            UserId = dataRow["USERID"] is DBNull ? -1 : Convert.ToInt32(dataRow["USERID"]);
            TheTime = Convert.ToDateTime(dataRow["TIME"]);

        }
        #endregion

        [ColumnMapping()]
        public string UserVehMonId { get; set; }
        [ColumnMapping()]
        public string VehMonId { get; set; }
        [ColumnMapping()]
        public int UserId { get; set; }
        [ColumnMapping()]
        public DateTime TheTime { get; set; }
        
    }
}

