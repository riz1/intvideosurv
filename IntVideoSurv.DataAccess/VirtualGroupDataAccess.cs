using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using IntVideoSurv.Entity;
using Microsoft.Practices.EnterpriseLibrary.Data;
namespace IntVideoSurv.DataAccess
{
    public class VirtualGroupDataAccess
    {
        public static int Insert(Database db, VirtualGroupInfo oVirtualGroup)
        {
            StringBuilder sbField = new StringBuilder();
            StringBuilder sbValue = new StringBuilder();
            sbField.Append("INSERT INTO  VirtualGroup(");
            sbValue.Append("values (");
            //sbField.Append("[ID]");
            //sbValue.AppendFormat("{0}", oVirtualGroup.ID);
            sbField.Append("Name)");
            sbValue.AppendFormat("'{0}')", oVirtualGroup.Name);
            string cmdText = sbField.ToString() + " " + sbValue.ToString();

            try
            {
                cmdText = cmdText.Replace("\r\n", "");
                db.ExecuteNonQuery(CommandType.Text, cmdText);

                string strsql = "";             

                if (DataBaseParas.DBType == MyDBType.SqlServer)
                {
                    strsql = "SELECT     ident_current('VirtualGroup')";
                }
                else if (DataBaseParas.DBType == MyDBType.Oracle)
                {
                    strsql =
                    "select ID   from   VirtualGroup   where  rowid=(select   max(rowid)   from   VirtualGroup)";
                }
                int id = int.Parse(db.ExecuteScalar(CommandType.Text, strsql).ToString());
                return id;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public static int DeleteByGroupID(Database db, int GroupID)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("delete from VirtualGroup ");
            sb.AppendFormat(" where ID={0}", GroupID);
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
        //
        public static DataSet GetAllVirtualGroupInfo(Database db)
        {
            string cmdText = string.Format("select * from VirtualGroup order by ID");
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
