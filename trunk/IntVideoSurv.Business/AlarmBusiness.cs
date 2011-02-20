using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using IntVideoSurv.Entity;
using IntVideoSurv.DataAccess;
using log4net;
using SMRemotingInterface;
using videosource;
using System.Drawing;


namespace IntVideoSurv.Business
{
    public class AlarmBusiness
    {
        public static readonly ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private static AlarmBusiness instance;
        public static AlarmBusiness Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AlarmBusiness();
                }
                return instance;
            }
        }
        public int Insert(ref string errMessage, AlarmInfo oAlarmInfo)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            try
            {
                return AlarmDataAccess.Insert(db, oAlarmInfo);

            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return -1;
            }
        }
        public int Update(ref string errMessage, AlarmInfo oAlarmInfo)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            try
            {
                return AlarmDataAccess.Update(db, oAlarmInfo);

            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return -1;
            }


        }
        public int Delete(ref string errMessage, int cameraId)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            try
            {
                int iRtn = AlarmDataAccess.Delete(db, cameraId);

                return iRtn;
            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return -1;
            }

        }

        public Dictionary<int, AlarmInfo> GetAllAlarmInfo(ref string errMessage)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            Dictionary<int, AlarmInfo> list = new Dictionary<int, AlarmInfo>();
            try
            {

                DataSet ds = AlarmDataAccess.GetAllAlarmInfo(db);

                AlarmInfo alarmInfo;
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    alarmInfo = new AlarmInfo(ds.Tables[0].Rows[i]);
                    list.Add(alarmInfo.AlarmId, alarmInfo);


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
        public AlarmInfo GetAlarmInfoByAlarmId(ref string errMessage, int alarmId)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            try
            {
                DataSet ds = AlarmDataAccess.GetAlarmInfoByAlarmId(db, alarmId);
                if (ds.Tables[0].Rows.Count == 0)
                {
                    return null;
                }
                return new AlarmInfo(ds.Tables[0].Rows[0]);

            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return null;
            }
        }
        // Create video source

        public AlarmInfo GetAlarmInfoByDeviceIdAndAlarmName(ref string errMessage, int deviceId, string alarmName)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            try
            {
                DataSet ds = AlarmDataAccess.GetAlarmInfoByDeviceIdAndAlarmName(db, deviceId, alarmName);
                if (ds.Tables[0].Rows.Count == 0)
                {
                    return null;
                }
                return new AlarmInfo(ds.Tables[0].Rows[0]);

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
