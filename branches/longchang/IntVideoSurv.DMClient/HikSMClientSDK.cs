using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace DMClient
{
    abstract class IHikClientAdviseSink
    {

        /******************************************************************
        在Setup时被调用,获取总的播放长度.nLength为总的播放长度,以1/64秒为单位
        */
        public abstract int OnPosLength(int nLength);

        /******************************************************************
         在Setup后被调用,表示URL已经被成功打开,sucess为1表示成功,0表示失败
        */
        public abstract int OnPresentationOpened(int success);

        /************************************************************************
        在Player被停止销毁后调用
        */
        public abstract int OnPresentationClosed();

        /************************************************************************
        未使用
        */
        public abstract int OnPreSeek(uint uOldTime, uint uNewTime);

        /************************************************************************
        未使用
        */
        public abstract int OnPostSeek(uint uOldTime, uint uNewTime);

        /************************************************************************
        未使用
        */
        public abstract int OnStop();

        /************************************************************************
        在Pause时被调用，uTime目前都是0
        */
        public abstract int OnPause(uint uTime);

        /************************************************************************
         在开始播放时调用，uTime目前都是0
         */
        public abstract int OnBegin(uint uTime);

        /************************************************************************
        在随机播放时调用，uTime目前都是0
        */
        public abstract int OnRandomBegin(uint uTime);

        /************************************************************************
         在Setup前调用，pszHost表示正在连接的服务器
         */
        public abstract int OnContacting(string pszHost);

        /************************************************************************
        在服务器端返回出错信息是调用， pError中为出错信息内容
        */
        public abstract int OnPutErrorMsg(string pError);

        /************************************************************************
        未使用
         */
        public abstract int OnBuffering(uint uFlag, uint uPercentComplete);

        public abstract int OnChangeRate(int flag);

        public abstract int OnDisconnect();

    };


    public delegate int pDataRec(int sid, int iusrdata, int idatatype, string pdata, int ilen);

    public delegate int pMsgBack(int sid, int opt, int param1, int param2);

    class HikSMClientSDK
    {

        [DllImport("client.dll")]
        public static extern int HIKS_CreatePlayer(IHikClientAdviseSink pSink, IntPtr pWndSiteHandle, pDataRec pRecFunc, pMsgBack pMsgFunc, int TransMethod);

        [DllImport("client.dll")]
        public static extern int InitStreamClientLib();
        [DllImport("client.dll")]
        public static extern int FiniStreamClientLib();
        [DllImport("client.dll")]
        public static extern int HIKS_OpenURL(int hSession, string pszURL, int iusrdata);
        [DllImport("client.dll")]
        public static extern int HIKS_Play(int hSession);
        [DllImport("client.dll")]
        public static extern int HIKS_RandomPlay(int hSession, int timepos);
        [DllImport("client.dll")]
        public static extern int HIKS_Pause(int hSession);
        [DllImport("client.dll")]
        public static extern int HIKS_Resume(int hSession);
        [DllImport("client.dll")]
        public static extern int HIKS_Stop(int hSession);
        [DllImport("client.dll")]
        public static extern int HIKS_GetCurTime(int hSession, ref  ushort utime);
        [DllImport("client.dll")]
        public static extern int HIKS_ChangeRate(int hSession, int scale);
        [DllImport("client.dll")]
        public static extern int HIKS_Destroy(int hSession);
        [DllImport("client.dll")]
        public static extern int HIKS_GetVideoParams(int hSession, ref  int ibri, ref int icon, ref int isat, ref int ihue);
        [DllImport("client.dll")]
        public static extern int HIKS_SetVideoParams(int hSession, int ibri, int icon, int isat, int ihue);
        [DllImport("client.dll")]
        public static extern int HIKS_PTZControl(int hSession, ushort ucommand, int iparam1, int iparam2, int iparam3, int iparam4);
        [DllImport("client.dll")]
        public static extern int HIKS_SetVolume(int hSession, ushort volume);
        [DllImport("client.dll")]
        public static extern int HIKS_OpenSound(int hSession, bool bExclusive);
        [DllImport("client.dll")]
        public static extern int HIKS_CloseSound(int hSession);
        [DllImport("client.dll")]
        public static extern int HIKS_ThrowBFrameNum(int hSession, uint nNum);
        [DllImport("client.dll")]
        public static extern int HIKS_GrabPic(int hSession, string szPicFileName, ushort byPicType);


    }
}
