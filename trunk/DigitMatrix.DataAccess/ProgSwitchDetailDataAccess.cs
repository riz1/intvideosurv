using System;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;

namespace IntVideoSurv.DataAccess
{
    public class ProgSwitchDetailDataAccess
    {
        public static DataSet GetProgSwitchDetailByProgSwitchId(Database db, int progSwitchId)
        {
            string cmdText = string.Format("select ProgSwitchDetail.Id as ProgSwitchDetailId, ProgSwitchDetail.CameraId as CameraId, CameraInfo.Name as CameraName," +
                "ProgSwitchDetail.TickTime as TickTime, DeviceInfo.DeviceId as DeviceId, DeviceInfo.Name as DeviceName " +
                " from " +
                "((ProgSwitchDetail inner join CameraInfo on ProgSwitchDetail.CameraId = CameraInfo.CameraId)  " +
                "inner join DeviceInfo on CameraInfo.DeviceId = DeviceInfo.DeviceId ) " +
                "where ProgSwitchDetail.ProgSwitchId={0} order by ProgSwitchDetail.Id", progSwitchId);
            try
            {
                return db.ExecuteDataSet(CommandType.Text, cmdText);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static DataSet GetProgSwitchDetailByDetailId(Database db, int detailId)
        {
            string cmdText = string.Format("select ProgSwitchDetail.Id as ProgSwitchDetailId, ProgSwitchDetail.CameraId as CameraId, CameraInfo.Name as CameraName," +
                "ProgSwitchDetail.TickTime as TickTime, DeviceInfo.DeviceId as DeviceId, DeviceInfo.Name as DeviceName " +
                " from " +
                "((ProgSwitchDetail inner join CameraInfo on ProgSwitchDetail.CameraId = CameraInfo.CameraId)  " +
                "inner join DeviceInfo on CameraInfo.DeviceId = DeviceInfo.DeviceId ) " +
                "where ProgSwitchDetail.Id={0}", detailId);
            try
            {
                return db.ExecuteDataSet(CommandType.Text, cmdText);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static DataSet GetAllProgSwitchDetailInfos(Database db)
        {
            string cmdText = string.Format("select ProgSwitchDetail.Id as ProgSwitchDetailId, ProgSwitchDetail.CameraId as CameraId, CameraInfo.Name as CameraName," +
                "ProgSwitchDetail.TickTime as TickTime, DeviceInfo.DeviceId as DeviceId, DeviceInfo.Name as DeviceName " +
                " from " +
                "((ProgSwitchDetail inner join CameraInfo on ProgSwitchDetail.CameraId = CameraInfo.CameraId)  " +
                "inner join DeviceInfo on CameraInfo.DeviceId = DeviceInfo.DeviceId ) " +
                "order by ProgSwitchDetail.Id");
            try
            {
                return db.ExecuteDataSet(CommandType.Text, cmdText);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static int Delete(Database db, int id)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("delete from [ProgSwitchDetail] ");
            sb.AppendFormat(" where [Id]={0}", id);
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

        public static int Insert(Database db, int progSwitchid, int cameraId, int tickTime)
        {
            if (IsExisted(db, progSwitchid, cameraId))
            {
                return int.MinValue;
            }

            StringBuilder sbField = new StringBuilder();
            StringBuilder sbValue = new StringBuilder();
            sbField.Append("INSERT INTO  [ProgSwitchDetail](");
            sbValue.Append("values (");
            sbField.Append("[ProgSwitchId]");
            sbValue.AppendFormat("{0}", progSwitchid);
            sbField.Append(",[CameraId]");
            sbValue.AppendFormat(",{0}", cameraId);
            sbField.Append(",[TickTime])");
            sbValue.AppendFormat(",{0})", tickTime);

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

        public static bool IsExisted(Database db, int progSwitchid, int cameraId)
        {
            String strSqlExisted =
                String.Format("select count(*) from ProgSwitchDetail where ProgSwitchId={0} and CameraId={1}",
                              progSwitchid, cameraId);
            try
            {

                return int.Parse(db.ExecuteScalar(CommandType.Text, strSqlExisted).ToString()) > 0 ? true : false;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public static int UpdateTickTimeById(Database db, int id, int tickTime)
        {

            string cmdText = string.Format("update [ProgSwitchDetail] set [TickTime]={0} where [Id] = {1}", tickTime, id);


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
