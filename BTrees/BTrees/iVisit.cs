using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTrees
{
    public interface iVisit
    {
        void VisitNode(Node n, Queue<int> que);
    }
}
