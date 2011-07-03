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
            string cmdText = string.Format("select * from TOG_TOLLGATE where tgid = {0} order by tgid",tollid);
            try
            {
                return db.ExecuteDataSet(CommandType.Text, cmdText);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public static DataSet GetTollGateInfoByCameraId(Database db, int id)
        {
            string cmdText = string.Format("select * from TOG_TOLLGATE where sxjbh = {0}", id);
            try
            {
                return db.ExecuteDataSet(CommandType.Text, cmdText);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public static int Delete(Database db, string TollId)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("delete from TOG_TOLLGATE");
            sb.AppendFormat(" where KKBH='{0}'", TollId);
            string cmdText = sb.ToString();
            try
            {
                return db.ExecuteNonQuery(CommandType.Text, cmdText);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public static DataSet GetTollGateInfoByKKBh(Database db, string tollid)
        {
            string cmdText = string.Format("select * from TOG_TOLLGATE where kkbh = '{0}' order by tgid", tollid);
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
