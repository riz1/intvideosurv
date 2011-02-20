using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using IntVideoSurv.Entity;
using IntVideoSurv.DataAccess;
using log4net;
using System.IO;
using videosource;
using System.Reflection;
using System.Threading;
using System.Drawing;

namespace IntVideoSurv.Business
{
    public class DeviceDriver
    {
        private IVideoSource _videoSource = null;
        private DeviceInfo _deviceInfo = null;
        private CameraInfo _cameraInfo = null;
        public IVideoSource videoSource = null;
        private Bitmap lastFrame = null;
        public event EventHandler NewFrame;

        public DeviceDriver(IVideoSource videoSource)
        {
            _videoSource = videoSource;
        }
        public bool Init(ref DeviceInfo deviceInfo)
        {
            bool bRtn = false;
            _deviceInfo = deviceInfo;
            if (_deviceInfo.DeviceRunningStatus)
            {
                return true;
            }
            if (_videoSource != null)
            {
                _videoSource.Init(ref deviceInfo);
                bRtn = true;

            }
            return bRtn;
        }


        public void Close()
        {
            if (videoSource != null)
            {
                _videoSource.Close();
                videoSource = null;

            }
            // dispose old frame
            if (lastFrame != null)
            {
                lastFrame.Dispose();
                lastFrame = null;
            }

        }
        public int GetJpegImage(ref byte[] imageBuf)
        {
            int iRtn = -1;
            if (_videoSource != null)
            {
                iRtn = _videoSource.GetJpegImage(ref imageBuf);
            }
            return iRtn;
        }

        // Start video source
        public void Start(ref CameraInfo cameraInfo)
        {
            _cameraInfo = cameraInfo;
            if (_videoSource != null)
            {
                _videoSource.NewFrame += new CameraEventHandler(video_NewFrame);
                _videoSource.Handle = _cameraInfo.Handle;
                _videoSource.Start(ref cameraInfo);
                _cameraInfo = cameraInfo;
            }
        }

        // Siganl video source to stop
        public void SignalToStop()
        {
            if (_videoSource != null)
            {
                _videoSource.SignalToStop();
            }
        }

        // Wait video source for stop
        public void WaitForStop()
        {
            // lock
            Monitor.Enter(this);

            if (_videoSource != null)
            {
                _videoSource.WaitForStop();
            }
            // unlock
            Monitor.Exit(this);
        }

        // Abort camera
        public void Stop()
        {
            // lock
            Monitor.Enter(this);

            if (_videoSource != null)
            {
                _videoSource.Stop();
            }
            // unlock
            Monitor.Exit(this);
        }

        // Lock it
        public void Lock()
        {
            Monitor.Enter(this);
        }

        // Unlock it
        public void Unlock()
        {
            Monitor.Exit(this);
        }
        public CameraInfo CurrentCamera
        {
            get
            {
                if (_cameraInfo == null)
                {
                     _cameraInfo =new CameraInfo();
                }
                return _cameraInfo;
            }
        }
        public Bitmap LastFrame
        {
            get { return lastFrame; }
        }
        // On new frame
        private void video_NewFrame(object sender, CameraEventArgs e)
        {
            // lock
            Monitor.Enter(this);

            // dispose old frame
            if (lastFrame != null)
            {
                lastFrame.Dispose();
            }

            lastFrame = (Bitmap)e.Bitmap.Clone();

            // image dimension
            _cameraInfo.Width = lastFrame.Width;
            _cameraInfo.Height = lastFrame.Height;

            // unlock
            Monitor.Exit(this);

            // notify client
            if (NewFrame != null)
                NewFrame(this, new EventArgs());
        }



    }
}
