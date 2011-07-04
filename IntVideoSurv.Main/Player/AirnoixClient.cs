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

    public class  AironixErrorCode
    {
        public static uint ERROR_CODE_NOERROR = 0x00000000;
        public static uint ERROR_CODE_PLAYBUFFER = 0x00000030;
        public static uint ERROR_CODE_STOPBUFFER = 0x00000031;
        public static uint ERROR_CODE_OPENBUFFER = 0x00000032;
        public static uint ERROR_CODE_RECVBUFFER = 0x00000033;
        public static uint ERROR_CODE_ENCFMTCHANGE = 0x00000040;
        public static uint ERROR_CODE_HANDLE = (0xC0000010);
        public static uint ERROR_CODE_INVALID_HANDLE = 0xc0000010;
        public static uint ERROR_CODE_PARAM = 0xC0000011;
        public static uint ERROR_CODE_CREATETHREAD = 0xC0000012;
        public static uint ERROR_CODE_CREATESOCKET = 0xC0000013;
        public static uint ERROR_CODE_OUTMEMORY = 0xC0000014;
        public static uint ERROR_CODE_MORECHANNEL = 0xC0000015;
        public static uint ERROR_CODE_CHANNELMAGIC_MISMATCH = 0xc0000016;
        public static uint ERROR_CODE_CALLBACK_REGISTERED = 0xc0000017;
        public static uint ERROR_CODE_QUEUE_OVERFLOW = 0xc0000018;
        public static uint ERROR_CODE_STREAM_THREAD_FAILURE = 0xc0000019;
        public static uint ERROR_CODE_THREAD_STOP_ERROR = 0xc000001A;
        public static uint ERROR_CODE_NOT_SUPPORT = 0xc000001B;
        public static uint ERROR_CODE_WAIT_TIMEOUT = 0xc000001C;
        public static uint ERROR_CODE_INVALID_ARGUMENT = 0xc000001D;
        public static uint ERROR_CODE_INVALID_uintERFACE = 0xc000001E;
        public static uint ERROR_CODE_BEGINCONNECT = 0xC0001000;
        public static uint ERROR_CODE_CONNECTSUCCESS = 0xC0001001;
        public static uint ERROR_CODE_NETWORK = 0xC0001002;
        public static uint ERROR_CODE_CONNECTERROR = 0xC0001003;
        public static uint ERROR_CODE_CONNECTERROR_1000 = 0xC0001004;
        public static uint ERROR_CODE_SERVERSTOP = 0xC0001005;
        public static uint ERROR_CODE_SERVERSTOP_1000 = 0xC0001006;
        public static uint ERROR_CODE_TIMEOUT = 0xC0001007;
        public static uint ERROR_CODE_TIMEOUT_1000 = 0xC0001008;
        public static uint ERROR_CODE_SENDDATA = 0xC0001009;
        public static uint ERROR_CODE_SENDDATA_1000 = 0xC000100A;
        public static uint ERROR_CODE_RECVDATA = 0xC000100B;
        public static uint ERROR_CODE_RECVDATA_1000 = 0xC000100C;
        public static uint ERROR_CODE_CLOSECONNECT = 0xC0010000;
        public static uint ERROR_CODE_SERVERNOSTART = 0xC0010001;
        public static uint ERROR_CODE_SERVERERROR = 0xC0010002;
        public static uint ERROR_CODE_CHANNELLIMIT = 0xC0010003;
        public static uint ERROR_CODE_SERVERLIMIT = 0xC0010004;
        public static uint ERROR_CODE_SERVERREFUSE = 0xC0010005;
        public static uint ERROR_CODE_IPLIMIT = 0xC0010006;
        public static uint ERROR_CODE_PORTLIMIT = 0xC0010007;
        public static uint ERROR_CODE_TYPEERROR = 0xC0010008;
        public static uint ERROR_CODE_USERERROR = 0xC0010009;
        public static uint ERROR_CODE_PASSWORDERROR = 0xC001000A;
        public static uint ERROR_CODE_DONTTURN = 0xC001000B;
        public static uint ERROR_CODE_VERSION = 0xC0100000;
        public static uint WM_ERRORMESSAGE = 432;
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

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int MP4_ClientSetReConnectNum(IntPtr hClient, int iNum);
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int MP4_ClientSetAutoConnect(IntPtr hClient, bool bTrue);
    }
}
