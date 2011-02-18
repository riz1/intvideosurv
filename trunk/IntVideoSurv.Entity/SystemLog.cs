using System;
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
    public class SystemLog : EntityObject
    {





        #region construction
        public SystemLog() { }
        public SystemLog(IDataReader dataReader) : base(dataReader) { }
        public SystemLog(DataRow dataRow)
            : base(dataRow)
        {

        }
        #endregion

        [ColumnMapping()]
        public int Id { get; set; }
        [ColumnMapping()]
        public DateTime HappenTime { get; set; }
        [ColumnMapping()]
        public int SystemTypeId { get; set; }
        [ColumnMapping()]
        public String SystemTypeName { get; set; }
        [ColumnMapping()]
        public string Content { get; set; }
        [ColumnMapping()]
        public string SyeUserName { get; set; }
        [ColumnMapping()]
        public int ClientUserId { get; set; }
        [ColumnMapping()]
        public string ClientUserName { get; set; }

    }
}

