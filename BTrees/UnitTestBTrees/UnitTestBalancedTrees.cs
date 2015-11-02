using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BTrees;

namespace UnitTestBalacedTrees
{
    [TestClass]
    public class UnitTestBalancedTrees
    {
        private void BuildSevenNodeBalancedTree(BalancedTrees bt)
        {
            // Building a 7-node tree. This as a node with only a left child, a node with only a right child, 
            // and nodes that have both left and right children. Tree that looks like this and has a depth of four:
            //     4
            //    /  \
            //   3    9
            //  /    / \
            // 1    7   11
            //           \
            //            15
            bt.Insert(4);
            bt.Insert(3);
            bt.Insert(9);
            bt.Insert(1);
            bt.Insert(7);
            bt.Insert(11);
            bt.Insert(15);
        }

        private void BuildLeftUnbalancedTree(BalancedTrees bt)
        {
            bt.Insert(4);
            bt.Insert(2);
            bt.Insert(1);
        }

        private void BuildRightUnbalancedTree(BalancedTrees bt)
        {
            bt.Insert(4);
            bt.Insert(8);
            bt.Insert(16);
        }

        [TestMethod]
        public void Test_Tree_Depth_For_Null_Tree()
        {
            // Arrange
            BalancedTrees b = new BalancedTrees();

            // Act
            int depth = b.TreeDepth();

            // Assert
            Assert.IsTrue(depth == 0);
        }

        [TestMethod]
        public void Test_Tree_Depth_For_Single_Node_Tree()
        {
            // Arrange
            BalancedTrees b = new BalancedTrees();
            b.Insert(1);

            // Act
            int depth = b.TreeDepth();

            // Assert
            Assert.IsTrue(depth == 1);
        }

        [TestMethod]
        public void Test_Tree_Depth_For_Seven_Node_Tree()
        {
            // Arrange
            BalancedTrees b = new BalancedTrees();
            BuildSevenNodeBalancedTree(b);

            // Act
            int depth = b.TreeDepth();

            // Assert
            Assert.IsTrue(depth == 4);
        }

        [TestMethod]
        public void Test_TreeIsBalanced1_For_Null_Tree()
        {
            // Arrange
            BalancedTrees b = new BalancedTrees();

            // Act
            bool balanced  = b.TreeIsBalanced1();

            // Assert
            Assert.IsTrue(balanced);
        }

        [TestMethod]
        public void Test_TreeIsBalanced1_For_Single_Node_Tree()
        {
            // Arrange
            BalancedTrees b = new BalancedTrees();
            Node tree = new Node();

            // Act
            bool balanced = b.TreeIsBalanced1();

            // Assert
            Assert.IsTrue(balanced);
        }

        [TestMethod]
        public void Test_TreeIsBalanced1_Seven_Node_Balanced_Tree()
        {
            // Arrange
            BalancedTrees b = new BalancedTrees();
            BuildSevenNodeBalancedTree(b);

            // Act
            bool balanced = b.TreeIsBalanced1();

            // Assert
            Assert.IsTrue(balanced);
        }

        [TestMethod]
        public void Test_TreeIsBalanced1_Left_Unbalanced_Tree()
        {
            // Arrange
            BalancedTrees b = new BalancedTrees();
            BuildLeftUnbalancedTree(b);

            // Act
            bool balanced = b.TreeIsBalanced1();

            // Assert
            Assert.IsFalse(balanced);
        }

        [TestMethod]
        public void Test_TreeIsBalanced2_For_Null_Tree()
        {
            // Arrange
            BalancedTrees b = new BalancedTrees();

            // Act
            bool balanced = b.TreeIsBalanced2();

            // Assert
            Assert.IsTrue(balanced);
        }

        [TestMethod]
        public void Test_TreeIsBalanced2_For_Single_Node_Tree()
        {
            // Arrange
            BalancedTrees b = new BalancedTrees();
            b.Insert(5);

            // Act
            bool balanced = b.TreeIsBalanced2();

            // Assert
            Assert.IsTrue(balanced);
        }
    }
}
