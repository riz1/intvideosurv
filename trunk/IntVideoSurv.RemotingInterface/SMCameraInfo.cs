using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Com.SS.Framework.Entity;
using System.Data;

namespace SMRemotingInterface
{
    [Serializable]
    public class SMCameraInfo : EntityObject
    {
        #region construction
        public SMCameraInfo() { }
        public SMCameraInfo(IDataReader dataReader) : base(dataReader) { }
        public SMCameraInfo(DataRow dataRow)
            : base(dataRow)
        {
            //RstpUrl上网内容为：192.168.1.234:8000:HIK-DS8000HC:0:0:admin:12345/av_stream，需要客户端自己添加"rtsp://服务器IP地址/"
            RstpUrl = String.Format("{0}:{1}:HIK-DS8000HC:{2}:{2}:{3}:{4}/av_stream", DeviceIp, DevicePort,
                                    MasterChannelNo, DeviceLoginName, DeviceLoginPassword);
        }
        #endregion

        [ColumnMapping()]
        public int CameraId { get; set; }
        [ColumnMapping()]
        public string CameraName { get; set; }
        [ColumnMapping()]
        public string CameraDescription { get; set; }
        [ColumnMapping()]
        public bool IsCameraValid { get; set; }
        [ColumnMapping()]
        public int MasterChannelNo { get; set; }
        [ColumnMapping()]
        public string ConnUrl { get; set; }
        [ColumnMapping()]
        public bool IsDetect { get; set; }
        [ColumnMapping()]
        public int StreamType { get; set; }
        [ColumnMapping()]
        public int DeviceId { get; set; }
        [ColumnMapping()]
        public string DeviceName { get; set; }
        [ColumnMapping()]
        public string DeviceIp { get; set; }
        [ColumnMapping()]
        public string DeviceType { get; set; }
        [ColumnMapping()]
        public int DevicePort { get; set; }
        [ColumnMapping()]
        public string DeviceLoginName { get; set; }
        [ColumnMapping()]
        public string DeviceLoginPassword { get; set; }
        [ColumnMapping()]
        public string GroupName { get; set; }
        [ColumnMapping()]
        public int GroupId { get; set; }

        //服务器的RTSP信息，除了服务器端的IP地址
        //完整的格式为：rtsp://127.0.0.1/192.168.1.234:8000:HIK-DS8000HC:0:0:admin:12345/av_stream
        //RstpUrl上网内容为：192.168.1.234:8000:HIK-DS8000HC:0:0:admin:12345/av_stream，需要客户端自己添加"rtsp://服务器IP地址/"
        public string RstpUrl { get; set; }

        public int SecondaryChannelNo { get; set; }

        //public override string ToString()
        //{
        //    return String.Format("ID:{0}  名称:{1}  描述:{2}  设备ID:{3}  设备名:{4}", CameraId, CameraName, CameraDescription, DeviceId, DeviceName);

        //}
    }
}
