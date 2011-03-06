namespace CameraViewer.NetWorking
{
    interface IPacketHandler
    {
        bool CanHandle(byte[] bytes);
        void Handle(byte[] bytes);
    }
}
