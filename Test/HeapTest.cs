using System.Collections.Generic;
using DataStructure.Heap;
using NUnit.Framework;

namespace Test
{
    public class HeapTest
    {
        [Test]
        public void TestMaxHeap()
        {
            var maxHeap = new MaxHeap<int>(8, Comparer<int>.Default);
            maxHeap.Insert(4);
            maxHeap.Insert(6);
            maxHeap.Insert(2);
            maxHeap.Insert(5);
            maxHeap.Insert(3);
            maxHeap.Insert(1);
            maxHeap.Insert(7);
            Assert.AreEqual(7, maxHeap.Delete());
            Assert.AreEqual(6, maxHeap.Delete());
            Assert.AreEqual(5, maxHeap.Delete());
        }

        [Test]
        public void TestMinHeap()
        {
            var minHeap = new MinHeap<int>(8, Comparer<int>.Default);
            minHeap.Insert(4);
            minHeap.Insert(6);
            minHeap.Insert(2);
            minHeap.Insert(5);
            minHeap.Insert(3);
            minHeap.Insert(1);
            minHeap.Insert(7);
            Assert.AreEqual(1, minHeap.Delete());
            Assert.AreEqual(2, minHeap.Delete());
            Assert.AreEqual(3, minHeap.Delete());
        }

    }
}