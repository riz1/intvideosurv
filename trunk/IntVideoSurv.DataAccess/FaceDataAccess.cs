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
            sbField.Append("INSERT INTO  [Face](");
            sbValue.Append("values (");
            //sbField.Append("[FaceID]");
            //sbValue.AppendFormat("'{0}'", oFace.FaceID);
            sbField.Append("[score]");
            sbValue.AppendFormat("'{0}'", oFace.score);
            sbField.Append(",[RectID]");
            sbValue.AppendFormat(",{0}", oFace.RectID);
            sbField.Append(",[PictureID]");
            sbValue.AppendFormat(",{0}", oFace.PictureID);
            sbField.Append(",[FacePath])");
            sbValue.AppendFormat(",'{0}')", oFace.FacePath);
            string cmdText = sbField.ToString() + " " + sbValue.ToString();

            try
            {
                cmdText = cmdText.Replace("\r\n", "");
                db.ExecuteNonQuery(CommandType.Text, cmdText);
                int id = int.Parse(db.ExecuteScalar(CommandType.Text, "SELECT     ident_current('Face')").ToString());
                return id;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static DataSet GetFaceCustom(Database db, string str)
        {
            string cmdText = string.Format(
                "select Face.FaceId,Face.Score,Face.RectId, Face.FacePath,Face.PictureId,VideoInfo.Id as VideoId " +
                "from Face,CapturePicture,VideoInfo " +
                "where Face.PictureId=CapturePicture.PictureId and " +
                "CapturePicture.CameraId = VideoInfo.CameraId and (CapturePicture.[DateTime] between VideoInfo.CaptureTimeBegin and VideoInfo.CaptureTimeEnd) {0};", str);
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
