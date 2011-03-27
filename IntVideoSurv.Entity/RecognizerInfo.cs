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
    public class RecognizerInfo : EntityObject
    {
        public RecognizerInfo() { }

        public RecognizerInfo(IDataReader dataReader) : base(dataReader) { }

        public RecognizerInfo(DataRow dataRow) : base(dataRow) { }

        [ColumnMapping()]
        public int Id { get; set; }

        [ColumnMapping()]
        public string Name { set; get; }
        [ColumnMapping()]
        public string Ip { get; set; }

        [ColumnMapping()]
        public int Port { get; set; }
        [ColumnMapping()]
        public int MaxRecogNumber { get; set; }
        public Dictionary<int, CameraInfo> ListCameras { get; set; }

    }
}
