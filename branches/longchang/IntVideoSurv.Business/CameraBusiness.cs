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
    public class CameraBusiness
    {
        public static readonly ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private static CameraBusiness instance;
        public static CameraBusiness Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CameraBusiness();
                }
                return instance;
            }
        }
        public int Insert(ref string errMessage, CameraInfo oCameraInfo)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            try
            {
                return CameraDataAccess.Insert(db, oCameraInfo);

            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return -1;
            }
        }
        public int Update(ref string errMessage, CameraInfo oCameraInfo)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            try
            {
                return CameraDataAccess.Update(db, oCameraInfo);

            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return -1;
            }


        }
        public int Delete(ref string errMessage, int CameraId)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            try
            {
                int iRtn = CameraDataAccess.Delete(db, CameraId);
            
                return iRtn;
            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return -1;
            }

        }

       
        public CameraInfo GetCameraInfoByCameraId(ref string errMessage, int CameraId)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            try
            {
                DataSet ds = CameraDataAccess.GetCamInfoByCameraId(db, CameraId);
                if (ds.Tables[0].Rows.Count == 0)
                {
                    return null;
                }
                return new CameraInfo(ds.Tables[0].Rows[0]);

            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return null;
            }
        }
        // Create video source

        public CameraInfo GetCamInfoByDeviceIdAndCameraName(ref string errMessage, int deviceId, string cameraName)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            try
            {
                DataSet ds = CameraDataAccess.GetCamInfoByDeviceIdAndCameraName(db, deviceId, cameraName);
                if (ds.Tables[0].Rows.Count == 0)
                {
                    return null;
                }
                return new CameraInfo(ds.Tables[0].Rows[0]);

            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return null;
            }
        }
        public Dictionary<int, CameraInfo> GetCamInfoByDeviceId(ref string errMessage, int DeviceId)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            Dictionary<int, CameraInfo> list = new Dictionary<int, CameraInfo>();
            try
            {

                DataSet ds = CameraDataAccess.GetCamInfoByDeviceId(db,DeviceId);

                CameraInfo oCamera;
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    oCamera = new CameraInfo(ds.Tables[0].Rows[i]);
                    list.Add(oCamera.CameraId, oCamera);


                }
                return list;

            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return null;
            }
            /*Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            try
            {
                DataSet ds = CameraDataAccess.GetCamInfoByDeviceId(db, DeviceId);
                if (ds.Tables[0].Rows.Count == 0)
                {
                    return null;
                }
                return new CameraInfo(ds.Tables[0].Rows[0]);

            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return null;
            }*/
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="errMessage"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        public Dictionary<int, SMCameraInfo> GetAllCameraInfoByUsername(ref string errMessage,string userName)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            Dictionary<int, SMCameraInfo> list = new Dictionary<int, SMCameraInfo>();
            try
            {

                DataSet ds = CameraDataAccess.GetAllCamInfoByUsername(db,userName);

                SMCameraInfo oCamera;
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    oCamera = new SMCameraInfo(ds.Tables[0].Rows[i]);
                    list.Add(oCamera.CameraId, oCamera);


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
