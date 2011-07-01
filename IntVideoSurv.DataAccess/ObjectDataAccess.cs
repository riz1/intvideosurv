using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using IntVideoSurv.Entity;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace IntVideoSurv.DataAccess
{
    public class ObjectDataAccess
    {
        public static int Insert(Database db, ObjectInfo oObject)
        {
            int i;
            StringBuilder sbField = new StringBuilder();
            StringBuilder sbValue = new StringBuilder();
            sbField.Append("INSERT INTO  IVS_ObjectInfo(");
            sbValue.Append("values (");
            sbField.Append("ObjectId");
            sbValue.AppendFormat("{0}", oObject.ObjectId);
            if (oObject.stop == true) i = 1;
            else i = 0;
            sbField.Append(",stop");
            sbValue.AppendFormat(",{0}", i);
            if (oObject.illegalDir == true) i = 1;
            else i = 0;
            sbField.Append(",illegalDir");
            sbValue.AppendFormat(",{0}", i);
            if (oObject.CrossLine== true) i = 1;
            else i = 0;
            sbField.Append(",CrossLine");
            sbValue.AppendFormat(",{0}", i);
            if (oObject.changeChannel == true) i = 1;
            else i = 0;
            sbField.Append(",changeChannel");
            sbValue.AppendFormat(",{0}", i);
            sbField.Append(",changeChannel)");
            sbValue.AppendFormat(",{0})", oObject.EventId);
            string cmdText = sbField.ToString() + " " + sbValue.ToString();

            try
            {
                cmdText = cmdText.Replace("\r\n", "");
                db.ExecuteNonQuery(CommandType.Text, cmdText);
                string strsql = "";
                if (DataBaseParas.DBType == MyDBType.SqlServer)
                {
                    strsql = "SELECT     ident_current('IVS_ObjectInfo')";
                }
                else if (DataBaseParas.DBType == MyDBType.Oracle)
                {
                    strsql =
                    "select ID   from   IVS_ObjectInfo   where  rowid=(select   max(rowid)   from   IVS_ObjectInfo)";
                }

                int id = int.Parse(db.ExecuteScalar(CommandType.Text, strsql).ToString());
                return id;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static DataSet GetObjectCustom(Database db, int eventid)
        {
            string cmdText = string.Format(
                "select IVS_ObjectInfo.ObjectId,IVS_ObjectInfo.stop,IVS_ObjectInfo.illegalDir,IVS_ObjectInfo.CrossLine,IVS_ObjectInfo.changeChannel,IVS_ObjectInfo.EventId " +
                "from IVS_ObjectInfo " +
                "where IVS_ObjectInfo.EventId={0} order by ObjectId", eventid);
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
