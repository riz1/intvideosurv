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
            sbField.Append("INSERT INTO CameraGroup(");
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
                    strsql = "SELECT     ident_current('CameraGroup')";
                }
                else if (DataBaseParas.DBType == MyDBType.Oracle)
                {
                    strsql =
                    "select ID   from   CameraGroup   where  rowid=(select   max(rowid)   from   CameraGroup)";
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
            sb.Append("delete from CameraGroup ");
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
            string cmdText = string.Format("select CameraInfo.*,DeviceInfo.Name as DeviceName from CameraGroup,CameraInfo, DeviceInfo where CameraGroup.CameraID=CameraInfo.CameraId and CameraGroup.VirtualGroupID={0} and CameraInfo.deviceid =  DeviceInfo.deviceid", VirtualGroupId);
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
            string cmdText = string.Format("select TOG_DEVICE.* from CameraGroup,TOG_DEVICE where CameraGroup.CameraID=TOG_DEVICE.SBBH and CameraGroup.VirtualGroupID={0}", VirtualGroupId);
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
                sb.Append("delete from VirtualGroup ");
                sb.AppendFormat(" where VirtualGroupID={0}", GroupID);

            }
            else{
                sb.Append("delete from VirtualGroup ");
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
            sb.Append("delete from CameraGroup ");
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
            string cmdText = string.Format("select * from CameraGroup where CameraID={0} and VirtualGroupID={1}", CameraID, GroupID);
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
