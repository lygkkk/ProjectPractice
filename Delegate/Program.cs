using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate
{
    class Program
    {
        static void Main(string[] args)
        {
            A a = new A();
            B b = new B(a);
            C c = new C(a);

            a.Raise("左");
            a.Raise("右");
            a.Fall();


        }
    }
}
