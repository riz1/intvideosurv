using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using IntVideoSurv.Entity;
using IntVideoSurv.DataAccess;
using log4net;
using System.IO;
using videosource;
using System.Reflection;
using System.Transactions;

namespace IntVideoSurv.Business
{
    public class DefaultCardOutBusiness
    {
        public static readonly ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private static DefaultCardOutBusiness instance;
        public static DefaultCardOutBusiness Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DefaultCardOutBusiness();
                }
                return instance;
            }
        }
        public int Insert(ref string errMessage, DefaultCardOut defaultCardOut)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            try
            {
                return DefaultCardOutDataAccess.Insert(db, defaultCardOut);

            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return -1;
            }
        }
        public int Update(ref string errMessage, DefaultCardOut defaultCardOut)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            try
            {
                return DefaultCardOutDataAccess.Update(db, defaultCardOut);

            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return -1;
            }


        }
        public int Delete(ref string errMessage, int defaultCardOutId)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            try
            {
                int iRtn = DefaultCardOutDataAccess.Delete(db, defaultCardOutId);

                return iRtn;
            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return -1;
            }

        }

        public Dictionary<int, DefaultCardOut> GetAllDefaultCardOuts(ref string errMessage)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            Dictionary<int, DefaultCardOut> list = new Dictionary<int, DefaultCardOut>();
            try
            {

                DataSet ds = DefaultCardOutDataAccess.GetAllDefaultCardOuts(db);

                DefaultCardOut defaultCardOut;
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    defaultCardOut = new DefaultCardOut(ds.Tables[0].Rows[i]);
                    list.Add(defaultCardOut.Id, defaultCardOut);


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
        public DefaultCardOut GetDefaultCardOutById(ref string errMessage, int defaultCardOutId)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            try
            {
                DataSet ds = DefaultCardOutDataAccess.GetDefaultCardOutById(db, defaultCardOutId);
                if (ds.Tables[0].Rows.Count == 0)
                {
                    return null;
                }
                return new DefaultCardOut(ds.Tables[0].Rows[0]);

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
