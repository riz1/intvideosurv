// Camara Vision
//
// Copyright ?Andrew Kirillov, 2005-2006
// andrew.kirillov@gmail.com
//

namespace HCVideoService
{
	using System;

	/// <summary>
	/// JPEGConfiguration
	/// </summary>
	public class HCVideoServerConfiguration
	{
        public string Name;
		public string	source;
		public string	login;
		public string	password;
		public int		frameInterval = 0;
        public ushort Port { get; set; }
        public int ChannelNo { get; set; }
        public int VideoCount { get; set; }
        public int ViddeoStartNo { get; set; }
        public int WarningOutputCount { get; set; }
        public int WarningInputNo { get; set; }
        public int WarningCount { get; set; }
        public string  Oupputpath { get; set; }
        public string FileExtName { get; set; }

        
     
      
       
        

	}
}
