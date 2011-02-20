using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using IntVideoSurv.Entity;

namespace IntVideoSurv.DataAccess
{
    public class GroupSwitchGroupDataAccess
    {


        public static int GetMaxGroupSwitchGroupId(Database db)
        {
            string cmdText = "select max(Id) from GroupSwitchGroup";
            try
            {
                return int.Parse(db.ExecuteScalar(CommandType.Text, cmdText).ToString());

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static int Insert(Database db, GroupSwitchGroup oGroupInfo)
        {

            StringBuilder sbField = new StringBuilder();
            StringBuilder sbValue = new StringBuilder();
            sbField.Append("INSERT INTO GroupSwitchGroup(");
            sbValue.Append("values(");
            sbField.Append("Name");
            sbValue.AppendFormat("'{0}'", oGroupInfo.Name);
            sbField.Append(",Description)");
            sbValue.AppendFormat(",'{0}')", oGroupInfo.Description);
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
        public static int Update(Database db, GroupSwitchGroup oGroupInfo)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("update GroupSwitchGroup set");
            sb.AppendFormat(" Name='{0}'", oGroupInfo.Name);
            sb.AppendFormat(",Description='{0}'", oGroupInfo.Description);
            sb.AppendFormat(" where ID={0})", oGroupInfo.Id);
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
            sb.Append("delete from GroupSwitchGroup ");
            sb.AppendFormat(" where ID={0}", groupId);
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

        public static DataSet GetAllGroupSwitchGroupInfo(Database db)
        {
            string cmdText = string.Format("select * from GroupSwitchGroup order by Id");
            try
            {
                return db.ExecuteDataSet(CommandType.Text, cmdText);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public static DataSet GetGroupSwitchGroupById(Database db, int groupId)
        {
            string cmdText = string.Format("select * from GroupSwitchGroup where Id={0} ", groupId);
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
