using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace IntVideoSurv.Business
{
    public class MonitorFolder
    {
        public static int GetFreeDiskSpaceMB(string drive)
        {
            DriveInfo driveInfo = new DriveInfo(drive);
            long FreeSpace = driveInfo.AvailableFreeSpace;

            FreeSpace /= 1024 * 1024;
            return (int)FreeSpace;
        }

        private string _fileDirect = string.Empty;
        private int _saveDay = 0;

        public MonitorFolder(string fileDirect, int saveDay)
        {
            this._fileDirect = fileDirect;
            this._saveDay = saveDay;
        }

        public void DeleteFirstDayFile()
        {

            this._fileDirect = Config.VideoPath;

            string[] directs = Directory.GetDirectories(_fileDirect);
            foreach (string subDirect in directs)
            {
                int lastIndex = subDirect.LastIndexOf("\\");
                string endFolderName = subDirect.Substring(lastIndex, subDirect.Length - lastIndex);
                DateTime folderTime = GetFolderDateTimeInfo(endFolderName);
                if (folderTime.Year > 2000)
                {
                    TimeSpan ts = DateTime.Now - folderTime;
                    if (ts.TotalDays > this._saveDay)
                    {
                        try
                        {
                            Directory.Delete(subDirect, true);
                        }
                        catch (Exception ex)
                        {

                        }
                        break;
                    }

                }
            }
        }


        private DateTime GetFolderDateTimeInfo(string folderName)
        {
            if (!CheckFolderNameIsNumber(folderName))
                return new DateTime();
            int year = Convert.ToInt32(folderName.Substring(0, 4));
            int month = Convert.ToInt32(folderName.Substring(4, 2));
            int day = Convert.ToInt32(folderName.Substring(6, 2));
            return new DateTime(year, month, day, 0, 0, 0);
        }

        private bool CheckFolderNameIsNumber(string folderName)
        {
            try
            {
                int temp = Convert.ToInt32(folderName);
            }
            catch (System.Exception ex)
            {
                return false;
            }
            return true;
        }
    }
}
