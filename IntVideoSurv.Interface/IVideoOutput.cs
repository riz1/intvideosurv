using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IntVideoSurv.Entity;

namespace DigitMatrix.Interfce
{
    public interface IVideoOutput
    {

        int Init(int VideoStandard);
        int TotalChannels { get; }
        int StartVideoPreview(VideoOutputInfo oVideoOutputInfo);
        int StopVideoPreview();
        int ChangeChannel(VideoOutputInfo oVideoOutputInfo);
        int Close();

    }
}
