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
    public class TaskInfo : EntityObject
    {
        public TaskInfo() { }

        public TaskInfo(IDataReader dataReader) : base(dataReader) { }

        public TaskInfo(DataRow dataRow) : base(dataRow) { }

        [ColumnMapping()]
        public int TaskId { get; set; }

        [ColumnMapping()]
        public int CameraId { set; get; }
        [ColumnMapping()]
        public int DecoderId { get; set; }
        [ColumnMapping()]
        public int Status { get; set; }
        [ColumnMapping()]
        public DateTime HappenDateTime { get; set; }

    }

    [Serializable]
    public enum TaskStatus
    {
        StartSend=0,
        StartSuccess = 1,
        StartError = 2,
        Running=4,
        StopSend=8,
        StopSuccess = 16,
        StopError = 32
    }
}