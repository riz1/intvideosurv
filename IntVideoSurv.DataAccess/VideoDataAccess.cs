using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using IntVideoSurv.Entity;

namespace IntVideoSurv.DataAccess
{
    public class VideoDataAccess
    {
        public static int Insert(Database db, VideoInfo videoInfo)
        {

            StringBuilder sbField = new StringBuilder();
            StringBuilder sbValue = new StringBuilder();
            sbField.Append("INSERT INTO  [VideoInfo(");
            sbValue.Append("values (");
            sbField.Append("[CameraId");
            sbValue.AppendFormat("{0}", videoInfo.CameraId);
            sbField.Append(",[CaptureTimeBegin");
            sbValue.AppendFormat(",'{0}'", videoInfo.CaptureTimeBegin);
            sbField.Append(",[CaptureTimeEnd");
            sbValue.AppendFormat(",'{0}'", videoInfo.CaptureTimeEnd);
            sbField.Append(",[FilePath)");
            sbValue.AppendFormat(",'{0}')", videoInfo.FilePath);
            string cmdText = sbField + " " + sbValue;
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
        
        public static int Delete(Database db, int id)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                DataSet dataSet = GetVideoInfoById(db, id);
                if (dataSet.Tables[0].Rows.Count == 0)
                {
                    return 0;
                }
                //删除相应的文件
                VideoInfo videoInfo;
                foreach (DataRow dr in dataSet.Tables[0].Rows)
                {

                    videoInfo = new VideoInfo(dr);
                    if (File.Exists(videoInfo.FilePath))
                    {
                        File.Delete(videoInfo.FilePath);
                    }
                }
                //删除出数据库中的记录
                sb.Append("delete from VideoInfo ");
                sb.AppendFormat(" where Id={0}", id);
                string cmdText = sb.ToString();
                return db.ExecuteNonQuery(CommandType.Text, cmdText);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public static DataSet GetVideoInfoById(Database db, int id)
        {
            string cmdText = string.Format("select * from VideoInfo where Id={0} order by Id", id);
            try
            {
                return db.ExecuteDataSet(CommandType.Text, cmdText);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static DataSet GetVideoInfoByCamera(Database db, int cameraId)
        {
            string cmdText = string.Format("select * from VideoInfo where CameraId={0} order by Id", cameraId);
            try
            {
                return db.ExecuteDataSet(CommandType.Text, cmdText);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static DataSet GetVideoInfoByCameraDateTime(Database db, int cameraId, DateTime captureBeginTime, DateTime captureEndTime)
        {
            string cmdText = string.Format("select * from VideoInfo where CameraId={0} and captureBeginTime >='{1}' and captureEndTime<'{2}' order by Id", cameraId,captureBeginTime,captureEndTime);
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
