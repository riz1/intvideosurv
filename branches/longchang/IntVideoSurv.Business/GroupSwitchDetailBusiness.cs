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
    public class GroupSwitchDetailBusiness
    {
        public static readonly ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private static GroupSwitchDetailBusiness instance;
        public static GroupSwitchDetailBusiness Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GroupSwitchDetailBusiness();
                }
                return instance;
            }
        }
        public DataTable GetGroupSwitchDetailDataSet(ref string errMessage)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            try
            {

                DataSet ds = GroupSwitchDetailDataAccess.GetAllGroupSwitchDetailInfos(db);

                return ds.Tables[0];

            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return null;
            }
        }

        public List<GroupSwitchDetailInfo> GetGroupSwitchDetailByGroupSwitchId(ref string errMessage, int groupSwitchId)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            try
            {
                List<GroupSwitchDetailInfo> list = new List<GroupSwitchDetailInfo>();
                DataSet ds = GroupSwitchDetailDataAccess.GetGroupSwitchDetailByGroupSwitchId(db, groupSwitchId);
                if (ds.Tables[0].Rows.Count == 0)
                {
                    return null;
                }
                GroupSwitchDetailInfo oGroupSwitchDetailInfo;
                foreach (DataRow  dr in ds.Tables[0].Rows)
                {
                    oGroupSwitchDetailInfo = new GroupSwitchDetailInfo(dr);
                    list.Add(oGroupSwitchDetailInfo);
                    
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
        //GroupSwitchGroupId
        /// <summary>
        /// 
        /// </summary>
        /// <param name="errMessage"></param>
        /// <param name="groupSwitchId"></param>
        /// <returns></returns>
        public GroupSwitchDetailInfo GetGroupSwitchDetailById(ref string errMessage, int groupSwitchId)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            try
            {

                DataSet ds = GroupSwitchDetailDataAccess.GetGroupSwitchDetailByGroupSwitchDetailId(db,groupSwitchId);

                if (ds.Tables[0].Rows.Count == 0)
                {
                    return null;
                }
                return new GroupSwitchDetailInfo(ds.Tables[0].Rows[0]);

            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return null;
            }
        }
        public int DeleteGroupSwitchDetailById(ref string errMessage,int id)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            try
            {
                int iRtn = GroupSwitchDetailDataAccess.Delete(db, id);

                return iRtn;
            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return -1;
            }
        }

        public int InsertGroupSwitchDetailById(ref string errMessage, int groupSwitchid, int synGroupId, int tickTime)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            try
            {
                int iRtn = GroupSwitchDetailDataAccess.Insert(db, groupSwitchid, synGroupId, tickTime);

                return iRtn;
            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return -1;
            }
        }
        public int UpdateTickTimeById(ref string errMessage, int id ,int tickTime)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            try
            {
                int iRtn = GroupSwitchDetailDataAccess.UpdateTickTimeById(db, id,tickTime);

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
