using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using BTrees;

namespace UnitTestBTrees
{
    class UnitTestBTreeTraversal
    {
        [TestClass]
        public class UnitTest_Recursive_BTrees
        {
            private Node BuildSixNodeTree()
            {
                // Tree that looks like (how to do this with a MOQ?):
                //     4
                //    /  \
                //   3    9
                //  /    / \
                // 1    7   11
                Node n = null;

                Node t = new Node();   // Root node (value == 4).
                t.iValue = 4;
                t.left = new Node();   // Left child of root (3).
                n = t.left;
                n.iValue = 3;
                n.left = new Node();   // Left child of 3 (is 1).
                n.left.iValue = 1;
                t.right = new Node();  // Right child of root (9).
                n = t.right;
                n.iValue = 9;
                n.left = new Node();   // Left child of 9 (is 7).
                n.left.iValue = 7;
                n.right = new Node();  // Right child of 9 (is 11).
                n.right.iValue = 11;

                return t;
            }
                
            [TestMethod]
            public void InOrder_Traversal_Handles_Null_Tree()
            {
                // Arrange
                Visit v = new Visit();
                Queue<int> queue = new Queue<int>();
                BTreeTraversal bt = new BTreeTraversal(v, queue);

                // Act
                bt.InOrder(null);

                //Assert
                Assert.IsTrue(queue.Count == 0);
            }

            [TestMethod]
            public void InOrder_Traversal_Handles_One_Node_Tree()
            {
                // Arrange
                Node n = new Node();
                Visit v = new Visit();
                Queue<int> queue = new Queue<int>();
                BTreeTraversal bt = new BTreeTraversal(v, queue);

                // Act
                bt.InOrder(n);

                //Assert
                Assert.IsTrue(queue.Count == 1);
            }

            [TestMethod]
            public void InOrder_Traversal_Handles_Simple_Six_Node_Tree()
            {
                // Arrange
                Node tree = BuildSixNodeTree();
                Visit v = new Visit();
                Queue<int> queue = new Queue<int>();
                BTreeTraversal bt = new BTreeTraversal(v, queue);

                // Act
                bt.InOrder(tree);

                //Assert
                // There should be six values in the queue:
                Assert.IsTrue(queue.Count == 6);

                // Those values should be in assending order:
                int iPrev = -1;
                int iVal = 0;
                while (queue.Count > 0)
                {
                    iVal = queue.Dequeue();
                    Assert.IsTrue(iPrev < iVal);
                    iPrev = iVal;
                }
            }
        }
    }
}
