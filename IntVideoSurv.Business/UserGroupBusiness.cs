using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using IntVideoSurv.Entity;
using IntVideoSurv.DataAccess;
using log4net;
using SMRemotingInterface;
using videosource;
using System.Drawing;


namespace IntVideoSurv.Business
{
    public class UserGroupBusiness
    {
        public static readonly ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private static UserGroupBusiness instance;
        public static UserGroupBusiness Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new UserGroupBusiness();
                }
                return instance;
            }
        }
        public int InsertUser(ref string errMessage, int userid, int groupid)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            try
            {
                if (UserGroupDataAccess.GetTheUser(db, userid).Tables[0].Rows.Count != 0)
                {

                    return -1;

                }
                else
                {
                    return UserGroupDataAccess.InsertUser(db, userid, groupid);
                }
                //return DecoderDataAccess.InsertCamera(db, odecoder, ocamera);  

            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return -1;
            }

        }
        public int Insert(ref string errMessage, UserGroupInfo oUserGroup)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            try
            {
                return UserGroupDataAccess.Insert(db, oUserGroup);

            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return -1;
            }
        }
        public int Update(ref string errMessage, UserGroupInfo oUserGroup)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            try
            {
                return UserGroupDataAccess.Update(db, oUserGroup);

            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return -1;
            }


        }
        public int DeleteUser(ref string errMessage, int userid)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            try
            {
                int iRtn = UserGroupDataAccess.DeleteUser(db, userid);

                return iRtn;
            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return -1;
            }

        }
        public int Delete(ref string errMessage, int ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            try
            {
                int iRtn = UserGroupDataAccess.Delete(db, ID);

                return iRtn;
            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return -1;
            }

        }
        public int DeleteByVirtualGroupID(ref string errMessage, int ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            try
            {
                int iRtn = UserGroupDataAccess.DeleteByVirtualGroupID(db, ID);

                return iRtn;
            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return -1;
            }

        }
        public Dictionary<int, UserInfo> GetAllCameraInfo(ref string errMessage, int VirtualGroupId)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            Dictionary<int, UserInfo> list = new Dictionary<int, UserInfo>();
            try
            {
                UserInfo oUserInfo;
                DataSet ds = UserGroupDataAccess.GetAllCameraInfo(db, VirtualGroupId);

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    oUserInfo = new UserInfo(ds.Tables[0].Rows[i]);
                    list.Add(oUserInfo.UserId, oUserInfo);
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
        public Dictionary<int, CameraInfo> GetCameraInfoByUserId(ref string errMessage, int userid)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            Dictionary<int, CameraInfo> list = new Dictionary<int, CameraInfo>();
            try
            {
                CameraInfo oCameraInfo;
                DataSet ds = UserGroupDataAccess.GetCameraInfoByUserId(db, userid);

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    oCameraInfo = new CameraInfo(ds.Tables[0].Rows[i]);
                    list.Add(oCameraInfo.CameraId, oCameraInfo);
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
    }
}
