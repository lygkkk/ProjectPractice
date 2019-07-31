using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPractice.Chain
{
    class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person { Name = "Tom" }
                .Run()
                .Sing()
                .Swim();
        }
    }

    class Person
    {
        public string Name { get; set; }

        public Person Run()
        {
            Console.WriteLine("Run");
            return this;
        }

        public Person Swim()
        {
            Console.WriteLine("Swim");
            return this;
        }

        public Person Sing()
        {
            Console.WriteLine("Sing");
            return this;
        }
    }
}
