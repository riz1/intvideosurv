using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using IntVideoSurv.Entity;
using Microsoft.Practices.EnterpriseLibrary.Data;


namespace IntVideoSurv.DataAccess
{
    public class CapturePictureDataAccess
    {
        public static int Insert(Database db, CapturePicture ocapturePicture)
        {
            StringBuilder sbField = new StringBuilder();
            StringBuilder sbValue = new StringBuilder();
            sbField.Append("INSERT INTO  IVS_CapturePicture(");
            sbValue.Append("values (");
            //sbField.Append("PictureID");
            //sbValue.AppendFormat("'{0}'", ocapturePicture.PictureID);
            sbField.Append("CameraID");
            sbValue.AppendFormat("{0}", ocapturePicture.CameraID);
            sbField.Append(",Datetime");
            //sbValue.AppendFormat(",'{0}'", ocapturePicture.Datetime);
            //sbValue.AppendFormat(",'{0}'", ocapturePicture.Datetime);
            if (DataBaseParas.DBType == MyDBType.SqlServer)
            {
                sbValue.AppendFormat("'{0}'", ocapturePicture.Datetime);
            }
            else if (DataBaseParas.DBType == MyDBType.Oracle)
            {
                //sbValue.AppendFormat(",to_date('{0}','YYYY/MM/DD HH24:MI:SS')", ocapturePicture.Datetime);
                sbValue.AppendFormat(",to_timestamp('{0:yyyy/MM/dd HH:mm:ss.fff}','YYYY/MM/DD HH24:MI:SS.xff')", ocapturePicture.Datetime);
            }
            sbField.Append(",FilePath)");
            sbValue.AppendFormat(",'{0}')", ocapturePicture.FilePath);

            string cmdText = sbField.ToString() + " " + sbValue.ToString();

            try
            {
                cmdText = cmdText.Replace("\r\n", "");
                db.ExecuteNonQuery(CommandType.Text, cmdText);

                string strsql = "";
                if (DataBaseParas.DBType == MyDBType.SqlServer)
                {
                    strsql = "SELECT     ident_current('IVS_CapturePicture')";
                }
                else if (DataBaseParas.DBType == MyDBType.Oracle)
                {
                    strsql =
                    "select ID   from   IVS_CapturePicture   where  rowid=(select   max(rowid)   from   IVS_CapturePicture)";
                }

                int id = int.Parse(db.ExecuteScalar(CommandType.Text, strsql).ToString());
                return id;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public static DataSet GetCapturePicture(Database db, int cameraId, DateTime dt)
        {
            string cmdText = string.Format("select * from IVS_CapturePicture where CameraID={0} and Datetime={1}", cameraId,dt);
            try
            {
                return db.ExecuteDataSet(CommandType.Text, cmdText);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public static DataSet GetCapturePicture(Database db, int id)
        {
            string cmdText = string.Format("select * from IVS_CapturePicture where PictureID={0}", id);
            try
            {
                return db.ExecuteDataSet(CommandType.Text, cmdText);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static bool IsExistCapturePicture(Database db, int id, DateTime dt)
        {
            string cmdText = string.Format("select count(*) from IVS_CapturePicture where CameraID={0} and Datetime={1}", id, dt);
            try
            {
                return int.Parse(db.ExecuteScalar(CommandType.Text, cmdText).ToString()) > 0;

            }
            catch (Exception ex)
            {

                return false;
            }
        }

    }
}
