using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using IntVideoSurv.Entity;

namespace IntVideoSurv.DataAccess
{
    public class LongChang_VehMonDataAccess
    {
        public static DataSet GetAllVehMonInfo(Database db)
        {
            string cmdText = string.Format("select * from TOG_VEHMON order by mvid");
            try
            {
                return db.ExecuteDataSet(CommandType.Text, cmdText);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public static string Insert(Database db, LongChang_VehMonInfo oVehMon)
        {
            
            StringBuilder sbField = new StringBuilder();
            StringBuilder sbValue = new StringBuilder();
            sbField.Append("INSERT INTO  TOG_VEHMON(");
            sbValue.Append("values (");
            //sbField.Append("id");
            //sbValue.AppendFormat("'{0}'", oDecoderInfo.id);
            sbField.Append("mvid");
            sbValue.AppendFormat("'{0}'", Guid.NewGuid().ToString("N"));
            sbField.Append(",clxxbh");
            sbValue.AppendFormat(",{0}", "CLXXBH_SEQ.nextval".ToString());
            sbField.Append(",kkbh");
            sbValue.AppendFormat(",{0}", oVehMon.tollNum);
            sbField.Append(",kkmc");
            sbValue.AppendFormat(",'{0}'", oVehMon.tollName);
            sbField.Append(",hphm");
            sbValue.AppendFormat(",'{0}'", oVehMon.plateNumber);
            sbField.Append(",hpysbh");
            sbValue.AppendFormat(",{0}", oVehMon.plateColorNum);
            sbField.Append(",hpys");
            sbValue.AppendFormat(",'{0}'", oVehMon.plateColor);
            sbField.Append(",txsl");
            sbValue.AppendFormat(",{0}", oVehMon.imageCount);
            sbField.Append(",txmc1");
            sbValue.AppendFormat(",'{0}'", oVehMon.imageName1);
            sbField.Append(",txmc2");
            sbValue.AppendFormat(",'{0}'", oVehMon.imageName2);
            sbField.Append(",txmc3");
            sbValue.AppendFormat(",'{0}'", oVehMon.imageName3);
            sbField.Append(",txmc4");
            sbValue.AppendFormat(",'{0}'", oVehMon.imageName4);
            sbField.Append(",spmc");
            sbValue.AppendFormat(",'{0}'", oVehMon.vedioName);
            sbField.Append(",spmc1");
            sbValue.AppendFormat(",'{0}'", oVehMon.vedioName1);
            sbField.Append(",spmc2");
            sbValue.AppendFormat(",'{0}'", oVehMon.vedioName2);
            sbField.Append(",csys");
            sbValue.AppendFormat(",'{0}'", oVehMon.vehicleColor);
            sbField.Append(",cllx");
            sbValue.AppendFormat(",{0}", oVehMon.vehicleType);
            sbField.Append(",cllxmc");
            sbValue.AppendFormat(",'{0}'", oVehMon.vehicleTypeName);
            sbField.Append(",hpzl");
            sbValue.AppendFormat(",'{0}'", oVehMon.plateNumberType);
            sbField.Append(",hpzlmc");
            sbValue.AppendFormat(",'{0}'", oVehMon.plateNumberTypeName);
            sbField.Append(",tjrq");
            sbValue.AppendFormat(",{0}", oVehMon.countTime);//////
            sbField.Append(",wzyy");
            sbValue.AppendFormat(",'{0}'", oVehMon.illegalReason);
            sbField.Append(",cdbh");
            sbValue.AppendFormat(",'{0}'", oVehMon.roadNumber);
            sbField.Append(",cdmc");
            sbValue.AppendFormat(",'{0}'", oVehMon.roadName);
            sbField.Append(",dwbh");
            sbValue.AppendFormat(",'{0}'", oVehMon.adminDivisionNumber);
            sbField.Append(",dwmc");
            sbValue.AppendFormat(",'{0}'", oVehMon.adminDivisionName);
            sbField.Append(",hdsj)");
            sbValue.AppendFormat(",to_date('{0}','YYYY/MM/DD HH24:MI:SS'))", oVehMon.redLightTime);///

            string cmdText = sbField.ToString() + " " + sbValue.ToString();
            string strsql;

            try
            {
                cmdText = cmdText.Replace("\r\n", "");
                db.ExecuteNonQuery(CommandType.Text, cmdText);

                strsql = "select MVID   from   TOG_VEHMON   where  MVID=(select   max(MVID)   from   TOG_VEHMON)";

                string id = db.ExecuteScalar(CommandType.Text, strsql).ToString();
                return id;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        
    }
}
