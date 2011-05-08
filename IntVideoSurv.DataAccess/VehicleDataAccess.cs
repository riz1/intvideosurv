using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using IntVideoSurv.Entity;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace IntVideoSurv.DataAccess
{
    public class VehicleDataAccess
    {
        public static int Insert(Database db, Vehicle oVehicle)
        {
            StringBuilder sbField = new StringBuilder();
            StringBuilder sbValue = new StringBuilder();
            sbField.Append("INSERT INTO  [Vehicle](");
            sbValue.Append("values (");
            sbField.Append("[VehicleID]");
            sbValue.AppendFormat("{0}", oVehicle.VehicleID);
            sbField.Append(",[platenumber]");
            sbValue.AppendFormat(",'{0}'", oVehicle.platenumber);
            sbField.Append(",[speed]");
            sbValue.AppendFormat(",{0}", oVehicle.speed);
            if (oVehicle.stemagainst == true)
            {
                sbField.Append(",[stemagainst]");
                sbValue.AppendFormat(",{0}", 1);
            }
            else
            {
                sbField.Append(",[stemagainst]");
                sbValue.AppendFormat(",{0}", 0);
            }
            if (oVehicle.stop == true)
            {
                sbField.Append(",[stop]");
                sbValue.AppendFormat(",{0}", 1);
            }
            else
            {
                sbField.Append(",[stop]");
                sbValue.AppendFormat(",{0}", 0);
            }
            if (oVehicle.accident == true)
            {
                sbField.Append(",[accident]");
                sbValue.AppendFormat(",{0}", 1);
            }
            else
            {
                sbField.Append(",[accident]");
                sbValue.AppendFormat(",{0}", 0);
            }
            if (oVehicle.linechange == true)
            {
                sbField.Append(",[linechange]");
                sbValue.AppendFormat(",{0}", 1);
            }
            else
            {
                sbField.Append(",[linechange]");
                sbValue.AppendFormat(",{0}", 0);
            }
            sbField.Append(",[platecolor]");
            sbValue.AppendFormat(",'{0}'", oVehicle.platecolor);
            sbField.Append(",[vehiclecolor]");
            sbValue.AppendFormat(",'{0}'", oVehicle.vehiclecolor);
            sbField.Append(",[PictureID]");
            sbValue.AppendFormat(",{0}", oVehicle.PictureID);
            sbField.Append(",[REctId])");
            sbValue.AppendFormat(",{0})", oVehicle.REctId);

            string cmdText = sbField.ToString() + " " + sbValue.ToString();

            try
            {
                cmdText = cmdText.Replace("\r\n", "");
                return db.ExecuteNonQuery(CommandType.Text, cmdText);
                //获得倒数第二条记录
                //int id = int.Parse(db.ExecuteScalar(CommandType.Text, "select top 2 VehicleID from Vehicle").ToString());
                //return id;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
