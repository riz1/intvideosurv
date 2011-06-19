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
    public class LongChang_VehTypeBusiness
    {
        public static readonly ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private static LongChang_VehTypeBusiness instance;
        public static LongChang_VehTypeBusiness Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new LongChang_VehTypeBusiness();
                }
                return instance;
            }
        }

        public Dictionary<string, LongChang_VehTypeInfo> GetAllVehTypeInfo(ref string errMessage)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            Dictionary<string, LongChang_VehTypeInfo> list = new Dictionary<string, LongChang_VehTypeInfo>();
            try
            {

                DataSet ds = LongChang_VehTypeDataAccess.GetAllVehTypeInfo(db);

                LongChang_VehTypeInfo oVehType;
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    oVehType = new LongChang_VehTypeInfo(ds.Tables[0].Rows[i]);
                    list.Add(oVehType.VehicleTypeNum, oVehType);


                }
                return list;

            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return new Dictionary<string, LongChang_VehTypeInfo>();
            }
        }


    }
}
