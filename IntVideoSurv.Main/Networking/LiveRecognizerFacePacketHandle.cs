using System;
using System.IO;
using System.Text;
using System.Drawing;
using System.Xml;
using IntVideoSurv.Business;
using IntVideoSurv.Entity;
using log4net;

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

                //解析人脸数据并入库
                /*******************处理流程：
                
 * 1）解析xml文件，获取cameraid和DateTime
 * 2）根据cameraid和DateTime判断改图像是否已经进入CapturePicture表
 * 3）如果是；转5；
 * 4）如果否，将改图像从TempPicture表移动到CapturePicture//先获取临时图像GetTempPicture，再移动图像MoveTempPicture
 * 5）识别结果入库
 */
                int cameraId = 1;
                DateTime dt = DateTime.Now;
                string errMessage = "";
                CurrentFace = AnalysisXMLBusiness.Instance.GetFace(ref errMessage, cameraId, dt);
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


