using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using IntVideoSurv.Entity;

namespace IntVideoSurv.DataAccess
{
    public class DisplayChannelDataAccess
    {


        public static int GetMaxDisplayChannelId(Database db)
        {
            string cmdText = "select max(DisplayChannelId) from IVS_displayChannelInfo";
            try
            {
                return int.Parse(db.ExecuteScalar(CommandType.Text, cmdText).ToString());

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static int Insert(Database db, DisplayChannelInfo displayChannelInfo)
        {

            StringBuilder sbField = new StringBuilder();
            StringBuilder sbValue = new StringBuilder();
            sbField.Append("INSERT INTO IVS_displayChannelInfo(");
            sbValue.Append("values(");
            sbField.Append("DisplayChannelName,");
            sbValue.AppendFormat("'{0}',", displayChannelInfo.DisplayChannelName);
            sbField.Append("DecodeCardNo,");
            sbValue.AppendFormat("{0},", displayChannelInfo.DecodeCardNo);
            sbField.Append("DispalyChannelNoInCurrentCard,");
            sbValue.AppendFormat("{0},", displayChannelInfo.DispalyChannelNoInCurrentCard);
            sbField.Append("SplitScreenNo) ");
            sbValue.AppendFormat("{0})", displayChannelInfo.SplitScreenNo);
    
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
        public static int Update(Database db, DisplayChannelInfo displayChannelInfo)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("update IVS_displayChannelInfo set");
            sb.AppendFormat(" DisplayChannelName='{0}'", displayChannelInfo.DisplayChannelName);
            sb.AppendFormat(" where DisplayChannelId={0})", displayChannelInfo.DisplayChannelId);
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

        public static int UpdateSplitScreenById(Database db, int id, int splitScreenNo)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("update IVS_displayChannelInfo set");
            sb.AppendFormat(" SplitScreenNo={0}", splitScreenNo);
            sb.AppendFormat(" where DisplayChannelId={0}", id);
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
        public static int Delete(Database db, int displayChannelId)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("delete from displayChannelInfo ");
            sb.AppendFormat(" where DisplayChannelId={0}", displayChannelId);
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

        public static DataSet GetAllDisplayChannelInfos(Database db)
        {
            string cmdText = string.Format("select * from IVS_displayChannelInfo order by DecodeCardNo, DisplayChannelId");
            try
            {
                return db.ExecuteDataSet(CommandType.Text, cmdText);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static DataSet GetDisplayChannelInfoById(Database db,int displayChannelId)
        {
            string cmdText = string.Format("select * from IVS_displayChannelInfo where DisplayChannelId={0}", displayChannelId);
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
