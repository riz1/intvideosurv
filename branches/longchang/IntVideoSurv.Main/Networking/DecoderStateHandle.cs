using System;

namespace CameraViewer.NetWorking
{
    public class DecoderStateHandle : IPacketHandler
    {
        public DecoderStateHandle()
        {
        }

        public event MainForm.ImageDataChangeHandle DataChange;

        public int LaneId { get; private set; }
        public int LaneState { get; private set; }
        public DateTime CurrentTimer { get; private set; }
        #region IPacketHandler Members

        public bool CanHandle(byte[] bytes)
        {
            return BitConverter.ToInt32(bytes, 0) == 6;
        }

        public void Handle(byte[] bytes)
        {
            try
            {
                ;                
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
