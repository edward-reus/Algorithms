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

        Data FindNode(int iKey);

        bool Insert(int iValue, Data data);

        bool Insert(Node node);

        bool Remove(int iKey);

        Queue<Node> TreeToQueue();
    }
}
