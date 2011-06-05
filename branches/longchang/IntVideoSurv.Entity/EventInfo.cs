using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Com.SS.Framework.Entity;
using System.Data;
namespace IntVideoSurv.Entity
{
    public class Event : EntityObject
    {
        #region construction
        public Event() { }
        public Event(IDataReader dataReader) : base(dataReader) { }
        public Event(DataRow dataRow)
        {
            EventId = Convert.ToInt32(dataRow["EventId"]);
            CarNum = Convert.ToInt32(dataRow["CarNum"]);
            Congestion = Convert.ToInt32(dataRow["Congestion"]);
            PictureID = Convert.ToInt32(dataRow["PictureID"]);
        }
        #endregion
        [ColumnMapping()]
        public int EventId { get; set; }
        [ColumnMapping()]
        public int CarNum { get; set; }
        [ColumnMapping()]
        public int Congestion { get; set; }
        [ColumnMapping()]
        public int PictureID { get; set; }
        [ColumnMapping()]
        public int VideoId { get; set; }

        public CapturePicture CapturePicture { get; set; }
        public VideoInfo VideoInfo { get; set; }
        public CameraInfo CameraInfo { get; set; }

        public Dictionary<int, ObjectInfo> listObject { get; set; }
    }
}
