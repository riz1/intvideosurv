using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using IntVideoSurv.Entity;
using IntVideoSurv.DataAccess;
using log4net;
using videosource;
using System.Drawing;

namespace IntVideoSurv.Business
{
    public class DecoderBusiness
    {
        public static readonly ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private static DecoderBusiness instance;
        public static DecoderBusiness Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DecoderBusiness();
                }
                return instance;
            }
        }
        public int InsertCamera(ref string errMessage, int odecoder, int ocamera)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            try
            { 
                    return DecoderDataAccess.InsertCamera(db, odecoder, ocamera);  
                    
            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return -1;
            }
            
        }
        public int Insert(ref string errMessage, DecoderInfo decoder)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            try
            {
                return DecoderDataAccess.Insert(db, decoder);

            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return -1;
            }
        }

        public int Update(ref string errMessage, DecoderInfo DecoderInfo)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            try
            {
                return DecoderDataAccess.Update(db, DecoderInfo);

            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return -1;
            }


        }
        public int Delete(ref string errMessage, int DecoderId)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            try
            {
                int iRtn = DecoderDataAccess.Delete(db, DecoderId);
                return iRtn;
            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return -1;
            }

        }
        public int DeleteByDecoderId(ref string errMessage, int DecoderId)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            try
            {
                int iRtn = DecoderDataAccess.DeleteByDecoderId(db, DecoderId);
                return iRtn;
            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return -1;
            }

        }
        public int DeleteCamera(ref string errMessage, int CameraId)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            try
            {
                int iRtn = DecoderDataAccess.DeleteCameras(db, CameraId);
                
                return iRtn;
            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return -1;
            }

        }
        public Dictionary<int, DecoderInfo> GetAllDecoderInfo(ref string errMessage)
        {
            /*Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            Dictionary<int, DecoderInfo> list = new Dictionary<int, DecoderInfo>();
            try
            {

                DataSet ds = DecoderDataAccess.GetAllDecInfo(db);

                DecoderInfo oDecoder;
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    oDecoder = new DecoderInfo(ds.Tables[0].Rows[i]);
                    list.Add(oDecoder.id, oDecoder);

                }
                return list;

            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return null;
            }*/
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            Dictionary<int, DecoderInfo> list = new Dictionary<int, DecoderInfo>();
            try
            {
                DecoderInfo oDecoderInfo;
                DataSet ds = DecoderDataAccess.GetAllDecInfo(db);
                DataSet dsCamera;
                CameraInfo oCamera;
               
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    oDecoderInfo = new DecoderInfo(ds.Tables[0].Rows[i]);
                    dsCamera = DecoderDataAccess.GetCameraInfoByDecoderId(db, oDecoderInfo.id);
                    //DecoderDataAccess.GetCamInfoByCameraId(db,dsCamera.Tables[0].Rows[i].)
                    oDecoderInfo.ListCameras = new Dictionary<int, CameraInfo>();
                    foreach (DataRow dr in dsCamera.Tables[0].Rows)
                    {
                        
                            oCamera = new CameraInfo(dr);
                            oDecoderInfo.ListCameras.Add(oCamera.CameraId, oCamera);
                    }
                    list.Add(oDecoderInfo.id, oDecoderInfo);
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
        public DecoderInfo GetDecoderInfoByDecoderId(ref string errMessage, int DecoderId)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            try
            {
                DataSet ds = DecoderDataAccess.GetDecoderInfoByDecoderId(db, DecoderId);
                if (ds.Tables[0].Rows.Count == 0)
                {
                    return null;
                }
                return new DecoderInfo(ds.Tables[0].Rows[0]);

            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return null;
            }
        }
        public Dictionary<int, CameraInfo> GetDecoderInfoByName(ref string errMessage, string Name)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            Dictionary<int, CameraInfo> mylist = new Dictionary<int, CameraInfo>();
            try
            {

                DataSet ds = DecoderDataAccess.GetDecoderInfoByName(db, Name);

                CameraInfo oCamera;
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    oCamera = new CameraInfo(ds.Tables[0].Rows[i]);
                    mylist.Add(oCamera.CameraId, oCamera);
                }
                return mylist;

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
