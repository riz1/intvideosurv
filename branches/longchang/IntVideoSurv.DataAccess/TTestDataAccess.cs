using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using IntVideoSurv.Entity;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace IntVideoSurv.DataAccess
{
    public class TTestDataAccess
    {
        public static int Insert(Database db, TTestInfo ttsetInfo)
        {
            StringBuilder sbField = new StringBuilder();
            StringBuilder sbValue = new StringBuilder();
            sbField.Append("INSERT INTO  TTest(");
            sbValue.Append("values (");
            //sbField.Append("RectID");
            //sbValue.AppendFormat("'{0}'", oRect.RectID);
            sbField.Append("id");
            sbValue.AppendFormat("{0}", ttsetInfo.Id);
            sbField.Append(",ts)");
            sbValue.AppendFormat(",to_timestamp('{0:yyyy/MM/dd HH:mm:ss.fff}','YYYY/MM/DD HH24:MI:SS.xff'))", ttsetInfo.ts);
            string cmdText = sbField.ToString() + " " + sbValue.ToString();

            try
            {
                cmdText = cmdText.Replace("\r\n", "");
                int id =db.ExecuteNonQuery(CommandType.Text, cmdText);
                return id;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static DataSet GetTTestInfo(Database db)
        {
            string cmdText = string.Format("select * from ttest");
            try
            {
                return db.ExecuteDataSet(CommandType.Text, cmdText);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}

