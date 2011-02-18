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
    public class ProgSwitchBusiness
    {

        public static readonly ILog Logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private static ProgSwitchBusiness _instance;
        public static ProgSwitchBusiness Instance
        {
            get { return _instance ?? (_instance = new ProgSwitchBusiness()); }
        }

        public int GetMaxProgSwitchId(ref string errMessage)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            try
            {
                return ProgSwitchDataAccess.GetMaxProgSwitchId(db);

            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                Logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return -1;
            }
        }

        public int Insert(ref string errMessage, ProgSwitchInfo progSwitchInfo)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            try
            {
                return ProgSwitchDataAccess.Insert(db, progSwitchInfo);

            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                Logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return -1;
            }
        }
        public int Update(ref string errMessage, ProgSwitchInfo progSwitchInfo)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            try
            {
                return ProgSwitchDataAccess.Update(db, progSwitchInfo);

            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                Logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return -1;
            }


        }
        public int Delete(ref string errMessage, int progSwitchId)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            try
            {
                return ProgSwitchDataAccess.Delete(db, progSwitchId);

            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                Logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return -1;
            }

        }

        public Dictionary<int, ProgSwitchInfo> GetAllProgSwitchs(ref string errMessage)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            var list = new Dictionary<int, ProgSwitchInfo>();
            try
            {
                ProgSwitchInfo progSwitchInfo;
                DataSet ds = ProgSwitchDataAccess.GetAllProgSwitchInfo(db);
                DataSet dsProgSwitchDetail;
                ProgSwitchDetailInfo progSwitchDetailInfo;

                //对于每一个程序切换
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    progSwitchInfo = new ProgSwitchInfo(ds.Tables[0].Rows[i]);

                    dsProgSwitchDetail = ProgSwitchDetailDataAccess.GetProgSwitchDetailByProgSwitchId(db, progSwitchInfo.Id);
                    progSwitchInfo.ListProgSwitchDetailInfo = new Dictionary<int, ProgSwitchDetailInfo>();
                    //对于一个程序切换中的所有与程序切换有联系的记录
                    foreach (DataRow drpsd in dsProgSwitchDetail.Tables[0].Rows)
                    {
                        progSwitchDetailInfo = new ProgSwitchDetailInfo(drpsd);

                        progSwitchInfo.ListProgSwitchDetailInfo.Add(progSwitchDetailInfo.ProgSwitchDetailId, progSwitchDetailInfo);
                    }

                    list.Add(progSwitchInfo.Id, progSwitchInfo);
                }
                return list;

            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                Logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return null;
            }
        }
        public ProgSwitchInfo GetProgSwitchById(ref string errMessage, int progSwitchId)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            try
            {
                DataSet ds = ProgSwitchDataAccess.GetProgSwitchById(db, progSwitchId);
                if (ds.Tables[0].Rows.Count == 0)
                {
                    return null;
                }
                var progSwitchInfo = new ProgSwitchInfo(ds.Tables[0].Rows[0]) { ListProgSwitchDetailInfo = new Dictionary<int, ProgSwitchDetailInfo>() };

                var progSwitchDetail = ProgSwitchDetailDataAccess.GetProgSwitchDetailByProgSwitchId(db, progSwitchInfo.Id);
                progSwitchInfo.ListProgSwitchDetailInfo = new Dictionary<int, ProgSwitchDetailInfo>();
                //对于一个程序切换中的所有与程序切换有联系的记录
                foreach (DataRow drpsd in progSwitchDetail.Tables[0].Rows)
                {
                    var progSwitchDetailInfo = new ProgSwitchDetailInfo(drpsd);
                    progSwitchInfo.ListProgSwitchDetailInfo.Add(progSwitchDetailInfo.ProgSwitchDetailId, progSwitchDetailInfo);
                }
                return progSwitchInfo;

            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                Logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return null;
            }
        }


      




    }
}
