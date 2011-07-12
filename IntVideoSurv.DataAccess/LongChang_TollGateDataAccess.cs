using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using IntVideoSurv.Entity;

namespace IntVideoSurv.DataAccess
{
    public class LongChang_TollGateDataAccess
    {
        public static DataSet GetAllTollGateInfo(Database db)
        {
            string cmdText = string.Format("select * from TOG_TOLLGATE order by tgid");
            try
            {
                return db.ExecuteDataSet(CommandType.Text, cmdText);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static DataSet GetTollGateInfoById(Database db, int tollid)
        {
            string cmdText = string.Format("select * from TOG_TOLLGATE where tgid = {0} order by tgid",tollid);
            try
            {
                return db.ExecuteDataSet(CommandType.Text, cmdText);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public static DataSet GetTollGateInfoByCameraId(Database db, int id)
        {
            string cmdText = string.Format("select * from TOG_TOLLGATE where sxjbh = {0}", id);
            try
            {
                return db.ExecuteDataSet(CommandType.Text, cmdText);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public static int Delete(Database db, string TollId)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("delete from TOG_TOLLGATE");
            sb.AppendFormat(" where KKBH='{0}'", TollId);
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
        public static DataSet GetTollGateInfoByKKBh(Database db, string tollid)
        {
            string cmdText = string.Format("select * from TOG_TOLLGATE where kkbh = '{0}' order by tgid", tollid);
            try
            {
                return db.ExecuteDataSet(CommandType.Text, cmdText);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public static DataSet GetTollGateInfoByKKFBh(Database db, string tollfid)
        {
            string cmdText = string.Format("select * from TOG_TOLLGATE where kkfbh = '{0}' order by tgid", tollfid);
            try
            {
                return db.ExecuteDataSet(CommandType.Text, cmdText);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public static string Insert(Database db, LongChang_TollGateInfo oTollGateInfo)
        {

            StringBuilder sbField = new StringBuilder();
            StringBuilder sbValue = new StringBuilder();
            sbField.Append("INSERT INTO  TOG_TOLLGATE(");
            sbValue.Append("values (");

            sbField.Append("tgid");
            sbValue.AppendFormat("'{0}'", Guid.NewGuid().ToString("N"));
            sbField.Append(",kkbh");
            sbValue.AppendFormat(",'{0}'", oTollGateInfo.tollNum);
            sbField.Append(",kkmc");
            sbValue.AppendFormat(",'{0}'", oTollGateInfo.tollName);
            sbField.Append(",kkjc");
            sbValue.AppendFormat(",'{0}'", oTollGateInfo.tollShort);
            sbField.Append(",kklx");
            sbValue.AppendFormat(",'{0}'", oTollGateInfo.tollType);
            sbField.Append(",dwbh");
            sbValue.AppendFormat(",'{0}'", oTollGateInfo.departmentNum);
            sbField.Append(",xzqh");
            sbValue.AppendFormat(",'{0}'", oTollGateInfo.administrationDivsion);
            sbField.Append(",sxjbh");
            sbValue.AppendFormat(",'{0}'", oTollGateInfo.cameraNum.ToString());
            sbField.Append(",kkfbh");
            sbValue.AppendFormat(",'{0}'", oTollGateInfo.tollParentNum);
            sbField.Append(",dlmc");
            sbValue.AppendFormat(",'{0}'", oTollGateInfo.roadName);
            sbField.Append(",dlbh)");
            sbValue.AppendFormat(",'{0}')", oTollGateInfo.roadNum);
            string cmdText = sbField.ToString() + " " + sbValue.ToString();
            string strsql;

            try
            {
                cmdText = cmdText.Replace("\r\n", "");
                db.ExecuteNonQuery(CommandType.Text, cmdText);

                strsql = "select tgid   from   TOG_TOLLGATE   where  tgid=(select   max(tgid)   from   TOG_TOLLGATE)";

                string id = db.ExecuteScalar(CommandType.Text, strsql).ToString();
                return id;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public static int InsertCheDao(Database db, LongChang_TollGateInfo oTollGateInfo)
        {

            StringBuilder sbField = new StringBuilder();
            StringBuilder sbValue = new StringBuilder();
            sbField.Append("INSERT INTO  TOG_TOLLGATE(");
            sbValue.Append("values (");

            sbField.Append("tgid");
            sbValue.AppendFormat("'{0}'", Guid.NewGuid().ToString("N"));
            sbField.Append(",kkfbh");
            sbValue.AppendFormat(",'{0}'", oTollGateInfo.tollParentNum);
            sbField.Append(",kkbh");
            sbValue.AppendFormat(",'{0}'", oTollGateInfo.tollNum);
            sbField.Append(",kkmc");
            sbValue.AppendFormat(",'{0}'", oTollGateInfo.tollName);
            sbField.Append(",kkjc");
            sbValue.AppendFormat(",'{0}'", oTollGateInfo.tollShort);
            sbField.Append(",sxjbh)");
            sbValue.AppendFormat(",{0})", oTollGateInfo.cameraNum);

            string cmdText = sbField.ToString() + " " + sbValue.ToString();
            string strsql;

            try
            {
                cmdText = cmdText.Replace("\r\n", "");
                return db.ExecuteNonQuery(CommandType.Text, cmdText);

            }
            catch (Exception ex)
            {

                throw ex;
                return -1;
            }
        }
        public static int Update(Database db, LongChang_TollGateInfo toll)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("update TOG_TOLLGATE set");
            sb.AppendFormat(" KKBH='{0}'", toll.tollNum);
            //sb.AppendFormat(",id='{0}'", oDecoderInfo.id);
            sb.AppendFormat(",KKMC='{0}'", toll.tollName);
            sb.AppendFormat(",KKJC='{0}'", toll.tollShort);
            sb.AppendFormat(",SXJBH={0}", toll.cameraNum);
            sb.AppendFormat(" where KKBH='{0}'", toll.tollNum);
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
    }
}
