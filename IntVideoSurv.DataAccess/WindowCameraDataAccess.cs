using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using IntVideoSurv.Entity;

namespace IntVideoSurv.DataAccess
{
    public class WindowCameraDataAccess
    {
        public static int Insert(Database db, WindowCameraInfo windowCameraInfo)
        {

            StringBuilder sbField = new StringBuilder();
            StringBuilder sbValue = new StringBuilder();
            sbField.Append("INSERT INTO  WindowCameraInfo(");
            sbValue.Append("values (");
            sbField.Append("row");
            sbValue.AppendFormat("{0}", windowCameraInfo.Row);
            sbField.Append(",col");
            sbValue.AppendFormat(",{0}", windowCameraInfo.Col);
            sbField.Append(",Camera)");
            sbValue.AppendFormat(",{0})", windowCameraInfo.CameraId);

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
        
        public static int Update(Database db, int id, int camera)
        {

            StringBuilder sbValue = new StringBuilder();
            sbValue.Append("update WindowCameraInfo set ");
            sbValue.AppendFormat("Camera={0}", camera);
            sbValue.AppendFormat(" where Id={0}", id);
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

        public static int Update(Database db, int row, int col, int camera)
        {

            StringBuilder sbValue = new StringBuilder();
            sbValue.Append("update WindowCameraInfo set ");
            sbValue.AppendFormat("Camera={0}", camera);
            sbValue.AppendFormat(" where row={0} and col={1}", row, col);
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

        public static int Delete(Database db, int id)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("delete from WindowCameraInfo ");
            sb.AppendFormat(" where Id={0}", id);
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

        public static DataSet GetAllWindowCameraInfo(Database db)
        {
            string cmdText = string.Format("select * from WindowCameraInfo order by Id");
            try
            {
                return db.ExecuteDataSet(CommandType.Text, cmdText);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static DataSet GetWindowCameraInfoById(Database db, int id)
        {
            string cmdText = string.Format("select * from WindowCameraInfo where Id={0}", id);
            try
            {
                return db.ExecuteDataSet(CommandType.Text, cmdText);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static DataSet GetWindowCameraInfoByCamera(Database db, int camera)
        {
            string cmdText = string.Format("select * from WindowCameraInfo where Camera={0}", camera);
            try
            {
                return db.ExecuteDataSet(CommandType.Text, cmdText);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static DataSet GetWindowCameraInfoByRowCol(Database db, int row, int col)
        {
            string cmdText = string.Format("select * from WindowCameraInfo where row={0} and col={1}", row, col);
            try
            {
                return db.ExecuteDataSet(CommandType.Text, cmdText);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static bool IsWindowCameraExisted(Database db, int row, int col)
        {
            string cmdText = string.Format("select count(*) from WindowCameraInfo where row={0} and col={1}", row, col);
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
