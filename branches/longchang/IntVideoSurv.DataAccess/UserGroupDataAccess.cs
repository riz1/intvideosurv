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

        public static int Insert(Database db, UserGroupInfo oUserGroup)
        {
            StringBuilder sbField = new StringBuilder();
            StringBuilder sbValue = new StringBuilder();
            sbField.Append("INSERT INTO UserGroup(");
            sbValue.Append("values(");
            sbField.Append("VirtualGroupID");
            sbValue.AppendFormat("{0}", oUserGroup.VirtualGroupID);
            sbField.Append(",Description");
            sbValue.AppendFormat(",{0}", oUserGroup.UserID);
            string cmdText = sbField + " " + sbValue;
            try
            {
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
            sb.Append("update UserGroup set");
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

        public static int Delete(Database db, int ID)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("delete from UserGroup ");
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

    }
}
