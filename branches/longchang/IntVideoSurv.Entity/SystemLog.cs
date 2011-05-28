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
        {
            Id = Convert.ToInt32(dataRow["Id"]);
            HappenTime = Convert.ToDateTime(dataRow["HappenTime"]);
            SystemTypeId = Convert.ToInt32(dataRow["SystemTypeId"]);
            SystemTypeName = Convert.ToString(dataRow["SystemTypeName"]);
            Content = Convert.ToString(dataRow["Content"]);
            SyeUserName = Convert.ToString(dataRow["SyeUserName"]);
            ClientUserId = Convert.ToInt32(dataRow["ClientUserId"]);
            ClientUserName = Convert.ToString(dataRow["ClientUserName"]);

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

