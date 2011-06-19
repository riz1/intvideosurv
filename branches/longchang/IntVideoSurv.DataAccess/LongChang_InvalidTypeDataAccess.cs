using System;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;

namespace IntVideoSurv.DataAccess
{
    public class LongChang_InvalidTypeDataAccess
    {
        public static DataSet GetAllInvalidType(Database db)
        {
            string cmdText = string.Format("select * from btoc_wzyy order by WzyyBH");
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
