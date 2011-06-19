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
    public class LongChang_VehTypeInfo : EntityObject
    {

        //clysdm	车辆颜色代码	定长字符	2		是	是		全部
        //clys	    车辆颜色	    变长字符	50					全部



        

        #region construction
        public LongChang_VehTypeInfo() { }
        public LongChang_VehTypeInfo(IDataReader dataReader) : base(dataReader) { }
        public LongChang_VehTypeInfo(DataRow dataRow)
        {
            VehicleTypeNum = dataRow["cllxdm"] is DBNull ? -1 : Convert.ToInt32(dataRow["cllxdm"]);
            VehicleType = dataRow["cllx"] is DBNull ? "" : Convert.ToString(dataRow["cllx"]);

        }
        #endregion

        [ColumnMapping()]
        public int VehicleTypeNum { get; set; }
        [ColumnMapping()]
        public string VehicleType { get; set; }
        
    }
}

