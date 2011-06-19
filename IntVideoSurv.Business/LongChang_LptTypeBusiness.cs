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
    public class LongChang_LptTypeBusiness
    {
        public static readonly ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private static LongChang_LptTypeBusiness instance;
        public static LongChang_LptTypeBusiness Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new LongChang_LptTypeBusiness();
                }
                return instance;
            }
        }

        public Dictionary<string, LongChang_LptTypeInfo> GetAllLptTypeInfo(ref string errMessage)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            Dictionary<string, LongChang_LptTypeInfo> list = new Dictionary<string, LongChang_LptTypeInfo>();
            try
            {

                DataSet ds = LongChang_LptTypeDataAccess.GetAllLptTypeInfo(db);

                LongChang_LptTypeInfo oLptType;
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    oLptType = new LongChang_LptTypeInfo(ds.Tables[0].Rows[i]);
                    list.Add(oLptType.PlateNumberType, oLptType);


                }
                return list;

            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return new Dictionary<string, LongChang_LptTypeInfo>();
            }
        }


    }
}
