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
            sbField.Append("INSERT INTO  IVS_Vehicle(");
            sbValue.Append("values (");
            sbField.Append("VehicleID");
            sbValue.AppendFormat("{0}", oVehicle.VehicleID);
            sbField.Append(",platenumber");
            sbValue.AppendFormat(",'{0}'", oVehicle.platenumber);
            sbField.Append(",speed");
            sbValue.AppendFormat(",{0}", oVehicle.speed);
            if (oVehicle.stemagainst == true)
            {
                sbField.Append(",stemagainst");
                sbValue.AppendFormat(",{0}", 1);
            }
            else
            {
                sbField.Append(",stemagainst");
                sbValue.AppendFormat(",{0}", 0);
            }
            if (oVehicle.stop == true)
            {
                sbField.Append(",stop");
                sbValue.AppendFormat(",{0}", 1);
            }
            else
            {
                sbField.Append(",stop");
                sbValue.AppendFormat(",{0}", 0);
            }
            if (oVehicle.accident == true)
            {
                sbField.Append(",accident");
                sbValue.AppendFormat(",{0}", 1);
            }
            else
            {
                sbField.Append(",accident");
                sbValue.AppendFormat(",{0}", 0);
            }
            if (oVehicle.linechange == true)
            {
                sbField.Append(",linechange");
                sbValue.AppendFormat(",{0}", 1);
            }
            else
            {
                sbField.Append(",linechange");
                sbValue.AppendFormat(",{0}", 0);
            }
            sbField.Append(",platecolor");
            sbValue.AppendFormat(",'{0}'", oVehicle.platecolor);
            sbField.Append(",vehiclecolor");
            sbValue.AppendFormat(",'{0}'", oVehicle.vehiclecolor);
            sbField.Append(",PictureID");
            sbValue.AppendFormat(",{0}", oVehicle.PictureID);
            sbField.Append(",REctId)");
            sbValue.AppendFormat(",{0})", oVehicle.REctId);

            string cmdText = sbField.ToString() + " " + sbValue.ToString();

            try
            {
                cmdText = cmdText.Replace("\r\n", "");
                return db.ExecuteNonQuery(CommandType.Text, cmdText);
                //获得倒数第二条记录
                //int id = int.Parse(db.ExecuteScalar(CommandType.Text, "select top 2 VehicleID from IVS_Vehicle").ToString());
                //return id;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public static int GetVehicleCountByPlateNumber(Database db, string number)
        {
            string cmdText = string.Format("select count(platenumber) from IVS_Vehicle where platenumber='{0}'", number);
            try
            {
                return int.Parse(db.ExecuteDataSet(CommandType.Text, cmdText).ToString());

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public static DataSet GetVehicleCustom(Database db, string str)
        {
            string cmdText = string.Format(
                "select IVS_Vehicle.VehicleID,IVS_Vehicle.platenumber,IVS_Vehicle.speed,IVS_Vehicle.stemagainst,IVS_Vehicle.stop,IVS_Vehicle.accident"+
                ",IVS_Vehicle.linechange,IVS_Vehicle.platecolor,IVS_Vehicle.vehiclecolor,IVS_Vehicle.PictureID,IVS_Vehicle.RectId"+
                ",IVS_Vehicle.confidence,IVS_VideoInfo.ID as VideoId " +
                "from IVS_Vehicle,IVS_CapturePicture,IVS_VideoInfo " +
                "where IVS_Vehicle.PictureID=IVS_CapturePicture.PictureID and " +
                "IVS_CapturePicture.CameraID = IVS_VideoInfo.CameraId and (IVS_CapturePicture.Datetime between IVS_VideoInfo.CaptureTimeBegin and IVS_VideoInfo.CaptureTimeEnd) {0};", str);
            try
            {
                return db.ExecuteDataSet(CommandType.Text, cmdText);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public static DataSet GetVehicleCustom(Database db, string str, int pageno,int pagesize)
        {
            string fields = " IVS_Vehicle.VehicleID,IVS_Vehicle.platenumber,IVS_Vehicle.speed,IVS_Vehicle.stemagainst,IVS_Vehicle.stop,IVS_Vehicle.accident,IVS_Vehicle.linechange,IVS_Vehicle.platecolor,IVS_Vehicle.vehiclecolor,IVS_Vehicle.pictureID,IVS_Vehicle.RectId,IVS_Vehicle.confidence,IVS_VideoInfo.ID as VideoId ";
            string tables = " IVS_Vehicle,IVS_CapturePicture,IVS_VideoInfo ";
            string condition = string.Format(
                " IVS_Vehicle.PictureID=IVS_CapturePicture.PictureID and " +
                "IVS_CapturePicture.CameraID = IVS_VideoInfo.CameraId and (IVS_CapturePicture.Datetime between IVS_VideoInfo.CaptureTimeBegin and IVS_VideoInfo.CaptureTimeEnd) {0} ", str);
            string ordercolumn = " Datetime ";
            byte ordertype = 1;
            string pkcolumn = " VehicleID ";
            string cmdText = "";
            if (pageno == 1)
            {
                cmdText = string.Format("SELECT TOP {0} {1} FROM {2}"
                + " WHERE {3}  order by {4} {5}", pagesize, fields, tables, condition, ordercolumn, ordertype == 1 ? "desc" : "asc");

            }
            else
            {
                cmdText = string.Format("SELECT TOP {0} {1} FROM {2}"
                + " WHERE {3} AND "
                + " {4}>(SELECT max({4}) FROM (SELECT TOP {5} "
                + " {4} FROM {2} order by {6} {7}) AS TabTemp) order by {6} {7}", pagesize, fields, tables, condition, pkcolumn, (pageno - 1) * pagesize, ordercolumn, ordertype == 1 ? "desc" : "asc");

            }
            try
            {
                return db.ExecuteDataSet(CommandType.Text, cmdText);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static int GetVehicleCustomQuantity(Database db, string str)
        {
            str = str.Replace("''", "'");
            string cmdText = string.Format(
                "select count(distinct IVS_Vehicle.VehicleID) " +
                "from IVS_Vehicle,IVS_CapturePicture,IVS_VideoInfo " +
                "where IVS_Vehicle.PictureID=IVS_CapturePicture.PictureID and " +
                "IVS_CapturePicture.CameraID = IVS_VideoInfo.CameraId and (IVS_CapturePicture.Datetime between IVS_VideoInfo.CaptureTimeBegin and IVS_VideoInfo.CaptureTimeEnd) {0};", str);
            try
            {
                return int.Parse(db.ExecuteScalar(CommandType.Text, cmdText).ToString());
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
