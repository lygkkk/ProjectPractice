using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Delegate
{
    class Program
    {
        public delegate T1 Testqq<T1, T2>(T2 t2);
        static void Main(string[] args)
        {
            (double, int) t = (4.5, 3);
            Console.WriteLine(t.ToString());
            Console.WriteLine($"Hash code of {t} is {t.GetHashCode()}.");

            List<Person> p = new List<Person>()
            {
                new Person(){Name = "q1", Gender = "男"},
                new Person(){Name = "q2", Gender = "男"},
                new Person(){Name = "q3", Gender = "女"},
                new Person(){Name = "q4", Gender = "男"},
                new Person(){Name = "q5", Gender = "女"},
                new Person(){Name = "q6", Gender = "男"},
            };

            Func<List<Person>, IEnumerable<Person>> func = Fun;

            del1(Fun, p);

        }



        public static IEnumerable<Person> Fun(List<Person> s1)
        {
           return s1.Where(p => p.Gender == "女");
        }

        public static void del1(Func<List<Person>, IEnumerable<Person>> qq, List<Person> list)
        {
            
            Debug.Print(qq(list).Count().ToString());
        }
    }
}
