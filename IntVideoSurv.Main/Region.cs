using System;
using DevExpress.Xpo;
namespace ora
{

    public class TOC_REGION : XPLiteObject
    {
        string fXZQHDM;
        [Key]
        [Size(10)]
        public string XZQHDM
        {
            get { return fXZQHDM; }
            set { SetPropertyValue<string>("XZQHDM", ref fXZQHDM, value); }
        }
        string fXZQH;
        public string XZQH
        {
            get { return fXZQH; }
            set { SetPropertyValue<string>("XZQH", ref fXZQH, value); }
        }
        int fPX;
        public int PX
        {
            get { return fPX; }
            set { SetPropertyValue<int>("PX", ref fPX, value); }
        }
        public TOC_REGION(Session session) : base(session) { }
        public TOC_REGION() : base(Session.DefaultSession) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

}
