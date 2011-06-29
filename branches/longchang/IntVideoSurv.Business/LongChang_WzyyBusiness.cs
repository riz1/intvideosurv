using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using IntVideoSurv.DataAccess;
using IntVideoSurv.Entity;
using log4net;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace IntVideoSurv.Business
{
    public class LongChang_WzyyBusiness
    {
        public static readonly ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private static LongChang_WzyyBusiness instance;
        public static LongChang_WzyyBusiness Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new LongChang_WzyyBusiness();
                }
                return instance;
            }
        }

        public Dictionary<string, LongChang_WzyyInfo> GetAllWzyyInfo(ref string errMessage)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            Dictionary<string, LongChang_WzyyInfo> list = new Dictionary<string, LongChang_WzyyInfo>();
            try
            {

                DataSet ds = LongChang_WzyyDataAccess.GetAllWzyyInfo(db);

                LongChang_WzyyInfo oVehType;
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    oVehType = new LongChang_WzyyInfo(ds.Tables[0].Rows[i]);
                    list.Add(oVehType.illeagalReasonNum, oVehType);


                }
                return list;

            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return new Dictionary<string, LongChang_WzyyInfo>();
            }
        }

        public int Insert(ref string errMessage, LongChang_WzyyInfo wzyy)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            try
            {
                return LongChang_WzyyDataAccess.Insert(db, wzyy);

            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return -1;
            }
        }



    }
}
