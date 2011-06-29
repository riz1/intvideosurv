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
    public class LongChang_VehMonInfo : EntityObject
    {

        /*mvid	车辆监控ID	变长字符	50		是	是	GUID	新增
        clxxbh	车辆信息编号	变长字符	15					全部
        kkbh	卡口编号	变长字符	12					全部
        kkmc	卡口名称	变长字符	100					全部
        hphm	号牌号码	变长字符	15					全部
        hpysbh	号牌颜色编号	变长字符	1					全部
        hpys	号牌颜色	变长字符	50					全部
        txsl	图像数量	小整数	1					全部
        txmc1	图像名称1	变长字符	100					全部
        txmc2	图像名称2	变长字符	100					全部
        txmc3	图像名称3	变长字符	100					全部
        txmc4	图像名称4	变长字符	100					全部
        spmc	视频名称	变长字符	100					全部
        csys	车身颜色	变长字符	5					全部
        cllx	车辆类型	变长字符	4					全部
        cllxmc	车辆类型名称	变长字符	100					全部
        hpzl	号牌种类	变长字符	2					全部
        hpzlmc	号牌种类名称	变长字符	100					全部
        tjrq	统计日期	小数	8					全部
        wzyy	违章原因	变长字符	5					全部
        hdsj	红灯时间	时间戳	14					全部*/

        #region construction
        public LongChang_VehMonInfo() { }
        public LongChang_VehMonInfo(IDataReader dataReader) : base(dataReader) { }
        public LongChang_VehMonInfo(DataRow dataRow)
        {
            vehMonId = dataRow["mvid"] is DBNull ? "" : Convert.ToString(dataRow["mvid"]);
            vehInfoNum = dataRow["clxxbh"] is DBNull ? -1 : Convert.ToInt32(dataRow["clxxbh"]);
            tollNum = dataRow["kkbh"] is DBNull ? -1 : Convert.ToInt32(dataRow["kkbh"]);
            tollName = dataRow["kkmc"] is DBNull ? "" : Convert.ToString(dataRow["kkmc"]);
            plateNumber = dataRow["hphm"] is DBNull ? "" : Convert.ToString(dataRow["hphm"]);
            plateColorNum = dataRow["hpysbh"] is DBNull ? -1 : Convert.ToInt32(dataRow["hpysbh"]);
            plateColor = dataRow["hpys"] is DBNull ? "" : Convert.ToString(dataRow["hpys"]);
            imageCount = dataRow["txsl"] is DBNull ? -1 : Convert.ToInt32(dataRow["txsl"]);
            imageName1 = dataRow["txmc1"] is DBNull ? "" : Convert.ToString(dataRow["txmc1"]);
            imageName2 = dataRow["txmc2"] is DBNull ? "" : Convert.ToString(dataRow["txmc2"]);
            imageName3 = dataRow["txmc3"] is DBNull ? "" : Convert.ToString(dataRow["txmc3"]);
            imageName4 = dataRow["txmc4"] is DBNull ? "" : Convert.ToString(dataRow["txmc4"]);
            vedioName = dataRow["spmc"] is DBNull ? "" : Convert.ToString(dataRow["spmc"]);
            vehicleColor = dataRow["csys"] is DBNull ? "" : Convert.ToString(dataRow["csys"]);
            vehicleType = dataRow["cllx"] is DBNull ? -1 : Convert.ToInt32(dataRow["cllx"]);
            vehicleTypeName = dataRow["cllxmc"] is DBNull ? "" : Convert.ToString(dataRow["cllxmc"]);
            plateNumberType = dataRow["hpzl"] is DBNull ? "" : Convert.ToString(dataRow["hpzl"]);
            plateNumberTypeName = dataRow["hpzlmc"] is DBNull ? "" : Convert.ToString(dataRow["hpzlmc"]);
            countTime = dataRow["tjrq"] is DBNull ? -1 : Convert.ToInt32(dataRow["tjrq"]);
            illegalReason = dataRow["wzyy"] is DBNull ? "" : Convert.ToString(dataRow["wzyy"]);
            redLightTime = Convert.ToDateTime(dataRow["hdsj"]);//dataRow["hdsj"] is DBNull ? '2006/01/22' : ;

            roadNumber = dataRow["cdbh"] is DBNull ? -1 : Convert.ToInt32(dataRow["cdbh"]);
            roadName = dataRow["cdmc"] is DBNull ? "" : Convert.ToString(dataRow["cdmc"]);
            adminDivisionNumber = dataRow["dwbh"] is DBNull ? -1 : Convert.ToInt32(dataRow["dwbh"]);
            adminDivisionName = dataRow["dwmc"] is DBNull ? "" : Convert.ToString(dataRow["dwmc"]);
            vedioName1 = dataRow["spmc1"] is DBNull ? "" : Convert.ToString(dataRow["spmc1"]);
            vedioName2 = dataRow["spmc2"] is DBNull ? "" : Convert.ToString(dataRow["spmc2"]);

        }
        #endregion

        [ColumnMapping()]
        public string vehMonId { get; set; }
        [ColumnMapping()]
        public int vehInfoNum { get; set; }
        [ColumnMapping()]
        public int tollNum { get; set; }
        [ColumnMapping()]
        public string tollName { get; set; }
        [ColumnMapping()]
        public string plateNumber { get; set; }
        [ColumnMapping()]
        public int plateColorNum { get; set; }
        [ColumnMapping()]
        public string plateColor { get; set; }
        [ColumnMapping()]
        public int imageCount { get; set; }
        [ColumnMapping()]
        public string imageName1 { get; set; }
        [ColumnMapping()]
        public string imageName2 { get; set; }
        [ColumnMapping()]
        public string imageName3 { get; set; }
        [ColumnMapping()]
        public string imageName4 { get; set; }
        [ColumnMapping()]
        public string vedioName { get; set; }
        [ColumnMapping()]
        public string vehicleColor { get; set; }
        [ColumnMapping()]
        public int vehicleType { get; set; }
        [ColumnMapping()]
        public string vehicleTypeName { get; set; }
        [ColumnMapping()]
        public string plateNumberType { get; set; }
        [ColumnMapping()]
        public string plateNumberTypeName { get; set; }
        [ColumnMapping()]
        public int countTime { get; set; }
        [ColumnMapping()]
        public string illegalReason { get; set; }
        [ColumnMapping()]
        public DateTime redLightTime { get; set; }

        [ColumnMapping()]
        public int roadNumber { get; set; }
        [ColumnMapping()]
        public string roadName { get; set; }
        [ColumnMapping()]
        public int adminDivisionNumber { get; set; }
        [ColumnMapping()]
        public string adminDivisionName  { get; set; }
        [ColumnMapping()]
        public string vedioName1 { get; set; }
        [ColumnMapping()]
        public string vedioName2 { get; set; }
        
    }
}

