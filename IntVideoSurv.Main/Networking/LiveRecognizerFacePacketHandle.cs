using System;
using System.IO;
using System.Text;
using System.Drawing;
using System.Xml;
using IntVideoSurv.Business;
using IntVideoSurv.Entity;
using log4net;
using IntVideoSurv.Entity;
using IntVideoSurv.Business;
using System.Drawing.Imaging;

namespace CameraViewer.NetWorking
{
    public class LiveRecognizerFacePacketHandle : IPacketHandler
    {
        public event MainForm.FaceHandle DataChange;

        public static readonly ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #region IPacketHandler Members

        public bool CanHandle(byte[] bytes)
        {
            return BitConverter.ToInt32(bytes, 0) == 202;
        }
        public static string FromASCIIByteArray(byte[] characters)
        {
            ASCIIEncoding encoding = new ASCIIEncoding();
            string constructedString = encoding.GetString(characters);
            return (constructedString);
        }
        public Face CurrentFace { set; get; }
        public void Handle(byte[] bytes)
        {
            try
            {
                logger.Info("开始解析人脸数据");

                //获取xml
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.LoadXml(BitConverter.ToString(bytes, 4));

                string errMessage = "";
                int cameraid =-1;
                DateTime timeid = new DateTime(1,1,1);
                XmlNodeList xml_cameras,xml_faces;
                xml_cameras = xmlDocument.SelectSingleNode("/pr/cameras").ChildNodes;
                foreach (XmlNode xmlItem in xml_cameras)
                {
                    XmlElement camera = (XmlElement)xmlItem;
                    cameraid = Convert.ToInt32(camera.GetAttribute("id"));
                    timeid = new DateTime(long.Parse(camera.GetAttribute("timeid")));
                    if (!CapturePictureBusiness.Instance.IsExistCapturePicture(ref errMessage, cameraid, timeid))
                    {
                        //将改图像从TempPicture表移动到CapturePicture//先获取临时图像GetTempPicture，再移动图像MoveTempPicture 
                        //图像还在临时图像库中
                        TempPicture tempPicture = TempPictureBusiness.Instance.GetTempPicture(ref errMessage, cameraid, timeid);
                        string destFile = TempPictureBusiness.Instance.MoveTempPicture(ref errMessage, tempPicture);
                        CapturePicture capturePictureinsert = new CapturePicture(){CameraID = cameraid,Datetime = timeid,FilePath = destFile};
                        CapturePictureBusiness.Instance.Insert(ref errMessage, capturePictureinsert);

                    }
                    //识别结果入库
                    CapturePicture oCapturePicture = CapturePictureBusiness.Instance.GetCapturePicture(ref errMessage,cameraid,timeid);
                    xml_faces = xmlItem.FirstChild.ChildNodes;//获得faces节点
                    string facePath = SystemParametersBusiness.Instance.ListSystemParameter["FacePicPath"] + @"\" + cameraid +
                        @"\" + timeid.ToString(@"yyyy\\MM\\dd\\HH\\") + cameraid + timeid.ToString(@"_yyyy_MM_dd_HH_mm_ss_fff");
                    int i = 1;
                    foreach (XmlNode faceItem in xml_faces)
                    {
                        XmlNode rectNode = faceItem.FirstChild;
                        XmlNode scoreNode = faceItem.LastChild;
                        XmlElement rectElement = (XmlElement)rectNode;
                        XmlElement scoreElement = (XmlElement)scoreNode;
                        REct facerect = new REct();
                        facerect.X = Convert.ToInt32(rectElement.GetAttribute("x"));
                        facerect.Y = Convert.ToInt32(rectElement.GetAttribute("y"));
                        facerect.W = Convert.ToInt32(rectElement.GetAttribute("w"));
                        facerect.H = Convert.ToInt32(rectElement.GetAttribute("h"));
                        int RectId = REctBusiness.Instance.Insert(ref errMessage, facerect);
                        
                        //抠图
                        Image newImage = Image.FromFile(oCapturePicture.FilePath);
                        Bitmap tmpbitmap = new Bitmap(facerect.W+1, facerect.H+1);
                        Rectangle rectSrt = new Rectangle(facerect.X, facerect.Y, facerect.W, facerect.H);
                        Rectangle rectDst = new Rectangle(0, 0, facerect.W, facerect.H);
                        Graphics graphic = Graphics.FromImage(tmpbitmap);
                        graphic.DrawImage(newImage, rectDst, rectSrt, GraphicsUnit.Pixel);
                        string faceFile = facePath +"_" + i + ".jpg";
                        string path = Path.GetDirectoryName(faceFile);
                        if (!Directory.Exists(path))
                        {
                            Directory.CreateDirectory(path);
                        }
                        tmpbitmap.Save(faceFile, ImageFormat.Jpeg);
                        
                        Face xmlface = new Face();
                        xmlface.score = Convert.ToSingle(scoreElement.InnerText);
                        xmlface.RectID = RectId;
                        xmlface.PictureID = oCapturePicture.PictureID;
                        xmlface.FacePath = faceFile;
                        int faceId = FaceBusiness.Instance.Insert(ref errMessage, xmlface);
                    }


                }
                //解析人脸数据并入库
                /*******************处理流程：
                
 * 1）解析xml文件，获取cameraid和DateTime
 * 2）根据cameraid和DateTime判断改图像是否已经进入CapturePicture表
 * 3）如果是；转5；
 * 4）如果否，将改图像从TempPicture表移动到CapturePicture//先获取临时图像GetTempPicture，再移动图像MoveTempPicture
 * 5）识别结果入库
 */

                CurrentFace = FaceBusiness.Instance.GetFace(ref errMessage, cameraid, timeid);
                OnDataChanged(this, new DataChangeEventArgs(GetType().Name));
                logger.Info("结束解析人脸数据");
            }
            catch (Exception ex)
            {
                logger.Error("解析人脸数据错误:" + FromASCIIByteArray(bytes));
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
    }
}


