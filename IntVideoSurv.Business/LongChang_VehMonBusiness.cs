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
    public class LongChang_VehMonBusiness
    {
        public static readonly ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private static LongChang_VehMonBusiness instance;
        public static LongChang_VehMonBusiness Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new LongChang_VehMonBusiness();
                }
                return instance;
            }
        }

        public Dictionary<string, LongChang_VehMonInfo> GetAllVehMonInfo(ref string errMessage)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            Dictionary<string, LongChang_VehMonInfo> list = new Dictionary<string, LongChang_VehMonInfo>();
            try
            {

                DataSet ds = LongChang_VehMonDataAccess.GetAllVehMonInfo(db);

                LongChang_VehMonInfo oVehMon;
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    oVehMon = new LongChang_VehMonInfo(ds.Tables[0].Rows[i]);
                    list.Add(oVehMon.vehMonId, oVehMon);


                }
                return list;

            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return new Dictionary<string, LongChang_VehMonInfo>();
            }
        }

        public string Insert(ref string errMessage, LongChang_VehMonInfo vehmon)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            try
            {
                var id = LongChang_VehMonDataAccess.Insert(db, vehmon);
                logger.Debug("write database successfully");
                return id;

            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return "";
            }
        }


    }
}
