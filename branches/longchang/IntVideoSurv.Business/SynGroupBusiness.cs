using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using IntVideoSurv.Entity;
using IntVideoSurv.DataAccess;
using log4net;

namespace IntVideoSurv.Business
{
    public class SynGroupBusiness
    {

        public static readonly ILog Logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private static SynGroupBusiness _instance;
        public static SynGroupBusiness Instance
        {
            get { return _instance ?? (_instance = new SynGroupBusiness()); }
        }

        public int GetMaxGroupId(ref string errMessage)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            try
            {
                return SynGroupDataAccess.GetMaxSynGroupId(db);

            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                Logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return -1;
            }
        }

        public int Insert(ref string errMessage, SynGroup synGroup)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            try
            {
                return SynGroupDataAccess.Insert(db, synGroup);

            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                Logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return -1;
            }
        }
        public int Update(ref string errMessage, SynGroup synGroup)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            try
            {
                return SynGroupDataAccess.Update(db, synGroup);

            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                Logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return -1;
            }


        }
        public int Delete(ref string errMessage, int synGroupId)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            try
            {
                return SynGroupDataAccess.Delete(db, synGroupId);

            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                Logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return -1;
            }

        }
        public List<SynCameraInfo> GetAllCameraBySynGroupId(ref string errMessage, int SynGroupId)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            var list = new List< SynCameraInfo>();
            try
            {
                SynCameraInfo oSynCameraInfo;
                DataSet ds = SynGroupDataAccess.GetAllCameraBySynGroupId(db, SynGroupId);
                foreach (DataRow  item in ds.Tables[0].Rows)
                {
                    oSynCameraInfo = new SynCameraInfo(item);
                    list.Add(oSynCameraInfo);
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
        public Dictionary<int, SynGroup> GetAllSynGroups(ref string errMessage)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            var list = new Dictionary<int, SynGroup>();
            try
            {
                SynGroup synGroup;
                DeviceInfo oDevice;
                DataSet ds = SynGroupDataAccess.GetAllSynGroupInfo(db);
                DataSet dsCamera;
                CameraInfo oCamera;
                DataSet dsCameraMonitorPair;
                CameraMonitorPairInfo cameraMonitorPair;
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    synGroup = new SynGroup(ds.Tables[0].Rows[i]);
                    //dsCamera = CameraDataAccess.GetCamInfoBySynGroupId(db, synGroup.SynGroupId);
                    //synGroup.ListCamera = new Dictionary<int, CameraInfo>();
                    //foreach (DataRow drCam in dsCamera.Tables[0].Rows)
                    //{
                    //    oCamera = new CameraInfo(drCam);
                    //    synGroup.ListCamera.Add(oCamera.CameraId, oCamera);
                    //}
                    dsCameraMonitorPair = CameraMonitorPairDataAccess.GetCameraMonitorPairBySynGroupId(db, synGroup.SynGroupId);
                    synGroup.ListCameraMonitorPair = new Dictionary<int, CameraMonitorPairInfo>();
                    foreach (DataRow drCamMonPair in dsCameraMonitorPair.Tables[0].Rows)
                    {
                        cameraMonitorPair = new CameraMonitorPairInfo(drCamMonPair);
                        synGroup.ListCameraMonitorPair.Add(cameraMonitorPair.CameraMonitorPairId, cameraMonitorPair);
                    }

                    list.Add(synGroup.SynGroupId, synGroup);
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


        public SynGroup GetSynGroupBySynGroupId(ref string errMessage, int synGroupId)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            try
            {
                DataSet ds = SynGroupDataAccess.GetSynGroupBySynGroupId(db, synGroupId);
                if (ds.Tables[0].Rows.Count == 0)
                {
                    return null;
                }
                CameraInfo oCamera;
                DeviceInfo oDevice;

                var synGroup = new SynGroup(ds.Tables[0].Rows[0]) {ListCamera = new Dictionary<int, CameraInfo>()};

                //DataSet dsCamera = CameraDataAccess.GetCamInfoBySynGroupId(db, synGroup.SynGroupId);
                //synGroup.ListCamera = new Dictionary<int, CameraInfo>();
                //foreach (DataRow drCam in dsCamera.Tables[0].Rows)
                //{
                //    oCamera = new CameraInfo(drCam);
                //    synGroup.ListCamera.Add(oCamera.CameraId, oCamera);

                //}
                CameraMonitorPairInfo cameraMonitorPair;
                DataSet dsCameraMonitorPair = CameraMonitorPairDataAccess.GetCameraMonitorPairBySynGroupId(db, synGroup.SynGroupId);
                synGroup.ListCameraMonitorPair = new Dictionary<int, CameraMonitorPairInfo>();
                foreach (DataRow drCamMonPair in dsCameraMonitorPair.Tables[0].Rows)
                {
                    cameraMonitorPair = new CameraMonitorPairInfo(drCamMonPair);
                    synGroup.ListCameraMonitorPair.Add(cameraMonitorPair.CameraMonitorPairId, cameraMonitorPair);
                }
                return synGroup;

            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                Logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return null;
            }
        }

        public SynGroup GetSynGroupBySynGroupName(ref string errMessage, string synGroupName)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            try
            {
                DataSet ds = SynGroupDataAccess.GetSynGroupBySynGroupName(db, synGroupName);
                if (ds.Tables[0].Rows.Count == 0)
                {
                    return null;
                }
                CameraInfo oCamera;
                DeviceInfo oDevice;

                var synGroup = new SynGroup(ds.Tables[0].Rows[0]) { ListCamera = new Dictionary<int, CameraInfo>() };

                //DataSet dsCamera = CameraDataAccess.GetCamInfoBySynGroupId(db, synGroup.SynGroupId);
                //synGroup.ListCamera = new Dictionary<int, CameraInfo>();
                //foreach (DataRow drCam in dsCamera.Tables[0].Rows)
                //{
                //    oCamera = new CameraInfo(drCam);
                //    synGroup.ListCamera.Add(oCamera.CameraId, oCamera);

                //}
                CameraMonitorPairInfo cameraMonitorPair;
                DataSet dsCameraMonitorPair = CameraMonitorPairDataAccess.GetCameraMonitorPairBySynGroupId(db, synGroup.SynGroupId);
                synGroup.ListCameraMonitorPair = new Dictionary<int, CameraMonitorPairInfo>();
                foreach (DataRow drCamMonPair in dsCameraMonitorPair.Tables[0].Rows)
                {
                    cameraMonitorPair = new CameraMonitorPairInfo(drCamMonPair);
                    synGroup.ListCameraMonitorPair.Add(cameraMonitorPair.CameraMonitorPairId, cameraMonitorPair);
                }
                return synGroup;

            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                Logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return null;
            }
        }

        public int InsertSynGroupCamera(ref string errMessage, int synGroupId, int cameraId)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            try
            {
                return SynGroupDataAccess.InsertSynGroupCamera(db, synGroupId, cameraId);

            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                Logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return -1;
            }
        }


        public int InsertSynGroupCamera(ref string errMessage, int synGroupId, int cameraId, int monitorId)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            try
            {
                return SynGroupDataAccess.InsertSynGroupCamera(db, synGroupId, cameraId, monitorId);

            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                Logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return -1;
            }
        }

        public int InsertSynGroupCamera(ref string errMessage, int synGroupId, int cameraId, int monitorId, int splitScreenNo)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            try
            {
                return SynGroupDataAccess.InsertSynGroupCamera(db, synGroupId, cameraId, monitorId, splitScreenNo);

            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                Logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return -1;
            }
        }

        public int DeleteSynGroupCamera(ref string errMessage, int synGroupId, int cameraId)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            try
            {
                return SynGroupDataAccess.DeleteSynGroupCamera(db, synGroupId, cameraId);

            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                Logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return -1;
            }
        }

        public int DeleteSynGroupCamera(ref string errMessage, int synGroupId, int cameraId, int monitorId)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            try
            {
                return SynGroupDataAccess.DeleteSynGroupCamera(db, synGroupId, cameraId, monitorId);

            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                Logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return -1;
            }
        }

        public int DeleteSynGroupCamera(ref string errMessage, int synCameraId)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            try
            {
                return SynGroupDataAccess.DeleteSynGroupCamera(db, synCameraId);

            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                Logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return -1;
            }
        }
    }
}
