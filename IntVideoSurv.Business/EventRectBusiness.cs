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
    public class EventRectBusiness
    {
        public static readonly ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private static EventRectBusiness instance;
        public static EventRectBusiness Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new EventRectBusiness();
                }
                return instance;
            }
        }
        public int Insert(ref string errMessage, EventRect oEventRect)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            try
            {
                return EventRectDataAccess.Insert(db, oEventRect);

            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return -1;
            }
        }
    }
}
