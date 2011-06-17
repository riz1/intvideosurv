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
    public class CameraGroupBusiness
    {
        public static readonly ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private static CameraGroupBusiness instance;
        public static CameraGroupBusiness Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CameraGroupBusiness();
                }
                return instance;
            }
        }
        public int Insert(ref string errMessage, CameraGroupInfo oCameraGroup)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            try
            {
                return CameraGroupDataAccess.Insert(db, oCameraGroup);

            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return -1;
            }
        }
        public int DeleteByVirtualGroupID(ref string errMessage, int vgid)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            try
            {
                return CameraGroupDataAccess.DeleteByVirtualGroupID(db, vgid);

            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return -1;
            }
        }
        public Dictionary<int, CameraInfo> GetAllCameraInfo(ref string errMessage,int VirtualGroupId)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            Dictionary<int, CameraInfo> list = new Dictionary<int, CameraInfo>();
            try
            {
                CameraInfo oCameraInfo;
                DataSet ds = CameraGroupDataAccess.GetAllCameraInfo(db, VirtualGroupId);

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    oCameraInfo = new CameraInfo(ds.Tables[0].Rows[i]);
                    list.Add(oCameraInfo.CameraId, oCameraInfo);
                }
                return list;

            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return new Dictionary<int, CameraInfo>();
            }
        }
        public  int DeleteByGroupIDandCamID(ref string errMessage, int GroupID,int CameraID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            try
            {
                return CameraGroupDataAccess.DeleteByGroupIDandCamID(db, GroupID, CameraID);

            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return -1;
            }

        }
        public int DeleteByCamID(ref string errMessage, int CameraID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            try
            {
                return CameraGroupDataAccess.DeleteByCamID(db, CameraID);

            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return -1;
            }

        }

    }
}
