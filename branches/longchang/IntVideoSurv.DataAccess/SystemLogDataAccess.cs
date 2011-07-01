﻿using System;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using IntVideoSurv.Entity;

namespace IntVideoSurv.DataAccess
{
    public class SystemLogDataAccess
    {
        public static int GetMaxSystemLogId(Database db)
        {
            string cmdText = "select max(Id) from IVS_SystemLog";
            try
            {
                return int.Parse(db.ExecuteScalar(CommandType.Text, cmdText).ToString());

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public static int Insert(Database db, SystemLog systemLog)
        {

            StringBuilder sbField = new StringBuilder();
            StringBuilder sbValue = new StringBuilder();
            sbField.Append("INSERT INTO  IVS_SystemLog(");
            sbValue.Append("values(");
            sbField.Append("Happentime");
            sbValue.AppendFormat("'{0}'", systemLog.HappenTime);
            if (DataBaseParas.DBType == MyDBType.SqlServer)
            {
                sbValue.AppendFormat("'{0}'", systemLog.HappenTime);
            }
            else if (DataBaseParas.DBType == MyDBType.Oracle)
            {
                sbValue.AppendFormat(",to_date('{0}','YYYY/MM/DD HH24:MI:SS')", systemLog.HappenTime);
            }
            sbField.Append(",systemtypeid");
            sbValue.AppendFormat(",{0}", systemLog.SystemTypeId);
            sbField.Append(",systemtypename");
            sbValue.AppendFormat(",'{0}'", systemLog.SystemTypeName); 
            sbField.Append(",content");
            sbValue.AppendFormat(",'{0}'", systemLog.Content);
            sbField.Append(",sysusername");
            sbValue.AppendFormat(",'{0}'", systemLog.SyeUserName);
            sbField.Append(",clientusername");
            sbValue.AppendFormat(",'{0}'", systemLog.ClientUserName);
            sbField.Append(",clientuserid)");
            sbValue.AppendFormat(",{0})", systemLog.ClientUserId);

            string cmdText = sbField.ToString() + " " + sbValue.ToString();

            try
            {
                cmdText = cmdText.Replace("\r\n", "");
                return db.ExecuteNonQuery(CommandType.Text, cmdText);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public static int Delete(Database db, int systemLogId)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("delete from IVS_SystemLog ");
            sb.AppendFormat(" where Id={0}", systemLogId);
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

        public static DataSet GetAllSystemLogs(Database db)
        {
            string cmdText = string.Format("select * from IVS_SystemLog order by Id");
            try
            {
                return db.ExecuteDataSet(CommandType.Text, cmdText);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static DataSet GetSystemLogs(Database db, string filter)
        {
            string cmdText = string.Format("select ID as 索引号, happentime as 发生时间,clientusername as 用户名, systemtypename as 操作类型, content as 内容 from IVS_SystemLog {0} order by Id", filter);
            try
            {
                return db.ExecuteDataSet(CommandType.Text, cmdText);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static DataSet GetSystemLogTypes(Database db)
        {
            string cmdText = string.Format("select distinct systemtypename from IVS_SystemLog");
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


