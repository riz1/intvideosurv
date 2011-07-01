using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using IntVideoSurv.Entity;
using Microsoft.Practices.EnterpriseLibrary.Data;
namespace IntVideoSurv.DataAccess
{
    public class CameraGroupDataAccess
    {
        public static int Insert(Database db, CameraGroupInfo oCameraGroup)
        {
            StringBuilder sbField = new StringBuilder();
            StringBuilder sbValue = new StringBuilder();
            sbField.Append("INSERT INTO IVS_CameraGroup(");
            sbValue.Append("values (");
           // sbField.Append("[ID]");
            //sbValue.AppendFormat("{0}", oCameraGroup.ID);
            sbField.Append("VirtualGroupID,");
            sbValue.AppendFormat("{0},", oCameraGroup.GroupID);
            sbField.Append("CameraID)");
            sbValue.AppendFormat("{0})", oCameraGroup.CameraID);
            string cmdText = sbField.ToString() + " " + sbValue.ToString();

            try
            {
                cmdText = cmdText.Replace("\r\n", "");
                db.ExecuteNonQuery(CommandType.Text, cmdText);
                string strsql = "";

                if (DataBaseParas.DBType == MyDBType.SqlServer)
                {
                    strsql = "SELECT     ident_current('IVS_CameraGroup')";
                }
                else if (DataBaseParas.DBType == MyDBType.Oracle)
                {
                    strsql =
                    "select ID   from   IVS_CameraGroup   where  rowid=(select   max(rowid)   from   IVS_CameraGroup)";
                }
                int id = int.Parse(db.ExecuteScalar(CommandType.Text, strsql).ToString());
                return id;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public static int DeleteByVirtualGroupID(Database db, int GroupID)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("delete from IVS_CameraGroup ");
            sb.AppendFormat(" where VirtualGroupID={0}", GroupID);
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
        public static DataSet GetAllCameraInfo(Database db,int VirtualGroupId)
        {
            string cmdText = string.Format("select IVS_CameraInfo.*,IVS_DeviceInfo.Name as DeviceName from IVS_CameraGroup,IVS_CameraInfo, IVS_DeviceInfo where IVS_CameraGroup.CameraID=IVS_CameraInfo.CameraId and IVS_CameraGroup.VirtualGroupID={0} and IVS_CameraInfo.deviceid =  IVS_DeviceInfo.deviceid", VirtualGroupId);
            try
            {
                return db.ExecuteDataSet(CommandType.Text, cmdText);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public static DataSet GetAllLongChangCameraInfo(Database db, int VirtualGroupId)
        {
            string cmdText = string.Format("select TOG_DEVICE.* from IVS_CameraGroup,TOG_DEVICE where IVS_CameraGroup.CameraID=TOG_DEVICE.SBBH and IVS_CameraGroup.VirtualGroupID={0}", VirtualGroupId);
            try
            {
                return db.ExecuteDataSet(CommandType.Text, cmdText);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public static int DeleteByGroupIDandCamID(Database db, int GroupID,int CameraID)
        {
            StringBuilder sb = new StringBuilder();
            //删除整个组
            if(CameraID==-1)
            {
                sb.Append("delete from IVS_VirtualGroup ");
                sb.AppendFormat(" where VirtualGroupID={0}", GroupID);

            }
            else{
                sb.Append("delete from IVS_VirtualGroup ");
                sb.AppendFormat(" where VirtualGroupID={0} and CameraID={1}", GroupID, CameraID);
            }

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
        public static int DeleteByCamID(Database db, int CameraID)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("delete from IVS_CameraGroup ");
            sb.AppendFormat(" where  CameraID={0}", CameraID);


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
        public static DataSet GetCamInfoByID(Database db, int CameraID, int GroupID)
        {
            string cmdText = string.Format("select * from IVS_CameraGroup where CameraID={0} and VirtualGroupID={1}", CameraID, GroupID);
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
