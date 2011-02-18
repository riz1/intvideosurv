using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IntVideoSurv.DataAccess;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using IntVideoSurv.Entity;
using log4net;
using videosource;
using System.Drawing;


namespace IntVideoSurv.Business
{
    public class UserBusiness
    {
        public static readonly ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private static UserBusiness instance;
        public static UserBusiness Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new UserBusiness();
                }
                return instance;
            }
        }
        public int Insert(ref string errMessage, UserInfo userInfo)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            try
            {
                return UserDataAccess.Insert(db, userInfo);

            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return -1;
            }
        }
        public int UpdatePassword(ref string errMessage, int userId, string password)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            try
            {
                return UserDataAccess.UpdatePassword(db, userId, password);

            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return -1;
            }


        }
        public int Delete(ref string errMessage, int userId)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            try
            {
                int iRtn = UserDataAccess.Delete(db, userId);

                return iRtn;
            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return -1;
            }

        }

        public Dictionary<int, UserInfo> GetAllUserInfo(ref string errMessage)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            Dictionary<int, UserInfo> list = new Dictionary<int, UserInfo>();
            try
            {

                DataSet ds = UserDataAccess.GetAllUserInfo(db);

                UserInfo userInfo;
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    userInfo = new UserInfo(ds.Tables[0].Rows[i]);
                    list.Add(userInfo.UserId, userInfo);
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
        public DataTable GetUserDataSet(ref string errMessage)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            try
            {

                DataSet ds = UserDataAccess.GetAllUsers(db);

                return ds.Tables[0];

            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return null;
            }
        }
        public UserInfo GetUserInfo(ref string errMessage, int userId)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            try
            {
                DataSet ds = UserDataAccess.GetUserInfo(db,userId);
                if (ds.Tables[0].Rows.Count == 0)
                {
                    return null;
                }
                return new UserInfo(ds.Tables[0].Rows[0]);

            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return null;
            }
        }

        public UserInfo GetUserInfo(ref string errMessage, string userName)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            try
            {
                DataSet ds = UserDataAccess.GetUserInfo(db, userName);
                if (ds.Tables[0].Rows.Count == 0)
                {
                    return null;
                }
                return new UserInfo(ds.Tables[0].Rows[0]);

            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return null;
            }
        }

        public bool IsUserNameExisted(ref string errMessage, string userName)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            try
            {
                return UserDataAccess.IsUserNameExisted(db, userName);
            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return true;
            }
        }

        public bool IsUserValid(ref string errMessage, string userName,string userPassword)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            try
            {
                return UserDataAccess.IsUserValid(db, userName, userPassword);
            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return true;
            }
        }
    }
}
