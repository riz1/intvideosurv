using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using IntVideoSurv.Entity;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace IntVideoSurv.DataAccess
{
    public class TempPictureDataAccess
    {
        public static int InsertTempPicture(Database db, TempPicture oTempPicture)
        {
            StringBuilder sbField = new StringBuilder();
            StringBuilder sbValue = new StringBuilder();
            sbField.Append("INSERT INTO  TempPicture(");
            sbValue.Append("values (");
            //sbField.Append("PictureID");
            //sbValue.AppendFormat("'{0}'", oTempPicture.PictureID);
            sbField.Append("CameraID");
            sbValue.AppendFormat("{0}", oTempPicture.CameraID);
            sbField.Append(",Datetime");
            //sbValue.AppendFormat(",'{0}'", oTempPicture.Datetime);
            sbValue.AppendFormat(",'{0}'", oTempPicture.Datetime);
            sbField.Append(",IsHistroy");
            //sbValue.AppendFormat(",'{0}'", oTempPicture.Datetime);
            sbValue.AppendFormat(",'{0}'", oTempPicture.IsHistroy);
            sbField.Append(",FilePath)");
            sbValue.AppendFormat(",'{0}')", oTempPicture.FilePath);

            string cmdText = sbField.ToString() + " " + sbValue.ToString();

            try
            {
                cmdText = cmdText.Replace("\r\n", "");
                db.ExecuteNonQuery(CommandType.Text, cmdText);
                //string cmdText2 = "select max(PictureID) from TempPicture";
                //return int.Parse(db.ExecuteScalar(CommandType.Text, cmdText2).ToString());
                int id = int.Parse(db.ExecuteScalar(CommandType.Text, "SELECT     ident_current('TempPicture')").ToString());
                return id;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static DataSet GetTempPicture(Database db, TempPicture oTempPicture)
        {
            string cmdText = string.Format("select * from TempPicture where CameraId={0} and DateTime='{1}'", oTempPicture.CameraID,oTempPicture.Datetime);
            try
            {
                return db.ExecuteDataSet(CommandType.Text, cmdText);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static DataSet GetTempPicture(Database db, int cameraId, DateTime captureTime)
        {
            string cmdText = string.Format("select * from TempPicture where CameraId={0} and DateTime='{1}'", cameraId, captureTime);
            try
            {
                return db.ExecuteDataSet(CommandType.Text, cmdText);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public static int DeleteTempPicture(Database db, int pictureId)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("delete from TempPicture ");
            sb.AppendFormat(" where PictureId={0}", pictureId);
            string cmdText = sb.ToString();
            try
            {
                return db.ExecuteNonQuery(CommandType.Text, cmdText);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
