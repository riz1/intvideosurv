using System;

namespace IntVideoSurv.Entity
{
    [Serializable]
    public class OperateLogTypeName
    {
        public const string UserAdd = "添加用户";
        public const string UserUpdate = "更新用户";
        public const string UserDelete = "删除用户";

        public const string SynGroupAdd = "添加同步群组";
        public const string SynGroupUpdate = "更新同步群组";
        public const string SynGroupDelete = "删除同步群组";

        public const string GroupSwitchAdd = "添加群组切换";
        public const string GroupSwitchUpdate = "更新群组切换";
        public const string GroupSwitchDelete = "删除群组切换";

        public const string GroupSwitchDetailAdd = "添加群组切换细节";
        public const string GroupSwitchDetailUpdate = "更新群组切换细节";
        public const string GroupSwitchDetailDelete = "删除群组切换细节";

        public const string ProgSwitchAdd = "添加程序切换";
        public const string ProgSwitchUpdate = "更新程序切换";
        public const string ProgSwitchDelete = "删除程序切换";

        public const string ProgSwitchDetailAdd = "添加程序切换细节";
        public const string ProgSwitchDetailUpdate = "更新程序切换细节";
        public const string ProgSwitchDetailDelete = "删除程序切换细节";

        public const string GroupAdd = "添加群组";
        public const string GroupUpdate = "更新群组";
        public const string GroupDelete = "删除群组";

        public const string DeviceAdd = "添加设备";
        public const string DeviceUpdate = "更新设备";
        public const string DeviceDelete = "删除设备";

        public const string CameraAdd = "添加摄像头";
        public const string CameraUpdate = "更新摄像头";
        public const string CameraDelete = "删除摄像头";
        //解码器添加，删除，更新信息
        public const string DecoderAdd = "添加解码器";
        public const string DecoderUpdate = "更新解码器";
        public const string DecoderDelete = "删除解码器";
        //摄像头在解码器中的添加，删除，更新
        public const string CameraAddInDecoder = "添加摄像头";
        public const string CameraUpdateInDecoder = "更新摄像头";
        public const string CameraDeleteInDecoder = "删除摄像头";
        //识别器添加、更新、删除
        public const string RecognizerAdd = "添加识别器";
        public const string RecognizerUpdate = "更新识别器";
        public const string RecognizerDelete = "删除识别器";
        //
        public const string CameraAddInRecognizer = "添加摄像头";
        public const string CameraUpdateInRecognizer = "更新摄像头";
        public const string CameraDeleteInRecognizer = "删除摄像头";
        public const string CameraAddInVirtualGroup = "添加摄像头到VirtualGroup";

        public const string UserAddInVirtualGroup = "添加用户到VirtualGroup";
        public const string UserDeleteInVirtualGroup = "删除在virtualgroup中的用户";
        //
        public const string TollGateKaKouAdd = "添加卡口";
        public const string TollGateKaKouDelete = "删除卡口";
        public const string TollGateKaKouUpdate = "更新卡口";
        //添加、删除、修改车道
        public const string TollGateCheDaoAdd = "添加车道";
        public const string TollGateCheDaoUpdate = "更新车道";
        public const string TollGateCheDaoDelete = "删除车道";
        public const string TollGateFangXiangAdd = "添加方向";
        public const string TollGateFangXiangUpdate = "更新方向";
        public const string TollGateFangXiangDelete = "删除方向";
        //
        public const string ToGDeviceAdd = "添加ToGDevice";
        public const string ToGDeviceUpdate = "更新ToGDevice";
        public const string ToGDeviceDelete = "删除ToGDevice";

    }
}