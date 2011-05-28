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
    public class AlarmIconInfo : EntityObject
    {
        #region construction

        public AlarmIconInfo() { }
        public AlarmIconInfo(IDataReader dataReader) : base(dataReader) { }
        public AlarmIconInfo(DataRow dataRow)
        {
            AlarmId = Convert.ToInt32(dataRow["AlarmId"]);
            ToolTip = Convert.ToString(dataRow["ToolTip"]);
            IconIndex = Convert.ToInt32(dataRow["IconIndex"]);
            X = Convert.ToSingle(dataRow["X"]);
            Y = Convert.ToSingle(dataRow["Y"]);
            MatchCameraId = Convert.ToInt32(dataRow["MatchCameraId"]);
            Map = Convert.ToInt16(dataRow["map"]);
        }
        #endregion

        [ColumnMapping()]
        public int AlarmId { get; set; }
        [ColumnMapping()]
        public string ToolTip { get; set; }
        [ColumnMapping()]
        public int IconIndex { get; set; }

        [ColumnMapping()]
        public double X { get; set; }

        [ColumnMapping()]
        public double Y { get; set; }

        [ColumnMapping()]
        public int MatchCameraId { get; set; }

        [ColumnMapping()]
        public int Map { get; set; }

        public string AlarmName { get; set; }



        public override string ToString()
        {
            return String.Format("报警ID:{0}  名称:{1}  ToolTip:{2}  IconIndex:{3}  X:{4}  Y:{5}  匹配上的摄像头ID:{6}", AlarmId, AlarmName, ToolTip, IconIndex, X, Y, MatchCameraId);

        }
    }
}
