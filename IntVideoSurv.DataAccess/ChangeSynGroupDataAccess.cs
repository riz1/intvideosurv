using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using DigtiMatrix.Entity;

namespace DigitMatrix.DataAccess
{
    public class ChangeSynGroupDataAccess
    {


        public static int GetMaxChangeSynGroupId(Database db)
        {
            string cmdText = "select max(ChangeSynGroupId) from ChangeSynGroup";
            try
            {
                return int.Parse(db.ExecuteScalar(CommandType.Text, cmdText).ToString());

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static int Insert(Database db, ChangeSynGroup oGroupInfo)
        {

            StringBuilder sbField = new StringBuilder();
            StringBuilder sbValue = new StringBuilder();
            sbField.Append("INSERT INTO ChangeSynGroup(");
            sbValue.Append("values(");
            sbField.Append("Name");
            sbValue.AppendFormat("'{0}'", oGroupInfo.Name);
            sbField.Append(",Description");
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
        public static int Update(Database db, ChangeSynGroup oGroupInfo)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("update ChangeSynGroup set");
            sb.AppendFormat(" Name='{0}'", oGroupInfo.Name);
            sb.AppendFormat(",Description='{0}'", oGroupInfo.Description);
            sb.AppendFormat(" where GroupID={0})", oGroupInfo.ChangeSynGroupId);
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
            sb.Append("delete from ChangeSynGroup ");
            sb.AppendFormat(" where ChangeSynGroupID={0}", groupId);
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

        public static DataSet GetAllChangeSynGroupInfo(Database db)
        {
            string cmdText = string.Format("select * from ChangeSynGroup order by ChangeSynGroupId");
            try
            {
                return db.ExecuteDataSet(CommandType.Text, cmdText);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public static DataSet GetChangeSynGroupById(Database db, int groupId)
        {
            string cmdText = string.Format("select * from ChangeSynGroup where ChangeSynGroupId={0} ", groupId);
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
