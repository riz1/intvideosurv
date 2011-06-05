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
            sbField.Append("INSERT INTO  EventInfo(");
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
                int id = int.Parse(db.ExecuteScalar(CommandType.Text, "SELECT     ident_current('EventInfo')").ToString());
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
                "select EventInfo.EventId,EventInfo.CarNum,EventInfo.Congestion,EventInfo.PictureId,VideoInfo.id AS VideoId " +
                "from EventInfo,CapturePicture,VideoInfo " +
                "where EventInfo.PictureId=CapturePicture.PictureId and " +
                "CapturePicture.CameraId = VideoInfo.CameraId and (CapturePicture.DateTime between VideoInfo.CaptureTimeBegin and VideoInfo.CaptureTimeEnd) {0} order by CapturePicture.DateTime desc", str);
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
                "select count(distinct EventInfo.EventId) " +
                "from EventInfo,CapturePicture,VideoInfo " +
                "where EventInfo.PictureId=CapturePicture.PictureId and " +
                "CapturePicture.CameraId = VideoInfo.CameraId and (CapturePicture.DateTime between VideoInfo.CaptureTimeBegin and VideoInfo.CaptureTimeEnd) {0};", str);
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
            string fields = " EventInfo.EventId,EventInfo.CarNum,EventInfo.Congestion,EventInfo.PictureId,VideoInfo.Id as VideoId ";
            string tables = " EventInfo,CapturePicture,VideoInfo ";
            string condition = string.Format(
                " EventInfo.PictureId=CapturePicture.PictureId and " +
                "CapturePicture.CameraId = VideoInfo.CameraId and (CapturePicture.DateTime between VideoInfo.CaptureTimeBegin and VideoInfo.CaptureTimeEnd) {0} ", str);
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
