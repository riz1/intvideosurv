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
        public DecoderInfo(DataRow dataRow) : base(dataRow) { }

        [ColumnMapping()]
        public int id { get; set; }
        [ColumnMapping()]
        public string Name { get; set; }
        [ColumnMapping()]
        public string Ip { get; set; }

        [ColumnMapping()]
        public int Port { get; set; }
        [ColumnMapping()]
        public int MaxDecodeChannelNo{ get; set; }
        public Dictionary<int, CameraInfo> ListCameras{ get; set; }

    }
}