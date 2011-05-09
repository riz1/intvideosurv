using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using IntVideoSurv.Entity;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace IntVideoSurv.DataAccess
{
    public class CommonDataAccess
    {
        public static DataSet ExecuteGeneralSplitPageProcedure(Database db, string fields,string tables,string condition, string ordercolumn,byte ordertype,string pkcolumn,int pageno,int pagesize)
        {
            string cmdText = string.Format("exec GeneralSplitPageProcedure {0},'{1}','{2}','{3}','{4}',{5},'{6}',{7}", pageno, fields, tables, condition, ordercolumn, ordertype, pkcolumn, pagesize);
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
