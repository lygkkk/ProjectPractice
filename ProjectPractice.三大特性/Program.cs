using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPractice.三大特性
{
    class Program
    {
        static void Main(string[] args)
        {

            //Computer cp = new Computer();
            //cp.ms = new Upan();
            //cp.Read();
            //cp.Write();


            //MobileStorg ms = new Phone();
            //   ms.Read();
            //   ms.Write();

        }

        void MP3()
        {
             
        }
    }


    abstract class MobileStorg
    {
        public abstract void Read();
        public abstract void Write();

    }

    class Upan : MobileStorg
    {
        public override void Read()
        {
            Console.WriteLine("U盘写数据");
        }

        public override void Write()
        {
            Console.WriteLine("U盘读数据");
        }
    }

    class Mp3 : MobileStorg
    {
        public override void Read()
        {
            Console.WriteLine("MP3读数据");
        }

        public override void Write()
        {
            Console.WriteLine("MP3写数据");
        }
    }

    class Phone : MobileStorg
    {
        public override void Read()
        {
            Console.WriteLine("手机读数据");
        }

        public override void Write()
        {
            Console.WriteLine("手机写数据");
        }
    }

    class Computer
    {
        public MobileStorg ms { get; set; }

        public void Read()
        {
            ms.Read();
        }

        public void Write()
        {
            ms.Write();
        }
    }
}
