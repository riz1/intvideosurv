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
            string cmdText = string.Format("select IVS_ProgSwitchDetail.Id as ProgSwitchDetailId, IVS_ProgSwitchDetail.CameraId as CameraId, IVS_CameraInfo.Name as CameraName," +
                "IVS_ProgSwitchDetail.TickTime as TickTime, IVS_DeviceInfo.DeviceId as DeviceId, IVS_DeviceInfo.Name as DeviceName " +
                " from " +
                "((IVS_ProgSwitchDetail inner join IVS_CameraInfo on IVS_ProgSwitchDetail.CameraId = IVS_CameraInfo.CameraId)  " +
                "inner join IVS_DeviceInfo on IVS_CameraInfo.DeviceId = IVS_DeviceInfo.DeviceId ) " +
                "where IVS_ProgSwitchDetail.ProgSwitchId={0} order by IVS_ProgSwitchDetail.Id", progSwitchId);
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
            string cmdText = string.Format("select IVS_ProgSwitchDetail.Id as ProgSwitchDetailId, IVS_ProgSwitchDetail.CameraId as CameraId, IVS_CameraInfo.Name as CameraName," +
                "IVS_ProgSwitchDetail.TickTime as TickTime, IVS_DeviceInfo.DeviceId as DeviceId, IVS_DeviceInfo.Name as DeviceName " +
                " from " +
                "((IVS_ProgSwitchDetail inner join IVS_CameraInfo on IVS_ProgSwitchDetail.CameraId = IVS_CameraInfo.CameraId)  " +
                "inner join IVS_DeviceInfo on IVS_CameraInfo.DeviceId = IVS_DeviceInfo.DeviceId ) " +
                "where IVS_ProgSwitchDetail.Id={0}", detailId);
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
            string cmdText = string.Format("select IVS_ProgSwitchDetail.Id as ProgSwitchDetailId, IVS_ProgSwitchDetail.CameraId as CameraId, IVS_CameraInfo.Name as CameraName," +
                "IVS_ProgSwitchDetail.TickTime as TickTime, IVS_DeviceInfo.DeviceId as DeviceId, IVS_DeviceInfo.Name as DeviceName " +
                " from " +
                "((IVS_ProgSwitchDetail inner join IVS_CameraInfo on IVS_ProgSwitchDetail.CameraId = IVS_CameraInfo.CameraId)  " +
                "inner join IVS_DeviceInfo on IVS_CameraInfo.DeviceId = IVS_DeviceInfo.DeviceId ) " +
                "order by IVS_ProgSwitchDetail.Id");
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
            sb.Append("delete from [IVS_ProgSwitchDetail] ");
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
            sbField.Append("INSERT INTO  [IVS_ProgSwitchDetail](");
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
                String.Format("select count(*) from IVS_ProgSwitchDetail where ProgSwitchId={0} and CameraId={1}",
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

            string cmdText = string.Format("update [IVS_ProgSwitchDetail] set [TickTime]={0} where [Id] = {1}", tickTime, id);


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
