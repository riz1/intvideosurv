using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;

namespace CameraViewer
{
    public static class YUV2RGB
    {
        private static long[] U = new long[256];
        private static long[] V = new long[256];
        private static long[] Y1 = new long[256];
        private static long[] Y2 = new long[256];

        static YUV2RGB()
        {
            for (int i = 0; i < 256; i++)
            {
                V[i] = 15938 * i - 2221300;
                U[i] = 20238 * i - 2771300;
                Y1[i] = 11644 * i;
                Y2[i] = 19837 * i - 311710;

            }
        }

        public static Bitmap GetBitmapFromYUVFile(string filename, int width, int height)
        {
            var inStream = new FileStream(filename, FileMode.Open, FileAccess.Read);
            long nBytesToRead = width*height*3/2;
            var buffer = new byte[nBytesToRead];
            int m = inStream.Read(buffer, 0, buffer.Length);
            var byteRGB = YUV420ToRGB(width, height, buffer);
            return GetDataPicture(width, height, byteRGB);
        }

        public static Bitmap GetBitmapFromYUVStream(int width, int height, byte[] pYuvBuf)
        {
            var byteRGB = YUV420ToRGB(width, height, pYuvBuf);
            return GetDataPicture(width, height, byteRGB);
        }

        private static byte[] YUV420ToRGB (int width, int height, byte[] pYuvBuf)
        {
            int rgbSize = width*height*3;
            var byteRgb= new byte[rgbSize];
            int iUbase;
            int i;
            int iY = 0;
            int iU = iUbase = width*height;
            int iV = iUbase+width*height/4;
            for (i = 0; i < height; i++)
            {
                int iB = rgbSize - 3 * width * (i + 1);
                int iG = rgbSize - 3 * width * (i + 1) + 1;
                int iR = rgbSize -3 * width * (i + 1) + 2;
                int j;
                for (j = 0; j < width; j+=2)
                {
                    byteRgb[iR] = (byte)(Math.Max(0, Math.Min(255, (V[pYuvBuf[iV]] + Y1[pYuvBuf[iY]]) / 10000)));
                    byteRgb[iB] = (byte)(Math.Max(0, Math.Min(255, (U[pYuvBuf[iU]] + Y1[pYuvBuf[iY]]) / 10000)));
                    byteRgb[iG] = (byte)(Math.Max(0, Math.Min(255, (Y2[pYuvBuf[iY]] - 5094 * byteRgb[iR] - 1942 * byteRgb[iB]) / 10000)));
                    iR += 3;
                    iB += 3;
                    iG += 3;
                    iY++;

                    byteRgb[iR] = (byte)(Math.Max(0, Math.Min(255, (V[pYuvBuf[iV]] + Y1[pYuvBuf[iY]]) / 10000)));
                    byteRgb[iB] = (byte)(Math.Max(0, Math.Min(255, (U[pYuvBuf[iU]] + Y1[pYuvBuf[iY]]) / 10000)));
                    byteRgb[iG] = (byte)(Math.Max(0, Math.Min(255, (Y2[pYuvBuf[iY]] - 5094 * byteRgb[iR] - 1942 * byteRgb[iB]) / 10000)));
                    iR += 3;
                    iB += 3;
                    iG += 3;
                    iY++;

                    iU++;
                    iV++;
                }
                if (i%2==0)
                {
                    iU = iU - (width >> 1);
                    iV = iV - (width >> 1);
                }
            }
            return byteRgb;
        }
        private static Bitmap GetDataPicture(int w, int h, byte[] data)
        {
            //写 BMP 图像文件。
            int yu = w * 3 % 4;
            int bytePerLine = 0;
            yu = yu != 0 ? 4 - yu : yu;
            bytePerLine = h * 3 + yu;
            Bitmap btmp;
            using(var stream=new MemoryStream(data.Length +14))//为头腾出14个长度的空间
            {
                //这个是文件头
                var bytes=new byte[]{0x42,0x4d};
                stream.Write(bytes, 0, 2);

                stream.Write(BitConverter.GetBytes(bytePerLine*h + 54),0,4);
                stream.Write(BitConverter.GetBytes(0), 0, 4);
                stream.Write(BitConverter.GetBytes(54), 0, 4);
                stream.Write(BitConverter.GetBytes(40), 0, 4);
                stream.Write(BitConverter.GetBytes(w), 0, 4);
                stream.Write(BitConverter.GetBytes(h), 0, 4);
                stream.Write(BitConverter.GetBytes(1), 0, 2);
                stream.Write(BitConverter.GetBytes(24), 0, 2);
                stream.Write(BitConverter.GetBytes(0), 0, 4);
                stream.Write(BitConverter.GetBytes(bytePerLine * h), 0, 4);
                stream.Write(BitConverter.GetBytes(0), 0, 4);
                stream.Write(BitConverter.GetBytes(0), 0, 4);
                stream.Write(BitConverter.GetBytes(0), 0, 4);
                stream.Write(BitConverter.GetBytes(0), 0, 4);
                stream.Write(data, 0, data.Length);
                btmp = new Bitmap(stream, true);
            }
            return btmp;

        }            
        private static void WriteBMP(byte[] rgbFrame, int width, int height, string bmpFile)
        {

          //写 BMP 图像文件。
          int yu = width * 3 % 4;
          int bytePerLine = 0;
          yu = yu != 0 ? 4 - yu : yu;
          bytePerLine = width * 3 + yu;
          using (FileStream fs = File.Open(bmpFile, FileMode.Create))
          {
              using (BinaryWriter bw = new BinaryWriter(fs))
              {
                  //这个是文件头
                  bw.Write('B');
                  bw.Write('M');
                  bw.Write(bytePerLine * height + 54);
                  bw.Write(0);
                  bw.Write(54);
                  bw.Write(40);
                  bw.Write(width);
                  bw.Write(height);
                  bw.Write((ushort)1);
                  bw.Write((ushort)24);
                  bw.Write(0);
                  bw.Write(bytePerLine * height);
                  bw.Write(0);
                  bw.Write(0);
                  bw.Write(0);
                  bw.Write(0);
                  bw.Write(rgbFrame, 0, rgbFrame.Length);
              }
          }
        }
    }
}
