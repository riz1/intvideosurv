using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;


namespace DMClient
{

    class StreamClient : IHikClientAdviseSink
    {
        //private inheritAdviseSink adviseSink;
        /// <summary>
        /// 播放的总时间
        /// </summary>
        private int m_totaltime;
        /// <summary>
        /// url是否被打开
        /// </summary>
        private int m_opened;

        /// <summary>
        /// 播放句柄
        /// </summary>
        private int playSession = -1;

        public StreamClient()
        {
            int ok;
             ok= HikSMClientSDK.InitStreamClientLib();
             if (ok == -1)
             {
                 MessageBox.Show("初始化失败！");
             }

        }
        /// <summary>
        /// 关闭是调用
        /// </summary>
        public void FiniStreamClientLib()
        {
            HikSMClientSDK.FiniStreamClientLib();
        }

        /// <summary>
        /// 开始之前调用
        /// </summary>
        public int CreatePlayer(IntPtr mHand)
        {
            pMsgBack mb = new pMsgBack(MsgBack);

            playSession = HikSMClientSDK.HIKS_CreatePlayer(null, mHand, null, mb, 1);

            if (playSession == -1)
            {
                MessageBox.Show("创建play句柄失败！");
            }

            return playSession;

        }
        /// <summary>
        /// 根据URL，连接服务器
        /// </summary>
        /// <param name="hSession">。hSession 是Player 的标示，应该设置为HIKS_CreatePlayer 成功返回的新建Player 的标示</param>
        /// <param name="pszURL">pszURL 即为服务器的地址</param>
        /// <param name="iusrdata">iusrdata 为用户数据。</param>
        /// <returns>返回值：成功返回 1，失败返回-1。</returns>
        public int HIKS_OpenURL(string pszURL, int iusrdata)
        {
            int ok;

            ok = HikSMClientSDK.HIKS_OpenURL(playSession, pszURL, iusrdata);

            if (ok == -1)
            {
                MessageBox.Show("连接服务器失败！");

            }
            else
            {

            }

            return ok;


        }

        private int  MsgBack(int sid, int opt, int param1, int param2)
        {

            int len = -1;
            switch (opt)
            {
                case 1:
                    m_totaltime = param1;
                    break;
                case 2:
                    m_opened = param1;
                    break;
                case 3:
                    break;
                case 4:
                    break;
                case 5:
                    break;
                case 6:
                    break;
                case 7:
                    break;
                case 8:
                    break;
                case 9:
                    break;
                case 10:

                    break;
                case 11:
                    break;
                case 12:
                    break;
                case 13:
                    //m_speeded = true;
                    break;
                case 14:
                    //PostMessage(WM_DISCONNECT,0,0);
                    break;
                default:
                    break;
            }
            return 0;
        }

        /// <summary>
        /// 播放
        /// </summary>
        /// <returns></returns>
        public int HIKS_Play()
        {
            int ok = HikSMClientSDK.HIKS_Play(playSession);


            if (ok == -1)
            {
                MessageBox.Show("播放失败！");


            }
            else
            {

            }

            return ok;

        }
        /// <summary>
        /// 停止播放
        /// </summary>
        /// <returns></returns>
        public int HIKS_Pause()
        {
            return HikSMClientSDK.HIKS_Pause(playSession);

        }

        public int HIKS_Resume()
        {
            int ok = HikSMClientSDK.HIKS_Resume(playSession);


            if (ok == -1)
            {
                MessageBox.Show("恢复播放失败！");


            }
            else
            {

            }

            return ok;

        }
        public int HIKS_Stop()
        {

            int ok = HikSMClientSDK.HIKS_Stop(playSession);


            if (ok == -1)
            {
                MessageBox.Show("停止播放失败！");


            }
            else
            {

            }

            return ok;

        }
        public int HIKS_GetCurTime(ref  ushort utime)
        {
            int ok = HikSMClientSDK.HIKS_GetCurTime(playSession, ref utime);


            if (ok == -1)
            {
                MessageBox.Show("获取播放时间失败！");


            }
            else
            {

            }

            return ok;

        }
        /// <summary>
        /// 作用：改变播放速率,在快进或慢进的时候用。
        /// </summary>
        /// <param name="scale"></param>
        /// <returns>返回值：成功返回 0，失败返回-1。</returns>
        public int HIKS_ChangeRate(int scale)
        {
            int ok = HikSMClientSDK.HIKS_ChangeRate(playSession,2);


            if (ok == -1)
            {
                MessageBox.Show("改变速度失败！");


            }
            else
            {

            }

            return ok;

        }
        /// <summary>
        /// 作用：销毁Player，只在HIKS_OpenURL 函数失败的请况下调用。
        /// </summary>
        /// <returns>返回值：成功返回 0，失败返回-1。</returns>
        public int HIKS_Destroy()
        {
            int ok = HikSMClientSDK.HIKS_Destroy(playSession);


            if (ok == -1)
            {
                MessageBox.Show("销毁失败！");


            }
            else
            {

            }

            return ok;

        }

        /// <summary>
        /// 声音控制
        /// </summary>
        /// <param name="volume"></param>
        /// <returns></returns>
        public int HIKS_SetVolume(ushort volume)
        {

            return HikSMClientSDK.HIKS_SetVolume(playSession, volume);
        }

        /// <summary>
        /// 作用：打开声音播放。hSession 是Player 的标示。bExclusive 表示打开声音
        //的方式，false 表示共享打开，true 表示独占打开。
        /// </summary>
        /// <param name="bExclusive"></param>
        /// <returns></returns>
        public int HIKS_OpenSound(bool bExclusive)
        {
            return HikSMClientSDK.HIKS_OpenSound(playSession, bExclusive);

        }
        /// <summary>
        ///关闭声音
        /// </summary>
        /// <returns></returns>
        public int HIKS_CloseSound()
        {
            return HikSMClientSDK.HIKS_CloseSound(playSession);

        }
        /// <summary>
        /// ：本地抓图。hSession 表示Player 的标示。szPicFileName 表示文件名。
        //byPicType 表示图片的类型，0 表示bmp 图片，1 表示jpeg 图片。
        /// </summary>
        /// <param name="szPicFileName"></param>
        /// <param name="byPicType"></param>
        /// <returns></returns>
        public int HIKS_GrabPic(string szPicFileName, ushort byPicType)
        {
            Random ra=new Random();
            return HikSMClientSDK.HIKS_GrabPic(playSession,System.DateTime.Now.Date.ToString() + System.DateTime.Now.Minute.ToString() + System.DateTime.Now.Second.ToString() + ra.Next().ToString(), 0);

        }

        /// <summary>
        /// 作用：获取视频参数。hSession 是Player 的标示
        /// </summary>
        /// <param name="ibri">是亮度</param>
        /// <param name="icon">是对比度</param>
        /// <param name="isat">是饱和度</param>
        /// <param name="ihue">是色调</param>
        /// <returns>成功返回 0，失败返回-1。</returns>
        public int HIKS_GetVideoParams(ref  int ibri, ref int icon, ref int isat, ref int ihue)
        {

            return HikSMClientSDK.HIKS_GetVideoParams(playSession,ref  ibri, ref icon, ref isat, ref ihue);
        }
        /// <summary>
        /// 作用：设置视频参数。hSession 是Player 的标示, ibri 是亮度，icon 是对比度，
        ///值域范围：ibri 1-10, icon 1-10, isat 1-10, ihue 1-10。
        /// </summary>
         /// <param name="ibri">是亮度</param>
        /// <param name="icon">是对比度</param>
        /// <param name="isat">是饱和度</param>
        /// <param name="ihue">是色调</param>
        /// <returns>成功返回 0，失败返回-1。</returns>
        public int HIKS_SetVideoParams(int ibri, int icon, int isat, int ihue)
        {

            return HikSMClientSDK.HIKS_SetVideoParams( playSession,  ibri,  icon,  isat,  ihue);
        }

        /// <summary>
        /// 云台控制
        /// </summary>
        /// <param name="ucommand"></param>
        /// <param name="iparam1"></param>
        /// <param name="iparam2"></param>
        /// <param name="iparam3"></param>
        /// <param name="iparam4"></param>
        /// <returns></returns>
        public int HIKS_PTZControl(ushort ucommand, int iparam1, int iparam2, int iparam3, int iparam4)
        {
            return HikSMClientSDK.HIKS_PTZControl(playSession,ucommand, iparam1,  iparam2,  iparam3,  iparam4);
        }

        /// <summary>
        /// 随即播放
        /// </summary>
        /// <param name="timepos"></param>
        /// <returns></returns>
        public int HIKS_RandomPlay(int timepos)
        {
            return 0;

        }

        public override int OnPosLength(int nLength)
        {
            return 0;
        }

        public override int OnPresentationOpened(int success)
        {
            return 0;
        }

        public override int OnPresentationClosed()
        {
            return 0;
        }

        public override int OnPreSeek(uint uOldTime, uint uNewTime)
        {
            return 0;
        }

        public override int OnPostSeek(uint uOldTime, uint uNewTime)
        {
            return 0;
        }

        public override int OnStop()
        {
            return 0;
        }

        public override int OnPause(uint uTime)
        {
            return 0;
        }

        public override int OnBegin(uint uTime)
        {
            return 0;
        }

        public override int OnRandomBegin(uint uTime)
        {
            return 0;
        }

        public override int OnContacting(string pszHost)
        {
            return 0;
        }

        public override int OnPutErrorMsg(string pError)
        {
            return 0;
        }

        public override int OnBuffering(uint uFlag, uint uPercentComplete)
        {
            return 0;
        }

        public override int OnChangeRate(int flag)
        {
            return 0;
        }

        public override int OnDisconnect()
        {
            return 0;
        }


    }
}
