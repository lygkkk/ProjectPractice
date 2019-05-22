using System;
using System.IO;
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
            var stream = result.Result;
            Console.WriteLine(result.Result);
            Console.ReadKey();
        }


        static async Task<string> AccessTheWebAsync()
        {
            HttpClient client = new HttpClient();
            return await client.GetStringAsync(
                "http://vip.stock.finance.sina.com.cn/quotes_service/api/jsonp_v2.php/_qsUpRankHTML/Market_Center.getHQNodeDataSimple?page=1&sort=changepercent&asc=0&node=hangye_ZI21&_=1555598643434");

            //return await client.GetStringAsync("http://vip.stock.finance.sina.com.cn/quotes_service/api/jsonp_v2.php/_qsUpRankHTML/Market_Center.getHQNodeDataSimple?page=1&sort=changepercent&asc=0&node=hangye_ZI21&_=1555598643434") ;
        }

        static void DoIndependentWork()
        {
            Console.WriteLine("走一个~");
        }
    }
}
