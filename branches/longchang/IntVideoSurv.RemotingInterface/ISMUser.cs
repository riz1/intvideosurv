using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMRemotingInterface
{
    public interface ISMUser
    {
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="password">密码</param>
        /// <returns>true-成功；false-失败</returns>
        bool Login(string userName, string password);
        /// <summary>
        /// 用户登录成功后，通过用户名获取当前用户管辖内的摄像头信息
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <returns>摄像头List</returns>
        Dictionary<int, SMCameraInfo> GetCameraInfoByUserName(string userName);
    }
}
