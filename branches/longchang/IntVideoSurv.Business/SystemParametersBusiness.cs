using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using IntVideoSurv.Entity;
using IntVideoSurv.DataAccess;
using log4net;

namespace IntVideoSurv.Business
{
    public class SystemParametersBusiness
    {
        public static readonly ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private static SystemParametersBusiness instance;
        public static SystemParametersBusiness Instance
        {
            get { return instance ?? (instance = new SystemParametersBusiness()); }
        }

        private Dictionary<string, SystemParameter> _listSystemParameter;
        public Dictionary<string,SystemParameter> ListSystemParameter
        {
            get
            {
                if (_listSystemParameter==null)
                {
                    string errMessage = "";
                    _listSystemParameter = GetSystemParameters(ref errMessage);                    
                }
                return _listSystemParameter;
            }
        }
        public int UpdateParameter(ref string errMessage, SystemParameter systemParameter)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            try
            {
                int ret = SystemParametersDataAccess.UpdateParameter(db, systemParameter);
                GetSystemParameters(ref errMessage);
                return ret;

            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return -1;
            }
        }

        public Dictionary<string,SystemParameter> GetSystemParameters(ref string errMessage)
        {
            Database db = DatabaseFactory.CreateDatabase();
            var list = new Dictionary<string, SystemParameter>();
            errMessage = "";
            try
            {
                DataSet ds = SystemParametersDataAccess.GetSystemParameters(db);

                SystemParameter systemParameter;
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    systemParameter = new SystemParameter(ds.Tables[0].Rows[i]);
                    list.Add(systemParameter.Name, systemParameter);
                }
                _listSystemParameter = list;
                return list;
            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                _listSystemParameter = null;
                return null;
            }
        }
    }
}
