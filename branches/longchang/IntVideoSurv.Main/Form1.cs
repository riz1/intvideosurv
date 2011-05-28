using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;

namespace CameraViewer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            multiplexer1.CloseAll();
            multiplexer1.CamerasVisible = true;
            multiplexer1.CellWidth = 320;
            multiplexer1.CellHeight = 240;
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    // get camera

                    Camera camera = new Camera("aa");
                    multiplexer1.SetCamera(i, j, camera);


                }
            }

            multiplexer1.Rows = 2;
            multiplexer1.Cols = 2;
            multiplexer1.SingleCameraMode = false;
            multiplexer1.CamerasVisible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string uri = @"http://192.168.1.201/liveimg.cgi?" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"); ;
            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(uri);
            req.Credentials = new NetworkCredential("admin", "admin");
            req.KeepAlive = true;

            string line = "";
             int	bufSize = 512 * 1024;	// buffer size
		    int	readSize = 1024;		// portion size to read
            HttpWebResponse reply = (HttpWebResponse)req.GetResponse();
            Stream stream = reply.GetResponseStream();
            
           
            System.Diagnostics.Debug.WriteLine(reply.ContentType);
            int read, total = 0;

            byte[] buffer = new byte[bufSize];	// buffer to read stream
            int bytesReceived = 0;
            while (true)
            {
                // check total read
                if (total > bufSize - readSize)
                {
                    total = 0;
                }

                // read next portion from stream
                if ((read = stream.Read(buffer, total, readSize)) == 0)
                    break;

                total += read;

                // increment received bytes counter
                bytesReceived += read;
            }
            
            StreamReader reader = new StreamReader(stream);
            do
            {
                line = reader.ReadLine();
                System.Diagnostics.Debug.WriteLine(line);

                System.Threading.Thread.Sleep(300);

            } while (line.Length > 0); 
        }
    }
}
