using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Com.SS.Framework.Entity;
using System.Data;
namespace IntVideoSurv.Entity
{
    [Serializable]
    public class ProgSwitchInfo : EntityObject
    {
        private int _id = 0;
        private string _name;
        private string _description = "";

        #region construction
        public ProgSwitchInfo() { }
        public ProgSwitchInfo(IDataReader dataReader) : base(dataReader) { }
        public ProgSwitchInfo(DataRow dataRow)
        {
            Id = Convert.ToInt32(dataRow["Id"]);
            Name = Convert.ToString(dataRow["Name"]);
            Description = Convert.ToString(dataRow["Description"]);
            DisplayChannelId = Convert.ToInt32(dataRow["DisplayChannelId"]);
            DisplaySplitScreenNo = Convert.ToInt32(dataRow["DisplaySplitScreenNo"]);
            DisplayChannelName = Convert.ToString(dataRow["DisplayChannelName"]);
        }
        #endregion
        [ColumnMapping()]
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        [ColumnMapping()]
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        [ColumnMapping()]
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        [ColumnMapping()]
        public int DisplayChannelId
        {
            set;
            get;
        }

        [ColumnMapping()]
        public int DisplaySplitScreenNo
        {
            set;
            get;
        }
        /// <summary>
        /// 只在查询时使用
        /// </summary>
        [ColumnMapping()]
        public String DisplayChannelName
        {
            set;
            get;
        }
        /// <summary>
        /// 只在查询时使用
        /// </summary>


        public Dictionary<int, ProgSwitchDetailInfo> ListProgSwitchDetailInfo
        {
            get;
            set;
        }
        public override string ToString()
        {
            return String.Format("ID:{0} 名称:{1} 描述:{2} 通道号:{3}", Id, Name, Description, DisplayChannelId);
        }
    }

}
