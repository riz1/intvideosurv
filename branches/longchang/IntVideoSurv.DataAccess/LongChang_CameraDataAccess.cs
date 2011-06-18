using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using IntVideoSurv.Entity;

namespace IntVideoSurv.DataAccess
{
    public class LongChang_CameraDataAccess
    {
        public static DataSet GetAllCamInfo(Database db)
        {
            string cmdText = string.Format("select * from TOG_DEVICE order by sbbh");
            try
            {
                return db.ExecuteDataSet(CommandType.Text, cmdText);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public static DataSet GetCamInfoByCameraId(Database db, int cameraId)
        {
            string cmdText = string.Format("select * from TOG_DEVICE where sbbh = {0}", cameraId);
            try
            {
                return db.ExecuteDataSet(CommandType.Text, cmdText);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static DataSet GetCamInfoByDeviceType(Database db, int type)
        {
            string cmdText = string.Format("select * from TOG_DEVICE where sblx = {0}", type);
            try
            {
                return db.ExecuteDataSet(CommandType.Text, cmdText);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static DataSet GetCamInfoByDeviceUserIdAndType(Database db,int userId, int type)
        {
            string cmdText = string.Format("select TOG_DEVICE.* "+
                " from TOG_DEVICE,usergroup,cameragroup "+
                " where usergroup.userid={0} and usergroup.virtualgroupid = cameragroup.virtualgroupid "+
                " and cameragroup.cameraid=TOG_DEVICE.sbbh and TOG_DEVICE.sblx = {1}", userId, type);
            try
            {
                return db.ExecuteDataSet(CommandType.Text, cmdText);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
