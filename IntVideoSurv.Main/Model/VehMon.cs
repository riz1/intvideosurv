using System;
using DevExpress.Xpo;

namespace CameraViewer.Model
{
    [Persistent("TOG_VEHMON")]
    public class TogVehmon : XPLiteObject
    {
        string fMVID;
        [Key]
        [Size(50)]
        public string MVID
        {
            get { return fMVID; }
            set { SetPropertyValue<string>("MVID", ref fMVID, value); }
        }
        long fCLXXBH;
        public long CLXXBH
        {
            get { return fCLXXBH; }
            set { SetPropertyValue<long>("CLXXBH", ref fCLXXBH, value); }
        }
        string fKKBH;
        [Size(12)]
        public string KKBH
        {
            get { return fKKBH; }
            set { SetPropertyValue<string>("KKBH", ref fKKBH, value); }
        }
        string fKKMC;
        public string KKMC
        {
            get { return fKKMC; }
            set { SetPropertyValue<string>("KKMC", ref fKKMC, value); }
        }
        string fFXBH;
        [Size(50)]
        public string FXBH
        {
            get { return fFXBH; }
            set { SetPropertyValue<string>("FXBH", ref fFXBH, value); }
        }
        string fFXMC;
        public string FXMC
        {
            get { return fFXMC; }
            set { SetPropertyValue<string>("FXMC", ref fFXMC, value); }
        }
        string fCDBH;
        [Size(50)]
        public string CDBH
        {
            get { return fCDBH; }
            set { SetPropertyValue<string>("CDBH", ref fCDBH, value); }
        }
        string fCDMC;
        [Size(50)]
        public string CDMC
        {
            get { return fCDMC; }
            set { SetPropertyValue<string>("CDMC", ref fCDMC, value); }
        }
        DateTime fJGSK;
        public DateTime JGSK
        {
            get { return fJGSK; }
            set { SetPropertyValue<DateTime>("JGSK", ref fJGSK, value); }
        }
        string fHPHM;
        [Size(15)]
        public string HPHM //车牌号码
        {
            get { return fHPHM; }
            set { SetPropertyValue<string>("HPHM", ref fHPHM, value); }
        }
        string fHPYSBH;
        [Size(1)]
        public string HPYSBH
        {
            get { return fHPYSBH; }
            set { SetPropertyValue<string>("HPYSBH", ref fHPYSBH, value); }
        }
        string fHPYS;
        [Size(50)]
        public string HPYS
        {
            get { return fHPYS; }
            set { SetPropertyValue<string>("HPYS", ref fHPYS, value); }
        }
        int fTXSL;
        public int TXSL
        {
            get { return fTXSL; }
            set { SetPropertyValue<int>("TXSL", ref fTXSL, value); }
        }
        string fTXMC1;
        public string TXMC1
        {
            get { return fTXMC1; }
            set { SetPropertyValue<string>("TXMC1", ref fTXMC1, value); }
        }
        string fTXMC2;
        public string TXMC2
        {
            get { return fTXMC2; }
            set { SetPropertyValue<string>("TXMC2", ref fTXMC2, value); }
        }
        string fTXMC3;
        public string TXMC3
        {
            get { return fTXMC3; }
            set { SetPropertyValue<string>("TXMC3", ref fTXMC3, value); }
        }
        string fTXMC4;
        public string TXMC4
        {
            get { return fTXMC4; }
            set { SetPropertyValue<string>("TXMC4", ref fTXMC4, value); }
        }
        string fSPMC;
        public string SPMC
        {
            get { return fSPMC; }
            set { SetPropertyValue<string>("SPMC", ref fSPMC, value); }
        }
        int fCLSD;
        public int CLSD
        {
            get { return fCLSD; }
            set { SetPropertyValue<int>("CLSD", ref fCLSD, value); }
        }
        string fXSZT;
        [Size(4)]
        public string XSZT
        {
            get { return fXSZT; }
            set { SetPropertyValue<string>("XSZT", ref fXSZT, value); }
        }
        string fCLPP;
        [Size(3)]
        public string CLPP
        {
            get { return fCLPP; }
            set { SetPropertyValue<string>("CLPP", ref fCLPP, value); }
        }
        string fCLWX;
        [Size(3)]
        public string CLWX
        {
            get { return fCLWX; }
            set { SetPropertyValue<string>("CLWX", ref fCLWX, value); }
        }
        string fCSYS;
        [Size(5)]
        public string CSYS
        {
            get { return fCSYS; }
            set { SetPropertyValue<string>("CSYS", ref fCSYS, value); }
        }
        decimal fCLWKC;
        public decimal CLWKC
        {
            get { return fCLWKC; }
            set { SetPropertyValue<decimal>("CLWKC", ref fCLWKC, value); }
        }
        string fCLLX;
        [Size(4)]
        public string CLLX
        {
            get { return fCLLX; }
            set { SetPropertyValue<string>("CLLX", ref fCLLX, value); }
        }
        string fCLLXMC;
        public string CLLXMC
        {
            get { return fCLLXMC; }
            set { SetPropertyValue<string>("CLLXMC", ref fCLLXMC, value); }
        }
        string fHPZL;
        [Size(2)]
        public string HPZL
        {
            get { return fHPZL; }
            set { SetPropertyValue<string>("HPZL", ref fHPZL, value); }
        }
        string fHPZLMC;
        public string HPZLMC
        {
            get { return fHPZLMC; }
            set { SetPropertyValue<string>("HPZLMC", ref fHPZLMC, value); }
        }
        string fYLXXLX;
        [Size(1)]
        public string YLXXLX
        {
            get { return fYLXXLX; }
            set { SetPropertyValue<string>("YLXXLX", ref fYLXXLX, value); }
        }
        string fYLXX;
        [Size(30)]
        public string YLXX
        {
            get { return fYLXX; }
            set { SetPropertyValue<string>("YLXX", ref fYLXX, value); }
        }
        string fCLBJ;
        [Size(1)]
        public string CLBJ
        {
            get { return fCLBJ; }
            set { SetPropertyValue<string>("CLBJ", ref fCLBJ, value); }
        }
        string fSBZT;
        [Size(1)]
        public string SBZT
        {
            get { return fSBZT; }
            set { SetPropertyValue<string>("SBZT", ref fSBZT, value); }
        }
        string fDWBH;
        [Size(4)]
        public string DWBH
        {
            get { return fDWBH; }
            set { SetPropertyValue<string>("DWBH", ref fDWBH, value); }
        }
        string fDWMC;
        [Size(200)]
        public string DWMC
        {
            get { return fDWMC; }
            set { SetPropertyValue<string>("DWMC", ref fDWMC, value); }
        }
        string fBZ;
        [Size(2000)]
        public string BZ
        {
            get { return fBZ; }
            set { SetPropertyValue<string>("BZ", ref fBZ, value); }
        }
        int fXS;
        public int XS
        {
            get { return fXS; }
            set { SetPropertyValue<int>("XS", ref fXS, value); }
        }
        decimal fCSB;
        public decimal CSB
        {
            get { return fCSB; }
            set { SetPropertyValue<decimal>("CSB", ref fCSB, value); }
        }
        string fSFCS;
        [Size(10)]
        public string SFCS
        {
            get { return fSFCS; }
            set { SetPropertyValue<string>("SFCS", ref fSFCS, value); }
        }
        string fSFNX;
        [Size(10)]
        public string SFNX
        {
            get { return fSFNX; }
            set { SetPropertyValue<string>("SFNX", ref fSFNX, value); }
        }
        char fWZBJ;
        public char WZBJ //违章标记
        {
            get { return fWZBJ; }
            set { SetPropertyValue<char>("WZBJ", ref fWZBJ, value); }
        }
        char fWZQRBJ;
        public char WZQRBJ //违章确认标记
        {
            get { return fWZQRBJ; }
            set { SetPropertyValue<char>("WZQRBJ", ref fWZQRBJ, value); }
        }
        string fWZYY;
        [Size(10)]
        public string WZYY
        {
            get { return fWZYY; }
            set { SetPropertyValue<string>("WZYY", ref fWZYY, value); }
        }
        DateTime fHDSJ;
        public DateTime HDSJ
        {
            get { return fHDSJ; }
            set { SetPropertyValue<DateTime>("HDSJ", ref fHDSJ, value); }
        }
        int fTJRQ;
        public int TJRQ //统计日期
        {
            get { return fTJRQ; }
            set { SetPropertyValue<int>("TJRQ", ref fTJRQ, value); }
        }
        string fWZWPYY;
        [Size(10)]
        public string WZWPYY
        {
            get { return fWZWPYY; }
            set { SetPropertyValue<string>("WZWPYY", ref fWZWPYY, value); }
        }
        char fTPBZ;
        public char TPBZ
        {
            get { return fTPBZ; }
            set { SetPropertyValue<char>("TPBZ", ref fTPBZ, value); }
        }
        string fCZXM;
        [Size(10)]
        public string CZXM
        {
            get { return fCZXM; }
            set { SetPropertyValue<string>("CZXM", ref fCZXM, value); }
        }
        string fCLCZY;
        [Size(50)]
        public string CLCZY
        {
            get { return fCLCZY; }
            set { SetPropertyValue<string>("CLCZY", ref fCLCZY, value); }
        }
        DateTime fCLSJ;
        public DateTime CLSJ
        {
            get { return fCLSJ; }
            set { SetPropertyValue<DateTime>("CLSJ", ref fCLSJ, value); }
        }
        string fSPMC1;
        public string SPMC1
        {
            get { return fSPMC1; }
            set { SetPropertyValue<string>("SPMC1", ref fSPMC1, value); }
        }
        string fSPMC2;
        public string SPMC2
        {
            get { return fSPMC2; }
            set { SetPropertyValue<string>("SPMC2", ref fSPMC2, value); }
        }
        public TogVehmon(Session session) : base(session) { }
        public TogVehmon() : base(Session.DefaultSession) { }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            this.MVID = Guid.NewGuid().ToString();
            this.WZBJ = '1';
            this.WZQRBJ = '0';
        }
    }

}
