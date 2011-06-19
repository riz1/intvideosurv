using System;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;

namespace IntVideoSurv.DataAccess
{
    public class LongChang_CaptureDepartmentDataAccess
    {
        public static DataSet GetAllCaptureDepartment(Database db)
        {
            string cmdText = string.Format("select * from AORG order by ORGID");
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
