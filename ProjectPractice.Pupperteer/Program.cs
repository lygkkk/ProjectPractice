using System;
using System.Threading.Tasks;

namespace ProjectPractice.Pupperteer
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var movieList = await PageIndex.Start();
        }
    }
}
