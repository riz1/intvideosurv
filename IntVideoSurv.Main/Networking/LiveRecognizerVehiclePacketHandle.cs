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
    public class LiveRecognizerVehiclePacketHandle : IPacketHandler
    {
        public event MainForm.ImageDataChangeHandle DataChange;

        public static readonly ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


        public int LaneId { set; get; }
        public NetImage CurrentNetImage { set; get; }


        #region IPacketHandler Members

        public bool CanHandle(byte[] bytes)
        {
            return BitConverter.ToInt32(bytes, 0) == 203;
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
                logger.Info("开始解析车牌数据");
                //获取xml
                XmlDocument xmlDocument = new XmlDocument() ;
                xmlDocument.LoadXml(BitConverter.ToString(bytes,4));

                string errMessage = "";
                int cameraid;
                DateTime timeid;
                int pictureId;
                XmlNodeList xml_cameras, xml_vehicles;
                xml_cameras = xmlDocument.SelectSingleNode("/pr/cameras").ChildNodes;
                foreach (XmlNode xmlItem in xml_cameras)
                {
                    XmlElement camera = (XmlElement)xmlItem;
                    cameraid = Convert.ToInt32(camera.GetAttribute("id"));
                    timeid = new DateTime(long.Parse(camera.GetAttribute("timeid")));
                    if (CapturePictureBusiness.Instance.GetTheCapturePicture(ref errMessage, cameraid, timeid) != -1)
                    {
                        //将改图像从TempPicture表移动到CapturePicture//先获取临时图像GetTempPicture，再移动图像MoveTempPicture
                    }
                    //识别结果入库
                    CapturePicture cp = new CapturePicture();
                    cp.CameraID = cameraid;
                    cp.Datetime = timeid;
                    cp.FilePath = SystemParametersBusiness.Instance.ListSystemParameter["CapPicPath"] + @"\" + cp.CameraID +
                        @"\" + cp.Datetime.ToString(@"yyyy\\MM\\dd\\HH\\") + cp.CameraID + cp.Datetime.ToString(@"_yyyy_MM_dd_HH_mm_ss_fff") + ".jpg";
                    pictureId = CapturePictureBusiness.Instance.Insert(ref errMessage, cp);
                    xml_vehicles = xmlItem.FirstChild.ChildNodes;//获得faces节点
                    foreach (XmlNode vehicleItem in xml_vehicles)
                    {
                        XmlNode vehicleNode = vehicleItem.FirstChild;
                        XmlNode vehicleRectNode = vehicleNode.FirstChild;
                        XmlElement vehicleElement = (XmlElement)vehicleNode;
                        XmlElement vehicleRectElement = (XmlElement)vehicleRectNode;
                        REct vehicleRect = new REct();
                        vehicleRect.X = Convert.ToInt32(vehicleRectElement.GetAttribute("x"));
                        vehicleRect.Y = Convert.ToInt32(vehicleRectElement.GetAttribute("y"));
                        vehicleRect.W = Convert.ToInt32(vehicleRectElement.GetAttribute("w"));
                        vehicleRect.H = Convert.ToInt32(vehicleRectElement.GetAttribute("h"));
                        int rectId = REctBusiness.Instance.Insert(ref errMessage, vehicleRect);
                        Vehicle vehicle = new Vehicle();
                        vehicle.platenumber = Convert.ToString(vehicleElement.GetAttribute("platenumber"));
                        vehicle.speed = Convert.ToSingle(vehicleElement.GetAttribute("speed"));
                        if (Convert.ToInt32(vehicleElement.GetAttribute("stemagainst")) == 1)
                        {
                            vehicle.stemagainst = true;
                        }
                        else
                        {
                            vehicle.stemagainst = false;
                        }
                        if (Convert.ToInt32(vehicleElement.GetAttribute("accident")) == 1)
                        {
                            vehicle.accident = true;
                        }
                        else
                        {
                            vehicle.accident = false;
                        }
                        if (Convert.ToInt32(vehicleElement.GetAttribute("stop")) == 1)
                        {
                            vehicle.stop = true;
                        }
                        else
                        {
                            vehicle.stop = false;
                        }
                        if (Convert.ToInt32(vehicleElement.GetAttribute("linechange")) == 1)
                        {
                            vehicle.linechange = true;
                        }
                        else
                        {
                            vehicle.linechange = false;
                        }
                        
                        vehicle.platecolor = Convert.ToString(vehicleElement.GetAttribute("platecolor"));
                        vehicle.vehiclecolor = Convert.ToString(vehicleElement.GetAttribute("vehiclecolor"));
                        vehicle.confidence = Convert.ToSingle(vehicleElement.GetAttribute("confidence"));
                        vehicle.REctId = rectId;
                        vehicle.PictureID = pictureId;
                        int vehicleId = VehicleBusiness.Instance.Insert(ref errMessage, vehicle);

                    }


                }
                //解析车牌数据并入库
                /*******************处理流程：
                
 * 1）解析xml文件，获取cameraid和DateTime
 * 2）根据cameraid和DateTime判断改图像是否已经进入CapturePicture表
 * 3）如果是；转5；
 * 4）如果否，将改图像从TempPicture表移动到CapturePicture//先获取临时图像GetTempPicture，再移动图像MoveTempPicture
 * 5）识别结果入库
 */

                logger.Info("结束解析车牌数据");
            }
            catch (Exception ex)
            {
                logger.Error("解析车牌数据错误:" + FromASCIIByteArray(bytes));
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

