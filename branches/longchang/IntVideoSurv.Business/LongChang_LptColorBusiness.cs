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
    public class LongChang_LptColorBusiness
    {
        public static readonly ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private static LongChang_LptColorBusiness instance;
        public static LongChang_LptColorBusiness Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new LongChang_LptColorBusiness();
                }
                return instance;
            }
        }

        public Dictionary<string, LongChang_LptColorInfo> GetAllLptColorInfo(ref string errMessage)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            Dictionary<string, LongChang_LptColorInfo> list = new Dictionary<string, LongChang_LptColorInfo>();
            try
            {

                DataSet ds = LongChang_LptColorDataAccess.GetAllLptColorInfo(db);

                LongChang_LptColorInfo oLptColor;
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    oLptColor = new LongChang_LptColorInfo(ds.Tables[0].Rows[i]);
                    list.Add(oLptColor.VehiclePlateNumber, oLptColor);


                }
                return list;

            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return new Dictionary<string, LongChang_LptColorInfo>();
            }
        }


    }
}
