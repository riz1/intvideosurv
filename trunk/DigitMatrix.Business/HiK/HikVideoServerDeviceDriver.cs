using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IntVideoSurv.Entity;

namespace IntVideoSurv.Business.HiK
{
    public class HikVideoServerDeviceDriver : IDisposable
    {
        public bool IsValidDevice { get; set; }
        public int ServiceId { get; set; }
        public DeviceInfo _deviceInfo = null;
        public string ErrMessage { get; set; }
        public int DecodeCardNum { get; set; }
        public bool IsValidEncodeCard { get; set; }
        public void Init(ref DeviceInfo deviceInfo)
        {
            try
            {
                ErrMessage = "";
                IsValidDevice = false;
                int devicenumber = 0;
                bool bRtn = HCNetSDK.NET_DVR_Init();  //初始化SDK
                if (!bRtn)
                {
                    return;
                }
                NET_DVR_DEVICEINFO_V30 RESULT;  //得到设备参数的结构体
                int serviceId = HCNetSDK.NET_DVR_Login_V30(deviceInfo.source, (ushort)deviceInfo.Port, deviceInfo.login, deviceInfo.pwd, out RESULT);
                ServiceId = serviceId;
                HikPlayer.PlayM4_InitDDrawDevice();
                deviceInfo.ServiceID = serviceId;
                if (serviceId > -1)
                {
                    deviceInfo.IsReady = true;
                    IsValidDevice = true;
                }
                else
                {
                    deviceInfo.IsReady = false;
                    IsValidDevice = false;
                }
                IsValidEncodeCard= HCNetSDK.NET_DVR_InitDevice_Card(ref devicenumber);
                DecodeCardNum = devicenumber;
                if (devicenumber > 0)
                {
                   IsValidEncodeCard= HCNetSDK.NET_DVR_InitDDraw_Card(deviceInfo.Handle, 0xffffff);
                }

                

                _deviceInfo = deviceInfo;
            }
            catch (Exception ex)
            {
                ErrMessage = ex.Message;
            }
        }
        public int Close()
        {
            try
            {
                HCNetSDK.NET_DVR_Logout_V30(_deviceInfo.ServiceID);
                HikPlayer.PlayM4_ReleaseDDrawDevice();
                foreach (var c in HikVideoServerCameraDriver.ListSerialHandle)
                {
                    if (c.Key == _deviceInfo.DeviceId)
                    {
                        HCNetSDK.NET_DVR_SerialStop(c.Value);
                    }
                }
                HikVideoServerCameraDriver.ListSerialHandle.Remove(_deviceInfo.DeviceId);
                return 1;
            }
            catch (Exception ex)
            {
                ErrMessage = ex.Message;
                return -1;
            }
        }

        #region IDisposable 成员

        public void Dispose()
        {
            Close();
        }

        #endregion
    }
}
