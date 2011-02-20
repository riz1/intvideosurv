using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using IntVideoSurv.Business.HiK;

namespace IntVideoSurv.Business
{
    public class OutputTVDeviceDriver
    {
        public int TotalDSP { get; set; }
        public bool IsValid { get; set; }
        public string errMessage = "";
        public const int MAX_DISPLAY_REGION = 16;
        public const int HWERR_SUCCESS = 0;


        public void Init(IntPtr paraHandle)
        {
            TotalDSP = 0;
            int totalDSP = 0;

            //初始化板卡
           
           
            IsValid = false;
          /*  if (!HCNetSDK.NET_DVR_InitDDraw_Card(paraHandle, 0xffffff))
            {
                errMessage = "设备初始化失败";
                return;
            }

            int m_iCardChanCount = 0;
            if (!HCNetSDK.NET_DVR_InitDevice_Card(ref m_iCardChanCount))
            {
                errMessage = "获取卡通道数失败";
                return;
            }

            TotalDSP = m_iCardChanCount;

            if (TotalDSP == 0)
            {
                errMessage = "没有可用的通道！！您是否已经启动服务器端？";
                return;
            }*/

            int nDispNum = HikVisionSDK.GetDisplayChannelCount();
            if (nDispNum >= 2)
            {
                REGION_PARAM[] struDisplayRegion = new REGION_PARAM[MAX_DISPLAY_REGION];
                int i;

                for (i = 0; i < MAX_DISPLAY_REGION; i++)
                {
                    struDisplayRegion[i] = new REGION_PARAM();
                    struDisplayRegion[i].color = (uint)(Color.FromArgb(i, i * 8, i * 16).ToArgb());
                }
                for (i = 0; i < nDispNum / 2; i++)
                {
                    HikVisionSDK.SetDisplayStandard(2 * i, VideoStandard_t.StandardPAL);
                    struDisplayRegion[0].left = 0; struDisplayRegion[0].top = 0; struDisplayRegion[0].width = 352; struDisplayRegion[0].height = 240;
                    struDisplayRegion[1].left = 352; struDisplayRegion[1].top = 0; struDisplayRegion[1].width = 352; struDisplayRegion[1].height = 240;
                    struDisplayRegion[2].left = 0; struDisplayRegion[2].top = 240; struDisplayRegion[2].width = 352; struDisplayRegion[2].height = 240;
                    struDisplayRegion[3].left = 352; struDisplayRegion[3].top = 240; struDisplayRegion[3].width = 352; struDisplayRegion[3].height = 240;
                    if (HikVisionSDK.SetDisplayRegion(2 * i, 4, ref struDisplayRegion[0], 0) != HWERR_SUCCESS)
                    {

                    }
                    HikVisionSDK.SetDecoderVideoExtOutput(4 * i, 0, true, 2 * i, 0, 0);
                    HikVisionSDK.SetDecoderVideoExtOutput(4 * i + 1, 0, true, 2 * i, 1, 0);
                    HikVisionSDK.SetDecoderVideoExtOutput(4 * i + 2, 0, true, 2 * i, 2, 0);
                    HikVisionSDK.SetDecoderVideoExtOutput(4 * i + 3, 0, true, 2 * i, 3, 0);

                    HikVisionSDK.SetDisplayStandard(2 * i + 1, VideoStandard_t.StandardPAL);
                    struDisplayRegion[0].left = 0; struDisplayRegion[0].top = 0; struDisplayRegion[0].width = 704; struDisplayRegion[0].height = 480;
                    if (HikVisionSDK.SetDisplayRegion(2 * i + 1, 1, ref struDisplayRegion[0], 0) != HWERR_SUCCESS)
                    {
                        // AddLog(m_iCurDeviceIndex, OPERATION_FAIL_T, "SetDisplayRegion failed!");
                    }

                    HikVisionSDK.SetDecoderVideoExtOutput(4 * i, 1, true, 2 * i + 1, 0, 0);
                }
            }

            IsValid = true;
        }
          
        public uint ValidDSP { get; set; }

        public void  Init()
        {


            TotalDSP = 0;
            int totalDSP = 0;
            IsValid = false;
            //初始化板卡
            int x = HikVisionSDK.HW_ReleaseDecDevice();
            int iRtn = HikVisionSDK.HW_InitDecDevice(ref totalDSP);

            if (iRtn < 0)
            {
                errMessage = "设备初始化失败";
                MessageBox.Show(errMessage);
                return;
            }
            TotalDSP = totalDSP;
            
            if (TotalDSP == 0)
            {
                errMessage = "没有可用的通道！！您是否已经启动服务器端？";
                MessageBox.Show(errMessage);
                return;
            }

            //iRtn = HikVisionSDK.SetDefaultVideoStandard(VideoStandard_t.StandardPAL);
            //if (iRtn < 0)
            //{
            //    errMessage = "设置视频制式失败";
            //    MessageBox.Show(errMessage);
            //    return;
            //}
            IsValid = true;
        }
        public void Close()
        {
            bool iRtn = HCNetSDK.NET_DVR_ReleaseDDraw_Card();
            HikVisionSDK.HW_ReleaseDecDevice();
        }
    }
}
