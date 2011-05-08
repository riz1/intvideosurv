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
    public class CapturePictureBusiness
    {
        public static readonly ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private static CapturePictureBusiness instance;
        public static CapturePictureBusiness Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CapturePictureBusiness();
                }
                return instance;
            }
        }

        public int Insert(ref string errMessage, CapturePicture oCapturePicture)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            try
            {
                return CapturePictureDataAccess.Insert(db, oCapturePicture);

            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return -1;
            }
        }
        public CapturePicture GetCapturePicture(ref string errMessage, int cameraId,DateTime dateTime)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            try
            {
                DataSet ds = CapturePictureDataAccess.GetCapturePicture(db, cameraId, dateTime);
                return new CapturePicture(ds.Tables[0].Rows[0]);

            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return null;
            }
        }

        public CapturePicture GetCapturePicture(ref string errMessage, int id)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            try
            {
                DataSet ds = CapturePictureDataAccess.GetCapturePicture(db, id);
                return new CapturePicture(ds.Tables[0].Rows[0]);

            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return null;
            }
        }
        public bool IsExistCapturePicture(ref string errMessage,int id,DateTime dt)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            try
            {
                return CapturePictureDataAccess.IsExistCapturePicture(db, id, dt);

            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return false;
            }
        }
    }
}
