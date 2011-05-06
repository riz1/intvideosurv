using System;
using System.IO;
using System.Text;
using System.Drawing;
using System.Xml;
using log4net;

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

