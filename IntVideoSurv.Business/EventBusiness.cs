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
    public class EventBusiness
    {
        public static readonly ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private static EventBusiness instance;
        public static EventBusiness Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new EventBusiness();
                }
                return instance;
            }
        }
        public int Insert(ref string errMessage, Event oEvent)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            try
            {
                return EventDataAccess.Insert(db, oEvent);

            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return -1;
            }
        }

        public Event GetEvent(ref string errMessage, int cameraId, DateTime captureDataTime)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            Event et = null;

            try
            {
                DataSet ds = EventDataAccess.GetEventCustom(db, string.Format(" and CapturePicture.CameraId={0} and  CapturePicture.DateTime='{1}'", cameraId, captureDataTime));
                et = new Event(ds.Tables[0].Rows[0]);
                et.CapturePicture = CapturePictureBusiness.Instance.GetCapturePicture(ref errMessage, et.PictureID);
                et.CameraInfo = CameraBusiness.Instance.GetCameraInfoByCameraId(ref errMessage,
                                                                                  et.CapturePicture.CameraID);
                et.VideoInfo = VideoBusiness.Instance.GetVideoInfoById(ref errMessage, et.VideoId);
                return et;

            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return null;
            }
        }

        public Dictionary<int, Event> GetEventCustom(ref string errMessage, string str)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            Dictionary<int, Event> list = new Dictionary<int, Event>();
            try
            {
                DataSet ds = EventDataAccess.GetEventCustom(db, str);
                Event et;
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    et = new Event(ds.Tables[0].Rows[i]);
                    et.CapturePicture = CapturePictureBusiness.Instance.GetCapturePicture(ref errMessage, et.PictureID);
                    et.CameraInfo = CameraBusiness.Instance.GetCameraInfoByCameraId(ref errMessage,
                                                                                      et.CapturePicture.CameraID);
                    et.VideoInfo = VideoBusiness.Instance.GetVideoInfoById(ref errMessage, et.VideoId);
                    list.Add(et.EventId, et);
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

        public Dictionary<int, Event> GetEventCustom(ref string errMessage, string str, int pageNo, int pageSize)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            Dictionary<int, Event> list = new Dictionary<int, Event>();
            Dictionary<int, ObjectInfo> listObject = new Dictionary<int, ObjectInfo>();
            try
            {
                DataSet ds = EventDataAccess.GetEventCustom(db, str, pageNo, pageSize);
                Event et;
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    et = new Event(ds.Tables[0].Rows[i]);
                    et.CapturePicture = CapturePictureBusiness.Instance.GetCapturePicture(ref errMessage, et.PictureID);
                    et.CameraInfo = CameraBusiness.Instance.GetCameraInfoByCameraId(ref errMessage,
                                                                                      et.CapturePicture.CameraID);
                    et.VideoInfo = VideoBusiness.Instance.GetVideoInfoById(ref errMessage, et.VideoId);
                    et.listObject = ObjectBusiness.Instance.GetEventObjectCustom(ref errMessage, et.EventId);

                    list.Add(et.EventId, et);
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

        public int GetEventQuantity(ref string errMessage, string str)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            int ret = 0;
            try
            {
                return EventDataAccess.GetEventCustomQuantity(db, str);

            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return 0;
            }


        }
    }
}
