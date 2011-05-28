using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace videosource
{
    public class GeneratorFileInfo
    {
        

        //generate video file name
        public const int DEFFFILEMIN = 15;
        public static Dictionary<string, DateTime> SearchVideoFileName(string baseOutpputPath, string extFile, int cameraId, DateTime dStartTime, DateTime dEndDate)
        {
           
            if (baseOutpputPath.Substring(baseOutpputPath.Length - 1, 1).Equals("\\"))
            {
                baseOutpputPath = baseOutpputPath.Substring(0, baseOutpputPath.Length - 1);
            }
            string startPath = string.Format("{0}\\{1}\\{2}\\{3}\\{4}\\{5}\\",
                                baseOutpputPath,
                                cameraId,
                                dStartTime.Year.ToString("d4"),
                                dStartTime.Month.ToString("d2"),
                                dStartTime.Day.ToString("d2"),
                                dStartTime.Hour.ToString("d2")
                                );
            string endPath = string.Format("{0}\\{1}\\{2}\\{3}\\{4}\\{5}\\",
                            baseOutpputPath,
                            cameraId,
                            dEndDate.Year.ToString("d4"),
                            dEndDate.Month.ToString("d2"),
                            dEndDate.Day.ToString("d2"),
                            dEndDate.Hour.ToString("d2")
                            );
            var d = new Dictionary<string, DateTime>();
            FileInfo oFileInfo;
            DateTime dt;
            string[] files;
            string[] splitStr;
            string fileDirect;
            string strFile = "";
            string strFileMin = "";
            int iFileMin = 0;
            DateTime dtFileSaveTime;
            dStartTime =dStartTime.AddMinutes(-1*DEFFFILEMIN);
            int hours = (int)dEndDate.Subtract(dStartTime).TotalHours;
            for (int j = 0; j <= hours; j++)
            {
                dt = dStartTime.AddHours(j);
                fileDirect = GeneratorFileInfo.GenerateSavePath(baseOutpputPath,cameraId,dt);
                files = Directory.GetFiles(fileDirect, "*."+extFile);
                for (int i = 0; i < files.Length; i++)
                {
                    splitStr = files[i].Split('\\');
                    strFile = splitStr[splitStr.Length - 1];
                    splitStr= strFile.Split('.');
                    if (!int.TryParse(splitStr[0], out iFileMin))
                    {
                        continue;
                    }
                    if (iFileMin < 0 || iFileMin >= 60)
                    {
                        continue;
                    }
                    strFileMin = iFileMin.ToString("99");
                    dtFileSaveTime = DateTime.Parse(dt.ToString("yyyy/MM/dd HH:mm").Substring(0, 14) + strFileMin + ":00");
                    if (dtFileSaveTime.CompareTo(dStartTime) > 0 && dtFileSaveTime.CompareTo(dEndDate) <= 0)
                    {
                        if (!d.ContainsKey(files[i]))
                        {
                            d.Add(files[i], new FileInfo(files[i]).LastWriteTime);
                        }
                    }

                }

            }

            return d;
        }
        public static string GenerateSavePath(string baseOutpputPath, int cameraId, DateTime dTime)
        {
            if (baseOutpputPath.Substring(baseOutpputPath.Length - 1, 1).Equals("\\"))
            {
                baseOutpputPath = baseOutpputPath.Substring(0, baseOutpputPath.Length - 1);
            }
            string path = string.Format("{0}\\{1}\\{2}\\{3}\\{4}\\{5}\\",
                                baseOutpputPath,
                                cameraId,
                                dTime.Year.ToString("d4"),
                                dTime.Month.ToString("d2"),
                                dTime.Day.ToString("d2"),
                                dTime.Hour.ToString("d2")
                                );
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            return path;
        }
        public static string GenerateSaveFilePath(string baseOutpputPath,string extFile, int cameraId, DateTime dTime)
        {
            if (baseOutpputPath.Substring(baseOutpputPath.Length - 1, 1).Equals("\\"))
            {
                baseOutpputPath = baseOutpputPath.Substring(0, baseOutpputPath.Length - 1);
            }
            string path = string.Format("{0}\\{1}\\{2}\\{3}\\{4}\\{5}\\",
                                baseOutpputPath,
                                cameraId,
                                dTime.Year.ToString("d4"),
                                dTime.Month.ToString("d2"),
                                dTime.Day.ToString("d2"),
                                dTime.Hour.ToString("d2")
                                );
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            path = path + string.Format("{0}.{1}", dTime.Minute.ToString("d2"), extFile);

            return path;
        }
    }
}
