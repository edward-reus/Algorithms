using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTrees
{
    // Nodes of a simple binary tree.
    public class Node
    {
        public Node()
        {
            iValue = 0;
        }

        public Node(int iNew)
        {
            iValue = iNew;
        }

        public int iValue;
        public Node left;
        public Node right;
    }
}
