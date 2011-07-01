using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using IntVideoSurv.Entity;

namespace IntVideoSurv.DataAccess
{
    public class LongChang_UserVehMonDataAccess
    {
        public static DataSet GetAllUserVehMonInfo(Database db)
        {
            string cmdText = string.Format("select * from IVS_USERVEHMON order by USERVEHMONID");
            try
            {
                return db.ExecuteDataSet(CommandType.Text, cmdText);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public static int Insert(Database db, LongChang_UserVehMonInfo uservehmon)
        {
           
            StringBuilder sbField = new StringBuilder();
            StringBuilder sbValue = new StringBuilder();
            sbField.Append("INSERT INTO  IVS_USERVEHMON(");
            sbValue.Append("values (");
            //sbField.Append("id");
            //sbValue.AppendFormat("'{0}'", oDecoderInfo.id);
            sbField.Append("USERVEHMONID");
            sbValue.AppendFormat("'{0}'", Guid.NewGuid().ToString("N"));
            sbField.Append(",VEHMONID");
            sbValue.AppendFormat(",'{0}'", uservehmon.VehMonId);
            sbField.Append(",USERID");
            sbValue.AppendFormat(",{0}", uservehmon.UserId);
            sbField.Append(",TIME)");
            sbValue.AppendFormat(",to_date('{0}','YYYY/MM/DD HH24:MI:SS'))", uservehmon.TheTime);

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
            }

        }

        public static DataSet GetUserInfoByCameraId(Database db, int cameraid)
        {

            string cmdText = string.Format("select * from IVS_UserInfo where username in (select DLYH from TOG_DEVICE where SBBH={0})", cameraid);
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
