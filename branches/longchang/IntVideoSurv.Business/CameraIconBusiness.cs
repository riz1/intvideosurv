using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using IntVideoSurv.Entity;
using IntVideoSurv.DataAccess;
using log4net;
using System.IO;
using videosource;
using System.Reflection;
using System.Transactions;
namespace IntVideoSurv.Business
{
    public class CameraIconBusiness
    {
        public static readonly ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private static CameraIconBusiness instance;
        public static CameraIconBusiness Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CameraIconBusiness();
                }
                return instance;
            }
        }

        public int Insert(ref string errMessage, CameraIconInfo cameraIconInfo)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            try
            {


                return CameraIconDataAccess.Insert(db, cameraIconInfo);

            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return -1;
            }
        }

        public int Update(ref string errMessage, CameraIconInfo cameraIconInfo)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            try
            {
                return CameraIconDataAccess.Update(db, cameraIconInfo);

            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return -1;
            }


        }
        public int Delete(ref string errMessage, int deviceId)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            try
            {
                int iRtn = CameraIconDataAccess.Delete(db, deviceId);
                return iRtn;
            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return -1;
            }

        }

        public Dictionary<int, CameraIconInfo> GetAllCameraIconInfo(ref string errMessage)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            Dictionary<int, CameraIconInfo> list = new Dictionary<int, CameraIconInfo>();
            try
            {
                CameraIconInfo cameraIconInfo;
                DataSet ds = CameraIconDataAccess.GetAllCameraIconInfo(db);
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    cameraIconInfo = new CameraIconInfo(ds.Tables[0].Rows[i]);
                    list.Add(cameraIconInfo.CameraId, cameraIconInfo);
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
        public CameraIconInfo GetCameraIconInfoByAlarmId(ref string errMessage, int alarmId)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            try
            {
                DataSet ds = CameraIconDataAccess.GetCameraIconInfoByCameraId(db, alarmId);

                return new CameraIconInfo(ds.Tables[0].Rows[0]); ;

            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return null;
            }
        }
        public Dictionary<int, CameraIconInfo> GetCameraIconInfoByMapId(ref string errMessage, int mapId)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            Dictionary<int, CameraIconInfo> list = new Dictionary<int, CameraIconInfo>();
            try
            {
                CameraIconInfo cameraIconInfo;
                DataSet ds = CameraIconDataAccess.GetCameraIconInfoByMapId(db,mapId);
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    cameraIconInfo = new CameraIconInfo(ds.Tables[0].Rows[i]);
                    list.Add(cameraIconInfo.CameraId, cameraIconInfo);
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

