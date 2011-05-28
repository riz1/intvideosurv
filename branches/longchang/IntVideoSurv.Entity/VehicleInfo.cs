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
        {
            VehicleID = Convert.ToInt32(dataRow["VehicleID"]);
            platenumber = Convert.ToString(dataRow["platenumber"]);
            speed = Convert.ToSingle(dataRow["speed"]);
            stemagainst = Convert.ToBoolean(dataRow["stemagainst"]);
            stop = Convert.ToBoolean(dataRow["stop"]);
            accident = Convert.ToBoolean(dataRow["accident"]);
            linechange = Convert.ToBoolean(dataRow["linechange"]);
            platecolor = Convert.ToString(dataRow["platecolor"]);
            vehiclecolor = Convert.ToString(dataRow["vehiclecolor"]);
            PictureID = Convert.ToInt32(dataRow["PictureID"]);
            REctId = Convert.ToInt32(dataRow["REctId"]);
            confidence = Convert.ToSingle(dataRow["confidence"]);
            VedioId = Convert.ToInt32(dataRow["VedioId"]);
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
        public float confidence { get; set;}

        [ColumnMapping()]
        public int VedioId { get; set; }

        public CapturePicture CapturePicture { get; set; }
        public VideoInfo VideoInfo { get; set; }
        public CameraInfo CameraInfo { get; set; }

    }
}
