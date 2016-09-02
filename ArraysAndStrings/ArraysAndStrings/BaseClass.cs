using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArraysAndStrings
{
    public abstract class BaseClass
    {
        public abstract int Addition(int firstnum, int secondNum);
        public int Modulo(int firstnum, int secondNum)
        {
            return firstnum%secondNum;
        }

        public virtual int Multiplication(int firstnum, int secondNum)
        {
            return firstnum*secondNum;
        }

        protected int Division(int firstnum, int secondNum)
        {
            return firstnum / secondNum;
        }

        public static void TestStatic()
        {
            
        }
    }
}
