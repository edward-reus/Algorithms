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
    }
}
