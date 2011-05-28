using System;
using System.Data;
using Com.SS.Framework.Entity;

namespace IntVideoSurv.Entity
{
    [Serializable]
    public class SystemParameter : EntityObject
    {
       #region construction

        public SystemParameter() { }
        public SystemParameter(IDataReader dataReader) : base(dataReader) { }
        public SystemParameter(DataRow dataRow)
        {
            Name = Convert.ToString(dataRow["Name"]);
            Type = Convert.ToString(dataRow["Type"]);
            Value = Convert.ToString(dataRow["Value"]);
        }
        #endregion

        [ColumnMapping()] 
        public string Name;
        [ColumnMapping()]
        public string Type;
        [ColumnMapping()]
        public string Value;

    }
}
