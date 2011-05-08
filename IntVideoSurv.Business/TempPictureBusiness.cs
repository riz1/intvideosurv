using System;
using System.IO;
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
    public class TempPictureBusiness
    {
        public static readonly ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private static TempPictureBusiness instance;
        public static TempPictureBusiness Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new TempPictureBusiness();
                }
                return instance;
            }
        }
        public int InsertTempPicture(ref string errMessage, TempPicture oTempPicture)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            try
            {
                return TempPictureDataAccess.InsertTempPicture(db, oTempPicture);

            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return -1;
            }
        }
        public string MoveTempPicture(ref string errMessage, TempPicture oTempPicture)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            try
            {
                string ret = null;
                string destFilePath = SystemParametersBusiness.Instance.ListSystemParameter["CapPicPath"] + @"\" + oTempPicture.CameraID +
                        @"\" + oTempPicture.Datetime.ToString(@"yyyy\\MM\\dd\\HH\\") + oTempPicture.CameraID + oTempPicture.Datetime.ToString(@"_yyyy_MM_dd_HH_mm_ss_fff") + ".jpg";
                if (File.Exists(oTempPicture.FilePath))
                {
                    string path = Path.GetDirectoryName(destFilePath);
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    File.Move(oTempPicture.FilePath, destFilePath);
                    TempPictureDataAccess.DeleteTempPicture(db, oTempPicture.PictureID);
                    ret = destFilePath;

                }
                return ret;

            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return null;
            }
        }

        public int DeleteTempPictureFromDb(ref string errMessage, int pictureId)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            try
            {
                return TempPictureDataAccess.DeleteTempPicture(db, pictureId);

            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return -1;
            }
        }

        public int DeleteTempPictureFromDbAndDisk(ref string errMessage, TempPicture oTempPicture)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            try
            {
                if (File.Exists(oTempPicture.FilePath))
                {
                    File.Delete(oTempPicture.FilePath);
                }
                return TempPictureDataAccess.DeleteTempPicture(db, oTempPicture.PictureID);

            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return -1;
            }
        }
        public TempPicture GetTempPicture(ref string errMessage,int cameraId, DateTime camptureDateTime)
        {
            Database db = DatabaseFactory.CreateDatabase();
            string cmdText = string.Format("select * from TempPicture where CameraId={0} and DateTime='{1}'", cameraId, camptureDateTime);
            try
            {
                DataSet ds = TempPictureDataAccess.GetTempPicture(db, cameraId, camptureDateTime);
                return  new TempPicture(ds.Tables[0].Rows[0]);

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