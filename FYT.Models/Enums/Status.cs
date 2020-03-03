using System;
using System.Collections.Generic;
using System.Text;

namespace FYT.Models
{
    public enum Status : byte
    {
        Requested = 1,
        Enrolled = 2,
        Finished = 3,
        Closed = 4
    }
}
