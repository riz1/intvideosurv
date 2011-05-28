using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using IntVideoSurv.Entity;

namespace IntVideoSurv.DataAccess
{
    public class CameraIconDataAccess
    {

        public static int Insert(Database db, CameraIconInfo cameraIconInfo)
        {
            StringBuilder sbField = new StringBuilder();
            StringBuilder sbValue = new StringBuilder();
            sbField.Append("INSERT INTO CameraIconInfo(");
            sbValue.Append("values(");
            sbField.Append("CameraId");
            sbValue.AppendFormat("{0}", cameraIconInfo.CameraId);
            sbField.Append(",IconIndex");
            sbValue.AppendFormat(",{0}", cameraIconInfo.IconIndex);
            sbField.Append(",ToolTip");
            sbValue.AppendFormat(",'{0}'", cameraIconInfo.ToolTip);
            sbField.Append(",X");
            sbValue.AppendFormat(",{0}", cameraIconInfo.X);
            sbField.Append(",Y");
            sbValue.AppendFormat(",{0}", cameraIconInfo.Y);
            sbField.Append(",Map");
            sbValue.AppendFormat(",{0}", cameraIconInfo.Map);
            sbField.Append(",MatchAlarmId)");
            sbValue.AppendFormat(",{0})", cameraIconInfo.MatchAlarmId);
            string cmdText = sbField + " " + sbValue;
            try
            {
                return db.ExecuteNonQuery(CommandType.Text, cmdText);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public static int Update(Database db, CameraIconInfo cameraIconInfo)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("update CameraIconInfo set");
            sb.AppendFormat(" IconIndex={0}", cameraIconInfo.IconIndex);
            sb.AppendFormat(",ToolTip='{0}'", cameraIconInfo.ToolTip);
            sb.AppendFormat(",X={0}", cameraIconInfo.X);
            sb.AppendFormat(",Y={0} ", cameraIconInfo.Y);
            sb.AppendFormat(",MatchAlarmId={0} ", cameraIconInfo.MatchAlarmId);
            sb.AppendFormat(" where CameraId={0}", cameraIconInfo.CameraId);
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
        public static int Delete(Database db, int cameraId)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("delete from CameraIconInfo ");
            sb.AppendFormat(" where CameraId={0}", cameraId);
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

        public static DataSet GetAllCameraIconInfo(Database db)
        {
            string cmdText = string.Format("select CameraIconInfo.*,CameraInfo.Name as CameraName from (CameraIconInfo inner join CameraInfo on CameraIconInfo.CameraId =  CameraInfo.CameraId) order by CameraInfo.CameraId");
            try
            {
                return db.ExecuteDataSet(CommandType.Text, cmdText);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public static DataSet GetCameraIconInfoByCameraId(Database db, int cameraId)
        {
            string cmdText = string.Format("select CameraIconInfo.*,CameraInfo.Name as CameraInfo from (CameraIconInfo inner join CameraInfo on CameraIconInfo.CameraId =  CameraInfo.CameraId) where CameraInfo.CameraId={0}", cameraId);
            try
            {
                return db.ExecuteDataSet(CommandType.Text, cmdText);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public static DataSet GetCameraIconInfoByMapId(Database db, int mapId)
        {
            string cmdText = string.Format("select CameraIconInfo.*,CameraInfo.Name as CameraInfo from (CameraIconInfo inner join CameraInfo on CameraIconInfo.CameraId =  CameraInfo.CameraId) where CameraIconInfo.map={0}", mapId);
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

