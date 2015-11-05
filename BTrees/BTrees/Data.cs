using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTrees
{
    public class Data
    {
        public Data()
        {
            iValue = 0;
            string1 = null;
        }

        public Data(int iNew, string newString)
        {
            iValue = iNew;
            string1 = newString;
        }

        public int iValue;

        public string string1;
    }
}
