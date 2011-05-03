using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using IntVideoSurv.Entity;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace IntVideoSurv.DataAccess
{
    public class SystemParametersDataAccess
    {
        public static int UpdateCapturePictureFilePath(Database db, string filePath)
        {
            StringBuilder sb = new StringBuilder();
            if (IsExistRow(db))
            {
                sb.Append("update SystemParameters set");
                sb.AppendFormat(" CapturePictureFilePath='{0}'", filePath);                
            }
            else
            {
                sb.Append("insert into SystemParameters(CapturePictureFilePath) ");
                sb.AppendFormat("values('{0}')", filePath);   
            }

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
        private static bool IsExistRow(Database db)
        {
            string cmdText = "select count(*) from SystemParameters";
            try
            {
                return int.Parse(db.ExecuteScalar(CommandType.Text, cmdText).ToString())>0;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public static DataSet GetCapturePictureFilePath(Database db)
        {
            string cmdText = string.Format("select CapturePictureFilePath from SystemParameters;");
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
