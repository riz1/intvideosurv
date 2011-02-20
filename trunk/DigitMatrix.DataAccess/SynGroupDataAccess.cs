using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using IntVideoSurv.Entity;

namespace IntVideoSurv.DataAccess
{
    public class SynGroupDataAccess
    {


        public static int GetMaxSynGroupId(Database db)
        {
            string cmdText = "select max(SynGroupId) from SynGroup";
            try
            {
                return int.Parse(db.ExecuteScalar(CommandType.Text, cmdText).ToString());

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public static DataSet GetAllCameraBySynGroupId(Database db, int SynGroupId)
        {

            string cmdText = string.Format(@"SELECT SynCamera.CameraId as CameraId, SynCamera.SynGroupId as SynGroupId, displayChannelInfo.DispalyChannelNoInCurrentCard as DispalyChannelNoInCurrentCard, "+
                "displayChannelInfo.DecodeCardNo as DecodeCardNo,displayChannelInfo.SplitScreenNo as SplitScreenNo,displayChannelInfo.DisplayChannelId as DisplayChannelId ,SynCamera.DisplaySplitScreenNo as DisplaySplitScreenNo "
                +"FROM SynCamera INNER JOIN displayChannelInfo ON SynCamera.DisplayChannelId = displayChannelInfo.DisplayChannelId  where SynCamera.SynGroupId={0} order by SynCamera.CameraId", SynGroupId);



            try
            {
                return db.ExecuteDataSet(CommandType.Text, cmdText);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public static int Insert(Database db, SynGroup oGroupInfo)
        {

            StringBuilder sbField = new StringBuilder();
            StringBuilder sbValue = new StringBuilder();
            sbField.Append("INSERT INTO SynGroup(");
            sbValue.Append("values(");
            sbField.Append("Name");
            sbValue.AppendFormat("'{0}'", oGroupInfo.Name);
            sbField.Append(",Description)");
            sbValue.AppendFormat(",'{0}')", oGroupInfo.Description);
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
        public static int Update(Database db, SynGroup oGroupInfo)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("update SynGroup set");
            sb.AppendFormat(" Name='{0}'", oGroupInfo.Name);
            sb.AppendFormat(",Description='{0}'", oGroupInfo.Description);
            sb.AppendFormat(" where GroupID={0})", oGroupInfo.SynGroupId);
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
        public static int Delete(Database db, int groupId)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("delete from SynGroup ");
            sb.AppendFormat(" where SynGroupID={0}", groupId);
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

        public static DataSet GetAllSynGroupInfo(Database db)
        {
            string cmdText = string.Format("select * from SynGroup order by SynGroupId");
            try
            {
                return db.ExecuteDataSet(CommandType.Text, cmdText);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public static DataSet GetSynGroupBySynGroupId(Database db, int groupId)
        {
            string cmdText = string.Format("select * from SynGroup where SynGroupId={0} ", groupId);
            try
            {
                return db.ExecuteDataSet(CommandType.Text, cmdText);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static DataSet GetSynGroupBySynGroupName(Database db, string groupName)
        {
            string cmdText = string.Format("select * from SynGroup where name=\'{0}\' ", groupName);
            try
            {
                return db.ExecuteDataSet(CommandType.Text, cmdText);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        //修改channelno的定义后本方法暂不使用
        public static int InsertSynGroupCamera(Database db, int groupId,int cameraId)
        {
            int monitorId = 0;
            string cmdTextIsExisted = string.Format("select count(*) from SynCamera where syngroupid={0} and cameraid={1}", groupId, cameraId);
            try
            {
                int isexisted=int.Parse(db.ExecuteScalar(CommandType.Text, cmdTextIsExisted).ToString());
                if (isexisted > 0)
                {
                    return -1;
                }
            }
            catch (Exception ex)
            {
                
                throw ex;
            }

            string cmdTextSearchMaxChanel = string.Format("select count(displayChannelId) from SynCamera where syngroupid={0}",groupId);
            try
            {
                monitorId = int.Parse(db.ExecuteScalar(CommandType.Text, cmdTextSearchMaxChanel).ToString());
                if (monitorId>0)
                {
                    cmdTextSearchMaxChanel = string.Format("select max(displayChannelId)+1 from SynCamera where syngroupid={0}", groupId);
                    monitorId = int.Parse(db.ExecuteScalar(CommandType.Text, cmdTextSearchMaxChanel).ToString());
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }

            StringBuilder sbField = new StringBuilder();
            StringBuilder sbValue = new StringBuilder();
            sbField.Append("INSERT INTO SynCamera(");
            sbValue.Append("values(");
            sbField.Append("SynGroupId");
            sbValue.AppendFormat("{0}", groupId);
            sbField.Append(",CameraId");
            sbValue.AppendFormat(",{0}", cameraId);
            sbField.Append(",displayChannelId)");
            sbValue.AppendFormat(",{0})", monitorId);

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
        //修改channelno+displaySpitScreen的定义后本方法暂不使用
        public static int InsertSynGroupCamera(Database db, int groupId, int cameraId, int displayChannelId)
        {

            string cmdTextIsExisted = string.Format("select count(*) from SynCamera where syngroupid={0} and cameraid={1} and displayChannelId={2}", groupId, cameraId, displayChannelId);
            try
            {
                int isexisted = int.Parse(db.ExecuteScalar(CommandType.Text, cmdTextIsExisted).ToString());
                if (isexisted > 0)
                {
                    return -1;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

            StringBuilder sbField = new StringBuilder();
            StringBuilder sbValue = new StringBuilder();
            sbField.Append("INSERT INTO SynCamera(");
            sbValue.Append("values(");
            sbField.Append("SynGroupId");
            sbValue.AppendFormat("{0}", groupId);
            sbField.Append(",CameraId");
            sbValue.AppendFormat(",{0}", cameraId);
            sbField.Append(",displayChannelId)");
            sbValue.AppendFormat(",{0})", displayChannelId);

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


        public static int InsertSynGroupCamera(Database db, int groupId, int cameraId, int displayChannelId, int displaySplitScreenNo)
        {

            string cmdTextIsExisted = string.Format("select count(*) from SynCamera where syngroupid={0} and cameraid={1} and displayChannelId={2} and displaySplitScreenNo= {3} ", groupId, cameraId, displayChannelId, displaySplitScreenNo);
            try
            {
                int isexisted = int.Parse(db.ExecuteScalar(CommandType.Text, cmdTextIsExisted).ToString());
                if (isexisted > 0)
                {
                    return -1;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

            StringBuilder sbField = new StringBuilder();
            StringBuilder sbValue = new StringBuilder();
            sbField.Append("INSERT INTO SynCamera(");
            sbValue.Append("values(");
            sbField.Append("SynGroupId");
            sbValue.AppendFormat("{0}", groupId);
            sbField.Append(",CameraId");
            sbValue.AppendFormat(",{0}", cameraId);
            sbField.Append(",displayChannelId");
            sbValue.AppendFormat(",{0}", displayChannelId);
            sbField.Append(",displaySplitScreenNo)");
            sbValue.AppendFormat(",{0})", displaySplitScreenNo);
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


        //修改channelno的定义后本方法暂不使用
        public static int DeleteSynGroupCamera(Database db, int groupId, int cameraId)
        {

            string cmdTextDeletelSynGroupCamera = string.Format("delete from SynCamera where syngroupid={0} and cameraId={1}", groupId, cameraId);
            try
            {
                return db.ExecuteNonQuery(CommandType.Text, cmdTextDeletelSynGroupCamera);
  
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }


        public static int DeleteSynGroupCamera(Database db, int groupId, int cameraId, int displayChannelId)
        {

            string cmdTextDeletelSynGroupCamera = string.Format("delete from SynCamera where syngroupid={0} and cameraId={1} and DisplayChannelId={2}", groupId, cameraId, displayChannelId);
            try
            {
                return db.ExecuteNonQuery(CommandType.Text, cmdTextDeletelSynGroupCamera);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public static int DeleteSynGroupCamera(Database db, int groupId, int cameraId, int displayChannelId, int displaySplitScreenNo)
        {

            string cmdTextDeletelSynGroupCamera = string.Format("delete from SynCamera where syngroupid={0} and cameraId={1} and DisplayChannelId={2} and displaySplitScreenNo={3}", groupId, cameraId, displayChannelId, displaySplitScreenNo);
            try
            {
                return db.ExecuteNonQuery(CommandType.Text, cmdTextDeletelSynGroupCamera);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public static int DeleteSynGroupCamera(Database db, int synCameraId)
        {

            string cmdTextDeletelSynGroupCamera = string.Format("delete from SynCamera where Id={0}", synCameraId);
            try
            {
                return db.ExecuteNonQuery(CommandType.Text, cmdTextDeletelSynGroupCamera);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

    }
}
