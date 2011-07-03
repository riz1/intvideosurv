using System;
using System.Collections.Generic;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using IntVideoSurv.Entity;
using IntVideoSurv.DataAccess;
using log4net;

namespace IntVideoSurv.Business
{
    public class VirtualGroupBusiness
    {
        public static readonly ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private static VirtualGroupBusiness instance;
        public static VirtualGroupBusiness Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new VirtualGroupBusiness();
                }
                return instance;
            }
        }
        public int Insert(ref string errMessage, VirtualGroupInfo oVirtualGroup)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            try
            {
                return VirtualGroupDataAccess.Insert(db, oVirtualGroup);

            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return -1;
            }
        }
        public  int DeleteByGroupID(ref string errMessage, int GroupID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            try
            {
                return VirtualGroupDataAccess.DeleteByGroupID(db, GroupID);

            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return -1;
            }

        }
        public Dictionary<int, VirtualGroupInfo> GetAllVirtualGroupInfo(ref string errMessage)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            Dictionary<int, VirtualGroupInfo> list = new Dictionary<int, VirtualGroupInfo>();
            try
            {
                VirtualGroupInfo oVirtualGroupInfo;
                DataSet ds = VirtualGroupDataAccess.GetAllVirtualGroupInfo(db);

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    oVirtualGroupInfo = new VirtualGroupInfo(ds.Tables[0].Rows[i]);
                    list.Add(oVirtualGroupInfo.ID, oVirtualGroupInfo);
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
        public int ChangeVirtualGroup(ref string errMessage,int Gid,string newname)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            try
            {
                return VirtualGroupDataAccess.ChangeVirtualGroup(db,Gid,newname);

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
