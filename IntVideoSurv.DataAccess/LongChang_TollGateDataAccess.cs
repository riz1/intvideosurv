using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using IntVideoSurv.Entity;

namespace IntVideoSurv.DataAccess
{
    public class LongChang_TollGateDataAccess
    {
        public static DataSet GetAllTollGateInfo(Database db)
        {
            string cmdText = string.Format("select * from TOG_TOLLGATE order by tgid");
            try
            {
                return db.ExecuteDataSet(CommandType.Text, cmdText);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public static DataSet GetTollGateInfoById(Database db, int tollid)
        {
            string cmdText = string.Format("select * from TOG_TOLLGATE where tollId = {0} order by tgid",tollid);
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
