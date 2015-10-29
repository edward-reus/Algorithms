using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTrees
{
    // Basic recursive algorithm:
    // 1. Traverse the left subtree recursively.
    // 2. If no left child, then visit the (current) node.
    // 3. Recurse to the right subtree.
    public class BTreeTraversal: iBTreeTraversal
    {
        private Visit _visit;
        private Queue<int> _que;

        public BTreeTraversal(Visit v, Queue<int> que)
        {
            _visit = v;
            _que = que;
        }

        public void InOrderTraversal(Node n)
        {
            if (n == null)
            {
                return;
            }

            InOrderTraversal(n.left);
            _visit.VisitNode(n,_que);
            InOrderTraversal(n.right);
        }
    }
}
