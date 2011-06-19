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
    public class LongChang_VehColorInfo : EntityObject
    {

        //clysdm	车辆颜色代码	定长字符	2		是	是		全部
        //clys	    车辆颜色	    变长字符	50					全部



        

        #region construction
        public LongChang_VehColorInfo() { }
        public LongChang_VehColorInfo(IDataReader dataReader) : base(dataReader) { }
        public LongChang_VehColorInfo(DataRow dataRow)
        {
            VehicleColorNum = dataRow["clysdm"] is DBNull ? -1 : Convert.ToInt32(dataRow["clysdm"]);
            VehicleColor = dataRow["clys"] is DBNull ? "" : Convert.ToString(dataRow["clys"]);

        }
        #endregion

        [ColumnMapping()]
        public int VehicleColorNum { get; set; }
        [ColumnMapping()]
        public string VehicleColor { get; set; }
        
    }
}

