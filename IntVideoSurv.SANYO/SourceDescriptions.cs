// Camara Vision
//
// Copyright ?Andrew Kirillov, 2005-2006
// andrew.kirillov@gmail.com
//

namespace SANYO
{
	using System;
	using System.Xml;
	using videosource;

	/// <summary>
	/// PanasonicCameraDescription
	/// </summary>
    public class SANYOCameraDescription : IVideoSourceDescription
	{
		// Name property
		public string Name
		{
			get { return "三洋高清数字相机"; }
		}

		// Description property
		public string Description
		{
            get { return "三洋高清数字相机"; }
		}

		// Return settings page
		public IVideoSourcePage GetSettingsPage()
		{
			return new PanasonicCameraSetupPage();
		}

		// Save configuration
		public void SaveConfiguration(XmlTextWriter writer, object config)
		{
			SANYOConfiguration cfg = (SANYOConfiguration) config;

			if (cfg != null)
			{
				writer.WriteAttributeString("source", cfg.source);
				writer.WriteAttributeString("login", cfg.login);
				writer.WriteAttributeString("password", cfg.password);
				writer.WriteAttributeString("size", cfg.resolution);
				writer.WriteAttributeString("stype", ((int) cfg.stremType).ToString());
				writer.WriteAttributeString("quality", cfg.quality);
				writer.WriteAttributeString("interval", cfg.frameInterval.ToString());
			}
		}

		// Load configuration
		public object LoadConfiguration(XmlTextReader reader)
		{
			SANYOConfiguration	config = new SANYOConfiguration();

			try
			{
				config.source	= reader.GetAttribute("source");
				config.login	= reader.GetAttribute("login");
				config.password	= reader.GetAttribute("password");
				config.resolution = reader.GetAttribute("size");
				config.stremType = (StreamType) (int.Parse(reader.GetAttribute("stype")));
				config.quality	= reader.GetAttribute("quality");
				config.frameInterval = int.Parse(reader.GetAttribute("interval"));
			}
			catch (Exception)
			{
			}
			return (object) config;
		}

		// Create video source object
		public IVideoSource CreateVideoSource(object config)
		{

            SANYOCamera source = new SANYOCamera();
            return (IVideoSource)source;


			/*SANYOConfiguration cfg = (SANYOConfiguration) config;
			
			if (cfg != null)
			{
				SANYOCamera source = new SANYOCamera();

				
				source.VideoSource	= cfg.source;
				source.Login		= cfg.login;
				source.Password		= cfg.password;
				source.Resolution	= cfg.resolution;
				source.Quality		= cfg.quality;
				source.FrameInterval = cfg.frameInterval;

				return (IVideoSource) source;
			}
			return null;*/
		}
	}
}