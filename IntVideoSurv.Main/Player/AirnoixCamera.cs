using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace CameraViewer.Player
{
    public class AirnoixCamera : IDisposable
    {
        private IntPtr _camHandle;

        private System.IO.BinaryWriter _writer;
        private byte[] _header;
        private DateTime _lastRecordTime;

        private bool _disposed;
        private byte[] _buf = new byte[512 * 1024];
        private string _tempFile;

        private AirnoixClient.StreamReadCallback _streamReadCallback;
        private AirnoixClient.MessageCallback _messageCallback;

        public uint LastStateCode{get; set; }
        public bool Started { get; set; }
        public int Id { get; set; }
        public int Type { get; set; }
        public bool IsAlive{ get; set; }
        private string _userName;
        public string UserName
        {
            get { return _userName; }
            set
            {
                _userName = value;
                AirnoixClient.MP4_ClientSetConnectUser(_camHandle, value, Password);
            }
        }

        private string _password;
        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                AirnoixClient.MP4_ClientSetConnectUser(_camHandle, UserName, value);
            }
        }

        public System.Drawing.Rectangle DisplayPos
        {
            set
            {
                var tagRect = new tagRECT();
                tagRect.left = value.Left;
                tagRect.top = value.Top;
                tagRect.right = value.Right;
                tagRect.bottom = value.Bottom;

                AirnoixClient.MP4_ClientSetDisPlayPos(_camHandle, ref tagRect);
            }
        }

        public string Ip { get; set; }
        public int Port { get; set; }
        public string SaveTo { get; set; }
        public int StreamId { get; set; }
        public DateTime BeginCaptureTime { get; set; }
        public DateTime EndCaptureTime { get; set; }

        public AirnoixCamera(IntPtr hWnd)
        {
            _camHandle = AirnoixClient.MP4_ClientInit(hWnd, 0xa0000, 0x200, 0);
            _messageCallback = MessageCallback;
            _streamReadCallback = StreamReadCallback;

            AirnoixClient.MP4_ClientRegisterErrorCallBack(_camHandle, _messageCallback, IntPtr.Zero);
            AirnoixClient.MP4_ClientRegisterStreamCallBack(_camHandle, _streamReadCallback, IntPtr.Zero);

            _tempFile = Path.GetTempFileName() + ".jpg";

            GC.KeepAlive(_messageCallback);
            GC.KeepAlive(_streamReadCallback);
        }

        ~AirnoixCamera()
        {
            Dispose(false);
        }

        public void Start()
        {

            AirnoixClient.MP4_ClientConnectEx(_camHandle, Ip, (uint)Port, 0, (uint)StreamId, 0);
            Started = true;
        }

        public void Stop()
        {
            AirnoixClient.MP4_ClientDisConnect(_camHandle);
            Started = false;
        }

        public void StartRecord()
        {
            if (!Directory.Exists(SaveTo))
            {
                throw new InvalidOperationException("SaveTo must be set");
            }

            AirnoixClient.MP4_ClientStartCapture(_camHandle);
            BeginCaptureTime = DateTime.Now;
        }

        public void StopRecord()
        {
            _isRecording = false;
            AirnoixClient.MP4_ClientStopCapture(_camHandle);
            EndCaptureTime = DateTime.Now;
            DisposeWriter();
        }

        public System.Drawing.Image CaptureImage()
        {
            if (!Started)
            {
                throw new InvalidOperationException("Start() must be called before calling CaptureImage()");
            }

            AirnoixClient.MP4_ClientCapturePicturefile(_camHandle, _tempFile);
            return System.Drawing.Image.FromFile(_tempFile);
        }


        public void MessageCallback(System.IntPtr hClient, uint dwCode, System.IntPtr context)
        {
             LastStateCode = dwCode;
             IsAlive = (LastStateCode == 0x30 || LastStateCode == 0x40) ? true : false;
        }

        private bool _isRecording = false;
        public string VideoPath { set; get;}
        public int StreamReadCallback(System.IntPtr hClient, System.IntPtr context)
        {
            int type = 0;
            while (true)
            {
                var len = AirnoixClient.MP4_ClientReadStreamData(_camHandle, _buf, _buf.Length, ref type);
                if (len <= 0) break;

                //视频文件头
                if (type == 0x80)
                {
                    if ((_isRecording==false)||(_header == null))
                    {

                        DisposeWriter();
                        _header = new byte[len];
                        Array.Copy(_buf, 0, _header, 0, len);
                        var now = DateTime.Now;
                        var file = Ip + now.ToString("HH-mm-ss") + ".mkv";
                        var path = Path.Combine(Properties.Settings.Default.RecordTempVideoPath,file);
                        VideoPath = path;
                        _writer = new BinaryWriter(File.OpenWrite(path));
                        _writer.Write(_header);
                        _isRecording = true;

                    }
                }
                //视频数据
                if (_writer != null && len > 0 && type != 0x80)
                {
                    _writer.Write(_buf, 0, len);
                }

            }

            return 0;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void DisposeWriter()
        {
            if (_writer != null)
            {
                _writer.Close();
                _writer = null;
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                AirnoixClient.MP4_ClientStopCapture(_camHandle);
                AirnoixClient.MP4_ClientDisConnect(_camHandle);
                AirnoixClient.MP4_ClientUInit(_camHandle);

                if (disposing)
                {
                    DisposeWriter();
                }

            }

            _disposed = true;
        }

    }
}
