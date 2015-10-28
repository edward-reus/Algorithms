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

        BTreeTraversal(Visit v)
        {
            _visit = v;
        }

        public void InOrder(Node n)
        {
            if (n == null)
            {
                return;
            }

            InOrder(n.left);
            _visit.VisitNode(n);
            InOrder(n.right);
        }
    }
}
