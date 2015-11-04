using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BTrees;

namespace BTrees
{
    interface iBinaryTree
    {
        int TreeDepth();

        bool TreeIsBalanced1();

        bool TreeIsBalanced2();

        Node FindNode(int iValue);

        bool Insert(int iValue);

        bool Insert(Node node);

        bool Remove(Node node);

        Queue<Node> TreeToQueue();
    }
}
