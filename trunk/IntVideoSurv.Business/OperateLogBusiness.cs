using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IntVideoSurv.DataAccess;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using IntVideoSurv.Entity;
using log4net;
using videosource;
using System.Drawing;


namespace IntVideoSurv.Business
{
    public class OperateLogBusiness
    {
        public static readonly ILog Logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private static OperateLogBusiness _instance;
        public static OperateLogBusiness Instance
        {
            get { return _instance ?? (_instance = new OperateLogBusiness()); }
        }
        public int Insert(ref string errMessage, OperateLog operateLog)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            try
            {
                return OperateLogDataAccess.Insert(db, operateLog);

            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                Logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return -1;
            }
        }

        public int Delete(ref string errMessage, int id)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            try
            {
                int iRtn = OperateLogDataAccess.Delete(db, id);

                return iRtn;
            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                Logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return -1;
            }

        }

        public Dictionary<int, OperateLog> GetAllOperateLogs(ref string errMessage)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            var list = new Dictionary<int, OperateLog>();
            try
            {

                DataSet ds = OperateLogDataAccess.GetAllOperateLogs(db);

                OperateLog operateLog;
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    operateLog = new OperateLog(ds.Tables[0].Rows[i]);
                    list.Add(operateLog.Id, operateLog);
                }
                return list;

            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                Logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return null;
            }
        }

        public Dictionary<int, OperateLog> GetOperateLogs(ref string errMessage, string filter)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            var list = new Dictionary<int, OperateLog>();
            try
            {

                DataSet ds = OperateLogDataAccess.GetOperateLogs(db, filter);

                OperateLog operateLog;
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    operateLog = new OperateLog(ds.Tables[0].Rows[i]);
                    list.Add(operateLog.Id, operateLog);
                }
                return list;

            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                Logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return null;
            }
        }

        public DataTable GetOperateLogDataSet(ref string errMessage, string filter)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            try
            {

                DataSet ds = OperateLogDataAccess.GetOperateLogs(db, filter);

                return ds.Tables[0];

            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                Logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return null;
            }
        }

        public ArrayList GetOperateLogTypes(ref string errMessage)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            var list = new ArrayList();
            try
            {

                DataSet ds = OperateLogDataAccess.GetOperateLogTypes(db);

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    list.Add(ds.Tables[0].Rows[i][0].ToString());
                }
                return list;

            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                Logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return null;
            }
        }
    }
}
