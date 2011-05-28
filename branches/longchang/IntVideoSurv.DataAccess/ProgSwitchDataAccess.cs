using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using IntVideoSurv.Entity;

namespace IntVideoSurv.DataAccess
{
    public class ProgSwitchDataAccess
    {


        public static int GetMaxProgSwitchId(Database db)
        {
            string cmdText = "select max(Id) from ProgSwitch";
            try
            {
                return int.Parse(db.ExecuteScalar(CommandType.Text, cmdText).ToString());

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static int Insert(Database db, ProgSwitchInfo progSwitchInfo)
        {

            StringBuilder sbField = new StringBuilder();
            StringBuilder sbValue = new StringBuilder();
            sbField.Append("INSERT INTO ProgSwitch(");
            sbValue.Append("values(");
            sbField.Append("Name");
            sbValue.AppendFormat("'{0}'", progSwitchInfo.Name);
            sbField.Append(",Description");
            sbValue.AppendFormat(",'{0}'", progSwitchInfo.Description);
            sbField.Append(",DisplayChannelId");
            sbValue.AppendFormat(",{0}", progSwitchInfo.DisplayChannelId);
            sbField.Append(",DisplaySplitScreenNo)");
            sbValue.AppendFormat(",{0})", progSwitchInfo.DisplaySplitScreenNo);
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
        public static int Update(Database db, ProgSwitchInfo progSwitchInfo)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("update ProgSwitch set");
            sb.AppendFormat(" Name='{0}'", progSwitchInfo.Name);
            sb.AppendFormat(",Description='{0}'", progSwitchInfo.Description);
            sb.AppendFormat(",DisplaySplitScreenNo={0}", progSwitchInfo.DisplaySplitScreenNo);
            sb.AppendFormat(",DisplayChannelId={0} ", progSwitchInfo.DisplayChannelId);
            sb.AppendFormat(" where ID={0})", progSwitchInfo.Id);
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
            sb.Append("delete from ProgSwitch ");
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

        public static DataSet GetAllProgSwitchInfo(Database db)
        {
            string cmdText = string.Format("select ProgSwitch.id as Id,ProgSwitch.name as Name, "+
                "ProgSwitch.Description as Description, displayChannelInfo.DisplayChannelId as DisplayChannelId, " +
                "displayChannelInfo.DisplayChannelName as DisplayChannelName, "+
                "ProgSwitch.DisplaySplitScreenNo as DisplaySplitScreenNo, " + 
                "displayChannelInfo.DispalyChannelNoInCurrentCard as DispalyChannelNoInCurrentCard " +
                "from (ProgSwitch inner join displayChannelInfo on ProgSwitch.DisplayChannelId = displayChannelInfo.DisplayChannelId) order by ProgSwitch.id ");
            try
            {
                return db.ExecuteDataSet(CommandType.Text, cmdText);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public static DataSet GetProgSwitchById(Database db, int progSwitchId)
        {
            string cmdText = string.Format("select ProgSwitch.id as Id,ProgSwitch.name as Name, "+
                "ProgSwitch.Description as Description, displayChannelInfo.DisplayChannelId as DisplayChannelId, " +
                "displayChannelInfo.DisplayChannelName as DisplayChannelName, "+
                "ProgSwitch.DisplaySplitScreenNo as DisplaySplitScreenNo, " + 
                "displayChannelInfo.DispalyChannelNoInCurrentCard as DispalyChannelNoInCurrentCard  " +
                "from (ProgSwitch inner join displayChannelInfo on ProgSwitch.DisplayChannelId = displayChannelInfo.DisplayChannelId) where ProgSwitch.id={0} ", progSwitchId);
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
