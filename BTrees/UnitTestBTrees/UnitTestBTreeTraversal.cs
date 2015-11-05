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
            private Node BuildSevenNodeTree()
            {
                // Building a 7-node tree. This as a node with only a left child, a node with only a right child, 
                // and nodes that have both left and right children. Tree that looks like:
                //     4
                //    /  \
                //   3    9
                //  /    / \
                // 1    7   11
                //           \
                //            15
                Node n = null;

                Node t = new Node();   // Root node (value == 4).
                t.iKey = 4;
                t.left = new Node();   // Left child of root (3).
                n = t.left;
                n.iKey = 3;
                n.left = new Node();   // Left child of 3 (is 1).
                n.left.iKey = 1;
                t.right = new Node();  // Right child of root (9).
                n = t.right;
                n.iKey = 9;
                n.left = new Node();   // Left child of 9 (is 7).
                n.left.iKey = 7;
                n.right = new Node();  // Right child of 9 (is 11).
                n.right.iKey = 11;
                n = n.right;
                n.right = new Node();  // Right child of 11 (is 15).
                n.right.iKey = 15;

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
                bt.InOrderTraversal(null);

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
                bt.InOrderTraversal(n);

                //Assert
                Assert.IsTrue(queue.Count == 1);
            }

            [TestMethod]
            public void InOrder_Traversal_Handles_Simple_Seven_Node_Tree()
            {
                // Arrange
                Node tree = BuildSevenNodeTree();
                Visit v = new Visit();
                Queue<int> queue = new Queue<int>();
                BTreeTraversal bt = new BTreeTraversal(v, queue);

                // Act
                bt.InOrderTraversal(tree);

                //Assert
                // There should be seven values (from the seven nodes) in the queue:
                Assert.IsTrue(queue.Count == 7);

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
