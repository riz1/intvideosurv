using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using IntVideoSurv.Entity;

namespace IntVideoSurv.DataAccess
{
    public class CameraMonitorPairDataAccess
    {
        public static DataSet GetCameraMonitorPairBySynGroupId(Database db,int synGroupId)
        {
            string cmdText = string.Format("select CameraInfo.*,DeviceInfo.Name as DeviceName,"+
                "displayChannelInfo.DisplayChannelId as DisplayChannelId,displayChannelInfo.DisplayChannelName as DisplayChannelName,"+
                "SynCamera.Id as CameraMonitorPairId, SynCamera.DisplaySplitScreenNo as DisplaySplitScreenNo " +
                "from (((SynCamera inner join CameraInfo on SynCamera.Cameraid=CameraInfo.cameraid) "+
                "inner join DeviceInfo on CameraInfo.deviceid =  DeviceInfo.deviceid) " +
                "inner join displayChannelInfo on SynCamera.DisplayChannelId = displayChannelInfo.DisplayChannelId) " +
                "where SynCamera.SynGroupId = {0} order by SynCamera.CameraId,SynCamera.DisplayChannelId", synGroupId);
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
