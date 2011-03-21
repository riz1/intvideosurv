using System;
using System.Collections.Generic;
using System.Text;
using IntVideoSurv.Business;

namespace CameraViewer
{
    public class Util
    {
        public enum Operateion
        {
            Add =0,
            Update=1,
            Delete=2,
        }
        public static  void GetRowCol(int cameraCount, ref int rows, ref int cols)
        {
            rows = 1;
            cols = 1;
            switch (cameraCount)
            {
                case 0:
                case 1:
                    rows = 1;
                    cols = 1;
                    break;
                case 2:
                case 3:
                case 4:
                    rows = 2;
                    cols = 2;
                    break;
                case 5:
                case 6:
                case 7:
                case 8:
                case 9:
                    rows = 3;
                    cols = 3;
                    break;
                case 10:
                case 11:
                case 12:
                case 13:
                case 14:
                case 15:
                case 16:
                    rows = 4;
                    cols = 4;
                    break;
                case 17:
                case 18:
                case 19:
                case 20:
                case 21:
                case 22:
                case 23:
                case 24:
                case 25:
                    rows = 5;
                    cols = 5;
                    break;
                default:
                    break;
            }
        }
    }
}
