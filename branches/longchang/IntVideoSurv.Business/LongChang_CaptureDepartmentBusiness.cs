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
    public class LongChang_CaptureDepartmentBusiness
    {
        public static readonly ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private static LongChang_CaptureDepartmentBusiness instance;
        public static LongChang_CaptureDepartmentBusiness Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new LongChang_CaptureDepartmentBusiness();
                }
                return instance;
            }
        }

        public Dictionary<string, LongChang_CaptureDepartmentInfo> GetAllVehColorInfo(ref string errMessage)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            Dictionary<string, LongChang_CaptureDepartmentInfo> list = new Dictionary<string, LongChang_CaptureDepartmentInfo>();
            try
            {

                DataSet ds = LongChang_ToGateTypeDataAccess.GetAllVehColorInfo(db);

                LongChang_CaptureDepartmentInfo longChangCaptureDepartmentInfo;
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    longChangCaptureDepartmentInfo = new LongChang_CaptureDepartmentInfo(ds.Tables[0].Rows[i]);
                    list.Add(longChangCaptureDepartmentInfo.CaptureDepartmentId, longChangCaptureDepartmentInfo);


                }
                return list;

            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return new Dictionary<string, LongChang_CaptureDepartmentInfo>();
            }
        }


    }
}

