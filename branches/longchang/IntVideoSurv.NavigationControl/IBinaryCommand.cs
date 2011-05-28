using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NavigationControl
{
    public interface IBinaryCommand
    {
        byte[] Build();
    }
}
