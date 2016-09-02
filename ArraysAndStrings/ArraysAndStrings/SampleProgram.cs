using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArraysAndStrings
{
    public class SampleProgram: DerivedClass2
    {
        public string Print()
        {
            var temp = base.Method1();
            var temp2 = base.Method2();

            return temp + " " + temp2;
        }
    }
}
