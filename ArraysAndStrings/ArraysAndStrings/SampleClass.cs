using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArraysAndStrings
{
    class SampleClass: BaseClass
    {
        public override int Addition(int firstnum, int secondNum)
        {

            return firstnum + secondNum;
        }

        public new int Multiplication(int firstnum, int secondNum)
        {
            firstnum = Addition(firstnum, 2);
            secondNum = Addition(secondNum, 2);
            return firstnum*secondNum;
        }

        public new int Division(int firstnum, int secondnum)
        {
            
            return firstnum/secondnum;
        }        
    }
}
