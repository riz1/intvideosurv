using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using IntVideoSurv.Entity;
using IntVideoSurv.DataAccess;
using log4net;
using videosource;
using System.Drawing;


namespace IntVideoSurv.Business
{
    public class TaskBusiness
    {
        public static readonly ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private static TaskBusiness instance;
        public static TaskBusiness Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new TaskBusiness();
                }
                return instance;
            }
        }
        public int Insert(ref string errMessage, TaskInfo taskInfo)
        {

            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            try
            {
                return TaskDataAccess.Insert(db, taskInfo);

            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return -1;
            }
        }

        public int Delete(ref string errMessage, int id)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            try
            {
                int iRtn = TaskDataAccess.Delete(db, id);
                return iRtn;
            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return -1;
            }

        }

        public int Update(ref string errMessage, int id, int status)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            try
            {
                int iRtn = TaskDataAccess.Update(db, id, status);
                return iRtn;
            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return -1;
            }

        }

        public bool IsTaskExisted(ref string errMessage, int id)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            try
            {
                return TaskDataAccess.IsTaskExisted(db, id);
 }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return false;
            }

        }

    }
}