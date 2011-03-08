using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using IntVideoSurv.DMClient;
using SMRemotingInterface;

namespace DMClient
{
    public partial class Form1 : Form
    {
        Dictionary<int, SMCameraInfo> smCameraInfos;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //使用TCP通道得到远程对象
                TcpChannel chan1 = new TcpChannel();
                ChannelServices.RegisterChannel(chan1);
                ISMUser obj1 = (ISMUser)Activator.GetObject(
                    typeof(ISMUser),
                    string.Format("tcp://{0}:8085/SMUserService", SMClientSetting.Default.RemotingServerIP));
                if (obj1 == null)
                {
                    XtraMessageBox.Show("连接Remoting服务器失败!");
                }

                //注册
                bool ret = obj1.Login("admin", "123456");
                if (ret)
                {
                    //获取"litaiyong"用户相关的摄像头的信息
                    smCameraInfos = obj1.GetCameraInfoByUserName("litaiyong");
                }
            }
            catch (Exception ex)
            {

                XtraMessageBox.Show(ex.ToString());
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            StreamClient sc = new StreamClient();
            int iret = sc.CreatePlayer(pictureBox1.Handle);
            string smurl = string.Format(@"rtsp://{0}/", SMClientSetting.Default.RemotingServerIP);
            string camerarstp = "";
            foreach (var VARIABLE in smCameraInfos)
            {
                camerarstp = VARIABLE.Value.RstpUrl;
            }
            smurl += camerarstp;
            //sc.HIKS_OpenURL(smurl, 0);
            iret = sc.HIKS_OpenURL(@"rtsp://127.0.0.1/192.168.1.234:8000:HIK-DS8000HC:0:0:admin:12345/av_stream", 0);
            iret = sc.HIKS_Play();
        }
    }
}
