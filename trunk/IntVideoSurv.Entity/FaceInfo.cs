using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Com.SS.Framework.Entity;
using System.Data;

namespace IntVideoSurv.Entity
{
    [Serializable]
    public class Face : EntityObject 
    {
        #region construction
        public Face() { }
        public Face(IDataReader dataReader) : base(dataReader) { }
        public Face(DataRow dataRow)
        {
            FaceID = Convert.ToInt32(dataRow["FaceID"]);
            score = Convert.ToSingle(dataRow["score"]);
            RectID = Convert.ToInt32(dataRow["RectID"]);
            PictureID = Convert.ToInt32(dataRow["PictureID"]);
            FacePath = Convert.ToString(dataRow["FacePath"]);
            VideoId = Convert.ToInt32(dataRow["VideoId"]);
        }
#endregion
        [ColumnMapping()]
        public int FaceID {get;set;}
        [ColumnMapping()]
        public float score { get; set; }
        [ColumnMapping()]
        public int RectID { get; set; }
        [ColumnMapping()]
        public int PictureID { get; set; }

        //新加的
        [ColumnMapping()]
        public string FacePath { get; set; }
        [ColumnMapping()]
        public int VideoId { get; set; }

        public CapturePicture CapturePicture { get; set; }
        public VideoInfo VideoInfo { get; set; }
        public CameraInfo CameraInfo { get; set; }

    }
}
