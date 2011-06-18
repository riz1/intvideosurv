using System;
using System.Runtime.InteropServices;

namespace CameraViewer.Player
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct tagRECT
    {
        /// LONG->int
        public int left;
        /// LONG->int
        public int top;
        /// LONG->int
        public int right;
        /// LONG->int
        public int bottom;
    }


    public static class AirnoixClient
    {

        private const string DllName = "BK_NetClientSDK.dll";


        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int StreamReadCallback(IntPtr hClient, IntPtr context);

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void MessageCallback(IntPtr hClient, uint dwCode, IntPtr context);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr MP4_ClientInit(IntPtr hWnd, uint dwFlags, uint dwDisplayFmt, uint dwAudioFmt);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int MP4_ClientUInit(IntPtr hClient);


        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int MP4_ClientRegisterStreamMessage(IntPtr hClient, IntPtr hWnd, uint msgId);


        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void MP4_ClientSetDisPlayPos(IntPtr hClient, ref tagRECT lpRect);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int MP4_ClientSetWaitTime(IntPtr hClient, float fTime);


        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int MP4_ClientSetConnectUser(
            IntPtr hClient,
            [In()]
            [MarshalAs(UnmanagedType.LPStr)]
            string lpUser,
            [In()]
            [MarshalAs(UnmanagedType.LPStr)] 
            string lpPass);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int MP4_ClientConnectEx(
            IntPtr hClient,
            [In()] 
            [MarshalAs(UnmanagedType.LPStr)]
            string lpIp,
            uint dwPort,
            uint dwChannel,
            uint dwStream,
            uint dwType);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int MP4_ClientDisConnect(IntPtr hClient);


        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int MP4_ClientReadStreamData(
            IntPtr hClient,
            byte[] buf,
            int iLen,
            ref int iFrameType);



        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int MP4_ClientRegisterStreamCallBack(
            IntPtr hClient,
            StreamReadCallback pCallBack,
            IntPtr context);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int MP4_ClientRegisterErrorCallBack(
            IntPtr hClient,
            MessageCallback pCallBack,
            IntPtr context);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int MP4_ClientSetBufferTime(IntPtr hClient, uint dwTime);


        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int MP4_ClientStartCapture(IntPtr hClient);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int MP4_ClientStopCapture(IntPtr hClient);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int MP4_ClientCapturePicturefile(
            IntPtr hClient,
            [InAttribute()]
            [MarshalAsAttribute(UnmanagedType.LPStr)]
            string pFileName);
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int MP4_ClientSetErrorMessage(IntPtr hClient,IntPtr hwnd,int msg);

    }
}
