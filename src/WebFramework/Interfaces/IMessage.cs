using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace WebFramework.Interfaces
{
    interface IMessage
    {
        int Id { get; set; }
        Type MessageType { get; set; }
    }
}
