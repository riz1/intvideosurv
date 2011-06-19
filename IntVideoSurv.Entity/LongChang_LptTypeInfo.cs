using System;
using System.Collections;
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
    public class LongChang_LptTypeInfo : EntityObject
    {

        //hpzldm	号牌种类代码	定长字符	2		是	是		全部
        //hpmc	    号牌名称	   变长字符	    50					全部


        

        #region construction
        public LongChang_LptTypeInfo() { }
        public LongChang_LptTypeInfo(IDataReader dataReader) : base(dataReader) { }
        public LongChang_LptTypeInfo(DataRow dataRow)
        {
            PlateNumberType = dataRow["hpzldm"] is DBNull ? -1 : Convert.ToInt32(dataRow["hpzldm"]);
            PlateNumberName = dataRow["hpmc"] is DBNull ? "" : Convert.ToString(dataRow["hpmc"]);

        }
        #endregion

        [ColumnMapping()]
        public int PlateNumberType { get; set; }
        [ColumnMapping()]
        public string PlateNumberName { get; set; }
        
    }
}

