using System;
using System.Collections.Generic;
using DataStructure;
using NUnit.Framework;

namespace Test
{
    public class CounterHashMapTest
    {
        [Test]
        public void TestPut1()
        {
            var counterHashMap = new CounterHashMap<string>();
            counterHashMap.Put("item1");
            counterHashMap.Put("item2");
            counterHashMap.Put("item3");
            counterHashMap.Put("item1");
            counterHashMap.Put("item2");
            counterHashMap.Put("item1");
            Assert.AreEqual(3, counterHashMap.Count("item1"));
            Assert.AreEqual(2, counterHashMap.Count("item2"));
            Assert.AreEqual(1, counterHashMap.Count("item3"));
        }

        [Test]
        public void TestPut2()
        {
            var random = new Random();
            var counterHashMap = new CounterHashMap<int>();
            for (var i = 0; i < 1000; i++)
            {
                counterHashMap.Put(random.Next(1000));
            }

            var count = 0;
            for (var i = 0; i < 1000; i++)
            {
                count += counterHashMap.Count(i);
            }

            Assert.AreEqual(1000, count);
        }

        [Test]
        public void TestSumOfCounts()
        {
            var random = new Random();
            var counterHashMap = new CounterHashMap<int>();
            for (var i = 0; i < 1000; i++)
            {
                counterHashMap.Put(random.Next(1000));
            }

            Assert.AreEqual(1000, counterHashMap.SumOfCounts());
        }

        [Test]
        public void TestPut3()
        {
            var random = new Random();
            var counterHashMap = new CounterHashMap<int>();
            for (var i = 0; i < 1000000; i++)
            {
                counterHashMap.Put(random.Next(1000000));
            }

            Assert.AreEqual(((Dictionary<int, int>) counterHashMap).Count / 1000000.0, 0.632, 0.001);
        }

        [Test]
        public void TestPutNTimes1()
        {
            var counterHashMap = new CounterHashMap<string>();
            counterHashMap.PutNTimes("item1", 2);
            counterHashMap.PutNTimes("item2", 3);
            counterHashMap.PutNTimes("item3", 6);
            counterHashMap.PutNTimes("item1", 2);
            counterHashMap.PutNTimes("item2", 3);
            counterHashMap.PutNTimes("item1", 2);
            Assert.AreEqual(6, counterHashMap.Count("item1"));
            Assert.AreEqual(6, counterHashMap.Count("item2"));
            Assert.AreEqual(6, counterHashMap.Count("item3"));
        }

        [Test]
        public void TestPutNTimes2()
        {
            var random = new Random();
            var counterHashMap = new CounterHashMap<int>();
            for (var i = 0; i < 1000; i++)
            {
                counterHashMap.PutNTimes(random.Next(1000), i + 1);
            }

            Assert.AreEqual(500500, counterHashMap.SumOfCounts());
        }

        [Test]
        public void TestMax()
        {
            var counterHashMap = new CounterHashMap<string>();
            counterHashMap.Put("item1");
            counterHashMap.Put("item2");
            counterHashMap.Put("item3");
            counterHashMap.Put("item1");
            counterHashMap.Put("item2");
            counterHashMap.Put("item1");
            Assert.AreEqual("item1", counterHashMap.Max());
        }

        [Test]
        public void TestMaxThreshold1()
        {
            var counterHashMap = new CounterHashMap<string>();
            counterHashMap.Put("item1");
            counterHashMap.Put("item2");
            counterHashMap.Put("item3");
            counterHashMap.Put("item1");
            counterHashMap.Put("item2");
            counterHashMap.Put("item1");
            Assert.AreEqual("item1", counterHashMap.Max(0.4999));
            Assert.AreNotEqual("item1", counterHashMap.Max(0.5001));
        }

        [Test]
        public void TestMaxThreshold2()
        {
            var random = new Random();
            var counterHashMap = new CounterHashMap<string>();
            for (var i = 0; i < 1000000; i++)
            {
                counterHashMap.Put(random.Next(100) + "");
            }

            var probability = counterHashMap.Count(counterHashMap.Max()) / 1000000.0;
            Assert.NotNull(counterHashMap.Max(probability - 0.001));
            Assert.Null(counterHashMap.Max(probability + 0.001));
        }

        [Test]
        public void TestAdd1()
        {
            var counterHashMap1 = new CounterHashMap<string>();
            counterHashMap1.Put("item1");
            counterHashMap1.Put("item2");
            counterHashMap1.Put("item3");
            counterHashMap1.Put("item1");
            counterHashMap1.Put("item2");
            counterHashMap1.Put("item1");
            var counterHashMap2 = new CounterHashMap<string>();
            counterHashMap2.PutNTimes("item1", 2);
            counterHashMap2.PutNTimes("item2", 3);
            counterHashMap2.PutNTimes("item3", 6);
            counterHashMap2.PutNTimes("item1", 2);
            counterHashMap2.PutNTimes("item2", 3);
            counterHashMap2.PutNTimes("item1", 2);
            counterHashMap1.Add(counterHashMap2);
            Assert.AreEqual(9, counterHashMap1.Count("item1"));
            Assert.AreEqual(8, counterHashMap1.Count("item2"));
            Assert.AreEqual(7, counterHashMap1.Count("item3"));
        }

        [Test]
        public void TestAdd2()
        {
            var counterHashMap1 = new CounterHashMap<string>();
            counterHashMap1.Put("item1");
            counterHashMap1.Put("item2");
            counterHashMap1.Put("item1");
            counterHashMap1.Put("item2");
            counterHashMap1.Put("item1");
            var counterHashMap2 = new CounterHashMap<string>();
            counterHashMap2.Put("item4");
            counterHashMap2.PutNTimes("item5", 4);
            counterHashMap2.Put("item2");
            counterHashMap1.Add(counterHashMap2);
            Assert.AreEqual(3, counterHashMap1.Count("item1"));
            Assert.AreEqual(3, counterHashMap1.Count("item2"));
            Assert.AreEqual(1, counterHashMap1.Count("item4"));
            Assert.AreEqual(4, counterHashMap1.Count("item5"));
        }

        [Test]
        public void TestAdd3()
        {
            var counterHashMap1 = new CounterHashMap<int>();
            for (var i = 0; i < 1000; i++)
            {
                counterHashMap1.Put(i);
            }

            var counterHashMap2 = new CounterHashMap<int>();
            for (var i = 500; i < 1000; i++)
            {
                counterHashMap2.PutNTimes(1000 + i, i + 1);
            }

            counterHashMap1.Add(counterHashMap2);
            Assert.AreEqual(1500, ((Dictionary<int, int>)counterHashMap1).Count);
        }

        [Test]
        public void TestTopN1()
        {
            var counterHashMap = new CounterHashMap<string>();
            counterHashMap.Put("item1");
            counterHashMap.Put("item2");
            counterHashMap.Put("item3");
            counterHashMap.Put("item1");
            counterHashMap.Put("item2");
            counterHashMap.Put("item1");
            Assert.AreEqual("item1", counterHashMap.TopN(1)[0].Key);
            Assert.AreEqual("item2", counterHashMap.TopN(2)[1].Key);
            Assert.AreEqual("item3", counterHashMap.TopN(3)[2].Key);
        }

        [Test]
        public void TestTopN2()
        {
            var counterHashMap = new CounterHashMap<string>();
            for (var i = 0; i < 1000; i++)
            {
                counterHashMap.PutNTimes(i + "", 2 * i + 2);
            }

            Assert.AreEqual(990 + "", counterHashMap.TopN(10)[9].Key);
            Assert.AreEqual(900 + "", counterHashMap.TopN(100)[99].Key);
        }
    }
}