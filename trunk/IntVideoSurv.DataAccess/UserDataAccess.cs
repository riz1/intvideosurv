using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using IntVideoSurv.Entity;

namespace IntVideoSurv.DataAccess
{
    public class UserDataAccess
    {
        public static int GetMaxUserId(Database db)
        {
            string cmdText = "select max([UserId]) from [UserInfo]";
            try
            {
                return int.Parse(db.ExecuteScalar(CommandType.Text, cmdText).ToString());

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public static int Insert(Database db, UserInfo userInfo)
        {

            StringBuilder sbField = new StringBuilder();
            StringBuilder sbValue = new StringBuilder();
            sbField.Append("INSERT INTO  [UserInfo](");
            sbValue.Append("values (");
            sbField.Append("[username]");
            sbValue.AppendFormat("'{0}'", userInfo.UserName);
            sbField.Append(",[password]");
            sbValue.AppendFormat(",'{0}'", userInfo.Password);
            sbField.Append(",[createdatetime]");
            sbValue.AppendFormat(",'{0}'", userInfo.CreateDateTime);
            sbField.Append(",[usertypeid]");
            sbValue.AppendFormat(",{0}", userInfo.UserTypeId);
            sbField.Append(",[usertypename])");
            sbValue.AppendFormat(",'{0}')", userInfo.UserTypeName);
 
            string cmdText = sbField.ToString() + " " + sbValue.ToString();


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
        public static int UpdatePassword(Database db, int userId, string password)
        {

            StringBuilder sbValue = new StringBuilder();
            sbValue.Append("update [UserInfo] set ");
            sbValue.AppendFormat("[password]='{0}'", password);
            sbValue.AppendFormat(" where [UserId]={0}", userId);
            string cmdText = sbValue.ToString();
            try
            {
                return db.ExecuteNonQuery(CommandType.Text, cmdText);

            }
            catch (Exception ex)
            {

                throw ex;
            }


        }
        public static int Delete(Database db, int userId)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("delete from [UserInfo] ");
            sb.AppendFormat(" where [UserId]={0}", userId);
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

        public static DataSet GetAllUserInfo(Database db)
        {
            string cmdText = string.Format("select * from [UserInfo] order by [UserId]");
            try
            {
                return db.ExecuteDataSet(CommandType.Text, cmdText);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static DataSet GetUserInfo(Database db,int userid)
        {
            string cmdText = string.Format("select * from [UserInfo] where [UserId]={0}", userid);
            try
            {
                return db.ExecuteDataSet(CommandType.Text, cmdText);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static DataSet GetUserInfo(Database db, string username)
        {
            string cmdText = string.Format("select * from [UserInfo] where [username]=\'{0}\'", username);
            try
            {
                return db.ExecuteDataSet(CommandType.Text, cmdText);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static DataSet GetAllUsers(Database db)
        {
            string cmdText = string.Format("select [userID] as 索引号, [username] as 用户名, [usertypename] as 用户类型, [createdatetime] as 创建时间 from [userinfo] order by [userId]");
            try
            {
                return db.ExecuteDataSet(CommandType.Text, cmdText);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static bool IsUserNameExisted(Database db,string userName)
        {
            string cmdText = string.Format("select count(*) from [userinfo] where [username]=\'{0}\'",userName);
            try
            {
                return int.Parse(db.ExecuteScalar(CommandType.Text, cmdText).ToString())>0?false:true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static bool IsUserValid(Database db, string userName, string userPassword)
        {
            string cmdText = string.Format("select count(*) from [userinfo] where [username]=\'{0}\' and [password]=\'{1}\'", userName, userPassword);
            try
            {
                return int.Parse(db.ExecuteScalar(CommandType.Text, cmdText).ToString()) > 0 ? true : false;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}

