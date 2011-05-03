using System;
using Com.SS.Framework.Entity;

namespace IntVideoSurv.Entity
{
    [Serializable]
    public class SystemParameters
    {
        [ColumnMapping()] 
        public static string CapturePictureFilePath;
    }
}
