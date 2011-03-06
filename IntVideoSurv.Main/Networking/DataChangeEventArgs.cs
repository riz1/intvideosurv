namespace CameraViewer.NetWorking
{
    public class DataChangeEventArgs 
    {
        public string Name;
        public string AtmAddress;
        public string Ip;

        public DataChangeEventArgs(string n)
        {
            Name = n;
        }

        public DataChangeEventArgs(string n, string atmaddress, string ip)
        {
            Name = n;
            AtmAddress = atmaddress;
            Ip = ip;
        }
        public DataChangeEventArgs(string n, string ip)
        {
            Name = n;
            Ip = ip;
        }
    }
}
