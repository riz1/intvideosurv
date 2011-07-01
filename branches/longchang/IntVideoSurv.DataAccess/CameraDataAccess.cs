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
            string cmdText = "select max(CameraId) from IVS_CameraInfo";
            try
            {
                return int.Parse(db.ExecuteScalar(CommandType.Text, cmdText).ToString());

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        private const string INSERT_CAMERA = "INSERT INTO IVS_CameraInfo()";
        public static int Insert(Database db, CameraInfo oCameraInfo)
        {
            StringBuilder sbField = new StringBuilder();
            StringBuilder sbValue = new StringBuilder();
            int i;
            if (oCameraInfo.IsValid) i = 1;
            else i = 0;
            sbField.Append("INSERT INTO IVS_CameraInfo(");
            sbValue.Append("values(");
            sbField.Append("DeviceId");
            sbValue.AppendFormat("{0}", oCameraInfo.DeviceId);
            sbField.Append(",Name");
            sbValue.AppendFormat(",'{0}'", oCameraInfo.Name);
            sbField.Append(",Description");
            sbValue.AppendFormat(",'{0}'", oCameraInfo.Description);
            sbField.Append(",IsValid");
            sbValue.AppendFormat(",{0}", i);
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
            sb.Append("update IVS_CameraInfo set");
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
            sb.Append("delete from IVS_CameraInfo ");
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
            sb.Append("delete from IVS_CameraInfo ");
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
            string cmdText = string.Format("select IVS_CameraInfo.*,IVS_DeviceInfo.Name as DeviceName from (CameraInfo inner join IVS_DeviceInfo on CameraInfo.deviceid =  IVS_DeviceInfo.deviceid) order by CameraId");
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
            string cmdText = string.Format("select IVS_CameraInfo.*,IVS_DeviceInfo.Name as DeviceName from (IVS_CameraInfo inner join IVS_DeviceInfo on IVS_CameraInfo.deviceid =  IVS_DeviceInfo.deviceid) where CameraId={0} ", CameraId);
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
            string cmdText = string.Format("select IVS_CameraInfo.*,IVS_DeviceInfo.Name as DeviceName from (IVS_CameraInfo inner join IVS_DeviceInfo on IVS_CameraInfo.deviceid =  IVS_DeviceInfo.deviceid) where IVS_CameraInfo.deviceid={0} and IVS_CameraInfo.Name='{1}'", deviceId, cameraName);
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
            string cmdText = string.Format("select IVS_CameraInfo.*,IVS_DeviceInfo.Name as DeviceName from (IVS_CameraInfo inner join IVS_DeviceInfo on IVS_CameraInfo.deviceid =  IVS_DeviceInfo.deviceid) where IVS_DeviceInfo.DeviceId={0} order by CameraId", DeviceId);
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
            string cmdText = string.Format("select IVS_CameraInfo.*,IVS_DeviceInfo.Name as DeviceName from ((IVS_CameraInfo inner join syncamera on IVS_CameraInfo.Cameraid = syncamera.cameraid ) inner join  IVS_DeviceInfo on IVS_CameraInfo.deviceid =  IVS_DeviceInfo.deviceid) where syncamera.syngroupid={0} order by IVS_CameraInfo.Cameraid;", synGroupId);
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
            string cmdText = string.Format("select IVS_CameraInfo.*,IVS_DeviceInfo.Name as DeviceName from ((IVS_CameraInfo inner join changesyncamera on IVS_CameraInfo.cameraid = changesyncamera.cameraid ) inner join  IVS_DeviceInfo on IVS_CameraInfo.deviceid =  IVS_DeviceInfo.deviceid) where changesyncamera.syngroupid={0} order by IVS_CameraInfo.Cameraid;", synGroupId);
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
            string cmdText = string.Format("select IVS_CameraInfo.CameraId as CameraId,IVS_CameraInfo.Name as CameraName,IVS_CameraInfo.Description as CameraDescription,IVS_CameraInfo.IsValid as IsCameraValid,"+
                "IVS_CameraInfo.ChannelNo as MasterChannelNo, IVS_CameraInfo.ConnURL as ConnURL, IVS_CameraInfo.IsDetectMotion as IsDetect,IVS_CameraInfo.StreamType as StreamType," +
                "IVS_DeviceInfo.Name as DeviceName,IVS_DeviceInfo.DeviceId as DeviceId,IVS_DeviceInfo.Source as DeviceIP, IVS_DeviceInfo.ProviderName as DeviceType, IVS_DeviceInfo.Port as DevicePort,IVS_DeviceInfo.login as DeviceLoginName,IVS_DeviceInfo.pwd as DeviceLoginPassword," +
                "IVS_GroupInfo.Name as GroupName,IVS_GroupInfo.GroupId as GroupId "+
                "from ((((((IVS_CameraInfo inner join IVS_DeviceInfo on IVS_CameraInfo.deviceid =  IVS_DeviceInfo.deviceid) "+
                "inner join IVS_GroupInfo on IVS_DeviceInfo.GroupId = IVS_GroupInfo.GroupId) "+
                "inner join CameraAuthority on IVS_CameraInfo.CameraId=CameraAuthority.CameraId) "+
                "inner join AuthorityGroup on AuthorityGroup.AuthorityId= CameraAuthority.AuthorityId) " +
                "inner join UserAuthority on AuthorityGroup.AuthorityId = UserAuthority.AuthorityId) " +
                "inner join IVS_UserInfo on IVS_UserInfo.UserId = UserAuthority.UserId) " +
                "where IVS_UserInfo.username='{0}' " +
                "order by IVS_CameraInfo.CameraId", userName);
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
