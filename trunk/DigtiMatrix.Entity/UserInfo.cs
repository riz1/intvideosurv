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
    public class UserInfo : EntityObject
    {

        #region construction
        public UserInfo() { }
        public UserInfo(IDataReader dataReader) : base(dataReader) { }
        public UserInfo(DataRow dataRow)
            : base(dataRow)
        {

        }
        #endregion

        [ColumnMapping()]
        public int UserId { get; set; }
        [ColumnMapping()]
        public string UserName { get; set; }
        [ColumnMapping()]
        public string Password { get; set; }

        [ColumnMapping()]
        public DateTime CreateDateTime { get; set; }
        [ColumnMapping()]
        public int UserTypeId { get; set; }
        [ColumnMapping()]
        public string UserTypeName { get; set; }

        public override String ToString()
        {
            return String.Format("ID:{0} \t用户名:{1} \t创建时间:{2} \t用户类型:{3}", UserId, UserName, CreateDateTime, UserTypeName);
        }

    }
}

