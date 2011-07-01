using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using IntVideoSurv.Entity;

namespace IntVideoSurv.DataAccess
{
    public class AlarmDataAccess
    {
        public static int GetMaxAlarmId(Database db)
        {
            string cmdText = "select max(AlarmId) from IVS_AlarmInfo";
            try
            {
                return int.Parse(db.ExecuteScalar(CommandType.Text, cmdText).ToString());

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        private const string INSERT_CAMERA = "INSERT INTO IVS_AlarmInfo()";
        public static int Insert(Database db, AlarmInfo oCameraInfo)
        {
            StringBuilder sbField = new StringBuilder();
            StringBuilder sbValue = new StringBuilder();
            sbField.Append("INSERT INTO IVS_AlarmInfo(");
            sbValue.Append("values(");
            sbField.Append("DeviceId");
            sbValue.AppendFormat("{0}", oCameraInfo.DeviceId);
            sbField.Append(",Name");
            sbValue.AppendFormat(",'{0}'", oCameraInfo.Name);
            sbField.Append(",Description");
            sbValue.AppendFormat(",'{0}'", oCameraInfo.Description);
            sbField.Append(",IsValid");
            sbValue.AppendFormat(",{0}", oCameraInfo.IsValid);
            sbField.Append(",ChannelNo)");
            sbValue.AppendFormat(",{0})", oCameraInfo.ChannelNo);
            string cmdText = sbField + " " + sbValue ;
            try
            {
                return db.ExecuteNonQuery(CommandType.Text, cmdText);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public static int Update(Database db, AlarmInfo oCameraInfo)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("update IVS_AlarmInfo set");
            sb.AppendFormat(" Name='{0}'", oCameraInfo.Name);
            sb.AppendFormat(",Description='{0}'", oCameraInfo.Description);
            sb.AppendFormat(",IsValid={0}", oCameraInfo.IsValid);
            sb.AppendFormat(",ChannelNo={0} ", oCameraInfo.ChannelNo);
            sb.AppendFormat(" where AlarmId={0})", oCameraInfo.AlarmId);
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
            sb.Append("delete from IVS_AlarmInfo ");
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

        public static int DeleteByDeviceId(Database db, int DeviceId)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("delete from IVS_AlarmInfo ");
            sb.AppendFormat(" where DeviceId={0}", DeviceId);
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


        public static DataSet GetAllAlarmInfo(Database db)
        {
            string cmdText = string.Format("select IVS_AlarmInfo.*,IVS_DeviceInfo.Name as DeviceName from (IVS_AlarmInfo inner join IVS_DeviceInfo on IVS_AlarmInfo.deviceid =  IVS_DeviceInfo.deviceid) order by AlarmId");
            try
            {
                return db.ExecuteDataSet(CommandType.Text, cmdText);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public static DataSet GetAlarmInfoByAlarmId(Database db, int AlarmId)
        {
            string cmdText = string.Format("select IVS_AlarmInfo.*,IVS_DeviceInfo.Name as DeviceName from (IVS_AlarmInfo inner join IVS_DeviceInfo on IVS_AlarmInfo.deviceid =  IVS_DeviceInfo.deviceid) where AlarmId={0} ", AlarmId);
            try
            {
                return db.ExecuteDataSet(CommandType.Text, cmdText);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public static DataSet GetAlarmInfoByDeviceIdAndAlarmName(Database db, int deviceId, string alarmName)
        {
            string cmdText = string.Format("select IVS_AlarmInfo.*,IVS_DeviceInfo.Name as DeviceName from (IVS_AlarmInfo inner join IVS_DeviceInfo on IVS_AlarmInfo.deviceid =  IVS_DeviceInfo.deviceid) where IVS_AlarmInfo.deviceid={0} and IVS_AlarmInfo.Name='{1}'", deviceId, alarmName);
            try
            {
                return db.ExecuteDataSet(CommandType.Text, cmdText);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public static DataSet GetAlarmInfoByDeviceId(Database db, int DeviceId)
        {
            string cmdText = string.Format("select IVS_AlarmInfo.*,IVS_DeviceInfo.Name as DeviceName from (IVS_AlarmInfo inner join IVS_DeviceInfo on IVS_AlarmInfo.deviceid = IVS_DeviceInfo.deviceid) where IVS_DeviceInfo.DeviceId={0} order by AlarmId", DeviceId);
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
