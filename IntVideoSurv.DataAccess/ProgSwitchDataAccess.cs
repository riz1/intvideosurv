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
            string cmdText = "select max(Id) from IVS_ProgSwitch";
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
            sbField.Append("INSERT INTO IVS_ProgSwitch(");
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
            sb.Append("update IVS_ProgSwitch set");
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
            sb.Append("delete from IVS_ProgSwitch ");
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
            string cmdText = string.Format("select IVS_ProgSwitch.id as Id,IVS_ProgSwitch.name as Name, "+
                "IVS_ProgSwitch.Description as Description, IVS_displayChannelInfo.DisplayChannelId as DisplayChannelId, " +
                "IVS_displayChannelInfo.DisplayChannelName as DisplayChannelName, "+
                "IVS_ProgSwitch.DisplaySplitScreenNo as DisplaySplitScreenNo, " + 
                "IVS_displayChannelInfo.DispalyChannelNoInCurrentCard as DispalyChannelNoInCurrentCard " +
                "from (IVS_ProgSwitch inner join IVS_displayChannelInfo on IVS_ProgSwitch.DisplayChannelId = IVS_displayChannelInfo.DisplayChannelId) order by IVS_ProgSwitch.id ");
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
            string cmdText = string.Format("select IVS_ProgSwitch.id as Id,IVS_ProgSwitch.name as Name, "+
                "IVS_ProgSwitch.Description as Description, IVS_displayChannelInfo.DisplayChannelId as DisplayChannelId, " +
                "IVS_displayChannelInfo.DisplayChannelName as DisplayChannelName, "+
                "IVS_ProgSwitch.DisplaySplitScreenNo as DisplaySplitScreenNo, " + 
                "IVS_displayChannelInfo.DispalyChannelNoInCurrentCard as DispalyChannelNoInCurrentCard  " +
                "from (IVS_ProgSwitch inner join IVS_displayChannelInfo on IVS_ProgSwitch.DisplayChannelId = IVS_displayChannelInfo.DisplayChannelId) where IVS_ProgSwitch.id={0} ", progSwitchId);
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
