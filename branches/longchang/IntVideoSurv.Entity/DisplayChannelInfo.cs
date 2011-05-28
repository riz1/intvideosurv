using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Com.SS.Framework.Entity;
using System.Data;
namespace IntVideoSurv.Entity
{
    [Serializable]
    public class DisplayChannelInfo : EntityObject
    {
        private int _displayChannelId = 0;
        private string _displayChannelName;

        #region construction
        public DisplayChannelInfo() { }
        public DisplayChannelInfo(IDataReader dataReader) : base(dataReader) { }
        public DisplayChannelInfo(DataRow dataRow)
        {
            DisplayChannelId = Convert.ToInt32(dataRow["DisplayChannelId"]);
            DisplayChannelName = Convert.ToString(dataRow["DisplayChannelName"]);
            DispalyChannelNoInCurrentCard = Convert.ToInt32(dataRow["DispalyChannelNoInCurrentCard"]);
            DecodeCardNo = Convert.ToInt32(dataRow["DecodeCardNo"]);
            SplitScreenNo = Convert.ToInt32(dataRow["SplitScreenNo"]);
        }
        #endregion
        [ColumnMapping()]
        public int DisplayChannelId
        {
            get { return _displayChannelId; }
            set { _displayChannelId = value; }
        }
        [ColumnMapping()]
        public string DisplayChannelName
        {
            get { return _displayChannelName; }
            set { _displayChannelName = value; }
        }
        [ColumnMapping()]
        public int DispalyChannelNoInCurrentCard
        {
            get;set;
            
        }
        [ColumnMapping()]
        public int DecodeCardNo
        {
            get;
            set;

        }

        [ColumnMapping()]
        public int SplitScreenNo
        {
            get;
            set;

        }

        public override string ToString()
        {
            return String.Format("ID:{0} 名称:{1} 解码卡号{2}  通道号:{3}  分屏数:{4}", DisplayChannelId, DisplayChannelName, DecodeCardNo, DispalyChannelNoInCurrentCard, SplitScreenNo);
        }
        
    }

}

