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
                    list.Add(oTollGate.tollNum, oTollGate);


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
        public LongChang_TollGateInfo GetTollGateInfoByKaKouID(ref string errMessage, string Id)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            try
            {
                DataSet ds = LongChang_TollGateDataAccess.GetTollGateInfoByKKBh(db, Id);
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
        //卡口父编号
        public Dictionary<string, LongChang_TollGateInfo> GetTollGateInfoByKaKouFBH(ref string errMessage, string fId)
        {
      
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            Dictionary<string, LongChang_TollGateInfo> listtollGate = new Dictionary<string, LongChang_TollGateInfo>();
            try
            {

                DataSet ds = LongChang_TollGateDataAccess.GetTollGateInfoByKKFBh(db, fId);

                LongChang_TollGateInfo oTollGate;
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    oTollGate = new LongChang_TollGateInfo(ds.Tables[0].Rows[i]);
                    listtollGate.Add(oTollGate.tollNum, oTollGate);


                }
                return listtollGate;

            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return new Dictionary<string, LongChang_TollGateInfo>();
            }

        }
        public int Delete(ref string errMessage, string TollId)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            try
            {
                int iRtn = LongChang_TollGateDataAccess.Delete(db, TollId);

                return iRtn;
            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return -1;
            }

        }
        public string Insert(ref string errMessage, LongChang_TollGateInfo oTollGateInfo)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            try
            {
                return LongChang_TollGateDataAccess.Insert(db, oTollGateInfo);

            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return "";
            }
        }
        public int InsertCheDao(ref string errMessage, LongChang_TollGateInfo oTollGateInfo)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            try
            {
                return LongChang_TollGateDataAccess.InsertCheDao(db, oTollGateInfo);

            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return -1;
            }
        }
        public int Update(ref string errMessage, LongChang_TollGateInfo toll)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            try
            {
                return LongChang_TollGateDataAccess.Update(db, toll);

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
