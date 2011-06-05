using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using IntVideoSurv.Entity;
using Microsoft.Practices.EnterpriseLibrary.Data;
namespace IntVideoSurv.DataAccess
{
    public class TrackDataAccess
    {
        public static int Insert(Database db, Track oTrack)
        {
            StringBuilder sbField = new StringBuilder();
            StringBuilder sbValue = new StringBuilder();
            sbField.Append("INSERT INTO  Track(");
            sbValue.Append("values (");
            //sbField.Append("Id");
            //sbValue.AppendFormat("'{0}'", oTrack.Id);
            sbField.Append("REct)");
            sbValue.AppendFormat("'{0}')", oTrack.REct);
            string cmdText = sbField.ToString() + " " + sbValue.ToString();

            try
            {
                cmdText = cmdText.Replace("\r\n", "");
                db.ExecuteNonQuery(CommandType.Text, cmdText);
                string strsql = "";
                if (DataBaseParas.DBType ==MyDBType.SqlServer)
                {
                    strsql = "SELECT ident_current('Track')";
                }
                else if (DataBaseParas.DBType ==MyDBType.Oracle)
                {
                    strsql =
                    "select ID   from   Track   where  rowid=(select   max(rowid)   from   Track)";
                }
                
                int id = int.Parse(db.ExecuteScalar(CommandType.Text,strsql).ToString());
                return id;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
