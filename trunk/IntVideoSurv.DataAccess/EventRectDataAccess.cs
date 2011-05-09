using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using IntVideoSurv.Entity;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace IntVideoSurv.DataAccess
{
    public class EventRectDataAccess
    {
        public static int Insert(Database db, EventRect oEventRect)
        {
            StringBuilder sbField = new StringBuilder();
            StringBuilder sbValue = new StringBuilder();
            sbField.Append("INSERT INTO  [EvenRectInfo](");
            sbValue.Append("values (");
            //sbField.Append("[FaceID]");
            //sbValue.AppendFormat("'{0}'", oFace.FaceID);
            sbField.Append("[x]");
            sbValue.AppendFormat("{0}", oEventRect.x);
            sbField.Append(",[y]");
            sbValue.AppendFormat(",{0}", oEventRect.y);
            sbField.Append(",[w]");
            sbValue.AppendFormat(",{0}", oEventRect.w);
            sbField.Append(",[h]");
            sbValue.AppendFormat(",{0}", oEventRect.h);
            sbField.Append(",[ObjectId])");
            sbValue.AppendFormat(",{0})", oEventRect.ObjectId);
            string cmdText = sbField.ToString() + " " + sbValue.ToString();

            try
            {
                cmdText = cmdText.Replace("\r\n", "");
                db.ExecuteNonQuery(CommandType.Text, cmdText);
                int id = int.Parse(db.ExecuteScalar(CommandType.Text, "SELECT     ident_current('EventRectInfo')").ToString());
                return id;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
