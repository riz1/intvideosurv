using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IntVideoSurv.DataAccess
{
    public static class DataBaseParas
    {
        public static MyDBType DBType = MyDBType.SqlServer;
    }
    public enum MyDBType
    {
        Access=1,
        Mysql=2,
        SqlServer=4,
        Oracle=8
    }
}
