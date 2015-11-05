using System;
using System.Collections.Generic;
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
            int[] iKeys = { 4, 3, 9, 1, 7, 11, 15 };
            string[] dataStrings = { "Data1", "Data2", "Data3", "Data4", "Data5", "Data6", "Data7" };
            for (int i=0; i<7; i++)
            {
                Data data = new Data(iKeys[i], dataStrings[i]);
                bt.Insert(iKeys[i], data);
            }
        }

        private void BuildLeftUnbalancedTree(BinaryTree bt)
        {
            int[] iKeys = { 4, 2, 1 };
            string[] dataStrings = { "Data1", "Data2", "Data3"};
            for (int i = 0; i < 3; i++)
            {
                Data data = new Data(iKeys[i], dataStrings[i]);
                bt.Insert(iKeys[i], data);
            }
        }

        private void BuildRightUnbalancedTree(BinaryTree bt)
        {
            int[] iKeys = { 4, 8, 16 };
            string[] dataStrings = { "Data1", "Data2", "Data3" };
            for (int i = 0; i < 7; i++)
            {
                Data data = new Data(iKeys[i], dataStrings[i]);
                bt.Insert(iKeys[i], data);
            }
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
            Data data = new Data();
            b.Insert(1, data);

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
            Data data = new Data();
            bt.Insert(5, data);

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
            Data data = bt.FindNode(7);   // Should be no node to find...

            // Assert
            Assert.IsNull(data);
        }

        [TestMethod]
        public void Test_Find_On_Non_Existant_Key_Fails_For_Single_Node_Tree()
        {
            // Arrange
            BinaryTree bt = new BinaryTree();
            Data data = new Data();
            bt.Insert(17, data);

            // Act
            data = bt.FindNode(23);   // Should be no node to find (23 != 17)...

            // Assert
            Assert.IsNull(data);
        }

        [TestMethod]
        public void Test_Find_Succeeds_For_Single_Node_Tree()
        {
            // Arrange
            BinaryTree bt = new BinaryTree();
            Data data = new Data();
            bt.Insert(17, data);

            // Act
            data = bt.FindNode(17);   // Should find the single node (17 == 17)...

            // Assert
            Assert.IsNotNull(data);
        }

        [TestMethod]
        public void Test_Find_Succeeds_When_Searching_A_Depth_Equals_2_Tree()
        {
            // Arrange
            BinaryTree bt = new BinaryTree();
            BuildLeftUnbalancedTree(bt);
            Data data = new Data(17, "Data4");
            bt.Insert(17,data);   // Tree (should have a depth of two, new leaf node.

            // Act
            data = bt.FindNode(17);   // Should find the single node (17 == 17)...

            // Assert
            Assert.IsNotNull(data);
        }

        [TestMethod]
        public void Test_Find_Succeeds_When_Walking_Complex_Tree()
        {
            // Arrange
            BinaryTree bt = new BinaryTree();
            BuildSevenNodeBalancedTree(bt);
            int iVal = 9;  // Internal Node in tree...

            // Act
            Data data = bt.FindNode(iVal);   // Should find the single node (17 == 17)...

            // Assert
            Assert.IsNotNull(data);
        }

        [TestMethod]
        public void Test_Remove_On_Null_Tree()
        {
            // Arrange
            BinaryTree bt = new BinaryTree();

            // Act
            bool removed = bt.Remove(23);   // Shouldn't find any node match.

            // Assert
            Assert.IsFalse(removed);
        }

        [TestMethod]
        // This is delete case #1, a delete of a leaf.
        public void Test_Delete_On_Single_Node_Tree()
        {
            // Arrange
            BinaryTree bt = new BinaryTree();
            Data data = new Data(17, "Data17");

            bt.Insert(17, data);

            // Act
            bool removed = bt.Remove(17);   // Should find the single node (17 == 17)...

            // Assert
            Assert.IsTrue(removed);
            Assert.IsTrue(bt.TreeDepth() == 0);
        }

        [TestMethod]
        // This is delete case #2, a delete of a node in the middle of a tree where it is "left-only".
        public void Test_Remove_On_Node_With_Only_A_Left_Subtree()
        {
            // Arrange
            BinaryTree bt = new BinaryTree();

            Node n1 = new Node(17);
            Node n2 = new Node(14);   // This is the one we will remove.
            Node n3 = new Node(9);

            // This order of insertion should create a left-only subtree.
            bt.Insert(n1);
            bt.Insert(n2);
            bt.Insert(n3);

            // Act
            bool removed = bt.Remove(14);

            // Assert
            Assert.IsTrue(removed);
            Assert.IsTrue(bt.TreeDepth() == 2);
            Queue<Node> queue = bt.TreeToQueue();
            Assert.IsTrue(queue.Dequeue() == n3);
            Assert.IsTrue(queue.Dequeue() == n1);
        }

        [TestMethod]
        // This is another delete case #2, where a delete of a node in the middle of a tree where it is "right-only".
        public void Test_Remove_On_Node_With_Only_A_Right_Subtree()
        {
            // Arrange
            BinaryTree bt = new BinaryTree();

            Node n1 = new Node(17);
            Node n2 = new Node(23);   // This is the node we will delete.
            Node n3 = new Node(29);

            // This order of insertion should create a right-only subtree.
            bt.Insert(n1);
            bt.Insert(n2);
            bt.Insert(n3);

            // Act
            bool removed = bt.Remove(23);

            // Assert
            Assert.IsTrue(removed);
            Assert.IsTrue(bt.TreeDepth() == 2);
        }

        [TestMethod]
        // This is a test for delete case #3, where the delete is for a node with both left and right children.
        // This is a simple case where the children are leaves.
        public void Test_Remove_On_Node_With_Left_and_right_Leaves()
        {
            // Arrange
            BinaryTree bt = new BinaryTree();

            Node n1 = new Node(17);
            Node n2 = new Node(23);   // This is the node we will delete.
            Node n3 = new Node(21);
            Node n4 = new Node(29);

            bt.Insert(n1);
            bt.Insert(n2);  // Node to delete.
            bt.Insert(n3);
            bt.Insert(n4);

            // Act
            bool removed = bt.Remove(23);

            // Assert
            Assert.IsTrue(removed);
            Queue<Node> queue = bt.TreeToQueue();  // To validate the remaining tree nodes.
            Assert.IsTrue(queue.Count == 3);
            Assert.IsTrue(17 == queue.Dequeue().iKey);
            Assert.IsTrue(21 == queue.Dequeue().iKey);
            Assert.IsTrue(29 == queue.Dequeue().iKey);
        }

        [TestMethod]
        // This is a test for delete case #3, where the delete is for a node with both left and right children.
        // This one has a left child that is a tree itself and will force a "ripple" down the tree below the delete.
        public void Test_Remove_On_Node_With_Left_and_right_Subtrees()
        {
            // Arrange
            BinaryTree bt = new BinaryTree();

            // The test tree looks like:
            //       11
            //      /  \
            //     5    17
            //    / \  
            //   2   7 
            //  / \
            // 1   4
            //    /
            //   3
            Node[] nArray = new Node[8];
            nArray[0] = new Node(11);
            nArray[1] = new Node(5);   // This is the node we will delete below.
            nArray[2] = new Node(17);
            nArray[3] = new Node(2);
            nArray[4] = new Node(7);
            nArray[5] = new Node(1);
            nArray[6] = new Node(4);
            nArray[7] = new Node(3);

            // This order of insertion should create the right tree.
            for (int i = 0; i < 8; i++)
            {
                bt.Insert(nArray[i]);
            }

            // Act
            bool removed = bt.Remove(5);

            // Assert
            Assert.IsTrue(removed);
            Queue<Node> queue = bt.TreeToQueue();  // Get the remaining elements to validate them...
            Assert.IsTrue(queue.Count == 7);
            Assert.IsTrue(1 == queue.Dequeue().iKey);
            Assert.IsTrue(2 == queue.Dequeue().iKey);
            Assert.IsTrue(3 == queue.Dequeue().iKey);
            Assert.IsTrue(4 == queue.Dequeue().iKey);
            Assert.IsTrue(7 == queue.Dequeue().iKey);
            Assert.IsTrue(11 == queue.Dequeue().iKey);
            Assert.IsTrue(17 == queue.Dequeue().iKey);
        }

        public void Test_Remove_On_Root_Node_With_Left_and_right_Subtrees()
        {
            // Arrange
            BinaryTree bt = new BinaryTree();

            // The test tree looks like:
            //       11
            //      /  \
            //     5    17
            //    / \  
            //   2   7 
            //  / \
            // 1   4
            //    /
            //   3
            Node[] nArray = new Node[8];
            nArray[0] = new Node(11);   // This is the node we will delete below (root node).
            nArray[1] = new Node(5);
            nArray[2] = new Node(17);
            nArray[3] = new Node(2);
            nArray[4] = new Node(7);
            nArray[5] = new Node(1);
            nArray[6] = new Node(4);
            nArray[7] = new Node(3);

            // This order of insertion should create a our "complex" tree.
            for (int i = 0; i < 8; i++)
            {
                bt.Insert(nArray[i]);
            }

            // Act
            bool removed = bt.Remove(11);

            // Assert
            Assert.IsTrue(removed);
            Queue<Node> queue = bt.TreeToQueue();  // Get the remaining elements to validate them...
            Assert.IsTrue(queue.Count == 7);
            Assert.IsTrue(1 == queue.Dequeue().iKey);
            Assert.IsTrue(2 == queue.Dequeue().iKey);
            Assert.IsTrue(3 == queue.Dequeue().iKey);
            Assert.IsTrue(4 == queue.Dequeue().iKey);
            Assert.IsTrue(5 == queue.Dequeue().iKey);
            Assert.IsTrue(7 == queue.Dequeue().iKey);
            Assert.IsTrue(17 == queue.Dequeue().iKey);
        }
    }
}
