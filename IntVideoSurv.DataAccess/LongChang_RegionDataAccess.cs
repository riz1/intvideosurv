using System;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;

namespace IntVideoSurv.DataAccess
{
    public class LongChang_RegionDataAccess
    {
        public static DataSet GetAllRegionInfo(Database db)
        {
            string cmdText = string.Format("select * from TOC_REGION order by XZQHDM");
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