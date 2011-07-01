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
            sbField.Append("INSERT INTO IVS_DefaultCardOut(");
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
            sb.Append("update IVS_DefaultCardOut set");
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
            sb.Append("delete from IVS_DefaultCardOut ");
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
                "select IVS_DefaultCardOut.Id as Id, IVS_DefaultCardOut.CameraId as CameraId, "+
                "IVS_DefaultCardOut.DisplayChannelId as DisplayChannelId, IVS_DefaultCardOut.DisplaySplitScreenNo as DisplaySplitScreenNo, " +
                "IVS_displayChannelInfo.DisplayChannelName as DisplayChannelName, " +
                "IVS_displayChannelInfo.DecodeCardNo as DecodeCardNo, " +
                "IVS_displayChannelInfo.DispalyChannelNoInCurrentCard as DispalyChannelNoInCurrentCard, " +
                "IVS_displayChannelInfo.SplitScreenNo as SplitScreenNo " +
                "from ( IVS_DefaultCardOut inner join IVS_displayChannelInfo on IVS_displayChannelInfo.DisplayChannelId = IVS_DefaultCardOut.DisplayChannelId )"+
                "order by IVS_DefaultCardOut.DisplayChannelId,IVS_DefaultCardOut.DisplaySplitScreenNo");
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
                "select IVS_DefaultCardOut.Id as Id, IVS_DefaultCardOut.CameraId as CameraId, " +
                "IVS_DefaultCardOut.DisplayChannelId as DisplayChannelId, IVS_DefaultCardOut.DisplaySplitScreenNo as DisplaySplitScreenNo, " +
                "IVS_displayChannelInfo.DisplayChannelName as DisplayChannelName, " +
                "IVS_displayChannelInfo.DecodeCardNo as DecodeCardNo, " +
                "IVS_displayChannelInfo.DispalyChannelNoInCurrentCard as DispalyChannelNoInCurrentCard, " +
                "IVS_displayChannelInfo.SplitScreenNo as SplitScreenNo " +
                "from ( IVS_DefaultCardOut inner join IVS_displayChannelInfo on IVS_displayChannelInfo.DisplayChannelId = IVS_DefaultCardOut.DisplayChannelId )" +
                "where IVS_DefaultCardOut.id={0} " +
                "order by IVS_DefaultCardOut.DisplayChannelId,IVS_DefaultCardOut.DisplaySplitScreenNo", defaultCardOutId); 
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
