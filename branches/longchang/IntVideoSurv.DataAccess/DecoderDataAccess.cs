using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using IntVideoSurv.Entity;

namespace IntVideoSurv.DataAccess
{
    public class DecoderDataAccess
    {
        public static int GetMaxDecoderId(Database db)
        {
            string cmdText = "select max(id) from DecoderInfo";
            try
            {
                return int.Parse(db.ExecuteScalar(CommandType.Text, cmdText).ToString());

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public static int InsertCamera(Database db, int decoder,int camera)
        {
            StringBuilder sbField = new StringBuilder();
            StringBuilder sbValue = new StringBuilder();
            sbField.Append("INSERT INTO  IVS_DecoderCamera(");
            sbValue.Append("values (");
            //sbField.Append("id");
            //sbValue.AppendFormat("{0}", id);
            sbField.Append("decoder");
            sbValue.AppendFormat("{0}", decoder);
            sbField.Append(",camera)");
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
        public static int Insert(Database db, DecoderInfo oDecoderInfo)
        {
           /* StringBuilder sbField = new StringBuilder();
            StringBuilder sbValue = new StringBuilder();
            sbField.Append("INSERT INTO DecoderInfo(");
            sbValue.Append("values(");
            sbField.Append("id");
            sbValue.AppendFormat("{0}", oDecoderInfo.id);
            sbField.Append(",Name");
            sbValue.AppendFormat(",'{0}'", oDecoderInfo.Name);
            sbField.Append(",Ip");
            sbValue.AppendFormat(",'{0}'", oDecoderInfo.Ip);
            sbField.Append(",Port");
            sbValue.AppendFormat(",{0}", oDecoderInfo.Port);
            sbField.Append(",MaxDecodeChannelNo");
            sbValue.AppendFormat(",{0}", oDecoderInfo.MaxDecodeChannelNo);

            string cmdText = sbField.ToString() + " " + sbValue.ToString();
            try
            {
               // cmdText = cmdText.Replace("\r\n", "");
                return db.ExecuteNonQuery(CommandType.Text, cmdText);

            }
            catch (Exception ex)
            {

                throw ex;
            }*/
            StringBuilder sbField = new StringBuilder();
            StringBuilder sbValue = new StringBuilder();
            sbField.Append("INSERT INTO  DecoderInfo(");
            sbValue.Append("values (");
            //sbField.Append("id");
            //sbValue.AppendFormat("'{0}'", oDecoderInfo.id);
            sbField.Append("Name");
            sbValue.AppendFormat("'{0}'", oDecoderInfo.Name);
            sbField.Append(",Ip");
            sbValue.AppendFormat(",'{0}'", oDecoderInfo.Ip);
            sbField.Append(",Port");
            sbValue.AppendFormat(",{0}", oDecoderInfo.Port);
            sbField.Append(",MaxDecodeChannelNo)");
            sbValue.AppendFormat(",'{0}')", oDecoderInfo.MaxDecodeChannelNo);

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
        public static int Update(Database db, DecoderInfo oDecoderInfo)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("update DecoderInfo set");
            sb.AppendFormat(" Name='{0}'", oDecoderInfo.Name);
            //sb.AppendFormat(",id='{0}'", oDecoderInfo.id);
            sb.AppendFormat(",Ip='{0}'", oDecoderInfo.Ip);
            sb.AppendFormat(",Port={0}", oDecoderInfo.Port);
            sb.AppendFormat(",MaxDecodeChannelNo={0}", oDecoderInfo.MaxDecodeChannelNo);
            sb.AppendFormat(" where id={0}", oDecoderInfo.id);
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
        public static int Delete(Database db, int DecoderId)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("delete from DecoderInfo ");
            sb.AppendFormat(" where id={0}", DecoderId);
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
            sb.Append("delete from IVS_DecoderCamera ");
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
        public static int DeleteByDecoderId(Database db, int DecoderId)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("delete from IVS_DecoderCamera ");
            sb.AppendFormat(" where decoder={0}", DecoderId);
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
        public static DataSet GetAllDecInfo(Database db)
        {
            string cmdText = string.Format("select * from DecoderInfo order by id");
            try
            {
                return db.ExecuteDataSet(CommandType.Text, cmdText);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public static DataSet GetDecoderInfoByDecoderId(Database db, int DecoderId)
        {
            string cmdText = string.Format("select * from DecoderInfo where id={0}", DecoderId);
            try
            {
                return db.ExecuteDataSet(CommandType.Text, cmdText);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static DataSet GetDecoderInfoByDecoderIP(Database db, string IP)
        {
            string cmdText = string.Format("select * from DecoderInfo where IP='{0}'", IP);
            try
            {
                return db.ExecuteDataSet(CommandType.Text, cmdText);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public static DataSet GetDecoderInfoByName(Database db, string Name)
        {
            string cmdText = string.Format("select * from DecoderInfo where Name='{0}' order by id", Name);
            try
            {
                return db.ExecuteDataSet(CommandType.Text, cmdText);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public static DataSet GetCameraInfoByDecoderId(Database db,int DecoderId)
        {

            string cmdText = string.Format("select * from IVS_CameraInfo where CameraId in (select camera from IVS_DecoderCamera where decoder={0})", DecoderId);
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

            string cmdText = string.Format("select * from IVS_DeviceInfo where DeviceId in (select DeviceId from IVS_CameraInfo where CameraId={0})", Id);
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

            string cmdText = string.Format("select * from IVS_CameraInfo where CameraId={0} order by CameraId", CameraId);
            try
            {
                return db.ExecuteDataSet(CommandType.Text, cmdText);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public static DataSet GetTheCamera(Database db,int CameraId)
        {

            string cmdText = string.Format("select * from IVS_DecoderCamera where camera={0}", CameraId);
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
