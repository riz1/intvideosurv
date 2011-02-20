using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using IntVideoSurv.Entity;

namespace IntVideoSurv.DataAccess
{
    public class GroupDataAccess
    {


        public static int GetMaxGroupId(Database db)
        {
            string cmdText = "select max(GroupId) from GroupInfo";
            try
            {
                return int.Parse(db.ExecuteScalar(CommandType.Text, cmdText).ToString());

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static int Insert(Database db, GroupInfo oGroupInfo)
        {

            StringBuilder sbField = new StringBuilder();
            StringBuilder sbValue = new StringBuilder();
            sbField.Append("INSERT INTO GroupInfo(");
            sbValue.Append("values(");
            sbField.Append("Name");
            sbValue.AppendFormat("'{0}'", oGroupInfo.Name);
            sbField.Append(",Description");
            sbValue.AppendFormat(",'{0}'", oGroupInfo.Description);
            sbField.Append(",ParentId");
            sbValue.AppendFormat(",{0}", oGroupInfo.ParentId);
            sbField.Append(",AddBy");
            sbValue.AppendFormat(",'{0}'", oGroupInfo.AddBy);
            sbField.Append(",AddTime)");
            sbValue.AppendFormat(",'{0}')", oGroupInfo.AddTime);
            string cmdText = sbField.ToString() + " " + sbValue.ToString() + "";
            try
            {
                return db.ExecuteNonQuery(CommandType.Text, cmdText);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public static int Update(Database db, GroupInfo oGroupInfo)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("update GroupInfo set");
            sb.AppendFormat(" Name='{0}'", oGroupInfo.Name);
            sb.AppendFormat(",Description='{0}'", oGroupInfo.Description);
            sb.AppendFormat(",ParentId={0}", oGroupInfo.ParentId);
            sb.AppendFormat(",ModifyBy='{0}'", oGroupInfo.AddBy);
            sb.AppendFormat(",ModifyTime='{0}'", oGroupInfo.AddTime ?? DateTime.Now.ToString());
            sb.AppendFormat(" where GroupID={0}", oGroupInfo.GroupID);
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
        public static int Delete(Database db, int groupId)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("delete from GroupInfo ");
            sb.AppendFormat(" where GroupId={0}", groupId);
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

        public static DataSet GetAllGroupInfo(Database db)
        {
            string cmdText = string.Format("select * from GroupInfo order by ParentId");
            try
            {
                return db.ExecuteDataSet(CommandType.Text, cmdText);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public static DataSet GetGroupInfoByGroupId(Database db, int groupId)
        {
            string cmdText = string.Format("select * from GroupInfo where GroupId={0} ", groupId);
            try
            {
                return db.ExecuteDataSet(CommandType.Text, cmdText);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static DataSet GetGroupInfoByGroupName(Database db, string groupName)
        {
            string cmdText = string.Format("select * from GroupInfo where Name='{0}' ", groupName);
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
