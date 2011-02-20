using System;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using IntVideoSurv.Entity;

namespace IntVideoSurv.DataAccess
{
    public class MapDataAccess
    {

        public static int Insert(Database db, MapInfo mapInfo)
        {
            StringBuilder sbField = new StringBuilder();
            StringBuilder sbValue = new StringBuilder();
            sbField.Append("INSERT INTO MapInfo(");
            sbValue.Append("values(");
            sbField.Append("Name");
            sbValue.AppendFormat("'{0}'", mapInfo.Name);
            sbField.Append(",Width");
            sbValue.AppendFormat(",{0}", mapInfo.Width);
            sbField.Append(",Height");
            sbValue.AppendFormat(",{0}", mapInfo.Height);
            sbField.Append(",FileName)");
            sbValue.AppendFormat(",'{0}')", mapInfo.FileName);
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
        public static int Update(Database db, MapInfo mapInfo)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("update MapInfo set");
            sb.AppendFormat(" Name={0}", mapInfo.Name);
            sb.AppendFormat(",X={0}", mapInfo.Width);
            sb.AppendFormat(",Y={0} ", mapInfo.Height);
            sb.AppendFormat(",FileName='{0}' ", mapInfo.FileName);
            sb.AppendFormat(" where Id={0}", mapInfo.Id);
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
        public static int Delete(Database db, int mapId)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("delete from MapInfo ");
            sb.AppendFormat(" where Id={0}", mapId);
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

        public static DataSet GetAllMapInfo(Database db)
        {
            string cmdText = string.Format("select * from MapInfo");
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

