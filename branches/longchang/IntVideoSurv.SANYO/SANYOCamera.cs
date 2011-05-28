// Camara Vision
//
// Copyright ?Andrew Kirillov, 2005-2006
// andrew.kirillov@gmail.com
//

namespace SANYO
{
	using System;
	using videosource;

	using jpeg;

	/// <summary>
	/// Panasonic network cameras
	/// </summary>
    public class SANYOCamera : JPEGSource
	{
		private string	server;
		private string	resolution = "960x540";
		private string	quality = "Standard";
		private int		frameInterval;

		// Constructor
		public SANYOCamera()
		{
            
		}

		 
		// VideoSource property
		public override string VideoSource
		{
			get { return server; }
			set
			{
				server = value;
				UpdateVideoSource();
			}
		}
		// Resolution property
		public string Resolution
		{
			get { return resolution; }
			set
			{
				resolution = value;
				UpdateVideoSource();
			}
		}
		// Quality property
		public string Quality
		{
			get { return quality; }
			set
			{
				quality = value;
				UpdateVideoSource();
			}
		}
	


		// Update video source
		protected  void UpdateVideoSource()
		{
			 
           this.VideoSource = "http://" + server + "/liveimg.cgi?serverpush=1";
				 
		}
	}
}
