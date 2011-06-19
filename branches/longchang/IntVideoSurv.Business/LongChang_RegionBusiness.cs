using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using IntVideoSurv.DataAccess;
using IntVideoSurv.Entity;
using log4net;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace IntVideoSurv.Business
{
    public class LongChang_RegionBusiness
    {
        public static readonly ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private static LongChang_RegionBusiness instance;
        public static LongChang_RegionBusiness Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new LongChang_RegionBusiness();
                }
                return instance;
            }
        }

        public Dictionary<string, LongChang_RegionInfo> GetAllVehColorInfo(ref string errMessage)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            Dictionary<string, LongChang_RegionInfo> list = new Dictionary<string, LongChang_RegionInfo>();
            try
            {

                DataSet ds = LongChang_RegionDataAccess.GetAllRegionInfo(db);

                LongChang_RegionInfo longChangRegionInfo;
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    longChangRegionInfo = new LongChang_RegionInfo(ds.Tables[0].Rows[i]);
                    list.Add(longChangRegionInfo.RegionId, longChangRegionInfo);


                }
                return list;

            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return new Dictionary<string, LongChang_RegionInfo>();
            }
        }


    }
}

