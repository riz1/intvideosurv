using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using IntVideoSurv.Entity;

namespace IntVideoSurv.DataAccess
{
    public class LongChang_WzyyDataAccess
    {
        public static DataSet GetAllWzyyInfo(Database db)
        {
            string cmdText = string.Format("select * from BTOC_WZYY order by WZYYBH");
            try
            {
                return db.ExecuteDataSet(CommandType.Text, cmdText);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public static int Insert(Database db, LongChang_WzyyInfo oWzyy)
        {

            StringBuilder sbField = new StringBuilder();
            StringBuilder sbValue = new StringBuilder();
            sbField.Append("INSERT INTO  BTOC_WZYY(");
            sbValue.Append("values (");
            //sbField.Append("id");
            //sbValue.AppendFormat("'{0}'", oDecoderInfo.id);
            sbField.Append("wzyybh");
            sbValue.AppendFormat("'{0}'", Guid.NewGuid().ToString("N"));
            sbField.Append(",wzyy");
            sbValue.AppendFormat(",'{0}'", oWzyy.illeagalReason);
            sbField.Append(",px");
            sbValue.AppendFormat(",{0}", oWzyy.sorting);
            sbField.Append(",ztbj");
            sbValue.AppendFormat(",'{0}'", oWzyy.stateTag);
            sbField.Append(",wzyy)");
            sbValue.AppendFormat(",'{0}')", oWzyy.remarks);

            string cmdText = sbField.ToString() + " " + sbValue.ToString();


            try
            {
                cmdText = cmdText.Replace("\r\n", "");
                return db.ExecuteNonQuery(CommandType.Text, cmdText);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        
    }
}
