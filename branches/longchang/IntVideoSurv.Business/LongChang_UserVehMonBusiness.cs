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
    public class LongChang_UserVehMonBusiness
    {
        public static readonly ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private static LongChang_UserVehMonBusiness instance;
        public static LongChang_UserVehMonBusiness Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new LongChang_UserVehMonBusiness();
                }
                return instance;
            }
        }

        public Dictionary<string, LongChang_UserVehMonInfo> GetAllUserVehMonInfo(ref string errMessage)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            Dictionary<string, LongChang_UserVehMonInfo> list = new Dictionary<string, LongChang_UserVehMonInfo>();
            try
            {

                DataSet ds = LongChang_UserVehMonDataAccess.GetAllUserVehMonInfo(db);

                LongChang_UserVehMonInfo oUserVehMon;
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    oUserVehMon = new LongChang_UserVehMonInfo(ds.Tables[0].Rows[i]);
                    list.Add(oUserVehMon.UserVehMonId, oUserVehMon);


                }
                return list;

            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return new Dictionary<string, LongChang_UserVehMonInfo>();
            }
        }

        public int Insert(ref string errMessage, LongChang_UserVehMonInfo uservehmon)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            try
            {
                return LongChang_UserVehMonDataAccess.Insert(db, uservehmon);

            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return -1;
            }
        }
        public UserInfo GetUserInfoByCameraId(ref string errMessage, int Id)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            try
            {
                DataSet ds = LongChang_UserVehMonDataAccess.GetUserInfoByCameraId(db, Id);
                if (ds.Tables[0].Rows.Count == 0)
                {
                    return null;
                }
                return new UserInfo(ds.Tables[0].Rows[0]);

            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return null;
            }

        }
        public DataSet GetTimeAndIllegalreasonByUserId(ref string errMessage, string userid ,DateTime starttime,DateTime endtime)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            //Dictionary<string, string> listIllegalreason = new Dictionary<string, string>();
            try
            {
                DataSet ds = LongChang_UserVehMonDataAccess.GetTimeAndIllegalreasonByUserId(db, userid,starttime,endtime);
                /*for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    listIllegalreason.Add(ds.Tables[0].Rows[i][1].ToString(),ds.Tables[0].Rows[i][0].ToString());


                }*/
                return ds;
            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return new DataSet();
            }

        }
        public DataSet GetAllQueryInfo(ref string errMessage)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            try
            {
                DataSet ds = LongChang_UserVehMonDataAccess.GetAllQueryInfo(db);
                return ds;
            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return new DataSet();
            }
        }
        public DataSet GetUserQueryInfoByUserId(ref string errMessage, string userid)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            try
            {
                DataSet ds = LongChang_UserVehMonDataAccess.GetUserQueryInfoByUserId(db, userid);
                return ds;
            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return new DataSet();
            }
        }
        public DataSet GetRecordDetail(ref string errMessage, string userid, string ileagalreason, string roadname, DateTime dt)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            try
            {
                DataSet ds = LongChang_UserVehMonDataAccess.GetRecordDetail(db, userid, ileagalreason, roadname, dt);
                return ds;
            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return new DataSet();
            }
        }

    }
}
