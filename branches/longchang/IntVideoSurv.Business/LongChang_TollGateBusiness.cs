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
    public class LongChang_TollGateBusiness
    {
        public static readonly ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private static LongChang_TollGateBusiness instance;
        public static LongChang_TollGateBusiness Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new LongChang_TollGateBusiness();
                }
                return instance;
            }
        }

        public Dictionary<string, LongChang_TollGateInfo> GetAllTollGateInfo(ref string errMessage)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            Dictionary<string, LongChang_TollGateInfo> list = new Dictionary<string, LongChang_TollGateInfo>();
            try
            {

                DataSet ds = LongChang_TollGateDataAccess.GetAllTollGateInfo(db);

                LongChang_TollGateInfo oTollGate;
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    oTollGate = new LongChang_TollGateInfo(ds.Tables[0].Rows[i]);
                    list.Add(oTollGate.tollGateID, oTollGate);


                }
                return list;

            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return new Dictionary<string, LongChang_TollGateInfo>();
            }
        }
        public Dictionary<string, LongChang_TollGateInfo> GetTollGateInfoById(ref string errMessage, int tollid)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            Dictionary<string, LongChang_TollGateInfo> list = new Dictionary<string, LongChang_TollGateInfo>();
            try
            {

                DataSet ds = LongChang_TollGateDataAccess.GetTollGateInfoById(db,tollid);

                LongChang_TollGateInfo oTollGate;
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    oTollGate = new LongChang_TollGateInfo(ds.Tables[0].Rows[i]);
                    list.Add(oTollGate.tollGateID, oTollGate);


                }
                return list;

            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return new Dictionary<string, LongChang_TollGateInfo>(); 
            }
        }

        public LongChang_TollGateInfo GetTollGateInfoByCameraId(ref string errMessage, int Id)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            try
            {
                DataSet ds = LongChang_TollGateDataAccess.GetTollGateInfoByCameraId(db, Id);
                if (ds.Tables[0].Rows.Count == 0)
                {
                    return null;
                }
                return new LongChang_TollGateInfo(ds.Tables[0].Rows[0]);

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
