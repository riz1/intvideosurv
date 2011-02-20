using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NavigationControl
{
    public class NavigationCommand : INavigationCommand
    {
       
        public static NavigationCommand SetPanDefultPos
        {
            get
            {
                var command = new NavigationCommand();
                command.CommandCode = new byte[] { 0x00, 0x03 };
                command.CommandData = new byte[] { 0x00, 0x01 };

                return command;

            }
        }
       
         private const byte FocusNear = 0x01;//增加聚焦
        private const byte IrisOpen = 0x02;//减小光圈
        private const byte IrisClose = 0x04;//增加光圈
        private const byte CameraOnOff = 0x08;//摄像机打开和关闭
        private const byte AutoManualScan = 0x10;//自动和手动扫描
        private const byte Sense = 0x80;//Sence码
         

        #region  指令码2
        private const byte _PanRight = 0x02;//右
        private const byte _PanLeft = 0x04;//左

        

        private const byte TiltUp = 0x08;//上
        private const byte TiltDown = 0x10;//下
        private const byte ZoomTele = 0x20;//增加对焦
        private const byte ZoomWide = 0x40;//减小对焦
        private const byte FocusFar = 0x80;//减小聚焦

        #endregion

        #region 镜头左右平移的速度
        private const byte PanSpeedMin = 0x00;//停止
        private const byte PanSpeedMax = 0xFF;//最高速
        #endregion

        #region 镜头上下移动的速度
        private const byte TiltSpeedMin = 0x00;//停止
        private const byte TiltSpeedMax = 0x3F;//最高速
        #endregion
         
        private const byte _PanRightUp = 0xa;//右上
        private const byte _PanLeftUP = 0x0c;//左上

        private const byte _PanRightDown =0x14;//右下
        private const byte _PanLeftDown = 0x12;//左下
        #region 云台控制枚举
        public enum Switch { On = 0x01, Off = 0x02 }//雨刷控制
        public enum Focus { Near = FocusNear, Far = FocusFar }//聚焦控制
        public enum Zoom { Wide = ZoomWide, Tele = ZoomTele }//对焦控制
        public enum Tilt { Up = TiltUp, Down = TiltDown }//上下控制
        public enum Pan { Left = _PanLeft, Right = _PanRight, LeftUP = _PanLeftUP, LeftDown = _PanLeftDown, RightUp = _PanRightUp, RightDown = _PanRightDown }//左右控制
        public enum Scan { Auto, Manual }//自动和手动控制
        public enum Iris { Open = IrisOpen, Close = IrisClose }//光圈控制
        #endregion
        /// <summary>
        ///雨刷控制 
        /// </summary>
        public static NavigationCommand CameraSwitchOn
        {
            get
            {
                byte m_action = CameraOnOff;
                 m_action = (byte)(CameraOnOff + Sense);
                var command = new NavigationCommand();
                command.CommandCode = new byte[] { m_action, 0x00 };
                command.CommandData = new byte[] { 0x00, 0x20 };
                return command;

            }
        }
        public static NavigationCommand CameraSwitchOff
        {
            get
            {
                byte m_action = CameraOnOff;
                var command = new NavigationCommand();
                command.CommandCode = new byte[] { m_action, 0x00 };
                command.CommandData = new byte[] { 0x00, 0x20 };

                return command;

            }
        }
        /// <summary>
        /// 光圈控制
        /// </summary>
        public static NavigationCommand CameraIrisOpen
        {
             get
            {
                //return Message.GetMessage(deviceAddress, (byte)action, 0x00, 0x00, 0x00);
                byte m_action = IrisOpen;
                var command = new NavigationCommand();
                command.CommandCode = new byte[] { m_action, 0x00 };
                command.CommandData = new byte[] { 0x00, 0x20 };

                return command;

            }
            
        }
        public static NavigationCommand CameraIrisClose
        {
            get
            {
                //return Message.GetMessage(deviceAddress, (byte)action, 0x00, 0x00, 0x00);
                byte m_action = IrisClose;
                var command = new NavigationCommand();
                command.CommandCode = new byte[] { m_action, 0x00 };
                command.CommandData = new byte[] { 0x00, 0x20 };

                return command;

            }

        }
        /// <summary>
        ///对焦控制 
        /// </summary>
        public static NavigationCommand CameraZoomWide
        {
            get
            {
                //return Message.GetMessage(deviceAddress, (byte)action, 0x00, 0x00, 0x00);
                byte m_action = ZoomWide;
                var command = new NavigationCommand();
                command.CommandCode = new byte[] {  0x00,m_action };
                command.CommandData = new byte[] { 0x00, 0x20 };

                return command;

            }

        }
        public static NavigationCommand CameraZoomTele
        {
            get
            {
                //return Message.GetMessage(deviceAddress, (byte)action, 0x00, 0x00, 0x00);
                byte m_action = ZoomTele;
                var command = new NavigationCommand();
                command.CommandCode = new byte[] { 0x00, m_action };
                command.CommandData = new byte[] { 0x00, 0x20 };

                return command;

            }

        }
      
        /// <summary>
        /// 聚焦控制
        /// </summary>
        public static NavigationCommand CameraFocusIn
        {
            get
            {
                byte action = (byte)Focus.Near;
                var command = new NavigationCommand();
                command.CommandCode = new byte[] { action, 0x00 };
                command.CommandData = new byte[] { 0x00, 0x20 };

                return command;

            }
        }
        //FF 01 00 20 00 20 41
        public static NavigationCommand CameraFocusOut
        {
            get
            {
                byte action = (byte)Focus.Far;
                var command = new NavigationCommand();
                command.CommandCode = new byte[] { 0x00, action };
                command.CommandData = new byte[] { 0x00, 0x20 };
                return command;

            }
        }
        public static NavigationCommand SetPanReturnDefultPos
        {
            get
            {
                var command = new NavigationCommand();
                command.CommandCode = new byte[] { 0x00, 0x07 };
                command.CommandData = new byte[] { 0x00, 0x01 };

                return command;

            }
        }
      
        //FF 01 00 04 00 20 25
        public static NavigationCommand PanLeft
        {
            get
            {
                var command = new NavigationCommand();
                command.CommandCode = new byte[] { 0x00, 0x04 };
                command.CommandData = new byte[] { 0xff, 0xff };

                return command;

            }
        }
        //FF 01 00 b ff ff 25
        public static NavigationCommand PanLeftUp
        {
            get
            {
                var command = new NavigationCommand();
                command.CommandCode = new byte[] { 0x00, 0x0c };
                command.CommandData = new byte[] { 0xff, 0xff };

                return command;

            }
        }
        //FF 01 00 14 ff ff 25
        public static NavigationCommand PanLeftDown
        {
            get
            {
                var command = new NavigationCommand();
                command.CommandCode = new byte[] { 0x00, 0x14 };
                command.CommandData = new byte[] { 0xff, 0xff };

                return command;

            }
        }

        //FF 01 00 08 00 20 29
        public static NavigationCommand PanUp
        {
            get
            {
                var command = new NavigationCommand();
                command.CommandCode = new byte[] { 0x00, 0x08 };
                command.CommandData = new byte[] { 0xff, 0xff };

                return command;

            }
        }
      
        //FF 01 00 02 00 20 23
        public static NavigationCommand PanRight
        {
            get
            {
                var command = new NavigationCommand();
                command.CommandCode = new byte[] { 0x00, 0x02 };
                command.CommandData = new byte[] { 0xff, 0xff };

                return command;

            }
        }
        //FF 01 00 a ff ff 
        public static NavigationCommand PanRightUp
        {
            get
            {
                var command = new NavigationCommand();
                command.CommandCode = new byte[] { 0x00, 0xa };
                command.CommandData = new byte[] { 0xff, 0xff };

                return command;

            }
        }
        //FF 01 00 12 ff ff 
        public static NavigationCommand PanRightDown
        {
            get
            {
                var command = new NavigationCommand();
                command.CommandCode = new byte[] { 0x00, 0x12 };
                command.CommandData = new byte[] { 0xff, 0xff };

                return command;

            }
        }
      
      
        //FF 01 00 10 00 20 31
        public static NavigationCommand PanDown
        {
            get
            {
                var command = new NavigationCommand();
                command.CommandCode = new byte[] { 0x00, 0x10};
                command.CommandData = new byte[] { 0xff, 0xff };

                return command;

            }
        }

        public static NavigationCommand Stop
        {
            get
            {
                var command = new NavigationCommand();
                command.CommandCode = new byte[] { 0x00, 0x00 };
                command.CommandData = new byte[] { 0x00, 0x00 };

                return command;

            }
        }



        #region IBinaryCommand Members

        byte[] IBinaryCommand.Build()
        {
            return this.Build();
        }

        #endregion

        public byte DestinationAddress { get; set; }
        public byte[] CommandCode { get; set;}
        public byte[] CommandData { get; set;}
    }
}
