using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTrees
{
    public class BalancedTrees
    {
        // The depth of the tree is the longest chain of nodes in the b-tree.
        // This recursive method adds one for each node "level" to find the depth.
        public int TreeDepth(Node tree)
        {

            if (tree == null)
            {
                return 0;
            }

            int dLeft = TreeDepth(tree.left);
            int dRight = TreeDepth(tree.right);

            return Math.Max(dLeft, dRight) + 1;  // Plus one for this node...
        }

        // Simple test a binary tree to see if it is balanced. A perfectly balanced tree has,
        // at most a difference of one for the depths of all of the leaves.
        //
        // This one is pretty simple but visits nodes multiple times.
        public bool TreeIsBalanced1(Node tree)
        {
            if (tree == null)
            {
                return true;
            }

            int dLeft = TreeDepth(tree.left);
            int dRight = TreeDepth(tree.right);

            if (Math.Abs(dLeft - dRight) > 1)
            {
                return false;
            }
            else
            {
                return (TreeIsBalanced1(tree.left) && (TreeIsBalanced1(tree.right)));
            }
        }

        public bool TreeIsBalanced2(Node tree)
        {
            int depth = 0;
            return IsBalanced2(tree, ref depth);
        }

        private bool IsBalanced2(Node tree, ref int depth)
        {
            if (tree == null)
            {
                depth = 0;
                return true;
            }

            int depthL = 0;
            int depthR = 0;

            if (IsBalanced2(tree.left,ref depthL)&&(IsBalanced2(tree.right,ref depthR)))
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
    }
}
