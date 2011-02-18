using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IntVideoSurv.DataAccess;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using IntVideoSurv.Entity;
using log4net;

namespace IntVideoSurv.Business
{
    public class GroupBusiness
    {

        public static readonly ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private static GroupBusiness instance;
        public static GroupBusiness Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GroupBusiness();
                }
                return instance;
            }
        }

        public int GetMaxGroupId(ref string errMessage)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            try
            {
                return GroupDataAccess.GetMaxGroupId(db);

            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return -1;
            }
        }

        public  int Insert(ref string errMessage, GroupInfo oGroupInfo)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            try
            {
                return GroupDataAccess.Insert(db, oGroupInfo);

            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return -1;
            }
        }
        public  int Update(ref string errMessage, GroupInfo oGroupInfo)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            try
            {
                return GroupDataAccess.Update(db, oGroupInfo);

            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return -1;
            }


        }
        public  int Delete(ref string errMessage, int groupId)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            try
            {
                return GroupDataAccess.Delete(db, groupId);

            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return -1;
            }

        }
        
        public  Dictionary<int,GroupInfo> GetAllGroupInfos(ref string errMessage)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            Dictionary<int, GroupInfo> list = new Dictionary<int, GroupInfo>();
            try
            {
                GroupInfo oGroupInfo;
                DeviceInfo oDevice;
                DataSet ds= GroupDataAccess.GetAllGroupInfo(db);
                DataSet dsDevice;
                DataSet dsCamera;
                CameraInfo oCamera;
                DataSet dsAlarm;
                AlarmInfo oAlarm;
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    oGroupInfo = new GroupInfo(ds.Tables[0].Rows[i]);
                    dsDevice = DeviceDataAccess.GetDeviceInfoByGroupId(db, oGroupInfo.GroupID);
                    oGroupInfo.ListDevice = new Dictionary<int, DeviceInfo>();
                    foreach (DataRow dr in dsDevice.Tables[0].Rows)
                    {
                        oDevice = new DeviceInfo(dr);
                        oDevice.ListCamera = new Dictionary<int, CameraInfo>();
                        dsCamera = CameraDataAccess.GetCamInfoByDeviceId(db, oDevice.DeviceId);
                        foreach (DataRow drCam in dsCamera.Tables[0].Rows)
                        {
                            oCamera=new CameraInfo(drCam);
                            oDevice.ListCamera.Add(oCamera.CameraId, oCamera);
                        }

                        oDevice.ListAlarm = new Dictionary<int, AlarmInfo>();
                        dsAlarm = AlarmDataAccess.GetAlarmInfoByDeviceId(db, oDevice.DeviceId);
                        foreach (DataRow drAlarm in dsAlarm.Tables[0].Rows)
                        {
                            oAlarm = new AlarmInfo(drAlarm);
                            oDevice.ListAlarm.Add(oAlarm.AlarmId, oAlarm);
                        }

                        oGroupInfo.ListDevice.Add(oDevice.DeviceId, oDevice);

                    }
                    list.Add(oGroupInfo.GroupID, oGroupInfo);
                }
                return list;

            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return null;
            }
        }
        public  GroupInfo GetGroupInfoByGroupId(ref string errMessage, int groupId)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            try
            {
                DataSet ds= GroupDataAccess.GetGroupInfoByGroupId(db,groupId);
                if (ds.Tables[0].Rows.Count == 0)
                {
                    return null;
                }
                DataSet dsDevice;
                DataSet dsCamera;
                CameraInfo oCamera;
                DeviceInfo oDevice;
                DataSet dsAlarm;
                AlarmInfo oAlarm;
                GroupInfo oGroupInfo = new GroupInfo(ds.Tables[0].Rows[0]);
                dsDevice = DeviceDataAccess.GetDeviceInfoByGroupId(db, oGroupInfo.GroupID);
                oGroupInfo.ListDevice = new Dictionary<int, DeviceInfo>();
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    oDevice = new DeviceInfo(dr);
                    oDevice.ListCamera = new Dictionary<int, CameraInfo>();
                    dsCamera = CameraDataAccess.GetCamInfoByDeviceId(db, oDevice.DeviceId);
                    foreach (DataRow drCam in dsCamera.Tables[0].Rows)
                    {
                        oCamera = new CameraInfo(drCam);
                        oDevice.ListCamera.Add(oCamera.CameraId, oCamera);
                    }

                    oDevice.ListAlarm = new Dictionary<int, AlarmInfo>();
                    dsAlarm = AlarmDataAccess.GetAlarmInfoByDeviceId(db, oDevice.DeviceId);
                    foreach (DataRow drAlarm in dsAlarm.Tables[0].Rows)
                    {
                        oAlarm = new AlarmInfo(drAlarm);
                        oDevice.ListAlarm.Add(oAlarm.AlarmId, oAlarm);
                    }

                    oGroupInfo.ListDevice.Add(oDevice.DeviceId, oDevice);

                }


                return oGroupInfo;

            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return null;
            }
        }

        public GroupInfo GetGroupInfoByGroupName(ref string errMessage, string groupName)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            try
            {
                DataSet ds = GroupDataAccess.GetGroupInfoByGroupName(db, groupName);
                if (ds.Tables[0].Rows.Count == 0)
                {
                    return null;
                }
                DataSet dsDevice;
                DataSet dsCamera;
                CameraInfo oCamera;
                DeviceInfo oDevice;
                DataSet dsAlarm;
                AlarmInfo oAlarm;

                GroupInfo oGroupInfo = new GroupInfo(ds.Tables[0].Rows[0]);
                dsDevice = DeviceDataAccess.GetDeviceInfoByGroupId(db, oGroupInfo.GroupID);
                oGroupInfo.ListDevice = new Dictionary<int, DeviceInfo>();
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    oDevice = new DeviceInfo(dr);
                    oDevice.ListCamera = new Dictionary<int, CameraInfo>();
                    dsCamera = CameraDataAccess.GetCamInfoByDeviceId(db, oDevice.DeviceId);
                    foreach (DataRow drCam in dsCamera.Tables[0].Rows)
                    {
                        oCamera = new CameraInfo(drCam);
                        oDevice.ListCamera.Add(oCamera.CameraId, oCamera);
                    }
                    oDevice.ListAlarm = new Dictionary<int, AlarmInfo>();
                    dsAlarm = AlarmDataAccess.GetAlarmInfoByDeviceId(db, oDevice.DeviceId);
                    foreach (DataRow drAlarm in dsAlarm.Tables[0].Rows)
                    {
                        oAlarm = new AlarmInfo(drAlarm);
                        oDevice.ListAlarm.Add(oAlarm.AlarmId, oAlarm);
                    }
                    oGroupInfo.ListDevice.Add(oDevice.DeviceId, oDevice);

                }


                return oGroupInfo;

            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return null;
            }
        }


    }
}
