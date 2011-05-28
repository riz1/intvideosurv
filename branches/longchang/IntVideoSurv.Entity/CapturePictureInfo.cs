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
    public class CapturePicture : EntityObject
    {
        #region construction
        public CapturePicture() { }
        public CapturePicture(IDataReader dataReader) : base(dataReader) { }
        public CapturePicture(DataRow dataRow)
        {
            PictureID = Convert.ToInt32(dataRow["PictureID"]);
            CameraID = Convert.ToInt32(dataRow["CameraID"]);
            Datetime = Convert.ToDateTime(dataRow["Datetime"]);
            FilePath = Convert.ToString(dataRow["FilePath"]);

        }
#endregion
        
        [ColumnMapping()]
        public int PictureID { get; set; }
        [ColumnMapping()]
        public int CameraID{get;set;}
        [ColumnMapping()]
        public DateTime Datetime {get;set;}
        [ColumnMapping()]
        public string FilePath { get; set; }

    }
}
