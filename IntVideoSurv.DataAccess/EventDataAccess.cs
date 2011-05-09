using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using IntVideoSurv.Entity;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace IntVideoSurv.DataAccess
{
    public class EventDataAccess
    {
        public static int Insert(Database db, Event oEvent)
        {
            StringBuilder sbField = new StringBuilder();
            StringBuilder sbValue = new StringBuilder();
            sbField.Append("INSERT INTO  [EventInfo](");
            sbValue.Append("values (");
            sbField.Append("[CarNum]");
            sbValue.AppendFormat("{0}", oEvent.CarNum);
            sbField.Append(",[Congestion]");
            sbValue.AppendFormat(",{0}", oEvent.Congestion);
            sbField.Append(",[PictureID])");
            sbValue.AppendFormat(",{0})", oEvent.PictureID);
            string cmdText = sbField.ToString() + " " + sbValue.ToString();

            try
            {
                cmdText = cmdText.Replace("\r\n", "");
                db.ExecuteNonQuery(CommandType.Text, cmdText);
                int id = int.Parse(db.ExecuteScalar(CommandType.Text, "SELECT     ident_current('EventInfo')").ToString());
                return id;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
