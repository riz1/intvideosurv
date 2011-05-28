using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Com.SS.Framework.Entity;
using System.Data;
namespace IntVideoSurv.Entity
{
    [Serializable]
    public class GroupInfo : EntityObject
    {
        private int id = 0;
        private string name;
        private string description = "";
        
         #region construction
        public GroupInfo() { }
        public GroupInfo(IDataReader dataReader) : base(dataReader) { }
        public GroupInfo(DataRow dataRow)
        {
            GroupID =Convert.ToInt32(dataRow["GroupID"]);
            ParentId =  Convert.ToInt32(dataRow["ParentId"]);
            Name = Convert.ToString(dataRow["Name"]);
            Description = Convert.ToString(dataRow["Description"]);
            AddBy = Convert.ToString(dataRow["AddBy"]);
            AddTime = Convert.ToString(dataRow["AddTime"]);
            ModifyBy = Convert.ToString(dataRow["ModifyBy"]);
            ModifyTime =  Convert.ToString(dataRow["ModifyTime"]);
        }
        #endregion
        [ColumnMapping()]
        public int GroupID
        {
            get { return id; }
            set { id = value; }
        }
        [ColumnMapping()]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        [ColumnMapping()]
        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        [ColumnMapping()]
        public int ParentId
        {
            get;
            set;
        }
        public Dictionary<int,DeviceInfo> ListDevice
        {
            get;
            set;
        }
        // FullName property
        
        // Constructor
        public GroupInfo(string name)
        {
            this.name = name;
        }
        [ColumnMapping()]
        public string AddBy { set; get; }
        [ColumnMapping()]
        public string AddTime { set; get; }
        [ColumnMapping()]
        public string ModifyBy { set; get; }
        [ColumnMapping()]
        public string ModifyTime { set; get; }

        public override string ToString()
        {
            return String.Format("ID:{0}  名称:{1}  描述:{2}", GroupID, Name, Description);
        }
    }
    
}
