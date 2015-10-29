using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTrees
{
    // Basic iterative algorithm:
    // 
    // As with recursive, we need to walk the left nodes from whereever we are until we get to a null left node. Rather than 
    // use the call stack, we push the node to a Stack<>.  When we get to the end of a left chain, pop the most recent node 
    // and visit it. Then continue to iterate on that node's right side.

    public class BTreeTraversalIterative : iBTreeTraversal
    {
        private Visit _visit;
        private Queue<int> _que;

        public BTreeTraversalIterative(Visit v, Queue<int> que)
        {
            _visit = v;
            _que = que;
        }

        public void InOrderTraversal(Node n)
        {
            Stack<Node> s = new Stack<Node>();

            while ((s.Count > 0)||(n != null))
            {
                if (n != null)
                {
                    s.Push(n);
                    n = n.left;
                }
                else  // Get here if (n==null), so stack is not empty.
                {
                    n = s.Pop();
                    _visit.VisitNode(n, _que);
                    n = n.right;
                }
            }
        }
    }
}
