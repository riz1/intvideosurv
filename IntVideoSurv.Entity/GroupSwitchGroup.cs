using System;
using System.Collections.Generic;
using Com.SS.Framework.Entity;
using System.Data;
namespace IntVideoSurv.Entity
{
    [Serializable]
    public class GroupSwitchGroup : EntityObject
    {
        private int _id;
        private string _name;
        private string _description = "";

        #region construction
        public GroupSwitchGroup() { }
        public GroupSwitchGroup(IDataReader dataReader) : base(dataReader) { }
        public GroupSwitchGroup(DataRow dataRow) : base(dataRow) { }
        #endregion
        [ColumnMapping]
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        [ColumnMapping]
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        [ColumnMapping]
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public Dictionary<int, GroupSwitchDetailInfo> ListGroupSwitchDetailInfo
        {
            get;
            set;
        }
        public override string ToString()
        {
            return String.Format("ID:{0} 名称:{1} 描述:{2}", Id, Name, Description);
        }
    }

}
