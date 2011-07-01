using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using IntVideoSurv.Entity;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace IntVideoSurv.DataAccess
{
    public class REctDataAccess
    {
        public static int Insert(Database db, REct oRect)
        {
            StringBuilder sbField = new StringBuilder();
            StringBuilder sbValue = new StringBuilder();
            sbField.Append("INSERT INTO  IVS_REct(");
            sbValue.Append("values (");
            //sbField.Append("RectID");
            //sbValue.AppendFormat("'{0}'", oRect.RectID);
            sbField.Append("X");
            sbValue.AppendFormat("{0}", oRect.X);
            sbField.Append(",Y");
            sbValue.AppendFormat(",{0}", oRect.Y);
            sbField.Append(",W");
            sbValue.AppendFormat(",{0}", oRect.W);
            sbField.Append(",H)");
            sbValue.AppendFormat(",{0})", oRect.H);
            string cmdText = sbField.ToString() + " " + sbValue.ToString();

            try
            {
                cmdText = cmdText.Replace("\r\n", "");
                db.ExecuteNonQuery(CommandType.Text, cmdText);

                string strsql = "";
                if (DataBaseParas.DBType == MyDBType.SqlServer)
                {
                    strsql = "SELECT     ident_current('IVS_REct')";
                }
                else if (DataBaseParas.DBType == MyDBType.Oracle)
                {
                    strsql =
                    "select ID   from   IVS_REct   where  rowid=(select   max(rowid)   from   IVS_REct)";
                }

                int id = int.Parse(db.ExecuteScalar(CommandType.Text, strsql).ToString());
                return id;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
