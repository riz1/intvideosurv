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
    public class OperateLog : EntityObject
    {
        #region construction
        public OperateLog() { }
        public OperateLog(IDataReader dataReader) : base(dataReader) { }
        public OperateLog(DataRow dataRow)
            : base(dataRow)
        {

        }
        #endregion

        [ColumnMapping()]
        public int Id { get; set; }
        [ColumnMapping()]
        public int GroupId { get; set; }
        [ColumnMapping()]
        public int DeviceId { get; set; }
        [ColumnMapping()]
        public int CameraId { get; set; }
        [ColumnMapping()]
        public DateTime HappenTime { get; set; }
        [ColumnMapping()]
        public int OperateTypeId { get; set; }
        [ColumnMapping()]
        public String OperateTypeName { get; set; }
        [ColumnMapping()]
        public string Content { get; set; }
        [ColumnMapping()]
        public string OperateUserName { get; set; }
        [ColumnMapping()]
        public int ClientUserId { get; set; }
        [ColumnMapping()]
        public string ClientUserName { get; set; }

    }
}

