using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using IntVideoSurv.Entity;
using IntVideoSurv.DataAccess;
using log4net;
using videosource;
using System.Drawing;


namespace IntVideoSurv.Business
{
    public class SystemLogBusiness
    {
        public static readonly ILog Logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private static SystemLogBusiness _instance;
        public static SystemLogBusiness Instance
        {
            get { return _instance ?? (_instance = new SystemLogBusiness()); }
        }
        public int Insert(ref string errMessage, SystemLog systemLog)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            try
            {
                return SystemLogDataAccess.Insert(db, systemLog);

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
                int iRtn = SystemLogDataAccess.Delete(db, id);

                return iRtn;
            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                Logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return -1;
            }

        }

        public Dictionary<int, SystemLog> GetAllSystemLogs(ref string errMessage)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            var list = new Dictionary<int, SystemLog>();
            try
            {

                DataSet ds = SystemLogDataAccess.GetAllSystemLogs(db);

                SystemLog systemLog;
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    systemLog = new SystemLog(ds.Tables[0].Rows[i]);
                    list.Add(systemLog.Id, systemLog);
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

        public Dictionary<int, SystemLog> GetSystemLogs(ref string errMessage, string filter)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            var list = new Dictionary<int, SystemLog>();
            try
            {

                DataSet ds = SystemLogDataAccess.GetSystemLogs(db, filter);

                SystemLog systemLog;
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    systemLog = new SystemLog(ds.Tables[0].Rows[i]);
                    list.Add(systemLog.Id, systemLog);
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

        public DataTable GetSystemLogDataSet(ref string errMessage, string filter)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            try
            {

                DataSet ds = SystemLogDataAccess.GetSystemLogs(db, filter);

                return ds.Tables[0];

            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                Logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return null;
            }
        }

        public ArrayList GetSystemLogTypes(ref string errMessage)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            var list = new ArrayList();
            try
            {

                DataSet ds = SystemLogDataAccess.GetSystemLogTypes(db);

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
