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
            sbField.Append("INSERT INTO  [CapturePicture](");
            sbValue.Append("values (");
            //sbField.Append("[PictureID]");
            //sbValue.AppendFormat("'{0}'", ocapturePicture.PictureID);
            sbField.Append("[CameraID]");
            sbValue.AppendFormat("{0}", ocapturePicture.CameraID);
            sbField.Append(",[Datetime]");
            //sbValue.AppendFormat(",'{0}'", ocapturePicture.Datetime);
            sbValue.AppendFormat(",'{0}'", ocapturePicture.Datetime);
            sbField.Append(",[FilePath])");
            sbValue.AppendFormat(",'{0}')", ocapturePicture.FilePath);

            string cmdText = sbField.ToString() + " " + sbValue.ToString();

            try
            {
                cmdText = cmdText.Replace("\r\n", "");
                db.ExecuteNonQuery(CommandType.Text, cmdText);
                //string cmdText2 = "select max(PictureID) from CapturePicture";
                //return int.Parse(db.ExecuteScalar(CommandType.Text, cmdText2).ToString());
                int id = int.Parse(db.ExecuteScalar(CommandType.Text, "SELECT     ident_current('CapturePicture')").ToString());
                return id;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public static DataSet GetTheCapturePicture(Database db, int id, DateTime dt)
        {
            string cmdText = string.Format("select * from CapturePicture where CameraID={0} and Datetime={0}", id,dt);
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
