namespace AlgorithmsNetCoreTest
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Algorithms;

    [TestClass]
    public class PriorityQueueTest
    {
        [TestMethod, TestCategory("UnitTest"), TestCategory("Queue")]
        public void TestAll()
        {
            PriorityQueue queue = new PriorityQueue();
            Assert.IsTrue(queue.IsEmpty());

            queue.Enqueue(1, 5);
            queue.Enqueue(2, 9);
            queue.Enqueue(3, 2);
            queue.Enqueue(4, 40);
            queue.Enqueue(5, 12);

            Assert.AreEqual(5, queue.Count);
            Assert.IsFalse(queue.IsEmpty());

            PriorityQueueNode node = queue.Dequeue();
            Assert.AreEqual(4, node.Data);

            node = queue.Dequeue();
            Assert.AreEqual(5, node.Data);

            node = queue.Dequeue();
            Assert.AreEqual(2, node.Data);

            node = queue.Dequeue();
            Assert.AreEqual(1, node.Data);

            node = queue.Dequeue();
            Assert.AreEqual(3, node.Data);

            Assert.IsTrue(queue.IsEmpty());

            try
            {
                queue.Dequeue();
                Assert.Fail();
            }
            catch (InvalidOperationException)
            {
            }
            catch
            {
                Assert.Fail();
            }

            queue.Enqueue(1, 5);
            queue.Enqueue(2, 9);
            queue.Enqueue(3, 2);
            queue.Enqueue(4, 40);
            queue.Enqueue(5, 12);
            Assert.AreEqual(5, queue.Count);

            queue.Dequeue();
            queue.Dequeue();
            Assert.AreEqual(3, queue.Count);

            queue.Enqueue(4, 1);
            queue.Enqueue(5, 1);
            queue.Enqueue(5, 100);
            Assert.AreEqual(6, queue.Count);

            node = queue.Dequeue();
            Assert.AreEqual(5, node.Data);
        }
    }
}
