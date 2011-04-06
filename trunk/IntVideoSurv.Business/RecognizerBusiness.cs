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
    public class RecognizerBusiness
    {
        public static readonly ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private static RecognizerBusiness instance;
        public static RecognizerBusiness Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new RecognizerBusiness();
                }
                return instance;
            }
        }
        //向recognizercamera中添加摄像头信息
        public int InsertCamera(ref string errMessage, int orecognizer, int ocamera)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            try
            {
                if (RecognizerDataAccess.GetTheCamera(db, ocamera).Tables[0].Rows.Count != 0)
                {

                    return -1;

                }
                else
                {
                    return RecognizerDataAccess.InsertCamera(db, orecognizer, ocamera);
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

        public int Insert(ref string errMessage, RecognizerInfo recognizer)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            try
            {
                return RecognizerDataAccess.Insert(db, recognizer);

            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return -1;
            }
        }

        public int Update(ref string errMessage, RecognizerInfo oRecognizerInfo)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            try
            {
                return RecognizerDataAccess.Update(db, oRecognizerInfo);

            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return -1;
            }


        }
        public int Delete(ref string errMessage, int RecognizerId)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            try
            {
                int iRtn = RecognizerDataAccess.Delete(db, RecognizerId);
                return iRtn;
            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return -1;
            }

        }

        public int DeleteByRecognizerId(ref string errMessage, int RecognizerId)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            try
            {
                int iRtn = RecognizerDataAccess.DeleteByRecognizerId(db, RecognizerId);
                return iRtn;
            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return -1;
            }

        }
        //据摄像头id删除摄像头
        public int DeleteCamera(ref string errMessage, int CameraId)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            try
            {
                int iRtn = RecognizerDataAccess.DeleteCameras(db, CameraId);

                return iRtn;
            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return -1;
            }

        }
        public Dictionary<int, RecognizerInfo> GetAllRecognizerInfo(ref string errMessage)
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
            Dictionary<int, RecognizerInfo> mylist = new Dictionary<int, RecognizerInfo>();
            try
            {
                RecognizerInfo oRecognizerInfo;
                DataSet ds = RecognizerDataAccess.GetAllRecInfo(db);
                DataSet dsCamera;
                CameraInfo oCamera;

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    oRecognizerInfo = new RecognizerInfo(ds.Tables[0].Rows[i]);
                    dsCamera = RecognizerDataAccess.GetCameraInfoByRecognizerId(db, oRecognizerInfo.Id);
                    //DecoderDataAccess.GetCamInfoByCameraId(db,dsCamera.Tables[0].Rows[i].)
                    oRecognizerInfo.ListCameras = new Dictionary<int, CameraInfo>();
                    foreach (DataRow dr in dsCamera.Tables[0].Rows)
                    {

                        oCamera = new CameraInfo(dr);
                        oRecognizerInfo.ListCameras.Add(oCamera.CameraId, oCamera);
                    }
                    mylist.Add(oRecognizerInfo.Id, oRecognizerInfo);
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
        public RecognizerInfo GetRecognizerInfoByRecognizerId(ref string errMessage, int RecognizerId)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            try
            {
                DataSet ds = RecognizerDataAccess.GetRecognizerInfoByRecognizerId(db, RecognizerId);
                if (ds.Tables[0].Rows.Count == 0)
                {
                    return null;
                }
                RecognizerInfo oRecognizerInfo = new RecognizerInfo(ds.Tables[0].Rows[0]);
                DataSet dsCamera;
                CameraInfo oCamera;
                dsCamera = RecognizerDataAccess.GetCameraInfoByRecognizerId(db, oRecognizerInfo.Id);
                //DecoderDataAccess.GetCamInfoByCameraId(db,dsCamera.Tables[0].Rows[i].)
                oRecognizerInfo.ListCameras = new Dictionary<int, CameraInfo>();
                foreach (DataRow dr in dsCamera.Tables[0].Rows)
                {

                    oCamera = new CameraInfo(dr);
                    oRecognizerInfo.ListCameras.Add(oCamera.CameraId, oCamera);
                }
                return oRecognizerInfo;

            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return null;
            }
        }
        public Dictionary<int, RecognizerInfo> GetRecognizerInfoByName(ref string errMessage, string Name)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            Dictionary<int, RecognizerInfo> mylist = new Dictionary<int, RecognizerInfo>();
            try
            {

                DataSet ds = RecognizerDataAccess.GetRecognizerInfoByName(db, Name);

                RecognizerInfo oRecognizerInfo;
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    oRecognizerInfo = new RecognizerInfo(ds.Tables[0].Rows[i]);
                    DataSet dsCamera;
                    CameraInfo oCamera;
                    dsCamera = RecognizerDataAccess.GetCameraInfoByRecognizerId(db, oRecognizerInfo.Id);
                    //DecoderDataAccess.GetCamInfoByCameraId(db,dsCamera.Tables[0].Rows[i].)
                    oRecognizerInfo.ListCameras = new Dictionary<int, CameraInfo>();
                    foreach (DataRow dr in dsCamera.Tables[0].Rows)
                    {

                        oCamera = new CameraInfo(dr);
                        oRecognizerInfo.ListCameras.Add(oCamera.CameraId, oCamera);
                    }

                    mylist.Add(oRecognizerInfo.Id, oRecognizerInfo);
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
        public string GetRecognizerXMLString(int recognizerid)
        {
            string ret = "", errMessage = "";
            RecognizerInfo oRecognizerInfo = GetRecognizerInfoByRecognizerId(ref errMessage, recognizerid);
            if (oRecognizerInfo != null)
            {
                //头,版本，编码信息
                XmlDocument doc = new XmlDocument();
                XmlNode docNode = doc.CreateXmlDeclaration("1.0", "gb2313", null);
                doc.AppendChild(docNode);

                //recognizer
                XmlNode decoderNode = doc.CreateElement("Recognizer");
                XmlAttribute decoderAttribute = doc.CreateAttribute("Id");
                decoderAttribute.Value = recognizerid.ToString();
                decoderNode.Attributes.Append(decoderAttribute);
                doc.AppendChild(decoderNode);

                //cameras
                XmlNode camerasNode = doc.CreateElement("Cameras");
                decoderNode.AppendChild(camerasNode);
                if (oRecognizerInfo.ListCameras != null)
                {
                    foreach (var VARIABLE in oRecognizerInfo.ListCameras)
                    {
                        //camera
                        XmlNode cameraNode = doc.CreateElement("Camera");
                        camerasNode.AppendChild(cameraNode);

                        //id
                        XmlElement idNode = doc.CreateElement("Id");
                        idNode.InnerText = VARIABLE.Value.CameraId.ToString();
                        cameraNode.AppendChild(idNode);
                        //name
                        XmlElement nameNode = doc.CreateElement("Name");
                        nameNode.InnerText = VARIABLE.Value.Name;
                        cameraNode.AppendChild(nameNode);

                        //获取设备信息

                        DeviceInfo deviceInfo = DeviceBusiness.Instance.GetDeviceInfoByDeviceId(ref errMessage, VARIABLE.Value.DeviceId);

                        //ip
                        XmlElement ipNode = doc.CreateElement("Ip");
                        ipNode.InnerText = deviceInfo.source;
                        cameraNode.AppendChild(ipNode);


                        //ip
                        XmlElement portNode = doc.CreateElement("Port");
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

        public DeviceInfo GetDeviceInfoByCameraId(ref string errMessage, int Id)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            try
            {
                DataSet ds = RecognizerDataAccess.GetDeviceInfoByCameraId(db, Id);
                if (ds.Tables[0].Rows.Count == 0)
                {
                    return null;
                }
                return new DeviceInfo(ds.Tables[0].Rows[0]);

            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return null;
            }

        }

        public RecognizerInfo GetRecognizerInfoByRecognizerIP(ref string errMessage, string IP)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            try
            {
                DataSet ds = RecognizerDataAccess.GetRecognizerInfoByRecognizerIP(db, IP);
                if (ds.Tables[0].Rows.Count == 0)
                {
                    return null;
                }
                RecognizerInfo oRecognizerInfo = new RecognizerInfo(ds.Tables[0].Rows[0]);
                DataSet dsCamera;
                CameraInfo oCamera;
                dsCamera = RecognizerDataAccess.GetCameraInfoByRecognizerId(db, oRecognizerInfo.Id);
                //DecoderDataAccess.GetCamInfoByCameraId(db,dsCamera.Tables[0].Rows[i].)
                oRecognizerInfo.ListCameras = new Dictionary<int, CameraInfo>();
                foreach (DataRow dr in dsCamera.Tables[0].Rows)
                {

                    oCamera = new CameraInfo(dr);
                    oRecognizerInfo.ListCameras.Add(oCamera.CameraId, oCamera);
                }
                return oRecognizerInfo;

            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return null;
            }
        }
        public RecognizerInfo GetRecognizerInfoByCameraId(ref string errMessage,int CameraId)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            try
            {
                DataSet ds = RecognizerDataAccess.GetRecognizerInfoByCameraId(db, CameraId);
                if (ds.Tables[0].Rows.Count == 0)
                {
                    return null;
                }
                return new RecognizerInfo(ds.Tables[0].Rows[0]);

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
