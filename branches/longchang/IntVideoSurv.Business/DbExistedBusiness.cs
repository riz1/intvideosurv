using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using IntVideoSurv.Entity;
using IntVideoSurv.DataAccess;
using log4net;

namespace IntVideoSurv.Business
{
    public class DbExistedBusiness
    {
        public static readonly ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private static DbExistedBusiness instance;
        public static DbExistedBusiness Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DbExistedBusiness();
                }
                return instance;
            }
        }
        public bool IsExisted( ref string errMessage)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            Event et = null;

            try
            {
                DataSet ds = DbExistedDataAccess.GetData(db);
                int one = int.Parse(ds.Tables[0].Rows[0][0].ToString());
                return one == 1 ;

            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return false;
            }
        }

    }
}
