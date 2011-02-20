using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Com.SS.Framework.Entity;
using System.Data;
namespace DigtiMatrix.Entity
{
    [Serializable]
    public class ChangeSynGroup : EntityObject
    {
        private int _id = 0;
        private string _name;
        private string _description = "";

        #region construction
        public ChangeSynGroup() { }
        public ChangeSynGroup(IDataReader dataReader) : base(dataReader) { }
        public ChangeSynGroup(DataRow dataRow) : base(dataRow) { }
        #endregion
        [ColumnMapping()]
        public int ChangeSynGroupId
        {
            get { return _id; }
            set { _id = value; }
        }
        [ColumnMapping()]
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        [ColumnMapping()]
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public Dictionary<int, CameraInfo> ListCamera
        {
            get;
            set;
        }
    }

}
