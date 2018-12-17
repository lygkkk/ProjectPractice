using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ASYNC
{
    class Program
    {
        static void Main(string[] args)
        {
            var d =  Test();
            Console.WriteLine(d);
            Console.WriteLine("222");
            Console.ReadKey();
        }

        private static string Test()
         {
             var x =  Test1();
             return x.Result;
         }

        static async Task<string> Test1()
        {
            await Task.Run(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine(111111);
                Console.WriteLine(1111112);
            });
            Test1();
            Console.WriteLine(33);
            return "11";
        }
    }
}
