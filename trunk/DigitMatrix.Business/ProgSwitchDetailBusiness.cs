using System;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using IntVideoSurv.Entity;
using IntVideoSurv.DataAccess;
using log4net;

namespace IntVideoSurv.Business
{
    public class ProgSwitchDetailBusiness
    {
        public static readonly ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private static ProgSwitchDetailBusiness instance;
        public static ProgSwitchDetailBusiness Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ProgSwitchDetailBusiness();
                }
                return instance;
            }
        }
        public DataTable GetProgSwitchDetailDataSet(ref string errMessage)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            try
            {

                DataSet ds = ProgSwitchDetailDataAccess.GetAllProgSwitchDetailInfos(db);

                return ds.Tables[0];

            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return null;
            }
        }

        public ProgSwitchDetailInfo GetProgSwitchDetailByProgSwitchId(ref string errMessage, int progSwitchId)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            try
            {

                DataSet ds = ProgSwitchDetailDataAccess.GetProgSwitchDetailByProgSwitchId(db, progSwitchId);

                if (ds.Tables[0].Rows.Count == 0)
                {
                    return null;
                }
                return new ProgSwitchDetailInfo(ds.Tables[0].Rows[0]);

            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return null;
            }
        }

        public ProgSwitchDetailInfo GetProgSwitchDetailByDetailId(ref string errMessage, int detailId)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            try
            {

                DataSet ds = ProgSwitchDetailDataAccess.GetProgSwitchDetailByDetailId(db, detailId);

                if (ds.Tables[0].Rows.Count == 0)
                {
                    return null;
                }
                return new ProgSwitchDetailInfo(ds.Tables[0].Rows[0]);

            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return null;
            }
        }

        public int DeleteProgSwitchDetailById(ref string errMessage, int id)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            try
            {
                int iRtn = ProgSwitchDetailDataAccess.Delete(db, id);

                return iRtn;
            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return -1;
            }
        }

        public int InsertProgSwitchDetailById(ref string errMessage, int grogSwitchid, int cameraId, int tickTime)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            try
            {
                int iRtn = ProgSwitchDetailDataAccess.Insert(db, grogSwitchid, cameraId, tickTime);

                return iRtn;
            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return -1;
            }
        }
        public int UpdateTickTimeById(ref string errMessage, int id, int tickTime)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            try
            {
                int iRtn = ProgSwitchDetailDataAccess.UpdateTickTimeById(db, id, tickTime);

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
