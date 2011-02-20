using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DigitMatrix.Interfce;
using DigtiMatrix.Entity;
using System.Drawing;

namespace DigitMatrix.Business
{
    public class VideoOutputDriver : IVideoOutput
    {

        #region IVideoOutput 成员

        VideoOutputInfo _VideoOutputInfo = null;
        int _TotalChannels = 0;
        IntPtr ChannelHandle;
        public int Init(int VideoStandard)
        {
            VideoStandard_t vs = (VideoStandard_t)VideoStandard;
            int iRtn = HKDS4000.SetDefaultVideoStandard(vs);//
            iRtn = HKDS4000.InitDSPs();
            if (iRtn < 0)
            {
                return iRtn;
            }
            _TotalChannels = HKDS4000.GetTotalDSPs();
            return _TotalChannels;
        }

        public int TotalChannels
        {
            get { return _TotalChannels; }
        }

        public int StartVideoPreview(DigtiMatrix.Entity.VideoOutputInfo oVideoOutputInfo)
        {
            int iRtn = -1;
            try
            {
                 
                _VideoOutputInfo = oVideoOutputInfo;
                ChannelHandle = HKDS4000.ChannelOpen(_VideoOutputInfo.OutputPort);
                //设置编码帧结构、帧率ITPUB个人空间 q Z4y3v/Y
                HKDS4000.SetIBPMode(ChannelHandle, 100, 2, 1, 25);
                //设置编码图像质量ITPUB个人空间!`mW a\5u
                HKDS4000.SetDefaultQuant(ChannelHandle, 15, 15, 20);
                Rectangle rect = _VideoOutputInfo.VideoPlayPanel.ClientRectangle;
                iRtn = HKDS4000.StartVideoPreview(ChannelHandle, _VideoOutputInfo.VideoPlayPanel.Handle, ref rect, false, (int)TypeVideoFormat.vdfRGB16, 25);
                return iRtn;
            }
            catch (Exception ex)
            {
                return -1;
            }

        }

        public int StopVideoPreview()
        {
           return HKDS4000.StopVideoPreview(ChannelHandle);
 
        }

        public int ChangeChannel(DigtiMatrix.Entity.VideoOutputInfo oVideoOutputInfo)
        {
            throw new NotImplementedException();
        }

        public int Close()
        {
            int iRtn = -1;
            try
            {
                iRtn = HKDS4000.StopVideoPreview(ChannelHandle);
                iRtn = HKDS4000.ChannelClose(ChannelHandle);
            }
            catch (Exception ex)
            {
                iRtn = -1;
            }
            return iRtn;
           
        }
        public int UnInit()
        {
           return HKDS4000.DeInitDSPs();

        }

        #endregion

         
    }
}
