using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using IntVideoSurv.Entity;
using IntVideoSurv.DataAccess;
using log4net;
using videosource;
using System.Drawing;

namespace IntVideoSurv.Business
{
    public class VideoBusiness
    {
        public static readonly ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private static VideoBusiness instance;
        public static VideoBusiness Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new VideoBusiness();
                }
                return instance;
            }
        }

        public static int Insert(ref string errMessage, VideoInfo videoInfo)
        {

            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            try
            {
                return VideoDataAccess.Insert(db, videoInfo);

            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return -1;
            }
        }

        public static int Delete(ref string errMessage, int id)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            try
            {
                int iRtn = VideoDataAccess.Delete(db, id);
                return iRtn;
            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return -1;
            }

        }

        public static VideoInfo GetVideoInfoById(ref string errMessage, int id)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            try
            {
                DataSet ds = VideoDataAccess.GetVideoInfoById(db, id);
                if (ds.Tables[0].Rows.Count == 0)
                {
                    return null;
                }
                VideoInfo videoInfo = new VideoInfo(ds.Tables[0].Rows[0]);
                DataSet dsCamera;
                CameraInfo oCamera;
                dsCamera = CameraDataAccess.GetCamInfoByCameraId(db, videoInfo.CameraId);
                foreach (DataRow dr in dsCamera.Tables[0].Rows)
                {

                    oCamera = new CameraInfo(dr);
                    videoInfo.CameraInfo =  oCamera;
                }
                return videoInfo;
            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return null;
            }
        }

        public static Dictionary<int,VideoInfo> GetVideoInfoByCamera(ref string errMessage, int cameraId)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            var videoList = new Dictionary<int, VideoInfo>();
            try
            {

                DataSet ds = VideoDataAccess.GetVideoInfoByCamera(db, cameraId);

                VideoInfo videoInfo;
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    videoInfo = new VideoInfo(ds.Tables[0].Rows[i]);
                    DataSet dsCamera;
                    CameraInfo oCamera;
                    dsCamera = CameraDataAccess.GetCamInfoByCameraId(db, videoInfo.CameraId);
                    foreach (DataRow dr in dsCamera.Tables[0].Rows)
                    {

                        oCamera = new CameraInfo(dr);
                        videoInfo.CameraInfo = oCamera;
                    }

                    videoList.Add(videoInfo.Id, videoInfo);
                }
                return videoList;

            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return null;
            }
        }

        public static Dictionary<int, VideoInfo> GetVideoInfoByCameraDateTime(ref string errMessage, int cameraId, DateTime captureBeginTime, DateTime captureEndTime)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            var videoList = new Dictionary<int, VideoInfo>();
            try
            {

                DataSet ds = VideoDataAccess.GetVideoInfoByCameraDateTime(db, cameraId,captureBeginTime,captureEndTime);

                VideoInfo videoInfo;
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    videoInfo = new VideoInfo(ds.Tables[0].Rows[i]);
                    DataSet dsCamera;
                    CameraInfo oCamera;
                    dsCamera = CameraDataAccess.GetCamInfoByCameraId(db, videoInfo.CameraId);
                    foreach (DataRow dr in dsCamera.Tables[0].Rows)
                    {

                        oCamera = new CameraInfo(dr);
                        videoInfo.CameraInfo = oCamera;
                    }

                    videoList.Add(videoInfo.Id, videoInfo);
                }
                return videoList;

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
