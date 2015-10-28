using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using BTrees;

namespace UnitTestBTrees
{
    [TestClass]
    public class UnitTestBTrees
    {
        [TestMethod]
        public void VisitNode_Enqueues_Int()
        {
            // Arrange
            Node node = new Node();
            Queue<int> queue = new Queue<int>();
            Visit v = new Visit();  // Class being tested...

            // Act
            Assert.IsTrue(queue.Count == 0);
            v.VisitNode(node, queue);

            //Assert
            Assert.IsTrue(queue.Count == 1);

        }

        [TestMethod]
        public void VisitNode_Enqueues_Ints_InOrder()
        {
            // Arrange
            Node node1 = new Node();
            Node node2 = new Node();
            Queue<int> queue = new Queue<int>();
            Visit v = new Visit();  // Class being tested...

            node1.iValue = 1;
            node2.iValue = 2;

            // Act
            v.VisitNode(node1, queue);
            v.VisitNode(node2, queue);

            //Assert
            int i1 = queue.Dequeue();
            int i2 = queue.Dequeue();
            Assert.IsTrue(i1 == 1);
            Assert.IsTrue(i2 == 2);

        }

        [TestMethod]
        public void VisitNode_Throws_ArgumentNullException_On_Null_Node()
        {
            // Arrange
            Queue<int> queue = new Queue<int>();
            Visit v = new Visit();  // Class being tested...

            // Act/Assert
            try
            {
                v.VisitNode(null, queue);
            }
            catch (Exception e)
            {
                Assert.IsTrue(e.GetType() == typeof(ArgumentNullException));
                return;
            }
            Assert.Fail();
        }

        [TestMethod]
        public void VisitNode_Throws_ArgumentNullException_On_Null_Queue()
        {
            // Arrange
            Node n = new Node();
            Visit v = new Visit();  // Class being tested...

            // Act/Assert
            try
            {
                v.VisitNode(n, null);
            }
            catch (Exception e)
            {
                Assert.IsTrue(e.GetType() == typeof(ArgumentNullException));
                return;
            }
            Assert.Fail();
        }
    }
}
