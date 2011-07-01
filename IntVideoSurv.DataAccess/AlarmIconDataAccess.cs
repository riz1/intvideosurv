using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using IntVideoSurv.Entity;

namespace IntVideoSurv.DataAccess
{
    public class AlarmIconDataAccess
    {
 
        public static int Insert(Database db, AlarmIconInfo alarmIconInfo)
        {
            StringBuilder sbField = new StringBuilder();
            StringBuilder sbValue = new StringBuilder();
            sbField.Append("INSERT INTO IVS_AlarmIconInfo(");
            sbValue.Append("values(");
            sbField.Append("AlarmId");
            sbValue.AppendFormat("{0}", alarmIconInfo.AlarmId);
            sbField.Append(",IconIndex");
            sbValue.AppendFormat(",{0}", alarmIconInfo.IconIndex);
            sbField.Append(",ToolTip");
            sbValue.AppendFormat(",'{0}'", alarmIconInfo.ToolTip);
            sbField.Append(",X");
            sbValue.AppendFormat(",{0}", alarmIconInfo.X);
            sbField.Append(",Y");
            sbValue.AppendFormat(",{0}", alarmIconInfo.Y);
            sbField.Append(",Map");
            sbValue.AppendFormat(",{0}", alarmIconInfo.Map);
            sbField.Append(",MatchCameraId)");
            sbValue.AppendFormat(",{0})", alarmIconInfo.MatchCameraId);
            string cmdText = sbField + " " + sbValue;
            try
            {
                return db.ExecuteNonQuery(CommandType.Text, cmdText);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public static int Update(Database db, AlarmIconInfo alarmIconInfo)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("update IVS_AlarmIconInfo set");
            sb.AppendFormat(" IconIndex={0}", alarmIconInfo.IconIndex);
            sb.AppendFormat(",ToolTip='{0}'", alarmIconInfo.ToolTip);
            sb.AppendFormat(",X={0}", alarmIconInfo.X);
            sb.AppendFormat(",Y={0} ", alarmIconInfo.Y);
            sb.AppendFormat(",MatchCameraId={0} ", alarmIconInfo.MatchCameraId);
            sb.AppendFormat(",Map={0} ", alarmIconInfo.Map);
            sb.AppendFormat(" where AlarmId={0}", alarmIconInfo.AlarmId);
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
        public static int Delete(Database db, int AlarmId)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("delete from IVS_AlarmIconInfo ");
            sb.AppendFormat(" where AlarmId={0}", AlarmId);
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

        public static DataSet GetAllAlarmIconInfo(Database db)
        {
            string cmdText = string.Format("select IVS_AlarmIconInfo.*,IVS_AlarmInfo.Name as AlarmName from (IVS_AlarmIconInfo inner join IVS_AlarmInfo on IVS_AlarmIconInfo.AlarmId =  IVS_AlarmInfo.AlarmId) order by IVS_AlarmInfo.AlarmId");
            try
            {
                return db.ExecuteDataSet(CommandType.Text, cmdText);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public static DataSet GetAlarmIconInfoByAlarmId(Database db, int alarmId)
        {
            string cmdText = string.Format("select IVS_AlarmIconInfo.*,IVS_AlarmInfo.Name as AlarmName from (IVS_AlarmIconInfo inner join IVS_AlarmInfo on IVS_AlarmIconInfo.AlarmId =  IVS_AlarmInfo.AlarmId) where IVS_AlarmInfo.AlarmId={0}", alarmId);
            try
            {
                return db.ExecuteDataSet(CommandType.Text, cmdText);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static DataSet GetAlarmIconInfoByMapId(Database db,int mapId)
        {
            string cmdText = string.Format("select IVS_AlarmIconInfo.*,IVS_AlarmInfo.Name as AlarmName from (IVS_AlarmIconInfo inner join IVS_AlarmInfo on IVS_AlarmIconInfo.AlarmId =  IVS_AlarmInfo.AlarmId) where IVS_AlarmIconInfo.map ={0} order by IVS_AlarmInfo.AlarmId",mapId);
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

