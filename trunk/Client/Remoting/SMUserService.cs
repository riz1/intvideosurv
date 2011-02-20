using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IntVideoSurv.Business;
using SMRemotingInterface;

namespace CameraViewer.Remoting
{
    class SMUserService : MarshalByRefObject, ISMUser
    {
        private string errMessage = "";
        public bool Login(string userName, string password)
        {
            return UserBusiness.Instance.IsUserValid(ref errMessage, userName, password);
        }

        Dictionary<int, SMCameraInfo> ISMUser.GetCameraInfoByUserName(string userName)
        {
            return CameraBusiness.Instance.GetAllCameraInfoByUsername(ref errMessage, userName);
        }
    }
}
