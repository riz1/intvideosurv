using System;
using System.IO;
using System.Text;
using System.Drawing;
using System.Xml;
using log4net;
using IntVideoSurv.Business;
using IntVideoSurv.Entity;

namespace CameraViewer.NetWorking
{
    public class LiveRecognizerEventPacketHandle : IPacketHandler
    {
        public event MainForm.ImageDataChangeHandle DataChange;

        public static readonly ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


        #region IPacketHandler Members

        public bool CanHandle(byte[] bytes)
        {
            return BitConverter.ToInt32(bytes, 0) == 201;
        }
        public static string FromASCIIByteArray(byte[] characters)
        {
            ASCIIEncoding encoding = new ASCIIEncoding();
            string constructedString = encoding.GetString(characters);
            return (constructedString);
        }

        public void Handle(byte[] bytes)
        {
            try
            {
                logger.Info("开始解析事件数据");

                //获取xml
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.LoadXml(BitConverter.ToString(bytes, 4));

                string errMessage = "";
                int cameraid;
                int pictureid = 0;
                int eventid;
                int objid;
                DateTime timeid;
                XmlNodeList xml_cameras;
                xml_cameras = xmlDocument.SelectSingleNode("/pr/cameras").ChildNodes;
                foreach (XmlNode xmlItem in xml_cameras)
                {
                    XmlElement camera = (XmlElement)xmlItem;
                    cameraid = Convert.ToInt32(camera.GetAttribute("id"));
                    timeid = new DateTime(long.Parse(camera.GetAttribute("timeid")));
                    if (!CapturePictureBusiness.Instance.IsExistCapturePicture(ref errMessage,cameraid,timeid))
                    {
                        //将改图像从TempPicture表移动到CapturePicture//先获取临时图像GetTempPicture，再移动图像MoveTempPicture 
                        //图像还在临时图像库中
                        TempPicture tempPicture = TempPictureBusiness.Instance.GetTempPicture(ref errMessage, cameraid, timeid);
                        string destFile = TempPictureBusiness.Instance.MoveTempPicture(ref errMessage, tempPicture);
                        CapturePicture capturePictureinsert = new CapturePicture() { CameraID = cameraid, Datetime = timeid, FilePath = destFile };
                        pictureid = CapturePictureBusiness.Instance.Insert(ref errMessage, capturePictureinsert);
                    }

                    CapturePicture oCapturePicture = CapturePictureBusiness.Instance.GetCapturePicture(ref errMessage, cameraid, timeid);

                    Event ev = new Event();
                    ev.CarNum = Convert.ToInt32(camera.GetAttribute("CarNum"));
                    ev.Congestion = Convert.ToInt32(camera.GetAttribute("Congestion"));
                    ev.PictureID = pictureid;
                    eventid = EventBusiness.Instance.Insert(ref errMessage, ev);

                    XmlNodeList objectlist = xmlItem.ChildNodes;
                    foreach (XmlNode xmlitem1 in objectlist)
                    {
                        XmlElement objecttarget = (XmlElement)xmlitem1;
                        ObjectInfo obj = new ObjectInfo();
                        if (Convert.ToInt32(objecttarget.GetAttribute("stop")) == 1)
                        {
                            obj.stop = true;
                        }
                        else
                        {
                            obj.stop = false;
                        }
                        if (Convert.ToInt32(objecttarget.GetAttribute("illegalDir")) == 1)
                        {
                            obj.illegalDir = true;
                        }
                        else
                        {
                            obj.illegalDir = false;
                        }
                        if (Convert.ToInt32(objecttarget.GetAttribute("CrossLine")) == 1)
                        {
                            obj.CrossLine = true;
                        }
                        else
                        {
                            obj.CrossLine = false;
                        }
                        if (Convert.ToInt32(objecttarget.GetAttribute("changeChannel")) == 1)
                        {
                            obj.changeChannel = true;
                        }
                        else
                        {
                            obj.changeChannel = false;
                        }
                        obj.EventId = eventid;
                        objid = ObjectBusiness.Instance.Insert(ref errMessage, obj);
                        foreach (XmlNode rectitem in objecttarget.ChildNodes)
                        {
                            XmlElement rectelement = (XmlElement)rectitem;
                            EventRect myrect = new EventRect();
                            myrect.x = Convert.ToInt32(rectelement.GetAttribute("x"));
                            myrect.y = Convert.ToInt32(rectelement.GetAttribute("y"));
                            myrect.w = Convert.ToInt32(rectelement.GetAttribute("w"));
                            myrect.h = Convert.ToInt32(rectelement.GetAttribute("h"));
                            myrect.ObjectId = objid;
                            EventRectBusiness.Instance.Insert(ref errMessage, myrect);
                        }
                    }
                    

                }
                /*******************处理流程：
                
                 * 1）解析xml文件，获取cameraid和DateTime
                 * 2）根据cameraid和DateTime判断改图像是否已经进入CapturePicture表
                 * 3）如果是；转5；
                 * 4）如果否，将改图像从TempPicture表移动到CapturePicture//先获取临时图像GetTempPicture，再移动图像MoveTempPicture
                 * 5）识别结果入库
                 */


                logger.Info("结束解析事件数据");
            }
            catch (Exception ex)
            {
                logger.Error("解析事件数据错误:" + FromASCIIByteArray(bytes));
            }
        }
        #endregion

        protected void OnDataChanged(object sender, DataChangeEventArgs e)
        {
            if (DataChange != null)
            {
                DataChange(sender, e);
            }
        }
        private int ToInt32Reverse(byte[] header, int pos)
        {

            var newbyte = new byte[4];
            for (int i = 0; i < 4; i++)
            {
                newbyte[i] = header[pos + 3 - i];
            
            }
            return BitConverter.ToInt32(newbyte, 0);
        }
    }
}

