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
    public class CameraIconInfo : EntityObject
    {
        #region construction

        public CameraIconInfo() { }
        public CameraIconInfo(IDataReader dataReader) : base(dataReader) { }
        public CameraIconInfo(DataRow dataRow)
        {
            CameraId = Convert.ToInt32(dataRow["CameraId"]);
            IconIndex = Convert.ToInt32(dataRow["IconIndex"]);
            ToolTip = Convert.ToString(dataRow["ToolTip"]);
            X = Convert.ToDouble(dataRow["X"]);
            Y = Convert.ToDouble(dataRow["Y"]);
            MatchAlarmId = Convert.ToInt32(dataRow["MatchAlarmId"]);
            Map = Convert.ToInt16(dataRow["map"]);
        }
        #endregion

        [ColumnMapping()]
        public int CameraId { get; set; }
        [ColumnMapping()]
        public string ToolTip { get; set; }
        [ColumnMapping()]
        public int IconIndex { get; set; }

        [ColumnMapping()]
        public double X { get; set; }

        [ColumnMapping()]
        public double Y { get; set; }

        [ColumnMapping()]
        public int MatchAlarmId { get; set; }

        [ColumnMapping()]
        public int Map { get; set; }

        public string CameraName { get; set; }

        public override string ToString()
        {
            return String.Format("报警ID:{0}  名称:{1}  ToolTip:{2}  IconIndex:{3}  X:{4}  Y:{5}  匹配上的摄像头ID:{6}", CameraId, CameraName, ToolTip, IconIndex, X, Y, MatchAlarmId);

        }
    }
}
