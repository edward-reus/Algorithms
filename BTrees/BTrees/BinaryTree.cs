using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTrees
{
    public class BinaryTree : iBinaryTree
    {
        private Node _tree = null;

        // The depth of the tree is the longest chain of nodes in the b-tree.
        // This recursive method adds one for each node "level" to find the depth.
        public int TreeDepth()
        {
            return TreeDepthInternal(_tree);
        }
            
        private int TreeDepthInternal(Node t)
        {
            if (t == null)
            {
                return 0;
            }

            int dLeft = TreeDepthInternal(t.left);
            int dRight = TreeDepthInternal(t.right);

            return Math.Max(dLeft, dRight) + 1;  // Plus one for this node...
        }

        // Simple test a binary tree to see if it is balanced. A perfectly balanced tree has,
        // at most a difference of one for the depths of all of the leaves.
        //
        // This one is pretty simple but visits nodes multiple times.
        public bool TreeIsBalanced1()
        {
            return TreeIsBalancedInternal1(_tree);
        }

        public bool TreeIsBalancedInternal1(Node t)
        {
            if (t == null)
            {
                return true;
            }

            int dLeft = TreeDepthInternal(t.left);
            int dRight = TreeDepthInternal(t.right);

            if (Math.Abs(dLeft - dRight) > 1)
            {
                return false;
            }
            else
            {
                return (TreeIsBalancedInternal1(t.left) && (TreeIsBalancedInternal1(t.right)));
            }
        }

        public bool TreeIsBalanced2()
        {
            int depth = 0;
            return TreeIsBalancedInternal2(_tree, ref depth);
        }

        private bool TreeIsBalancedInternal2(Node t, ref int depth)
        {
            if (t == null)
            {
                depth = 0;
                return true;
            }

            int depthL = 0;
            int depthR = 0;

            if (TreeIsBalancedInternal2(t.left,ref depthL)&&(TreeIsBalancedInternal2(t.right,ref depthR)))
            {
                int diff = Math.Abs(depthL - depthR);
                if (diff <= 1)
                {
                    depth = 1 + (Math.Max(depthL, depthR));
                    return true;
                }
            }
            return false;
        }

        public bool Insert(int iValue)
        {
            Node n = new Node(iValue);

            return Insert(n);
        }

        public bool Insert(Node n)
        {
            if (_tree == null)
            {
                _tree = n;     // tree was empty (null), so n is first element.
                return true;
            }

            Node current = _tree;
            Node parent = null;
            bool inserted = false;

            while (true)
            {
                parent = current;
                if (current.iValue == n.iValue)
                {
                    return true;  // Element (node) is already in tree.
                }

                if (current.iValue > n.iValue)
                {
                    current = current.left;
                    if (current == null)
                    {
                        parent.left = n;  // Less-than insert left.
                        inserted = true;
                        break;
                    }
                }
                else
                {
                    current = current.right;
                    if (current == null)
                    {
                        parent.right = n;
                        inserted = true;
                        break;
                    }
                }
            }

            return inserted;
        }

        public bool FindNodeAndParent(Node t, Node n, ref Node parent)
        {
            if (t == null)    // Check for empty tree.
            {
                parent = null;
                return false;
            }

            if (t == n)
            {
                return true;
            }

            parent = t;

            bool found;

            if (t.iValue > n.iValue)
            {
                if (t.left != null)
                {
                    found = FindNodeAndParent(t.left, n, ref parent);
                    if (found == true)
                    {
                        return true;
                    }
                }
            }

            if (t.right != null)
            {
                found = FindNodeAndParent(t.right, n, ref parent);
                if (found == true)
                {
                    return true;
                }
            }

            return false;
        }

        // FindNodeyValue() is a pre-order recursive search. In a well balanced tree this is O(log number-of-nodes).
        private Node FindNodeByValue(Node t, int iVal)
        {
            if (t == null)
            {
                return null;
            }

            if (iVal == t.iValue)  // Check for match.
            {
                return t;
            }

            if (iVal < t.iValue)   // Check to see if we need to go look left.
            {
                return FindNodeByValue(t.left, iVal);
            }

            // Only case left is to check the right branch of the tree.
            return FindNodeByValue(t.right, iVal);
        }

        public Node FindNode(int iVal)
        {
            return FindNodeByValue(_tree, iVal);
        }

        public bool Remove(Node nRemove)
        {
            Node parent = null;
            bool found = FindNodeAndParent(_tree, nRemove, ref parent);

            if (found == false)
            {
                // Either the tree is empty or the node doesn't exist in the tree.
                return false;
            }

            // Ok, node was found.
            if (parent == null)
            {
                // Tree is a single node tree.
                _tree = null;
                return true;
            }

            // Case #1: Node n is a leaf (no children)
            if ( (nRemove.left == null) && (nRemove.right == null))
            {
                if (parent.left == nRemove)
                    parent.left = null;
                else
                    parent.right = null;
                return true;
            }
            
            // Case #2: Node n has either a left or right child but not both.
            if((nRemove.left != null) && (nRemove.right == null))
            {
                if (parent.left == nRemove)
                {
                    parent.left = nRemove.left;
                }
                else
                {
                    parent.right = nRemove.left;
                }

                return true;
            }

            if ((nRemove.left == null) && (nRemove.right != null))
            {
                if (parent.left == nRemove)
                {
                    parent.left = nRemove.right;
                }
                else
                {
                    parent.right = nRemove.right;
                }

                return true;
            }

            // Case #3: The node has both left and right children.
            // Find the largest value in the left subtree, copy its data into the node being "removed" then 
            // remove that largest node from the tree (note: it won't have a right subtree).
            Node nLargest = nRemove.left;
            Node nLargestParent = nRemove;
            while (nLargest.right != null)
            {
                nLargestParent = nLargest;
                nLargest = nLargest.right;
            }

            int tempValue = nLargest.iValue;

            bool removed = Remove(nLargest);

            nRemove.iValue = tempValue;

            return true;
        }

        private void InOrderTreeToQueue(Node t, Queue<Node> queue)
        {
            if (t != null)
            {
                InOrderTreeToQueue(t.left, queue);
                queue.Enqueue(t);
                InOrderTreeToQueue(t.right, queue);
            }
        }

        public Queue<Node> TreeToQueue()
        {
            Queue<Node> queue = new Queue<Node>();

            InOrderTreeToQueue(_tree, queue);

            return queue;
        }
    }
}
