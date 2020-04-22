using System;
using System.Text.RegularExpressions;

namespace ProjectPractice.Regex
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            string pattern = @"—————— \d*  当前账号 |拖 \d* :";
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(pattern);

            
        }
    }
}
