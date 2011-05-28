// Camera Vision
//
// Copyright ?Andrew Kirillov, 2005-2006
// andrew.kirillov@gmail.com
//
namespace CameraViewer
{
	using System;
	using System.Collections;
    using IntVideoSurv.Entity;
    using System.Collections.Generic;
    using IntVideoSurv.Business;
    using videosource;
    using System.Threading;
    using CameraViewer.Controls;

	/// <summary>
	/// RunningPool
	/// </summary>
	public class RunningPool 
	{
		// Configuration
        Dictionary<int , DeviceDriver> RunningDriverList = null;
        Dictionary<int, DeviceInfo > RunningDeviceList = null;
         
        private Thread thread;
        private ManualResetEvent stopEvent = null;
        string appPath = "";
		public RunningPool()
		{
            appPath = AppDomain.CurrentDomain.BaseDirectory;
            RunningDriverList = new Dictionary<int, DeviceDriver>();
            RunningDeviceList = new Dictionary<int, DeviceInfo>();
            DeviceBusiness.Instance.Load(appPath);

		}
        public void Start()
        {
            // create events
            stopEvent = new ManualResetEvent(false);

            // create and start new thread
            thread = new Thread(new ThreadStart(WorkerThread));
            thread.Start();
        }

        // Stop the pool
        public void Stop()
        {
            if (thread != null)
            {
                // signal to stop
                stopEvent.Set();
                // wait for thread stop
                thread.Join();

                thread = null;

                // release events
                stopEvent.Close();
                stopEvent = null;
            }
        }

        // Thread entry point
        private void WorkerThread()
        {
            while (!stopEvent.WaitOne(0, true))
            {
                // lock
                Monitor.Enter(this);

               
                // unlock
                Monitor.Exit(this);

                // sleep for a while
                Thread.Sleep(300);
            }
            foreach (KeyValuePair<int,DeviceDriver> item in RunningDriverList)
            {
                item.Value.Stop();

            }
            foreach (KeyValuePair<int, DeviceDriver> item in RunningDriverList)
            {
                item.Value.Close();

            }
         
        }
       

		// Add new camera to the collection and run it
        public bool Add(CameraPlay camwin, DeviceInfo deviceInfo, CameraInfo camera)
		{
			// create video source

            IVideoSource videoSource=  DeviceBusiness.Instance.CreateVideoSource(deviceInfo.ProviderName);
            if (videoSource == null)
            {
                return false;
            }
            DeviceDriver device = new DeviceDriver(videoSource);
            if (!RunningDeviceList.ContainsKey(deviceInfo.DeviceId))
            {
                deviceInfo.ServiceID = -1;
                device.Init(ref deviceInfo);
                RunningDeviceList.Add(deviceInfo.DeviceId, deviceInfo);
                RunningDriverList.Add(camera.CameraId, device);

            }
            else
            {
                deviceInfo = RunningDeviceList[deviceInfo.DeviceId];
                device.Init(ref deviceInfo);
                
                RunningDriverList.Add(camera.CameraId, device);
            }
            
            device.Start(ref camera);
            camwin.Camera = device;
			return true;
		}

        public bool Add(CameraWindow camwin, DeviceInfo deviceInfo, CameraInfo camera)
        {
            // create video source

            IVideoSource videoSource = DeviceBusiness.Instance.CreateVideoSource(deviceInfo.ProviderName);
            if (videoSource == null)
            {
                return false;
            }
            DeviceDriver device = new DeviceDriver(videoSource);

            if (!RunningDeviceList.ContainsKey(deviceInfo.DeviceId))
            {
                deviceInfo.ServiceID = -1;
                device.Init(ref deviceInfo);
                RunningDeviceList.Add(deviceInfo.DeviceId, deviceInfo);
                RunningDriverList.Add(camera.CameraId, device);

            }
            else
            {
                deviceInfo = RunningDeviceList[deviceInfo.DeviceId];
                device.Init(ref deviceInfo);

                RunningDriverList.Add(camera.CameraId, device);
            }

            device.Start(ref camera);
           // camwin.Camera = device;
            return true;
        }
         

		// Remove camera from the collection and signal to stop it
        public void Remove(CameraInfo camera)
		{
            DeviceDriver device;
            if (RunningDriverList.ContainsKey(camera.CameraId))
            {
                device = RunningDriverList[camera.CameraId];
                device.SignalToStop();
                RunningDriverList.Remove(camera.CameraId);

            }
		}

	}
}
