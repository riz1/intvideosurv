using System;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using System.Text;

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
        public static DataSet GetInvalidTypeByWzyy(Database db, string wzyy)
        {
            string cmdText = string.Format("select * from BTOC_WZYY where wzyy='{0}'", wzyy);
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
