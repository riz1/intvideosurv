// Camara Vision
//
// Copyright ?Andrew Kirillov, 2005-2006
// andrew.kirillov@gmail.com
//

namespace HCVideoService
{
	using System;
	using System.Drawing;
	using System.IO;
	using System.Threading;
	using System.Net;

	using videosource;
    using System.Windows.Forms;
using IntVideoSurv.Entity;

	/// <summary>
	/// JPEGSource - JPEG downloader
	/// </summary>
	public class HCVideoServerSource : IVideoSource
	{
		private string	source;
		private string	login = null;
		private string	password = null;
		private object	userData = null;
		private int		framesReceived;
		private int		bytesReceived;
		private bool	useSeparateConnectionGroup = false;
		private bool	preventCaching = false;
		private int		frameInterval = 0;		// frame interval in miliseconds
        private bool isValidVideo = false;

        #region new var
        public IntPtr Handle { get; set; }
        public bool IsDetect { get; set; }
        public ushort Port { get; set; }
        public bool IsNeedInit { get; set; }
        public  int ChannelNo { get; set; }
        public int RetrunUserId { get; set; }
        public string OutputPath { get; set; }
        public string FileExtName { get; set; }
        public int CameraId { get; set; }
        #endregion


        private const int	bufSize = 512 * 1024;	// buffer size
		private const int	readSize = 1024;		// portion size to read

		private Thread	thread = null;
		private ManualResetEvent stopEvent = null;

		// new frame event
		public event CameraEventHandler NewFrame;
      
		// SeparateConnectioGroup property
		// indicates to open WebRequest in separate connection group
		public bool	SeparateConnectionGroup
		{
			get { return useSeparateConnectionGroup; }
			set { useSeparateConnectionGroup = value; }
		}
		// PreventCaching property
		// If the property is set to true, we are trying to prevent caching
		// appneding fake parameter to URL. It's needed is client is behind
		// proxy server.
		public bool	PreventCaching
		{
			get { return preventCaching; }
			set { preventCaching = value; }
		}
		// FrameInterval property - interval between frames
		// If the property is set 100, than the source will produce 10 frames
		// per second if it possible
		public int FrameInterval
		{
			get { return frameInterval; }
			set { frameInterval = value; }
		}
		// VideoSource property
		public virtual string VideoSource
		{
			get { return source; }
			set { source = value; }
		}
		// Login property
		public string Login
		{
			get { return login; }
			set { login = value; }
		}
		// Password property
		public string Password
		{
			get { return password; }
			set { password = value; }
		}
		// FramesReceived property
		public int FramesReceived
		{
			get
			{
				int frames = framesReceived;
				framesReceived = 0;
				return frames;
			}
		}
		// BytesReceived property
		public int BytesReceived
		{
			get
			{
				int bytes = bytesReceived;
				bytesReceived = 0;
				return bytes;
			}
		}
		// UserData property
		public object UserData
		{
			get { return userData; }
			set { userData = value; }
		}
        int m_lPlayHandle = -1;
		// Get state of the video source thread
		public bool Running
		{
			get
			{
				if (thread != null)
				{
					if (thread.Join(0) == false)
						return true;

					// the thread is not running, so free resources
					Free();
				}
				return false;
			}
		}

		// Constructor
		public HCVideoServerSource()
		{
		}
       
        public bool RecordVideo()
        {
            string videoFile = GeneratorFileInfo.GenerateSaveFilePath(_cameraInfo.Oupputpath, _deviceInfo.FileExtName, _cameraInfo.CameraId, DateTime.Now);
            return HCNetSDK.NET_DVR_SaveRealData(_cameraInfo.PlayHandle, videoFile);

        }
        public bool StopVideo()
        {
            return HCNetSDK.NET_DVR_StopSaveRealData(_cameraInfo.PlayHandle);

        }
        public int GetJpegImage(ref byte[] imageBuf)
        {
            // static extern int GetJpegImage(IntPtr hChannelHandle, byte[] ImageBuf, out int Size, uint nQuality);
            imageBuf = new byte[800 * 600 * 2];
            uint size = 800 * 600 * 2;
            HCNetSDK.NET_DVR_JPEGPARA jpegPara = new HCNetSDK.NET_DVR_JPEGPARA();
            jpegPara.wPicSize =2;
            jpegPara.wPicQuality = 1;
            string filename =string.Format( "C:\\Picture\\{0}_{1}.jpg",_cameraInfo.Name,Guid.NewGuid().ToString());
            //NET_DVR_CaptureJPEGPicture_NEW(LONG lUserID, LONG lChannel, LPNET_DVR_JPEGPARA lpJpegPara, char *sJpegPicBuffer, DWORD dwPicSize,  LPDWORD lpSizeReturned);
             //HCNetSDK.NET_DVR_CaptureJPEGPicture_NEW(_deviceInfo.ServiceID, _cameraInfo.PlayHandle,jpegPara, imageBuf,100, out size);
            HCNetSDK.NET_DVR_CapturePicture(_cameraInfo.PlayHandle, filename);
           // bool brtn= HCNetSDK.NET_DVR_CaptureJPEGPicture(_deviceInfo.ServiceID, _cameraInfo.PlayHandle,ref jpegPara, filename);
             
                FileStream stream=new FileStream(filename, FileMode.Open);
                BinaryReader br = new BinaryReader(stream);
                imageBuf = br.ReadBytes((int)stream.Length);
                br.Close();
             
             return (int)size;
            
        }
        DeviceInfo _deviceInfo = null;
        CameraInfo _cameraInfo = null;
        public void Init(ref DeviceInfo deviceInfo)
        {
            if ((!deviceInfo.IsReady) || deviceInfo.ServiceID<0)
            {
                bool bRtn = HCNetSDK.NET_DVR_Init();  //初始化SDK

                NET_DVR_DEVICEINFO_V30 RESULT;  //得到设备参数的结构体
                int serviceId = HCNetSDK.NET_DVR_Login_V30(deviceInfo.source,(ushort) deviceInfo.Port, deviceInfo.login, deviceInfo.pwd, out RESULT);
                deviceInfo.ServiceID = serviceId;
                if (serviceId > -1)
                {
                    deviceInfo.IsReady = true;
                }
                else
                {
                    deviceInfo.IsReady = false;
                }
                HikPlayer.PlayM4_InitDDrawDevice();
                
            }
            _deviceInfo = deviceInfo;
        }
        int m_lPort = -1;
        public void g_RealDataCallBack_V30(int lRealHandle, uint dwDataType, byte[] pBuffer, uint dwBufSize, IntPtr pUser)
        {
            bool iRet = false;
            try
            {

                switch (dwDataType)
                {
                    case 1: //NET_DVR_SYSHEAD:
                        if (m_lPort >= 0)
                        {
                            HikPlayer.PlayM4_FreePort(m_lPort);
                        }
                        HikPlayer.PlayM4_GetPort(ref m_lPort);

                        if (dwBufSize > 0)
                        {
                            bool temp;
                            temp = HikPlayer.PlayM4_SetStreamOpenMode(m_lPort, 0);
                            temp = HikPlayer.PlayM4_OpenStream(m_lPort, ref pBuffer, dwBufSize, 1024 * 1024);
                            temp = HikPlayer.PlayM4_Play(m_lPort, _cameraInfo.Handle);
                            temp = HikPlayer.PlayM4_SetDisplayBuf(m_lPort, 15);
                            temp = HikPlayer.PlayM4_SetOverlayMode(m_lPort, false, 0);
                        }
                        break;

                    case 4://NET_DVR_STD_VIDEODATA:
                    case 5://NET_DVR_STD_AUDIODATA:
                    case 2://NET_DVR_STREAMDATA:
                        if (dwBufSize > 0 && m_lPort != -1)
                        {
                            if (!HikPlayer.PlayM4_InputData(m_lPort, ref pBuffer, dwBufSize))
                            {

                                int temp = 1;
                            }
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
            }
        }

		// Start work
		public void Start(ref CameraInfo cameraInfo)
		{
            if ((!_deviceInfo.IsReady) || _deviceInfo.ServiceID < 0)
            {
                return;
            }
            
            NET_DVR_CLIENTINFO struClientInfo;  //定义预览参数结构体
            struClientInfo.lChannel = cameraInfo.ChannelNo;
            struClientInfo.lLinkMode = 0;
            struClientInfo.hPlayWnd = cameraInfo.Handle;
            int m_iSubWndIndex = 0;  //用户数据
            struClientInfo.sMultiCastIP = "0.0.0.0";
            // 实时预览 不回调
           // m_lPlayHandle = HCNetSDK.NET_DVR_RealPlay_V30(_deviceInfo.ServiceID, ref struClientInfo, null, m_iSubWndIndex, true);
            //实时预览 回调
            _cameraInfo = cameraInfo;
            //m_lPlayHandle = HCNetSDK.NET_DVR_RealPlay_V30(_deviceInfo.ServiceID, ref struClientInfo, new RealDataCallBack_V30(g_RealDataCallBack_V30), m_iSubWndIndex, true);
             m_lPlayHandle = HCNetSDK.NET_DVR_RealPlay_V30(_deviceInfo.ServiceID, ref struClientInfo,null, m_iSubWndIndex, true);
            
            cameraInfo.PlayHandle = m_lPlayHandle;
            if (m_lPlayHandle > -1)
            {
                isValidVideo = true;
            }
            _cameraInfo = cameraInfo;
          	if (thread == null)
			{
				framesReceived = 0;
				bytesReceived = 0;
				stopEvent	= new ManualResetEvent(false);
		 		thread = new Thread(new ThreadStart(WorkerThread));
				thread.Name = source;
				thread.Start();
			}
		}

		// Signal thread to stop work
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
			if (this.Running)
			{
				thread.Abort();
				WaitForStop();
               
			}
            StopVideo();
           
		}

		// Free resources
		private void Free()
		{
			thread = null;

			// release events
			stopEvent.Close();
			stopEvent = null;
		}
        public void Close()
        {
            HCNetSDK.NET_DVR_Logout_V30(_deviceInfo.ServiceID);
            HikPlayer.PlayM4_ReleaseDDrawDevice();
        }

		// Thread entry point
		public void WorkerThread()
		{
			byte[]			buffer = new byte[bufSize];	// buffer to read stream
			HttpWebRequest	req = null;
			WebResponse		resp = null;
			Stream			stream = null;
			Random			rnd = new Random((int) DateTime.Now.Ticks);
			DateTime		start;
			TimeSpan		span;
            bool isStartRecord = false;
            bool bRtn = false;
          
			while (true)
			{
				 

				try
				{
					start = DateTime.Now;
                    if (!isStartRecord)
                    {
                        bRtn = RecordVideo();
                        isStartRecord = true;
                    }
					while ((stopEvent.WaitOne(0, true) == false))
					{
						// sleeping ...
                        if (DateTime.Now.AddMinutes(-1 * GeneratorFileInfo.DEFFFILEMIN).CompareTo(start) >=0)
                        {
                            isStartRecord = false;
                           bRtn =  StopVideo();
                           break;
                        }
                      	Thread.Sleep(10000);
						 
					}
					 
				}
				catch (WebException ex)
				{
					System.Diagnostics.Debug.WriteLine("=============: " + ex.Message);
					// wait for a while before the next try
					Thread.Sleep(250);
				}
				catch (Exception ex)
				{
					System.Diagnostics.Debug.WriteLine("=============: " + ex.Message);
				}
				finally
				{
					// abort request
					if (req != null)
					{
						req.Abort();
						req = null;
					}
					// close response stream
					if (stream != null)
					{
						stream.Close();
						stream = null;
					}
					// close response
					if (resp != null)
					{
						resp.Close();
						resp = null;
					}
				}

				// need to stop ?
				if (stopEvent.WaitOne(0, true))
					break;
			}
		}
	}
}
