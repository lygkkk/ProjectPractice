using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace ProjectPractice.Async
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //var client = new HttpClient();
            //var result = await client.GetStringAsync("https://www.baidu.com/");

            Task<string> result = AccessTheWebAsync();
            DoIndependentWork();

            result.GetAwaiter().GetResult();
            Console.WriteLine(result.Result);
            Console.ReadKey();
        }


        static async Task<string> AccessTheWebAsync()
        {
            HttpClient client = new HttpClient();

            return await client.GetStringAsync("https://www.cnblogs.com/taro/p/7285126.html") ;
        }

        static void DoIndependentWork()
        {
            Console.WriteLine("走一个~");
        }
    }
}
