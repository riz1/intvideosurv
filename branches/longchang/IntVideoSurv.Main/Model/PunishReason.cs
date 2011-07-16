using DevExpress.Xpo;

namespace CameraViewer.Model
{
    [Persistent("BTOC_WZYY")]
    public class PunishReason : XPLiteObject
    {
        string fWZYYBH;
        [Size(10)]
        public string WZYYBH
        {
            get { return fWZYYBH; }
            set { SetPropertyValue<string>("WZYYBH", ref fWZYYBH, value); }
        }
        string fWZYY;
        [Key]
        public string WZYY
        {
            get { return fWZYY; }
            set { SetPropertyValue<string>("WZYY", ref fWZYY, value); }
        }
        int fPX;
        public int PX
        {
            get { return fPX; }
            set { SetPropertyValue<int>("PX", ref fPX, value); }
        }
        char fZTBJ;
        public char ZTBJ
        {
            get { return fZTBJ; }
            set { SetPropertyValue<char>("ZTBJ", ref fZTBJ, value); }
        }
        string fBZ;
        [Size(1000)]
        public string BZ
        {
            get { return fBZ; }
            set { SetPropertyValue<string>("BZ", ref fBZ, value); }
        }
        public PunishReason(Session session) : base(session) { }
        public PunishReason() : base(Session.DefaultSession) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }
}