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
            sbField.Append("INSERT INTO  IVS_VirtualGroup(");
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
                    strsql = "SELECT     ident_current('IVS_VirtualGroup')";
                }
                else if (DataBaseParas.DBType == MyDBType.Oracle)
                {
                    strsql =
                    "select ID   from   IVS_VirtualGroup   where  rowid=(select   max(rowid)   from   IVS_VirtualGroup)";
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
            sb.Append("delete from IVS_VirtualGroup ");
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
            string cmdText = string.Format("select * from IVS_VirtualGroup order by ID");
            try
            {
                return db.ExecuteDataSet(CommandType.Text, cmdText);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public static int ChangeVirtualGroup(Database db,int Gid,string newname)
        {
            string cmdText = string.Format("update IVS_VIRTUALGROUP set name='{0}' where ID={1}",newname,Gid);
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
