using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_2
{
    public class MyList
    {
        public int CountSameNumbers { get; private set; }
        public List<int> List { get; private set; }
        public MyList(int count, List<int> list)
        {
            CountSameNumbers = count;
            List = list;
        }
    }
}