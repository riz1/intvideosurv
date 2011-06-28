// Error: Failed to resolve name 'tmServerInfo_t'
// Error: Failed to resolve name 'tmServerCfg_t'
// Error: Failed to resolve name 'tmDecoderInfo_t'
// Error: Failed to resolve name '='
// Error: Failed to resolve name '0x3E'
// Error: Failed to resolve name '='
// Error: Failed to resolve name '0'
// Error: Failed to resolve name '='
// Error: Failed to resolve name '0'
// Error: Failed to resolve name '='
// Error: Failed to resolve name '0'
// Error: Failed to resolve name 'tmConnectCfg_t'
// Error: Failed to resolve name 'tmPtzParameter_t'
// Error: Failed to resolve name 'tmWorkState_t'
// Error: Failed to resolve name 'tmServerExCfg_t'
// Error: Failed to resolve name 'tmConnectCfg_t'
// Error: Failed to resolve name 'tmConnectCfg_t'
// Error: Failed to resolve name 'tmWindowsCfg_t'
// Error: Failed to resolve name 'tmWindowsCfg_t'
// Error: Failed to resolve name 'tmDisplayCfg_t'
// Error: Failed to resolve name 'tmDisplayCfg_t'
// Error: Failed to resolve name 'tmLockCfg_t'
// Error: Failed to resolve name 'tmLockCfg_t'


public enum ControlType
{
    
        PTZ_REALTRANS		=	0,	/* 透明云台数据传输 */                   
        PTZ_LIGHT_PWRON	=		2,	/* 接通灯光电源 */                     
        PTZ_WIPER_PWRON	=		3,	/* 接通雨刷开关 */                     
        PTZ_FAN_PWRON		=	4,	/* 接通风扇开关 */                       
        PTZ_HEATER_PWRON=		5,	/* 接通加热器开关 */                   
        PTZ_AUX_PWRON		=	6,	/* 接通辅助设备开关 */                   
                                                  
        PTZ_ZOOM_IN			=	11,	/* 焦距以速度SS变大(倍率变大) */         
        PTZ_ZOOM_OUT		=	12,	/* 焦距以速度SS变小(倍率变小) */         
        PTZ_FOCUS_NEAR	=		13,	/* 焦点以速度SS前调 */                 
        PTZ_FOCUS_FAR		=	14,	/* 焦点以速度SS后调 */                   
        PTZ_IRIS_ENLARGE=		15,	/* 光圈以速度SS扩大 */                 
        PTZ_IRIS_SHRINK	=		16,	/* 光圈以速度SS缩小 */                 
        PTZ_UP					=21,	/* 云台以SS的速度上仰 */                 
        PTZ_DOWN				=22,	/* 云台以SS的速度下俯 */                 
        PTZ_LEFT				=23,	/* 云台以SS的速度左转 */                 
        PTZ_RIGHT				=24,	/* 云台以SS的速度右转 */                 
        PTZ_RIGHTUP			=	25,	/* 云台以SS的速度右上仰 */               
        PTZ_RIGHTDOWN		=	26,	/* 云台以SS的速度右下仰 */               
        PTZ_LEFTUP			=	27,	/* 云台以SS的速度左上仰 */               
        PTZ_LEFTDOWN		=	28,	/* 云台以SS的速度左下仰 */               
        PTZ_AUTO				=29,	/* 云台以SS的速度左右自动扫描 */         
        PTZ_485INPUT		=	31,	/* 485接收数据输入 */                    
        PTZ_485OUTPUT		=	32,	/* 485发送数据输出 */                    
        PTZ_SET_PRESET	=		100,	// 设置预置点                          
        PTZ_CLE_PRESET	=		101,	// 清除预置点                          
        PTZ_GOTO_PRESET	=		102,	// 转到预置点                          
                                                                       
        PTZ_STARTREC_TRACK	=	110,	// 开始录制轨迹                      
        PTZ_STOPREC_TRACK		=111,	// 停止录制轨迹                      
        PTZ_STARTRUN_TRACK	=	112,	// 运行轨迹                          
        PTZ_STOPRUN_TRACK		=113,	// 停止轨迹                          
                                            
        PTZ_STARTREC_CRUISE	=	120,	// 开始录制巡航                      
        PTZ_STOPREC_CRUISE	=	121,	// 停止录制巡航                      
        PTZ_STARTRUN_CRUISE	=	122,	// 运行巡航                          
        PTZ_STOPRUN_CRUISE	=	123,	// 停止巡航
        PTZ_INTEGRATE_CONTROL =	124	// 云台综合控制，同时控制旋转和变倍等

}


public partial class NativeConstants
{

    /// __TMCONTROLCLIENT_H__ -> 
    /// Error generating expression: 值不能为空。
    ///参数名: node
    public const string @__TMCONTROLCLIENT_H__ = "";

    /// TMCC_API -> extern "C" __declspec(dllexport)
    /// Error generating expression: Expression is not parsable.  Treating value as a raw string
    public const string TMCC_API = "extern \"C\" __declspec(dllexport)";

    /// TMCC_CALL -> __cdecl
    /// Error generating expression: Value __cdecl is not resolved
    public const string TMCC_CALL = "__cdecl";

    /// USER_CONTEXT_SIZE -> 128
    public const int USER_CONTEXT_SIZE = 128;
}

[System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
public struct tmConnectInfo_t
{

    /// unsigned int
    public uint dwSize;

    /// char[32]
    [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst = 32)]
    public string pIp;

    /// int
    public int iPort;

    /// char[32]
    [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst = 32)]
    public string szUser;

    /// char[32]
    [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst = 32)]
    public string szPass;

    /// int
    public int iUserLevel;

    /// unsigned char[128]
    [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst = 128)]
    public string pUserContext;
}

[System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
public struct tmCommandInfo_t
{

    /// unsigned int
    public uint dwSize;

    /// unsigned int
    public uint dwMajorCommand;

    /// unsigned int
    public uint dwMinorCommand;

    /// unsigned short
    public ushort iChannel;

    /// unsigned short
    public ushort iStream;

    /// void*
    public System.IntPtr pCommandBuffer;

    /// int
    public int iCommandBufferLen;

    /// int
    public int iCommandDataLen;

    /// unsigned int
    public uint dwResult;
}

[System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
public struct tmProgressInfo_t
{

    /// HANDLE->void*
    public System.IntPtr hTmcc;

    /// unsigned int
    public uint dwModalID;

    /// unsigned int
    public uint dwModalSize;

    /// unsigned int
    public uint dwModalPos;
}

/// Return Type: void
///hTmCC: HANDLE->void*
///code: unsigned int
///info: char*
///context: void*
[System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.StdCall)]
public delegate void LOG_CALLBACK(System.IntPtr hTmCC, uint code, [System.Runtime.InteropServices.InAttribute()] [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string info, System.IntPtr context);

/// Return Type: BOOL->int
///hTmCC: HANDLE->void*
///bConnect: BOOL->int
///dwResult: unsigned int
///context: void*
[System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.StdCall)]
public delegate int TMCC_CONNECT_CALLBACK(System.IntPtr hTmCC, [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.Bool)] bool bConnect, uint dwResult, System.IntPtr context);

/// Return Type: int
///hTmcc: HANDLE->void*
///pCmd: tmCommandInfo_t*
///context: void*
[System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.StdCall)]
public delegate int TMCC_DATAREAD_CALLBACK(System.IntPtr hTmcc, ref tmCommandInfo_t pCmd, System.IntPtr context);

/// Return Type: BOOL->int
///pCmd: tmCommandInfo_t*
///context: void*
[System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.StdCall)]
public delegate int TMCC_SERVERINFO_CALLBACK(ref tmCommandInfo_t pCmd, System.IntPtr context);

/// Return Type: BOOL->int
///pInfo: tmProgressInfo_t*
///context: void*
[System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.StdCall)]
public delegate int TMCC_PROGRESS_CALLBACK(ref tmProgressInfo_t pInfo, System.IntPtr context);

/// Return Type: int
///hTmCC: HANDLE->void*
///pRecvDataBuffer: char*
///iBufSize: int
///context: void*
[System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.StdCall)]
public delegate int TMCC_SERIALDATA_CALLBACK(System.IntPtr hTmCC, System.IntPtr pRecvDataBuffer, int iBufSize, System.IntPtr context);

public class AironixControl
{
    private const string DllName = "tmControlClient.dll";
    /// Return Type: unsigned int
    ///pBulid: unsigned int*
    [System.Runtime.InteropServices.DllImportAttribute(DllName, EntryPoint = "TMCC_GetVersion", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public static extern uint TMCC_GetVersion(ref uint pBulid);


    /// Return Type: void
    ///pCallBack: LOG_CALLBACK
    ///context: void*
    [System.Runtime.InteropServices.DllImportAttribute(DllName, EntryPoint = "TMCC_RegisterLogCallBack", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public static extern void TMCC_RegisterLogCallBack(LOG_CALLBACK pCallBack, System.IntPtr context);


    /// Return Type: void
    ///pCallBack: TMCC_SERVERINFO_CALLBACK
    ///context: void*
    [System.Runtime.InteropServices.DllImportAttribute(DllName, EntryPoint = "TMCC_RegisterServerInfoCallBack", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public static extern void TMCC_RegisterServerInfoCallBack(TMCC_SERVERINFO_CALLBACK pCallBack, System.IntPtr context);


    /// Return Type: HANDLE->void*
    ///dwFlags: unsigned int
    [System.Runtime.InteropServices.DllImportAttribute(DllName, EntryPoint = "TMCC_Init", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public static extern System.IntPtr TMCC_Init(uint dwFlags);


    /// Return Type: int
    ///hTmCC: HANDLE->void*
    [System.Runtime.InteropServices.DllImportAttribute(DllName, EntryPoint = "TMCC_Done", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public static extern int TMCC_Done(System.IntPtr hTmCC);


    /// Return Type: void
    ///hTmCC: HANDLE->void*
    ///pCallBack: TMCC_CONNECT_CALLBACK
    ///context: void*
    [System.Runtime.InteropServices.DllImportAttribute(DllName, EntryPoint = "TMCC_RegisterConnectCallBack", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public static extern void TMCC_RegisterConnectCallBack(System.IntPtr hTmCC, TMCC_CONNECT_CALLBACK pCallBack, System.IntPtr context);


    /// Return Type: void
    ///hTmCC: HANDLE->void*
    ///pCallBack: TMCC_DATAREAD_CALLBACK
    ///context: void*
    [System.Runtime.InteropServices.DllImportAttribute(DllName, EntryPoint = "TMCC_RegisterDataReadCallBack", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public static extern void TMCC_RegisterDataReadCallBack(System.IntPtr hTmCC, TMCC_DATAREAD_CALLBACK pCallBack, System.IntPtr context);


    /// Return Type: void
    ///hTmCC: HANDLE->void*
    ///pCallBack: TMCC_PROGRESS_CALLBACK
    ///context: void*
    [System.Runtime.InteropServices.DllImportAttribute(DllName, EntryPoint = "TMCC_RegisterProgressCallBack", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public static extern void TMCC_RegisterProgressCallBack(System.IntPtr hTmCC, TMCC_PROGRESS_CALLBACK pCallBack, System.IntPtr context);


    /// Return Type: int
    ///hTmCC: HANDLE->void*
    ///dwTime: unsigned int
    [System.Runtime.InteropServices.DllImportAttribute(DllName, EntryPoint = "TMCC_SetTimeOut", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public static extern int TMCC_SetTimeOut(System.IntPtr hTmCC, uint dwTime);


    /// Return Type: unsigned int
    ///hTmCC: HANDLE->void*
    [System.Runtime.InteropServices.DllImportAttribute(DllName, EntryPoint = "TMCC_GetTimeOut", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public static extern uint TMCC_GetTimeOut(System.IntPtr hTmCC);


    /// Return Type: int
    ///hTmCC: HANDLE->void*
    ///bAutoConnect: BOOL->int
    [System.Runtime.InteropServices.DllImportAttribute(DllName, EntryPoint = "TMCC_SetAutoReConnect", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public static extern int TMCC_SetAutoReConnect(System.IntPtr hTmCC, [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.Bool)] bool bAutoConnect);


    /// Return Type: BOOL->int
    ///hTmCC: HANDLE->void*
    [System.Runtime.InteropServices.DllImportAttribute(DllName, EntryPoint = "TMCC_GetAutoReConnect", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
    [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.Bool)]
    public static extern bool TMCC_GetAutoReConnect(System.IntPtr hTmCC);


    /// Return Type: BOOL->int
    ///hTmCC: HANDLE->void*
    [System.Runtime.InteropServices.DllImportAttribute(DllName, EntryPoint = "TMCC_IsConnect", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
    [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.Bool)]
    public static extern bool TMCC_IsConnect(System.IntPtr hTmCC);


    /// Return Type: int
    ///hTmCC: HANDLE->void*
    ///pConnectInfo: tmConnectInfo_t*
    ///bSync: BOOL->int
    [System.Runtime.InteropServices.DllImportAttribute(DllName, EntryPoint = "TMCC_Connect", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public static extern int TMCC_Connect(System.IntPtr hTmCC, ref tmConnectInfo_t pConnectInfo, [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.Bool)] bool bSync);


    /// Return Type: int
    ///hTmC: HANDLE->void*
    [System.Runtime.InteropServices.DllImportAttribute(DllName, EntryPoint = "TMCC_DisConnect", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public static extern int TMCC_DisConnect(System.IntPtr hTmC);


    /// Return Type: int
    ///hTmCC: HANDLE->void*
    ///pCommandInfo: tmCommandInfo_t*
    [System.Runtime.InteropServices.DllImportAttribute(DllName, EntryPoint = "TMCC_SetConfig", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public static extern int TMCC_SetConfig(System.IntPtr hTmCC, ref tmCommandInfo_t pCommandInfo);


    /// Return Type: int
    ///hTmCC: HANDLE->void*
    ///pCommandInfo: tmCommandInfo_t*
    [System.Runtime.InteropServices.DllImportAttribute(DllName, EntryPoint = "TMCC_GetConfig", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public static extern int TMCC_GetConfig(System.IntPtr hTmCC, ref tmCommandInfo_t pCommandInfo);


    /// Return Type: int
    ///hTmCC: HANDLE->void*
    [System.Runtime.InteropServices.DllImportAttribute(DllName, EntryPoint = "TMCC_SaveConfig", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public static extern int TMCC_SaveConfig(System.IntPtr hTmCC);


    /// Return Type: int
    ///hTmCC: HANDLE->void*
    [System.Runtime.InteropServices.DllImportAttribute(DllName, EntryPoint = "TMCC_RestoreConfig", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public static extern int TMCC_RestoreConfig(System.IntPtr hTmCC);


    /// Return Type: int
    ///hTmCC: HANDLE->void*
    [System.Runtime.InteropServices.DllImportAttribute(DllName, EntryPoint = "TMCC_Reboot", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public static extern int TMCC_Reboot(System.IntPtr hTmCC);


    /// Return Type: int
    ///hTmCC: HANDLE->void*
    [System.Runtime.InteropServices.DllImportAttribute(DllName, EntryPoint = "TMCC_ShutDown", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public static extern int TMCC_ShutDown(System.IntPtr hTmCC);


    /// Return Type: int
    ///hTmCC: HANDLE->void*
    ///lpszFileName: char*
    [System.Runtime.InteropServices.DllImportAttribute(DllName, EntryPoint = "TMCC_UpgradeSystem", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public static extern int TMCC_UpgradeSystem(System.IntPtr hTmCC, [System.Runtime.InteropServices.InAttribute()] [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string lpszFileName);


    /// Return Type: int
    ///dwListenPort: unsigned int
    [System.Runtime.InteropServices.DllImportAttribute(DllName, EntryPoint = "TMCC_StartListen", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public static extern int TMCC_StartListen(uint dwListenPort);


    /// Return Type: int
    [System.Runtime.InteropServices.DllImportAttribute(DllName, EntryPoint = "TMCC_StopListen", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public static extern int TMCC_StopListen();


    /// Return Type: int
    [System.Runtime.InteropServices.DllImportAttribute(DllName, EntryPoint = "TMCC_RefreshEnumServer", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public static extern int TMCC_RefreshEnumServer();


    /// Return Type: int
    [System.Runtime.InteropServices.DllImportAttribute(DllName, EntryPoint = "TMCC_PtzOpen", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public static extern int TMCC_PtzOpen(System.IntPtr hTmCC, int iChannel, bool bLock);

    /// Return Type: int
    ///hTmCC: HANDLE->void*
    [System.Runtime.InteropServices.DllImportAttribute(DllName, EntryPoint = "TMCC_PtzClose", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public static extern int TMCC_PtzClose(System.IntPtr hTmCC);


    /// Return Type: int
    ///hTmCC: HANDLE->void*
    ///iChannel: int
    [System.Runtime.InteropServices.DllImportAttribute(DllName, EntryPoint = "TMCC_PtzLock", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public static extern int TMCC_PtzLock(System.IntPtr hTmCC, int iChannel);


    /// Return Type: int
    ///hTmCC: HANDLE->void*
    ///iChannel: int
    [System.Runtime.InteropServices.DllImportAttribute(DllName, EntryPoint = "TMCC_PtzUnLock", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public static extern int TMCC_PtzUnLock(System.IntPtr hTmCC, int iChannel);


    /// Return Type: int
    ///hTmCC: HANDLE->void*
    ///dwPTZCommand: unsigned int
    ///dwPTZControl: unsigned int
    ///dwSpeed: unsigned int
    [System.Runtime.InteropServices.DllImportAttribute(DllName, EntryPoint = "TMCC_PtzControl", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public static extern int TMCC_PtzControl(System.IntPtr hTmCC, uint dwPTZCommand, uint dwPTZControl, uint dwSpeed);


    /// Return Type: int
    ///hTmCC: HANDLE->void*
    ///pPTZCodeBuf: BYTE*
    ///iBufSize: int
    [System.Runtime.InteropServices.DllImportAttribute(DllName, EntryPoint = "TMCC_PtzTrans", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public static extern int TMCC_PtzTrans(System.IntPtr hTmCC, ref byte pPTZCodeBuf, int iBufSize);


    /// Return Type: int
    ///hTmCC: HANDLE->void*
    ///dwPTZPresetCmd: unsigned int
    ///dwPresetIndex: unsigned int
    ///dwSpeed: unsigned int
    [System.Runtime.InteropServices.DllImportAttribute(DllName, EntryPoint = "TMCC_PtzPreset", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public static extern int TMCC_PtzPreset(System.IntPtr hTmCC, uint dwPTZPresetCmd, uint dwPresetIndex, uint dwSpeed);


    /// Return Type: void
    ///hTmCC: HANDLE->void*
    ///pCallBack: TMCC_SERIALDATA_CALLBACK
    ///context: void*
    [System.Runtime.InteropServices.DllImportAttribute(DllName, EntryPoint = "TMCC_RegisterSerialDataReadCallBack", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public static extern void TMCC_RegisterSerialDataReadCallBack(System.IntPtr hTmCC, TMCC_SERIALDATA_CALLBACK pCallBack, System.IntPtr context);


    /// Return Type: int
    ///hTmCC: HANDLE->void*
    ///iSerialPort: int
    [System.Runtime.InteropServices.DllImportAttribute(DllName, EntryPoint = "TMCC_SerialOpen", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public static extern int TMCC_SerialOpen(System.IntPtr hTmCC, int iSerialPort);


    /// Return Type: int
    ///hTmCC: HANDLE->void*
    ///iChannel: int
    ///pSendBuf: char*
    ///iBufSize: int
    [System.Runtime.InteropServices.DllImportAttribute(DllName, EntryPoint = "TMCC_SerialSend", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public static extern int TMCC_SerialSend(System.IntPtr hTmCC, int iChannel, System.IntPtr pSendBuf, int iBufSize);


    /// Return Type: int
    ///hTmCC: HANDLE->void*
    [System.Runtime.InteropServices.DllImportAttribute(DllName, EntryPoint = "TMCC_SerialClose", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public static extern int TMCC_SerialClose(System.IntPtr hTmCC);


    /// Return Type: int
    ///hTmCC: HANDLE->void*
    ///pConnectInfo: tmConnectInfo_t*
    [System.Runtime.InteropServices.DllImportAttribute(DllName, EntryPoint = "TMCC_StartVoiceCom", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public static extern int TMCC_StartVoiceCom(System.IntPtr hTmCC, ref tmConnectInfo_t pConnectInfo);


    /// Return Type: int
    ///hTmCC: HANDLE->void*
    ///iVolume: int
    [System.Runtime.InteropServices.DllImportAttribute(DllName, EntryPoint = "TMCC_SetVoiceComClientVolume", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public static extern int TMCC_SetVoiceComClientVolume(System.IntPtr hTmCC, int iVolume);


    /// Return Type: int
    ///hTmCC: HANDLE->void*
    ///fpmPerNum: float
    [System.Runtime.InteropServices.DllImportAttribute(DllName, EntryPoint = "TMCC_SetVoiceComClientVolumeZoom", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public static extern int TMCC_SetVoiceComClientVolumeZoom(System.IntPtr hTmCC, float fpmPerNum);


    /// Return Type: int
    ///hTmCC: HANDLE->void*
    ///fpmPerNum: float
    [System.Runtime.InteropServices.DllImportAttribute(DllName, EntryPoint = "TMCC_SetVoiceComClientMicZoom", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public static extern int TMCC_SetVoiceComClientMicZoom(System.IntPtr hTmCC, float fpmPerNum);


    /// Return Type: int
    ///hTmCC: HANDLE->void*
    [System.Runtime.InteropServices.DllImportAttribute(DllName, EntryPoint = "TMCC_StopVoiceCom", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public static extern int TMCC_StopVoiceCom(System.IntPtr hTmCC);


    /// Return Type: int
    ///hTmCC: HANDLE->void*
    ///pFileName: char*
    ///bPlayNum: BYTE->unsigned char
    [System.Runtime.InteropServices.DllImportAttribute(DllName, EntryPoint = "TMCC_SetPlayWaveFile", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public static extern int TMCC_SetPlayWaveFile(System.IntPtr hTmCC, System.IntPtr pFileName, byte bPlayNum);


    /// Return Type: int
    ///hTmCC: HANDLE->void*
    [System.Runtime.InteropServices.DllImportAttribute(DllName, EntryPoint = "TMCC_SaveDefaultConfig", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public static extern int TMCC_SaveDefaultConfig(System.IntPtr hTmCC);


    /// Return Type: int
    ///hTmCC: HANDLE->void*
    ///iChannel: int
    ///iIndex: int
    [System.Runtime.InteropServices.DllImportAttribute(DllName, EntryPoint = "TMCC_ClearConnectInfo", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public static extern int TMCC_ClearConnectInfo(System.IntPtr hTmCC, int iChannel, int iIndex);


    /// Return Type: int
    ///hTmCC: HANDLE->void*
    ///iChannel: int
    [System.Runtime.InteropServices.DllImportAttribute(DllName, EntryPoint = "TMCC_StartConnect", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public static extern int TMCC_StartConnect(System.IntPtr hTmCC, int iChannel);


    /// Return Type: int
    ///hTmCC: HANDLE->void*
    ///iChannel: int
    [System.Runtime.InteropServices.DllImportAttribute(DllName, EntryPoint = "TMCC_StopConnect", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public static extern int TMCC_StopConnect(System.IntPtr hTmCC, int iChannel);


    /// Return Type: int
    ///hTmCC: HANDLE->void*
    ///szSerialNumber: char*
    [System.Runtime.InteropServices.DllImportAttribute(DllName, EntryPoint = "TMCC_SetSerialNumber", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public static extern int TMCC_SetSerialNumber(System.IntPtr hTmCC, [System.Runtime.InteropServices.InAttribute()] [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string szSerialNumber);


    /// Return Type: int
    ///hTmCC: HANDLE->void*
    ///dwFlags: unsigned int
    ///buf: void*
    ///iLen: int*
    [System.Runtime.InteropServices.DllImportAttribute(DllName, EntryPoint = "TMCC_SetOtherParam", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public static extern int TMCC_SetOtherParam(System.IntPtr hTmCC, uint dwFlags, System.IntPtr buf, ref int iLen);

}
