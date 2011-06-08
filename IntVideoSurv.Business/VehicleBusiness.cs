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
    public class VehicleBusiness
    {
        public static readonly ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private static VehicleBusiness instance;
        public static VehicleBusiness Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new VehicleBusiness();
                }
                return instance;
            }
        }
        public int Insert(ref string errMessage, Vehicle ovehicle)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            try
            {
                return VehicleDataAccess.Insert(db, ovehicle);

            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return -1;
            }
        }
        public bool GetVehicleCountByPlateNumber(ref string errMessage, string number)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            try
            {
                int i = VehicleDataAccess.GetVehicleCountByPlateNumber(db, number);
                if (i>=1)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return false;
            }
        }
        public Vehicle GetVehicle(ref string errMessage, int cameraId, DateTime captureDataTime)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            Vehicle vehicle = null;

            try
            {
                DataSet ds = VehicleDataAccess.GetVehicleCustom(db, string.Format(" and CapturePicture.CameraId={0} and  CapturePicture.DateTime='{1}'", cameraId, captureDataTime));
                vehicle = new Vehicle(ds.Tables[0].Rows[0]);
                vehicle.CapturePicture = CapturePictureBusiness.Instance.GetCapturePicture(ref errMessage, vehicle.PictureID);
                vehicle.CameraInfo = CameraBusiness.Instance.GetCameraInfoByCameraId(ref errMessage,
                                                                                  vehicle.CapturePicture.CameraID);
                vehicle.VideoInfo = VideoBusiness.Instance.GetVideoInfoById(ref errMessage, vehicle.VedioId);
                return vehicle;

            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return null;
            }
        }

        public Dictionary<int, Vehicle> GetVehicleCustom(ref string errMessage, string str)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            Dictionary<int, Vehicle> list = new Dictionary<int, Vehicle>();
            try
            {
                DataSet ds = VehicleDataAccess.GetVehicleCustom(db, str);
                Vehicle vehicle;
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    vehicle = new Vehicle(ds.Tables[0].Rows[i]);
                    vehicle.CapturePicture = CapturePictureBusiness.Instance.GetCapturePicture(ref errMessage, vehicle.PictureID);
                    vehicle.CameraInfo = CameraBusiness.Instance.GetCameraInfoByCameraId(ref errMessage,
                                                                                      vehicle.CapturePicture.CameraID);
                    vehicle.VideoInfo = VideoBusiness.Instance.GetVideoInfoById(ref errMessage, vehicle.VedioId);
                    list.Add(vehicle.VehicleID, vehicle);
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
        public Dictionary<int, Vehicle> GetVehicleCustom(ref string errMessage, string str, int pageno,int pagesize)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            Dictionary<int, Vehicle> list = new Dictionary<int, Vehicle>();
            try
            {
                DataSet ds = VehicleDataAccess.GetVehicleCustom(db, str, pageno, pagesize);
                Vehicle vehicle;
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    vehicle = new Vehicle(ds.Tables[0].Rows[i]);
                    vehicle.CapturePicture = CapturePictureBusiness.Instance.GetCapturePicture(ref errMessage, vehicle.PictureID);
                    vehicle.CameraInfo = CameraBusiness.Instance.GetCameraInfoByCameraId(ref errMessage,
                                                                                      vehicle.CapturePicture.CameraID);
                    vehicle.VideoInfo = VideoBusiness.Instance.GetVideoInfoById(ref errMessage, vehicle.VedioId);
                    list.Add(vehicle.VehicleID, vehicle);
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
        public int GetVehicleQuantity(ref string errMessage, string str)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            int ret = 0;
            try
            {
                return VehicleDataAccess.GetVehicleCustomQuantity(db, str);

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
