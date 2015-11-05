using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTrees
{
    public class Visit : iVisit
    {
        public void VisitNode(Node n, Queue<int> queue)
        {
            if ((n == null)||(queue == null))
            {
                throw new ArgumentNullException();
            }

            queue.Enqueue(n.iKey);
            
            return;
        }
    }
}
