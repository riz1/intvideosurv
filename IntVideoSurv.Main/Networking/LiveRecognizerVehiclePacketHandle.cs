using System;
using System.IO;
using System.Text;
using System.Drawing;
using log4net;

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


                //解析人脸数据并入库
                //更新主窗口显示结果的界面
                OnDataChanged(this, new DataChangeEventArgs(GetType().Name));

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

