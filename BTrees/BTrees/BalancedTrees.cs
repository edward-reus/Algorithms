﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTrees
{
    public class BalancedTrees : iBalancedTrees
    {
        private Node tree = null;

        // The depth of the tree is the longest chain of nodes in the b-tree.
        // This recursive method adds one for each node "level" to find the depth.
        public int TreeDepth()
        {
            return TreeDepthInternal(this.tree);
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
            return TreeIsBalancedInternal1(this.tree);
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
            return TreeIsBalancedInternal2(this.tree, ref depth);
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

            if (tree == null)
            {
                tree = n;     // tree was empty (null), so n is first element.
                return true;
            }

            Node current = tree;
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

        private bool FindParent(Node n, ref Node parent)
        {
            Stack<Node> s = new Stack<Node>();
            s.Push(n);

            parent = null;
            return false;
        }

        public bool Delete(Node n)
        {
            Node parent = null;
            bool found = FindParent(n, ref parent);

            if (found == false)
            {
                // Either the tree is empty or the node doesn't exist in the tree.
                return false;
            }

            if (parent == null)
            {
                // Tree is a single node tree.
                tree = null;
                return true;
            }

            // Case #1: Node n is a leaf (no children)
            if ( (n.left == null) && (n.right == null))
            {
                if (parent.left == n)
                    parent.left = null;
                else
                    parent.right = null;
                return true;
            }
            
            // Case #2: Node n has either a left or right child.
            if (n.left != null)
            {
                parent.left = n.left;
                return true;
            }

            if (n.right != null)
            {
                parent.right = n.right;
                return true;
            }

            // Case #3: The node has both left and right children.
            // Find the largest value in the left subtree, remove it, and 
            // substitute it in with the node being deleted.

            return true;
        }
    }
}
