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
    public class FaceBusiness
    {
        public static readonly ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private static FaceBusiness instance;
        public static FaceBusiness Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new FaceBusiness();
                }
                return instance;
            }
        }
        public int Insert(ref string errMessage, Face oFace)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            try
            {
                return FaceDataAccess.Insert(db, oFace);

            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return -1;
            }
        }
        public Face GetFace(ref string errMessage, int cameraId, DateTime captureDataTime)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            Face face = null;

            try
            {
                DataSet ds = FaceDataAccess.GetFaceCustom(db, string.Format(" and CapturePicture.CameraId={0} and  CapturePicture.DateTime='{1}'", cameraId, captureDataTime));
                face = new Face(ds.Tables[0].Rows[0]);
                face.CapturePicture = CapturePictureBusiness.Instance.GetCapturePicture(ref errMessage, face.PictureID);
                face.CameraInfo = CameraBusiness.Instance.GetCameraInfoByCameraId(ref errMessage,
                                                                                  face.CapturePicture.CameraID);
                face.VideoInfo = VideoBusiness.Instance.GetVideoInfoById(ref errMessage, face.VideoId);
                return face;

            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return null;
            }
        }

        public Dictionary<int, Face> GetFaceCustom(ref string errMessage, string str)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            Dictionary<int, Face> list = new Dictionary<int, Face>();
            try
            {
                DataSet ds = FaceDataAccess.GetFaceCustom(db, str);
                Face face;
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    face = new Face(ds.Tables[0].Rows[i]);
                    face.CapturePicture = CapturePictureBusiness.Instance.GetCapturePicture(ref errMessage,face.PictureID);
                    face.CameraInfo = CameraBusiness.Instance.GetCameraInfoByCameraId(ref errMessage,
                                                                                      face.CapturePicture.CameraID);
                    face.VideoInfo = VideoBusiness.Instance.GetVideoInfoById(ref errMessage, face.VideoId);
                    list.Add(face.FaceID, face);
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

        public Dictionary<int, Face> GetFaceCustom(ref string errMessage, string str,int pageNo,int pageSize)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            Dictionary<int, Face> list = new Dictionary<int, Face>();
            try
            {
                DataSet ds = FaceDataAccess.GetFaceCustom(db, str,pageNo,pageSize);
                Face face;
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    face = new Face(ds.Tables[0].Rows[i]);
                    face.CapturePicture = CapturePictureBusiness.Instance.GetCapturePicture(ref errMessage, face.PictureID);
                    face.CameraInfo = CameraBusiness.Instance.GetCameraInfoByCameraId(ref errMessage,
                                                                                      face.CapturePicture.CameraID);
                    face.VideoInfo = VideoBusiness.Instance.GetVideoInfoById(ref errMessage, face.VideoId);
                    list.Add(face.FaceID, face);
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

        public int GetFaceQuantity(ref string errMessage,string str)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            int ret = 0;
            try
            {
                return FaceDataAccess.GetFaceCustomQuantity(db,str);

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
