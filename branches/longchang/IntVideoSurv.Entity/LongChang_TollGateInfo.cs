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
    public class LongChang_TollGateInfo : EntityObject
    {

        //tgid	卡口ID	变长字符	50		是	是	GUID	新增
        //kkfbh	卡口编号(父)	变长字符	12					全部
        //kkbh	卡口编号	变长字符	12					全部
        //kkmc	卡口名称	变长字符	40					全部
        //kkjc	卡口简称	变长字符	40					全部
        //kkwz	卡口位置	变长字符	40					全部
        //dwbh	管辖单位编号	变长字符	4					全部
        //xzqh	行政区划	变长字符	10					全部
        //kklx	卡口类型	变长字符	2					全部
        //xdsd	限定速度	小整数						全部
        //cds	车道数	小整数						全部
        //sxjs	摄像机数	小整数						全部
        //sxjbh	摄像机编号	变长字符	50					全部
        //fx	方向	变长字符	50					全部
        //dlbh	道路编号	变长字符	10					全部
        //dlmc	道路名称	变长字符	50					全部
        //dtbh	地图编号	变长字符	10					全部
        //dtxzb	地图X坐标	单精度						全部
        //dtyzb	地图Y坐标	单精度						全部
        //dtjd	地图精度	变长字符						全部
        //dtwd	地图纬度	单精度						全部




        

        #region construction
        public LongChang_TollGateInfo() { }
        public LongChang_TollGateInfo(IDataReader dataReader) : base(dataReader) { }
        public LongChang_TollGateInfo(DataRow dataRow)
        {
            tollGateID = dataRow["tgid"] is DBNull ? "" : Convert.ToString(dataRow["tgid"]);
            tollParentNum = dataRow["kkfbh"] is DBNull ? -1 : Convert.ToInt32(dataRow["kkfbh"]);
            tollNum = dataRow["kkbh"] is DBNull ? -1 : Convert.ToInt32(dataRow["kkbh"]);
            tollName = dataRow["kkmc"] is DBNull ? "" : Convert.ToString(dataRow["kkmc"]);
            tollShort = dataRow["kkjc"] is DBNull ? "" : Convert.ToString(dataRow["kkjc"]);
            tollPosition = dataRow["kkwz"] is DBNull ? "" : Convert.ToString(dataRow["kkwz"]);
            departmentNum = dataRow["dwbh"] is DBNull ? -1 : Convert.ToInt32(dataRow["dwbh"]);
            administrationDivsion = dataRow["xzqh"] is DBNull ? "" : Convert.ToString(dataRow["xzqh"]);
            tollType = dataRow["kklx"] is DBNull ? -1 : Convert.ToInt32(dataRow["kklx"]);
            cameraNum = dataRow["sxjbh"] is DBNull ? -1 : Convert.ToInt32(dataRow["sxjbh"]);
            roadNum = dataRow["dlbh"] is DBNull ? -1 : Convert.ToInt32(dataRow["dlbh"]);
            roadName = dataRow["dlmc"] is DBNull ? "" : Convert.ToString(dataRow["dlmc"]);
            mapNum = dataRow["dtbh"] is DBNull ? -1 : Convert.ToInt32(dataRow["dtbh"]);
            mapX = dataRow["dtxzb"] is DBNull ? -1 : Convert.ToSingle(dataRow["dtxzb"]);
            mapY = dataRow["dtyzb"] is DBNull ? -1 : Convert.ToSingle(dataRow["dtyzb"]);
            precision = dataRow["dtjb"] is DBNull ? -1 : Convert.ToInt32(dataRow["dtjd"]);
            mapLatitude = dataRow["dtwd"] is DBNull ? -1 : Convert.ToSingle(dataRow["dtwd"]);
            
        }
        #endregion

        [ColumnMapping()]
        public string tollGateID { get; set; }
        [ColumnMapping()]
        public int tollParentNum { get; set; }
        [ColumnMapping()]
        public int tollNum { get; set; }
        [ColumnMapping()]
        public string tollName { get; set; }
        [ColumnMapping()]
        public string tollShort { get; set; }
        [ColumnMapping()]
        public string tollPosition { get; set; }
        [ColumnMapping()]
        public int departmentNum { get; set; }
        [ColumnMapping()]
        public string administrationDivsion { get; set; }
        [ColumnMapping()]
        public int tollType { get; set; }
        [ColumnMapping()]
        public int cameraNum { get; set; }
        [ColumnMapping()]
        public int roadNum { get; set; }
        [ColumnMapping()]
        public string roadName { get; set; }
        [ColumnMapping()]
        public int mapNum { get; set; }
        [ColumnMapping()]
        public float mapX { get; set; }
        [ColumnMapping()]
        public float mapY { get; set; }
        [ColumnMapping()]
        public int precision { get; set; }
        [ColumnMapping()]
        public float mapLatitude { get; set; }
        
    }
}

