using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using IntVideoSurv.Entity;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace IntVideoSurv.DataAccess
{
    public class AnalysisXMLDataAccess
    {
        public static int InsertCapturePicture(Database db,CapturePicture ocapturePicture)
        {
            StringBuilder sbField = new StringBuilder();
            StringBuilder sbValue = new StringBuilder();
            sbField.Append("INSERT INTO  [CapturePicture](");
            sbValue.Append("values (");
            //sbField.Append("[PictureID]");
            //sbValue.AppendFormat("'{0}'", ocapturePicture.PictureID);
            sbField.Append("[CameraID]");
            sbValue.AppendFormat("{0}", ocapturePicture.CameraID);
            sbField.Append(",[Datetime]");
            //sbValue.AppendFormat(",'{0}'", ocapturePicture.Datetime);
            sbValue.AppendFormat(",'{0}'", ocapturePicture.Datetime);
            sbField.Append(",[FilePath])");
            sbValue.AppendFormat(",'{0}')", ocapturePicture.FilePath);

            string cmdText = sbField.ToString() + " " + sbValue.ToString();

            try
            {
                cmdText = cmdText.Replace("\r\n", "");
                db.ExecuteNonQuery(CommandType.Text, cmdText);
                //string cmdText2 = "select max(PictureID) from CapturePicture";
                //return int.Parse(db.ExecuteScalar(CommandType.Text, cmdText2).ToString());
                int id = int.Parse(db.ExecuteScalar(CommandType.Text, "SELECT     ident_current('CapturePicture')").ToString());
                return id;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public static int InsertVehicle(Database db, Vehicle oVehicle)
        {
            StringBuilder sbField = new StringBuilder();
            StringBuilder sbValue = new StringBuilder();
            sbField.Append("INSERT INTO  [Vehicle](");
            sbValue.Append("values (");
            sbField.Append("[VehicleID]");
            sbValue.AppendFormat("{0}", oVehicle.VehicleID);
            sbField.Append(",[platenumber]");
            sbValue.AppendFormat(",'{0}'", oVehicle.platenumber);
            sbField.Append(",[speed]");
            sbValue.AppendFormat(",{0}", oVehicle.speed);
            if (oVehicle.stemagainst==true)
            {
                sbField.Append(",[stemagainst]");
                sbValue.AppendFormat(",{0}", 1);
            }
            else
            {
                sbField.Append(",[stemagainst]");
                sbValue.AppendFormat(",{0}", 0);
            }
            if (oVehicle.stop == true)
            {
                sbField.Append(",[stop]");
                sbValue.AppendFormat(",{0}", 1);
            }
            else
            {
                sbField.Append(",[stop]");
                sbValue.AppendFormat(",{0}", 0);
            }
            if (oVehicle.accident == true)
            {
                sbField.Append(",[accident]");
                sbValue.AppendFormat(",{0}", 1);
            } 
            else
            {
                sbField.Append(",[accident]");
                sbValue.AppendFormat(",{0}", 0);
            }
            if (oVehicle.linechange == true)
            {
                sbField.Append(",[linechange]");
                sbValue.AppendFormat(",{0}", 1);
            } 
            else
            {
                sbField.Append(",[linechange]");
                sbValue.AppendFormat(",{0}", 0);
            }
            sbField.Append(",[platecolor]");
            sbValue.AppendFormat(",'{0}'", oVehicle.platecolor);
            sbField.Append(",[vehiclecolor]");
            sbValue.AppendFormat(",'{0}'", oVehicle.vehiclecolor);
            sbField.Append(",[PictureID]");
            sbValue.AppendFormat(",{0}", oVehicle.PictureID);
            sbField.Append(",[REctId])");
            sbValue.AppendFormat(",{0})", oVehicle.REctId);

            string cmdText = sbField.ToString() + " " + sbValue.ToString();

            try
            {
                cmdText = cmdText.Replace("\r\n", "");
                return db.ExecuteNonQuery(CommandType.Text, cmdText);
                //获得倒数第二条记录
                //int id = int.Parse(db.ExecuteScalar(CommandType.Text, "select top 2 VehicleID from Vehicle").ToString());
                //return id;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public static int InsertFace(Database db, Face oFace)
        {
            StringBuilder sbField = new StringBuilder();
            StringBuilder sbValue = new StringBuilder();
            sbField.Append("INSERT INTO  [Face](");
            sbValue.Append("values (");
            //sbField.Append("[FaceID]");
            //sbValue.AppendFormat("'{0}'", oFace.FaceID);
            sbField.Append("[score]");
            sbValue.AppendFormat("'{0}'", oFace.score);
            sbField.Append(",[RectID]");
            sbValue.AppendFormat(",{0}", oFace.RectID);
            sbField.Append(",[PictureID])");
            sbValue.AppendFormat(",{0})", oFace.PictureID);
            string cmdText = sbField.ToString() + " " + sbValue.ToString();

            try
            {
                cmdText = cmdText.Replace("\r\n", "");
                db.ExecuteNonQuery(CommandType.Text, cmdText);
                int id = int.Parse(db.ExecuteScalar(CommandType.Text, "SELECT     ident_current('Face')").ToString());
                return id;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public static int InsertREct(Database db, REct oRect)
        {
            StringBuilder sbField = new StringBuilder();
            StringBuilder sbValue = new StringBuilder();
            sbField.Append("INSERT INTO  [REct](");
            sbValue.Append("values (");
            //sbField.Append("[RectID]");
            //sbValue.AppendFormat("'{0}'", oRect.RectID);
            sbField.Append("[X]");
            sbValue.AppendFormat("{0}", oRect.X);
            sbField.Append(",[Y]");
            sbValue.AppendFormat(",{0}", oRect.Y);
            sbField.Append(",[W]");
            sbValue.AppendFormat(",{0}", oRect.W);
            sbField.Append(",[H])");
            sbValue.AppendFormat(",{0})", oRect.H);
            string cmdText = sbField.ToString() + " " + sbValue.ToString();

            try
            {
                cmdText = cmdText.Replace("\r\n", "");
                db.ExecuteNonQuery(CommandType.Text, cmdText);
                int id = int.Parse(db.ExecuteScalar(CommandType.Text, "SELECT     ident_current('REct')").ToString());
                return id;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public static int InsertTrack(Database db, Track oTrack)
        {
            StringBuilder sbField = new StringBuilder();
            StringBuilder sbValue = new StringBuilder();
            sbField.Append("INSERT INTO  [Track](");
            sbValue.Append("values (");
            //sbField.Append("[Id]");
            //sbValue.AppendFormat("'{0}'", oTrack.Id);
            sbField.Append("[REct])");
            sbValue.AppendFormat("'{0}')", oTrack.REct);
            string cmdText = sbField.ToString() + " " + sbValue.ToString();

            try
            {
                cmdText = cmdText.Replace("\r\n", "");
                db.ExecuteNonQuery(CommandType.Text, cmdText);
                int id = int.Parse(db.ExecuteScalar(CommandType.Text, "SELECT     ident_current('Track')").ToString());
                return id;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
