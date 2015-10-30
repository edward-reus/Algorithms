using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BTrees;

namespace UnitTestBalacedTrees
{
    [TestClass]
    public class UnitTestBalancedTrees
    {
        private Node BuildSevenNodeBalancedTree()
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
            n = n.right;
            n.right = new Node();  // Right child of 11 (is 15).
            n.right.iValue = 15;

            return t;
        }

        private Node BuildLeftUnbalancedTree()
        {
            Node tree = new Node();

            tree.left = new Node();
            tree.left.left = new Node();

            return tree;
        }

        private Node BuildRightUnbalancedTree()
        {
            Node tree = new Node();

            tree.right = new Node();
            tree.right.right = new Node();

            return tree;
        }

        [TestMethod]
        public void Test_Tree_Depth_For_Null_Tree()
        {
            // Arrange
            BalancedTrees b = new BalancedTrees();

            // Act
            int depth = b.TreeDepth(null);

            // Assert
            Assert.IsTrue(depth == 0);
        }

        [TestMethod]
        public void Test_Tree_Depth_For_Single_Node_Tree()
        {
            // Arrange
            BalancedTrees b = new BalancedTrees();
            Node tree = new Node();

            // Act
            int depth = b.TreeDepth(tree);

            // Assert
            Assert.IsTrue(depth == 1);
        }

        [TestMethod]
        public void Test_Tree_Depth_For_Seven_Node_Tree()
        {
            // Arrange
            BalancedTrees b = new BalancedTrees();
            Node tree = BuildSevenNodeBalancedTree();

            // Act
            int depth = b.TreeDepth(tree);

            // Assert
            Assert.IsTrue(depth == 4);
        }

        [TestMethod]
        public void Test_TreeIsBalanced1_For_Null_Tree()
        {
            // Arrange
            BalancedTrees b = new BalancedTrees();

            // Act
            bool balanced  = b.TreeIsBalanced1(null);

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
            bool balanced = b.TreeIsBalanced1(tree);

            // Assert
            Assert.IsTrue(balanced);
        }

        [TestMethod]
        public void Test_TreeIsBalanced1_Seven_Node_Balanced_Tree()
        {
            // Arrange
            BalancedTrees b = new BalancedTrees();
            Node tree = BuildSevenNodeBalancedTree();

            // Act
            bool balanced = b.TreeIsBalanced1(tree);

            // Assert
            Assert.IsTrue(balanced);
        }

        [TestMethod]
        public void Test_TreeIsBalanced1_Left_Unbalanced_Tree()
        {
            // Arrange
            BalancedTrees b = new BalancedTrees();
            Node tree = BuildLeftUnbalancedTree();

            // Act
            bool balanced = b.TreeIsBalanced1(tree);

            // Assert
            Assert.IsFalse(balanced);
        }

        [TestMethod]
        public void Test_TreeIsBalanced2_For_Null_Tree()
        {
            // Arrange
            BalancedTrees b = new BalancedTrees();

            // Act
            bool balanced = b.TreeIsBalanced2(null);

            // Assert
            Assert.IsTrue(balanced);
        }

        [TestMethod]
        public void Test_TreeIsBalanced2_For_Single_Node_Tree()
        {
            // Arrange
            BalancedTrees b = new BalancedTrees();
            Node tree = new Node();

            // Act
            bool balanced = b.TreeIsBalanced2(tree);

            // Assert
            Assert.IsTrue(balanced);
        }
    }
}
