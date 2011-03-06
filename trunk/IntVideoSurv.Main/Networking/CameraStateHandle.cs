using System;

namespace CameraViewer.NetWorking
{
    public class CameraStateHandle : IPacketHandler
    {
        public CameraStateHandle()
        {
        }

        public event MainForm.ImageDataChangeHandle DataChange;

        public int LaneId { get; private set; }
        public int LaneState { get; private set; }
        public DateTime CurrentTimer { get; private set; }
        #region IPacketHandler Members

        public bool CanHandle(byte[] bytes)
        {
            return BitConverter.ToInt32(bytes, 8) == 2;
        }

        public void Handle(byte[] bytes)
        {
            try
            {
                #region 数据包
                //typeof struct
                //{
                //    DWORD laneId,
                //    DWORD laneState,//0:正常 1:故障
                //    long time //数据包发送时间
                //}
                #endregion
                DateTime dTime = DateTime.Now;//发送数据包的时间
                int laneId = -1;//通道编号
                int laneState = -1;//当前通道状态
                Int64 seconds = -1;//时间秒数
                int length = -1;//包长

                length = BitConverter.ToInt32(bytes, 8);//包长
                if (length + 12 == bytes.Length)
                {
                    laneId = BitConverter.ToInt32(bytes, 16);
                    laneState = BitConverter.ToInt32(bytes, 20);
                    seconds = BitConverter.ToInt64(bytes, 24);
                    LaneId = laneId;
                    LaneState = laneState; 
                    CurrentTimer = dTime;
                    OnDataChanged(this, new DataChangeEventArgs(GetType().Name));
                }
            }
            catch (System.Exception ex)
            {
                int i = 0;
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

        protected DateTime GetLocalTime(int second)
        {
            return new DateTime(1970, 1, 1, 0, 0, 0).AddSeconds(second).ToLocalTime();
        }
    }
}
