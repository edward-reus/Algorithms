using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTrees
{
    public class BTreeTraversal: iBTreeTraversal
    {
        private Visit _visit;
        private Queue<int> _que;

        BTreeTraversal(Visit v, Queue<int> que)
        {
            _visit = v;
            _que = que;
        }

        public void InOrder(Node n)
        {
            if (n == null)
            {
                return;
            }

            InOrder(n.left);
            _visit.VisitNode(n,_que);
            InOrder(n.right);
        }
    }
}
