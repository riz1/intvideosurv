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
    public class VirtualGroupInfo : EntityObject
    {

        #region construction
        public VirtualGroupInfo() { }
        public VirtualGroupInfo(IDataReader dataReader) : base(dataReader) { }
        public VirtualGroupInfo(DataRow dataRow)
        {
            ID = Convert.ToInt32(dataRow["ID"]);
            Name = Convert.ToString(dataRow["Name"]);    
        }
        #endregion

        [ColumnMapping()]
        public int ID { get; set; }
        [ColumnMapping()]
        public string Name { get; set; }
       
    }
}
