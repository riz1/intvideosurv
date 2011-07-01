using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using IntVideoSurv.Entity;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace IntVideoSurv.DataAccess
{
    public class SystemParametersDataAccess
    {
        public static int UpdateParameter(Database db, SystemParameter systemParameter)
        {
            StringBuilder sb = new StringBuilder();
            if (IsExistRow(db, systemParameter.Name))
            {
                sb.Append("update IVS_systemParameter set");
                sb.AppendFormat(" Value='{0}',Type='{1}' where Name='{2}'", systemParameter.Name, systemParameter.Type,systemParameter.Value);                
            }
            else
            {
                sb.Append("insert into IVS_systemParameter(name,type,value) ");
                sb.AppendFormat("values('{0}','{1}','{2}')", systemParameter.Name, systemParameter.Type, systemParameter.Value);   
            }

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
        private static bool IsExistRow(Database db,string name)
        {
            string cmdText = string.Format("select count(*) from IVS_systemParameter where Name='{0}';", name);
            try
            {
                return int.Parse(db.ExecuteScalar(CommandType.Text, cmdText).ToString())>0;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public static DataSet GetSystemParameters(Database db)
        {
            string cmdText = string.Format("select * from IVS_systemParameter;");
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
