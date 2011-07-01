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
            sbField.Append("INSERT INTO  IVS_TempPicture(");
            sbValue.Append("values (");
            //sbField.Append("PictureID");
            //sbValue.AppendFormat("'{0}'", oTempPicture.PictureID);
            sbField.Append("CameraID");
            sbValue.AppendFormat("{0}", oTempPicture.CameraID);
            sbField.Append(",Datetime");
            //sbValue.AppendFormat(",'{0}'", oTempPicture.Datetime);
            if (DataBaseParas.DBType == MyDBType.SqlServer)
            {
                sbValue.AppendFormat(",'{0}'", oTempPicture.Datetime);
            }
            else if (DataBaseParas.DBType == MyDBType.Oracle)
            {
                sbValue.AppendFormat(",to_timestamp('{0:yyyy/MM/dd HH:mm:ss.fff}','YYYY/MM/DD HH24:MI:SS.xff')", oTempPicture.Datetime);

            }
            
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
                //string cmdText2 = "select max(PictureID) from IVS_TempPicture";
                //return int.Parse(db.ExecuteScalar(CommandType.Text, cmdText2).ToString());
                string strsql = "";
                if (DataBaseParas.DBType == MyDBType.SqlServer)
                {
                    strsql = "SELECT     ident_current('IVS_TempPicture')";
                }
                else if (DataBaseParas.DBType == MyDBType.Oracle)
                {
                    strsql =
                    "select ID   from   IVS_TempPicture   where  rowid=(select   max(rowid)   from   IVS_TempPicture)";
                }

                int id = int.Parse(db.ExecuteScalar(CommandType.Text, strsql).ToString());
                return id;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static DataSet GetTempPicture(Database db, TempPicture oTempPicture)
        {
            string cmdText = string.Format("select * from IVS_TempPicture where CameraId={0} and DateTime='{1}'", oTempPicture.CameraID,oTempPicture.Datetime);
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
            string cmdText = string.Format("select * from IVS_TempPicture where CameraId={0} and DateTime='{1}'", cameraId, captureTime);
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
            sb.Append("delete from IVS_TempPicture ");
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
