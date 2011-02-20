using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using IntVideoSurv.Entity;
using log4net;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Threading;
using System.IO;
using System.Drawing;
using System.Runtime.InteropServices;
using videosource;
using System.Collections;

namespace IntVideoSurv.Business.HiK
{
    public class HikVideoServerCameraDriver : IComparable
    {
        private const ushort _OSD_BASE = 0x9000;
        private const ushort _OSD_YEAR4 = _OSD_BASE + 0;
        private const ushort _OSD_YEAR2 = _OSD_BASE + 1;
        private const ushort _OSD_MONTH3 = _OSD_BASE + 2;
        private const ushort _OSD_MONTH2 = _OSD_BASE + 3;
        private const ushort _OSD_DAY = _OSD_BASE + 4;
        private const ushort _OSD_WEEK3 = _OSD_BASE + 5;
        private const ushort _OSD_CWEEK1 = _OSD_BASE + 6;
        private const ushort _OSD_HOUR24 = _OSD_BASE + 7;
        private const ushort _OSD_HOUR12 = _OSD_BASE + 8;
        private const ushort _OSD_MINUTE = _OSD_BASE + 9;
        private const ushort _OSD_SECOND = _OSD_BASE + 10;
        private Thread thread = null;
        private ManualResetEvent stopEvent = null;
        private static RealDataCallBack_V30 stream_callback;
        private static HCNetSDK.SerialDataCallBack serial_callback;
        private IntPtr ChannelHandle;
        private byte[] FileHeader;
        //文件头长度
        private int FileHeaderLen = 0;
        //是否开始捕获文件 0 未启用 1 启用
        private volatile int CaptureState;
        private static IMAGE_STREAM_CALLBACK image_CallBack;
        string videoFile = "";
        uint endCode = 0x00000002;
        public bool IsValidChannel { get; set; }

        Database db;// = DatabaseFactory.CreateDatabase();
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private DeviceInfo _deviceInfo = null;
        private CameraInfo _cameraInfo = null;
        private int m_lPlayHandle = -1;
        public static Dictionary<int,int> ListSerialHandle = new Dictionary<int, int>();
        public static string AlarmSites;
        private string TempPath = "";

        public bool Running
        {
            get
            {
                if (thread != null)
                {
                    if (thread.Join(0) == false)
                        return true;
                    Free();
                }
                return false;
            }
        }
        public CameraInfo CurrentCamera
        {
            get
            {
                return _cameraInfo;
            }
            set
            {
                _cameraInfo = value;

            }
        }
        /// <summary>
        /// 将数据流写入视频文件
        /// </summary>
        /// <param name="length"></param>
        /// <param name="dataBuf"></param>
        private void WriterVideoCapture(int length, IntPtr dataBuf)
        {
            if (CaptureState == 1)
            {
                using (FileStream fs = new FileStream(videoFile, FileMode.Append))
                {
                    BinaryWriter bw = new BinaryWriter(fs);

                    byte[] byteBuf = new byte[length];
                    Marshal.Copy(dataBuf, byteBuf, 0, length);
                    bw.Write(byteBuf);
                    bw.Flush();
                    bw.Close();
                    byteBuf = null;
                }
            }
        }

        public HikVideoServerCameraDriver(DeviceInfo deviceInfo)
        {
            log.Debug("start");
            _deviceInfo = deviceInfo;

        }
        int m_lPort = -1;
        Dictionary<int, IntPtr> ListPorts = null;
        public static Dictionary<int, DefaultCardOut> ListDefaultCardOut;
        IntPtr hCardHandle = IntPtr.Zero;
        /*
         
            1、SetDefaultVideoStandard设置视频制式

            2、用HW_InitDecDevice初始化设备

            3、GetDecodeChannelCount()获取解码通道个数

            4、GetDisplayChannelCount()获取显示通道个数

            5、SetDisplayRegion()设置区域

            6、HW_SetDisplayPara()设置视频输出参数

            7、SetDecoderVideoExtOutput设置解码通道外部输出

            8、HW_OpenStream打开流文件头

            9、HW_Play播放

            10、HW_InputData输入数据

         */
        private static bool CardInitiOK;
        private static int TotalDecodeChannels;
        private static int TotalDisplayChannels;
        private static int CurrentDecodeChannelCount;
        private static int CurrentDisplayChannelCount;
        private static int CurrentDecodeChannel;
        public static void InitDecodeCard()
        {
            TotalDecodeChannels = (int)HikVisionSDK.GetDecodeChannelCount();
            TotalDisplayChannels = (int)HikVisionSDK.GetDisplayChannelCount();
            CurrentDecodeChannelCount = 0;
            CurrentDisplayChannelCount = 0;
            _listDecodeChannel = new Dictionary<int, DecodeChannel>(TotalDecodeChannels);
            for (int i = 0; i < TotalDecodeChannels; i++)
            {
                DecodeChannel dc = new DecodeChannel();
                dc.Id = i;
                _listDecodeChannel.Add(i, dc);
            }

        }
        private DecodeChannel FindOneFreeDecodeChannel()
        {
            //找得到就找

            foreach (var VARIABLE in _listDecodeChannel)
            {
                if (VARIABLE.Value.IsUsed() == false)
                {
                    return VARIABLE.Value;
                }
            }
            //找不到就释放以前的解码通道

            foreach (var VARIABLE in _listDecodeChannel)
            {
                if ((VARIABLE.Value.CurrentCardOutType!=CurrentCardOutType)||(VARIABLE.Value.CurrentCardOutId!=CurrentCardOutId))
                {
                    foreach (var VARIABLE2 in _listDecodeChannel)
                    {
                        if ((VARIABLE2.Value.CurrentCardOutType == VARIABLE.Value.CurrentCardOutType) && (VARIABLE2.Value.CurrentCardOutId == VARIABLE.Value.CurrentCardOutId))
                        {
                            CloseHandle(VARIABLE2.Value.Handle);
                            DecodeChannel decodeChannel = new DecodeChannel();
                            decodeChannel.Id = VARIABLE2.Key;
                            _listDecodeChannel[decodeChannel.Id] = decodeChannel;
                            return decodeChannel;
                        }
                    }
                }
            }
            //再找不到就从编号0的通道开始循环使用
            DecodeChannel dc = new DecodeChannel();
            dc.Id = CurrentDecodeChannel++;
            _listDecodeChannel[dc.Id] = dc;
            if (CurrentDecodeChannel >= TotalDecodeChannels)
            {
                CurrentDecodeChannel = 0;
            }
            return _listDecodeChannel[dc.Id];
            
        }
        public void g_RealDataCallBack_V30(int lRealHandle, uint dwDataType, IntPtr pBuffer, uint dwBufSize, IntPtr pUser)
        {
            bool iRet = false;
            bool temp;
            int iRtn = -1;
            IntPtr CurrentCardHandle = IntPtr.Zero;
            try
            {

                switch (dwDataType)
                {
                    case 1: //NET_DVR_SYSHEAD:

                        #region soft decode
                        HikPlayer.PlayM4_GetPort(ref m_lPort);
                        if (dwBufSize > 0)
                        {
                            temp = HikPlayer.PlayM4_SetStreamOpenMode(m_lPort, 0);
                            temp = HikPlayer.PlayM4_OpenStream(m_lPort, pBuffer, dwBufSize, 1024 * 1024);
                            temp = HikPlayer.PlayM4_Play(m_lPort, _cameraInfo.Handle);
                            temp = HikPlayer.PlayM4_SetDisplayBuf(m_lPort, 15);
                            temp = HikPlayer.PlayM4_SetOverlayMode(m_lPort, false, 0);
                            ListPorts.Add(m_lPort, _cameraInfo.Handle);
                        }
                        #endregion

                        #region card decode output to TV

                        foreach (var defaultCardOut in ListDefaultCardOut)
                        {
                            if (defaultCardOut.Value.CameraId == _cameraInfo.CameraId)
                            {
                                DecodeChannel decodeChannel = FindOneFreeDecodeChannel();

                                if (decodeChannel != null)
                                {
                                    // iRtn =  HikVisionSDK.HW_InitDirectDraw(item.Value, 0x00000010);
                                    iRtn = HikVisionSDK.SetDecoderVideoExtOutput(decodeChannel.Id, 0, true, defaultCardOut.Value.DisplayChannelId, defaultCardOut.Value.DisplaySplitScreenNo, 0);
                                    if (iRtn != 0)
                                    {
                                        log.Error(string.Format("HW_SetDisplayPara {0}", iRtn));
                                        ListPorts[m_lPort] = IntPtr.Zero;
                                        return;
                                    }
                                    iRtn = HikVisionSDK.HW_InitDirectDraw(_cameraInfo.Handle, 0x00000010);
                                    iRtn = HikVisionSDK.HW_ChannelOpen(decodeChannel.Id, ref CurrentCardHandle);
                                    decodeChannel.Handle = CurrentCardHandle;
                                    if (iRtn != 0)
                                    {
                                        log.Error(string.Format("HW_ChannelOpen err[%x]", iRtn));
                                        ListPorts[m_lPort] = IntPtr.Zero;
                                        return;
                                    }

                                    iRtn = HikVisionSDK.HW_SetStreamOpenMode(CurrentCardHandle, 2);
                                    if (iRtn != 0)
                                    {
                                        log.Error(string.Format("HW_SetStreamOpenMode {0}", iRtn));
                                        ListPorts[m_lPort] = IntPtr.Zero;
                                        return;

                                    }

                                    DISPLAY_PARA struCardPlayInfo = new DISPLAY_PARA();

                                    struCardPlayInfo.nLeft = 0;
                                    struCardPlayInfo.nTop = 0;
                                    struCardPlayInfo.nWidth = 704;
                                    struCardPlayInfo.nHeight = 576;
                                    struCardPlayInfo.bToScreen = 0;
                                    struCardPlayInfo.bToVideoOut = 1;
                                    iRtn = HikVisionSDK.HW_SetDisplayPara(CurrentCardHandle, ref struCardPlayInfo);
                                    if (iRtn != 0)
                                    {
                                        log.Error(string.Format("HW_SetDisplayPara {0}", iRtn));
                                        ListPorts[m_lPort] = IntPtr.Zero;
                                        return;
                                    }

                                    iRtn = HikVisionSDK.HW_OpenStream(CurrentCardHandle, pBuffer, dwBufSize);
                                    if (iRtn != 0)
                                    {
                                        log.Error(string.Format("HW_OpenStream err {0}", iRtn));
                                        ListPorts[m_lPort] = IntPtr.Zero;
                                        return;

                                    }
                                    iRtn = HikVisionSDK.HW_Play(CurrentCardHandle);
                                    //start to play
                                    CardInitiOK = true;
                                    if (iRtn != 0)
                                    {
                                        log.Error(string.Format("HW_Play err {0}", iRtn));

                                        ListPorts[m_lPort] = IntPtr.Zero;
                                        return;

                                    }

                                    decodeChannel.CurrentCardOutType = CurrentCardOutType;
                                    decodeChannel.CurrentCardOutId = CurrentCardOutId;
                                    _listDecodeChannel.Remove(decodeChannel.Id);
                                    _listDecodeChannel.Add(decodeChannel.Id, decodeChannel);


                                }
                            }
                        }

                        #endregion
                        break;

                    case 4://NET_DVR_STD_VIDEODATA:
                    case 5://NET_DVR_STD_AUDIODATA:
                    case 2://NET_DVR_STREAMDATA:

                        #region ltyong暂时注释
                        //if (dwBufSize > 0 && ListPorts.Count>0)
                        //{
                        //    foreach (KeyValuePair<int,IntPtr> item in ListPorts)
                        //    {
                        //        #region soft decode
                        //        m_lPort = item.Key;
                        //        if (!HikPlayer.PlayM4_InputData(m_lPort, pBuffer, dwBufSize))
                        //        {
                        //        }
                        //        #endregion
                        //        #region card decode output to TV
                        //        hCardHandle = item.Value;
                        //        if (hCardHandle != IntPtr.Zero)
                        //        {
                        //            iRtn = HikVisionSDK.HW_InputData(hCardHandle, pBuffer, dwBufSize);
                        //            if (iRtn <= 0)
                        //            {
                        //                log.Error(string.Format("HW_InputData err {0}", iRtn));

                        //            }
                        //        }
                        //        #endregion

                        //    }

                        //}
                        #endregion

                        #region soft decode
                        if (dwBufSize > 0 && ListPorts.Count > 0)
                        {
                            foreach (KeyValuePair<int, IntPtr> item in ListPorts)
                            {

                                m_lPort = item.Key;
                                bool success = HikPlayer.PlayM4_InputData(m_lPort, pBuffer, dwBufSize);
                                if (!success)
                                {
                                    // Trace.WriteLine(DateTime.Now + "\t:HikPlayer.PlayM4_InputData failed!");
                                    log.Error(string.Format("HikPlayer.PlayM4_InputData failed!"));
                                }
                            }
                        }
                        #endregion

                        #region card decode output to TV
                        if (dwBufSize > 0)
                        {
                            foreach (var item in _listDecodeChannel)
                            {
                                if ((CardInitiOK) && item.Value.IsUsed())
                                {
                                    iRtn = HikVisionSDK.HW_InputData(item.Value.Handle, pBuffer, dwBufSize);
                                    //Trace.WriteLine(DateTime.Now + "\t:HikVisionSDK.HW_InputData 返回值:" + iRtn);
                                    if (iRtn <= 0)
                                    {
                                        log.Error(string.Format("HW_InputData err {0}", iRtn));

                                    }
                                }
                            }
                        }

                        #endregion


                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void g_DefaultRealDataCallBack_V30(int lRealHandle, uint dwDataType, IntPtr pBuffer, uint dwBufSize, IntPtr pUser)
        {
            bool iRet = false;
            bool temp;
            int iRtn = -1;
            IntPtr CurrentCardHandle = IntPtr.Zero;
            try
            {

                switch (dwDataType)
                {
                    case 1: //NET_DVR_SYSHEAD:

                        #region soft decode
                        HikPlayer.PlayM4_GetPort(ref m_lPort);
                        if (dwBufSize > 0)
                        {
                            temp = HikPlayer.PlayM4_SetStreamOpenMode(m_lPort, 0);
                            temp = HikPlayer.PlayM4_OpenStream(m_lPort, pBuffer, dwBufSize, 1024 * 1024);
                            temp = HikPlayer.PlayM4_Play(m_lPort, _cameraInfo.Handle);
                            temp = HikPlayer.PlayM4_SetDisplayBuf(m_lPort, 15);
                            temp = HikPlayer.PlayM4_SetOverlayMode(m_lPort, false, 0);
                            ListPorts.Add(m_lPort, _cameraInfo.Handle);
                        }
                        #endregion

                        #region card decode output to TV

                        foreach (var defaultCardOut in ListDefaultCardOut)
                        {
                            if (defaultCardOut.Value.CameraId == _cameraInfo.CameraId)
                            {
                                DecodeChannel decodeChannel = FindOneFreeDecodeChannel();

                                if (decodeChannel != null)
                                {
                                    iRtn = HikVisionSDK.SetDecoderVideoExtOutput(decodeChannel.Id, 0, true, defaultCardOut.Value.DisplayChannelId, defaultCardOut.Value.DisplaySplitScreenNo, 0);
                                    if (iRtn != 0)
                                    {
                                        log.Error(string.Format("HW_SetDisplayPara {0}", iRtn));
                                        ListPorts[m_lPort] = IntPtr.Zero;
                                        return;
                                    }
                                    iRtn = HikVisionSDK.HW_InitDirectDraw(_cameraInfo.Handle, 0x00000010);
                                    iRtn = HikVisionSDK.HW_ChannelOpen(decodeChannel.Id, ref CurrentCardHandle);
                                    decodeChannel.Handle = CurrentCardHandle;
                                    if (iRtn != 0)
                                    {
                                        log.Error(string.Format("HW_ChannelOpen err[%x]", iRtn));

                                        ListPorts[m_lPort] = IntPtr.Zero;
                                        return;
                                    }

                                    iRtn = HikVisionSDK.HW_SetStreamOpenMode(CurrentCardHandle, 2);
                                    if (iRtn != 0)
                                    {
                                        log.Error(string.Format("HW_SetStreamOpenMode {0}", iRtn));

                                        ListPorts[m_lPort] = IntPtr.Zero;
                                        return;

                                    }

                                    DISPLAY_PARA struCardPlayInfo = new DISPLAY_PARA();

                                    struCardPlayInfo.nLeft = 0;
                                    struCardPlayInfo.nTop = 0;
                                    struCardPlayInfo.nWidth = 704;
                                    struCardPlayInfo.nHeight = 576;
                                    struCardPlayInfo.bToScreen = 0;
                                    struCardPlayInfo.bToVideoOut = 1;
                                    iRtn = HikVisionSDK.HW_SetDisplayPara(CurrentCardHandle, ref struCardPlayInfo);
                                    if (iRtn != 0)
                                    {
                                        log.Error(string.Format("HW_SetDisplayPara {0}", iRtn));

                                        ListPorts[m_lPort] = IntPtr.Zero;
                                        return;
                                    }

                                    iRtn = HikVisionSDK.HW_OpenStream(CurrentCardHandle, pBuffer, dwBufSize);
                                    if (iRtn != 0)
                                    {
                                        log.Error(string.Format("HW_OpenStream err {0}", iRtn));

                                        ListPorts[m_lPort] = IntPtr.Zero;
                                        return;

                                    }
                                    iRtn = HikVisionSDK.HW_Play(CurrentCardHandle);
                                    //start to play
                                    CardInitiOK = true;
                                    if (iRtn != 0)
                                    {
                                        log.Error(string.Format("HW_Play err {0}", iRtn));

                                        ListPorts[m_lPort] = IntPtr.Zero;
                                        return;

                                    }
                                    decodeChannel.CurrentCardOutType = CurrentCardOutType;
                                    decodeChannel.CurrentCardOutId = CurrentCardOutId;
                                    _listDecodeChannel.Remove(decodeChannel.Id);
                                    _listDecodeChannel.Add(decodeChannel.Id, decodeChannel);
                                    AlUsedDisplayChannelInfo.Add(new UsedDisplayChannelInfo { DisplayChannelId = defaultCardOut.Value.DisplayChannelId, DisplaySplitScreenNo = defaultCardOut.Value.DisplaySplitScreenNo, DefaultDisplayCameraId = CurrentCardOutId, Handle = CurrentCardHandle });
                                }
                            }
                        }

                        #endregion
                        break;

                    case 4://NET_DVR_STD_VIDEODATA:
                    case 5://NET_DVR_STD_AUDIODATA:
                    case 2://NET_DVR_STREAMDATA:

                        #region soft decode
                        if (dwBufSize > 0 && ListPorts.Count > 0)
                        {
                            foreach (KeyValuePair<int, IntPtr> item in ListPorts)
                            {

                                int curPort = item.Key;
                                bool success = HikPlayer.PlayM4_InputData(curPort, pBuffer, dwBufSize);
                                if (!success)
                                {
                                    // Trace.WriteLine(DateTime.Now + "\t:HikPlayer.PlayM4_InputData failed!");
                                    log.Error(string.Format("HikPlayer.PlayM4_InputData failed!"));
                                }
                            }
                        }
                        #endregion

                        #region card decode output to TV
                        if (dwBufSize > 0)
                        {
                            foreach (var item in _listDecodeChannel)
                            {
                                if ((CardInitiOK) && item.Value.IsUsed())
                                {
                                    iRtn = HikVisionSDK.HW_InputData(item.Value.Handle, pBuffer, dwBufSize);
                                    if (iRtn <= 0)
                                    {
                                        log.Error(string.Format("HW_InputData err {0}", iRtn));

                                    }
                                }
                            }
                        }

                        #endregion


                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }


        public void g_ProgSwitchRealDataCallBack_V30(int lRealHandle, uint dwDataType, IntPtr pBuffer, uint dwBufSize, IntPtr pUser)
        {
            bool iRet = false;
            bool temp;
            int iRtn = -1;
            IntPtr CurrentCardHandle = IntPtr.Zero;
            try
            {

                switch (dwDataType)
                {
                    case 1: //NET_DVR_SYSHEAD:


                        if (ListPorts.Count == 0)
                        {
                            if (_cameraInfo.ListOutputTarget != null)
                            {
                                foreach (DisplayHandlePair item in _cameraInfo.ListOutputTarget)
                                {

                                    #region soft decode
                                    HikPlayer.PlayM4_GetPort(ref m_lPort);
                                    if (dwBufSize > 0)
                                    {
                                        temp = HikPlayer.PlayM4_SetStreamOpenMode(m_lPort, 0);
                                        temp = HikPlayer.PlayM4_OpenStream(m_lPort, pBuffer, dwBufSize, 1024 * 1024);
                                        temp = HikPlayer.PlayM4_Play(m_lPort, item.Handle);
                                        temp = HikPlayer.PlayM4_SetDisplayBuf(m_lPort, 15);
                                        temp = HikPlayer.PlayM4_SetOverlayMode(m_lPort, false, 0);
                                        ListPorts.Add(m_lPort, item.Handle);
                                    }
                                    #endregion

                                    #region card decode output to TV
                                    DecodeChannel decodeChannel = FindOneFreeDecodeChannel();
                                    if (decodeChannel != null)
                                    {
                                        UsedDisplayChannelInfo udci = IsDisplayScreenNoOccupied(item.DisplayChannelId, item.DisplaySplitScreenNo);
                                        if (udci != null)
                                        {
                                            ReleaseUsedScreen(udci);
                                        }
                                        iRtn = HikVisionSDK.SetDecoderVideoExtOutput(decodeChannel.Id, 0, true, item.DisplayChannelId, item.DisplaySplitScreenNo, 0);
                                        if (iRtn != 0)
                                        {
                                            log.Error(string.Format("HW_SetDisplayPara {0}", iRtn));
                                            continue;
                                        }
                                        iRtn = HikVisionSDK.HW_InitDirectDraw(_cameraInfo.Handle, 0x00000010);
                                        iRtn = HikVisionSDK.HW_ChannelOpen(decodeChannel.Id, ref CurrentCardHandle);
                                        decodeChannel.Handle = CurrentCardHandle;
                                        if (iRtn != 0)
                                        {
                                            log.Error(string.Format("HW_ChannelOpen err[%x]", iRtn));
                                            ListPorts[m_lPort] = IntPtr.Zero;
                                            continue;
                                        }
                                        iRtn = HikVisionSDK.HW_SetStreamOpenMode(CurrentCardHandle, 2);
                                        if (iRtn != 0)
                                        {
                                            log.Error(string.Format("HW_SetStreamOpenMode {0}", iRtn));
                                            ListPorts[m_lPort] = IntPtr.Zero;
                                            continue;
                                        }
                                        DISPLAY_PARA struCardPlayInfo = new DISPLAY_PARA();
                                        struCardPlayInfo.nLeft = 0;
                                        struCardPlayInfo.nTop = 0;
                                        struCardPlayInfo.nWidth = 704;
                                        struCardPlayInfo.nHeight = 576;
                                        struCardPlayInfo.bToScreen = 0;
                                        struCardPlayInfo.bToVideoOut = 1;
                                        iRtn = HikVisionSDK.HW_SetDisplayPara(CurrentCardHandle, ref struCardPlayInfo);
                                        if (iRtn != 0)
                                        {
                                            log.Error(string.Format("HW_SetDisplayPara {0}", iRtn));

                                            ListPorts[m_lPort] = IntPtr.Zero;
                                            continue;
                                        }

                                        iRtn = HikVisionSDK.HW_OpenStream(CurrentCardHandle, pBuffer, dwBufSize);
                                        if (iRtn != 0)
                                        {
                                            log.Error(string.Format("HW_OpenStream err {0}", iRtn));

                                            ListPorts[m_lPort] = IntPtr.Zero;
                                            continue;
                                        }
                                        iRtn = HikVisionSDK.HW_Play(CurrentCardHandle);

                                        CardInitiOK = true;
                                        if (iRtn != 0)
                                        {
                                            log.Error(string.Format("HW_Play err {0}", iRtn));

                                            ListPorts[m_lPort] = IntPtr.Zero;
                                            continue;

                                        }
                                        decodeChannel.CurrentCardOutId = CurrentCardOutId;
                                        decodeChannel.CurrentCardOutType = CurrentCardOutType;
                                        _listDecodeChannel.Remove(decodeChannel.Id);
                                        _listDecodeChannel.Add(decodeChannel.Id, decodeChannel);
                                        AlUsedDisplayChannelInfo.Add(new UsedDisplayChannelInfo { DisplayChannelId = item.DisplayChannelId, DisplaySplitScreenNo = item.DisplaySplitScreenNo, SynGroupId = CurrentCardOutId, Handle = CurrentCardHandle });

                                    }
                                }
                            }
                        }
                        #endregion

                        break;

                    case 4://NET_DVR_STD_VIDEODATA:
                    case 5://NET_DVR_STD_AUDIODATA:
                    case 2://NET_DVR_STREAMDATA:

                        #region soft decode
                        if (dwBufSize > 0 && ListPorts.Count > 0)
                        {
                            foreach (KeyValuePair<int, IntPtr> item in ListPorts)
                            {

                                int curPort = item.Key;
                                bool success = HikPlayer.PlayM4_InputData(curPort, pBuffer, dwBufSize);
                                if (!success)
                                {
                                    // Trace.WriteLine(DateTime.Now + "\t:HikPlayer.PlayM4_InputData failed!");
                                    log.Error(string.Format("HikPlayer.PlayM4_InputData failed!"));
                                }
                            }
                        }
                        #endregion

                        #region card decode output to TV
                        if (dwBufSize > 0)
                        {
                            foreach (var item in _listDecodeChannel)
                            {
                                if ((CardInitiOK) && item.Value.IsUsed())
                                {
                                    iRtn = HikVisionSDK.HW_InputData(item.Value.Handle, pBuffer, dwBufSize);
                                    if (iRtn <= 0)
                                    {
                                        log.Error(string.Format("HW_InputData err {0}", iRtn));

                                    }
                                }
                            }
                        }

                        #endregion


                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void g_GroupSwitchRealDataCallBack_V30(int lRealHandle, uint dwDataType, IntPtr pBuffer, uint dwBufSize, IntPtr pUser)
        {
            bool iRet = false;
            bool temp;
            int iRtn = -1;
            IntPtr CurrentCardHandle = IntPtr.Zero;
            try
            {

                switch (dwDataType)
                {
                    case 1: //NET_DVR_SYSHEAD:

                        #region soft decode
                        HikPlayer.PlayM4_GetPort(ref m_lPort);
                        if (dwBufSize > 0)
                        {
                            temp = HikPlayer.PlayM4_SetStreamOpenMode(m_lPort, 0);
                            temp = HikPlayer.PlayM4_OpenStream(m_lPort, pBuffer, dwBufSize, 1024 * 1024);
                            temp = HikPlayer.PlayM4_Play(m_lPort, _cameraInfo.Handle);
                            temp = HikPlayer.PlayM4_SetDisplayBuf(m_lPort, 15);
                            temp = HikPlayer.PlayM4_SetOverlayMode(m_lPort, false, 0);
                            ListPorts.Add(m_lPort, _cameraInfo.Handle);
                        }
                        #endregion

                        #region card decode output to TV

                        foreach (var defaultCardOut in ListDefaultCardOut)
                        {
                            if (defaultCardOut.Value.CameraId == _cameraInfo.CameraId)
                            {
                                DecodeChannel decodeChannel = FindOneFreeDecodeChannel();

                                if (decodeChannel != null)
                                {
                                    iRtn = HikVisionSDK.SetDecoderVideoExtOutput(decodeChannel.Id, 0, true, defaultCardOut.Value.DisplayChannelId, defaultCardOut.Value.DisplaySplitScreenNo, 0);
                                    if (iRtn != 0)
                                    {
                                        log.Error(string.Format("HW_SetDisplayPara {0}", iRtn));

                                        ListPorts[m_lPort] = IntPtr.Zero;
                                        return;
                                    }
                                    iRtn = HikVisionSDK.HW_InitDirectDraw(_cameraInfo.Handle, 0x00000010);
                                    iRtn = HikVisionSDK.HW_ChannelOpen(decodeChannel.Id, ref CurrentCardHandle);
                                    decodeChannel.Handle = CurrentCardHandle;
                                    if (iRtn != 0)
                                    {
                                        log.Error(string.Format("HW_ChannelOpen err[%x]", iRtn));

                                        ListPorts[m_lPort] = IntPtr.Zero;
                                        return;
                                    }

                                    iRtn = HikVisionSDK.HW_SetStreamOpenMode(CurrentCardHandle, 2);
                                    if (iRtn != 0)
                                    {
                                        log.Error(string.Format("HW_SetStreamOpenMode {0}", iRtn));

                                        ListPorts[m_lPort] = IntPtr.Zero;
                                        return;

                                    }

                                    DISPLAY_PARA struCardPlayInfo = new DISPLAY_PARA();

                                    struCardPlayInfo.nLeft = 0;
                                    struCardPlayInfo.nTop = 0;
                                    struCardPlayInfo.nWidth = 704;
                                    struCardPlayInfo.nHeight = 576;
                                    struCardPlayInfo.bToScreen = 0;
                                    struCardPlayInfo.bToVideoOut = 1;
                                    iRtn = HikVisionSDK.HW_SetDisplayPara(CurrentCardHandle, ref struCardPlayInfo);
                                    if (iRtn != 0)
                                    {
                                        log.Error(string.Format("HW_SetDisplayPara {0}", iRtn));

                                        ListPorts[m_lPort] = IntPtr.Zero;
                                        return;
                                    }

                                    iRtn = HikVisionSDK.HW_OpenStream(CurrentCardHandle, pBuffer, dwBufSize);
                                    if (iRtn != 0)
                                    {
                                        log.Error(string.Format("HW_OpenStream err {0}", iRtn));

                                        ListPorts[m_lPort] = IntPtr.Zero;
                                        return;

                                    }
                                    iRtn = HikVisionSDK.HW_Play(CurrentCardHandle);
                                    //start to play
                                    CardInitiOK = true;
                                    if (iRtn != 0)
                                    {
                                        log.Error(string.Format("HW_Play err {0}", iRtn));

                                        ListPorts[m_lPort] = IntPtr.Zero;
                                        return;

                                    }

                                    decodeChannel.CurrentCardOutId = CurrentCardOutId;
                                    decodeChannel.CurrentCardOutType = CurrentCardOutType;
                                    _listDecodeChannel.Remove(decodeChannel.Id);
                                    _listDecodeChannel.Add(decodeChannel.Id, decodeChannel);

                                }
                            }
                        }

                        #endregion
                        break;

                    case 4://NET_DVR_STD_VIDEODATA:
                    case 5://NET_DVR_STD_AUDIODATA:
                    case 2://NET_DVR_STREAMDATA:

                        #region soft decode
                        if (dwBufSize > 0 && ListPorts.Count > 0)
                        {
                            foreach (KeyValuePair<int, IntPtr> item in ListPorts)
                            {

                                m_lPort = item.Key;
                                bool success = HikPlayer.PlayM4_InputData(m_lPort, pBuffer, dwBufSize);
                                if (!success)
                                {
                                    // Trace.WriteLine(DateTime.Now + "\t:HikPlayer.PlayM4_InputData failed!");
                                    log.Error(string.Format("HikPlayer.PlayM4_InputData failed!"));
                                }
                            }
                        }
                        #endregion

                        #region card decode output to TV
                        if (dwBufSize > 0)
                        {
                            foreach (var item in _listDecodeChannel)
                            {
                                if ((CardInitiOK) && item.Value.IsUsed())
                                {
                                    iRtn = HikVisionSDK.HW_InputData(item.Value.Handle, pBuffer, dwBufSize);
                                    if (iRtn <= 0)
                                    {
                                        log.Error(string.Format("HW_InputData err {0}", iRtn));

                                    }
                                }
                            }
                        }

                        #endregion


                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void g_SynGroupRealDataCallBack_V30(int lRealHandle, uint dwDataType, IntPtr pBuffer, uint dwBufSize, IntPtr pUser)
        {
            bool iRet = false;
            bool temp;
            int iRtn = -1;
            IntPtr CurrentCardHandle = IntPtr.Zero;
            try
            {

                switch (dwDataType)
                {
                    case 1: //NET_DVR_SYSHEAD:


                        if (ListPorts.Count == 0)
                        {
                            if (_cameraInfo.ListOutputTarget != null)
                            {
                                foreach (DisplayHandlePair item in _cameraInfo.ListOutputTarget)
                                {

                                    #region soft decode
                                    HikPlayer.PlayM4_GetPort(ref m_lPort);
                                    if (dwBufSize > 0)
                                    {
                                        temp = HikPlayer.PlayM4_SetStreamOpenMode(m_lPort, 0);
                                        temp = HikPlayer.PlayM4_OpenStream(m_lPort, pBuffer, dwBufSize, 1024 * 1024);
                                        temp = HikPlayer.PlayM4_Play(m_lPort, item.Handle);
                                        temp = HikPlayer.PlayM4_SetDisplayBuf(m_lPort, 15);
                                        temp = HikPlayer.PlayM4_SetOverlayMode(m_lPort, false, 0);
                                        ListPorts.Add(m_lPort, item.Handle);
                                    }
                                    #endregion

                                    #region card decode output to TV
                                    DecodeChannel decodeChannel = FindOneFreeDecodeChannel();
                                    if (decodeChannel != null)
                                    {
                                        UsedDisplayChannelInfo udci=IsDisplayScreenNoOccupied(item.DisplayChannelId, item.DisplaySplitScreenNo);
                                        if ( udci!= null)
                                        {
                                            ReleaseUsedScreen(udci);
                                        }
                                        iRtn = HikVisionSDK.SetDecoderVideoExtOutput(decodeChannel.Id, 0, true, item.DisplayChannelId, item.DisplaySplitScreenNo, 0);
                                        if (iRtn != 0)
                                        {
                                            log.Error(string.Format("HW_SetDisplayPara {0}", iRtn));
                                            continue;
                                        }
                                        iRtn = HikVisionSDK.HW_InitDirectDraw(_cameraInfo.Handle, 0x00000010);
                                        iRtn = HikVisionSDK.HW_ChannelOpen(decodeChannel.Id, ref CurrentCardHandle);
                                        decodeChannel.Handle = CurrentCardHandle;
                                        if (iRtn != 0)
                                        {
                                            log.Error(string.Format("HW_ChannelOpen err[%x]", iRtn));
                                            ListPorts[m_lPort] = IntPtr.Zero;
                                            continue;
                                        }
                                        iRtn = HikVisionSDK.HW_SetStreamOpenMode(CurrentCardHandle, 2);
                                        if (iRtn != 0)
                                        {
                                            log.Error(string.Format("HW_SetStreamOpenMode {0}", iRtn));                                            
                                            ListPorts[m_lPort] = IntPtr.Zero;
                                            continue;
                                        }
                                        DISPLAY_PARA struCardPlayInfo = new DISPLAY_PARA();
                                        struCardPlayInfo.nLeft = 0;
                                        struCardPlayInfo.nTop = 0;
                                        struCardPlayInfo.nWidth = 704;
                                        struCardPlayInfo.nHeight = 576;
                                        struCardPlayInfo.bToScreen = 0;
                                        struCardPlayInfo.bToVideoOut = 1;
                                        iRtn = HikVisionSDK.HW_SetDisplayPara(CurrentCardHandle, ref struCardPlayInfo);
                                        if (iRtn != 0)
                                        {
                                            log.Error(string.Format("HW_SetDisplayPara {0}", iRtn));
                                            
                                            ListPorts[m_lPort] = IntPtr.Zero;
                                            continue;
                                        }

                                        iRtn = HikVisionSDK.HW_OpenStream(CurrentCardHandle, pBuffer, dwBufSize);
                                        if (iRtn != 0)
                                        {
                                            log.Error(string.Format("HW_OpenStream err {0}", iRtn));
                                            
                                            ListPorts[m_lPort] = IntPtr.Zero;
                                            continue;
                                        }
                                        iRtn = HikVisionSDK.HW_Play(CurrentCardHandle);
                                        
                                        CardInitiOK = true;
                                        if (iRtn != 0)
                                        {
                                            log.Error(string.Format("HW_Play err {0}", iRtn));
                                            
                                            ListPorts[m_lPort] = IntPtr.Zero;
                                            continue;

                                        }
                                        decodeChannel.CurrentCardOutId = CurrentCardOutId;
                                        decodeChannel.CurrentCardOutType = CurrentCardOutType;
                                        _listDecodeChannel.Remove(decodeChannel.Id);
                                        _listDecodeChannel.Add(decodeChannel.Id, decodeChannel);
                                        AlUsedDisplayChannelInfo.Add(new UsedDisplayChannelInfo { DisplayChannelId = item.DisplayChannelId, DisplaySplitScreenNo = item.DisplaySplitScreenNo, SynGroupId = CurrentCardOutId, Handle = CurrentCardHandle });

                                    }
                                }
                            }
                        }
                        #endregion
                      
                        break;

                    case 4://NET_DVR_STD_VIDEODATA:
                    case 5://NET_DVR_STD_AUDIODATA:
                    case 2://NET_DVR_STREAMDATA:

                        #region soft decode
                        if (dwBufSize > 0 && ListPorts.Count > 0)
                        {
                            foreach (KeyValuePair<int, IntPtr> item in ListPorts)
                            {

                                int curPort = item.Key;
                                bool success = HikPlayer.PlayM4_InputData(curPort, pBuffer, dwBufSize);
                                if (!success)
                                {
                                    // Trace.WriteLine(DateTime.Now + "\t:HikPlayer.PlayM4_InputData failed!");
                                    log.Error(string.Format("HikPlayer.PlayM4_InputData failed!"));
                                }
                            }
                        }
                        #endregion

                        #region card decode output to TV
                        if (dwBufSize > 0)
                        {
                            foreach (var item in _listDecodeChannel)
                            {
                                if ((CardInitiOK) && item.Value.IsUsed())
                                {
                                    iRtn = HikVisionSDK.HW_InputData(item.Value.Handle, pBuffer, dwBufSize);
                                    if (iRtn <= 0)
                                    {
                                        log.Error(string.Format("HW_InputData err {0}", iRtn));

                                    }
                                }
                            }
                        }

                        #endregion


                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public UsedDisplayChannelInfo IsDisplayScreenNoOccupied(int displayChannelId, int displayScreenNo)
        {
            foreach (UsedDisplayChannelInfo udci in AlUsedDisplayChannelInfo)
            {
                if (udci.DisplayChannelId == displayChannelId && udci.DisplaySplitScreenNo == displayScreenNo)
                {
                    return udci;
                }
            }
            return null;
        }
        
        public void g_SerialDataCallBack(int lSerialHandle, string pRecvDataBuffer, uint dwBufSize, uint dwUser)
        {
            Debug.WriteLine(DateTime.Now + " :\t" + pRecvDataBuffer);
            AlarmSites = pRecvDataBuffer;
        }
        public void ReleaseUsedScreen(UsedDisplayChannelInfo udci)
        {   //
            for(int i=0;i<AlUsedDisplayChannelInfo.Count;i++)
            {
                UsedDisplayChannelInfo tempudci = (UsedDisplayChannelInfo)(AlUsedDisplayChannelInfo[i]);
                if ((tempudci.DefaultDisplayCameraId == udci.DefaultDisplayCameraId)&&(tempudci.SynGroupId == udci.SynGroupId)&&
                    (tempudci.GroupSwitchId == udci.GroupSwitchId) && (tempudci.ProgSwitchId == udci.ProgSwitchId))
                {
                    //先释放相应的DecodeChannel
                    for (int j = 0; j < _listDecodeChannel.Count; j++)
                    {
                        DecodeChannel sc = _listDecodeChannel[i];
                        if ((sc.Handle == tempudci.Handle))
                        {
                            int tempid = sc.Id;
                            DecodeChannel newDC = new DecodeChannel();
                            newDC.Id = tempid;
                            _listDecodeChannel[newDC.Id] = newDC;
                        }
                    }
                    CloseHandle(tempudci.Handle);
                    AlUsedDisplayChannelInfo.RemoveAt(i--);
                }                
            }
        }

        private void CloseHandle(IntPtr handle)
        {
            int ret = HikVisionSDK.HW_Stop(handle);
            ret = HikVisionSDK.HW_CloseStream(handle);
            ret = HikVisionSDK.HW_ChannelClose(handle);
        }

        public static REGION_PARAM[] GetStruDisplayRegion(DISPLAY_PARA struCardPlayInfo, int regionNumber)
        {
            REGION_PARAM[] struDisplayRegion = new REGION_PARAM[regionNumber];
            int i;
            int row = (int)(Math.Sqrt(regionNumber));
            var tempDisplayRegion = new REGION_PARAM[row, row];
            int step = 64 / regionNumber;

            int nwidth = struCardPlayInfo.nWidth / row;
            int nheight = struCardPlayInfo.nHeight / row;
            for (int j = 0; j < row; j++)
            {
                for (int k = 0; k < row; k++)
                {
                    tempDisplayRegion[j, k].top = (uint)(nheight * k);
                    tempDisplayRegion[j, k].left = (uint)(nwidth * j);
                    tempDisplayRegion[j, k].width = (uint)(nwidth);
                    tempDisplayRegion[j, k].height = (uint)(nheight);
                }
            }
            for (i = 0; i < regionNumber; i++)
            {
                struDisplayRegion[i] = new REGION_PARAM();
                struDisplayRegion[i] = tempDisplayRegion[i % row, i / row];
                struDisplayRegion[i].color = (uint)(Color.FromArgb(128, i * step, 0, 0).ToArgb());
            }
            return struDisplayRegion;
        }

        public void Start(CameraInfo camera)
        {
            IsValidChannel = false;
            NET_DVR_CLIENTINFO struClientInfo;  //定义预览参数结构体
            struClientInfo.lChannel = camera.ChannelNo;
            struClientInfo.lLinkMode = 0;
            struClientInfo.hPlayWnd = IntPtr.Zero; //camera.Handle;
            int m_iSubWndIndex = 1000;  //用户数据
            struClientInfo.sMultiCastIP = "0.0.0.0";
            // 实时预览 不回调
            // m_lPlayHandle = HCNetSDK.NET_DVR_RealPlay_V30(_deviceInfo.ServiceID, ref struClientInfo, null, m_iSubWndIndex, true);
            //实时预览 回调
            _cameraInfo = camera;
            ListPorts = new Dictionary<int, IntPtr>();
            stream_callback = new RealDataCallBack_V30(g_RealDataCallBack_V30);
            GCHandle aa = GCHandle.Alloc(stream_callback);
            m_lPlayHandle = HCNetSDK.NET_DVR_RealPlay_V30(_deviceInfo.ServiceID, ref struClientInfo, stream_callback, m_iSubWndIndex, true);
            //m_lPlayHandle = HCNetSDK.NET_DVR_RealPlay_V30(_deviceInfo.ServiceID, ref struClientInfo, null, m_iSubWndIndex, true);

            camera.PlayHandle = m_lPlayHandle;
            int SerialHandle = -1;
            if(!ListSerialHandle.ContainsKey(_deviceInfo.DeviceId))
            {
                serial_callback = new HCNetSDK.SerialDataCallBack(g_SerialDataCallBack);
                SerialHandle = HCNetSDK.NET_DVR_SerialStart(_deviceInfo.ServiceID, 1, serial_callback, (uint)m_iSubWndIndex);
                if (SerialHandle!=-1)
                {
                    ListSerialHandle.Add(_deviceInfo.DeviceId, SerialHandle);
                }
            }

            camera.SerialHandle = SerialHandle;         
            _cameraInfo = camera;
            if (m_lPlayHandle > -1)
            {
                IsValidChannel = true;
            }
            processFile = AppDomain.CurrentDomain.BaseDirectory + "Temp\\";
            if (!Directory.Exists(processFile))
            {
                Directory.CreateDirectory(processFile);
            }
            TempPath = processFile;
            processFile = processFile + "delectfile.jpg";
            _cameraInfo = camera;
            if (thread == null)
            {

                stopEvent = new ManualResetEvent(false);
                thread = new Thread(new ThreadStart(WorkerThread));
                thread.Name = camera.Name;
                thread.Start();
            }
        }
        // Signal thread to stop work
        private CardOutType CurrentCardOutType;
        private int CurrentCardOutId;
        public static Dictionary<int, DecodeChannel> _listDecodeChannel;
        private static ArrayList AlUsedDisplayChannelInfo = new ArrayList();

        public void Start(CameraInfo camera, CardOutType cardOutType, int id)
        {
            CurrentCardOutType = cardOutType;
            CurrentCardOutId = id;
            IsValidChannel = false;
            NET_DVR_CLIENTINFO struClientInfo;  //定义预览参数结构体
            struClientInfo.lChannel = camera.ChannelNo;
            struClientInfo.lLinkMode = 0;
            struClientInfo.hPlayWnd = IntPtr.Zero; //camera.Handle;
            int m_iSubWndIndex = 1000;  //用户数据
            struClientInfo.sMultiCastIP = "0.0.0.0";
            // 实时预览 不回调
            // m_lPlayHandle = HCNetSDK.NET_DVR_RealPlay_V30(_deviceInfo.ServiceID, ref struClientInfo, null, m_iSubWndIndex, true);
            //实时预览 回调
            _cameraInfo = camera;
            ListPorts = new Dictionary<int, IntPtr>();
            switch (cardOutType)
            {
                case CardOutType.DefaultDisplay:
                    stream_callback = new RealDataCallBack_V30(g_DefaultRealDataCallBack_V30);
                    break;
                case CardOutType.SynGroup:
                    stream_callback = new RealDataCallBack_V30(g_SynGroupRealDataCallBack_V30);
                    break;
                case CardOutType.GroupSwitch:
                    stream_callback = new RealDataCallBack_V30(g_GroupSwitchRealDataCallBack_V30);
                    break;
                case CardOutType.ProgSwitch:
                    stream_callback = new RealDataCallBack_V30(g_ProgSwitchRealDataCallBack_V30);
                    break;

                default:
                    stream_callback = new RealDataCallBack_V30(g_RealDataCallBack_V30);
                    break;
            }

            GCHandle aa = GCHandle.Alloc(stream_callback);
            GCHandle bb = GCHandle.Alloc(serial_callback);
            m_lPlayHandle = HCNetSDK.NET_DVR_RealPlay_V30(_deviceInfo.ServiceID, ref struClientInfo, stream_callback, m_iSubWndIndex, true);

            //m_lPlayHandle = HCNetSDK.NET_DVR_RealPlay_V30(_deviceInfo.ServiceID, ref struClientInfo, null, m_iSubWndIndex, true);
            camera.PlayHandle = m_lPlayHandle;

            int SerialHandle = -1;
            if (!ListSerialHandle.ContainsKey(_deviceInfo.DeviceId))
            {
                serial_callback = new HCNetSDK.SerialDataCallBack(g_SerialDataCallBack);
                SerialHandle = HCNetSDK.NET_DVR_SerialStart(_deviceInfo.ServiceID, 1, serial_callback, (uint)m_iSubWndIndex);
                if (SerialHandle != -1)
                {
                    ListSerialHandle.Add(_deviceInfo.DeviceId, SerialHandle);
                }
            }

            camera.SerialHandle = SerialHandle;
            _cameraInfo = camera;
            if (m_lPlayHandle > -1)
            {
                IsValidChannel = true;
            }
            processFile = AppDomain.CurrentDomain.BaseDirectory + "Temp\\";
            if (!Directory.Exists(processFile))
            {
                Directory.CreateDirectory(processFile);
            }
            TempPath = processFile;
            processFile = processFile + "delectfile.jpg";
            _cameraInfo = camera;
            if (thread == null)
            {

                stopEvent = new ManualResetEvent(false);
                thread = new Thread(WorkerThread);
                thread.Name = camera.Name;
                thread.Start();
            }
        }

        public void TestAlarm()
        {
            //报警主机回送：F6  GARM 4B 10 DATA1 DATA2 CH  00
            //GARM: 报警主机号码（01-20）(一台报警主机有16路警点)
            //DATA1，DATA2: 警情位功能（1:有警；0:无警）
            //DATA1：16路报警主机的低8路
            //DATA2：16路报警主机的高8路

            //AfxMessageBox("测试报警!\r\n");
            for (int i = 1; i < 2; i++)
            {
                byte[] data = new byte[8];
                data[0] = 0xF6;
                data[1] = 0x01;  //GARM,报警主机号
                data[2] = 0x4B;  //0x4B;
                data[3] = 0x10;  //0x10;
                data[7] = 0x00;  //0x00;

                //第１、２路有报警
                data[4] = 0xfe;  //0xfe; //DATA1，16路报警主机的低8路

                //第９路有报警
                data[5] = 0xfe;  //0xfe; //DATA2，16路报警主机的高8路

                data[6] = (byte)(data[1] + 0x4B + 0x10 +data[4] + data[5]);
                string strdata = "";
                for (int j = 0; j < 8; j++)
                {
                    strdata += data[j].ToString("X2");
                }
                foreach (KeyValuePair<int, int> keyValuePair in ListSerialHandle)
                {
                    g_SerialDataCallBack(keyValuePair.Value, strdata, 16, 0);
                    
                }

            }
        }

        // Signal thread to stop work

        #region 暂时不需要改动部分

        public void SignalToStop()
        {
            // stop thread
            if (thread != null)
            {
                // signal to stop
                stopEvent.Set();
            }
        }

        // Wait for thread stop
        public void WaitForStop()
        {
            if (thread != null)
            {
                // wait for thread stop
                thread.Join();

                Free();
            }
        }

        // Abort thread
        public void Stop()
        {
            StopVideo();
            if (this.Running)
            {
                thread.Abort();
                WaitForStop();

            }


        }

        // Free resources
        private void Free()
        {
            thread = null;

            // release events
            if (stopEvent != null)
            {
                stopEvent.Close();
            }

            stopEvent = null;
        }

        public void WorkerThread()
        {
            if (!IsValidChannel)
            {
                return;
            }
            Random rnd = new Random((int)DateTime.Now.Ticks);
            DateTime start;
            bool isStartRecord = false;
            DateTime date1 = DateTime.Now;
            while (true)
            {


                try
                {
                    start = DateTime.Now;
                    if (CaptureState != 1)
                    {
                        RecordVideo();
                        Thread.Sleep(10);
                        continue;
                    }
                    while ((stopEvent.WaitOne(0, true) == false))
                    {
                        // sleeping ...
                        if (DateTime.Now.AddMinutes(-1 * Config.DEFFFILEMIN).CompareTo(start) >= 0)
                        {
                            isStartRecord = false;
                            StopVideo();
                            break;
                        }

                        Thread.Sleep(50);

                        //check disk space
                        if (DateTime.Now.CompareTo(date1.AddHours(1)) > 0)
                        {
                            MonitorFolder monitorFolder = new MonitorFolder(Config.VideoPath, Config.SaveDay);
                            if (MonitorFolder.GetFreeDiskSpaceMB(Config.VideoPath) <= Config.DiskSpace)
                            {
                                Thread delFileTh = new Thread(monitorFolder.DeleteFirstDayFile);
                                delFileTh.IsBackground = true;
                                delFileTh.Start();
                            }
                        }

                    }

                }

                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("=============: " + ex.Message);
                }
                finally
                {

                }

                // need to stop ?
                if (stopEvent.WaitOne(0, true))
                    break;
            }
        }

        DateTime dStartDate = DateTime.MinValue;
        private bool isNewStart = true;
        private bool hasProcStart = false;
        DateTime dStartTime = DateTime.MinValue;
        private string processFile = "";
        private bool startMove = false;
        DateTime startDate = DateTime.MinValue;



        public bool RecordVideo()
        {
            if (!IsValidChannel)
            {
                return false;
            }
            CaptureState = 1;
            videoFile = GeneratorFileInfo.GenerateSaveFilePath(Config.VideoPath, "264", _cameraInfo.CameraId, DateTime.Now);
            return HCNetSDK.NET_DVR_SaveRealData(_cameraInfo.PlayHandle, videoFile);

        }
        public bool StopVideo()
        {
            return HCNetSDK.NET_DVR_StopSaveRealData(_cameraInfo.PlayHandle);

        }


        public int GetJpegImage(ref byte[] imageBuf)
        {
            if (!IsValidChannel)
            {
                return -1;
            }

            uint size = 0;
            HCNetSDK.NET_DVR_JPEGPARA jpegPara = new HCNetSDK.NET_DVR_JPEGPARA();
            jpegPara.wPicSize = 2;
            jpegPara.wPicQuality = 1;
            string filename = string.Format("{0}{1}_{2}.bmp", TempPath, _cameraInfo.Name, Guid.NewGuid().ToString());

            bool ret = HCNetSDK.NET_DVR_CapturePicture(_cameraInfo.PlayHandle, filename);
            Thread.Sleep(100);
            FileStream stream = new FileStream(filename, FileMode.OpenOrCreate);
            BinaryReader br = new BinaryReader(stream);
            imageBuf = br.ReadBytes((int)stream.Length);
            br.Close();

            return (int)size;

        }

        public bool Close()
        {

            StopVideo();
            if (thread != null)
            {
                thread.Abort();
            }
            Free();
            if (ListPorts != null)
            {
                foreach (KeyValuePair<int, IntPtr> item in ListPorts)
                {
                    m_lPort = item.Key;
                    HikPlayer.PlayM4_CloseStream(m_lPort);
                }
            }
            return HCNetSDK.NET_DVR_StopRealPlay(m_lPlayHandle);

        }
        public bool IsValidVideo()
        {

            return IsValidChannel;
        }
        #endregion

        #region IComparable Members

        public int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }

        #endregion


    }
}