using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IntVideoSurv.DataAccess;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using IntVideoSurv.Entity;
using log4net;
using System.IO;
using videosource;
using System.Reflection;
using System.Transactions;
namespace IntVideoSurv.Business
{
    public class DeviceBusiness
    {
        public static readonly ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private static DeviceBusiness instance;
        public static DeviceBusiness Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DeviceBusiness();
                }
                return instance;
            }
        }

        public DeviceBusiness(string path)
        {
            Load(path);
        }
        public DeviceBusiness()
        {

        }
        public int Insert(ref string errMessage, DeviceInfo oDeviceInfo)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            try
            {


                return DeviceDataAccess.Insert(db, oDeviceInfo);

            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return -1;
            }
        }
        public int Insert(ref string errMessage, List<CameraInfo> listCam, DeviceInfo oDeviceInfo)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            int iDeviceId = 0;
            int iRtn = 0;
            try
            {
                // using (TransactionScope transaction = new TransactionScope())
                //{
                iRtn = DeviceDataAccess.Insert(db, oDeviceInfo);
                iDeviceId = DeviceDataAccess.GetMaxDeviceId(db);
                foreach (CameraInfo item in listCam)
                {
                    item.DeviceId = iDeviceId;
                    CameraDataAccess.Insert(db, item);
                }
                //  transaction.Complete();
                // }
                return iRtn;

            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return -1;
            }
        }
        public int Update(ref string errMessage, List<CameraInfo> listCam, DeviceInfo oDeviceInfo)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            int iRtn = -1;
            try
            {
                CameraDataAccess.DeleteByDeviceId(db, oDeviceInfo.DeviceId);
                foreach (CameraInfo item in listCam)
                {
                    CameraDataAccess.Insert(db, item);
                }
                iRtn = DeviceDataAccess.Update(db, oDeviceInfo);
                return iRtn;

            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return -1;
            }


        }

        public int Update(ref string errMessage, DeviceInfo oDeviceInfo)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            try
            {
                return DeviceDataAccess.Update(db, oDeviceInfo);

            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return -1;
            }


        }
        public int Delete(ref string errMessage, int deviceId)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            try
            {
                int iRtn = DeviceDataAccess.Delete(db, deviceId);
                iRtn = CameraDataAccess.DeleteByDeviceId(db, deviceId);
                return iRtn;
            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return -1;
            }

        }

        public Dictionary<int, DeviceInfo> GetAllDeviceInfo(ref string errMessage)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            Dictionary<int, DeviceInfo> list = new Dictionary<int, DeviceInfo>();
            try
            {
                DeviceInfo oDeviceInfo;
                DataSet ds = DeviceDataAccess.GetAllDeviceInfo(db);
                DataSet dsCamera;
                CameraInfo oCamera;
                DataSet dsAlarm;
                AlarmInfo oAlarm;
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    oDeviceInfo = new DeviceInfo(ds.Tables[0].Rows[i]);

                    oDeviceInfo.ListCamera = new Dictionary<int, CameraInfo>();

                    dsCamera = CameraDataAccess.GetCamInfoByDeviceId(db, oDeviceInfo.DeviceId);
                    foreach (DataRow drCam in dsCamera.Tables[0].Rows)
                    {
                        oCamera = new CameraInfo(drCam);
                        oDeviceInfo.ListCamera.Add(oCamera.CameraId, oCamera);
                    }

                    oDeviceInfo.ListAlarm = new Dictionary<int, AlarmInfo>();
                    dsAlarm = AlarmDataAccess.GetAlarmInfoByDeviceId(db, oDeviceInfo.DeviceId);
                    foreach (DataRow drAlarm in dsAlarm.Tables[0].Rows)
                    {
                        oAlarm = new AlarmInfo(drAlarm);
                        oDeviceInfo.ListAlarm.Add(oAlarm.AlarmId, oAlarm);
                    }

                    list.Add(oDeviceInfo.DeviceId, oDeviceInfo);


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
        public Dictionary<int, DeviceInfo> GetDeviceInfoByGroupId(ref string errMessage, int GroupId)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            try
            {
                Dictionary<int, DeviceInfo> list = new Dictionary<int, DeviceInfo>();
                DataSet ds = DeviceDataAccess.GetDeviceInfoByGroupId(db, GroupId);
                if (ds.Tables[0].Rows.Count == 0)
                {
                    return null;
                }
                DataSet dsCamera;
                CameraInfo oCamera;
                DeviceInfo oDeviceInfo;
                DataSet dsAlarm;
                AlarmInfo oAlarm;
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    oDeviceInfo = new DeviceInfo(ds.Tables[0].Rows[i]);

                    oDeviceInfo.ListCamera = new Dictionary<int, CameraInfo>();

                    dsCamera = CameraDataAccess.GetCamInfoByDeviceId(db, oDeviceInfo.DeviceId);
                    foreach (DataRow drCam in dsCamera.Tables[0].Rows)
                    {
                        oCamera = new CameraInfo(drCam);
                        oDeviceInfo.ListCamera.Add(oCamera.CameraId, oCamera);
                    }

                    oDeviceInfo.ListAlarm = new Dictionary<int, AlarmInfo>();

                    dsAlarm = AlarmDataAccess.GetAlarmInfoByDeviceId(db, oDeviceInfo.DeviceId);
                    foreach (DataRow drAlarm in dsAlarm.Tables[0].Rows)
                    {
                        oAlarm = new AlarmInfo(drAlarm);
                        oDeviceInfo.ListAlarm.Add(oAlarm.AlarmId, oAlarm);
                    }

                    list.Add(oDeviceInfo.DeviceId, oDeviceInfo);

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
        Dictionary<string, IVideoSourceDescription> _ListVideoProvider = null;
        public Dictionary<string, IVideoSourceDescription> ListVideoProvider
        {
            get
            {
                return _ListVideoProvider;
            }
        }

        // Get provider by its name
        public IVideoSourceDescription GetProviderByName(string name)
        {
            if (_ListVideoProvider != null)
            {
                if (_ListVideoProvider.ContainsKey(name))
                {
                    return _ListVideoProvider[name];
                }
            }
            return null;
        }

        // Load all video providers
        public void Load(string path)
        {
            _ListVideoProvider = new Dictionary<string, IVideoSourceDescription>();
            // create directory info
            DirectoryInfo dir = new DirectoryInfo(path);

            // get all dll files from the directory
            FileInfo[] files = dir.GetFiles("*.dll");

            // walk through all files
            foreach (FileInfo f in files)
            {
                LoadAssembly(Path.Combine(path, f.Name));
            }

        }

        // Load assembly and find video provider descriptors there
        private void LoadAssembly(string fname)
        {
            Type typeVideoSourceDesc = typeof(IVideoSourceDescription);
            Assembly asm = null;

            try
            {
                // try to load assembly
                asm = Assembly.LoadFrom(fname);

                // get types of the assembly
                Type[] types = asm.GetTypes();

                // check all types
                foreach (Type type in types)
                {
                    // get interfaces ot the type
                    Type[] interfaces = type.GetInterfaces();

                    // check, if the type is inherited from IVideoSourceDescription
                    if (Array.IndexOf(interfaces, typeVideoSourceDesc) != -1)
                    {
                        IVideoSourceDescription desc = null;

                        try
                        {
                            // create an instance of the type
                            desc = (IVideoSourceDescription)Activator.CreateInstance(type);
                            // create provider object
                            _ListVideoProvider.Add(desc.Name, desc);

                        }
                        catch (Exception)
                        {
                            // something failed during instance creatinion
                        }
                    }
                }
            }
            catch (Exception)
            {
            }
        }
        public IVideoSource CreateVideoSource(string providerName)
        {
            IVideoSource videoSource = null;
            IVideoSourceDescription sourceDesc = GetProviderByName(providerName);
            if (sourceDesc == null)
            {
                return null;
            }

            videoSource = sourceDesc.CreateVideoSource(null);
            return videoSource;
        }
        public DeviceInfo GetDeviceInfoByDeviceId(ref string errMessage, int DeviceId)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            try
            {
                DataSet ds = DeviceDataAccess.GetDeviceInfoByDeviceId(db, DeviceId);
                if (ds.Tables[0].Rows.Count == 0)
                {
                    return null;
                }
                DataSet dsCamera;
                CameraInfo oCamera;

                DeviceInfo oDeviceInfo = new DeviceInfo(ds.Tables[0].Rows[0]);
                oDeviceInfo = new DeviceInfo(ds.Tables[0].Rows[0]);
                oDeviceInfo.ListCamera = new Dictionary<int, CameraInfo>();
                dsCamera = CameraDataAccess.GetCamInfoByDeviceId(db, oDeviceInfo.DeviceId);
                foreach (DataRow drCam in dsCamera.Tables[0].Rows)
                {
                    oCamera = new CameraInfo(drCam);
                    oDeviceInfo.ListCamera.Add(oCamera.CameraId, oCamera);
                }
                oDeviceInfo.ListAlarm = new Dictionary<int, AlarmInfo>();
                DataSet dsAlarm;
                AlarmInfo oAlarm;
                dsAlarm = AlarmDataAccess.GetAlarmInfoByDeviceId(db, oDeviceInfo.DeviceId);
                foreach (DataRow drAlarm in dsAlarm.Tables[0].Rows)
                {
                    oAlarm = new AlarmInfo(drAlarm);
                    oDeviceInfo.ListAlarm.Add(oAlarm.AlarmId, oAlarm);
                }

                return oDeviceInfo;

            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return null;
            }
        }

        public DeviceInfo GetDeviceInfoByDeviceName(ref string errMessage, string deviceName)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            try
            {
                DataSet ds = DeviceDataAccess.GetDeviceInfoByDeviceName(db, deviceName);
                if (ds.Tables[0].Rows.Count == 0)
                {
                    return null;
                }
                DataSet dsCamera;
                CameraInfo oCamera;

                DeviceInfo oDeviceInfo = new DeviceInfo(ds.Tables[0].Rows[0]);
                oDeviceInfo.ListCamera = new Dictionary<int, CameraInfo>();
                dsCamera = CameraDataAccess.GetCamInfoByDeviceId(db, oDeviceInfo.DeviceId);
                foreach (DataRow drCam in dsCamera.Tables[0].Rows)
                {
                    oCamera = new CameraInfo(drCam);
                    oDeviceInfo.ListCamera.Add(oCamera.CameraId, oCamera);
                }
                oDeviceInfo.ListAlarm = new Dictionary<int, AlarmInfo>();
                DataSet dsAlarm;
                AlarmInfo oAlarm;
                dsAlarm = AlarmDataAccess.GetAlarmInfoByDeviceId(db, oDeviceInfo.DeviceId);
                foreach (DataRow drAlarm in dsAlarm.Tables[0].Rows)
                {
                    oAlarm = new AlarmInfo(drAlarm);
                    oDeviceInfo.ListAlarm.Add(oAlarm.AlarmId, oAlarm);
                }


                return oDeviceInfo;

            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return null;
            }
        }
        public DataTable GetDisplayDeviceByDeviceId(ref string errMessage, int deviceId)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            try
            {

                DataSet ds = DeviceDataAccess.GetDisplayDeviceById(db, deviceId);

                return ds.Tables[0];

            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return null;
            }
        }
        public DataTable GetDisplayDeviceByGroupId(ref string errMessage, int groupId)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            try
            {

                DataSet ds = DeviceDataAccess.GetDisplayDeviceByGroupId(db, groupId);

                return ds.Tables[0];

            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return null;
            }
        }
        public DataTable GetDisplayDeviceByDeviceList(ref string errMessage, string deviceList)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            try
            {
                DataSet ds = DeviceDataAccess.GetAllDisplayDeviceByDeviceList(db, deviceList);

                return ds.Tables[0];

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
