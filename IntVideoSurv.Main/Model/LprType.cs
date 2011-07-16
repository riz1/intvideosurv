using DevExpress.Xpo;

namespace CameraViewer.Model
{
    [Persistent("TOC_LPTTYPE")]
    public class LprType : XPLiteObject
    {
        string fHPZLDM;
        [Key]
        [Size(2)]
        public string HPZLDM
        {
            get { return fHPZLDM; }
            set { SetPropertyValue<string>("HPZLDM", ref fHPZLDM, value); }
        }
        string fHPMC;
        [Size(50)]
        [DisplayName("号牌类型")]
        public string HPMC
        {
            get { return fHPMC; }
            set { SetPropertyValue<string>("HPMC", ref fHPMC, value); }
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
        [Size(2000)]
        public string BZ
        {
            get { return fBZ; }
            set { SetPropertyValue<string>("BZ", ref fBZ, value); }
        }
        public LprType(Session session) : base(session) { }
        public LprType() : base(Session.DefaultSession) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

}
