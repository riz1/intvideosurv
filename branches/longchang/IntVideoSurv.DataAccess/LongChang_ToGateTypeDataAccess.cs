using System;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;

namespace IntVideoSurv.DataAccess
{
    public class LongChang_ToGateTypeDataAccess
    {
        public static DataSet GetAllVehColorInfo(Database db)
        {
            string cmdText = string.Format("select * from TOC_TOGATETYPE order by KKLXDM");
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

