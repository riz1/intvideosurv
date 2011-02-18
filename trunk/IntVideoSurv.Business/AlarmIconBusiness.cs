using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IntVideoSurv.DataAccess;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using IntVideoSurv.Entity;
using log4net;
using System.IO;
using videosource;
using System.Reflection;
using System.Transactions;
namespace IntVideoSurv.Business
{
    public class AlarmIconBusiness
    {
        public static readonly ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private static AlarmIconBusiness instance;
        public static AlarmIconBusiness Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AlarmIconBusiness();
                }
                return instance;
            }
        }

        public int Insert(ref string errMessage, AlarmIconInfo alarmIconInfo)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            try
            {


                return AlarmIconDataAccess.Insert(db, alarmIconInfo);

            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return -1;
            }
        }

        public int Update(ref string errMessage, AlarmIconInfo alarmIconInfo)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            try
            {
                return AlarmIconDataAccess.Update(db, alarmIconInfo);

            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return -1;
            }


        }
        public int Delete(ref string errMessage, int alarmId)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            try
            {
                int iRtn = AlarmIconDataAccess.Delete(db, alarmId);
                return iRtn;
            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return -1;
            }

        }

        public Dictionary<int, AlarmIconInfo> GetAllAlarmIconInfo(ref string errMessage)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            Dictionary<int, AlarmIconInfo> list = new Dictionary<int, AlarmIconInfo>();
            try
            {
                AlarmIconInfo alarmIconInfo;
                DataSet ds = AlarmIconDataAccess.GetAllAlarmIconInfo(db);
                DataSet dsCamera;
                CameraInfo oCamera;
                DataSet dsAlarm;
                AlarmInfo oAlarm;
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    alarmIconInfo = new AlarmIconInfo(ds.Tables[0].Rows[i]);
                    list.Add(alarmIconInfo.AlarmId, alarmIconInfo);
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
        public AlarmIconInfo GetAlarmIconInfoByAlarmId(ref string errMessage, int alarmId)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            try
            {
                DataSet ds = AlarmIconDataAccess.GetAlarmIconInfoByAlarmId(db, alarmId);

                return new AlarmIconInfo(ds.Tables[0].Rows[0]); ;

            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return null;
            }
        }
        public Dictionary<int, AlarmIconInfo> GetAlarmIconInfoByMapId(ref string errMessage, int mapId)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            Dictionary<int, AlarmIconInfo> list = new Dictionary<int, AlarmIconInfo>();
            try
            {
                AlarmIconInfo alarmIconInfo;
                DataSet ds = AlarmIconDataAccess.GetAlarmIconInfoByMapId(db, mapId);
                DataSet dsCamera;
                CameraInfo oCamera;
                DataSet dsAlarm;
                AlarmInfo oAlarm;
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    alarmIconInfo = new AlarmIconInfo(ds.Tables[0].Rows[i]);
                    list.Add(alarmIconInfo.AlarmId, alarmIconInfo);
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

