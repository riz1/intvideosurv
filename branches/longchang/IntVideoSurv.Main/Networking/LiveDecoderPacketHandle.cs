using System;
using System.IO;
using System.Text;
using System.Drawing;
using IntVideoSurv.Business;
using IntVideoSurv.Entity;
using log4net;

namespace CameraViewer.NetWorking
{
    public class LiveDecoderPacketHandle : IPacketHandler
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
        //精确到毫秒的时间戳(long) +摄像头(int)+任务号（int）+格式(int)+W(int)+H(int) +数据
        public void Handle(byte[] bytes)
        {
            try
            {
                logger.Info("开始解析图像数据");
                

                int datalength = BitConverter.ToInt32(bytes, 4);//数据长度

                long captureTicks = BitConverter.ToInt64(bytes, 8);//抓拍时间Ticks
                DateTime captureTime = new DateTime(captureTicks);

                int cameraId = BitConverter.ToInt32(bytes, 16);//摄像头ID
                int taskId = BitConverter.ToInt32(bytes, 20);//摄像头ID
                int picType = BitConverter.ToInt32(bytes, 24);//图像类型
                int width = BitConverter.ToInt32(bytes, 28);//图像宽度
                int height = BitConverter.ToInt32(bytes, 32);//图像高度

                if (datalength + 8 == bytes.Length)
                {
                    //获取图像数据的真实长度
                    var imgLen = datalength - 24;
                    var imageDetail=new byte[imgLen];
                    Array.Copy(bytes, 32, imageDetail, 0, imgLen);
                    CurrentNetImage = new NetImage
                                          {
                                              CameraId = cameraId,
                                              Image =
                                                  picType == 2
                                                      ? YUV2RGB.GetBitmapFromYUVStream(width, height, imageDetail)
                                                      : YUV2RGB.GetBitmapFromRGBStream(width, height, imageDetail),
                                              Width = width,
                                              Height =height,
                                              Format = picType,
                                              CaptureTime = captureTime

                                          };

                    //图像入临时图片库
                    string errMessage = "";

                    TempPictureBusiness.Instance.InsertTempPicture(ref errMessage, new TempPicture()
                                                                                       {
                                                                                           CameraID = cameraId,
                                                                                           Datetime = captureTime,
                                                                                           IsHistroy = false,
                                                                                           FilePath =
                                                                                               SystemParametersBusiness.Instance.ListSystemParameter["TempPicPath"] +
                                                                                               @"\" + cameraId +
                                                                                               @"\" +
                                                                                               captureTime.ToString(
                                                                                                   @"yyyy\\MM\\dd\\HH\\") +
                                                                                               cameraId +
                                                                                               captureTime.ToString(
                                                                                                   @"_yyyy_MM_dd_HH_mm_ss_fff") +
                                                                                               ".jpg"
                                                                                       });

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

