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
    }
}
