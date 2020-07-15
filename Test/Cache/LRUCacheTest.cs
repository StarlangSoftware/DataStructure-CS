using System;
using DataStructure.Cache;
using NUnit.Framework;

namespace Test.Cache
{
    public class LRUCacheTest
    {
        [Test]
        public void Test1()
        {
            var cache = new LRUCache<string, string>(5);
            cache.Add("item1", "1");
            cache.Add("item2", "2");
            cache.Add("item3", "3");
            Assert.True(cache.Contains("item2"));
            Assert.False(cache.Contains("item4"));
        }

        [Test]
        public void Test2()
        {
            var cache = new LRUCache<string, string>(2);
            cache.Add("item1", "1");
            cache.Add("item2", "2");
            cache.Add("item3", "3");
            Assert.True(cache.Contains("item2"));
            Assert.False(cache.Contains("item1"));
        }

        [Test]
        public void Test3()
        {
            var random = new Random();
            var cache = new LRUCache<int, int>(10000);
            for (var i = 0; i < 10000; i++)
            {
                cache.Add(i, i);
            }

            for (var i = 0; i < 1000; i++)
            {
                Assert.True(cache.Contains(random.Next(10000)));
            }
        }

        [Test]
        public void Test4()
        {
            var random = new Random();
            var cache = new LRUCache<int, int>(1000000);
            for (var i = 0; i < 1000000; i++)
            {
                cache.Add(random.Next(1000000), i);
            }

            var count = 0;
            for (var i = 0; i < 1000000; i++)
            {
                if (cache.Contains(i))
                {
                    count++;
                }
            }

            Assert.AreEqual(0.632, count / 1000000.0, 0.001);
        }
    }
}