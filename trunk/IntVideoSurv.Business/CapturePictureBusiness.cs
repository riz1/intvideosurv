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
        public int GetTheCapturePicture(ref string errMessage,int id,DateTime dt)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            try
            {
                if (CapturePictureDataAccess.GetTheCapturePicture(db, id,dt).Tables[0].Rows.Count != 0)
                {

                    return -1;

                }
                else
                {
                    return 0;
                    //return CapturePictureDataAccess.Insert(db, );
                }
                //return DecoderDataAccess.InsertCamera(db, odecoder, ocamera);  

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
