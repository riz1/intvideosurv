using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using IntVideoSurv.Entity;
namespace IntVideoSurv.DataAccess
{
    public class RecognizerDataAccess
    {
        public static int GetMaxRecognizerId(Database db)
        {
            string cmdText = "select max(Id) from RecognizerInfo";
            try
            {
                return int.Parse(db.ExecuteScalar(CommandType.Text, cmdText).ToString());

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public static int InsertCamera(Database db, int recognizer, int camera)
        {
            StringBuilder sbField = new StringBuilder();
            StringBuilder sbValue = new StringBuilder();
            sbField.Append("INSERT INTO  [RecognizerCamera](");
            sbValue.Append("values (");
            //sbField.Append("[id]");
            //sbValue.AppendFormat("{0}", id);
            sbField.Append("[Recognizer]");
            sbValue.AppendFormat("{0}", recognizer);
            sbField.Append(",[Camera])");
            sbValue.AppendFormat(",{0})", camera);

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
        public static int Insert(Database db, RecognizerInfo oRecognizerInfo)
        {
            
            StringBuilder sbField = new StringBuilder();
            StringBuilder sbValue = new StringBuilder();
            sbField.Append("INSERT INTO  [RecognizerInfo](");
            sbValue.Append("values (");
            //sbField.Append("[id]");
            //sbValue.AppendFormat("'{0}'", oDecoderInfo.id);
            sbField.Append("[Name]");
            sbValue.AppendFormat("'{0}'", oRecognizerInfo.Name);
            sbField.Append(",[Ip]");
            sbValue.AppendFormat(",'{0}'", oRecognizerInfo.Ip);
            sbField.Append(",[Port]");
            sbValue.AppendFormat(",{0}", oRecognizerInfo.Port);
            sbField.Append(",[RecogType]");
            sbValue.AppendFormat(",{0}", oRecognizerInfo.RecogType);
            sbField.Append(",[MaxRecogNumber])");
            sbValue.AppendFormat(",'{0}')", oRecognizerInfo.MaxRecogNumber);

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
        public static int Update(Database db, RecognizerInfo oRecognizerInfo)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("update RecognizerInfo set");
            sb.AppendFormat(" Name='{0}'", oRecognizerInfo.Name);
            //sb.AppendFormat(",id='{0}'", oDecoderInfo.id);
            sb.AppendFormat(",Ip='{0}'", oRecognizerInfo.Ip);
            sb.AppendFormat(",Port={0}", oRecognizerInfo.Port);
            sb.AppendFormat(",MaxRecogNumber={0}", oRecognizerInfo.MaxRecogNumber);
            sb.AppendFormat(",RecogType={0}", oRecognizerInfo.RecogType);
            sb.AppendFormat(" where Id={0}", oRecognizerInfo.Id);
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
        public static int Delete(Database db, int RecognizerId)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("delete from RecognizerInfo ");
            sb.AppendFormat(" where Id={0}", RecognizerId);
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
        public static int DeleteCameras(Database db, int CameraId)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("delete from RecognizerCamera ");
            sb.AppendFormat(" where camera={0}", CameraId);
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
        public static int DeleteByRecognizerId(Database db, int RecognizerId)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("delete from RecognizerCamera ");
            sb.AppendFormat(" where recognizer={0}", RecognizerId);
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
        public static DataSet GetAllRecInfo(Database db)
        {
            string cmdText = string.Format("select * from RecognizerInfo order by Id");
            try
            {
                return db.ExecuteDataSet(CommandType.Text, cmdText);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public static DataSet GetRecognizerInfoByRecognizerId(Database db, int RecognizerId)
        {
            string cmdText = string.Format("select * from RecognizerInfo where Id={0}", RecognizerId);
            try
            {
                return db.ExecuteDataSet(CommandType.Text, cmdText);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static DataSet GetRecognizerInfoByRecognizerIP(Database db, string IP)
        {
            string cmdText = string.Format("select * from RecognizerInfo where Ip='{0}'", IP);
            try
            {
                return db.ExecuteDataSet(CommandType.Text, cmdText);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public static DataSet GetRecognizerInfoByName(Database db, string Name)
        {
            string cmdText = string.Format("select * from RecognizerInfo where Name='{0}' order by Id", Name);
            try
            {
                return db.ExecuteDataSet(CommandType.Text, cmdText);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public static DataSet GetCameraInfoByRecognizerId(Database db, int RecognizerId)
        {

            string cmdText = string.Format("select * from CameraInfo where CameraId in (select camera from RecognizerCamera where recognizer={0})", RecognizerId);
            try
            {
                return db.ExecuteDataSet(CommandType.Text, cmdText);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public static DataSet GetDeviceInfoByCameraId(Database db, int Id)
        {

            string cmdText = string.Format("select * from DeviceInfo where DeviceId in (select DeviceId from CameraInfo where CameraId={0})", Id);
            try
            {
                return db.ExecuteDataSet(CommandType.Text, cmdText);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public static DataSet GetCamInfoByCameraId(Database db, int CameraId)
        {

            string cmdText = string.Format("select * from CameraInfo where CameraId={0} order by CameraId", CameraId);
            try
            {
                return db.ExecuteDataSet(CommandType.Text, cmdText);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public static DataSet GetTheCamera(Database db, int CameraId)
        {

            string cmdText = string.Format("select * from RecognizerCamera where Camera={0}", CameraId);
            try
            {
                return db.ExecuteDataSet(CommandType.Text, cmdText);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public static DataSet GetRecognizerInfoByCameraId(Database db,int CameraId)
        {
            string cmdText = string.Format("select * from RecognizerInfo where Id in (select Recognizer from RecognizerCamera where Camera = {0})", CameraId);
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
