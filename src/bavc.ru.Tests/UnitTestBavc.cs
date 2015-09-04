using System;
using System.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebFramework;
using WebFramework.Interfaces;
using WebFramework.PaserQueue;

namespace bavc.ru.Tests
{
    [TestClass]
    public class UnitTestBavc
    {
        [TestMethod]
        public void TestAddQueue()
        {
            var obj = new InnerQueue();
            obj.AddQueue<string>();
            obj.AddQueue<int>();
            obj.AddQueue<bool>();
            Assert.AreEqual(obj.AddQueue<bool>(), false);
        }

        [TestMethod]
        public void TestFindQueue()
        {
            var obj = new InnerQueue();
            obj.AddQueue<int>();
            Assert.AreEqual(obj.GetQueue(new MyQueue<int>()).QueueType, new MyQueue<int>().QueueType);
        }

        [TestMethod]
        public void TestAddMessageToQueue()
        {
            var obj=new InnerQueue();
            obj.AddQueue<int>();
            obj.AddQueue<string>();
            var queue = obj.GetQueue(new MyQueue<int>());
            var queueString = obj.GetQueue(typeof (string));
            queueString.Enqueue("Test1");
            queue.Enqueue(10);
            Assert.AreEqual(queue.Dequeue(), 10);
            Assert.AreEqual(queueString.Dequeue(), "Test1");
        }
    }
    

}
