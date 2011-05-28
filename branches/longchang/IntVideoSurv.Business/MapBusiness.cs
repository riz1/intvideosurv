using System;
using System.Collections.Generic;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using IntVideoSurv.Entity;
using IntVideoSurv.DataAccess;
using log4net;

namespace IntVideoSurv.Business
{
    public class MapBusiness
    {
        public static readonly ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private static MapBusiness instance;
        public static MapBusiness Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MapBusiness();
                }
                return instance;
            }
        }

        public int Insert(ref string errMessage, MapInfo mapInfo)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            try
            {
                return MapDataAccess.Insert(db, mapInfo);

            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return -1;
            }
        }

        public int Update(ref string errMessage, MapInfo mapInfo)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            try
            {
                return MapDataAccess.Update(db, mapInfo);

            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return -1;
            }


        }
        public int Delete(ref string errMessage, int mapId)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            try
            {
                int iRtn = MapDataAccess.Delete(db, mapId);
                return iRtn;
            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return -1;
            }

        }

        public Dictionary<int, MapInfo> GetAllMapInfo(ref string errMessage)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            Dictionary<int, MapInfo> list = new Dictionary<int, MapInfo>();
            try
            {
                MapInfo mapInfo;
                DataSet ds = MapDataAccess.GetAllMapInfo(db);
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    mapInfo = new MapInfo(ds.Tables[0].Rows[i]);
                    list.Add(mapInfo.Id, mapInfo);
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

