using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using IntVideoSurv.Entity;

namespace IntVideoSurv.DataAccess
{
    public class LongChang_LptTypeDataAccess
    {
        public static DataSet GetAllLptTypeInfo(Database db)
        {
            string cmdText = string.Format("select * from TOC_LPTTYPE order by hpzldm");
            try
            {
                return db.ExecuteDataSet(CommandType.Text, cmdText);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        
    }
}
