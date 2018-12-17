using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace 单据汇总
{
    class Program
    {
        static void Main(string[] args)
        {
            var orderList = GetOrderList();
            #region Select版本
            //var viewData = orderList.GroupBy(e => new { e.BillType, e.ShopName }).Select(e =>
            //  {
            //      var min = e.Min(x => x.RightNum);
            //      var max = e.Max(x => x.RightNum);
            //      var result = "";
            //      var data = e.OrderBy(x => x.RightNum).ToArray();
            //      var index = 0;
            //      for (var i = min; i < max; i++)
            //      {
            //          if (data[index].RightNum != i)
            //          {
            //              result = data[index - 1].RightNum == min ? $"{result}{min}," : $"{result}{min}-{data[index - 1].RightNum},";
            //              min = data[index].RightNum;
            //              i = min;
            //          }
            //          index++;
            //      }
            //      result = min == max ? $"{max}" : $"{result}{min}-{max}";
            //      return new { e.Key.BillType, e.Key.ShopName, section = result.TrimEnd(',') };
            //  });
            #endregion
            #region ForEach版本
            var viewData = orderList.GroupBy(e => new { e.BillType, e.ShopName });
            foreach (var item in viewData.Select(e => e.Key))
            {
                var e = viewData.FirstOrDefault(x => x.Key.BillType == item.BillType && x.Key.ShopName == item.ShopName);
                var min = e.Min(x => x.RightNum);
                var max = e.Max(x => x.RightNum);

                var result = "";
                var data = e.OrderBy(x => x.RightNum).ToArray();
                var index = 0;
                for (var i = min; i < max; i++)
                {
                    if (data[index].RightNum != i)
                    {
                        result = data[index - 1].RightNum == min ? $"{result}{min}," : $"{result}{min}-{data[index - 1].RightNum},";
                        min = data[index].RightNum;
                        i = min;
                    }
                    index++;
                }
                result = min == max ? $"{max}" : $"{result}{min}-{max}";
                var str = $"订单类型：{e.Key.BillType}，店铺名称：{e.Key.ShopName},单据号：{result}";
                Console.WriteLine(str);
                //  return new { e.Key.BillType, e.Key.ShopName, section = result.TrimEnd(',') };

            }
            #endregion

            Console.ReadKey();
        }
        public static IEnumerable<OrderTotal> GetOrderList()
        {
  
            var conn = new OleDbConnection(@"Provider=Microsoft.Ace.OleDb.12.0;Extended Properties=Excel 12.0;Data Source=C:\Users\Administrator\Desktop\单据审核中心.xls");
            string str = "select 单据类型, " +
                         "IIF(INSTR(单位名称, '/') > 0, MID(单位名称, 1, INSTR(单位名称, '/') -1), 单位名称) AS 单位名称," +
                         " CINT(RIGHT(单号, 3)) AS 单号  from [单据审核中心$]";
            var dt = new DataTable();
            using (OleDbDataAdapter da = new OleDbDataAdapter(str, conn))
            {
                da.Fill(dt);
            }

            var viewData = dt.AsEnumerable().GroupBy(x => new {单据类型 = x[0], 单位名称 = x[1]}, x=> x[2]).
                Select(x =>
                {
                    //var dwmc = x.Key.单位名称;
                    var data = Array.ConvertAll<object, int>(x.ToArray(), e => int.Parse(e.ToString()));
                    var max = data.Max();
                    var min = data.Min();
                    var index = 0;
                    var result = "";
                    for (var i = min; i < max; i++)
                    {
                        if(data[index] != i)
                        {
                            result = data[index - 1] == min ? $"{result}{min}," : $"{result}{min}-{data[index - 1]},";
                            min = data[index];
                            i = min;
                        }
                        index++;
                    }
                    result = min == max ? $"{result}{max}" : $"{result}{min}-{max}";

                    return new{ x.Key.单据类型, x.Key.单位名称, result };
                });

            #region 测试FirstOrDefault机制

            string[] ddd = new[] {"柯桥爱尚美化妆品", "⊙唐三彩武林2店", "⊙唐三彩下沙保利湾店"};
            var test = viewData.Select(e =>
            {
                var cc1 = e.单位名称;
                var aa = ddd.FirstOrDefault(a => a.ToString() == e.单位名称.ToString());
                Debug.Print(aa ?? $"{cc1}没有找到");
                return new {e.单据类型, cc = aa + cc1 + "哈哈", e.result };
            });

            #endregion
            foreach (var item in test)
            {
                
            }

            return null;
        }
    }
    class OrderTotal
    {
        public string BillType { get; set; }
        public string ShopName { get; set; }
        public string BillNumber { get; set; }
        public int RightNum { get; set; }

    }

}
