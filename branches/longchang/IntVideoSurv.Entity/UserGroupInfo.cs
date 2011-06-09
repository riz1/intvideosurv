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
    public class UserGroupInfo : EntityObject
    {
        #region construction
        
        public UserGroupInfo() { }
        public UserGroupInfo(IDataReader dataReader) : base(dataReader) { }
        public UserGroupInfo(DataRow dataRow)
        {
            ID = Convert.ToInt32(dataRow["ID"]);
            VirtualGroupID = Convert.ToInt32(dataRow["VirtualGroupID"]);
            UserID = Convert.ToInt32(dataRow["UserID"]);
        }
        #endregion
        [ColumnMapping()]
        public int ID { get; set; }
        [ColumnMapping()]
        public int VirtualGroupID { get; set; }
        [ColumnMapping()]
        public int UserID { get; set; }
    }
}