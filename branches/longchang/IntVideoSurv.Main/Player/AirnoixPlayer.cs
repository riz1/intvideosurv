using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace CameraViewer.Player
{
    public enum AirnoixPlayerState
    {
        PLAY_STATE_NONE		=-1	,//无文件打开
        PLAY_STATE_STOP		=0	,//停止播放
        PLAY_STATE_PAUSE	=1	,//暂停播放
        PLAY_STATE_PLAY		=2	,//正在播放
        PLAY_STATE_FAST		=3	,//快速播放
        PLAY_STATE_SLOW		=4	,//慢速播放
        PLAY_STATE_LOAD		=10, //正在打开文件
        PLAY_STATE_OPEN		=11,//文件打开完毕，可以开始播放了
        PLAY_STATE_CLOSE	=12,//关闭文件
        PLAY_STATE_FILEEND=13,//文件播放完毕
        PLAY_STATE_ERROR	=24//有错误发生
    }


    public class AirnoixPlayer
    {
        private const string DllName = "Avdecoder.dll";

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr Avdec_Init(IntPtr hWnd, uint dwFlags, uint dwDisFmt, uint dwSoundFmt);
        
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Avdec_Play(IntPtr p);


        /// Return Type: int
        ///p: IntPtr->void*
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Avdec_Replay(IntPtr p);


        /// Return Type: int
        ///p: IntPtr->void*
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Avdec_Stop(IntPtr p);

        /// Return Type: int
        ///p: IntPtr->void*
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Avdec_Pause(IntPtr p);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Avdec_SetFile(IntPtr p, string lpFileName,string lpAudioFile,  bool bPlay);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Avdec_Forward(IntPtr p, uint dwOffset);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Avdec_Backward(IntPtr p, uint dwOffset);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Avdec_GetImageWidth(IntPtr p);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Avdec_GetImageHeight(IntPtr p);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Avdec_GetTotalFrames(IntPtr p);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Avdec_GetCurrentPosition(IntPtr p);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Avdec_CapturePicture(IntPtr p, string lpFileName, string lpPicFormat);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern float Avdec_GetTotalTime(IntPtr p);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern float Avdec_GetCurrentTime(IntPtr p);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Avdec_SetCurrentTime(IntPtr p, float dwTime);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Avdec_SetCurrentPosition(IntPtr p, int lPosition);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Avdec_StepFrame(IntPtr p, bool bForward);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern AirnoixPlayerState Avdec_GetCurrentState(IntPtr p);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Avdec_Done(IntPtr p);
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Avdec_Jump(IntPtr p,int offset);
    }
}
