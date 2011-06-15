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
            sbField.Append("INSERT INTO  [CameraGroup](");
            sbValue.Append("values (");
           // sbField.Append("[ID]");
            //sbValue.AppendFormat("{0}", oCameraGroup.ID);
            sbField.Append("[VirtualGroupID],");
            sbValue.AppendFormat("{0},", oCameraGroup.GroupID);
            sbField.Append("[CameraID])");
            sbValue.AppendFormat("{0})", oCameraGroup.CameraID);
            string cmdText = sbField.ToString() + " " + sbValue.ToString();

            try
            {
                cmdText = cmdText.Replace("\r\n", "");
                db.ExecuteNonQuery(CommandType.Text, cmdText);
                int id = int.Parse(db.ExecuteScalar(CommandType.Text, "SELECT     ident_current('CameraGroup')").ToString());
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
            string cmdText = string.Format("select b.* from CameraGroup a,CameraInfo b where a.CameraID=b.CameraId and a.VirtualGroupID={0}", VirtualGroupId);
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
                sb.AppendFormat(" where VirtualGroupID={0} and CameraID={0}", GroupID, CameraID);
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

    }
}
