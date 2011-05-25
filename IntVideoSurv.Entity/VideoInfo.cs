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
    public class VideoInfo : EntityObject
    {
        #region construction

        public VideoInfo() { }
        public VideoInfo(IDataReader dataReader) : base(dataReader) { }
        public VideoInfo(DataRow dataRow)
        {
            Id = Convert.ToInt32(dataRow["Id"]);
            CameraId = Convert.ToInt32(dataRow["CameraId"]);
            CaptureTimeBegin = Convert.ToDateTime(dataRow["CaptureTimeBegin"]);
            CaptureTimeEnd = Convert.ToDateTime(dataRow["CaptureTimeEnd"]);
            FilePath = Convert.ToString(dataRow["FilePath"]);
        }
        #endregion

        [ColumnMapping()]
        public int Id { get; set; }

        [ColumnMapping()]
        public int CameraId { get; set; }

        [ColumnMapping()]
        public DateTime CaptureTimeBegin { get; set; }

        [ColumnMapping()]
        public DateTime CaptureTimeEnd { get; set; }


        [ColumnMapping()]
        public string FilePath { get; set; }

        public CameraInfo CameraInfo;

    
    }

}
