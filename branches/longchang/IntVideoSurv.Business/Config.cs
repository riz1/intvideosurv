using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.ComponentModel;
using Com.SS.ProfileReader;
using System.IO;

namespace IntVideoSurv.Business
{
    public class Config
    {
        public enum EventType
        {
            [Description("系统参数配置")]
            SystemLog = 1,
            [Description("报警信息")]
            WarnInfo = 2,
            [Description("视频丢失")]
            LostVideo = 3,
            [Description("磁盘空间满")]
            FullDisk = 4,
            [Description("退出系统")]
            LogOut = 5,

        }

        public static void writeLog(string message)
        {
            try
            {
                string logFile = AppDomain.CurrentDomain.BaseDirectory + "\\syslog.txt";
                FileStream stream = new FileStream(logFile, FileMode.Append, FileAccess.Write);
                using (StreamWriter sw = new StreamWriter(stream))
                {
                    sw.WriteLine(message);
                    sw.Flush();
                }
            }
            catch (Exception ex)
            {

            }


        }

        private static string ConfigPath
        {
            get
            {
                string charSign = "\\";
                string configFile = "MatrixConfig.txt";
                if (AppDomain.CurrentDomain.BaseDirectory.EndsWith(charSign))
                {
                    return AppDomain.CurrentDomain.BaseDirectory + configFile;
                }
                else
                {
                    return AppDomain.CurrentDomain.BaseDirectory + "\\" + configFile;
                }
            }
        }

       
        public static int DiskSpace
        {
            set
            {
                Ini _profile = new Ini(ConfigPath);
                _profile.SetValue("Setting", "DiskSpace", value);
            }

            get
            {
                Ini _profile = new Ini(ConfigPath);
                try
                {
                    return int.Parse(Convert.ToString(_profile.GetValue("Setting", "DiskSpace")));
                }
                catch (Exception ex)
                {
                    //logger.Error(ex.Message + " :" + ex.StackTrace);
                    return 2000;
                }
            }
        }
        public static int FileSaveDay
        {
            set
            {
                Ini _profile = new Ini(ConfigPath);
                _profile.SetValue("Setting", "FileSaveDay", value);
            }

            get
            {
                Ini _profile = new Ini(ConfigPath);
                try
                {
                    return int.Parse(Convert.ToString(_profile.GetValue("Setting", "FileSaveDay")));
                }
                catch (Exception ex)
                {
                    //logger.Error(ex.Message + " :" + ex.StackTrace);
                    return 15;
                }
            }

        }
        public static int DEFFFILEMIN
        {
            set
            {
                Ini _profile = new Ini(ConfigPath);
                _profile.SetValue("Setting", "DEFFFILEMIN", value);
            }

            get
            {
                Ini _profile = new Ini(ConfigPath);
                try
                {
                    return int.Parse(Convert.ToString(_profile.GetValue("Setting", "DEFFFILEMIN")));
                }
                catch (Exception ex)
                {
                    //logger.Error(ex.Message + " :" + ex.StackTrace);
                    return 15;
                }
            }
        }

        public static int FrameRate
        {
            set
            {
                Ini _profile = new Ini(ConfigPath);
                _profile.SetValue("Setting", "FrameRate", value);
            }

            get
            {
                Ini _profile = new Ini(ConfigPath);
                try
                {
                    return int.Parse(Convert.ToString(_profile.GetValue("Setting", "FrameRate")));
                }
                catch (Exception ex)
                {
                    //logger.Error(ex.Message + " :" + ex.StackTrace);
                    return 25;
                }
            }
        }
        public static int Brightness
        {
            set
            {
                Ini _profile = new Ini(ConfigPath);
                _profile.SetValue("Setting", "Brightness", value);
            }

            get
            {
                Ini _profile = new Ini(ConfigPath);
                try
                {
                    return int.Parse(Convert.ToString(_profile.GetValue("Setting", "Brightness")));
                }
                catch (Exception ex)
                {
                    //logger.Error(ex.Message + " :" + ex.StackTrace);
                    return 5000;
                }
            }
        }
        public static int NewStartHours
        {
            set
            {
                Ini _profile = new Ini(ConfigPath);
                _profile.SetValue("Setting", "NewStartHours", value);
            }

            get
            {
                Ini _profile = new Ini(ConfigPath);
                try
                {
                    return int.Parse(Convert.ToString(_profile.GetValue("Setting", "NewStartHours")));
                }
                catch (Exception ex)
                {
                    //logger.Error(ex.Message + " :" + ex.StackTrace);
                    return 4;
                }
            }
        }

        public static int SaveDay
        {
            set
            {
                Ini _profile = new Ini(ConfigPath);
                _profile.SetValue("Setting", "SaveDay", value);
            }

            get
            {
                Ini _profile = new Ini(ConfigPath);
                try
                {
                    return int.Parse(Convert.ToString(_profile.GetValue("Setting", "SaveDay")));
                }
                catch (Exception ex)
                {
                    //logger.Error(ex.Message + " :" + ex.StackTrace);
                    return 15;
                }
            }
        }

        public static string PicPath
        {
            set
            {
                Ini _profile = new Ini(ConfigPath);
                _profile.SetValue("Setting", "PicPath", value);
            }

            get
            {
                Ini _profile = new Ini(ConfigPath);
                try
                {
                    return Convert.ToString(_profile.GetValue("Setting", "PicPath"));
                }
                catch (Exception ex)
                {
                    //logger.Error(ex.Message + " :" + ex.StackTrace);
                    return "";
                }
            }
        }
        public static string WarningFile
        {
            set
            {
                Ini _profile = new Ini(ConfigPath);
                _profile.SetValue("Setting", "WarningFile", value);
            }

            get
            {
                Ini _profile = new Ini(ConfigPath);
                try
                {
                    return Convert.ToString(_profile.GetValue("Setting", "WarningFile"));
                }
                catch (Exception ex)
                {
                    //logger.Error(ex.Message + " :" + ex.StackTrace);
                    return "";
                }
            }
        }
        public static int IsNewDetect
        {
            set
            {
                Ini _profile = new Ini(ConfigPath);
                _profile.SetValue("Setting", "IsNewDetect", value.ToString());
            }

            get
            {
                Ini _profile = new Ini(ConfigPath);
                try
                {
                    return Convert.ToInt32(_profile.GetValue("Setting", "IsNewDetect"));
                }
                catch (Exception ex)
                {
                    //logger.Error(ex.Message + " :" + ex.StackTrace);
                    return 0;
                }
            }
        }

        public static int CapWeight
        {
            set
            {
                Ini _profile = new Ini(ConfigPath);
                _profile.SetValue("Setting", "CapWeight", value.ToString());
            }

            get
            {
                Ini _profile = new Ini(ConfigPath);
                try
                {
                    return Convert.ToInt32(_profile.GetValue("Setting", "CapWeight"));
                }
                catch (Exception ex)
                {
                    //logger.Error(ex.Message + " :" + ex.StackTrace);
                    return 0;
                }

            }
        }

        public static int CapHeight
        {
            set
            {
                Ini _profile = new Ini(ConfigPath);
                _profile.SetValue("Setting", "CapHeight", value.ToString());
            }

            get
            {
                Ini _profile = new Ini(ConfigPath);
                try
                {
                    return Convert.ToInt32(_profile.GetValue("Setting", "CapHeight"));
                }
                catch (Exception ex)
                {
                    //logger.Error(ex.Message + " :" + ex.StackTrace);
                    return 0;
                }
            }
        }
        /*
         CapWeight=720
         CapHeight=576
         */
        //VIDEO_IN
        public static int VIDEO_IN
        {
            set
            {
                Ini _profile = new Ini(ConfigPath);
                _profile.SetValue("Setting", "VIDEO_IN", value.ToString());
            }

            get
            {
                Ini _profile = new Ini(ConfigPath);
                try
                {
                    return Convert.ToInt32(_profile.GetValue("Setting", "VIDEO_IN"));
                }
                catch (Exception ex)
                {
                    //logger.Error(ex.Message + " :" + ex.StackTrace);
                    return 0;
                }
            }
        }

        public static int BaudRate
        {
            set
            {
                Ini _profile = new Ini(ConfigPath);
                _profile.SetValue("Setting", "BaudRate", value.ToString());
            }

            get
            {
                Ini _profile = new Ini(ConfigPath);
                try
                {
                    return Convert.ToInt32(_profile.GetValue("Setting", "BaudRate"));
                }
                catch (Exception ex)
                {
                    //logger.Error(ex.Message + " :" + ex.StackTrace);
                    return 2400;
                }
            }
        }
        /*
         WaitTime=1800
ActionTime=380
         */
        public static int ActionTime
        {
            set
            {
                Ini _profile = new Ini(ConfigPath);
                _profile.SetValue("Setting", "ActionTime", value.ToString());
            }

            get
            {
                Ini _profile = new Ini(ConfigPath);
                try
                {
                    return int.Parse(_profile.GetValue("Setting", "ActionTime").ToString());
                }
                catch (Exception ex)
                {
                    //logger.Error(ex.Message + " :" + ex.StackTrace);
                    return 380;
                }
            }
        }

        public static int HasSetDefaultPos
        {
            set
            {
                Ini _profile = new Ini(ConfigPath);
                _profile.SetValue("Setting", "HasSetDefaultPos", value.ToString());
            }

            get
            {
                Ini _profile = new Ini(ConfigPath);
                try
                {
                    return int.Parse(_profile.GetValue("Setting", "HasSetDefaultPos").ToString());
                }
                catch (Exception ex)
                {
                    //logger.Error(ex.Message + " :" + ex.StackTrace);
                    return 0;
                }
            }
        }
        public static int WaitTime
        {
            set
            {
                Ini _profile = new Ini(ConfigPath);
                _profile.SetValue("Setting", "WaitTime", value.ToString());
            }

            get
            {
                Ini _profile = new Ini(ConfigPath);
                try
                {
                    return int.Parse(_profile.GetValue("Setting", "WaitTime").ToString());
                }
                catch (Exception ex)
                {
                    //logger.Error(ex.Message + " :" + ex.StackTrace);
                    return 1800;
                }
            }
        }

        public static string Direction
        {
            set
            {
                Ini _profile = new Ini(ConfigPath);
                _profile.SetValue("Setting", "Direction", value.ToString());
            }

            get
            {
                Ini _profile = new Ini(ConfigPath);
                try
                {
                    return _profile.GetValue("Setting", "Direction").ToString();
                }
                catch (Exception ex)
                {
                    //logger.Error(ex.Message + " :" + ex.StackTrace);
                    return "";
                }
            }
        }
        public static int DataBit
        {
            set
            {
                Ini _profile = new Ini(ConfigPath);
                _profile.SetValue("Setting", "DataBit", value.ToString());
            }

            get
            {
                Ini _profile = new Ini(ConfigPath);
                try
                {
                    return Convert.ToInt32(_profile.GetValue("Setting", "DataBit"));
                }
                catch (Exception ex)
                {
                    //logger.Error(ex.Message + " :" + ex.StackTrace);
                    return 8;
                }
            }
        }
        //Parity
        public static int Parity
        {
            set
            {
                Ini _profile = new Ini(ConfigPath);
                _profile.SetValue("Setting", "Parity", value.ToString());
            }

            get
            {
                Ini _profile = new Ini(ConfigPath);
                try
                {
                    return Convert.ToInt32(_profile.GetValue("Setting", "Parity"));
                }
                catch (Exception ex)
                {
                    //logger.Error(ex.Message + " :" + ex.StackTrace);
                    return 0;
                }
            }
        }
        public static int StopBit
        {
            set
            {
                Ini _profile = new Ini(ConfigPath);
                _profile.SetValue("Setting", "StopBit", value.ToString());
            }

            get
            {
                Ini _profile = new Ini(ConfigPath);
                try
                {
                    return Convert.ToInt32(_profile.GetValue("Setting", "StopBit"));
                }
                catch (Exception ex)
                {
                    // logger.Error(ex.Message + " :" + ex.StackTrace);
                    return 1;
                }
            }
        }
        //VlidCardIDNUm
        //CardCom
        public static int VlidCardIDNUm
        {
            set
            {
                Ini _profile = new Ini(ConfigPath);
                _profile.SetValue("Setting", "VlidCardIDNUm", value.ToString());
            }

            get
            {
                Ini _profile = new Ini(ConfigPath);
                try
                {
                    return int.Parse(_profile.GetValue("Setting", "VlidCardIDNUm").ToString());
                }
                catch (Exception ex)
                {
                    //logger.Error(ex.Message + " :" + ex.StackTrace);
                    return 1;
                }
            }
        }
        public static int CardId
        {
            set
            {
                Ini _profile = new Ini(ConfigPath);
                _profile.SetValue("Setting", "CardId", value.ToString());
            }

            get
            {
                Ini _profile = new Ini(ConfigPath);
                try
                {
                    return int.Parse(_profile.GetValue("Setting", "CardId").ToString());
                }
                catch (Exception ex)
                {
                    //logger.Error(ex.Message + " :" + ex.StackTrace);
                    return 0;
                }
            }
        }

        public static string CardCom
        {
            set
            {
                Ini _profile = new Ini(ConfigPath);
                _profile.SetValue("Setting", "CardCom", value.ToString());
            }

            get
            {
                Ini _profile = new Ini(ConfigPath);
                try
                {
                    return _profile.GetValue("Setting", "CardCom").ToString();
                }
                catch (Exception ex)
                {
                    //logger.Error(ex.Message + " :" + ex.StackTrace);
                    return "COM1";
                }
            }
        }
        //VideoPath=
        public static string VideoPath
        {
            set
            {
                Ini _profile = new Ini(ConfigPath);
                _profile.SetValue("Setting", "VideoPath", value.ToString());
            }

            get
            {
                Ini _profile = new Ini(ConfigPath);
                try
                {
                    return _profile.GetValue("Setting", "VideoPath").ToString();
                }
                catch (Exception ex)
                {
                    //logger.Error(ex.Message + " :" + ex.StackTrace);
                    return @"d:\VideoOutput";
                }
            }
        }
        public static int ReadTimeout
        {
            set
            {
                Ini _profile = new Ini(ConfigPath);
                _profile.SetValue("Setting", "ReadTimeout", value.ToString());
            }

            get
            {
                Ini _profile = new Ini(ConfigPath);
                try
                {
                    return Convert.ToInt32(_profile.GetValue("Setting", "ReadTimeout"));
                }
                catch (Exception ex)
                {
                    //logger.Error(ex.Message + " :" + ex.StackTrace);
                    return 1000;
                }
            }
        }
        public static int WriteTimeout
        {
            set
            {
                Ini _profile = new Ini(ConfigPath);
                _profile.SetValue("Setting", "WriteTimeout", value.ToString());
            }

            get
            {
                Ini _profile = new Ini(ConfigPath);
                try
                {
                    return Convert.ToInt32(_profile.GetValue("Setting", "WriteTimeout"));
                }
                catch (Exception ex)
                {
                    //logger.Error(ex.Message + " :" + ex.StackTrace);
                    return 1000;
                }
            }
        }

        public static int DetectVideoStartX
        {
            set
            {
                Ini _profile = new Ini(ConfigPath);
                _profile.SetValue("Setting", "DetectVideoStartX", value.ToString());
            }

            get
            {
                Ini _profile = new Ini(ConfigPath);
                try
                {
                    return Convert.ToInt32(_profile.GetValue("Setting", "DetectVideoStartX"));
                }
                catch (Exception ex)
                {
                    //logger.Error(ex.Message + " :" + ex.StackTrace);
                    return 0;
                }
            }
        }
        public static int DetectVideoStartY
        {
            set
            {
                Ini _profile = new Ini(ConfigPath);
                _profile.SetValue("Setting", "DetectVideoStartY", value.ToString());
            }

            get
            {
                Ini _profile = new Ini(ConfigPath);
                try
                {
                    return Convert.ToInt32(_profile.GetValue("Setting", "DetectVideoStartY"));
                }
                catch (Exception ex)
                {
                    //logger.Error(ex.Message + " :" + ex.StackTrace);
                    return 0;
                }
            }
        }
        public static int DetectVideoWidth
        {
            set
            {
                Ini _profile = new Ini(ConfigPath);
                _profile.SetValue("Setting", "DetectVideoWidth", value.ToString());
            }

            get
            {
                Ini _profile = new Ini(ConfigPath);
                try
                {
                    return Convert.ToInt32(_profile.GetValue("Setting", "DetectVideoWidth"));
                }
                catch (Exception ex)
                {
                    //logger.Error(ex.Message + " :" + ex.StackTrace);
                    return 0;
                }
            }
        }

        public static int IsStartDetect
        {
            set
            {
                Ini _profile = new Ini(ConfigPath);
                _profile.SetValue("Setting", "IsStartDetect", value.ToString());
            }

            get
            {
                Ini _profile = new Ini(ConfigPath);
                try
                {
                    return Convert.ToInt32(_profile.GetValue("Setting", "IsStartDetect"));
                }
                catch (Exception ex)
                {
                    //logger.Error(ex.Message + " :" + ex.StackTrace);
                    return 0;
                }
            }
        }


        public static int DetectVideoHeight
        {
            set
            {
                Ini _profile = new Ini(ConfigPath);
                _profile.SetValue("Setting", "DetectVideoHeight", value.ToString());
            }

            get
            {
                Ini _profile = new Ini(ConfigPath);
                try
                {
                    return Convert.ToInt32(_profile.GetValue("Setting", "DetectVideoHeight"));
                }
                catch (Exception ex)
                {
                    //logger.Error(ex.Message + " :" + ex.StackTrace);
                    return 0;
                }
            }
        }

    }
    public static class CommonEnumData
    {

        public static T ToEnum<T>(string name)
        {
            return (T)Enum.Parse(typeof(T), name);
        }

        private static string GetDescription(FieldInfo feildInfo)
        {
            DescriptionAttribute[] EnumAttributes = (DescriptionAttribute[])feildInfo.
               GetCustomAttributes(typeof(DescriptionAttribute), false);
            if (EnumAttributes.Length > 0)
                return EnumAttributes[0].Description;
            return string.Empty;
        }

        public static string GetType<T>(string value)
        {
            FieldInfo feildInfo = (typeof(T)).GetField(value);
            return GetDescription(feildInfo);
        }

    }

}
