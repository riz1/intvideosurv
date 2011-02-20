// Camara Vision
//
// Copyright ?Andrew Kirillov, 2005-2006
// andrew.kirillov@gmail.com
//

namespace HCVideoService
{
	using System;
	using System.Xml;
	using videosource;

	/// <summary>
	/// JPEGSourceDescription
	/// </summary>
    public class HCVideoServiceSourceDescription : IVideoSourceDescription
	{
		// Name property
		public string Name
		{
			get { return "海康视频服务器"; }
		}

		// Description property
		public string Description
		{
            get { return "海康视频服务器"; }
		}

		// Return settings page
		public IVideoSourcePage GetSettingsPage()
		{
            return new HCVideoServiceSourceSetting();
		}

		// Save configuration
		public void SaveConfiguration(XmlTextWriter writer, object config)
		{
			HCVideoServerConfiguration	cfg = (HCVideoServerConfiguration) config;

			if (cfg != null)
			{
               
				writer.WriteAttributeString("source", cfg.source);
				writer.WriteAttributeString("login", cfg.login);
				writer.WriteAttributeString("password", cfg.password);
				writer.WriteAttributeString("interval", cfg.frameInterval.ToString());
                writer.WriteAttributeString("Port", cfg.Port.ToString());
                writer.WriteAttributeString("ChannelNo", cfg.ChannelNo.ToString());
                writer.WriteAttributeString("VideoCount", cfg.VideoCount.ToString());
                writer.WriteAttributeString("ViddeoStartNo", cfg.ViddeoStartNo.ToString());
                writer.WriteAttributeString("WarningOutputCount", cfg.WarningOutputCount.ToString());
                writer.WriteAttributeString("WarningInputNo", cfg.WarningInputNo.ToString());
                writer.WriteAttributeString("WarningCount", cfg.WarningCount.ToString());
                writer.WriteAttributeString("Oupputpath", cfg.Oupputpath.ToString());
                writer.WriteAttributeString("FileExtName", Util.VIDEOFILEEXTNAME);


			}
		}

		// Load configuration
		public object LoadConfiguration(XmlTextReader reader)
		{
			HCVideoServerConfiguration	config = new HCVideoServerConfiguration();

			try
			{
				config.source	= reader.GetAttribute("source");
				config.login	= reader.GetAttribute("login");
				config.password	= reader.GetAttribute("password");
				config.frameInterval = int.Parse(reader.GetAttribute("interval"));
                config.Port = ushort.Parse(reader.GetAttribute("Port"));
                config.ChannelNo = int.Parse(reader.GetAttribute("ViddeoStartNo"));
                config.VideoCount = int.Parse(reader.GetAttribute("VideoCount"));
                config.ViddeoStartNo = int.Parse(reader.GetAttribute("ViddeoStartNo"));
                config.WarningOutputCount = int.Parse(reader.GetAttribute("WarningOutputCount"));
                config.WarningInputNo = int.Parse(reader.GetAttribute("WarningInputNo"));
                config.WarningCount = int.Parse(reader.GetAttribute("WarningCount"));
                config.Oupputpath = reader.GetAttribute("Oupputpath");
                config.FileExtName = reader.GetAttribute("FileExtName");
               
			}
			catch (Exception)
			{
			}

			return (object) config;
		}

		// Create video source object
		public IVideoSource CreateVideoSource(object config)
		{
				HCVideoServerSource source = new HCVideoServerSource();
				return (IVideoSource) source;
			 
		}
	}
}
