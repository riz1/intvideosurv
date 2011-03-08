using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using IntVideoSurv.Business;

namespace CameraViewer
{
    public partial class JustForTest : Form
    {
        public JustForTest()
        {
            InitializeComponent();
            string ret = DecoderBusiness.Instance.GetDecoderXMLString(3);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            SendDecoderStopCommand();
        }

        private byte[] BuildPackte(int type, byte[] data, int pos, int length)
        {
            int dataLength = (length + 8);
            byte[] byteHb = new byte[dataLength+8];

            //包头（格式+包长）
            byteHb[0] = byteHb[2] = 0xaa; byteHb[1] = byteHb[3] = 0x55;
            Array.Copy(BitConverter.GetBytes(dataLength), 0, byteHb, 4, 4); 
            
            //数据类型

            Array.Copy(BitConverter.GetBytes(type),0,byteHb,8, 4); 

            //数据长度
            Array.Copy(BitConverter.GetBytes(length), 0, byteHb, 12, 4); 

            //真实数据
            Array.Copy(data, pos, byteHb, 16, length);

            return byteHb;

        }

        //发送解码器配置XML
        public void SendDecoderXML(int decoderid)
        {

            byte[] byteArray = System.Text.Encoding.Default.GetBytes(DecoderBusiness.Instance.GetDecoderXMLString(decoderid));

            byte[] byteHb = BuildPackte(1, byteArray, 0, byteArray.Length);


        }

        public void SendDecoderStopCommand()
        {
            byte[] bytes = new byte[0];
            byte[] byteHb = BuildPackte(3, bytes, 0, 0);

        }
    }
}
