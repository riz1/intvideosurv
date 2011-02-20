using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IntVideoSurv.Entity
{
    public class DecodeChannel
    {
        public DecodeChannel()
        {
            Id = -1;
            CurrentCardOutId = -1;
            Handle= new IntPtr(-1);
        }

        public int Id { get; set; }

        public IntPtr Handle { get; set; }

        public CardOutType CurrentCardOutType{ get; set; }

        public int CurrentCardOutId{ get; set; }

        public bool IsUsed()
        {
            return (CurrentCardOutId == -1) ? false
                       : true;
        }
    }
}
