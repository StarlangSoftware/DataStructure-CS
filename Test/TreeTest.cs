using System.Collections.Generic;
using DataStructure.Tree;
using NUnit.Framework;

namespace Test
{
    public class TreeTest
    {
        [Test]
        public void TestTree()
        {
            var tree = new Tree<int>(Comparer<int>.Default);
            tree.Insert(4);
            tree.Insert(6);
            tree.Insert(2);
            tree.Insert(5);
            tree.Insert(3);
            tree.Insert(1);
            tree.Insert(7);
            Assert.NotNull(tree.Search(3));
            Assert.IsNull(tree.Search(8));
        }

        [Test]
        public void TestTree2()
        {
            var tree = new AvlTree<int>(Comparer<int>.Default);
            for (var i = 1; i <= 31; i++){
                tree.Insert(i);
            }
            for (var i = 1; i < 32; i++){
                Assert.NotNull(tree.Search(i));
            }
            Assert.IsNull(tree.Search(32));
        }

        [Test]
        public void TestTree3() {
            BTree<int> tree = new BTree<int>(1, Comparer<int>.Default);
            for (int i = 1; i <= 31; i++){
                tree.Insert(i);
            }
            for (int i = 1; i < 32; i++){
                Assert.NotNull(tree.Search(i));
            }
            Assert.IsNull(tree.Search(32));
        }

    }
}