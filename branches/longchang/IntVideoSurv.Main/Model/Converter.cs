using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CameraViewer.Model
{
    public static class TimeConverter
    {
        public static int ToTongJiRiQi(DateTime time)
        {
            var result = 0;
            var power = 1;
            result += time.Day*power;
            power *= 100;
            result += time.Month*power;
            power *= 100;
            result += time.Year*power;

            return result;
        }
    }
}
