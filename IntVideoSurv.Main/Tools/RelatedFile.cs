using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace CameraViewer.Tools
{
    public class RelatedFile
    {
        public string Ip { set; get; }
        public int Channel { set; get; } 
        public DateTime CaptureTime{ set; get; }
        public int SecondsBefore{ set; get; }


        public string RelatedFile1 { set; get; }
        public int RelatedStartFramePosition1 { set; get; }
        public int RelatedFrames1 { set; get; }

        public string RelatedFile2 { set; get; }
        public int RelatedStartFramePosition2 { set; get; }
        public int RelatedFrames2 { set; get; }

        ArrayList PathList= new ArrayList();
        public static int fps = 25;

        public RelatedFile()
        {
            
        }

        public RelatedFile(string ip,int channel,DateTime captureTime, int seconds)
        {
            
            Ip = ip;
            Channel = channel;
            CaptureTime = captureTime;
            SecondsBefore = seconds;
            PathList.Clear();
            
            //获取磁盘映射的根目录
            string[] paths = Properties.Settings.Default.RecordPath.Split(';');
            foreach (var path in paths)
            {
                PathList.Add(path);
            }

            //获取根目录下与当前IP相关的目录
            ArrayList IPPath = new ArrayList();
            foreach (string path in PathList)
            {
                if (Directory.Exists(path)==false)
                {
                    continue;
                }
                DirectoryInfo Dir = new DirectoryInfo(path);
                foreach(DirectoryInfo d in Dir.GetDirectories()) //查找子目录
                {
                    if (d.FullName.Contains(Ip))
                    {
                        IPPath.Add(d.FullName);
                    }
                }
            }

            //获取各IP相关目录下与当日相关的目录
            ArrayList DatePath = new ArrayList();
            foreach (string path in IPPath)
            {
                if (Directory.Exists(path) == false)
                {
                    continue;
                }
                DirectoryInfo Dir = new DirectoryInfo(path);
                foreach (DirectoryInfo d in Dir.GetDirectories(CaptureTime.ToString("yyyy-MM-dd"))) //查找子目录
                {
                    DatePath.Add(d.FullName);
                }
            }

            //获取日期目录下的通道目录
            ArrayList ChannelPath = new ArrayList();
            foreach (string path in DatePath)
            {
                if (Directory.Exists(path) == false)
                {
                    continue;
                }
                DirectoryInfo Dir = new DirectoryInfo(path);
                foreach (DirectoryInfo d in Dir.GetDirectories("ch0"+channel+"ch")) //查找子目录
                {
                    ChannelPath.Add(d.FullName);

                }
            }
            //获取通道目录下的文件
            int hour2 = CaptureTime.Hour;
            int hour1 = hour2 - 1;
            if (hour1 == -1) hour1 = 0;
            string hstrhour2 = string.Format("{0:D2}", hour2);
            string hstrhour1 = string.Format("{0:D2}", hour1);
            List<FileInfo> listVideoFiles = new List<FileInfo>();
            foreach (string path in ChannelPath)
            {
                if (Directory.Exists(path) == false)
                {
                    continue;
                }
                DirectoryInfo Dir = new DirectoryInfo(path);

                foreach (FileInfo fileInfo in Dir.GetFiles(hstrhour2+"*.mkv").Union(Dir.GetFiles(hstrhour2+"*.avi").Union(Dir.GetFiles(hstrhour1+"*.mkv").Union(Dir.GetFiles(hstrhour1+"*.avi")))))//查找文件
                {
                    listVideoFiles.Add(fileInfo);
                }

            }
            //根据创建时间逆序排序

            listVideoFiles.Sort(delegate(FileInfo a, FileInfo b)
                                    {
                                        if (a.CreationTime < b.CreationTime)
                                            return 1;
                                        else if (a.CreationTime > b.CreationTime)
                                            return -1;
                                        else return 0;

                                    });

            for (int i = 0; i < listVideoFiles.Count;i++ )
            {
                FileInfo fileInfo = listVideoFiles[i];
                //只有一个文件就ok;
                if ((fileInfo.CreationTime.AddSeconds(SecondsBefore) <= captureTime) && (fileInfo.LastWriteTime >= captureTime))
                {
                    RelatedFile1 = fileInfo.FullName;
                    RelatedStartFramePosition1 = fps * (int)((captureTime.AddSeconds(-SecondsBefore) - fileInfo.CreationTime)).TotalSeconds;
                    RelatedFrames1 = fps * SecondsBefore;
                    break;
                }
                else if ((fileInfo.CreationTime < captureTime) && (fileInfo.LastWriteTime.AddSeconds(SecondsBefore) >= captureTime))
                {
                    //文件2
                    RelatedFile2 = fileInfo.FullName;
                    RelatedStartFramePosition2 = 0;
                    RelatedFrames2 = fps * (int)((captureTime - fileInfo.CreationTime)).TotalSeconds;
                    //文件1
                    RelatedFile1 = listVideoFiles[i+1].FullName;
                    int seconds2play = (SecondsBefore-(int)(captureTime - fileInfo.CreationTime).TotalSeconds);
                    if (seconds2play<2)
                    {
                        RelatedFile1 = null;
                        break;
                    }
                    RelatedStartFramePosition1 = fps * (120 - seconds2play);
                    RelatedFrames1 = fps * seconds2play;
                    break;
                }
            }

        }




    }
    public class FileInfoCompare : IComparer
    {
        public int Compare(object f1, object f2)
        {
            return (f1 as FileInfo).CreationTime > (f2 as FileInfo).CreationTime ? 1 : 0;
        }
    }
}
