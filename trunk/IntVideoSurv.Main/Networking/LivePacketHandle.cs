using System;
using System.IO;
using System.Text;
using System.Drawing;
using log4net;

namespace CameraViewer.NetWorking
{
    public class LivePacketHandle : IPacketHandler
    {
        public event MainForm.ImageDataChangeHandle DataChange;

        public static readonly ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


        public int LaneId { set; get;}
        public NetImage CurrentNetImage { set; get; }


        #region IPacketHandler Members

        public bool CanHandle(byte[] bytes)
        {
            return BitConverter.ToInt32(bytes, 0) ==7;
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
                logger.Info("开始解析图像数据");

                int datalength = BitConverter.ToInt32(bytes, 4);//数据长度
                int cameraId = BitConverter.ToInt32(bytes, 8);//摄像头ID
                int picType = BitConverter.ToInt32(bytes, 12);//图像类型
                int width = BitConverter.ToInt32(bytes, 16);//图像宽度
                int height = BitConverter.ToInt32(bytes, 20);//图像高度

                if (datalength + 8 == bytes.Length)
                {
                    //获取图像数据的真实长度
                    var imgLen = datalength - 16;
                    var imageDetail=new byte[imgLen];
                    Array.Copy(bytes, 24, imageDetail, 0, imgLen);
                    CurrentNetImage = new NetImage
                                          {
                                              CameraId = cameraId,
                                              Image =
                                                  picType == 2
                                                      ? YUV2RGB.GetBitmapFromYUVStream(width, height, imageDetail)
                                                      : YUV2RGB.GetBitmapFromRGBStream(width, height, imageDetail)
                                          };

                    OnDataChanged(this, new DataChangeEventArgs(GetType().Name));
                }
                logger.Info("结束解析图像数据");
            }
            catch (Exception ex)
            {
                logger.Error("解析图像数据错误:" + FromASCIIByteArray(bytes));
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

