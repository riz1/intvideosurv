using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using IntVideoSurv.Entity;

namespace IntVideoSurv.DataAccess
{
    public class OperateLogDataAccess
    {
        public static int GetMaxSystemLogId(Database db)
        {
            string cmdText = "select max(Id) from OperateLog";
            try
            {
                return int.Parse(db.ExecuteScalar(CommandType.Text, cmdText).ToString());

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public static int Insert(Database db, OperateLog operateLog)
        {

            StringBuilder sbField = new StringBuilder();
            StringBuilder sbValue = new StringBuilder();
            sbField.Append("INSERT INTO  OperateLog(");
            sbValue.Append("values(");
            sbField.Append("GroupID");
            sbValue.AppendFormat("{0}", operateLog.GroupId);
            sbField.Append(",DeviceID");
            sbValue.AppendFormat(",{0}", operateLog.DeviceId);
            sbField.Append(",CameraId");
            sbValue.AppendFormat(",{0}", operateLog.CameraId);
            sbField.Append(",Happentime");
            sbValue.AppendFormat(",'{0}'", operateLog.HappenTime);
            sbField.Append(",operatetypeid");
            sbValue.AppendFormat(",{0}", operateLog.OperateTypeId);
            sbField.Append(",operatetypename");
            sbValue.AppendFormat(",'{0}'", operateLog.OperateTypeName);
            sbField.Append(",content");
            sbValue.AppendFormat(",'{0}'", operateLog.Content);
            sbField.Append(",operateusername");
            sbValue.AppendFormat(",'{0}'", operateLog.OperateUserName);
            sbField.Append(",clientusername");
            sbValue.AppendFormat(",'{0}'", operateLog.ClientUserName);
            sbField.Append(",clientuserid)");
            sbValue.AppendFormat(",{0})", operateLog.ClientUserId);

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
        public static int Delete(Database db, int operateLogId)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("delete from OperateLog ");
            sb.AppendFormat(" where Id={0}", operateLogId);
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

        public static DataSet GetAllOperateLogs(Database db)
        {
            string cmdText = string.Format("select * from OperateLog order by Id");
            try
            {
                return db.ExecuteDataSet(CommandType.Text, cmdText);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static DataSet GetOperateLogs(Database db, string filter)
        {
            string cmdText = string.Format("select  ID as 索引号,GroupInfo.name as 组名,deviceinfo.name as 设备名称, CameraInfo.Name as 摄像头名, "+
                "happentime as 发生时间,clientusername as 用户名, operatetypename as 操作类型, "+
                "content as 内容  from ((( OperateLog left join deviceinfo on OperateLog.DeviceID = deviceinfo.deviceid) " +
                "left join CameraInfo on CameraInfo.CameraId=OperateLog.CameraId) left join GroupInfo on GroupInfo.GroupId=OperateLog.GroupId) " +
                "{0} order by OperateLog.Id", filter);
            try
            {
                return db.ExecuteDataSet(CommandType.Text, cmdText);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static DataSet GetOperateLogTypes(Database db)
        {
            string cmdText = string.Format("select distinct operatetypename from OperateLog");
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


