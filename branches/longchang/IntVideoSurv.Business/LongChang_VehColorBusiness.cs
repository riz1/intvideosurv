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
    public class LongChang_VehColorBusiness
    {
        public static readonly ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private static LongChang_VehColorBusiness instance;
        public static LongChang_VehColorBusiness Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new LongChang_VehColorBusiness();
                }
                return instance;
            }
        }

        public Dictionary<int, LongChang_VehColorInfo> GetAllVehColorInfo(ref string errMessage)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            Dictionary<int, LongChang_VehColorInfo> list = new Dictionary<int, LongChang_VehColorInfo>();
            try
            {

                DataSet ds = LongChang_VehColorDataAccess.GetAllVehColorInfo(db);

                LongChang_VehColorInfo oVehColor;
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    oVehColor = new LongChang_VehColorInfo(ds.Tables[0].Rows[i]);
                    list.Add(oVehColor.VehicleColorNum, oVehColor);


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


    }
}
