// Camara Vision
//
// Copyright ?Andrew Kirillov, 2005-2006
// andrew.kirillov@gmail.com
//

namespace videosource
{
	using System;
    using IntVideoSurv.Entity;
	/// <summary>
	/// IVideoSource interface
	/// </summary>
	public interface IVideoSource
	{
		/// <summary>
		/// New frame event - notify client about the new frame
		/// </summary>
		event CameraEventHandler NewFrame;

		/// <summary>
		/// Video source property
		/// </summary>
		string VideoSource{get; set;}
        IntPtr Handle { get; set; }
        bool IsDetect { get; set; }
        ushort Port { get; set; }
        bool IsNeedInit { get; set; }
        int ChannelNo { get; set; }
        int RetrunUserId { get; set; }
        int CameraId { get; set; }
        string OutputPath { get; set; }
        string FileExtName { get; set; }

		/// <summary>
		/// Login property
		/// </summary>
		string Login{get; set;}

		/// <summary>
		/// Password property
		/// </summary>
		string Password{get; set;}

		/// <summary>
		/// FramesReceived property
		/// get number of frames the video source received from the last
		/// access to the property
		/// </summary>
		int FramesReceived{get;}

		/// <summary>
		/// BytesReceived property
		/// get number of bytes the video source received from the last
		/// access to the property
		/// </summary>
		int BytesReceived{get;}

		/// <summary>
		/// UserData property
		/// allows to associate user data with an object
		/// </summary>
		object UserData{get; set;}

		/// <summary>
		/// Get state of video source
		/// </summary>
		bool Running{get;}

		/// <summary>
		/// Start receiving video frames
		/// </summary>
        /// 

        void Init(ref DeviceInfo deviceInfo);
		void Start(ref CameraInfo cameraInfo);
        bool RecordVideo();
        bool StopVideo();
        int  GetJpegImage(ref byte[] imageBuf);

		/// <summary>
		/// Stop receiving video frames
		/// </summary>
		void SignalToStop();

		/// <summary>
		/// Wait for stop
		/// </summary>
		void WaitForStop();

		/// <summary>
		/// Stop work
		/// </summary>
		void Stop();
        /// <summary>
        /// close device
        /// </summary>
        void Close();
	}
}
