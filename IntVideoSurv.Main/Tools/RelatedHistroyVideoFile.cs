using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using IntVideoSurv.Entity;

namespace CameraViewer.Tools
{
    public class RelatedHistroyVideoFile
    {
        public List<HistroyVideoFile> ListHistroyVideoFile = new List<HistroyVideoFile>();
        public static int fps = 25;
        public RelatedHistroyVideoFile(LongChang_CameraInfo cameraInfo,int channel,DateTime beginTime, DateTime endTime)
        {
            ArrayList PathList= new ArrayList();
            string Ip = cameraInfo.IP;
            ListHistroyVideoFile.Clear();
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
                DateTime date= new DateTime(beginTime.Year,beginTime.Month,beginTime.Day);
                for (; date<=endTime; date=date.AddHours(24))
                {
                    foreach (DirectoryInfo d in Dir.GetDirectories(date.ToString("yyyy-MM-dd"))) //查找子目录
                    {
                        DatePath.Add(d.FullName);
                    }                   
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
                foreach (DirectoryInfo d in Dir.GetDirectories("ch"+string.Format("{0:d2}",channel)+"ch")) //查找子目录
                {
                    ChannelPath.Add(d.FullName);

                }
            }
            //获取通道目录下的文件
            List<FileInfo> listVideoFiles = new List<FileInfo>();
            foreach (string path in ChannelPath)
            {
                if (Directory.Exists(path) == false)
                {
                    continue;
                }
                DirectoryInfo Dir = new DirectoryInfo(path);

                foreach (FileInfo fileInfo in Dir.GetFiles("*.mkv").Union(Dir.GetFiles("*.avi")))//查找文件
                {
                    if (fileInfo.CreationTime>=beginTime && fileInfo.CreationTime<=endTime)
                    {
                         listVideoFiles.Add(fileInfo);
                    }

                }

            }
            //根据创建时间逆序排序

            listVideoFiles.Sort(delegate(FileInfo a, FileInfo b)
                                    {
                                        if (a.CreationTime > b.CreationTime)
                                            return 1;
                                        else if (a.CreationTime < b.CreationTime)
                                            return -1;
                                        else return 0;

                                    });
            foreach (var listVideoFile in listVideoFiles)
            {
                HistroyVideoFile histroyVideoFile= new HistroyVideoFile();
                histroyVideoFile.Camera = cameraInfo;
                histroyVideoFile.CaptureTime = listVideoFile.CreationTime;
                histroyVideoFile.FileName = listVideoFile.FullName;
                ListHistroyVideoFile.Add(histroyVideoFile);
            }
            }
        }
    }
