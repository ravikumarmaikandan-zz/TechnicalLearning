using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ArraysAndStrings
{
    public class DerivedClass: FirstInterface
    {
        public virtual string Method1()
        {
            return "Method 1";
        }
    }

    public class DerivedClass2 : DerivedClass,SecondInterface
    {
        public string Method2()
        {
            return "Method 2";
        }

        public override string Method1()
        {
            string temp =  base.Method1();
            return temp + " modified";
            var tempss = Singleton.Instance;
        }
        
    }

    public class Singleton
    {
        private static Singleton _instance;

        private Singleton()
        {
            
        }
        
        public static Singleton Instance
        {
            get { return _instance ?? (_instance = new Singleton()); }
        }
    }

}
