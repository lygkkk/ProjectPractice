using System;

namespace Reflect
{
    public class Peson : IRun
    {
        private string _name;

        private string Name { get => _name; set => _name = value; }

        public Peson()
        {
        }

        public Peson(string name)
        {
            this.Name = name;
        }

        public void Run()
        {
            Console.WriteLine("我是人类跑跑跑~~~");
        }
    }
}