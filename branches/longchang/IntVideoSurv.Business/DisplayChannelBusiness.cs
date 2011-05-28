using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using IntVideoSurv.Entity;
using IntVideoSurv.DataAccess;
using log4net;

namespace IntVideoSurv.Business
{
    public class DisplayChannelBusiness
    {

        public static readonly ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private static DisplayChannelBusiness instance;
        public static DisplayChannelBusiness Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DisplayChannelBusiness();
                }
                return instance;
            }
        }

        public int GetMaxDisplayChannelId(ref string errMessage)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            try
            {
                return DisplayChannelDataAccess.GetMaxDisplayChannelId(db);

            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return -1;
            }
        }

        public int Insert(ref string errMessage, DisplayChannelInfo displayChannelInfo)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            try
            {
                return DisplayChannelDataAccess.Insert(db, displayChannelInfo);

            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return -1;
            }
        }
        public int Update(ref string errMessage, DisplayChannelInfo displayChannelInfo)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            try
            {
                return DisplayChannelDataAccess.Update(db, displayChannelInfo);

            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return -1;
            }


        }
        public int Delete(ref string errMessage, int monitorId)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            try
            {
                return DisplayChannelDataAccess.Delete(db, monitorId);

            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return -1;
            }

        }

        public Dictionary<int, DisplayChannelInfo> GetAllDisplayChannelInfo(ref string errMessage)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            Dictionary<int, DisplayChannelInfo> list = new Dictionary<int, DisplayChannelInfo>();
            try
            {
                DisplayChannelInfo displayChannelInfo;
                DataSet ds = DisplayChannelDataAccess.GetAllDisplayChannelInfos(db);
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    displayChannelInfo = new DisplayChannelInfo(ds.Tables[0].Rows[i]);
                    list.Add(displayChannelInfo.DisplayChannelId, displayChannelInfo);
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

        public DisplayChannelInfo GetDisplayChannelInfoById(ref string errMessage, int monitorId)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            try
            {
                DataSet ds = DisplayChannelDataAccess.GetDisplayChannelInfoById(db, monitorId);
                if (ds.Tables[0].Rows.Count == 0)
                {
                    return null;
                }
                return new DisplayChannelInfo(ds.Tables[0].Rows[0]);

            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return null;
            }
        }

        public int UpdateSplitScreenById(ref string errMessage, int id, int splitScreenNo)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            try
            {
                return DisplayChannelDataAccess.UpdateSplitScreenById(db, id, splitScreenNo);

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
