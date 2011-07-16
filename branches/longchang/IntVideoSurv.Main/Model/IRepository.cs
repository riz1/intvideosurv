using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CameraViewer.Model
{
    public class Repository
    {
        private Dictionary<string, Camera> _cameras = new Dictionary<string, Camera>();
        private static Repository _instance;

        public Camera GetCamera(string cameraId)
        {
            if (_cameras.ContainsKey(cameraId))
            {
                return _cameras[cameraId];
            }

            var query = string.Format(
                "select a.kkbh, a.kkmc, b.kkbh fxbh, b.kkmc fxmc, c.kkbh cdbh, c.kkmc cdmc,a.dlbh, a.dlmc, a.lkdm, a.lkmc,a.dwbh, a.xzqh, a.kkwz, c.sxjbh from tog_tollgate a, tog_tollgate b, tog_tollgate c where a.kkbh=b.kkfbh and b.kkbh=c.kkfbh and a.kkbh<>'moniroot' and c.sxjbh = '{0}'", cameraId);
            var res = DevExpress.Xpo.XpoDefault.Session.ExecuteQuery(query);
            if (res.ResultSet.Length > 0)
            {
                if (res.ResultSet[0].Rows.Length >= 0)
                {
                    var c = new Camera()
                                {
                                    No = cameraId,

                                    KaKouNo = res.ResultSet[0].Rows[0].Values[0].ToString(),
                                    KakouName = res.ResultSet[0].Rows[0].Values[1].ToString(),

                                    DirectionNo = res.ResultSet[0].Rows[0].Values[2].ToString(),
                                    DirectionName = res.ResultSet[0].Rows[0].Values[3].ToString(),

                                    LaneNo = res.ResultSet[0].Rows[0].Values[4].ToString(),
                                    LaneName = res.ResultSet[0].Rows[0].Values[5].ToString(),
                                };
                    _cameras.Add(cameraId, c);
                    return c;
                }
            }

            return null;
        }

        public static Repository Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Repository();
                }

                return _instance;
            }
        }
    }
}
