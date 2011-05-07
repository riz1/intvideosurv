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
    public class AnalysisXMLBusiness
    {
        public static readonly ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private static AnalysisXMLBusiness instance;
        public static AnalysisXMLBusiness Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AnalysisXMLBusiness();
                }
                return instance;
            }
        }
        public int InsertCapturePicture(ref string errMessage, CapturePicture ocapturepicture)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            try
            {
                return AnalysisXMLDataAccess.InsertCapturePicture(db,ocapturepicture);

            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return -1;
            }
        }
        public int InsertVehicle(ref string errMessage, Vehicle ovehicle)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            try
            {
                return AnalysisXMLDataAccess.InsertVehicle(db, ovehicle);

            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return -1;
            }
        }
        public int InsertFace(ref string errMessage, Face oFace)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            try
            {
                return AnalysisXMLDataAccess.InsertFace(db, oFace);

            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return -1;
            }
        }
        public int InsertREct(ref string errMessage, REct oRect)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            try
            {
                return AnalysisXMLDataAccess.InsertREct(db, oRect);

            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return -1;
            }
        }
        public int InsertTrack(ref string errMessage, Track oTrack)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            try
            {
                return AnalysisXMLDataAccess.InsertTrack(db, oTrack);

            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return -1;
            }
        }

        public Dictionary<int,Face> GetFaceCustom(ref string errMessage, string str)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            Dictionary<int, Face> list = new Dictionary<int, Face>();
            try
            {
                DataSet ds = AnalysisXMLDataAccess.GetFaceCustom(db, str);
                Face face;
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    face = new Face(ds.Tables[0].Rows[i]);
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
    }
}
