using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using IntVideoSurv.Entity;

namespace IntVideoSurv.DataAccess
{
    public class DefaultCardOutDataAccess
    {


        public static int Insert(Database db, DefaultCardOut defaultCardOut)
        {

            StringBuilder sbField = new StringBuilder();
            StringBuilder sbValue = new StringBuilder();
            sbField.Append("INSERT INTO DefaultCardOut(");
            sbValue.Append("values(");
            sbField.Append("CameraId,");
            sbValue.AppendFormat("{0},", defaultCardOut.CameraId);
            sbField.Append("DisplayChannelId,");
            sbValue.AppendFormat("{0},", defaultCardOut.DisplayChannelId);
            sbField.Append("DispalySplitScreenNo)");
            sbValue.AppendFormat("{0})", defaultCardOut.DisplaySplitScreenNo);

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
        public static int Update(Database db, DefaultCardOut defaultCardOut)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("update DefaultCardOut set");
            sb.AppendFormat(" cameraid={0},", defaultCardOut.CameraId);
            sb.AppendFormat(" DisplayChannelId={0},", defaultCardOut.DisplayChannelId);
            sb.AppendFormat(" DisplaySplitScreenNo={0},", defaultCardOut.DisplaySplitScreenNo);
            sb.AppendFormat(" where Id={0})", defaultCardOut.Id);
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
        public static int Delete(Database db, int defaultCardOutId)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("delete from DefaultCardOut ");
            sb.AppendFormat(" where id={0}", defaultCardOutId);
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

        public static DataSet GetAllDefaultCardOuts(Database db)
        {
            string cmdText = string.Format(
                "select DefaultCardOut.Id as Id, DefaultCardOut.CameraId as CameraId, "+
                "DefaultCardOut.DisplayChannelId as DisplayChannelId, DefaultCardOut.DisplaySplitScreenNo as DisplaySplitScreenNo, " +
                "DisplayChannelInfo.DisplayChannelName as DisplayChannelName, " +
                "DisplayChannelInfo.DecodeCardNo as DecodeCardNo, " +
                "DisplayChannelInfo.DispalyChannelNoInCurrentCard as DispalyChannelNoInCurrentCard, " +
                "DisplayChannelInfo.SplitScreenNo as SplitScreenNo " +
                "from ( DefaultCardOut inner join displayChannelInfo on DisplayChannelInfo.DisplayChannelId = DefaultCardOut.DisplayChannelId )"+
                "order by DefaultCardOut.DisplayChannelId,DefaultCardOut.DisplaySplitScreenNo");
            try
            {
                return db.ExecuteDataSet(CommandType.Text, cmdText);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static DataSet GetDefaultCardOutById(Database db, int defaultCardOutId)
        {
            string cmdText = string.Format(
                "select DefaultCardOut.Id as Id, DefaultCardOut.CameraId as CameraId, " +
                "DefaultCardOut.DisplayChannelId as DisplayChannelId, DefaultCardOut.DisplaySplitScreenNo as DisplaySplitScreenNo, " +
                "DisplayChannelInfo.DisplayChannelName as DisplayChannelName, " +
                "DisplayChannelInfo.DecodeCardNo as DecodeCardNo, " +
                "DisplayChannelInfo.DispalyChannelNoInCurrentCard as DispalyChannelNoInCurrentCard, " +
                "DisplayChannelInfo.SplitScreenNo as SplitScreenNo " +
                "from ( DefaultCardOut inner join displayChannelInfo on DisplayChannelInfo.DisplayChannelId = DefaultCardOut.DisplayChannelId )" +
                "where DefaultCardOut.id={0} " +
                "order by DefaultCardOut.DisplayChannelId,DefaultCardOut.DisplaySplitScreenNo", defaultCardOutId); 
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
