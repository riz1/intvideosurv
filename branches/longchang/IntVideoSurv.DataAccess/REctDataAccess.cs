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
            sbField.Append("INSERT INTO  REct(");
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
                int id = int.Parse(db.ExecuteScalar(CommandType.Text, "SELECT     ident_current('REct')").ToString());
                return id;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
