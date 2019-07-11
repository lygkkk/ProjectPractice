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
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using Tools = Microsoft.Office.Tools;
namespace 单据汇总
{
    class Program
    {
        public static Form1 form;
         static void Main(string[] args)
         {
            
            form = new Form1{ShowInTaskbar = true};
            
            // string str = "1,2,3";
            // string str1 = "1,3,3";
            ////var t1 = string.Join(",", str.Split(',').OrderBy(e => e)) == string.Join(",", str1.Split(',').OrderBy(e => e));
            //var t1 = string.Join(",", str1.Split(',').OrderBy(e => e));
            //var t2 = str.Split(',').Join(str1.Split(','), c => c, e => e, (c, e) => new {c,e}).Any();
            //OperationExcel();
        

            //var orderList = GetOrderList();
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
            //var viewData = orderList.GroupBy(e => new { e.BillType, e.ShopName });
            //foreach (var item in viewData.Select(e => e.Key))
            //{
            //    var e = viewData.FirstOrDefault(x => x.Key.BillType == item.BillType && x.Key.ShopName == item.ShopName);
            //    var min = e.Min(x => x.RightNum);
            //    var max = e.Max(x => x.RightNum);

            //    var result = "";
            //    var data = e.OrderBy(x => x.RightNum).ToArray();
            //    var index = 0;
            //    for (var i = min; i < max; i++)
            //    {
            //        if (data[index].RightNum != i)
            //        {
            //            result = data[index - 1].RightNum == min ? $"{result}{min}," : $"{result}{min}-{data[index - 1].RightNum},";
            //            min = data[index].RightNum;
            //            i = min;
            //        }
            //        index++;
            //    }
            //    result = min == max ? $"{max}" : $"{result}{min}-{max}";
            //    var str = $"订单类型：{e.Key.BillType}，店铺名称：{e.Key.ShopName},单据号：{result}";
            //    Console.WriteLine(str);
            //  return new { e.Key.BillType, e.Key.ShopName, section = result.TrimEnd(',') };

            //}
            #endregion

            //Console.ReadKey();
        }

        #region 操作excel

        public static void OperationExcel()
        {
            Excel.Application app = new Excel.Application();
            
            app.Workbooks.Add();
            app.DisplayDocumentActionTaskPane = true;
            Excel.Worksheet sht = app.ActiveSheet;
            
            #region 写入数据

            object[,] values = new object[2, 3] { { "test", "", null }, { "序号", "名称", "描述" } };
            
            sht.get_Range("A1", "C2").Value2 = values;
            int x = values.GetLength(1);
            int low = values.GetLowerBound(0);
            int up = values.GetUpperBound(1);
            for (int i = 0; i < x; i++)
            {
                Debug.Print(values[1,i].ToString());
            }

            #endregion


            app.Visible = true;
        }


        #endregion

        #region 测试函数
        /// <summary>
        /// 获取数据并进行单号汇总
        /// </summary>
        /// <returns></returns>
        public static  IEnumerable<OrderTotal> GetOrderList()
        {
            var ceshi = "";

            #region 连接数据库并获取数据

            //var conn = new OleDbConnection(@"Provider=Microsoft.Ace.OleDb.12.0;Extended Properties=Excel 12.0;Data Source=C:\Users\Administrator\Desktop\单据审核中心.xls");
            //string str = "select 单据类型, " +
            //             "IIF(INSTR(单位名称, '/') > 0, MID(单位名称, 1, INSTR(单位名称, '/') -1), 单位名称) AS 单位名称," +
            //             " CINT(RIGHT(单号, 3)) AS 单号  from [单据审核中心$]";
            //var dt = new DataTable();
            //using (OleDbDataAdapter da = new OleDbDataAdapter(str, conn))
            //{
            //    da.Fill(dt);
            //}

            #endregion

            #region 测试窗体是否能阻止继续执行代码

            //var tmp = dt.AsEnumerable().Select(e =>
            //{
            //    var tmp1 = "";
            //    ceshi = e.ItemArray[2].ToString();
            //    if (e.ItemArray[0].ToString() == "盘点单")
            //    {

            //        tmp1 = Test(e[0].ToString() + "22");

            //    }

            //    return tmp1== "" ? e.ItemArray[0] : tmp1;
            //});
            


            #endregion

            #region 单号汇总

            //var viewData = dt.AsEnumerable().GroupBy(x => new {单据类型 = x[0], 单位名称 = x[1]}, x=> x[2]).
            //    Select(x =>
            //    {
            //        //var dwmc = x.Key.单位名称;
            //        var data = Array.ConvertAll<object, int>(x.ToArray(), e => int.Parse(e.ToString()));
            //        var max = data.Max();
            //        var min = data.Min();
            //        var index = 0;
            //        var result = "";
            //        for (var i = min; i < max; i++)
            //        {
            //            if(data[index] != i)
            //            {
            //                result = data[index - 1] == min ? $"{result}{min}," : $"{result}{min}-{data[index - 1]},";
            //                min = data[index];
            //                i = min;
            //            }
            //            index++;
            //        }
            //        result = min == max ? $"{result}{max}" : $"{result}{min}-{max}";

            //        return new{ x.Key.单据类型, x.Key.单位名称, result };
            //    });

            #endregion

            #region 测试FirstOrDefault机制

            //string[] ddd = new[] {"柯桥爱尚美化妆品", "⊙唐三彩武林2店", "⊙唐三彩下沙保利湾店"};
            //var test = viewData.Select(e =>
            //{
            //    var cc1 = e.单位名称;
            //    var aa = ddd.FirstOrDefault(a => a.ToString() == e.单位名称.ToString());
            //    Debug.Print(aa ?? $"{cc1}没有找到");
            //    return new {e.单据类型, cc = aa + cc1 + "哈哈", e.result };
            //});

            #endregion
            
            return null;
        }

        #endregion

        #region 事件测试
        /// <summary>
        /// 事件测试
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
         public static  string Test(string str)
        {
            var tmp1 = "";
            if (form == null)
            {
                form = new Form1();
                form.ConfirmClick += s =>
                {
                    if (string.IsNullOrEmpty(s))
                    {
                        MessageBox.Show(@"不得为空");
                        return;
                    }
                    tmp1 = s;
                    
                    form.Hide();
                };
            }
            form.ShowDialog();
            return tmp1;
        }

        #endregion
       


    }

    

    class OrderTotal
    {
        public string BillType { get; set; }
        public string ShopName { get; set; }
        public string BillNumber { get; set; }
        public int RightNum { get; set; }

    }

}
