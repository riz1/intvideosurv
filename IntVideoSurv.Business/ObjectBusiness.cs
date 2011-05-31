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
using videosource;
using System.Drawing;

namespace IntVideoSurv.Business
{
    public class ObjectBusiness
    {
        public static readonly ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private static ObjectBusiness instance;
        public static ObjectBusiness Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ObjectBusiness();
                }
                return instance;
            }
        }
        public int Insert(ref string errMessage, ObjectInfo oObject)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            try
            {
                return ObjectDataAccess.Insert(db, oObject);

            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return -1;
            }
        }

        public Dictionary<int, ObjectInfo> GetEventRectCustom(ref string errMessage, int eventid)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            Dictionary<int, ObjectInfo> list = new Dictionary<int, ObjectInfo>();
            try
            {
                DataSet ds = ObjectDataAccess.GetObjectCustom(db, eventid);
                ObjectInfo obj;
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    obj = new ObjectInfo(ds.Tables[0].Rows[i]);
                    list.Add(obj.ObjectId, obj);
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