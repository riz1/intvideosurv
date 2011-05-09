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
            : base(dataRow)
        {
        }
#endregion
        [ColumnMapping()]
        public int FaceID {get;set;}
        [ColumnMapping()]
        public double score { get; set; }
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
