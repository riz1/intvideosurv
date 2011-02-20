using System;
using System.Runtime.InteropServices;
using System.Drawing;

namespace HCVideoService
{
	#region Struct
	/// <summary>
	/// typedef struct{
	///		long nWidth;	//画面宽，单位像素。如果是音频数据则为 0；
	///		long nHeight;	//画面高。如果是音频数据则为 0；
	///		long nStamp;	//时标信息，单位毫秒。
	///		long nType;		//数据类型，T_AUDIO16，T_RGB32， T_YV12，详见宏定义说明。
	///		long nFrameRate;//编码时产生的图像帧率。
	/// }FRAME_INFO; 
	/// </summary>
	public struct FRAME_INFO
	{
		/// <summary>
		/// 画面宽，单位像素。如果是音频数据则为0
		/// long nWidth;
		/// </summary>
		public int nWidth;
		/// <summary>
		/// 画面高。如果是音频数据则为0
		/// long nHeight;
		/// </summary>
		public int nHeight;
		/// <summary>
		/// 时标信息，单位毫秒
		/// long nStamp;
		/// </summary>
		public int nStamp;
		/// <summary>
		/// 数据类型，T_AUDIO16，T_RGB32， T_YV12
		/// long nType;
		/// </summary>
		public int nType;
		/// <summary>
		/// 编码时产生的图像帧率
		/// long nFrameRate;
		/// </summary>
		public int nFrameRate;
	}

	/// <summary>
	/// typedef struct{
	///		long nFilePos;	//文件位置；
	///		long nFrameNum;	//帧序号；
	///		long nFrameTime;//帧时标（ms）;
	/// }FRAME_POS,*PFRAME_POS; 
	/// </summary>
	public struct PFRAME_POS
	{
		/// <summary>
		/// 出错的文件位置 
		/// long nFilePos;
		/// </summary>
		public int nFilePos;
		/// <summary>
		/// 出错后正常的帧号
		/// long nFrameNum;
		/// </summary>
		public int nFrameNum;
		/// <summary>
		/// 出错后正常的时间（相对此文件开始时间）
		/// long nFrameTime;
		/// </summary>
		public int nFrameTime;
		/// <summary>
		/// 出错时的帧号
		/// long nErrorFrameNum;
		/// </summary>
		public int nErrorFrameNum;
		/// <summary>
		/// 出错的绝对时间（设备录象文件有用）
		/// SYSTEMTIME *pErrorTime;
		/// </summary>
		public DateTime pErrorTime;
		/// <summary>
		/// 出错时丢失的帧数
		/// long nErrorLostFrameNum;
		/// </summary>
		public int nErrorLostFrameNum;
		/// <summary>
		///  出错时错误的数据大小
		/// long nErrorFrameSize;
		/// </summary>
		public int nErrorFrameSize;
	}

	/// <summary>
	/// typedef struct{
	///		char *pDataBuf;	//数据帧首地址
	///		long nSize;		//数据帧的大小
	///		long nFrameNum;	//数据帧的个数
	///		BOOL bIsAudio;	//是否音频帧
	///		long nReserved;	//保留
	/// }FRAME_TYPE; 
	/// </summary>
	public struct FRAME_TYPE
	{
		/// <summary>
		/// 数据帧首地址
		/// char *pDataBuf;
		/// </summary>
		public byte[] pDataBuf;
		/// <summary>
		/// 数据帧的大小
		/// long nSize;
		/// </summary>
		public int nSize;
		/// <summary>
		/// 数据帧的个数
		/// long nFrameNum;
		/// </summary>
		public int nFrameNum;
		/// <summary>
		/// 是否音频帧
		/// BOOL bIsAudio;
		/// </summary>
		public bool bIsAudio;
		/// <summary>
		/// 保留
		/// long nReserved;
		/// </summary>
		public int nReserved;
	}
    #endregion

	#region Delegate
	///////////////////////////////////////////////////////////////////////////////////////////////
	//注意：关于回调函数。因为vb不支持多线程，所以当回调函数是VB声明的函数时，在vc的线程中调用vb的函数，会有问题。
	//		详见：Microsoft Knowledge Base Article - Q198607 “PRB: Access Violation in VB Run-Time Using AddressOf ”。 
	///////////////////////////////////////////////////////////////////////////////////////////////

	/// <summary>
	/// void (CALLBACK* DecCBFun)(long nPort,char * pBuf,long nSize,FRAME_INFO * pFrameInfo, long nReserved1,long nReserved2)
	/// 回调函数指针。不能为 NULL; 
	/// </summary>
	/// <param name="nPort">播放器通道号</param>
	/// <param name="pBuf">解码后的音视频数据</param>
	/// <param name="nSize">解码后的音视频数据pBuf的长度</param>
	/// <param name="pFrameInfo">图像和声音信息</param>
	/// <param name="nReserved1">保留参数</param>
	/// <param name="nReserved2">保留参数</param>
	public delegate void DecCBFun(int nPort, IntPtr pBuf, int nSize, ref FRAME_INFO pFrameInfo, int nReserved1, int nReserved2);

	/// <summary>
	/// void (CALLBACK* DisplayCBFun)(long nPort,char * pBuf,long nSize,long nWidth,long nHeight,long nStamp,long nType,long nReceaved)); 
	/// 抓图回调函数。可以为 NULL; 
	/// </summary>
	/// <param name="nPort">通道号</param>
	/// <param name="pBuf">返回图像数据</param>
	/// <param name="nSize">返回图像数据大小</param>
	/// <param name="nWidth">画面宽，单位像素</param>
	/// <param name="nHeight">画面高</param>
	/// <param name="nStamp">时标信息，单位毫秒</param>
	/// <param name="nType">数据类型，T_YV12，T_RGB32，T_UYVY</param>
	/// <param name="nReceaved">保留</param>
	public delegate void DisplayCBFun(int nPort, IntPtr pBuf, int nSize, int nWidth, int nHeight, int nStamp, int nType, int nReceaved);

	/// <summary>
	/// void CALLBACK SourceBufCallBack(long nPort,DWORD nBufSize, DWORD dwUser,void*pContext) 
	/// </summary>
	/// <param name="nPort">播放器通道号</param>
	/// <param name="nBufSize">缓冲区中剩余数据</param>
	/// <param name="dwUser">用户数据</param>
	/// <param name="pContext">保留数据</param>
	public delegate void SourceBufCallBack(int nPort, ushort nBufSize, ushort dwUser, IntPtr pContext);

	/// <summary>
	/// void FileRefDone(DWORD nPort,DWORD nUser) 
	/// </summary>
	/// <param name="nPort">播放器通道号</param>
	/// <param name="nUser">用户数据</param>
	public delegate void FileRefDone(int nPort, ushort nUser);

	/// <summary>
	/// void CALLBACK DrawFun(long nPort,HDC hDc,LONG nUser)； 
	/// </summary>
	/// <param name="nPort">通道号</param>
	/// <param name="hDc">hDc OffScreen表面设备上下文，你可以像操作显示窗口客户区DC那样操作它。</param>
	/// <param name="nUser">用户数据，就是上面输入的用户数据</param>
	public delegate void DrawFun(int nPort, IntPtr hDc, int nUser);

	/// <summary>
	/// void __stdcall Verify(long nPort, FRAME_POS * pFilePos, DWORD bIsVideo, DWORD nUser)
	/// </summary>
	/// <param name="nPort">通道号</param>
	/// <param name="pFilePos">文件位置</param>
	/// <param name="bIsVideo">是否视频数据，1视频，0音频</param>
	/// <param name="nUser">用户数据</param>
	public delegate void Verify(int nPort, ref PFRAME_POS pFilePos, ushort bIsVideo, ushort nUser);

	/// <summary>
	/// void __stdcall  Audio(long nPort, char * pAudioBuf, long nSize, long nStamp, long nType, long nUser) 
	/// </summary>
	/// <param name="nPort">通道号</param>
	/// <param name="pAudioBuf">wave格式音频数据</param>
	/// <param name="nSize">音频数据长度</param>
	/// <param name="nStamp"> 时标(ms) </param>
	/// <param name="nType">音频类型T_AUDIO16, 采样率16khz，单声道，每个采样点16位表示 </param>
	/// <param name="nUser">用户自定义数据</param>
	public delegate void Audio(int nPort, string pAudioBuf, int nSize, int nStamp, int nType, int nUser);

	/// <summary>
	/// void (CALLBACK *funEncChange)(long nPort,long nUser) 
	/// </summary>
	/// <param name="nPort">通道号</param>
	/// <param name="nUser">用户自定义数据</param>
	public delegate void EncChange(int nPort, int nUser);

	/// <summary>
	/// void(CALLBACK *funGetOrignalFrame)(long nPort,FRAME_TYPE *frameType, long nUser) 
	/// </summary>
	/// <param name="nPort">通道号</param>
	/// <param name="frameType">有关数据帧的信息</param>
	/// <param name="nUser"></param>
	public delegate void GetOrignalFrame(int nPort, ref FRAME_TYPE frameType, int nUser);
	#endregion

	/// <summary>
	/// 播放器
	/// </summary>
	public sealed class HikPlayer
    {
        #region Const Member Variables
        // #define WINVER 
        // 0x0700 Windows 7
        // 0x0600 Windows Vista
        // 0x0502 Windows 2003 Server
        // 0x0410 Windows XP
        //<0x0400 Windows 98/Windows 2000
        public static readonly int WINVER = 0x0502;

		public static readonly uint WM_USER = 0x0400;
		public static readonly uint WM_FILE_END = WM_USER + 33;
		public static readonly uint WM_ENC_CHANGE = WM_USER + 100;
		
        public static readonly int COLOR_DEFAULT = 64;
        public static readonly int PLAYER_SLIDER_MAX = 200;
        public static readonly int MAX_DISPLAY_DEVICE = 4;

        public static readonly int WIDTH_PAL = 352;
        public static readonly int HEIGHT_PAL = 288;

		#region Source buffer
		//#define SOURCE_BUF_MAX
		public static readonly uint SOURCE_BUF_MAX = 1024 * 100000;
		//#define SOURCE_BUF_MIN    1024*50
		public static readonly uint SOURCE_BUF_MIN = 1024 * 50;
		#endregion

		#region Frame type
		/// <summary>
		/// 音频数据;采样率16khz，单声道，每个采样点16位表示。
		/// </summary>
		public static readonly int T_AUDIO16 = 101;
		public static readonly int T_AUDIO8 = 100;

		/// <summary>
		/// 视频数据，uyvy格式。“U0-Y0-V0-Y1-U2-Y2-V2-Y3….”，第一个像素位于图像左上角。 
		/// </summary>
		public static readonly int T_UYVY = 1;
		/// <summary>
		/// 视频数据，yv12格式。排列顺序“Y0-Y1-……”，“V0-V1….”，“U0-U1-…..”。 
		/// </summary>
		public static readonly int T_YV12 = 3;
		/// <summary>
		/// 视频数据。每个像素4个字节，排列方式与位图相似，“B-G-R-0 ……”，第一个像素位于图像左下角。 
		/// </summary>
		public static readonly int T_RGB32 = 7;
		#endregion

		#region Stream type
		/// <summary>
		/// 实时模式，适合播放网络实时数据，解码器会立刻解码。
		/// </summary>
		public static readonly int STREAME_REALTIME = 0;
		/// <summary>
		/// 文件模式，适合用户把文件数据用流方式输入。
		/// 注意：当PlayM4_InputData()返回FALSE时，用户要等一下重新输入。
		/// </summary>
		public static readonly int STREAME_FILE = 1;
		#endregion

		#region Error code
		/// <summary>
		/// 没有错误
		/// no error
		/// </summary>
		public static readonly int PlayM4_NOERROR = 0;
		/// <summary>
		/// 输入参数非法
		/// input parameter is invalid;
		/// </summary>
		public static readonly int PlayM4_PARA_OVER = 1;
		/// <summary>
		/// 调用顺序不对
		/// The order of the function to be called is error.
		/// </summary>
		public static readonly int PlayM4_ORDER_ERROR = 2;
		/// <summary>
		/// 多媒体时钟设置失败
		/// Create multimedia clock failed;
		/// </summary>
		public static readonly int PlayM4_TIMER_ERROR = 3;
		/// <summary>
		/// 视频解码失败
		/// Decode video data failed.
		/// </summary>
		public static readonly int PlayM4_DEC_VIDEO_ERROR = 4;
		/// <summary>
		/// 音频解码失败
		/// Decode audio data failed.
		/// </summary>
		public static readonly int PlayM4_DEC_AUDIO_ERROR = 5;
		/// <summary>
		/// 分配内存失败
		/// Allocate memory failed.
		/// </summary>
		public static readonly int PlayM4_ALLOC_MEMORY_ERROR = 6;
		/// <summary>
		/// 文件操作失败
		/// Open the file failed.
		/// </summary>
		public static readonly int PlayM4_OPEN_FILE_ERROR = 7;
		/// <summary>
		/// 创建线程事件等失败
		/// Create thread or event failed.
		/// </summary>
		public static readonly int PlayM4_CREATE_OBJ_ERROR = 8;
		/// <summary>
		/// 创建DirectDraw失败
		/// Create DirectDraw object failed.
		/// </summary>
		public static readonly int PlayM4_CREATE_DDRAW_ERROR = 9;
		/// <summary>
		/// 创建后端缓存失败
		/// Failed when creating off-screen surface.
		/// </summary>
		public static readonly int PlayM4_CREATE_OFFSCREEN_ERROR = 10;
		/// <summary>
		/// 缓冲区满，输入流失败
		/// Buffer is overflow.
		/// </summary>
		public static readonly int PlayM4_BUF_OVER = 11;
		/// <summary>
		/// 创建音频设备失败
		/// Failed when creating audio device.
		/// </summary>
		public static readonly int PlayM4_CREATE_SOUND_ERROR = 12;
		/// <summary>
		/// 设置音量失败
		/// Set volume failed.
		/// </summary>
		public static readonly int PlayM4_SET_VOLUME_ERROR = 13;
		/// <summary>
		/// 只能在播放文件时才能使用此接口
		/// The function only support play file.
		/// </summary>
		public static readonly int PlayM4_SUPPORT_FILE_ONLY = 14;
		/// <summary>
		/// 只能在播放流时才能使用此接口
		/// The function only support play stream.
		/// </summary>
		public static readonly int PlayM4_SUPPORT_STREAM_ONLY = 15;
		/// <summary>
		/// 系统不支持，解码器只能工作在Pentium 3以上
		/// System not support.
		/// </summary>
		public static readonly int PlayM4_SYS_NOT_SUPPORT = 16;
		/// <summary>
		/// 没有文件头
		/// No file header.
		/// </summary>
		public static readonly int PlayM4_FILEHEADER_UNKNOWN = 17;
		/// <summary>
		/// 解码器和编码器版本不对应
		/// The version of decoder and encoder is not adapted.  
		/// </summary>
		public static readonly int PlayM4_VERSION_INCORRECT = 18;
		/// <summary>
		/// 初始化解码器失败
		/// Initialize decoder failed.
		/// </summary>
		public static readonly int HIK_PALYM4_INIT_DECODER_ERROR = 19;
		/// <summary>
		/// 文件太短或码流无法识别
		/// The file data is unknown.
		/// </summary>
		public static readonly int PlayM4_CHECK_FILE_ERROR = 20;
		/// <summary>
		/// 初始化多媒体时钟失败
		/// Initialize multimedia clock failed.
		/// </summary>
		public static readonly int PlayM4_INIT_TIMER_ERROR = 21;
		/// <summary>
		/// 位拷贝失败
		/// Blt failed.
		/// </summary>
		public static readonly int PlayM4_BLT_ERROR = 22;
		/// <summary>
		/// 显示Overlay失败
		/// Update failed.
		/// </summary>
		public static readonly int PlayM4_UPDATE_ERROR = 23;
		/// <summary>
		/// 打开文件错误
		/// Open file error, stream type is multi.
		/// </summary>
		public static readonly int PlayM4_OPEN_FILE_ERROR_MULTI = 24;
		/// <summary>
		/// 打开文件错误
		/// Open file error, stream type is video.
		/// </summary>
		public static readonly int PlayM4_OPEN_FILE_ERROR_VIDEO = 25;
		/// <summary>
		/// JPEG格式压缩错误
		/// JPEG compress error.
		/// </summary>
		public static readonly int PlayM4_JPEG_COMPRESS_ERROR = 26;
		/// <summary>
		/// 不支持此文件的版本
		/// Don't support the version of this file.
		/// </summary>
		public static readonly int PlayM4_EXTRACT_NOT_SUPPORT = 27;
		/// <summary>
		/// 提取视频数据失败
		/// Extract video data failed.
		/// </summary>
		public static readonly int PlayM4_EXTRACT_DATA_ERROR = 28;

		#endregion

		#region Display buffers
		/// <summary>
		/// 播放缓冲最大值
		/// </summary>
		public static readonly int MAX_DIS_FRAMES = 50;
		/// <summary>
		/// 播放缓冲最小值
		/// </summary>
		public static readonly int MIN_DIS_FRAMES = 6;
		#endregion

		#region Locate by
		/// <summary>
		/// 帧号
		/// </summary>
		public static readonly int BY_FRAMENUM = 1;
		/// <summary>
		/// 时间
		/// </summary>
		public static readonly int BY_FRAMETIME = 2;
		#endregion

		#region Display type
		/// <summary>
		/// 正常分辨率数据送显卡显示。
		/// </summary>
		public static readonly int DISPLAY_NORMAL = 1;
		/// <summary>
		/// 1/4分辨率数据送显卡显示。
		/// </summary>
		public static readonly int DISPLAY_QUARTER = 2;
		#endregion

		#region Timer type
		/// <summary>
		/// 一个进程中只能使用16个，定时比较准，画面流畅。
		/// Only 16 timers for every process.Default TIMER;
		/// </summary>
		public static readonly int TIMER_1 = 1;
		/// <summary>
		/// 使用数目没有限制，定时没有TIMER_1准。
		/// Not limit;But the precision less than TIMER_1; 
		/// </summary>
		public static readonly int TIMER_2 = 2;
		#endregion

		#region BUFFER TYPE
		/// <summary>
		/// 视频数据源缓冲区，缓冲解码之前视频数据，只对流模式有效，单位byte。
		/// </summary>
		public static readonly ushort BUF_VIDEO_SRC = 1;
		/// <summary>
		/// 音频数据源缓冲区，缓冲解码之前音频数据，只对流模式有效, 单位byte。 
		/// </summary>
        public static readonly ushort BUF_AUDIO_SRC = 2;
		/// <summary>
		/// 解码后视频数据缓冲区，单位帧数。 
		/// </summary>
        public static readonly ushort BUF_VIDEO_RENDER = 3;
		/// <summary>
		/// 解码后音频数据缓冲区，单位帧数，音频40ms数据定为一帧。 
		/// </summary>
        public static readonly ushort BUF_AUDIO_RENDER = 4;
		#endregion

		#endregion

		#region HikPlayer

        [DllImport("PlayCtrl.dll")]
        public static extern bool PlayM4_FreePort(int Port);

        [DllImport("PlayCtrl.dll")]
        public static extern bool PlayM4_GetPort(ref int Port);	
        
        /// <summary>
		/// 1、 BOOL PlayM4_InitDDraw(HWND hWnd);
		/// 初始化DirectDraw表面。在使用vb,delphi开发时请注意，它们生成的对话框具有WS_CLIPCHILDREN
		/// 窗口风格，必须去掉这种风格，否则显示画面会被对话框上的控件覆盖。注意：1.1版以上不需要调用。
		/// </summary>
		/// <param name="hWnd">hWnd 应用程序主窗口的句柄。</param>
		/// <returns></returns>
		[DllImport("PlayCtrl.dll")]
		public static extern bool PlayM4_InitDDraw(IntPtr hWnd);

		/// <summary>
		/// 2、 BOOL PlayM4_RealeseDDraw(); 
		/// 释放directDraw表面；注意：1.1版以上不需要调用。
		/// </summary>
		/// <returns></returns>
		[DllImport("PlayCtrl.dll")]
		public static extern bool PlayM4_RealeseDDraw();

		/// <summary>
		/// 3、 BOOL PlayM4_OpenFile(LONG nPort,LPSTR sFileName); 
		/// 打开播放文件
		/// </summary>
		/// <param name="nPort"></param>
		/// <param name="sFileName">文件名，文件不能超过4G或小于4K</param>
		/// <returns></returns>
		[DllImport("PlayCtrl.dll")]
		public static extern bool PlayM4_OpenFile(int nPort, string sFileName);

		/// <summary>
		/// 4、 BOOL PlayM4_CloseFile(LONG nPort); 
		/// 关闭播放文件
		/// </summary>
		/// <param name="nPort"></param>
		/// <returns></returns>
		[DllImport("PlayCtrl.dll")]
		public static extern bool PlayM4_CloseFile(int nPort);

		/// <summary>
		/// 5、 BOOL PlayM4_Play(LONG nPort, HWND hWnd); 
		/// 播放开始，播放视频画面大小将根据hWnd窗口调整，要全屏显示，只要把hWnd窗口放大到全屏。
		/// 如果已经播放，只是改变当前播放速度为正常速度。 
		/// </summary>
		/// <param name="nPort"></param>
		/// <param name="hWnd">hWnd 播放视频的窗口句柄</param>
		/// <returns></returns>
		[DllImport("PlayCtrl.dll")]
		public static extern bool PlayM4_Play(int nPort, IntPtr hWnd);

		/// <summary>
		/// 6、 BOOL PlayM4_Stop(LONG nPort); 
		/// 播放结束
		/// </summary>
		/// <param name="nPort"></param>
		/// <returns></returns>
		[DllImport("PlayCtrl.dll")]
		public static extern bool PlayM4_Stop(int nPort);

		/// <summary>
		/// 7、 BOOL PlayM4_Pause(LONG nPort,DWORD nPause); 
		/// 播放暂停/恢复
		/// </summary>
		/// <param name="nPort"></param>
		/// <param name="nPause">nPause=TRUE暂停，否则恢复</param>
		/// <returns></returns>
		[DllImport("PlayCtrl.dll")]
		public static extern bool PlayM4_Pause(int nPort, bool nPause);

		/// <summary>
		/// 8、 BOOL PlayM4_Fast(LONG nPort); 
		/// 快速播放，每次调用将使当前播放速度加快一倍，最多调用4次；要恢复正常播放调用PlayM4_Play()，
		/// 从当前位置开始正常播放
		/// </summary>
		/// <param name="nPort"></param>
		/// <returns></returns>
		[DllImport("PlayCtrl.dll")]
		public static extern bool PlayM4_Fast(int nPort);

		/// <summary>
		/// 9、 BOOL PlayM4_Slow(LONG nPort); 
		/// 慢速播放，每次调用将使当前播放速度慢一倍；最多调用4次；要恢复正常播放调用PlayM4_Play()
		/// </summary>
		/// <param name="nPort"></param>
		/// <returns></returns>
		[DllImport("PlayCtrl.dll")]
		public static extern bool PlayM4_Slow(int nPort);

		/// <summary>
		/// 10、BOOL PlayM4_SetPlayPos(LONG nPort,float fRelativePos); 
		/// 设置文件播放指针的相对位置（百分比）。 
		/// </summary>
		/// <param name="nPort"></param>
		/// <param name="fRelativePos">范围0-100%</param>
		/// <returns></returns>
		[DllImport("PlayCtrl.dll")]
		public static extern bool PlayM4_SetPlayPos(int nPort, float fRelativePos);

		/// <summary>
		/// 11、float PlayM4_GetPlayPos(LONG nPort); 
		/// 获得文件播放指针的相对位置
		/// </summary>
		/// <param name="nPort">范围0-100%</param>
		/// <returns></returns>
		[DllImport("PlayCtrl.dll")]
		public static extern float PlayM4_GetPlayPos(int nPort);

		/// <summary>
		/// 12、BOOL PlayM4_SetFileEndMsg(LONG nPort,HWND hWnd,UINT nMsg); 
		/// 设置文件结束时要发送的消息；从2.4版开始，当文件播放完时，解码线程将不会自动结束，需要
		/// 用户做停止工作：应用程序在收到这个消息后要调用播放结束函数PlayM4_Stop(nPort)。 
		/// </summary>
		/// <param name="nPort"></param>
		/// <param name="hWnd">消息发送的窗口。 </param>
		/// <param name="nMsg">用户自定义的输入的消息；当播放到文件结束时用户从hWnd窗口过程中收到这个消息。此消息函数中的wParam参数返回nPort的值。</param>
		/// <returns></returns>
		[DllImport("PlayCtrl.dll")]
		public static extern bool PlayM4_SetFileEndMsg(int nPort, IntPtr hWnd, uint nMsg);

		/// <summary>
		/// 13、BOOL PlayM4_SetVolume(LONG nPort,WORD nVolume); 
		/// 设置音量；可以在播放之前设置，返回值是FALSE，但设置的值被保存，并作为启动声音时的初始
		/// </summary>
		/// <param name="nPort"></param>
		/// <param name="nVolume">音量的值，范围0-0XFFFF</param>
		/// <returns></returns>
		[DllImport("PlayCtrl.dll")]
		public static extern bool PlayM4_SetVolume(int nPort, int nVolume);

		/// <summary>
		/// 14、BOOL PlayM4_PlaySound(LONG nPort);
		/// 打开声音；同一时刻只能有一路声音。如果现在已经有声音打开，则自动关闭原来已经打开的声音。
		/// 注意：默认情况下声音是关闭的！ 
		/// </summary>
		/// <param name="nPort"></param>
		/// <returns></returns>
		[DllImport("PlayCtrl.dll")]
		public static extern bool PlayM4_PlaySound(int nPort);

		/// <summary>
		/// 15、BOOL PlayM4_StopSound(); 
		/// 关闭声音
		/// </summary>
		/// <returns></returns>
		[DllImport("PlayCtrl.dll")]
		public static extern bool PlayM4_StopSound();

		/// <summary>
		/// 16．BOOL  PlayM4_OpenStream(LONG nPort,PBYTE pFileHeadBuf,DWORD nSize,DWORD nBufPoolSize); 
		/// 打开流接口（类似打开文件）
		/// </summary>
		/// <param name="nPort"></param>
		/// <param name="pFileHeadBuf">用户从卡上得到的文件头数据。</param>
		/// <param name="nSize">文件头长度。</param>
		/// <param name="nBufPoolSize">设置播放器中存放数据流的缓冲区大小。范围是SOURCE_BUF_MIN~ SOURCE_BUF_MAX。 </param>
		/// <returns></returns>
		[DllImport("PlayCtrl.dll")]
//		public static extern bool PlayM4_OpenStream(int nPort, IntPtr pFileHeadBuf, ushort nSize, ushort nBufPoolSize);
        public static extern bool PlayM4_OpenStream(int nPort, ref byte[] pFileHeadBuf, uint nSize, uint nBufPoolSize);

		/// <summary>
		/// 17、BOOL PlayM4_InputData(LONG nPort,PBYTE pBuf,DWORD nSize); 
		/// 输入从卡上得到的流数据；打开流之后才能输入数据。
		/// </summary>
		/// <param name="nPort"></param>
		/// <param name="pBuf">缓冲区地址</param>
		/// <param name="nSize">缓冲区大小</param>
		/// <returns>TURE,表示已经输入数据。FALSE 表示失败，数据没有输入。</returns>
		[DllImport("PlayCtrl.dll")]
        public static extern bool PlayM4_InputData(int nPort, ref byte[] pBuf, uint nSize);

		/// <summary>
		/// 18、BOOL PlayM4_CloseStream(LONG nPort); 
		/// 关闭数据流
		/// </summary>
		/// <param name="nPort"></param>
		/// <returns></returns>
		[DllImport("PlayCtrl.dll")]
		public static extern bool PlayM4_CloseStream(int nPort);

		/// <summary>
		/// 19、int PlayM4_GetCaps(); 
		/// 测试播放器需要的一些系统功能 
		/// 注意：如果显卡支持上面列出的显示功能，将会大大降低CPU利用率。解码后的图像是352*288（PAL）大小，
		///      如果显卡不支持放大缩小，则建议显示窗口也使用352*288。 
		/// </summary>
		/// <returns>
		/// 1~8位分别表示以下信息（位与是TRUE表示支持）： 
		///    SUPPORT_DDRAW		支持DIRECTDRAW；如果不支持，则播放器不能工作。 
		///    SUPPORT_BLT			显卡支持BLT操作；如果不支持，则播放器不能工作。 
		///    SUPPORT_BLTFOURCC	显卡BLT支持颜色转换；如果不支持，播放器会使用软件方式作RGB转换。
		///    SUPPORT_BLTSHRINKX	显卡BLT支持X轴缩小；如果不支持，系统使用软件方式转换。
		///    SUPPORT_BLTSHRINKY	显卡BLT支持Y轴缩小；如果不支持，系统使用软件方式转换。 
		///    SUPPORT_BLTSTRETCHX	显卡BLT支持X轴放大；如果不支持，系统使用软件方式转换。
		///    SUPPORT_BLTSTRETCHY	显卡BLT支持Y轴放大；如果不支持，系统使用软件方式转换。 
		///    SUPPORT_SSE			CPU支持SSE指令,Intel Pentium3以上支持SSE指令。
		///    SUPPORT_MMX			CPU支持MMX指令集。 
		/// </returns>
		[DllImport("PlayCtrl.dll")]
		public static extern int PlayM4_GetCaps();

		/// <summary>
		/// 20、DWORD PlayM4_GetFileTime(LONG nPort); 
		/// 得到文件总的时间长度，单位秒
		/// </summary>
		/// <param name="nPort"></param>
		/// <returns></returns>
		[DllImport("PlayCtrl.dll")]
		public static extern int PlayM4_GetFileTime(int nPort);

		/// <summary>
		/// 21、DWORD PlayM4_GetPlayedTime(LONG nPort); 
		/// 得到文件当前播放的时间，单位秒
		/// </summary>
		/// <param name="nPort"></param>
		/// <returns></returns>
		[DllImport("PlayCtrl.dll")]
		public static extern ushort PlayM4_GetPlayedTime(int nPort);

		/// <summary>
		/// 22、DWORD PlayM4_GetPlayedFrames(LONG nPort); 
		/// 得到已经解码的视频帧数
		/// </summary>
		/// <param name="nPort"></param>
		/// <returns></returns>
		[DllImport("PlayCtrl.dll")]
		public static extern ushort PlayM4_GetPlayedFrames(int nPort);

		/// <summary>
		/// 23、BOOL PlayM4_OneByOne(LONG nPort); 
		/// 单帧播放。要恢复正常播放调用PlayM4_Play()
		/// </summary>
		/// <param name="nPort"></param>
		/// <returns></returns>
		[DllImport("PlayCtrl.dll")]
		public static extern bool PlayM4_OneByOne(int nPort);

		/// <summary>
		/// 24、BOOL PlayM4_SetDecCallBack(LONG nPort,void (CALLBACK* DecCBFun)(long nPort,char * pBuf,long nSize,FRAME_INFO * pFrameInfo, long nReserved1,long nReserved2)); 
		/// 设置回调函数，替换播放器中的显示部分，有用户自己控制显示，该函数在PlayM4_Play()之前调用，
		/// 在PlayM4_Stop()时自动失效，下次调用PlayM4_Play()之前需要重新设置。
		/// 注意解码部分不控制速度，只要用户从回调函数中返回，解码器就会解码下一部分数据。
		/// 这个功能的使用需要用户对视频显示和声音播放有足够的了解，否则请慎重使用，有关知识请参阅directx开发包。
		/// </summary>
		/// <param name="nPort"></param>
		/// <param name="dcbf">DecCBFun回调函数指针，不能为NULL</param>
		/// <returns></returns>
		[DllImport("PlayCtrl.dll")]
		public static extern bool PlayM4_SetDecCallBack(int nPort, DecCBFun dcbf);

		/// <summary>
		/// 25、BOOL PlayM4_SetDisplayCallBack(LONG nPort,void (CALLBACK* DisplayCBFun)(long nPort,char * pBuf,long nSize,long nWidth,long nHeight,long nStamp,long nType,long nReceaved)); 
		/// 设置抓图回调函数；注意要尽快返回，如果要停止回调，可以把回调函数指针DisplayCBFun设为NULL。
		/// 一旦设置回调函数，则一直有效，直到程序退出。该函数可以在任何时候调用。 
		/// </summary>
		/// <param name="nPort"></param>
		/// <param name="dcbf">DisplayCBFun抓图回调函数，可以为NULL。</param>
		/// <returns></returns>
		[DllImport("PlayCtrl.dll")]
		public static extern bool PlayM4_SetDisplayCallBack(int nPort, DisplayCBFun dcbf);

		/// <summary>
		/// 26、BOOL PlayM4_ConvertToBmpFile(char * pBuf,long nSize,long nWidth,long nHeight,long nType,char *sFileName);
		/// 将抓图得到的图像数据保存成BMP文件。转换函数占用的cpu资源，如果不需要保存图片，则不要调用
		/// </summary>
		/// <param name="pBuf">同抓图回调函数中的参数</param>
		/// <param name="nSize">同抓图回调函数中的参数</param>
		/// <param name="nWidth">同抓图回调函数中的参数</param>
		/// <param name="nHeight">同抓图回调函数中的参数</param>
		/// <param name="nType">同抓图回调函数中的参数</param>
		/// <param name="sFileName">要保存的文件名。最好以BMP作为文件扩展名。</param>
		/// <returns></returns>
		[DllImport("PlayCtrl.dll")]
		public static extern bool PlayM4_ConvertToBmpFile(IntPtr pBuf, int nSize, int nWidth, int nHeight, int nType, string sFileName);

		/// <summary>
		/// 27、DWORD PlayM4_GetFileTotalFrames(LONG nPort); 
		/// 得到文件中的总帧数。 
		/// </summary>
		/// <param name="nPort"></param>
		/// <returns>文件中的总帧数。 </returns>
		[DllImport("PlayCtrl.dll")]
		public static extern int PlayM4_GetFileTotalFrames(int nPort);

		/// <summary>
		/// 28、DWORD PlayM4_GetCurrentFrameRate(LONG nPort); 
		/// 得到当前码流中编码时的帧率。
		/// </summary>
		/// <param name="nPort"></param>
		/// <returns>当前码流中编码时的帧率。 </returns>
		[DllImport("PlayCtrl.dll")]
		public static extern ushort PlayM4_GetCurrentFrameRate(int nPort);

		/// <summary>
		/// 29、DWORD PlayM4_GetPlayedTimeEx(LONG nPort); 
		/// 得到文件当前播放的时间，单位毫秒
		/// </summary>
		/// <param name="nPort"></param>
		/// <returns></returns>
		[DllImport("PlayCtrl.dll")]
		public static extern ushort PlayM4_GetPlayedTimeEx(int nPort);

		/// <summary>
		/// 30、BOOL PlayM4_SetPlayedTimeEx(LONG nPort,DWORD nTime); 
		/// 根据时间设置文件播放位置，此接口比PlayM4_SetPlayPos费时，但如果用时间来控制播放进度条
		/// （与PlayM4_GetPlayedTime(Ex)配合使用），那么可以使进度条平滑滚动。 
		/// </summary>
		/// <param name="nPort"></param>
		/// <param name="nTime">设置文件播放位置到指定时间。单位毫秒。</param>
		/// <returns></returns>
		[DllImport("PlayCtrl.dll")]
		public static extern bool PlayM4_SetPlayedTimeEx(int nPort, int nTime);

		/// <summary>
		/// 31、DWORD PlayM4_GetCurrentFrameNum(LONG nPort); 
		/// 得到当前播放的帧序号。而PlayM4_GetPlayedFrames()是总共解码的帧数。如果文件播放位置
		/// 不被改变，那么这两个函数的返回值应该非常接近，除非码流丢失数据。 
		/// </summary>
		/// <param name="nPort"></param>
		/// <returns></returns>
		[DllImport("PlayCtrl.dll")]
		public static extern int PlayM4_GetCurrentFrameNum(int nPort);

		/// <summary>
		/// 32．BOOL PlayM4_SetStreamOpenMode(LONG nPort,DWORD nMode); 
		/// 设置流播放的模式。必须在播放之前设置。 
		/// 注意：2.2版以后可以做暂停，快放，慢放，单帧播放操作。 
		/// </summary>
		/// <param name="nPort"></param>
		/// <param name="nMode">STREAME_REALTIME实时模式（默认），STREAME_FILE文件模式。</param>
		/// <returns></returns>
		[DllImport("PlayCtrl.dll")]
		public static extern bool PlayM4_SetStreamOpenMode(int nPort, ushort nMode);

		/// <summary>
		/// 33、DWORD PlayM4_GetFileHeadLength(); 
		/// 得到当前版本播放器能播放的文件的文件头长度。主要应用在流播放器的STREAME_FILE模式下。
		/// 以便读出文件头作为PlayM4_OpenStream()的输入参数。 
		/// <example>
		/// CFile m_TestFile;
		/// void Start() 
		/// {
		///		//获得文件头长度； 
		///		DWORD nLength= PlayM4_GetFileHeadLength(); 
		///		PBYTE pFileHead=new BYTE[nLength]; 
		///		//打开文件； 
		///		m_TestFile.Open("test.mp4 ", CFile::modeRead,NULL); 
		///		m_TestFile.Read(pFileHead,nLength); 
		///		//设置模式 
		///		PlayM4_SetStreamOpenMode(0,STREAME_FILE); 
		///		//打开流接口 
		///		if(!PlayM4_OpenStream(0,pFileHead, nLength,1024*100)) 
		///		{ 
		///			m_strPlayFileName=""; 
		///			MessageBox("文件打不开"); 
		///		} 
		///		//播放 
		///		m_bPlaying = PlayM4_Play( 0, m_hWnd); 
		///		delete []pFileHead; 
		/// }  
		/// /////////////////////////////////////////////////////////////////////////////// 
		/// void InputData() 
		/// {
		///		BYTE pBuf[4096]; 
		///		m_TestFile.Read(pBuf,sizeof(pBuf)); 
		///		while(!PlayM4_InputData(0,pBuf,sizeof(pBuf))) 
		///		{ 
		///			if(!m_bPlaying) 
		///			break;//如果已经停止播放，则退出； 
		///			TRACE("SLEEEP \n"); 
		///			Sleep(5); 
		///		} 
		///  } 
		/// </example>
		/// </summary>
		/// <returns>此版本播放器对应的文件头的长度。 </returns>
		[DllImport("PlayCtrl.dll")]
		public static extern ushort PlayM4_GetFileHeadLength();

		/// <summary>
		/// 34、DWORD PlayM4_GetSdkVersion(); 
		/// 得到当前播放器sdk的版本号和build号。如果只是修改bug，我们只升级build号。
		/// </summary>
		/// <returns>高16位表示当前的build号。9~16位表示主版本号，1~8位表示次版本号。如：返回值0x06040105 表示：build号是0604，版本号1.5。 </returns>
		[DllImport("PlayCtrl.dll")]
		public static extern bool PlayM4_GetSdkVersion();

		/// <summary>
		/// 35、DWORD PlayM4_GetLastError(LONG nPort) 
		/// 获得当前错误的错误码。用户应该在调用某个函数失败时，调用此函数以获得错误的详细信息。 
		/// </summary>
		/// <param name="nPort"></param>
		/// <returns></returns>
		[DllImport("PlayCtrl.dll")]
		public static extern int PlayM4_GetLastError(int nPort);

		/// <summary>
		/// 36、BOOL PlayM4_RefreshPlay(LONG nPort)
		/// 刷新显示。当用户暂停时如果刷新了窗口，则窗口中的图像因为刷新而消失，此时调用这个接口可
		/// 以重新把图像显示出来。只有在暂停和单帧播放时才会执行， 其它情况会直接返回。 
		/// </summary>
		/// <param name="nPort"></param>
		/// <returns></returns>
		[DllImport("PlayCtrl.dll")]
		public static extern bool PlayM4_RefreshPlay(int nPort);

		/// <summary>
		/// 37、BOOL PlayM4_SetOverlayMode(LONG nPort,BOOL bOverlay,COLORREF colorKey) 
		/// 设置OVERLAY模式显示画面。在一块显卡中同一时刻只能有一个OVERLAY表面处于活动状态，
		/// 如果此时系统中已经有程序使用了OVERLAY，那么播放器就不能再创建OVERLAY表面，它将自
		/// 动改用Off_Screen表面，并不返回FALSE。一些常用的播放器，以及我们卡的预览都可能使用了
		/// overlay表面。同样，如果播放器使用了OVERLAY表面，那么，其他的程序将不能使用OVERLAY
		/// 表面，特别注意，我们的卡在预览时可能也要使用OVERLAY(用户可设置)，如果先打开播放器（并
		/// 且使用了OVERLAY），再启动预览，那么预览可能因为得不到OVERLAY而失败。使用OVERLAY
		/// 模式的优点是：大部份的显卡都支持OVERLAY，在一些不支持BLT硬件缩放和颜色转换的显卡上 
		/// (如SIS系列显卡)使用OVERLAY模式（OVERLAY模式下的缩放和颜色转换由显卡支持），可以大
		/// 大减小cpu利用率并提高画面质量（相对于软件缩放和颜色转换）。缺点是：只能有一路播放器使用。
		/// 该设置必须在PLAY之前使用，而且需要设置透明色。
		/// </summary>
		/// <param name="nPort"></param>
		/// <param name="bOverlay">如果为TRUE,表示将首先尝试使用OVERLAY模式，如果不行再使用其他模式。如果为FALSE,则不进行OVERLAY模式的尝试。 </param>
		/// <param name="colorKey">
		///     用户设置的透明色，透明色相当于一层透视膜，显示的画面只能穿过这种颜色，而其他的颜色将
		///     挡住显示的画面。用户应该在显示窗口中涂上这种颜色，那样才能看到显示画面。一般应该使
		///     用一种不常用的颜色作为透明色。这是一个双字节值0x00rrggbb,最高字节为0，后三个字节分别表示r,g,b的值。
		/// </param>
		/// <returns></returns>
		[DllImport("PlayCtrl.dll")]
		public static extern bool PlayM4_SetOverlayMode(int nPort, bool bOverlay,int colorKey);

		/// <summary>
		/// 38、BOOL PlayM4_GetPictureSize(LONG nPort,LONG *pWidth,LONG *pHeight); 
		/// 获得码流中原始图像的大小，根据此大小来设置显示窗口的区域，可以不用显卡做缩放工作，
		/// 对于那些不支持硬件缩放的显卡来说非常有用。 
		/// </summary>
		/// <param name="nPort"></param>
		/// <param name="pWidth">原始图像的宽。在PAL制CIF格式下是352。</param>
		/// <param name="pHeight">原始图像的高。在PAL制CIF格式下是288。</param>
		/// <returns></returns>
		[DllImport("PlayCtrl.dll")]
        public static extern bool PlayM4_GetPictureSize(int nPort, out int pWidth, out int pHeight);

		/// <summary>
		/// 39、BOOL PlayM4_SetPicQuality(LONG nPort,BOOL bHighQuality); 
		/// 设置图像质量，当设置成高质量时画面效果好，但CPU利用率高。在支持多路播放时，可以
		/// 设为低质量，以降低CPU利用率；当某路放大播放时将该路设置成高质量，以达到好的画面效果。
		/// </summary>
		/// <param name="nPort"></param>
		/// <param name="bHighQuality">等于1时图像高质量，等于0时低质量（默认值）。</param>
		/// <returns></returns>
		[DllImport("PlayCtrl.dll")]
		public static extern bool PlayM4_SetPicQuality(int nPort, bool bHighQuality);

		/// <summary>
		/// 40、BOOL PlayM4_PlaySoundShare(LONG nPort); 
		/// 以共享方式播放声音，只管播放本路声音而不去关闭其他路的声音。
		/// 注意：WIN98及其之前版本操作系统不支持创建多个声音设备。如果声卡已经被使用，那么此函数将返回FALSE。
		/// </summary>
		/// <param name="nPort"></param>
		/// <returns></returns>
		[DllImport("PlayCtrl.dll")]
		public static extern bool PlayM4_PlaySoundShare(int nPort);

		/// <summary>
		/// 41、BOOL PlayM4_StopSoundShare(LONG nPort); 
		/// 以共享方式关闭声音。PlayM4_PlaySound()和PlayM4_StopSound()是以独占方式播放声音的。
		/// 注意：在同一个进程中，所有通道必须使用相同的方式播放或关闭声音。
		/// </summary>
		/// <param name="nPort"></param>
		/// <returns></returns>
		[DllImport("PlayCtrl.dll")]
		public static extern bool PlayM4_StopSoundShare(int nPort);
		
		#endregion

		#region 以下为2.4版新增接口
		/// <summary>
		/// 42、LONG PlayM4_GetStreamOpenMode(LONG nPort); 
		/// 获得流模式类型。 
		/// </summary>
		/// <param name="nPort"></param>
		/// <returns>STREAME_REALTIME或STREAME_FILE</returns>
		[DllImport("PlayCtrl.dll")]
		public static extern int PlayM4_GetStreamOpenMode(int nPort);

		/// <summary>
		/// 43、LONG PlayM4_GetOverlayMode(LONG nPort); 
		/// 检查当前播放器是否使用了OVERLAY模式
		/// </summary>
		/// <param name="nPort"></param>
		/// <returns>0，表示没有使用OVERLAY；1，表示使用了OVERLAY表面。</returns>
		[DllImport("PlayCtrl.dll")]
		public static extern int PlayM4_GetOverlayMode(int nPort);

		/// <summary>
		/// 44、COLORREF PlayM4_GetColorKey(LONG nPort); 
		/// 获得OVERLAY表面使用的透明色
		/// </summary>
		/// <param name="nPort"></param>
		/// <returns>颜色值</returns>
		[DllImport("PlayCtrl.dll")]
        public static extern uint PlayM4_GetColorKey(int nPort);

		/// <summary>
		/// 45、WORD PlayM4_GetVolume(LONG nPort); 
		/// 获得当前设置的音量
		/// </summary>
		/// <param name="nPort">音量值</param>
		/// <returns></returns>
		[DllImport("PlayCtrl.dll")]
        public static extern ushort PlayM4_GetVolume(int nPort);

		/// <summary>
		/// 46、BOOL PlayM4_GetPictureQuality(LONG nPort,BOOL *bHighQuality); 
		/// 获得当前图像质量
		/// </summary>
		/// <param name="nPort"></param>
		/// <param name="bHighQuality">1表示高质量，0表示低质量。 </param>
		/// <returns></returns>
		[DllImport("PlayCtrl.dll")]
		public static extern bool PlayM4_GetPictureQuality(int nPort, out bool bHighQuality);

		/// <summary>
		/// 47、DWORD PlayM4_GetSourceBufferRemain(LONG nPort); 
		/// 获得流播放模式下源缓冲剩余数据 
		/// </summary>
		/// <param name="nPort"></param>
		/// <returns>当前源缓冲的大小（BYTE）</returns>
		[DllImport("PlayCtrl.dll")]
		public static extern ushort PlayM4_GetSourceBufferRemain(int nPort);

		/// <summary>
		/// 48、BOOL PlayM4_ResetSourceBuffer(LONG nPort); 
		/// 清除流播放模式下源缓冲区剩余数据
		/// </summary>
		/// <param name="nPort"></param>
		/// <returns></returns>
		[DllImport("PlayCtrl.dll")]
		public static extern bool PlayM4_ResetSourceBuffer(int nPort);

		/// <summary>
		/// 49、BOOL PlayM4_SetSourceBufCallBack(LONG nPort,DWORD nThreShold,void (CALLBACK * SourceBufCallBack)(long nPort,DWORD nBufSize,DWORD dwUser,void*pResvered),DWORD dwUser,void *pReserved); 
		/// 设置源缓冲区阀值和剩余数据小于等于阀值时的回调函数指针
		/// </summary>
		/// <param name="nPort"></param>
		/// <param name="nThreShold">阀值</param>
		/// <param name="sbcb">回调函数指针</param>
		/// <param name="dwUser">用户数据</param>
		/// <param name="pReserved">保留数据</param>
		/// <returns></returns>
		[DllImport("PlayCtrl.dll")]
		public static extern bool PlayM4_SetSourceBufCallBack(int nPort, ushort nThreShold, SourceBufCallBack sbcb, ushort dwUser, IntPtr pReserved);

		/// <summary>
		/// 50、BOOL PlayM4_ResetSourceBufFlag(LONG nPort); 
		/// 重置回调标志位为有效状态。流模式下源缓冲到达阀值时（如果用户设置了回调函数）不一定会回调，
		/// 用户需要重置回调标志位后才能回调。而且每次回调后标志位都被设为无效，用户可以在适当的时候重置回调标志，
		/// 这个接口的主要目的是防止重复回调（数据在阀值附近摆动因为用户输入数据时，播放器也在读走数据）。
		/// 初始化状态下，回调标志位是有效的。 
		/// </summary>
		/// <param name="nPort"></param>
		/// <returns></returns>
		[DllImport("PlayCtrl.dll")]
		public static extern bool PlayM4_ResetSourceBufFlag(int nPort);

		/// <summary>
		/// 51、BOOL PlayM4_SetDisplayBuf(LONG nPort,DWORD nNum); 
		/// 设置播放缓冲区（即解码后的图像缓冲区）大小；这个缓冲区比较重要，他直接影响播放的流畅性和延时性。
		/// 在一定范围内缓冲越大越流畅，同时延时越大。在播放文件时用户最好可以考虑开大缓冲（如果内存足够大），
		/// 我们的默认值是15（帧），在25帧/秒的情况下即0.6秒的数据。在播放流时我们的默认值是10(帧)，
		/// 如果用户追求最大延时最小，可以考虑试当减小这个值。 输入参数：nNum 播放缓冲区最大缓冲帧数。
		/// 范围：MIN_DIS_FRAMES ~MAX_DIS_FRAMES。一帧352*288图像的所需内存最小值是 352*288*3/2大约150K 。
		/// 最大值是352*288*4大约405K。 
		/// </summary>
		/// <param name="nPort"></param>
		/// <param name="nNum"></param>
		/// <returns></returns>
		[DllImport("PlayCtrl.dll")]
		public static extern bool PlayM4_SetDisplayBuf(int nPort, ushort nNum);

		/// <summary>
		/// 获得播放缓冲区最大缓冲的帧数
		/// 
		/// 52．DWORD  PlayM4_GetDisplayBuf(LONG nPort); 
		/// </summary>
		/// <param name="nPort"></param>
		/// <returns>播放缓冲区最大缓冲帧数</returns>
		[DllImport("PlayCtrl.dll")]
		public static extern ushort PlayM4_GetDisplayBuf(int nPort);

		/// <summary>
		/// 53、BOOL PlayM4_SetFileRefCallBack(LONG nPort,  void (__stdcall *pFileRefDone) (DWORD nPort,DWORD nUser),DWORD nUser); 
		/// 设置回调函数指针，文件索引建立后回调。为了能在文件中准确快速的定位，我们在文件打开的时候生成文件索引。
        /// 这个过程耗时比较长，大约每秒处理40M左右的数据，主要是因为从硬盘读数据比较慢。
        /// 建立索引的过程是在后台完成，需要使用索引的函数要等待这个过程结束，而其他接口不会受到影响。 
		/// </summary>
		/// <param name="nPort"></param>
		/// <param name="frd">回调函数指针</param>
		/// <param name="nUser">用户数据</param>
		/// <returns></returns>
		[DllImport("PlayCtrl.dll")]
		public static extern bool PlayM4_SetFileRefCallBack(int nPort, FileRefDone frd, ushort nUser);

		/// <summary>
		/// 54、BOOL PlayM4_OneByOneBack(LONG nPort); 
		/// 单帧回放。每调用一次倒退一帧。此函数必须在文件索引生成之后才能调用。
		/// 虽然SetCurrentFrameNum()也可以做到单帧回退，但效率要低很多。在单帧回放时我们建议使用这个接口。
		/// </summary>
		/// <param name="nPort"></param>
		/// <returns></returns>
		[DllImport("PlayCtrl.dll")]
		public static extern bool PlayM4_OneByOneBack(int nPort);

		/// <summary>
		/// 55、BOOL PlayM4_SetCurrentFrameNum(LONG nPort,DWORD nFrameNum); 
		/// 设置当前播放播放位置到指定帧号；根据帧号来定位播放位置。此函数必须在文件索引生成之后才能调用
		/// </summary>
		/// <param name="nPort"></param>
		/// <param name="nFrameNum">帧序号</param>
		/// <returns></returns>
		[DllImport("PlayCtrl.dll")]
		public static extern bool PlayM4_SetCurrentFrameNum(int nPort, int nFrameNum);

		/// <summary>
		/// 56、BOOL PlayM4_GetKeyFramePos(LONG nPort,DWORD nValue, DWORD nType, PFRAME_POS pFramePos); 
		/// 查找指定位置之前的关键帧位置。图像解码必须从关键帧开始，如果用户保存的文件不是从
		/// 关键帧开始的，那么倒下一个关键帧之前的数据会被忽略。如果用户要截取文件中的一段数据，
		/// 则应该考虑从关键帧开始截取。结束位置则关系不大，最多丢失3帧数据。 
		/// </summary>
		/// <param name="nPort"></param>
		/// <param name="nValue">当前位置，可以是时间或帧号，类型由nType指定。</param>
		/// <param name="nType">指定nValue的类型。如果nType 是BY_FRAMENUM则nValue表示帧号BY_FRAMTIME，则nValue表示时间，单位ms。 </param>
		/// <param name="pFramePos">查找到的关键帧的文件位置，帧序号，时标信息。 </param>
		/// <returns></returns>
		[DllImport("PlayCtrl.dll")]
		public static extern bool PlayM4_GetKeyFramePos(int nPort, ushort nValue, ushort nType, ref PFRAME_POS pFramePos);

		/// <summary>
		/// 57、BOOL PlayM4_GetNextKeyFramePos(LONG nPort,DWORD nValue, DWORD nType, PFRAME_POS pFramePos);
		/// 查找指定位置之后的关键帧位置。
		/// </summary>
		/// <param name="nPort"></param>
		/// <param name="nValue">当前位置，可以是时间或帧号，类型由nType指定。</param>
		/// <param name="nType">指定nValue的类型。如果nType 是BY_FRAMENUM则nValue表示帧号，如果nType 是Y_FRAMTIME，则nValue表示时间，单位ms。</param>
		/// <param name="pFramePos">查找到的关键帧的文件位置，帧序号，时标信息。</param>
		/// <returns></returns>
		[DllImport("PlayCtrl.dll")]
		public static extern bool PlayM4_GetNextKeyFramePos(int nPort, ushort nValue, ushort nType, ref PFRAME_POS pFramePos);

		/// <summary>
		/// 58、BOOL PlayM4_ThrowBFrameNum(LONG nPort,DWORD nNum); 
		/// 设置不解码B帧帧数；不解码B帧，可以减小CPU利用率，如果码流中没有B帧，那么设
		/// 置这个值将不会有作用。如在快速播放，和支持多路而CPU利用率太高的情况下可以考虑使用。 
		/// </summary>
		/// <param name="nPort"></param>
		/// <param name="nNum">不解码B帧的帧数。nNum 对于我们的DS-400XM系列板卡采集的文件，nNum范围是0~2。</param>
		/// <returns></returns>
		[DllImport("PlayCtrl.dll")]
		public static extern bool PlayM4_ThrowBFrameNum(int nPort, int nNum);

		///////////////////////////////////////////////////////////////////////////////////////////////
		//注意：59~64几个函数接口，是为支持多显卡而增加的。Windows98,Windows2000及Windows2000之后的
		//		操作系统才支持多显卡，并需要安装DirectX6.0或更高版本。如果用户不需支持多显卡环境，则这几个接
		//		口可以不予考虑。关于多显卡的编程请参考Microsoft sdk相关文档"Multiple-Monitor Systems"
		///////////////////////////////////////////////////////////////////////////////////////////////
		/// <summary>
		/// 59、BOOL PlayM4_InitDDrawDevice(); 
		/// 枚举系统中的显示设备。
		/// </summary>
		/// <returns></returns>
		[DllImport("PlayCtrl.dll")]
		public static extern bool PlayM4_InitDDrawDevice();

		/// <summary>
		/// 60、void PlayM4_ReleaseDDrawDevice(); 
		/// 释放枚举显示设备的过程中分配的资源。
		/// </summary>
		[DllImport("PlayCtrl.dll")]
		public static extern void PlayM4_ReleaseDDrawDevice();

		/// <summary>
		/// 61．DWORD PlayM4_GetDDrawDeviceTotalNums(); 
		/// 获得系统中与windows桌面绑定的总的显示设备数目（这里主要是指显卡）
		/// </summary>
		/// <returns>
		///     如果返回0，则表示系统中只有主显示设备。如果返回1，则表示系统中安装了多块显卡
		///     但只有一块显卡与Windows桌面绑定。返回其他值，则表示系统中与桌面绑定的显卡数目。在多显卡
		///     的系统中可以通过设置显示属性，而指定任意一块显卡作为主显示设备。 
		/// </returns>
		[DllImport("PlayCtrl.dll")]
		public static extern int PlayM4_GetDDrawDeviceTotalNums();

		/// <summary>
		/// 62、BOOL PlayM4_SetDDrawDevice(LONG nPort,DWORD nDeviceNum);
		/// 设置播放窗口使用的显卡。注意：该窗口必须在该显卡所对应的监视器上才能显示播放画面。
		/// </summary>
		/// <param name="nPort"></param>
		/// <param name="nDeviceNum">显示设备的设备号，如果是0，则表示使用主显示设备。</param>
		/// <returns></returns>
		[DllImport("PlayCtrl.dll")]
		public static extern bool PlayM4_SetDDrawDevice(int nPort, int nDeviceNum);

		/// <summary>
		/// 63、BOOL PlayM4_GetDDrawDeviceInfo(DWORD nDeviceNum,LPSTR lpDriverDescription,DWORD nDespLen,LPSTR lpDriverName ,DWORD nNameLen,HMONITOR *hhMonitor); 
		/// 得到指定显卡和监视器信息
		/// </summary>
		/// <param name="nDeviceNum">显示设备的设备号，如果是0，则表示主显示设备。</param>
		/// <param name="lpDriverDescription">输出参数：显示设备的描述信息。 </param>
		/// <param name="nDespLen">表示lpDriverDescription已分配空间的大小，单位byte。</param>
		/// <param name="lpDriverName">输出参数：显示设备的设备名。 </param>
		/// <param name="nNameLen">表示lpDriverName已分配空间的大小，单位byte。</param>
		/// <param name="hhMonitor">
		///		显示设备使用的监视器句柄，通过Windows API 函数GetMonitorInfo，可以得到详细信息，供用户定位窗口位置。
		///     注意：HMONITOR类型 ，当_WIN32_WINNT >= 0x0500时，在“windef.h”头文件中定义，
		///		否则在“Multimon.H”中定义，如果用户在编译过程中找不到该类型定义，可以包含相应的头文件。 
		/// </param>
		/// <returns></returns>
		[DllImport("PlayCtrl.dll")]
        public static extern bool PlayM4_GetDDrawDeviceInfo(int nDeviceNum, [MarshalAs(UnmanagedType.LPStr)] string lpDriverDescription, ushort nDespLen, [MarshalAs(UnmanagedType.LPStr)] string lpDriverName, ushort nNameLen, IntPtr hhMonitor);

		/// <summary>
		/// 64、int PlayM4_GetCapsEx(DWORD nDDrawDeviceNum);
		/// 获得指定显示设备的系统信息，支持多显卡。
		/// </summary>
		/// <param name="nDDrawDeviceNum">指定显示设备的设备号，如果是0，则表示主显示设备。</param>
		/// <returns></returns>
		[DllImport("PlayCtrl.dll")]
		public static extern int PlayM4_GetCapsEx(int nDDrawDeviceNum);

		/// <summary>
		/// 65、BOOL PlayM4_SetDisplayType(LONG nPort,LONG nType);
		/// 设置显示的模式，在小画面显示时，采用DISPLAY_QUARTER 可以减小显卡工作量，从而
		/// 支持更多路显示，但画面显示质量有下降。在正常和大画面显示时应该使用DISPLAY_NORMAL。
		/// </summary>
		/// <param name="nPort"></param>
		/// <param name="nType">nType 两种模式，DISPLAY_NORMAL或DISPLAY_QUARTER。</param>
		/// <returns></returns>
		[DllImport("PlayCtrl.dll")]
		public static extern bool PlayM4_SetDisplayType(int nPort, int nType);

		/// <summary>
		/// 66、long PlayM4_GetDisplayType(LONG nPort);
		/// 获得目前设置的显示模式。
		/// </summary>
		/// <param name="nPort"></param>
		/// <returns>DISPLAY_NORMAL 或 DISPLAY_QUARTER</returns>
		[DllImport("PlayCtrl.dll")]
		public static extern int PlayM4_GetDisplayType(int nPort);

		/// <summary>
		/// 67、BOOL __stdcall PlayM4_SetDecCBStream(LONG nPort,DWORD nStream);
		/// 设置解码回调的流类型。
		/// </summary>
		/// <param name="nPort"></param>
		/// <param name="nStream">1视频流，2音频流，3复合流</param>
		/// <returns></returns>
		[DllImport("PlayCtrl.dll")]
		public static extern bool PlayM4_SetDecCBStream(int nPort, ushort nStream);

		/// <summary>
		/// 68、BOOL __stdcall PlayM4_SetDisplayRegion(LONG nPort,DWORD nRegionNum, RECT *pSrcRect, HWND hDestWnd, BOOL bEnable); 
		/// 设置或增加显示区域。可以做局部放大显示。
		/// </summary>
		/// <param name="nPort"></param>
		/// <param name="nRegionNum">显示区域序号，0~(MAX_DISPLAY_WND-1)。nRegionNum如果nRegionNum为0，
		/// 表示对主要显示窗口(PlayM4_Play中设置的窗口)进行设置，将忽略hDestWnd和bEnable的设置。</param>
		/// <param name="pSrcRect">设置在要显示的原始图像上的区域，如：如果原始图像是352*288，
		/// 那么pSrcRect可设置的范围只能在（0，0，352，288）之中。如果pSrcRect=NULL,将显示整个图像。</param>
		/// <param name="hDestWnd">设置显示窗口。如果该区域的窗口已经设置过（打开过），那么该参数被忽略。</param>
		/// <param name="bEnable">打开（设置）或关闭显示区域。</param>
		/// <returns></returns>
		[DllImport("PlayCtrl.dll")]
		public static extern bool PlayM4_SetDisplayRegion(int nPort, ushort nRegionNum, ref Rectangle pSrcRect, IntPtr hDestWnd, bool bEnable);

		/// <summary>
		/// 69、BOOL __stdcall PlayM4_RefreshPlayEx(LONG nPort,DWORD nRegionNum); 
		/// 刷新显示，同36。为支持PlayM4_SetDisplayRegion而增加一个参数。 
		/// </summary>
		/// <param name="nPort"></param>
		/// <param name="nRegionNum">显示区域序号。</param>
		/// <returns></returns>
		[DllImport("PlayCtrl.dll")]
		public static extern bool PlayM4_RefreshPlayEx(int nPort, ushort nRegionNum);

		/// <summary>
		/// 70、BOOL __stdcall PlayM4_SetDDrawDeviceEx(LONG nPort,DWORD nRegionNum,DWORD nDeviceNum);
		/// 设置播放窗口使用的显卡，同62。为支持PlayM4_SetDisplayRegion而增加一个参数。
		/// </summary>
		/// <param name="nPort"></param>
		/// <param name="nRegionNum">显示区域序号。</param>
		/// <param name="nDeviceNum"></param>
		/// <returns></returns>
		[DllImport("PlayCtrl.dll")]
		public static extern bool PlayM4_SetDDrawDeviceEx(int nPort, ushort nRegionNum, ushort nDeviceNum);

		/// <summary>
		/// 71、BOOL __stdcall PlayM4_OpenStreamEx(LONG nPort,PBYTE pFileHeadBuf,DWORD nSize,DWORD nBufPoolSize);
		/// 以音视频分开输入的方式打开流。
		/// </summary>
		/// <param name="nPort"></param>
		/// <param name="pFileHeadBuf">用户从卡上得到的文件头数据。</param>
		/// <param name="nSize">文件头长度 </param>
		/// <param name="nBufPoolSize"> 设置播放器中存放数据流的缓冲区大小。范围是SOURCE_BUF_MIN~ SOURCE_BUF_MAX。</param>
		/// <returns></returns>
		[DllImport("PlayCtrl.dll")]
		public static extern bool PlayM4_OpenStreamEx(int nPort, IntPtr pFileHeadBuf, ushort nSize, ushort nBufPoolSize);

		/// <summary>
		/// 72、BOOL __stdcall PlayM4_CloseStreamEx(LONG nPort);
		/// 关闭数据流
		/// </summary>
		/// <param name="nPort"></param>
		/// <returns></returns>
		[DllImport("PlayCtrl.dll")]
		public static extern bool PlayM4_CloseStreamEx(int nPort);

		/// <summary>
		/// 73、BOOL __stdcall PlayM4_InputVideoData(LONG nPort,PBYTE pBuf,DWORD nSize);
		/// 输入从卡上得到的视频流 (可以是复合流，但音频数据会被忽略)；打开流之后才能输入数据。
		/// </summary>
		/// <param name="nPort"></param>
		/// <param name="pBuf">缓冲区地址</param>
		/// <param name="nSize">缓冲区大小</param>
		/// <returns>TURE,表示已经输入数据。FALSE 表示失败，数据没有输入。</returns>
		[DllImport("PlayCtrl.dll")]
		public static extern bool PlayM4_InputVideoData(int nPort, IntPtr pBuf, ushort nSize);

		/// <summary>
		/// 74、BOOL __stdcall PlayM4_InputAudioData(LONG nPort,PBYTE pBuf,DWORD nSize);
		/// 输入从卡上得到的音频流；打开声音之后才能输入数据。 
		/// </summary>
		/// <param name="nPort"></param>
		/// <param name="pBuf">缓冲区地址</param>
		/// <param name="nSize">缓冲区大小</param>
		/// <returns>返回值：TURE,表示已经输入数据。FALSE 表示失败，数据没有输入。</returns>
		[DllImport("PlayCtrl.dll")]
		public static extern bool PlayM4_InputAudioData(int nPort, IntPtr pBuf, ushort nSize);

		/// <summary>
		/// 75、BOOL __stdcall PlayM4_RigisterDrawFun(LONG nPort,void (CALLBACK* DrawFun)(long nPort,HDC hDc,LONG nUser),LONG nUser);
		/// 注册一个回调函数，获得当前表面的device context, 你可以在这个DC上画图（或写字），就好像在窗口的客户区DC上绘图，
		/// 但这个DC不是窗口客户区的DC，而是DirectDraw里的Off-Screen表面的DC。注意，如果是使用overlay表面，这个接口无效，
		/// 你可以直接在窗口上绘图，只要不是透明色就不会被覆盖。 
		/// </summary>
		/// <param name="nPort"></param>
		/// <param name="df">回调函数句柄</param>
		/// <param name="nUser">用户数据</param>
		/// <returns></returns>
		[DllImport("PlayCtrl.dll")]
		public static extern bool PlayM4_RigisterDrawFun(int nPort, DrawFun df, int nUser);

		/// <summary>
		/// 76、BOOL __stdcall PlayM4_GetRefValue(LONG nPort,BYTE *pBuffer, DWORD *pSize);
		/// 获取文件索引信息，以便下次打开同一个文件时直接使用这个信息。必须在索引建成后才能获得信息。 
		/// </summary>
		/// <param name="nPort"></param>
		/// <param name="pBuffer">索引信息</param>
		/// <param name="pSize">
		///		输入/输出参数：输入pBuffer的大小，输出索引信息大小。
		///     注：可以在第一次指定pSize=0,pBuffer=NULL
		///     从pSize的返回值获得需要的缓冲区大小。然后分配足够的缓冲，再调用一次 
		/// </param>
		/// <returns></returns>
		[DllImport("PlayCtrl.dll")]
		public static extern bool PlayM4_GetRefValue(int nPort, IntPtr pBuffer, ref ushort pSize);

		/// <summary>
		/// 77、BOOL __stdcall PlayM4_SetRefValue(LONG nPort,BYTE *pBuffer, DWORD nSize);
		/// 设置文件索引。如果已经有了文件索引信息，可以不再调用生成索引的回调函数(53.PlayM4_SetFileRefCallBack)，
		/// 直接输入索引信息。注：索引信息及其长度必须准确 
		/// </summary>
		/// <param name="nPort"></param>
		/// <param name="pBuffer">索引信息。</param>
		/// <param name="nSize">索引信息的长度</param>
		/// <returns></returns>
		[DllImport("PlayCtrl.dll")]
		public static extern bool PlayM4_SetRefValue(int nPort, IntPtr pBuffer, ushort nSize);

		/// <summary>
		/// 78、BOOL __stdcall PlayM4_SetTimerType(LONG nPort,DWORD nTimerType,DWORD nReserved);
		/// 设置播放器使用的定时器；注意：必须在Open之前调用
		/// </summary>
		/// <param name="nPort"></param>
		/// <param name="nTimerType">TIMER_1或TIMER_2，见宏定义。默认情况下0~15路使用TIMER_1，其余使用TIMER_2。</param>
		/// <param name="nReserved">保留</param>
		/// <returns></returns>
		[DllImport("PlayCtrl.dll")]
		public static extern bool PlayM4_SetTimerType(int nPort, int nTimerType, ushort nReserved);

		/// <summary>
		/// 79、BOOL __stdcall PlayM4_GetTimerType(LONG nPort,DWORD *pTimerType,DWORD *pReserved);
		/// 获得当前通道使用的定时器。 
		/// </summary>
		/// <param name="nPort"></param>
		/// <param name="pTimerType">TIMER_1或TIMER_2</param>
		/// <param name="pReserved">保留</param>
		/// <returns></returns>
		[DllImport("PlayCtrl.dll")]
		public static extern bool PlayM4_GetTimerType(int nPort, out ushort pTimerType, out ushort pReserved);

		/// <summary>
		/// 80、BOOL __stdcall PlayM4_ResetBuffer(LONG nPort,DWORD nBufType);
		/// 清空播放器中的缓冲区。
		/// </summary>
		/// <param name="nPort"></param>
		/// <param name="nBufType">缓冲区类型</param>
		/// <returns></returns>
		[DllImport("PlayCtrl.dll")]
		public static extern bool PlayM4_ResetBuffer(int nPort, int nBufType);

		/// <summary>
		/// 81、DWORD __stdcall PlayM4_GetBufferValue(LONG nPort,DWORD nBufType);
		/// 获取播放器中的缓冲区大小（帧数或者byte）。这个接口可以帮助用户了解缓冲区中的数据，从而在网络延时方面有所估计。 
		/// </summary>
		/// <param name="nPort"></param>
		/// <param name="nBufType">缓冲区类型</param>
		/// <returns>根据参数不同，返回缓冲区值，源缓冲区返回byte,解码后缓冲区返回帧数。</returns>
		[DllImport("PlayCtrl.dll")]
		public static extern ushort PlayM4_GetBufferValue(int nPort, ushort nBufType);

		/// <summary>
		/// 82、BOOL __stdcall PlayM4_AdjustWaveAudio(LONG nPort,LONG nCoefficient);
		/// 调整WAVE波形，可以改变声音的大小。它和PlayM4_SetVolume()的不同在于，它是调整声音数据，
		/// 只对该路其作用，而PlayM4_SetVolume是调整声卡音量，对整个系统起作用。
		/// 注意，用这个函数会破坏音质，除非想每路单独调整音量，否则请谨慎使用。 
		/// </summary>
		/// <param name="nPort"></param>
		/// <param name="nCoefficient">调整的参数，范围从MIN_WAVE_COEF 到 MAX_WAVE_COEF，0是不调整。</param>
		/// <returns></returns>
		[DllImport("PlayCtrl.dll")]
		public static extern bool PlayM4_AdjustWaveAudio(int nPort, int nCoefficient);

		/// <summary>
		/// 83、BOOL __stdcall PlayM4_SetVerifyCallBack(LONG nPort, DWORD nBeginTime, DWORD nEndTime, void (__stdcall* funVerify)(long nPort, FRAME_POS * pFilePos, DWORD bIsVideo, DWORD nUser),  DWORD  nUser); 
		/// 注册一个回调函数，校验数据是否被修改，实现水印功能。现在可以发现数据丢失情况。
		/// 注意，该校验在建立文件索引的时候进行，所以必须建文件索引才能校验。在openfile之前使用。
		/// </summary>
		/// <param name="nPort"></param>
		/// <param name="nBeginTime">校验开始时间，单位ms</param>
		/// <param name="nEndTime">校验结束时间，单位ms</param>
		/// <param name="vfy">当发现数据被修改时回调的函数</param>
		/// <param name="nUser">用户数据</param>
		/// <returns></returns>
		[DllImport("PlayCtrl.dll")]
		public static extern bool PlayM4_SetVerifyCallBack(int nPort, uint nBeginTime, uint nEndTime, Verify vfy, uint nUser);

		/// <summary>
		/// 84、BOOL __stdcall PlayM4_SetAudioCallBack(LONG nPort, void (__stdcall * funAudio)(long nPort, char * pAudioBuf, long nSize, long nStamp, long nType, long nUser), long nUser);
		/// 音频帧解码后的wave数据回调
		/// </summary>
		/// <param name="nPort"></param>
		/// <param name="nBufType"></param>
		/// <param name="ado">音频回调函数</param>
		/// <param name="nUser">用户自定义数据</param>
		/// <returns></returns>
		[DllImport("PlayCtrl.dll")]
		public static extern bool PlayM4_SetAudioCallBack(int nPort, Audio ado, int nUser);

		/// <summary>
		/// 85、BOOL __stdcall PlayM4_SetEncTypeChangeCallBack(LONG nPort,void(CALLBACK *funEncChange)(long nPort,long nUser),long nUser);
		/// 解码时图象格式发生改变通知用户的回调函数；在打开文件前使用
		/// </summary>
		/// <param name="nPort"></param>
		/// <param name="ec">回调函数</param>
		/// <param name="nUser">用户自定义数据</param>
		/// <returns></returns>
		[DllImport("PlayCtrl.dll")]
		public static extern bool PlayM4_SetEncTypeChangeCallBack(int nPort, EncChange ec, int nUser);

		/// <summary>
		/// 86、BOOL __stdcall PlayM4_SetColor(LONG nPort, DWORD nRegionNum, int nBrightness, int nContrast, int nSaturation, int nHue);
		/// 设置图象的视频参数，即时起作用
		/// 注意：如果全部为默认值将不进行颜色调节
		/// </summary>
		/// <param name="nPort"></param>
		/// <param name="nRegionNum">显示区域，参考PlayM4_SetDisplayRegion；如果只有一个显示区域(通常情况)设为0</param>
		/// <param name="nBrightness">亮度，默认64； 范围0-128</param>
		/// <param name="nContrast">对比度，默认64； 范围0-128</param>
		/// <param name="nSaturation">饱和度，默认64； 范围0-128</param>
		/// <param name="nHue">色调，默认64； 范围0-128</param>
		/// <returns></returns>
		[DllImport("PlayCtrl.dll")]
		public static extern bool PlayM4_SetColor(int nPort, ushort nRegionNum, int nBrightness, int nContrast, int nSaturation, int nHue);

		/// <summary>
		/// 87、BOOL __stdcall PlayM4_GetColor(LONG nPort, DWORD nRegionNum, int *pBrightness, int *pContrast, int *pSaturation, int *pHue);
		/// 相应的获得颜色值
		/// </summary>
		/// <param name="nPort"></param>
		/// <param name="nRegionNum">显示区域，参考PlayM4_SetDisplayRegion；如果只有一个显示区域(通常情况)设为0</param>
		/// <param name="nBrightness">亮度，默认64； 范围0-128</param>
		/// <param name="nContrast">对比度，默认64； 范围0-128</param>
		/// <param name="nSaturation">饱和度，默认64； 范围0-128</param>
		/// <param name="nHue">色调，默认64； 范围0-128</param>
		/// <returns></returns>
		[DllImport("PlayCtrl.dll")]
		public static extern bool PlayM4_GetColor(int nPort, ushort nRegionNum, out int pBrightness, out int pContrast, out int pSaturation, out int pHue);

		/// <summary>
		/// 88、BOOL __stdcall PlayM4_SetEncChangeMsg(LONG nPort,HWND hWnd,UINT nMsg)
		/// 设置解码时编码格式发生改变时要发送的消息。 
		/// </summary>
		/// <param name="nPort"></param>
		/// <param name="hWnd">消息发送的窗口。</param>
		/// <param name="nMsg">用户输入的消息，当设置解码时编码格式发生改变时要发送此定义的消息。消息函数中的wParam参数值是返回nPort的值。 </param>
		/// <returns></returns>
		[DllImport("PlayCtrl.dll")]
		public static extern bool PlayM4_SetEncChangeMsg(int nPort, IntPtr hWnd, uint nMsg);

		/// <summary>
		/// 89、BOOL _stdcall PlayM4_GetOriginalFrameCallBack(LONG nPort, BOOL bIsChange, BOOL bNormalSpeed, long nStartFrameNum, long nStartStamp, long nFileHeader, void(CALLBACK *funGetOrignalFrame)(long nPort,FRAME_TYPE *frameType, long nUser), long nUser)
		/// 创建得到原始帧数据的回调函数，可以改变每帧的时标和帧号，在文件打开之后调用。用于将两个文件拼接在一起。
		/// </summary>
		/// <param name="nPort"></param>
		/// <param name="bIsChange">是否要改变每帧的参数</param>
		/// <param name="bNormalSpeed">是否要以正常速度得到原始帧</param>
		/// <param name="nStartFrameNum">如要改变原始帧帧号，则是此文件的开始帧号</param>
		/// <param name="nStartStamp">如要改变原始帧时标，则是此文件的开始时标</param>
		/// <param name="nFileHeader">输出参数:文件头版本信息，如果版本不匹配，返回不成功</param>
		/// <param name="gof"></param>
		/// <param name="nUser">用户数据</param>
		/// <returns></returns>
		[DllImport("PlayCtrl.dll")]
		public static extern bool PlayM4_GetOriginalFrameCallBack(int nPort, bool bIsChange, bool bNormalSpeed, int nStartFrameNum, int nStartStamp, out int nFileHeader, GetOrignalFrame gof, int nUser);

		/// <summary>
		/// 90、BOOL _stdcall PlayM4_GetFileSpecialAttr(LONG nPort, DWORD *pTimeStamp,DWORD *pFileNum ,DWORD *nFileHeader)
		/// 得到文件最后的时标和帧号，在文件打开之后调用。与上个文件一起使用，用于文件拼接。 
		/// </summary>
		/// <param name="nPort"></param>
		/// <param name="pTimeStamp">文件结束时标</param>
		/// <param name="pFileNum">文件结束帧号</param>
		/// <param name="nFileHeader">文件头信息</param>
		/// <returns></returns>
		[DllImport("PlayCtrl.dll")]
		public static extern bool PlayM4_GetFileSpecialAttr(int nPort, ref ushort pTimeStamp, ref ushort pFileNum, ref ushort nFileHeader);
		#endregion

		#region 以下为4.7版(build0711)新增接口

		/// <summary>
		/// 91.、BOOL _stdcall PlayM4_ConvertToJpegFile(char *pBuf, long nSize, long nWidth, int nHeight, long nType, char *sFileName)
		/// 抓图存为JPEG文件, 该函数可在显示回调函数中使用, 用法参见PlayM4_ConvertToBmpFile(); 
		/// </summary>
		/// <param name="pBuf">图像数据缓存</param>
		/// <param name="nSize">图像大小</param>
		/// <param name="nWidth">图像宽</param>
		/// <param name="nHeight">图像高</param>
		/// <param name="nType">图像类型YV12</param>
		/// <param name="sFileName">保存jpeg文件路径 </param>
		/// <returns>
		///		TRUE: 保存Jpeg文件成功
		///		FALSE: 失败, 可调用PlayM4_GetLastError()获取错误类型 
		/// </returns>
		[DllImport("PlayCtrl.dll")]
		public static extern bool PlayM4_ConvertToJpegFile(byte[] pBuf, int nSize, int nWidth, int nHeight, int nType, string sFileName);

		/// <summary>
		/// 92、BOOL _stdcall PlayM4_SetJpegQuality(long nQuality)
		/// 设置抓取的jpeg图像质量, 设置范围0~100, 建议使用75~90, 若不调用该函数, 则采用默认图像质量, 目前默认为80 
		/// </summary>
		/// <param name="nQuality">
		///	质量参数, 范围0~100
		///     0:   图像质量最差, 但抓取的图像大小最小 
		///     100: 图像质量最好, 但抓取的图像大小最大 
		/// </param>
		/// <returns>
		///		TRUE: 设置成功, 采用设置的质量
		///		FALSE: 设置失败, 采用默认值, 可调用PlayM4_GetLastError()获取错误类型 
		/// </returns>
		[DllImport("PlayCtrl.dll")]
		public static extern bool PlayM4_SetJpegQuality(int nQuality);

		/// <summary>
		/// 93、BOOL _stdcall PlayM4_SetDeflash(LONG nPort,BOOL bDeflash)
		/// 设置是否去闪烁功能, 原先在静止图像区域有噪声情况下, 图像会产生闪烁现象（或称刷新或跳动），
		/// 启动去闪烁功能后，闪烁效果可消除或减轻，同时也能降低噪声 
		/// </summary>
		/// <param name="nPort">通道号</param>
		/// <param name="bDeflash"> TRUE表示设置去闪烁，FALSE表示不设置，默认为不设置</param>
		/// <returns>TRUE: 设置成功；FALSE: 设置失败, 采用默认值, 可调用PlayM4_GetLastError()获取错误类型 </returns>
		[DllImport("PlayCtrl.dll")]
		public static extern bool PlayM4_SetDeflash(int nPort, bool bDeflash);
		#endregion

		#region 以下为4.8版(build0813)新增接口
		/// <summary>
		/// 94、BOOL __stdcall PlayM4_CheckDiscontinuousFrameNum(LONG nPort, BOOL bCheck)
		/// 帧号不连续时是否跳下一个I帧
		/// </summary>
		/// <param name="nPort">通道号</param>
		/// <param name="bCheck">帧号不连续时是否跳下一个I帧</param>
		/// <returns>TRUE:  设置成功  FALSE: 设置失败 </returns>
		[DllImport("PlayCtrl.dll")]
		public static extern bool PlayM4_CheckDiscontinuousFrameNum(int nPort, bool bCheck);

		/// <summary>
		/// 95、BOOL __stdcall PlayM4_GetBMP(LONG nPort,PBYTE pBitmap,DWORD nBufSize,DWORD* pBmpSize);
		/// 抓取bmp图像 
		/// </summary>
		/// <param name="nPort">通道号</param>
		/// <param name="pBitmap">
		///     存放BMP图像数据地址，由用户分配，不得小于bmp图像大小
		///     sizeof(BITMAPFILEHEADER) + sizeof(BITMAPINFOHEADER) + w * h * 4， 其中w和h分别为图像宽高。 
		/// </param>
		/// <param name="nBufSize">申请的缓冲区大小</param>
		/// <param name="pBmpSize">获取到的实际bmp图像大小</param>
		/// <returns>TRUE:  获取成功 FALSE: 获取失败 </returns>
		[DllImport("PlayCtrl.dll")]
        public static extern bool PlayM4_GetBMP(int nPort, byte[] pBitmap, int nBufSize, out int pBmpSize);

		/// <summary>
		/// 96、BOOL __stdcall PlayM4_GetJPEG(LONG nPort,PBYTE pJpeg,DWORD nBufSize,DWORD* pJpegSize);
		/// 抓取jpeg图像
		/// </summary>
		/// <param name="nPort">通道号</param>
		/// <param name="pJpeg">存放JEPG图像数据地址，由用户分配，不得小于JPEG图像大小，建议大小w * h * 3/2， 其中w和h分别为图像宽高。</param>
		/// <param name="nBufSize">申请的缓冲区大小。</param>
		/// <param name="pJpegSize">获取到的实际bmp图像大小。</param>
		/// <returns>TRUE:   获取成功  FALSE:  获取失败</returns>
		[DllImport("PlayCtrl.dll")]
        public static extern bool PlayM4_GetJPEG(int nPort, byte[] pJpeg, int nBufSize, out int pJpegSize);

		/// <summary>
		/// 97、BOOL __stdcall PlayM4_SetDecCallBackMend(LONG nPort,void (CALLBACK* DecCBFun)(long nPort,char * pBuf,long nSize,FRAME_INFO * pFrameInfo, long nUser, long nReserved2), long nUser);
		/// 设置回调函数，替换播放器中的显示部分，有用户自己控制显示，该函数在PlayM4_Play之前调用，
		/// 在PlayM4_Stop时自动失效，下次调用PlayM4_Play之前需要重新设置。
		/// 注意解码部分不控制速度，只要用户从回调函数中返回，解码器就会解码下一部分数据。这个功能
		/// 的使用需要用户对视频显示和声音播放有足够的了解，否则请慎重使用，有关知识请参阅directx开发包。
		/// </summary>
		/// <param name="nPort"></param>
		/// <param name="dcbf">DecCBFun回调函数指针，不能为NULL</param>
		/// <param name="nUser"></param>
		/// <returns></returns>
		[DllImport("PlayCtrl.dll")]
		public static extern bool PlayM4_SetDecCallBackMend(int nPort, DecCBFun dcbf, int nUser);
		#endregion
    }
}
