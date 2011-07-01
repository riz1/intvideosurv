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
            sbField.Append("INSERT INTO  EvenRectInfo(");
            sbValue.Append("values (");
            //sbField.Append("FaceID");
            //sbValue.AppendFormat("'{0}'", oFace.FaceID);
            sbField.Append("x");
            sbValue.AppendFormat("{0}", oEventRect.x);
            sbField.Append(",y");
            sbValue.AppendFormat(",{0}", oEventRect.y);
            sbField.Append(",w");
            sbValue.AppendFormat(",{0}", oEventRect.w);
            sbField.Append(",h");
            sbValue.AppendFormat(",{0}", oEventRect.h);
            sbField.Append(",ObjectId)");
            sbValue.AppendFormat(",{0})", oEventRect.ObjectId);
            string cmdText = sbField.ToString() + " " + sbValue.ToString();

            try
            {
                cmdText = cmdText.Replace("\r\n", "");
                db.ExecuteNonQuery(CommandType.Text, cmdText);
                string strsql = "";
                if (DataBaseParas.DBType == MyDBType.SqlServer)
                {
                    strsql = "SELECT     ident_current('EvenRectInfo')";
                }
                else if (DataBaseParas.DBType == MyDBType.Oracle)
                {
                    strsql =
                    "select ID   from   EvenRectInfo   where  rowid=(select   max(rowid)   from   EvenRectInfo)";
                }

                int id = int.Parse(db.ExecuteScalar(CommandType.Text, strsql).ToString());
                return id;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static DataSet GetEventRectCustom(Database db, int objectid)
        {
            string cmdText = string.Format(
                "select IVS_EventRectInfo.EventRectId,IVS_EventRectInfo.x,IVS_EventRectInfo.y,IVS_EventRectInfo.w,IVS_EventRectInfo.h,IVS_EventRectInfo.ObjectId " +
                "from IVS_EventRectInfo " +
                "where IVS_EventRectInfo.ObjectId={0} order by EventRectId",objectid);
            try
            {
                return db.ExecuteDataSet(CommandType.Text, cmdText);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public static int GetEventRectCustomQuantity(Database db, int objectid)
        {
            string cmdText = string.Format(
                "select count(distinct IVS_EventRectInfo.EventRectId) " +
                "from IVS_EventRectInfo " +
                "where IVS_EventRectInfo.ObjectId={0}",objectid);
            try
            {
                return int.Parse(db.ExecuteScalar(CommandType.Text, cmdText).ToString());
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /*public static DataSet GetEventRectCustom(Database db, string str, int pageno, int pagesize)
        {
            string fields = " IVS_EventRectInfo.EventRectId,IVS_EventRectInfo.x,IVS_EventRectInfo.y,IVS_EventRectInfo.w,IVS_EventRectInfo.h,IVS_EventRectInfo.ObjectId ";
            string tables = " IVS_EventInfo ";
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
        }*/
    }
}
