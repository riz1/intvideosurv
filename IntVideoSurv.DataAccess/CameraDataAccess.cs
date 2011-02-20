using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using IntVideoSurv.Entity;

namespace IntVideoSurv.DataAccess
{
    public class CameraDataAccess
    {
        public static int GetMaxCameraId(Database db)
        {
            string cmdText = "select max(CameraId) from CameraInfo";
            try
            {
                return int.Parse(db.ExecuteScalar(CommandType.Text, cmdText).ToString());

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        private const string INSERT_CAMERA = "INSERT INTO CameraInfo()";
        public static int Insert(Database db, CameraInfo oCameraInfo)
        {
            StringBuilder sbField = new StringBuilder();
            StringBuilder sbValue = new StringBuilder();
            sbField.Append("INSERT INTO CameraInfo(");
            sbValue.Append("values(");
            sbField.Append("DeviceId");
            sbValue.AppendFormat("{0}", oCameraInfo.DeviceId);
            sbField.Append(",Name");
            sbValue.AppendFormat(",'{0}'", oCameraInfo.Name);
            sbField.Append(",Description");
            sbValue.AppendFormat(",'{0}'", oCameraInfo.Description);
            sbField.Append(",IsValid");
            sbValue.AppendFormat(",{0}", oCameraInfo.IsValid);
            sbField.Append(",ChannelNo");
            sbValue.AppendFormat(",{0}", oCameraInfo.ChannelNo);
            sbField.Append(",AddressID");
            sbValue.AppendFormat(",{0}", oCameraInfo.AddressID);
            sbField.Append(",ConnURL");
            sbValue.AppendFormat(",'{0}'", oCameraInfo.ConnURL);
            sbField.Append(",Remark");
            sbValue.AppendFormat(",'{0}'", oCameraInfo.Remark);
            sbField.Append(",Oupputpath");
            sbValue.AppendFormat(",'{0}'", oCameraInfo.Oupputpath);
            sbField.Append(",frameInterval");
            sbValue.AppendFormat(",{0}", oCameraInfo.frameInterval);

            sbField.Append(",resolution");
            sbValue.AppendFormat(",'{0}'", oCameraInfo.resolution);

            sbField.Append(",quality");
            sbValue.AppendFormat(",'{0}'", oCameraInfo.quality);


            sbField.Append(",StreamType");
            sbValue.AppendFormat(",{0}", oCameraInfo.StreamType);

          

            sbField.Append(",AddBy");
            sbValue.AppendFormat(",'{0}'", oCameraInfo.AddBy);
            sbField.Append(",AddTime)");
            sbValue.AppendFormat(",'{0}')", oCameraInfo.AddTime);
            string cmdText = sbField.ToString() + " " + sbValue.ToString()  ;
            try
            {
                return  db.ExecuteNonQuery(CommandType.Text, cmdText);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public static int Update(Database db, CameraInfo oCameraInfo)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("update CameraInfo set");
            sb.AppendFormat(" Name='{0}'", oCameraInfo.Name);
            sb.AppendFormat(",Description='{0}'", oCameraInfo.Description);
            sb.AppendFormat(",IsValid={0}", oCameraInfo.IsValid);
            sb.AppendFormat(",ChannelNo={0}", oCameraInfo.ChannelNo);
            sb.AppendFormat(",AddressID={0}", oCameraInfo.AddressID);
            sb.AppendFormat(",ConnURL='{0}'", oCameraInfo.ConnURL);
            sb.AppendFormat(",Remark='{0}'", oCameraInfo.Remark);
            sb.AppendFormat(",Oupputpath='{0}'", oCameraInfo.Oupputpath);
            sb.AppendFormat(",ModifyBy='{0}'", oCameraInfo.AddBy);
            sb.AppendFormat(",ModifyTime='{0}')", oCameraInfo.AddTime);
            sb.AppendFormat(",frameInterval={0})", oCameraInfo.frameInterval);

            sb.AppendFormat(",resolution='{0}'", oCameraInfo.resolution);
            sb.AppendFormat(",quality='{0}')", oCameraInfo.quality);
            sb.AppendFormat(",StreamType={0})", oCameraInfo.StreamType);


            sb.AppendFormat(" where CameraId={0})", oCameraInfo.CameraId);
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
        public static int Delete(Database db, int CameraId)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("delete from CameraInfo ");
            sb.AppendFormat(" where CameraId={0}", CameraId);
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
            sb.Append("delete from CameraInfo ");
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


        public static DataSet GetAllCamInfo(Database db)
        {
            string cmdText = string.Format("select CameraInfo.*,DeviceInfo.Name as DeviceName from (CameraInfo inner join DeviceInfo on CameraInfo.deviceid =  DeviceInfo.deviceid) order by CameraId");
            try
            {
                return db.ExecuteDataSet(CommandType.Text, cmdText);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public static DataSet GetCamInfoByCameraId(Database db, int CameraId)
        {
            string cmdText = string.Format("select CameraInfo.*,DeviceInfo.Name as DeviceName from (CameraInfo inner join DeviceInfo on CameraInfo.deviceid =  DeviceInfo.deviceid) where CameraId={0} ", CameraId);
            try
            {
                return db.ExecuteDataSet(CommandType.Text, cmdText);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public static DataSet GetCamInfoByDeviceIdAndCameraName(Database db, int deviceId, string cameraName)
        {
            string cmdText = string.Format("select CameraInfo.*,DeviceInfo.Name as DeviceName from (CameraInfo inner join DeviceInfo on CameraInfo.deviceid =  DeviceInfo.deviceid) where CameraInfo.deviceid={0} and CameraInfo.Name='{1}'", deviceId, cameraName);
            try
            {
                return db.ExecuteDataSet(CommandType.Text, cmdText);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public static DataSet GetCamInfoByDeviceId(Database db, int DeviceId)
        {
            string cmdText = string.Format("select CameraInfo.*,DeviceInfo.Name as DeviceName from (CameraInfo inner join DeviceInfo on CameraInfo.deviceid =  DeviceInfo.deviceid) where DeviceInfo.DeviceId={0} order by CameraId", DeviceId);
            try
            {
                return db.ExecuteDataSet(CommandType.Text, cmdText);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static DataSet GetCamInfoBySynGroupId(Database db, int synGroupId)
        {
            string cmdText = string.Format("select CameraInfo.*,DeviceInfo.Name as DeviceName from ((CameraInfo inner join syncamera on CameraInfo.Cameraid = syncamera.cameraid ) inner join  DeviceInfo on CameraInfo.deviceid =  DeviceInfo.deviceid) where syncamera.syngroupid={0} order by CameraInfo.Cameraid;", synGroupId);
            try
            {
                return db.ExecuteDataSet(CommandType.Text, cmdText);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static DataSet GetCamInfoByChangeSynGroupId(Database db, int synGroupId)
        {
            string cmdText = string.Format("select CameraInfo.*,DeviceInfo.Name as DeviceName from ((CameraInfo inner join changesyncamera on CameraInfo.cameraid = changesyncamera.cameraid ) inner join  DeviceInfo on CameraInfo.deviceid =  DeviceInfo.deviceid) where changesyncamera.syngroupid={0} order by CameraInfo.Cameraid;", synGroupId);
            try
            {
                return db.ExecuteDataSet(CommandType.Text, cmdText);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static DataSet GetAllCamInfoByUsername(Database db, string userName)
        {
            string cmdText = string.Format("select CameraInfo.CameraId as CameraId,CameraInfo.Name as CameraName,CameraInfo.Description as CameraDescription,CameraInfo.IsValid as IsCameraValid,"+
                "CameraInfo.ChannelNo as MasterChannelNo, CameraInfo.ConnURL as ConnURL, CameraInfo.IsDetectMotion as IsDetect,CameraInfo.StreamType as StreamType," +
                "DeviceInfo.Name as DeviceName,DeviceInfo.DeviceId as DeviceId,DeviceInfo.Source as DeviceIP, DeviceInfo.ProviderName as DeviceType, DeviceInfo.Port as DevicePort,DeviceInfo.login as DeviceLoginName,DeviceInfo.pwd as DeviceLoginPassword," +
                "GroupInfo.Name as GroupName,GroupInfo.GroupId as GroupId "+
                "from ((((((CameraInfo inner join DeviceInfo on CameraInfo.deviceid =  DeviceInfo.deviceid) "+
                "inner join GroupInfo on DeviceInfo.GroupId = GroupInfo.GroupId) "+
                "inner join CameraAuthority on CameraInfo.CameraId=CameraAuthority.CameraId) "+
                "inner join AuthorityGroup on AuthorityGroup.AuthorityId= CameraAuthority.AuthorityId) " +
                "inner join UserAuthority on AuthorityGroup.AuthorityId = UserAuthority.AuthorityId) " +
                "inner join UserInfo on UserInfo.UserId = UserAuthority.UserId) " +
                "where Userinfo.username='{0}' " +
                "order by CameraInfo.CameraId", userName);
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
