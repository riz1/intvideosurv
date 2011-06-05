using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using IntVideoSurv.Entity;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace IntVideoSurv.DataAccess
{
    public class FaceDataAccess
    {
        public static int Insert(Database db, Face oFace)
        {
            StringBuilder sbField = new StringBuilder();
            StringBuilder sbValue = new StringBuilder();
            sbField.Append("INSERT INTO  Face](");
            sbValue.Append("values (");
            //sbField.Append("FaceID]");
            //sbValue.AppendFormat("'{0}'", oFace.FaceID);
            sbField.Append("score]");
            sbValue.AppendFormat("'{0}'", oFace.score);
            sbField.Append(",RectID]");
            sbValue.AppendFormat(",{0}", oFace.RectID);
            sbField.Append(",PictureID]");
            sbValue.AppendFormat(",{0}", oFace.PictureID);
            sbField.Append(",FacePath])");
            sbValue.AppendFormat(",'{0}')", oFace.FacePath);
            string cmdText = sbField.ToString() + " " + sbValue.ToString();

            try
            {
                cmdText = cmdText.Replace("\r\n", "");
                db.ExecuteNonQuery(CommandType.Text, cmdText);
                string strsql = "";
                if (DataBaseParas.DBType == MyDBType.SqlServer)
                {
                    strsql = "SELECT     ident_current('Face')";
                }
                else if (DataBaseParas.DBType == MyDBType.Oracle)
                {
                    strsql =
                    "select ID   from   Face   where  rowid=(select   max(rowid)   from   Face)";
                }

                int id = int.Parse(db.ExecuteScalar(CommandType.Text, strsql).ToString());
                return id;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static DataSet GetFaceCustom(Database db, string str)
        {
            str = str.Replace("''", "'");
            string cmdText = string.Format(
                "select Face.FaceId,Face.Score,Face.RectId, Face.FacePath,Face.PictureId,VideoInfo.Id as VideoId " +
                "from Face,CapturePicture,VideoInfo " +
                "where Face.PictureId=CapturePicture.PictureId and " +
                "CapturePicture.CameraId = VideoInfo.CameraId and (CapturePicture.DateTime] between VideoInfo.CaptureTimeBegin and VideoInfo.CaptureTimeEnd) {0} order by CapturePicture.DateTime] desc", str);
            try
            {
                return db.ExecuteDataSet(CommandType.Text, cmdText);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public static int GetFaceCustomQuantity(Database db, string str)
        {
            str = str.Replace("''", "'");
            string cmdText = string.Format(
                "select count(distinct Face.FaceId) " +
                "from Face,CapturePicture,VideoInfo " +
                "where Face.PictureId=CapturePicture.PictureId and " +
                "CapturePicture.CameraId = VideoInfo.CameraId and (CapturePicture.DateTime between VideoInfo.CaptureTimeBegin and VideoInfo.CaptureTimeEnd) {0}", str);
            try
            {
                return int.Parse(db.ExecuteScalar(CommandType.Text, cmdText).ToString());
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public static DataSet GetFaceCustom(Database db, string str, int pageno,int pagesize)
        {
            string fields = " Face.FaceId,Face.Score,Face.RectId, Face.FacePath,Face.PictureId,VideoInfo.Id as VideoId ";
            string tables = " Face,CapturePicture,VideoInfo ";
            string condition=string.Format(
                " Face.PictureId=CapturePicture.PictureId and " +
                "CapturePicture.CameraId = VideoInfo.CameraId and (CapturePicture.DateTime between VideoInfo.CaptureTimeBegin and VideoInfo.CaptureTimeEnd) {0} ", str);
            string ordercolumn = " DateTime ";
            byte ordertype = 1;
            string pkcolumn = " FaceId ";
            string cmdText = "";

            if (DataBaseParas.DBType==MyDBType.SqlServer)
            {
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
            }
            else if (DataBaseParas.DBType == MyDBType.Oracle)
            {
                //select * from (select a.*,rownum rn  from face a where rownum <= 40) where rn >= 20 order by faceid desc; 
                cmdText = string.Format("SELECT * FROM (select {0},rownum rn from {1} where rownum <={2} and {3} order by {4}) where rn>={5} order by faceid", 
                    fields, tables, pageno * pagesize,condition, pkcolumn,(pageno - 1) * pagesize);

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
