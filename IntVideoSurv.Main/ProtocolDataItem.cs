using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CameraViewer
{
    public static class MyConstant
    {
        public static uint ProtocolDatalen = 8;
    }
    //一条矩阵协议
    public class ProtocolDataItem
    {
        public uint DataLen;	//协议数据的长度
        public byte[] Data;	//协议数据缓冲区
        private string _strdata;
        public string StrData
        {
            get
            {
                for (int i = 0; i < DataLen; i++)
                {
                    _strdata += Data[i].ToString("X2");
                }
                return _strdata;
            }
        }
        public ProtocolDataItem(uint len)
        {
            DataLen = len;
            Data = new byte[DataLen];
        }
        
    };
}