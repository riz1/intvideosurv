using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NavigationControl
{
    public interface INavigationCommand : IBinaryCommand
    {
        byte DestinationAddress { get; set; }
        byte[] CommandCode { get; set; }
        byte[] CommandData { get; set; }

    }
}
