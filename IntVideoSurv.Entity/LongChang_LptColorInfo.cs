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
    public class LongChang_LptColorInfo : EntityObject
    {

        //hpysdm	号牌颜色代码	定长字符	1		是	是		全部
        //hpys	号牌颜色	变长字符	50					全部

        

        #region construction
        public LongChang_LptColorInfo() { }
        public LongChang_LptColorInfo(IDataReader dataReader) : base(dataReader) { }
        public LongChang_LptColorInfo(DataRow dataRow)
        {
            VehiclePlateNumber = dataRow["hpysdm"] is DBNull ? -1 : Convert.ToInt32(dataRow["hpysdm"]);
            VehiclePlateNumberColor = dataRow["hpys"] is DBNull ? "" : Convert.ToString(dataRow["hpys"]);

        }
        #endregion

        [ColumnMapping()]
        public int VehiclePlateNumber { get; set; }
        [ColumnMapping()]
        public string VehiclePlateNumberColor { get; set; }
        
    }
}

