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
    public class LongChang_InvalidTypeBusiness
    {
        public static readonly ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private static LongChang_InvalidTypeBusiness instance;
        public static LongChang_InvalidTypeBusiness Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new LongChang_InvalidTypeBusiness();
                }
                return instance;
            }
        }

        public Dictionary<string, LongChang_InvalidTypeInfo> GetAllInvalidTypeInfo(ref string errMessage)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            Dictionary<string, LongChang_InvalidTypeInfo> list = new Dictionary<string, LongChang_InvalidTypeInfo>();
            try
            {

                DataSet ds = LongChang_InvalidTypeDataAccess.GetAllInvalidType(db);

                LongChang_InvalidTypeInfo longChangInvalidTypeInfo;
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    longChangInvalidTypeInfo = new LongChang_InvalidTypeInfo(ds.Tables[0].Rows[i]);
                    list.Add(longChangInvalidTypeInfo.InvalidId, longChangInvalidTypeInfo);


                }
                return list;

            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return new Dictionary<string, LongChang_InvalidTypeInfo>();
            }
        }


    }
}

