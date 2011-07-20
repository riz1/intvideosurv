using System;
using DevExpress.Xpo;

namespace CameraViewer.Model
{

    public class AORG : XPLiteObject
    {
        string fORGID;
        [Key]
        [Size(50)]
        public string ORGID
        {
            get { return fORGID; }
            set { SetPropertyValue<string>("ORGID", ref fORGID, value); }
        }
        string fPARENTID;
        [Size(50)]
        public string PARENTID
        {
            get { return fPARENTID; }
            set { SetPropertyValue<string>("PARENTID", ref fPARENTID, value); }
        }
        string fORGNAME;
        [Size(50)]
        public string ORGNAME
        {
            get { return fORGNAME; }
            set { SetPropertyValue<string>("ORGNAME", ref fORGNAME, value); }
        }
        string fORGTYPE;
        [Size(50)]
        public string ORGTYPE
        {
            get { return fORGTYPE; }
            set { SetPropertyValue<string>("ORGTYPE", ref fORGTYPE, value); }
        }
        byte fORGLEVEL;
        public byte ORGLEVEL
        {
            get { return fORGLEVEL; }
            set { SetPropertyValue<byte>("ORGLEVEL", ref fORGLEVEL, value); }
        }
        int fO;
        public int O
        {
            get { return fO; }
            set { SetPropertyValue<int>("O", ref fO, value); }
        }
        string fREMARK;
        [Size(200)]
        public string REMARK
        {
            get { return fREMARK; }
            set { SetPropertyValue<string>("REMARK", ref fREMARK, value); }
        }
        string fCREATOR;
        [Size(50)]
        public string CREATOR
        {
            get { return fCREATOR; }
            set { SetPropertyValue<string>("CREATOR", ref fCREATOR, value); }
        }
        DateTime fCREATETIME;
        public DateTime CREATETIME
        {
            get { return fCREATETIME; }
            set { SetPropertyValue<DateTime>("CREATETIME", ref fCREATETIME, value); }
        }
        string fMODIFIER;
        [Size(50)]
        public string MODIFIER
        {
            get { return fMODIFIER; }
            set { SetPropertyValue<string>("MODIFIER", ref fMODIFIER, value); }
        }
        DateTime fMODIFYTIME;
        public DateTime MODIFYTIME
        {
            get { return fMODIFYTIME; }
            set { SetPropertyValue<DateTime>("MODIFYTIME", ref fMODIFYTIME, value); }
        }
        public AORG(Session session) : base(session) { }
        public AORG() : base(Session.DefaultSession) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }
    public static class Ora_remoteSprocHelper
    {
    }


}
