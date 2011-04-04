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
            : base(dataRow)
        {
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
