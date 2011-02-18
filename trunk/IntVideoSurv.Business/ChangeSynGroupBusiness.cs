using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using DigtiMatrix.Entity;
using DigitMatrix.DataAccess;
using log4net;

namespace DigitMatrix.Business
{
    public class ChangeSynGroupBusiness
    {

        public static readonly ILog Logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private static ChangeSynGroupBusiness _instance;
        public static ChangeSynGroupBusiness Instance
        {
            get { return _instance ?? (_instance = new ChangeSynGroupBusiness()); }
        }

        public int GetMaxGroupId(ref string errMessage)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            try
            {
                return ChangeSynGroupDataAccess.GetMaxChangeSynGroupId(db);

            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                Logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return -1;
            }
        }

        public int Insert(ref string errMessage, ChangeSynGroup synGroup)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            try
            {
                return ChangeSynGroupDataAccess.Insert(db, synGroup);

            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                Logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return -1;
            }
        }
        public int Update(ref string errMessage, ChangeSynGroup synGroup)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            try
            {
                return ChangeSynGroupDataAccess.Update(db, synGroup);

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
                return ChangeSynGroupDataAccess.Delete(db, synGroupId);

            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                Logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return -1;
            }

        }

        public Dictionary<int, ChangeSynGroup> GetAllChangeSynGroup(ref string errMessage)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            var list = new Dictionary<int, ChangeSynGroup>();
            try
            {
                ChangeSynGroup synGroup;
                DeviceInfo oDevice;
                DataSet ds = ChangeSynGroupDataAccess.GetAllChangeSynGroupInfo(db);
                DataSet dsCamera;
                CameraInfo oCamera;
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    synGroup = new ChangeSynGroup(ds.Tables[0].Rows[i]);
                    dsCamera = CameraDataAccess.GetCamInfoByChangeSynGroupId(db, synGroup.ChangeSynGroupId);
                    synGroup.ListCamera = new Dictionary<int, CameraInfo>();
                    foreach (DataRow drCam in dsCamera.Tables[0].Rows)
                    {
                        oCamera = new CameraInfo(drCam);
                        synGroup.ListCamera.Add(oCamera.CameraId, oCamera);
                    }

                    list.Add(synGroup.ChangeSynGroupId, synGroup);
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
        public ChangeSynGroup GetChangeSynGroupById(ref string errMessage, int synGroupId)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            try
            {
                DataSet ds = ChangeSynGroupDataAccess.GetChangeSynGroupById(db, synGroupId);
                if (ds.Tables[0].Rows.Count == 0)
                {
                    return null;
                }
                CameraInfo oCamera;
                DeviceInfo oDevice;

                var synGroup = new ChangeSynGroup(ds.Tables[0].Rows[0]) {ListCamera = new Dictionary<int, CameraInfo>()};

                DataSet dsCamera = CameraDataAccess.GetCamInfoByDeviceId(db, synGroup.ChangeSynGroupId);
                synGroup.ListCamera = new Dictionary<int, CameraInfo>();
                foreach (DataRow drCam in dsCamera.Tables[0].Rows)
                {
                    oCamera = new CameraInfo(drCam);
                    synGroup.ListCamera.Add(oCamera.CameraId, oCamera);
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



    }
}
