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
            sbField.Append("INSERT INTO  IVS_EventInfo(");
            sbValue.Append("values (");
            sbField.Append("CarNum");
            sbValue.AppendFormat("{0}", oEvent.CarNum);
            sbField.Append(",Congestion");
            sbValue.AppendFormat(",{0}", oEvent.Congestion);
            sbField.Append(",PictureID)");
            sbValue.AppendFormat(",{0})", oEvent.PictureID);
            string cmdText = sbField.ToString() + " " + sbValue.ToString();

            try
            {
                cmdText = cmdText.Replace("\r\n", "");
                db.ExecuteNonQuery(CommandType.Text, cmdText);

                string strsql = "";
                if (DataBaseParas.DBType == MyDBType.SqlServer)
                {
                    strsql = "SELECT     ident_current('IVS_EventInfo')";
                }
                else if (DataBaseParas.DBType == MyDBType.Oracle)
                {
                    strsql =
                    "select ID   from   IVS_EventInfo   where  rowid=(select   max(rowid)   from   IVS_EventInfo)";
                }

                int id = int.Parse(db.ExecuteScalar(CommandType.Text, strsql).ToString());
                return id;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static DataSet GetEventCustom(Database db, string str)
        {
            str = str.Replace("''", "'");
            string cmdText = string.Format(
                "select IVS_EventInfo.EventId,IVS_EventInfo.CarNum,IVS_EventInfo.Congestion,IVS_EventInfo.PictureId,IVS_VideoInfo.id AS VideoId " +
                "from IVS_EventInfo,IVS_CapturePicture,IVS_VideoInfo " +
                "where IVS_EventInfo.PictureId=IVS_CapturePicture.PictureId and " +
                "IVS_CapturePicture.CameraId = IVS_VideoInfo.CameraId and (IVS_CapturePicture.DateTime between IVS_VideoInfo.CaptureTimeBegin and IVS_VideoInfo.CaptureTimeEnd) {0} order by IVS_CapturePicture.DateTime desc", str);
            try
            {
                return db.ExecuteDataSet(CommandType.Text, cmdText);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public static int GetEventCustomQuantity(Database db, string str)
        {
            str = str.Replace("''", "'");
            string cmdText = string.Format(
                "select count(distinct IVS_EventInfo.EventId) " +
                "from IVS_EventInfo,IVS_CapturePicture,IVS_VideoInfo " +
                "where IVS_EventInfo.PictureId=IVS_CapturePicture.PictureId and " +
                "IVS_CapturePicture.CameraId = IVS_VideoInfo.CameraId and (IVS_CapturePicture.DateTime between IVS_VideoInfo.CaptureTimeBegin and IVS_VideoInfo.CaptureTimeEnd) {0};", str);
            try
            {
                return int.Parse(db.ExecuteScalar(CommandType.Text, cmdText).ToString());
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static DataSet GetEventCustom(Database db, string str, int pageno, int pagesize)
        {
            string fields = " IVS_EventInfo.EventId,IVS_EventInfo.CarNum,IVS_EventInfo.Congestion,IVS_EventInfo.PictureId,IVS_VideoInfo.Id as VideoId ";
            string tables = " IVS_EventInfo,IVS_CapturePicture,IVS_VideoInfo ";
            string condition = string.Format(
                " IVS_EventInfo.PictureId=IVS_CapturePicture.PictureId and " +
                "IVS_CapturePicture.CameraId = IVS_VideoInfo.CameraId and (IVS_CapturePicture.DateTime between IVS_VideoInfo.CaptureTimeBegin and IVS_VideoInfo.CaptureTimeEnd) {0} ", str);
            string ordercolumn = " DateTime ";
            byte ordertype = 1;
            string pkcolumn = " EventId ";
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
    }
}
