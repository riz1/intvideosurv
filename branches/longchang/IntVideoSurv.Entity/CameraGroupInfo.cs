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
    public class CameraGroupInfo : EntityObject
    {

        #region construction
        public CameraGroupInfo() { }
        public CameraGroupInfo(IDataReader dataReader) : base(dataReader) { }
        public CameraGroupInfo(DataRow dataRow)
        {
            ID = Convert.ToInt32(dataRow["ID"]);
            GroupID = Convert.ToInt32(dataRow["GroupID"]);
            CameraID = Convert.ToInt32(dataRow["CameraID"]);  
        }
        #endregion

        [ColumnMapping()]
        public int ID { get; set; }
        [ColumnMapping()]
        public int GroupID { get; set; }
        [ColumnMapping()]
        public int CameraID { get; set; }
       
    }
}
