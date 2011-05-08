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
    public class Vehicle : EntityObject
    {
         #region construction
        public Vehicle() { }
        public Vehicle(IDataReader dataReader) : base(dataReader) { }
        public Vehicle(DataRow dataRow)
            : base(dataRow)
        {
        }
        #endregion

        
        [ColumnMapping()]
        public int VehicleID {get;set;}
        [ColumnMapping()]
        public string platenumber { get; set; }
        [ColumnMapping()]
        public float speed { get; set; }
        [ColumnMapping()]
        public bool stemagainst { get; set; }
        [ColumnMapping()]
        public bool stop { get; set; }
        [ColumnMapping()]
        public bool accident { get; set; }
        [ColumnMapping()]
        public bool linechange { get; set; }
        [ColumnMapping()]
        public string platecolor{ get; set; }
        [ColumnMapping()]
        public string vehiclecolor { get; set; }
        [ColumnMapping()]
        public int PictureID { get; set; }
        [ColumnMapping()]
        public int REctId { get; set; }
        [ColumnMapping]
        public int confidence { get; set;}
        public string PicturePath;
        public int VideoId;
        public string VideoPath;

    }
}
