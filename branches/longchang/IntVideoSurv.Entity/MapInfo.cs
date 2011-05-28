using System;
using Com.SS.Framework.Entity;
using System.Data;

namespace IntVideoSurv.Entity
{
    [Serializable]
    public class MapInfo : EntityObject
    {
        #region construction

        public MapInfo() { }
        public MapInfo(IDataReader dataReader) : base(dataReader) { }
        public MapInfo(DataRow dataRow)
        {
            Id = Convert.ToInt32(dataRow["Id"]);
            Name = Convert.ToString(dataRow["Name"]);
            Width = Convert.ToInt32(dataRow["Width"]);
            Height = Convert.ToInt32(dataRow["Height"]);
            FileName = Convert.ToString(dataRow["FileName"]);

        }
        #endregion

        [ColumnMapping()]
        public int Id { get; set; }
        [ColumnMapping()]
        public string Name { get; set; }
        [ColumnMapping()]
        public int Width { get; set; }

        [ColumnMapping()]
        public int Height { get; set; }

        [ColumnMapping()]
        public string FileName { get; set; }

        public override string ToString()
        {
            return String.Format("ID:{0}  名称:{1}  宽度:{2}  高度:{3}  文件名:{4}", Id, Name, Width, Height, FileName);

        }
    }
}
