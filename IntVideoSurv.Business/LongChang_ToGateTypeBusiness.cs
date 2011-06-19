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
    public class LongChang_ToGateTypeBusiness
    {
        public static readonly ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private static LongChang_ToGateTypeBusiness instance;
        public static LongChang_ToGateTypeBusiness Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new LongChang_ToGateTypeBusiness();
                }
                return instance;
            }
        }

        public Dictionary<string, LongChang_ToGateTypeInfo> GetAllVehColorInfo(ref string errMessage)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            Dictionary<string, LongChang_ToGateTypeInfo> list = new Dictionary<string, LongChang_ToGateTypeInfo>();
            try
            {

                DataSet ds = LongChang_ToGateTypeDataAccess.GetAllVehColorInfo(db);

                LongChang_ToGateTypeInfo oVehColor;
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    oVehColor = new LongChang_ToGateTypeInfo(ds.Tables[0].Rows[i]);
                    list.Add(oVehColor.GateCaptureTypeId, oVehColor);


                }
                return list;

            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return new Dictionary<string, LongChang_ToGateTypeInfo>();
            }
        }


    }
}

