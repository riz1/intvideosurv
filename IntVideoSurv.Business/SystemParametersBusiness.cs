using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using IntVideoSurv.Entity;
using IntVideoSurv.DataAccess;
using log4net;

namespace IntVideoSurv.Business
{
    public class SystemParametersBusiness
    {
        public static readonly ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private static SystemParametersBusiness instance;
        public static SystemParametersBusiness Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SystemParametersBusiness();
                }
                return instance;
            }
        }
        public int SetCapturePictureFilePath(ref string errMessage, string filePath)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            try
            {
                return SystemParametersDataAccess.UpdateCapturePictureFilePath(db, filePath);

            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return -1;
            }
        }

        public string GetCapturePictureFilePath(ref string errMessage)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            try
            {
                DataSet ds = SystemParametersDataAccess.GetCapturePictureFilePath(db);
                if (ds.Tables[0].Rows.Count == 0)
                {
                    return null;
                }
                return (ds.Tables[0].Rows[0]).ToString();

            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return null;
            }
        }
    }
}
