using DataStructure.Cache;
using NUnit.Framework;

namespace Test.Cache
{
    public class CacheLinkedListTest
    {
        [Test]
        public void Test1()
        {
            var cacheLinkedList = new CacheLinkedList<string, string>();
            cacheLinkedList.Add(new CacheNode<string, string>("item1", "1"));
            cacheLinkedList.Add(new CacheNode<string, string>("item2", "2"));
            var removed = cacheLinkedList.Remove();
            Assert.AreEqual("item1", removed.GetKey());
            Assert.AreEqual("1", removed.GetData());
            removed = cacheLinkedList.Remove();
            Assert.AreEqual("item2", removed.GetKey());
            Assert.AreEqual("2", removed.GetData());
        }

        [Test]
        public void Test2()
        {
            var cacheLinkedList = new CacheLinkedList<string, string>();
            for (var i = 0; i < 1000; i++)
            {
                cacheLinkedList.Add(new CacheNode<string, string>(i + "", i + ""));
            }

            for (var i = 0; i < 1000; i++)
            {
                var removed = cacheLinkedList.Remove();
                Assert.AreEqual(i + "", removed.GetKey());
                Assert.AreEqual(i + "", removed.GetData());
            }
        }
    }
}