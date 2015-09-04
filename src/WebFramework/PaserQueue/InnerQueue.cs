using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using WebFramework.Interfaces;

namespace WebFramework.PaserQueue
{
    public class InnerQueue
    {
        private readonly List<IMyQueue> _queue;

        public InnerQueue()
        {
            _queue=new List<IMyQueue>();
        }

        public bool AddQueue<T>()
        {
            bool restult = false;
            var searchResult = from s in _queue where s.QueueType == typeof (T) select s;
            if (!searchResult.Any())
            {
                _queue.Add(new MyQueue<T>());
                restult = true;
            }
            return restult;
        }

        public IEnumerable GetAllQueue()
        {
            return _queue;
        }

        public IMyQueue GetQueue(IMyQueue queue)
        {
            var result = from myQueue in _queue where myQueue.QueueType == queue.QueueType select myQueue;
            var myQueues = result as IMyQueue[] ?? result.ToArray();
            if (myQueues.Any())
                return myQueues.FirstOrDefault();
            return null;
        }

        public IMyQueue GetQueue(Type type)
        {
            var result = from myQueue in _queue where myQueue.QueueType == type select myQueue;
            var myQueues = result as IMyQueue[] ?? result.ToArray();
            if (myQueues.Any())
                return myQueues.FirstOrDefault();
            return null;
        }
    }

    public class MyQueue<T>:Queue, IMyQueue
    {
        public Type QueueType { get; set; }
        public Queue MsgQueue { get; set; }

        public MyQueue()
        {
            QueueType = typeof (T);
            MsgQueue = this;
        }

        public override void Enqueue(object obj)
        {

            if (obj.GetType() != QueueType)
                throw new Exception("Invalid type queue.");
            base.Enqueue(obj);
        }

        public override object Dequeue()
        {
            return base.Dequeue();
        }
    }
}
