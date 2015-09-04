using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebFramework.Interfaces
{
    public interface IMyQueue
    {
        Type QueueType { get; set; }
        Queue MsgQueue { get; set; }
        void Enqueue(object obj);
        object Dequeue();
    }
}
