using System;
using System.Collections.Generic;
using System.Data;
using IntVideoSurv.DataAccess;
using IntVideoSurv.Entity;
using log4net;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace IntVideoSurv.Business
{
    public class TTestInfoBusiness
    {
        public static readonly ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private static TTestInfoBusiness instance;
        public static TTestInfoBusiness Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new TTestInfoBusiness();
                }
                return instance;
            }
        }
        public int Insert(ref string errMessage, TTestInfo oCameraInfo)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            try
            {
                return TTestDataAccess.Insert(db, oCameraInfo);

            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return -1;
            }
        }

        public List<TTestInfo> GetAllTTestInfo(ref string errMessage)
        {
 
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            List<TTestInfo> list = new List<TTestInfo>();
            try
            {
                TTestInfo testInfo;
                DataSet ds = TTestDataAccess.GetTTestInfo(db);

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    testInfo = new TTestInfo(ds.Tables[0].Rows[i]);
                    list.Add( testInfo);
                }
                return list;

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
