using System;

namespace Reflect
{
    public class Rabbit : IRun
    {
        public void Run()
        {
            Console.WriteLine("我是兔子跳跳跳~");
        }
    }
}