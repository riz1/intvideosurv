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
    public class WindowCameraBusiness
    {
        public static readonly ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private static WindowCameraBusiness instance;
        public static WindowCameraBusiness Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new WindowCameraBusiness();
                }
                return instance;
            }
        }

        public int Insert(ref string errMessage, WindowCameraInfo windowCameraInfo)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            try
            {
                return WindowCameraDataAccess.IsWindowCameraExisted(db, windowCameraInfo.Row, windowCameraInfo.Col)
                           ? WindowCameraDataAccess.Update(db, windowCameraInfo.Row, windowCameraInfo.Col,
                                                           windowCameraInfo.CameraId)
                           : WindowCameraDataAccess.Insert(db, windowCameraInfo);
            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return -1;
            }
        }

        public int Delete(ref string errMessage, int id)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            try
            {
                int iRtn = WindowCameraDataAccess.Delete(db, id);
                return iRtn;
            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return -1;
            }
        }

        public int Update(ref string errMessage, int id, int camera)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            try
            {
                int iRtn = WindowCameraDataAccess.Update(db, id, camera);
                return iRtn;
            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return -1;
            }
        }

        public int Update(ref string errMessage, int id, int row, int col)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            try
            {
                int iRtn = WindowCameraDataAccess.Update(db, id, row, col);
                return iRtn;
            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return -1;
            }
        }
        
        public Dictionary<int, WindowCameraInfo> GetAllWindowCameraInfo(ref string errMessage)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            Dictionary<int, WindowCameraInfo> list = new Dictionary<int, WindowCameraInfo>();
            try
            {

                DataSet ds = WindowCameraDataAccess.GetAllWindowCameraInfo(db);

                WindowCameraInfo windowCameraInfo;
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    windowCameraInfo = new WindowCameraInfo(ds.Tables[0].Rows[i]);
                    list.Add(windowCameraInfo.Id, windowCameraInfo);
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

        public WindowCameraInfo GetWindowCameraInfoById(ref string errMessage, int id)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            try
            {
                DataSet ds = WindowCameraDataAccess.GetWindowCameraInfoById(db, id);
                if (ds.Tables[0].Rows.Count == 0)
                {
                    return null;
                }
                return new WindowCameraInfo(ds.Tables[0].Rows[0]);

            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return null;
            }
        }

        public Dictionary<int, WindowCameraInfo> GetWindowCameraInfoByCamera(ref string errMessage, int camera)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            Dictionary<int, WindowCameraInfo> list = new Dictionary<int, WindowCameraInfo>();
            try
            {
                DataSet ds = WindowCameraDataAccess.GetWindowCameraInfoByCamera(db, camera);
                WindowCameraInfo windowCameraInfo;
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    windowCameraInfo = new WindowCameraInfo(ds.Tables[0].Rows[i]);
                    list.Add(windowCameraInfo.Id, windowCameraInfo);
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

        public WindowCameraInfo GetWindowCameraInfoByRowCol(ref string errMessage, int row,  int col)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            try
            {
                DataSet ds = WindowCameraDataAccess.GetWindowCameraInfoByRowCol(db, row, col);
                if (ds.Tables[0].Rows.Count == 0)
                {
                    return null;
                }
                return new WindowCameraInfo(ds.Tables[0].Rows[0]);

            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return null;
            }
        }

        public bool IsWindowCameraExisted(ref string errMessage, int row,  int col)
        {
            bool ret = true;
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            try
            {
                return WindowCameraDataAccess.IsWindowCameraExisted(db,row,col);
            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return true;
            }
        }

    }
}
