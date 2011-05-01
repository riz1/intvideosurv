using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using IntVideoSurv.Business;
using IntVideoSurv.Entity;
using log4net;

namespace CameraViewer.NetWorking
{
    public class DecoderClientConnection
    {
        public string Ip { get; set; }
        public int Port { get; set; }
        
        private NetworkStream _networkStream;
        private Socket _socket;
        public DecoderInfo DecoderInfo;

        private IPacketHandler[] _handlers;
        public LiveDecoderPacketHandle LiveDecoderPacketHandle;
        public DecoderStateHandle DecoderStateHandle;
        public static readonly ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        
        public DecoderClientConnection(Socket socket)
        {
            string errMessage = "";
            _socket = socket;
            Ip = ((IPEndPoint) socket.RemoteEndPoint).Address.ToString();
            Port = ((IPEndPoint)socket.RemoteEndPoint).Port;
            DecoderInfo = DecoderBusiness.Instance.GetDecoderInfoByDecoderIP(ref errMessage, Ip);
            _networkStream = new NetworkStream(socket);
            LiveDecoderPacketHandle = new LiveDecoderPacketHandle();
            DecoderStateHandle = new DecoderStateHandle();
            _handlers = new IPacketHandler[] { LiveDecoderPacketHandle, DecoderStateHandle };


        }
        public int Read(byte[] recb,int pos,int length)
        {
            int len = 0;
            try
            {
               len = _networkStream.Read(recb, 0, recb.Length);
            }
            catch (Exception)
            {
                len = 0;
                logger.Error(Ip + ":" + Port +" Socket连接异常");
            }
            return len;
        }
        

        //分析数据
        public void AnalysisData(byte[] byteBuf)
        {
            foreach (var handler in _handlers)
            {
                if (handler.CanHandle(byteBuf))
                {
                    handler.Handle(byteBuf);
                }
            }
        }
        //发送心跳信号
        public void SendHbTrade()
        {
            byte[] byteHb = new byte[16] { 0xaa, 0xaa, 0xaa, 0xaa, 0xaa, 0xaa, 0xaa, 0xaa, 0xaa, 0xaa, 0xaa, 0xaa, 0xaa, 0xaa, 0xaa, 0xaa };
            byte[] byteToSend = BuildPacket(99, byteHb, 0, 16);
            try
            {
                if (_networkStream != null)
                    _networkStream.Write(byteToSend, 0, byteToSend.Length);
            }
            catch (IOException ex)
            {
                //_connectState = false;
                //ConnetSever(this, new DataChangeEventArgs("false", Ip));
                return;
            }
            catch (ObjectDisposedException ode)
            {
                //System.Diagnostics.Debug.WriteLine("对象释放异常！");
                return;
            }
        }

        private byte[] BuildPacket(int type, byte[] data, int pos, int length)
        {
            int dataLength = (length + 8);
            byte[] byteHb = new byte[dataLength + 8];

            //包头（格式+包长）
            byteHb[0] = byteHb[2] = 0xaa; byteHb[1] = byteHb[3] = 0x55;
            Array.Copy(BitConverter.GetBytes(dataLength), 0, byteHb, 4, 4);

            //数据类型

            Array.Copy(BitConverter.GetBytes(type), 0, byteHb, 8, 4);

            //数据长度
            Array.Copy(BitConverter.GetBytes(length), 0, byteHb, 12, 4);

            //真实数据
            Array.Copy(data, pos, byteHb, 16, length);

            return byteHb;

        }

        //发送解码器配置XML
        public void SendDecoderXML(int decoderid)
        {

            byte[] byteArray = System.Text.Encoding.Default.GetBytes(DecoderBusiness.Instance.GetDecoderXMLString(decoderid));

            byte[] byteToSend = BuildPacket(1, byteArray, 0, byteArray.Length);

            try
            {
                if (_networkStream != null)
                    _networkStream.Write(byteToSend, 0, byteToSend.Length);
            }
            catch (IOException ex)
            {
                //_connectState = false;
                //ConnetSever(this, new DataChangeEventArgs("false", Ip));
                return;
            }
            catch (ObjectDisposedException ode)
            {
                //System.Diagnostics.Debug.WriteLine("对象释放异常！");
                return;
            }
        }


        //发送解码器配置XML
        public void SendDecoderXML()
        {

            byte[] byteArray = System.Text.Encoding.Default.GetBytes(DecoderBusiness.Instance.GetDecoderXMLString(DecoderInfo.id));

            byte[] byteToSend = BuildPacket(1, byteArray, 0, byteArray.Length);

            try
            {
                if (_networkStream != null)
                    _networkStream.Write(byteToSend, 0, byteToSend.Length);
            }
            catch (IOException ex)
            {
                //_connectState = false;
                //ConnetSever(this, new DataChangeEventArgs("false", Ip));
                return;
            }
            catch (ObjectDisposedException ode)
            {
                //System.Diagnostics.Debug.WriteLine("对象释放异常！");
                return;
            }
        }

        //发送解码器启动指令

        public void SendDecoderStartCommand()
        {
            byte[] bytes = new byte[0];
            byte[] byteToSend = BuildPacket(2, bytes, 0, 0);

            try
            {
                if (_networkStream != null)
                    _networkStream.Write(byteToSend, 0, byteToSend.Length);
            }
            catch (IOException ex)
            {
                //_connectState = false;
                //ConnetSever(this, new DataChangeEventArgs("false", Ip));
                return;
            }
            catch (ObjectDisposedException ode)
            {
                //System.Diagnostics.Debug.WriteLine("对象释放异常！");
                return;
            }
        }

        //发送解码器停止指令

        public void SendDecoderStopCommand()
        {
            byte[] bytes = new byte[0];
            byte[] byteToSend = BuildPacket(3, bytes, 0, 0);

            try
            {
                if (_networkStream != null)
                    _networkStream.Write(byteToSend, 0, byteToSend.Length);
            }
            catch (IOException ex)
            {
                //_connectState = false;
                //ConnetSever(this, new DataChangeEventArgs("false", Ip));
                return;
            }
            catch (ObjectDisposedException ode)
            {
                //System.Diagnostics.Debug.WriteLine("对象释放异常！");
                return;
            }
        }
        //设置图片长宽

        public void SetPicWidthHeight(int width, int height)
        {
            byte[] bytes = new byte[8];
            Array.Copy(BitConverter.GetBytes(width), 0, bytes, 0, 4);
            Array.Copy(BitConverter.GetBytes(height), 0, bytes, 4, 4);

            byte[] byteToSend = BuildPacket(5, bytes, 0, 8);

            try
            {
                if (_networkStream != null)
                    _networkStream.Write(byteToSend, 0, byteToSend.Length);
            }
            catch (IOException ex)
            {
                //_connectState = false;
                //ConnetSever(this, new DataChangeEventArgs("false", Ip));
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

                        int lenInHeader = BitConverter.ToInt32(header, 4);
                        int packetLen = lenInHeader;

                        var pack = new byte[packetLen];

                        int byteRead = 0;

                        do
                        {
                            byteRead += _networkStream.Read(pack, byteRead, pack.Length - byteRead);
                        } while (byteRead != lenInHeader);

                        if (IsConnected(packetLen, pack))
                            continue;
                        if (byteRead == packetLen)
                        {
                            AnalysisData(pack);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                logger.Error(Ip + ":" + Port + " Socket连接异常");
                return;
            }
        }

        public bool IsOk;
        public bool IsConnected(int len, byte[] data)
        {
            bool ret = true;
            if (len != 16)
            {
                ret = false;
            }
            for (int i = 0; i < len; i++)
            {
                if (data[i] != 0xaa)
                {
                    ret = false;
                    break;
                }
            }
            IsOk = ret;
            return ret;
        }

    }
}
