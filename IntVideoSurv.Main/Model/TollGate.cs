using DevExpress.Xpo;

namespace CameraViewer.Model
{
    [Persistent("TOG_TOLLGATE")]
    public class TogTollgate : XPLiteObject
    {
        string fTGID;
        [Key]
        [Size(50)]
        public string TGID
        {
            get { return fTGID; }
            set { SetPropertyValue<string>("TGID", ref fTGID, value); }
        }
        string fKKFBH;
        [Size(12)]
        public string KKFBH
        {
            get { return fKKFBH; }
            set { SetPropertyValue<string>("KKFBH", ref fKKFBH, value); }
        }
        string fKKBH;
        [Size(12)]
        public string KKBH
        {
            get { return fKKBH; }
            set { SetPropertyValue<string>("KKBH", ref fKKBH, value); }
        }
        string fKKMC;
        [Size(40)]
        public string KKMC
        {
            get { return fKKMC; }
            set { SetPropertyValue<string>("KKMC", ref fKKMC, value); }
        }
        string fKKJC;
        [Size(40)]
        public string KKJC
        {
            get { return fKKJC; }
            set { SetPropertyValue<string>("KKJC", ref fKKJC, value); }
        }
        string fKKWZ;
        [Size(40)]
        public string KKWZ
        {
            get { return fKKWZ; }
            set { SetPropertyValue<string>("KKWZ", ref fKKWZ, value); }
        }
        string fDWBH;
        [Size(4)]
        public string DWBH
        {
            get { return fDWBH; }
            set { SetPropertyValue<string>("DWBH", ref fDWBH, value); }
        }
        string fKKLX;
        [Size(2)]
        public string KKLX
        {
            get { return fKKLX; }
            set { SetPropertyValue<string>("KKLX", ref fKKLX, value); }
        }
        int fXDSD;
        public int XDSD
        {
            get { return fXDSD; }
            set { SetPropertyValue<int>("XDSD", ref fXDSD, value); }
        }
        int fCDS;
        public int CDS
        {
            get { return fCDS; }
            set { SetPropertyValue<int>("CDS", ref fCDS, value); }
        }
        int fSXJS;
        public int SXJS
        {
            get { return fSXJS; }
            set { SetPropertyValue<int>("SXJS", ref fSXJS, value); }
        }
        string fFX;
        [Size(50)]
        public string FX
        {
            get { return fFX; }
            set { SetPropertyValue<string>("FX", ref fFX, value); }
        }
        string fDLBH;
        [Size(10)]
        public string DLBH
        {
            get { return fDLBH; }
            set { SetPropertyValue<string>("DLBH", ref fDLBH, value); }
        }
        string fDLMC;
        [Size(50)]
        public string DLMC
        {
            get { return fDLMC; }
            set { SetPropertyValue<string>("DLMC", ref fDLMC, value); }
        }
        string fDTBH;
        [Size(10)]
        public string DTBH
        {
            get { return fDTBH; }
            set { SetPropertyValue<string>("DTBH", ref fDTBH, value); }
        }
        double fDTXZB;
        public double DTXZB
        {
            get { return fDTXZB; }
            set { SetPropertyValue<double>("DTXZB", ref fDTXZB, value); }
        }
        double fDTYZB;
        public double DTYZB
        {
            get { return fDTYZB; }
            set { SetPropertyValue<double>("DTYZB", ref fDTYZB, value); }
        }
        string fDTJD;
        [Size(50)]
        public string DTJD
        {
            get { return fDTJD; }
            set { SetPropertyValue<string>("DTJD", ref fDTJD, value); }
        }
        double fDTWD;
        public double DTWD
        {
            get { return fDTWD; }
            set { SetPropertyValue<double>("DTWD", ref fDTWD, value); }
        }
        string fBZ;
        [Size(2000)]
        public string BZ
        {
            get { return fBZ; }
            set { SetPropertyValue<string>("BZ", ref fBZ, value); }
        }
        string fSXJBH;
        [Size(50)]
        public string SXJBH
        {
            get { return fSXJBH; }
            set { SetPropertyValue<string>("SXJBH", ref fSXJBH, value); }
        }
        string fXZQH;
        [Size(10)]
        public string XZQH
        {
            get { return fXZQH; }
            set { SetPropertyValue<string>("XZQH", ref fXZQH, value); }
        }
        public TogTollgate(Session session) : base(session) { }
        public TogTollgate() : base(Session.DefaultSession) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

}
