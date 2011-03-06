using System;
using System.IO;
using System.Net.Sockets;
using System.Timers;
using System.Net;
using IntVideoSurv.Business;
using log4net;

namespace CameraViewer.NetWorking
{
    public class GetTransPacket
    {
        public GetTransPacket()
        {
            LivePacketHandle = new LivePacketHandle();
            CameraStateHandle = new CameraStateHandle();
            _handlers = new IPacketHandler[] { LivePacketHandle};
        }

        private readonly IPacketHandler[] _handlers;
        public static readonly ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private TcpClient _client;
        private NetworkStream _networkStream;

        public LivePacketHandle LivePacketHandle;
        public CameraStateHandle CameraStateHandle;
        public event MainForm.ImageDataChangeHandle ConnectionServerHandle;
        private bool _connectState;

        public string Ip { get; set; }
        public int Port { get; set; }

        public void InitSocket(object obj)
        {
            try
            {
                if (_networkStream != null)
                {
                    _networkStream.Close();
                    _client.Close();
                }
                _client = new TcpClient();
                _client.Connect(Ip, Port);
                _networkStream = _client.GetStream();
                var time = new Timer();
                time.Elapsed += TimerElapsed;
                time.Interval = Properties.Settings.Default.AutoConnectTime;
                time.Enabled = true;
                _connectState = true;
                ConnetSever(this, new DataChangeEventArgs("true", Ip));
                
            }
            catch (SocketException ex)
            {
                _connectState = false;
                logger.Error("Socket连接异常");
                ConnetSever(this, new DataChangeEventArgs("false", Ip));
            }
        }

        protected void ConnetSever(object sender, DataChangeEventArgs e)
        {
            if (ConnectionServerHandle != null)
            {
                ConnectionServerHandle(sender, e);
            }
        }

        //分析数据
        protected void AnalysisData(byte[] byteBuf)
        {
            foreach (var handler in _handlers)
            {
                if (handler.CanHandle(byteBuf))
                {
                    handler.Handle(byteBuf);
                }
            }
        }

        private void TimerElapsed(object source, ElapsedEventArgs args)
        {
            if (!_connectState) return;
            SendHbTrade();
        }

        //发送心跳信号
        public void SendHbTrade()
        {
            byte[] bytes = BitConverter.GetBytes(IPAddress.HostToNetworkOrder(1));
            byte[] bytet = BitConverter.GetBytes(0x00010100);
            byte[] byteHb = new byte[16] { 0xaa, 0xaa, 0xaa, 0xaa, 0xaa, 0xaa, 0xaa, 0xaa, 0xaa, 0xaa, 0xaa, 0xaa, 0xaa, 0xaa, 0xaa, 0xaa };

            try
            {
                if (_networkStream != null)
                    _networkStream.Write(byteHb, 0, byteHb.Length);
            }
            catch (IOException ex)
            {
                _connectState = false;
                ConnetSever(this, new DataChangeEventArgs("false", Ip));
                return;
            }
            catch (ObjectDisposedException ode)
            {
                //System.Diagnostics.Debug.WriteLine("对象释放异常！");
                return;
            }
        }

        private byte[] BuildPackte(int type,  byte[] data, int pos, int length)
        {
            byte[] byteHb = new byte[length+8];
            
            //包头（格式+包长）
            byteHb[0] = byteHb[2] = 0xaa; byteHb[1] = byteHb[3] = 0x55;
            byteHb[4] = (byte)(((length + 8) & 0xff000000) >> 6); byteHb[5] = (byte)(((length + 8) & 0x00ff0000) >> 4);
            byteHb[6] = (byte)(((length + 8) & 0x0000ff00) >> 2); byteHb[7] = (byte)(((length + 8) & 0x000000ff));

            //数据类型
            byteHb[8] = byteHb[9] = byteHb[10] = 0;
            byteHb[11] = (byte)(type & 0x000000ff);

            //数据长度

            byteHb[12] = (byte)(((length) & 0xff000000) >> 6); byteHb[13] = (byte)(((length) & 0x00ff0000) >> 4);
            byteHb[14] = (byte)(((length) & 0x0000ff00) >> 2); byteHb[15] = (byte)(((length) & 0x000000ff));
            
            //
            Array.Copy(data, pos, byteHb, 16, length);

            return byteHb;

        }

        //发送解码器配置XML
        public void SendDecoderXML(int decoderid)
        {
            
            byte[] byteArray = System.Text.Encoding.Default.GetBytes(DecoderBusiness.Instance.GetDecoderXMLString(decoderid));

            byte[] byteHb = BuildPackte(1, byteArray, 0, byteArray.Length);

            try
            {
                if (_networkStream != null)
                    _networkStream.Write(byteHb, 0, byteHb.Length);
            }
            catch (IOException ex)
            {
                _connectState = false;
                ConnetSever(this, new DataChangeEventArgs("false", Ip));
                return;
            }
            catch (ObjectDisposedException ode)
            {
                //System.Diagnostics.Debug.WriteLine("对象释放异常！");
                return;
            }
        }

        

        static bool IsHeader(byte[] hdr)
        {
            int i = 0;
            if (hdr[i++] == 0xaa && hdr[i++] == 0x55 && hdr[i++] == 0xaa && hdr[i++] == 0x55)
            {
                return true;
            }
            return false;
        }

        //接收数据
        public void GetData()
        {
            var header = new byte[8];
            try
            {
                while ((_networkStream.Read(header, 0, header.Length)) == header.Length)
                {
                    if (IsHeader(header))
                    {

                        int lenInHeader = ToInt32Reverse(header,4);
                        int packetLen = lenInHeader;

                        var pack = new byte[packetLen + header.Length];

                        int byteRead = 0;

                        do
                        {
                            byteRead += _networkStream.Read(pack, 0 + header.Length + byteRead, pack.Length - header.Length - byteRead);
                        } while (byteRead != lenInHeader);

                        if(IsConnected(packetLen, pack))
                            continue;
                        if (byteRead == packetLen)
                        {
                            header.CopyTo(pack, 0);
                            AnalysisData(pack);
                        }
                    }
                }
                
            }
            catch (IOException ex)
            {
                _connectState = false;
                ConnetSever(this, new DataChangeEventArgs("false", Ip));
                return;
            }
            catch (ObjectDisposedException ode)
            {
                _connectState = false;
                return;
            }
            System.Diagnostics.Debug.WriteLine("End of while");
        }

        public bool IsConnected(int len,byte[] data)
        {
            bool ret=true;
            if (len!=16)
            {
                ret = false;
            }
            for (int i = 0; i < len; i++)
            {
                if (data[i]!=0xaa)
                {
                    ret = false;
                    break;
                }
            }
            IsOk = ret;
            return ret;
        }

        public bool IsOk;
        private int ToInt32Reverse(byte[] header, int pos)
        {

            var newbyte = new byte[4];
            for (int i = 0; i < 4; i++)
            {
                newbyte[i] = header[pos + 3 - i];
            }
            return BitConverter.ToInt32(newbyte,0);
        }
    }
}
