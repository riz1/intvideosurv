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
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            SendDecoderXML(3);



        }

        private byte[] BuildPackte(int type, byte[] data, int pos, int length)
        {
            byte[] byteHb = new byte[length + 16];

            //包头（格式+包长）
            byteHb[0] = byteHb[2] = 0xaa; byteHb[1] = byteHb[3] = 0x55;
            int dataLength = (length + 8);
            byteHb[4] = (byte)((dataLength & 0xff000000) >> 24); byteHb[5] = (byte)((dataLength & 0x00ff0000) >> 16);
            byteHb[6] = (byte)((dataLength & 0x0000ff00) >> 8); byteHb[7] = (byte)((dataLength & 0x000000ff));

            //数据类型
            byteHb[8] = byteHb[9] = byteHb[10] = 0;
            byteHb[11] = (byte)(type & 0x000000ff);

            //数据长度

            byteHb[12] = (byte)(((length) & 0xff000000) >> 24); byteHb[13] = (byte)(((length) & 0x00ff0000) >> 16);
            byteHb[14] = (byte)(((length) & 0x0000ff00) >> 8); byteHb[15] = (byte)(((length) & 0x000000ff));

            //
            Array.Copy(data, pos, byteHb, 16, length);

            return byteHb;

        }

        //发送解码器配置XML
        public void SendDecoderXML(int decoderid)
        {

            byte[] byteArray = System.Text.Encoding.Default.GetBytes(DecoderBusiness.Instance.GetDecoderXMLString(decoderid));

            byte[] byteHb = BuildPackte(1, byteArray, 0, byteArray.Length);


        }
    }
}
