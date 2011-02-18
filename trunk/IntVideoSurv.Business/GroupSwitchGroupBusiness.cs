using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IntVideoSurv.DataAccess;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using IntVideoSurv.Entity;
using log4net;

namespace IntVideoSurv.Business
{
    public class GroupSwitchGroupBusiness
    {

        public static readonly ILog Logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private static GroupSwitchGroupBusiness _instance;
        public static GroupSwitchGroupBusiness Instance
        {
            get { return _instance ?? (_instance = new GroupSwitchGroupBusiness()); }
        }

        public int GetMaxGroupId(ref string errMessage)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            try
            {
                return GroupSwitchGroupDataAccess.GetMaxGroupSwitchGroupId(db);

            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                Logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return -1;
            }
        }

        public int Insert(ref string errMessage, GroupSwitchGroup groupSwitchGroup)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            try
            {
                return GroupSwitchGroupDataAccess.Insert(db, groupSwitchGroup);

            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                Logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return -1;
            }
        }
        public int Update(ref string errMessage, GroupSwitchGroup groupSwitchGroup)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            try
            {
                return GroupSwitchGroupDataAccess.Update(db, groupSwitchGroup);

            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                Logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return -1;
            }


        }
        public int Delete(ref string errMessage, int groupSwitchGroupId)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            try
            {
                return GroupSwitchGroupDataAccess.Delete(db, groupSwitchGroupId);

            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                Logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return -1;
            }

        }

        public Dictionary<int, GroupSwitchGroup> GetAllGroupSwitchGroups(ref string errMessage)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            var list = new Dictionary<int, GroupSwitchGroup>();
            try
            {
                GroupSwitchGroup groupSwitchGroup;
                DataSet ds = GroupSwitchGroupDataAccess.GetAllGroupSwitchGroupInfo(db);
                DataSet groupSwitchDetail;
                GroupSwitchDetailInfo groupSwitchDetailInfo;
                CameraMonitorPairInfo cameraMonitorPairInfo;
                //对于每一个群组切换的组
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    groupSwitchGroup = new GroupSwitchGroup(ds.Tables[0].Rows[i]);
                    groupSwitchDetail = GroupSwitchDetailDataAccess.GetGroupSwitchDetailByGroupSwitchId(db, groupSwitchGroup.Id);
                    groupSwitchGroup.ListGroupSwitchDetailInfo = new Dictionary<int, GroupSwitchDetailInfo>();
                    //对于一个组中的所有与同步群组有联系的记录
                    foreach (DataRow drgsdi in groupSwitchDetail.Tables[0].Rows)
                    {
                        groupSwitchDetailInfo = new GroupSwitchDetailInfo(drgsdi);
                        //根据同步群组获取同步群组与摄像机、监视器的配对信息
                        DataSet dsCamMonPair = CameraMonitorPairDataAccess.GetCameraMonitorPairBySynGroupId(db,
                                            groupSwitchDetailInfo.SynGroupId);
                        groupSwitchDetailInfo.ListCameraMonitorPair = new Dictionary<int, CameraMonitorPairInfo>();
                        foreach (DataRow drCmP in dsCamMonPair.Tables[0].Rows)
                        {
                            cameraMonitorPairInfo = new CameraMonitorPairInfo(drCmP);
                            groupSwitchDetailInfo.ListCameraMonitorPair.Add(cameraMonitorPairInfo.CameraMonitorPairId, cameraMonitorPairInfo);
                        }

                        groupSwitchGroup.ListGroupSwitchDetailInfo.Add(groupSwitchDetailInfo.Id, groupSwitchDetailInfo);
                    }

                    list.Add(groupSwitchGroup.Id, groupSwitchGroup);
                }
                return list;

            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                Logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return null;
            }
        }
        public GroupSwitchGroup GetGroupSwitchGroupById(ref string errMessage, int groupSwitchGroupId)
        {
            Database db = DatabaseFactory.CreateDatabase();
            errMessage = "";
            try
            {
                DataSet ds = GroupSwitchGroupDataAccess.GetGroupSwitchGroupById(db, groupSwitchGroupId);
                if (ds.Tables[0].Rows.Count == 0)
                {
                    return null;
                }
                var groupSwitchGroup = new GroupSwitchGroup(ds.Tables[0].Rows[0]) {ListGroupSwitchDetailInfo = new Dictionary<int, GroupSwitchDetailInfo>()};

                var groupSwitchDetail = GroupSwitchDetailDataAccess.GetGroupSwitchDetailByGroupSwitchId(db, groupSwitchGroup.Id);
                groupSwitchGroup.ListGroupSwitchDetailInfo = new Dictionary<int, GroupSwitchDetailInfo>();
                //对于一个组中的所有与同步群组有联系的记录
                foreach (DataRow drgsdi in groupSwitchDetail.Tables[0].Rows)
                {
                    var groupSwitchDetailInfo = new GroupSwitchDetailInfo(drgsdi);
                    //根据同步群组获取同步群组与摄像机、监视器的配对信息
                    DataSet dsCamMonPair = CameraMonitorPairDataAccess.GetCameraMonitorPairBySynGroupId(db,
                                        groupSwitchDetailInfo.SynGroupId);
                    groupSwitchDetailInfo.ListCameraMonitorPair = new Dictionary<int, CameraMonitorPairInfo>();
                    foreach (DataRow drCmP in dsCamMonPair.Tables[0].Rows)
                    {
                        var cameraMonitorPairInfo = new CameraMonitorPairInfo(drCmP);
                        groupSwitchDetailInfo.ListCameraMonitorPair.Add(cameraMonitorPairInfo.CameraMonitorPairId, cameraMonitorPairInfo);
                    }

                    groupSwitchGroup.ListGroupSwitchDetailInfo.Add(groupSwitchDetailInfo.Id, groupSwitchDetailInfo);
                }
                return groupSwitchGroup;

            }
            catch (Exception ex)
            {
                errMessage = ex.Message + ex.StackTrace;
                Logger.Error("Error Message:" + ex.Message + " Trace:" + ex.StackTrace);
                return null;
            }
        }



    }
}
