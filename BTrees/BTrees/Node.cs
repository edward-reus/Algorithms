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
            iKey = 0;
            data = null;
        }

        public Node(int iNewKey)
        {
            iKey = iNewKey;
            data = null;
        }

        public Node(int iNewKey, Data newData)
        {
            iKey = iNewKey;
            data = newData;
        }

        public int  iKey;
        public Data data;
        public Node left;
        public Node right;
    }
}
