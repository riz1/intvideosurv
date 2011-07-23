using System;
using DevExpress.Xpo;

namespace CameraViewer.Model
{

    public class TOG_DEVICE : XPLiteObject
    {
        string fTDID;
        [Key]
        [Size(50)]
        public string TDID
        {
            get { return fTDID; }
            set { SetPropertyValue<string>("TDID", ref fTDID, value); }
        }
        string fSBBH;
        [Size(50)]
        public string SBBH
        {
            get { return fSBBH; }
            set { SetPropertyValue<string>("SBBH", ref fSBBH, value); }
        }
        string fSBMC;
        public string SBMC
        {
            get { return fSBMC; }
            set { SetPropertyValue<string>("SBMC", ref fSBMC, value); }
        }
        string fKKMC;
        [Size(50)]
        public string KKMC
        {
            get { return fKKMC; }
            set { SetPropertyValue<string>("KKMC", ref fKKMC, value); }
        }
        string fKKBH;
        [Size(50)]
        public string KKBH
        {
            get { return fKKBH; }
            set { SetPropertyValue<string>("KKBH", ref fKKBH, value); }
        }
        string fFSBBH;
        [Size(50)]
        public string FSBBH
        {
            get { return fFSBBH; }
            set { SetPropertyValue<string>("FSBBH", ref fFSBBH, value); }
        }
        string fSBLX;
        [Size(20)]
        public string SBLX
        {
            get { return fSBLX; }
            set { SetPropertyValue<string>("SBLX", ref fSBLX, value); }
        }
        string fSBXH;
        [Size(50)]
        public string SBXH
        {
            get { return fSBXH; }
            set { SetPropertyValue<string>("SBXH", ref fSBXH, value); }
        }
        string fGYS;
        [Size(20)]
        public string GYS
        {
            get { return fGYS; }
            set { SetPropertyValue<string>("GYS", ref fGYS, value); }
        }
        DateTime fQYSJ;
        public DateTime QYSJ
        {
            get { return fQYSJ; }
            set { SetPropertyValue<DateTime>("QYSJ", ref fQYSJ, value); }
        }
        string fAZWZ;
        [Size(200)]
        public string AZWZ
        {
            get { return fAZWZ; }
            set { SetPropertyValue<string>("AZWZ", ref fAZWZ, value); }
        }
        string fSBIP;
        [Size(20)]
        public string SBIP
        {
            get { return fSBIP; }
            set { SetPropertyValue<string>("SBIP", ref fSBIP, value); }
        }
        string fTXFWQBH;
        [Size(50)]
        public string TXFWQBH
        {
            get { return fTXFWQBH; }
            set { SetPropertyValue<string>("TXFWQBH", ref fTXFWQBH, value); }
        }
        string fTXFWQIP;
        [Size(20)]
        public string TXFWQIP
        {
            get { return fTXFWQIP; }
            set { SetPropertyValue<string>("TXFWQIP", ref fTXFWQIP, value); }
        }
        string fBZ;
        [Size(2000)]
        public string BZ
        {
            get { return fBZ; }
            set { SetPropertyValue<string>("BZ", ref fBZ, value); }
        }
        string fDKH;
        [Size(10)]
        public string DKH
        {
            get { return fDKH; }
            set { SetPropertyValue<string>("DKH", ref fDKH, value); }
        }
        string fSPTDH;
        [Size(10)]
        public string SPTDH
        {
            get { return fSPTDH; }
            set { SetPropertyValue<string>("SPTDH", ref fSPTDH, value); }
        }
        string fDLYH;
        [Size(20)]
        public string DLYH
        {
            get { return fDLYH; }
            set { SetPropertyValue<string>("DLYH", ref fDLYH, value); }
        }
        string fDLMM;
        [Size(20)]
        public string DLMM
        {
            get { return fDLMM; }
            set { SetPropertyValue<string>("DLMM", ref fDLMM, value); }
        }
        public TOG_DEVICE(Session session) : base(session) { }
        public TOG_DEVICE() : base(Session.DefaultSession) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

}
