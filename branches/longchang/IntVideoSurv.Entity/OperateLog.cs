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
        {
            Id = Convert.ToInt32(dataRow["Id"]);
            GroupId = Convert.ToInt32(dataRow["GroupId"]);
            DeviceId = Convert.ToInt32(dataRow["DeviceId"]);
            CameraId = Convert.ToInt32(dataRow["CameraId"]);
            HappenTime = Convert.ToDateTime(dataRow["HappenTime"]);
            OperateTypeId = Convert.ToInt32(dataRow["OperateTypeId"]);
            OperateTypeName = Convert.ToString(dataRow["OperateTypeName"]);
            ClientUserId = Convert.ToInt32(dataRow["ClientUserId"]);
            ClientUserName = Convert.ToString(dataRow["ClientUserName"]);
            Content = Convert.ToString(dataRow["Content"]);
            OperateUserName = Convert.ToString(dataRow["OperateUserName"]);
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

