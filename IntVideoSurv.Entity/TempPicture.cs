using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Com.SS.Framework.Entity;

namespace IntVideoSurv.Entity
{
    [Serializable]
    public class TempPicture : EntityObject
    {
        #region construction
        public TempPicture() { }
        public TempPicture(IDataReader dataReader) : base(dataReader) { }
        public TempPicture(DataRow dataRow)
        {
            PictureID = Convert.ToInt32(dataRow["PictureID"]);
            CameraID = Convert.ToInt32(dataRow["CameraID"]);
            Datetime = Convert.ToDateTime(dataRow["Datetime"]);
            FilePath = Convert.ToString(dataRow["FilePath"]);
            IsHistroy = Convert.ToBoolean(dataRow["IsHistroy"]);
        }
        #endregion

        [ColumnMapping()]
        public int PictureID { get; set; }
        [ColumnMapping()]
        public int CameraID { get; set; }
        [ColumnMapping()]
        public DateTime Datetime { get; set; }
        [ColumnMapping()]
        public string FilePath { get; set; }
        [ColumnMapping()]
        public bool IsHistroy { get; set; }


    }
}
