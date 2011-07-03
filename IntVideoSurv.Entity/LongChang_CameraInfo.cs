using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Com.SS.Framework.Entity;
using System.Data;
using System.Drawing;
using System.Threading;
namespace IntVideoSurv.Entity
{
    [Serializable]
    public class LongChang_CameraInfo : EntityObject
    {

        //tdid	设备id	变长字符	50		是	是	GUID	新增
        //sbbh	设备编号	变长字符	50					全部
        //sbmc	设备名称	变长字符	100					全部
        //kkmc	卡口名称	变长字符						全部
        //kkbh	卡口编号	变长字符						全部
        //fsbbh	上层设备编号	变长字符	50					全部
        //sblx	设备类型	变长字符	20					全部
        //azwz	安装位置	变长字符	200					全部
        //sbip	设备IP	变长字符	20					全部
        //dkh	设备端口号	变长字符	10					全部
        //sptdh	视频通道号	变长字符	10					全部
        //dlyh	登录用户名	变长字符	20					全部
        //dlmm	登录密码	变长字符	20					全部

        #region construction
        public LongChang_CameraInfo() { }
        public LongChang_CameraInfo(IDataReader dataReader) : base(dataReader) { }
        public LongChang_CameraInfo(DataRow dataRow)
        {
            CameraId = dataRow["sbbh"] is DBNull ? -1 : Convert.ToInt32(dataRow["sbbh"]);
            Name = dataRow["sbmc"] is DBNull ? "" : Convert.ToString(dataRow["sbmc"]);
            TollGateId = dataRow["kkbh"] is DBNull ? -1 : Convert.ToInt32(dataRow["kkbh"]);
            TollGateName = dataRow["kkmc"] is DBNull ? "":Convert.ToString(dataRow["kkmc"]);
            UpperDeviceId = dataRow["fsbbh"] is DBNull ? -1 : Convert.ToInt32(dataRow["fsbbh"]);
            //DeviceType = dataRow["sblx"] is DBNull ? -1 : Convert.ToInt32(dataRow["sblx"]);
            Address = dataRow["azwz"] is DBNull ? "":Convert.ToString(dataRow["azwz"]);
            IP = dataRow["sbip"] is DBNull ? "":Convert.ToString(dataRow["sbip"]);
            Port = dataRow["dkh"] is DBNull ? -1 : Convert.ToInt32(dataRow["dkh"]);
            ChannelNo = dataRow["sptdh"] is DBNull ? -1 : Convert.ToInt32(dataRow["sptdh"]);
            UserName = dataRow["dlyh"] is DBNull ? "":Convert.ToString(dataRow["dlyh"]);
            PassWord = dataRow["dlmm"] is DBNull ? "":Convert.ToString(dataRow["dlmm"]);
            Type = dataRow["sblx"] is DBNull ? -1 : Convert.ToInt32(dataRow["sblx"]);
        }
        #endregion

        [ColumnMapping()]
        public int CameraId { get; set; }
        [ColumnMapping()]
        public string Name { get; set; }
        [ColumnMapping()]
        public int ChannelNo { get; set; }

        [ColumnMapping()]
        public int TollGateId { set; get; }
        [ColumnMapping()]
        public string TollGateName { get; set; }

        [ColumnMapping()]
        public int UpperDeviceId { set; get; }
        [ColumnMapping()]
        public int DeviceType { set; get; }
        [ColumnMapping()]
        public string Address { set; get; }
        [ColumnMapping()]
        public string IP { set; get; }
        [ColumnMapping()]
        public int Port { get; set; }
        [ColumnMapping()]
        public string UserName { get; set; }
        [ColumnMapping()]
        public string PassWord { get; set; }

        //2011-6-28添加，1表示枪机、2表示球机
        [ColumnMapping()]
        public int Type { get; set; }
 
        public override string ToString()
        {
            return String.Format("ID:{0}  名称:{1}  地址:{2}  设备ID:{3}  设备名:{4}", CameraId, Name, Address, IP, TollGateName);

        }
    }
}

