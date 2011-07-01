using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using IntVideoSurv.Entity;

namespace IntVideoSurv.DataAccess
{
    public class DeviceDataAccess
    {
        public static int GetMaxDeviceId(Database db)
        {
            string cmdText = "select max(DeviceId) from IVS_DeviceInfo";
            try
            {
                return int.Parse(db.ExecuteScalar(CommandType.Text, cmdText).ToString());

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public static int Insert(Database db, DeviceInfo oDeviceInfo)
        {

            StringBuilder sbField = new StringBuilder();
            StringBuilder sbValue = new StringBuilder();
            sbField.Append("INSERT INTO  IVS_DeviceInfo(");
            sbValue.Append("values(");
            sbField.Append("Name");
            sbValue.AppendFormat("'{0}'", oDeviceInfo.Name);
            sbField.Append(",source");
            sbValue.AppendFormat(",'{0}'", oDeviceInfo.source);
            sbField.Append(",login");
            sbValue.AppendFormat(",'{0}'", oDeviceInfo.login);
            sbField.Append(",pwd");
            sbValue.AppendFormat(",'{0}'", oDeviceInfo.pwd);
            sbField.Append(",Port");
            sbValue.AppendFormat(",{0}", oDeviceInfo.Port);
            sbField.Append(",VideoCount");
            sbValue.AppendFormat(",{0}", oDeviceInfo.VideoCount);
            sbField.Append(",WarningOutputCount");
            sbValue.AppendFormat(",{0}", oDeviceInfo.WarningOutputCount);
            sbField.Append(",WarningInputNo");
            sbValue.AppendFormat(",{0}", oDeviceInfo.WarningInputNo);
            sbField.Append(",Description");
            sbValue.AppendFormat(",'{0}'", oDeviceInfo.Description);
            sbField.Append(",FileExtName");
            sbValue.AppendFormat(",'{0}'", oDeviceInfo.FileExtName);
            sbField.Append(",Remark");
            sbValue.AppendFormat(",'{0}'", oDeviceInfo.Remark);
            sbField.Append(",ProviderName");
            sbValue.AppendFormat(",'{0}'", oDeviceInfo.ProviderName);
            sbField.Append(",GroupId");
            sbValue.AppendFormat(",{0}", oDeviceInfo.GroupId);
            sbField.Append(",AddBy");
            sbValue.AppendFormat(",'{0}'", oDeviceInfo.AddBy);
            sbField.Append(",AddTime)");
            sbValue.AppendFormat(",'{0}')", oDeviceInfo.AddTime);
            string cmdText = sbField.ToString() + " " + sbValue.ToString() ;


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
        public static int Update(Database db, DeviceInfo oDeviceInfo)
        {

            StringBuilder sbValue = new StringBuilder();
            sbValue.Append("update IVS_DeviceInfo set ");
            sbValue.AppendFormat("Name='{0}'", oDeviceInfo.Name);
            sbValue.AppendFormat(",source='{0}'", oDeviceInfo.source);
            sbValue.AppendFormat(",login='{0}'", oDeviceInfo.login);
            sbValue.AppendFormat(",pwd='{0}'", oDeviceInfo.pwd);
            sbValue.AppendFormat(",Port={0}", oDeviceInfo.Port);
            sbValue.AppendFormat(",VideoCount={0}", oDeviceInfo.VideoCount);
            sbValue.AppendFormat(",WarningOutputCount={0}", oDeviceInfo.WarningOutputCount);
            sbValue.AppendFormat(",WarningInputNo={0}", oDeviceInfo.WarningInputNo);
            sbValue.AppendFormat(",WarningCount={0}", oDeviceInfo.WarningCount);
            sbValue.AppendFormat(",FileExtName='{0}'", oDeviceInfo.FileExtName);
            sbValue.AppendFormat(",Remark='{0}'", oDeviceInfo.Remark);
            sbValue.AppendFormat(",ProviderName='{0}'", oDeviceInfo.ProviderName);
            sbValue.AppendFormat(",GroupId={0}", oDeviceInfo.GroupId);


            sbValue.AppendFormat(" where DeviceId={0}", oDeviceInfo.DeviceId);
            string cmdText = sbValue.ToString();
            try
            {
                return db.ExecuteNonQuery(CommandType.Text, cmdText);

            }
            catch (Exception ex)
            {

                throw ex;
            }


        }
        public static int Delete(Database db, int DeviceId)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("delete from IVS_DeviceInfo ");
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
        public static int DeleteByGroupId(Database db, int GroupId)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("delete from IVS_DeviceInfo ");
            sb.AppendFormat(" where GroupId={0}", GroupId);
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
        public static DataSet GetAllDeviceInfo(Database db)
        {
            string cmdText = string.Format("select * from IVS_DeviceInfo order by DeviceId");
            try
            {
                return db.ExecuteDataSet(CommandType.Text, cmdText);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static DataSet GetDeviceInfoByDeviceId(Database db, int deviceId)
        {
            string cmdText = string.Format("select * from IVS_DeviceInfo where DeviceId={0} order by DeviceId", deviceId);
            try
            {
                return db.ExecuteDataSet(CommandType.Text, cmdText);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public static DataSet GetDeviceInfoByDeviceName(Database db, string deviceName)
        {
            string cmdText = string.Format("select * from IVS_DeviceInfo where Name='{0}' order by DeviceId", deviceName);
            try
            {
                return db.ExecuteDataSet(CommandType.Text, cmdText);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static DataSet GetDeviceInfoByGroupId(Database db, int groupId)
        {
            string cmdText = string.Format("select * from IVS_DeviceInfo where GroupId={0} order by DeviceId", groupId);
            try
            {
                return db.ExecuteDataSet(CommandType.Text, cmdText);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static DataSet GetDisplayDeviceById(Database db, int deviceId)
        {
            string cmdText = string.Format("select deviceID as 索引号, IVS_DeviceInfo.name as 设备名, source as IP地址, port as 端口, "+
                "login as 登录名,IVS_DeviceInfo.description as 描述,IVS_GroupInfo.Name as 组名 "+
                "from (IVS_DeviceInfo left join IVS_GroupInfo on (IVS_DeviceInfo.GroupId=IVS_GroupInfo.GroupId)) where DeviceId={0}", deviceId);
            try
            {
                return db.ExecuteDataSet(CommandType.Text, cmdText);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static DataSet GetDisplayDeviceByGroupId(Database db, int groupId)
        {
            string cmdText = string.Format(
                "select deviceID as 索引号, IVS_DeviceInfo.name as 设备名, source as IP地址, port as 端口, "+
                "login as 登录名,IVS_DeviceInfo.description as 描述,IVS_GroupInfo.Name as 组名 "+
                "from (IVS_DeviceInfo left join IVS_GroupInfo on (IVS_DeviceInfo.GroupId=IVS_GroupInfo.GroupId)) where IVS_DeviceInfo.GroupId={0} order by DeviceId", groupId);
            try
            {
                return db.ExecuteDataSet(CommandType.Text, cmdText);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public static DataSet GetAllDisplayDeviceByDeviceList(Database db,string devicelist)
        {
            string cmdText = string.Format("select deviceID as 索引号, IVS_DeviceInfo.name as 设备名, source as IP地址, port as 端口, "+
                "login as 登录名,IVS_DeviceInfo.description as 描述,IVS_GroupInfo.Name as 组名 "+
                " from  (IVS_DeviceInfo left join IVS_GroupInfo on (IVS_DeviceInfo.GroupId=IVS_GroupInfo.GroupId)) where DeviceId in {0} order by DeviceId", devicelist);
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
