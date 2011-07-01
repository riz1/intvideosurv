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
            string cmdText = string.Format("select IVS_CameraInfo.*,IVS_DeviceInfo.Name as DeviceName,"+
                "IVS_displayChannelInfo.DisplayChannelId as DisplayChannelId,IVS_displayChannelInfo.DisplayChannelName as DisplayChannelName,"+
                "SynCamera.Id as CameraMonitorPairId, SynCamera.DisplaySplitScreenNo as DisplaySplitScreenNo " +
                "from (((SynCamera inner join IVS_CameraInfo on SynCamera.Cameraid=IVS_CameraInfo.cameraid) "+
                "inner join IVS_DeviceInfo on IVS_CameraInfo.deviceid =  IVS_DeviceInfo.deviceid) " +
                "inner join IVS_displayChannelInfo on SynCamera.DisplayChannelId = IVS_displayChannelInfo.DisplayChannelId) " +
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
