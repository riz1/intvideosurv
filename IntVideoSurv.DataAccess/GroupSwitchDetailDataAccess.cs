using System;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using IntVideoSurv.Entity;

namespace IntVideoSurv.DataAccess
{
    public class GroupSwitchDetailDataAccess
    {
        public static DataSet GetGroupSwitchDetailByGroupSwitchId(Database db, int groupSwitchId)
        {
            string cmdText = string.Format("select GroupSwitchDetail.Id as Id,SynGroup.SynGroupId as SynGroupId,SynGroup.Name as SynGroupName, " +
                "GroupSwitchDetail.TickTime as TickTime, GroupSwitchDetail.GroupSwitchGroupId as GroupSwitchGroupId "+
                " from " +
                "(GroupSwitchDetail inner join SynGroup on GroupSwitchDetail.SynGroupId=SynGroup.SynGroupId) "+
                "where GroupSwitchDetail.GroupSwitchGroupId={0} order by GroupSwitchDetail.Id", groupSwitchId);
            try
            {
                return db.ExecuteDataSet(CommandType.Text, cmdText);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static DataSet GetGroupSwitchDetailByGroupSwitchDetailId(Database db, int groupSwitchDetailId)
        {
            string cmdText = string.Format("select GroupSwitchDetail.Id as Id,SynGroup.SynGroupId as SynGroupId,SynGroup.Name as SynGroupName, " +
                "GroupSwitchDetail.TickTime as TickTime, GroupSwitchDetail.GroupSwitchGroupId as GroupSwitchGroupId " +
                " from " +
                "(GroupSwitchDetail inner join SynGroup on GroupSwitchDetail.SynGroupId=SynGroup.SynGroupId) " +
                "where GroupSwitchDetail.Id={0} order by GroupSwitchDetail.Id", groupSwitchDetailId);
            try
            {
                return db.ExecuteDataSet(CommandType.Text, cmdText);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static DataSet GetGroupSwitchDetailChineseTitleByGroupSwitchId(Database db, int groupSwitchId)
        {
            string cmdText = string.Format("select GroupSwitchDetail.Id as 索引号, GroupSwitchGroup.Name as 群组切换名,SynGroup.Name as 同步群组名," +
                "GroupSwitchDetail.TickTime as 时间间隔" +
                "" +
                " from " +
                "((GroupSwitchDetail inner join SynGroup on GroupSwitchDetail.SynGroupId=SynGroup.SynGroupId) inner join  GroupSwitchGroup on GroupSwitchGroup.Id=GroupSwitchDetail.GroupSwitchGroupId) " +
                "where GroupSwitchDetail.GroupSwitchGroupId={0} order by GroupSwitchDetail.Id", groupSwitchId);
            try
            {
                return db.ExecuteDataSet(CommandType.Text, cmdText);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public static DataSet GetAllGroupSwitchDetailInfos(Database db)
        {
            string cmdText = string.Format("select GroupSwitchDetail.Id as 索引号, GroupSwitchGroup.Name as 群组切换名,SynGroup.Name as 同步群组名," +
                "GroupSwitchDetail.TickTime as 时间间隔" +
                "" +
                " from " +
                "((GroupSwitchDetail inner join SynGroup on GroupSwitchDetail.SynGroupId=SynGroup.SynGroupId) inner join  GroupSwitchGroup on GroupSwitchGroup.Id=GroupSwitchDetail.GroupSwitchGroupId) " +
                " order by GroupSwitchDetail.Id");
            try
            {
                return db.ExecuteDataSet(CommandType.Text, cmdText);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static int Delete(Database db, int id)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("delete from GroupSwitchDetail ");
            sb.AppendFormat(" where Id={0}", id);
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
        public static DataSet GetGroupSwitchDetailById(Database db, int id)
        {
            string cmdText = string.Format("select * from GroupSwitchDetail  where GroupSwitchGroupId={0}", id);
            try
            {
                return db.ExecuteDataSet(CommandType.Text, cmdText);
       
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int Insert(Database db, int groupSwitchid, int synGroupId, int tickTime)
        {
            if (IsExisted(db, groupSwitchid, synGroupId))
            {
                return int.MinValue;
            }

            StringBuilder sbField = new StringBuilder();
            StringBuilder sbValue = new StringBuilder();
            sbField.Append("INSERT INTO  GroupSwitchDetail(");
            sbValue.Append("values (");
            sbField.Append("GroupSwitchGroupId");
            sbValue.AppendFormat("{0}", groupSwitchid);
            sbField.Append(",SynGroupId");
            sbValue.AppendFormat(",{0}", synGroupId);
            sbField.Append(",TickTime)");
            sbValue.AppendFormat(",{0})", tickTime);

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

        public static int UpdateTickTimeById(Database db, int id, int tickTime)
        {

            string cmdText = string.Format("update GroupSwitchDetail set TickTime={0} where Id = {1}", tickTime, id);


            try
            {

                return db.ExecuteNonQuery(CommandType.Text, cmdText);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public static bool IsExisted(Database db, int groupSwitchid, int synGroupId)
        {
            String strSqlExisted =
                String.Format("select count(*) from GroupSwitchDetail where GroupSwitchGroupId={0} and SynGroupId={1}",
                              groupSwitchid, synGroupId);
            try
            {

                return int.Parse(db.ExecuteScalar(CommandType.Text, strSqlExisted).ToString()) > 0 ? true : false;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
