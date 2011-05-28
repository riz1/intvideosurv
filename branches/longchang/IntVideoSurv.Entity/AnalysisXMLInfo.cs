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
            : base(dataRow)
        {
            //Name = dataRow["CameraInfo.Name"].ToString();
            //DeviceName = dataRow["DeviceInfo.Name"].ToString();
        }
#endregion
        
        [ColumnMapping()]
        public int PictureID { get; set; }
        [ColumnMapping()]
        public int CameraID{get;set;}
        [ColumnMapping()]
        public DateTime Datetime {get;set;}
        [ColumnMapping()]
        public string FilePath {get;set;}


    }
    [Serializable]
    public class Vehicle:EntityObject
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
    }
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
        public float score { get; set; }
        [ColumnMapping()]
        public int RectID { get; set; }
        [ColumnMapping()]
        public int PictureID { get; set; }

        [ColumnMapping()]
        public string FacePath { get; set; }
        [ColumnMapping()]
        public int VideoId;

        public CapturePicture CapturePicture { get; set; }
        public VideoInfo VideoInfo { get; set; }
        public CameraInfo CameraInfo { get; set; }

    }
    [Serializable]
    public class REct : EntityObject
    {
         #region construction
        public REct() { }
        public REct(IDataReader dataReader) : base(dataReader) { }
        public REct(DataRow dataRow)
            : base(dataRow)
        {
        }
#endregion
        [ColumnMapping()]
        public int RectID {get;set;}
        [ColumnMapping()]
        public int X { get; set; }
        [ColumnMapping()]
        public int Y { get; set; }
        [ColumnMapping()]
        public int W { get; set; }
        [ColumnMapping()]
        public int H { get;set; }

    }
    [Serializable]
    public class Track : EntityObject
    {
         #region construction
        public Track() { }
        public Track(IDataReader dataReader) : base(dataReader) { }
        public Track(DataRow dataRow)
            : base(dataRow)
        {
        }
#endregion
        [ColumnMapping()]
        public int Id {get;set;}
        [ColumnMapping()]
        public int REct { get; set; }

    }
}