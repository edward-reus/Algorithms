using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BTrees;

namespace UnitTestBalacedTrees
{
    [TestClass]
    public class UnitTestBalancedTrees
    {
        private void BuildSevenNodeBalancedTree(BinaryTree bt)
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

        private void BuildLeftUnbalancedTree(BinaryTree bt)
        {
            bt.Insert(4);
            bt.Insert(2);
            bt.Insert(1);
        }

        private void BuildRightUnbalancedTree(BinaryTree bt)
        {
            bt.Insert(4);
            bt.Insert(8);
            bt.Insert(16);
        }

        [TestMethod]
        public void Test_Tree_Depth_For_Null_Tree()
        {
            // Arrange
            BinaryTree b = new BinaryTree();

            // Act
            int depth = b.TreeDepth();

            // Assert
            Assert.IsTrue(depth == 0);
        }

        [TestMethod]
        public void Test_Tree_Depth_For_Single_Node_Tree()
        {
            // Arrange
            BinaryTree b = new BinaryTree();
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
            BinaryTree b = new BinaryTree();
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
            BinaryTree b = new BinaryTree();

            // Act
            bool balanced  = b.TreeIsBalanced1();

            // Assert
            Assert.IsTrue(balanced);
        }

        [TestMethod]
        public void Test_TreeIsBalanced1_For_Single_Node_Tree()
        {
            // Arrange
            BinaryTree b = new BinaryTree();
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
            BinaryTree b = new BinaryTree();
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
            BinaryTree b = new BinaryTree();
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
            BinaryTree b = new BinaryTree();

            // Act
            bool balanced = b.TreeIsBalanced2();

            // Assert
            Assert.IsTrue(balanced);
        }

        [TestMethod]
        public void Test_TreeIsBalanced2_For_Single_Node_Tree()
        {
            // Arrange
            BinaryTree bt = new BinaryTree();
            bt.Insert(5);

            // Act
            bool balanced = bt.TreeIsBalanced2();

            // Assert
            Assert.IsTrue(balanced);
        }

        [TestMethod]
        public void Test_Find_For_Empty_Tree()
        {
            // Arrange
            BinaryTree bt = new BinaryTree();

            // Act
            Node n = bt.FindNode(7);   // Should be no node to find...

            // Assert
            Assert.IsNull(n);
        }

        [TestMethod]
        public void Test_Find_Fails_For_Single_Node_Tree()
        {
            // Arrange
            BinaryTree bt = new BinaryTree();
            bt.Insert(17);

            // Act
            Node n = bt.FindNode(7);   // Should be no node to find (7 != 17)...

            // Assert
            Assert.IsNull(n);
        }

        [TestMethod]
        public void Test_Find_Succeeds_For_Single_Node_Tree()
        {
            // Arrange
            BinaryTree bt = new BinaryTree();
            bt.Insert(17);

            // Act
            Node n = bt.FindNode(17);   // Should find the single node (17 == 17)...

            // Assert
            Assert.IsNotNull(n);
        }

        [TestMethod]
        public void Test_Find_Succeeds_When_Walking_Depth_Equals_2_Tree()
        {
            // Arrange
            BinaryTree bt = new BinaryTree();
            BuildLeftUnbalancedTree(bt);
            bt.Insert(17);   // Tree (should have a depth of two, new leaf node.

            // Act
            Node n = bt.FindNode(17);   // Should find the single node (17 == 17)...

            // Assert
            Assert.IsNotNull(n);
        }

        [TestMethod]
        public void Test_Find_Succeeds_When_Walking_Complex_Tree()
        {
            // Arrange
            BinaryTree bt = new BinaryTree();
            BuildSevenNodeBalancedTree(bt);
            int iVal = 9;  // Internal Node in tree...

            // Act
            Node n = bt.FindNode(iVal);   // Should find the single node (17 == 17)...

            // Assert
            Assert.IsNotNull(n);
        }
    }
}
