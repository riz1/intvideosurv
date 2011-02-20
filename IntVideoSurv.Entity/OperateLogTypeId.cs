using System;

namespace IntVideoSurv.Entity
{
    [Serializable]
    public enum OperateLogTypeId
    {
        UserAdd = 1001,
        UserUpdate,
        UserDelete,

        SynGroupAdd = 1101,
        SynGroupUpdate,
        SynGroupDelete,

        GroupSwitchAdd = 1201,
        GroupSwitchUpdate,
        GroupSwitchDelete,

        GroupSwitchDetailAdd = 1301,
        GroupSwitchDetailUpdate,
        GroupSwitchDetailDelete,

        ProgSwitchAdd = 1401,
        ProgSwitchUpdate,
        ProgSwitchDelete,

        ProgSwitchDetailAdd = 1501,
        ProgSwitchGroupUpdate,
        ProgSwitchGroupDelete,

        GroupAdd = 1601,
        GroupUpdate,
        GroupDelete,

        DeviceAdd = 1701,
        DeviceUpdate,
        DeviceDelete,

        CameraAdd = 1801,
        CameraUpdate,
        CameraDelete

    }
}