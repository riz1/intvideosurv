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
            : base(dataRow)
        {
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
