using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Com.SS.Framework.Entity;

namespace IntVideoSurv.Entity
{
    /****
     * 
     * 这个类仅仅是用来测试Oracle中的timestamp的使用方法
     * 
     * 
     */
    [Serializable]
    public class TTestInfo
    {
         #region construction
        public TTestInfo() { }
        public TTestInfo(DataRow dataRow)
        {
            Id = Convert.ToInt32(dataRow["Id"]);
            ts = Convert.ToDateTime(dataRow["ts"]);       


        }
        #endregion

        [ColumnMapping()]
        public int Id { get; set; }
        [ColumnMapping()]
        public DateTime ts { get; set; }
    }
}
