using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IntVideoSurv.DataAccess;

namespace IntVideoSurv.Business
{
    
    public static class DbParasBusiness
    {
        public static void SetDataBase(MyDBType dbType)
        {
            DataBaseParas.DBType = dbType;
        }
    }
}
