using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using IntVideoSurv.Entity;
using Microsoft.Practices.EnterpriseLibrary.Data;
namespace IntVideoSurv.DataAccess
{
    public class CameraGroupDataAccess
    {
        public static int Insert(Database db, CameraGroupInfo oCameraGroup)
        {
            StringBuilder sbField = new StringBuilder();
            StringBuilder sbValue = new StringBuilder();
            sbField.Append("INSERT INTO  [CameraGroup](");
            sbValue.Append("values (");
            sbField.Append("[ID]");
            sbValue.AppendFormat("{0}", oCameraGroup.ID);
            sbField.Append("[GroupID]");
            sbValue.AppendFormat("{0}", oCameraGroup.GroupID);
            sbField.Append("[CameraID])");
            sbValue.AppendFormat("{0})", oCameraGroup.CameraID);
            string cmdText = sbField.ToString() + " " + sbValue.ToString();

            try
            {
                cmdText = cmdText.Replace("\r\n", "");
                db.ExecuteNonQuery(CommandType.Text, cmdText);
                int id = int.Parse(db.ExecuteScalar(CommandType.Text, "SELECT     ident_current('CameraGroup')").ToString());
                return id;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
