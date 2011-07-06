﻿using System;
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
    public class LongChang_CameraBusiness
    {
        public static readonly ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private static LongChang_CameraBusiness instance;
        public static LongChang_CameraBusiness Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new LongChang_CameraBusiness();
                }
                return instance;
            }
        }

        public Dictionary<int, LongChang_CameraInfo> GetAllCameraInfo(ref string errMessage)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            Dictionary<int, LongChang_CameraInfo> list = new Dictionary<int, LongChang_CameraInfo>();
            try
            {

                DataSet ds = LongChang_CameraDataAccess.GetAllCamInfo(db);

                LongChang_CameraInfo oCamera;
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    oCamera = new LongChang_CameraInfo(ds.Tables[0].Rows[i]);
                    list.Add(oCamera.CameraId, oCamera);


                }
                return list;

            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return new Dictionary<int, LongChang_CameraInfo>(); ;
            }
        }

        public Dictionary<int, LongChang_CameraInfo> GetAllCameraInfoByType(ref string errMessage, int type)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            Dictionary<int, LongChang_CameraInfo> list = new Dictionary<int, LongChang_CameraInfo>();
            try
            {

                DataSet ds = LongChang_CameraDataAccess.GetCamInfoByDeviceType(db,type);

                LongChang_CameraInfo oCamera;
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    oCamera = new LongChang_CameraInfo(ds.Tables[0].Rows[i]);
                    list.Add(oCamera.CameraId, oCamera);


                }
                return list;

            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return new Dictionary<int, LongChang_CameraInfo>(); ;
            }
        }
        public Dictionary<int, LongChang_CameraInfo> GetCamInfoByDeviceUserId(ref string errMessage, int userid)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            Dictionary<int, LongChang_CameraInfo> list = new Dictionary<int, LongChang_CameraInfo>();
            try
            {

                DataSet ds = LongChang_CameraDataAccess.GetCamInfoByDeviceUserId(db, userid);

                LongChang_CameraInfo oCamera;
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    oCamera = new LongChang_CameraInfo(ds.Tables[0].Rows[i]);
                    list.Add(oCamera.CameraId, oCamera);


                }
                return list;

            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return new Dictionary<int, LongChang_CameraInfo>(); ;
            }
        }

        public LongChang_CameraInfo GetCameraInfoByCameraId(ref string errMessage, int cameraId)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            try
            {
                DataSet ds = LongChang_CameraDataAccess.GetCamInfoByCameraId(db, cameraId);
                if (ds.Tables[0].Rows.Count == 0)
                {
                    return null;
                }
                return new LongChang_CameraInfo(ds.Tables[0].Rows[0]);

            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return null;
            }
        }
        public int Delete(ref string errMessage, int CameraId)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            try
            {
                int iRtn = LongChang_CameraDataAccess.Delete(db, CameraId);

                return iRtn;
            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return -1;
            }

        }

        public string Insert(ref string errMessage, LongChang_CameraInfo oCameraInfo)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            try
            {
                return LongChang_CameraDataAccess.Insert(db, oCameraInfo);

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