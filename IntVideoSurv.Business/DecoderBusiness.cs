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
                DecoderInfo decoderInfo = new DecoderInfo(ds.Tables[0].Rows[0]);
                DataSet dsCamera;
                CameraInfo oCamera;
                dsCamera = DecoderDataAccess.GetCameraInfoByDecoderId(db, decoderInfo.id);
                //DecoderDataAccess.GetCamInfoByCameraId(db,dsCamera.Tables[0].Rows[i].)
                decoderInfo.ListCameras = new Dictionary<int, CameraInfo>();
                foreach (DataRow dr in dsCamera.Tables[0].Rows)
                {

                    oCamera = new CameraInfo(dr);
                    decoderInfo.ListCameras.Add(oCamera.CameraId, oCamera);
                }
                return decoderInfo;

            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return null;
            }
        }
        public Dictionary<int, DecoderInfo> GetDecoderInfoByName(ref string errMessage, string Name)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            Dictionary<int, DecoderInfo> mylist = new Dictionary<int, DecoderInfo>();
            try
            {

                DataSet ds = DecoderDataAccess.GetDecoderInfoByName(db, Name);

                DecoderInfo decoderInfo;
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    decoderInfo = new DecoderInfo(ds.Tables[0].Rows[i]);
                    DataSet dsCamera;
                    CameraInfo oCamera;
                    dsCamera = DecoderDataAccess.GetCameraInfoByDecoderId(db, decoderInfo.id);
                    //DecoderDataAccess.GetCamInfoByCameraId(db,dsCamera.Tables[0].Rows[i].)
                    decoderInfo.ListCameras = new Dictionary<int, CameraInfo>();
                    foreach (DataRow dr in dsCamera.Tables[0].Rows)
                    {

                        oCamera = new CameraInfo(dr);
                        decoderInfo.ListCameras.Add(oCamera.CameraId, oCamera);
                    }

                    mylist.Add(decoderInfo.id, decoderInfo);
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
        public string GetDecoderXMLString(int decoderid)
        {
            string ret = "",errMessage="";
            DecoderInfo decoderInfo = GetDecoderInfoByDecoderId(ref errMessage, decoderid);
            if (decoderInfo != null)
            {
                //头,版本，编码信息
                XmlDocument doc = new XmlDocument();
                XmlNode docNode = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
                doc.AppendChild(docNode);

                //decoder
                XmlNode decoderNode = doc.CreateElement("Decoder");
                XmlAttribute decoderAttribute = doc.CreateAttribute("id");
                decoderAttribute.Value = decoderid.ToString();
                decoderNode.Attributes.Append(decoderAttribute);
                doc.AppendChild(decoderNode);

                //cameras
                XmlNode camerasNode = doc.CreateElement("Cameras");
                decoderNode.AppendChild(camerasNode);
                if (decoderInfo.ListCameras!=null)
                {
                    foreach (var VARIABLE in decoderInfo.ListCameras)
                    {
                        //camera
                        XmlNode cameraNode = doc.CreateElement("Camera");
                        camerasNode.AppendChild(cameraNode);

                        //id
                        XmlElement idNode = doc.CreateElement("id");
                        idNode.InnerText = VARIABLE.Value.CameraId.ToString();
                        cameraNode.AppendChild(idNode);
                        //name
                        XmlElement nameNode = doc.CreateElement("Name");
                        nameNode.InnerText = VARIABLE.Value.Name;
                        cameraNode.AppendChild(nameNode);

                        //获取设备信息

                        DeviceInfo deviceInfo = DeviceBusiness.Instance.GetDeviceInfoByDeviceId(ref errMessage, VARIABLE.Value.DeviceId);

                        //ip
                        XmlElement ipNode = doc.CreateElement("ip");
                        ipNode.InnerText = deviceInfo.source;
                        cameraNode.AppendChild(ipNode);


                        //ip
                        XmlElement portNode = doc.CreateElement("port");
                        portNode.InnerText = deviceInfo.Port.ToString();
                        cameraNode.AppendChild(portNode);


                        //user
                        XmlElement userNode = doc.CreateElement("username");
                        userNode.InnerText = deviceInfo.login;
                        cameraNode.AppendChild(userNode);

                        //password
                        XmlElement pwdNode = doc.CreateElement("password");
                        pwdNode.InnerText = deviceInfo.pwd;
                        cameraNode.AppendChild(pwdNode);
                        
                        
                        //channel
                        XmlElement channelNode = doc.CreateElement("channel");
                        channelNode.InnerText = VARIABLE.Value.ChannelNo.ToString();
                        cameraNode.AppendChild(channelNode);

                        //width
                        XmlElement widthNode = doc.CreateElement("width");
                        widthNode.InnerText = VARIABLE.Value.Width.ToString();
                        cameraNode.AppendChild(widthNode);

                        //channel
                        XmlElement heightNode = doc.CreateElement("height");
                        heightNode.InnerText = VARIABLE.Value.Height.ToString();
                        cameraNode.AppendChild(heightNode);



                    }                    
                }

                ret = doc.InnerXml;
            }

            return ret;
        }
    }
}
