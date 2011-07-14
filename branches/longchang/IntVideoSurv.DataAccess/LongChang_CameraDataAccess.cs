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
            string cmdText = string.Format("select * from TOG_DEVICE where (TOG_DEVICE.sblx = 1 or TOG_DEVICE.sblx = 2) order by sbbh");
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
            string cmdText = string.Format("select TOG_DEVICE.* from TOG_DEVICE where sbbh = {0}", cameraId);
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
            string cmdText = string.Format("select distinct * from TOG_DEVICE where sblx = {0}", type);
            try
            {
                return db.ExecuteDataSet(CommandType.Text, cmdText);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public static int Delete(Database db, int CameraId)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("delete from TOG_DEVICE ");
            sb.AppendFormat(" where SBBH={0}", CameraId);
            string cmdText = sb.ToString();
            try
            {
                return db.ExecuteNonQuery(CommandType.Text, cmdText);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public static DataSet GetCamInfoByDeviceUserId(Database db,int userId)
        {
            string cmdText = string.Format("select distinct TOG_DEVICE.* " +
                " from TOG_DEVICE,IVS_usergroup,IVS_CameraGroup "+
                " where IVS_usergroup.userid={0} and IVS_usergroup.virtualgroupid = IVS_CameraGroup.virtualgroupid "+
                " and IVS_CameraGroup.cameraid=TOG_DEVICE.sbbh and (TOG_DEVICE.sblx = 1 or TOG_DEVICE.sblx = 2)", userId);
            try
            {
                return db.ExecuteDataSet(CommandType.Text, cmdText);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public static string Insert(Database db, LongChang_CameraInfo oCameraInfo)
        {

            StringBuilder sbField = new StringBuilder();
            StringBuilder sbValue = new StringBuilder();
            sbField.Append("INSERT INTO  TOG_DEVICE(");
            sbValue.Append("values (");

            sbField.Append("tdid");
            sbValue.AppendFormat("'{0}'", Guid.NewGuid().ToString("N"));
            sbField.Append(",sbbh");
            sbValue.AppendFormat(",'{0}'", oCameraInfo.CameraId.ToString());
            sbField.Append(",sbmc");
            sbValue.AppendFormat(",'{0}'", oCameraInfo.Name);
            sbField.Append(",sbip");
            sbValue.AppendFormat(",'{0}'", oCameraInfo.IP);
            sbField.Append(",dkh");
            sbValue.AppendFormat(",'{0}'", oCameraInfo.Port.ToString());
            sbField.Append(",dlyh");
            sbValue.AppendFormat(",'{0}'", oCameraInfo.UserName);
            sbField.Append(",dlmm");
            sbValue.AppendFormat(",'{0}'", oCameraInfo.PassWord);
            sbField.Append(",kkmc");
            sbValue.AppendFormat(",'{0}'", oCameraInfo.TollGateName);
            sbField.Append(",sblx)");
            sbValue.AppendFormat(",'{0}')", oCameraInfo.Type.ToString());
           
            string cmdText = sbField.ToString() + " " + sbValue.ToString();
            string strsql;

            try
            {
                cmdText = cmdText.Replace("\r\n", "");
                db.ExecuteNonQuery(CommandType.Text, cmdText);

                strsql = "select tdid   from   TOG_DEVICE   where  tdid=(select   max(tdid)   from   TOG_DEVICE)";

                string id = db.ExecuteScalar(CommandType.Text, strsql).ToString();
                return id;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
