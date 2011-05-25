using System;
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
    public class DecoderInfo : EntityObject
    {
        public DecoderInfo() { }
        
        public DecoderInfo(IDataReader dataReader) : base(dataReader) { }
        
        public DecoderInfo(DataRow dataRow)
        {
            id = Convert.ToInt32(dataRow["id"]);
            Ip = Convert.ToString(dataRow["Ip"]);
            Name = Convert.ToString(dataRow["Name"]);
            Port = Convert.ToInt32(dataRow["Port"]);
            MaxDecodeChannelNo = Convert.ToInt32(dataRow["MaxDecodeChannelNo"]);
        }

        [ColumnMapping()]
        public int id { get; set; }

        [ColumnMapping()]
        public string Name { set; get; }
        [ColumnMapping()]
        public string Ip { get; set; }

        [ColumnMapping()]
        public int Port { get; set; }
        [ColumnMapping()]
        public int MaxDecodeChannelNo{ get; set; }
        public Dictionary<int, CameraInfo> ListCameras{ get; set; }

    }
}