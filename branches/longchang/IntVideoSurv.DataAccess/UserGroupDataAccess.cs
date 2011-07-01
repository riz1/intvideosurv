using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using IntVideoSurv.Entity;

namespace IntVideoSurv.DataAccess
{
    public class UserGroupDataAccess
    {
        public static int InsertUser(Database db, int userid, int groupid)
        {
            StringBuilder sbField = new StringBuilder();
            StringBuilder sbValue = new StringBuilder();
            sbField.Append("INSERT INTO  IVS_usergroup(");
            sbValue.Append("values (");
            //sbField.Append("id");
            //sbValue.AppendFormat("{0}", id);
            sbField.Append("UserID");
            sbValue.AppendFormat("{0}", userid);
            sbField.Append(",VirtualGroupID)");
            sbValue.AppendFormat(",{0})", groupid);

            string cmdText = sbField.ToString() + " " + sbValue.ToString();


            try
            {
                cmdText = cmdText.Replace("\r\n", "");
                return db.ExecuteNonQuery(CommandType.Text, cmdText);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public static int Insert(Database db, UserGroupInfo oUserGroup)
        {
            StringBuilder sbField = new StringBuilder();
            StringBuilder sbValue = new StringBuilder();
            sbField.Append("INSERT INTO IVS_usergroup(");
            sbValue.Append("values (");
            sbField.Append("VirtualGroupID");
            sbValue.AppendFormat("{0}", oUserGroup.VirtualGroupID);
            sbField.Append(",UserID)");
            sbValue.AppendFormat(",{0})", oUserGroup.UserID);
            string cmdText = sbField.ToString() + " " + sbValue.ToString();
            try
            {
                cmdText = cmdText.Replace("\r\n", "");
                return db.ExecuteNonQuery(CommandType.Text, cmdText);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static int Update(Database db, UserGroupInfo oUserGroup)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("update IVS_usergroup set");
            sb.AppendFormat("VirtualGroupID={0} ", oUserGroup.VirtualGroupID);
            sb.AppendFormat(",UserID={0} ", oUserGroup.UserID);
            sb.AppendFormat(" where ID={0})", oUserGroup.ID);
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
        public static int DeleteUser(Database db, int userid)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("delete from IVS_usergroup ");
            sb.AppendFormat(" where UserID={0}", userid);
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
        public static int Delete(Database db, int ID)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("delete from IVS_usergroup ");
            sb.AppendFormat(" where ID={0}", ID);
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
        public static int DeleteByVirtualGroupID(Database db, int ID)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("delete from IVS_usergroup ");
            sb.AppendFormat(" where VirtualGroupID={0}", ID);
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
        public static DataSet GetAllCameraInfo(Database db, int VirtualGroupId)
        {
            string cmdText = string.Format("select b.* from IVS_usergroup a,IVS_UserInfo b where a.UserID=b.userid and a.VirtualGroupID={0}", VirtualGroupId);
            try
            {
                return db.ExecuteDataSet(CommandType.Text, cmdText);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public static DataSet GetTheUser(Database db, int userid)
        {
            string cmdText = string.Format("select * from IVS_usergroup where UserID={0}", userid);
            try
            {
                return db.ExecuteDataSet(CommandType.Text, cmdText);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public static DataSet GetCameraInfoByUserId(Database db, int userid)
        {
            string cmdText = string.Format("select * from IVS_CameraInfo where CameraId in (select CameraID from IVS_CameraGroup where VirtualGroupID in (select VirtualGroupID from IVS_usergroup where UserID={0}))", userid);
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
