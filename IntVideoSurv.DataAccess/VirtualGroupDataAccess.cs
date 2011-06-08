using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using IntVideoSurv.Entity;
using Microsoft.Practices.EnterpriseLibrary.Data;
namespace IntVideoSurv.DataAccess
{
    public class VirtualGroupDataAccess
    {
        public static int Insert(Database db, VirtualGroupInfo oVirtualGroup)
        {
            StringBuilder sbField = new StringBuilder();
            StringBuilder sbValue = new StringBuilder();
            sbField.Append("INSERT INTO  [VirtualGroup](");
            sbValue.Append("values (");
            sbField.Append("[ID]");
            sbValue.AppendFormat("{0}", oVirtualGroup.ID);
            sbField.Append("[Name])");
            sbValue.AppendFormat("'{0}')", oVirtualGroup.Name);
            string cmdText = sbField.ToString() + " " + sbValue.ToString();

            try
            {
                cmdText = cmdText.Replace("\r\n", "");
                db.ExecuteNonQuery(CommandType.Text, cmdText);
                int id = int.Parse(db.ExecuteScalar(CommandType.Text, "SELECT     ident_current('VirtualGroup')").ToString());
                return id;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
