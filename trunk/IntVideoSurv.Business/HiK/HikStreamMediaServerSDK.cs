using System.Runtime.InteropServices;

namespace IntVideoSurv.Business.HiK
{

    [UnmanagedFunctionPointerAttribute(CallingConvention.Cdecl)]
    public delegate int CbfNotifyANewConnection([MarshalAsAttribute(UnmanagedType.I1)] bool badd, [System.Runtime.InteropServices.InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string clientip, ushort port, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string url);

    public class HikStreamMediaServerSDK
    {
        /// <summary>
        /// 作用：初始化。该函数需要在窗口程序初始化时调用
        /// </summary>
        /// <returns>返回值：成功返回 0，失败返回-1</returns>
        [DllImport("server.dll")]
        public static extern int InitStreamServerLib();
        /// <summary>
        /// 反初始化。该函数需要在窗口程序关闭时时调用
        /// </summary>
        /// <returns>成功返回 0，失败返回-1</returns>
        [DllImport("server.dll")]
        public static extern int FiniStreamServerLib();
        /// <summary>
        /// 初始化服务端。port 是指服务器的侦听端口号，默认值是556
        /// </summary>
        /// <param name="port"></param>
        /// <returns>返回值：成功返回 0，失败返回-1</returns>
        [DllImport("server.dll")]
        public static extern int StartServer(string path, ushort port);
        /// <summary>
        /// 停止服务端，释放资源
        /// </summary>
        /// <returns>成功返回 0，失败返回-1</returns>
        [DllImport("server.dll")]
        public static extern int StopServer();

        [DllImport("server.dll")]
        public static extern int RunServer();
        /// <summary>
        /// 获取当前连接的客户端数目
        /// </summary>
        /// <returns>返回值： 当前连接的客户端数目</returns>
        [DllImport("server.dll")]
        public static extern int GetCurConnection();

        [DllImport("server.dll")]
        public static extern int SetNewConnectionCallBack(CbfNotifyANewConnection callback);


    }
}
