using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BTrees;

namespace BTrees
{
    interface iBalancedTrees
    {
        int TreeDepth();

        bool TreeIsBalanced1();

        bool TreeIsBalanced2();

        bool Insert(int iValue);

        bool Delete(Node node);
    }
}
