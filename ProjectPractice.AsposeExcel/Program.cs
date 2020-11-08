using Aspose.Cells;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectPractice.AsposeExcel
{
    class Program
    {
        static string[,] val;
        static Workbook workbook;
        static Worksheet worksheet;
        static Dictionary<string, int> dic;
        [STAThread]
        static void Main(string[] args)
        {
       
            //dic = new Dictionary<string, int>();
            //ReadExcel();
            //var x = dic.Sum(e => e.Value);
            workbook = new Workbook(@"C:\Users\Administrator\Desktop\骨料数据表.xlsx");
            //workbook.Worksheets[1].ActiveCell = "A4" ;
            workbook.Worksheets[1].IsSelected = false;
            workbook.Worksheets[4].IsSelected = true;
            
            workbook.Save(@"C:\Users\Administrator\Desktop\骨料数据表.xlsx");
        }

        static void ReadExcel()
        {
            workbook = new Workbook(@"C:\Users\Administrator\Desktop\2020年马颈河基地9月份临时工工资发放表(1).xlsx");
            worksheet = workbook.Worksheets["明细表"];

            Cells cells = worksheet.Cells;
      
            for (int i = 3; i < cells.MaxDataRow - 1; i++)
            {
                var tmp = cells[i, 5].StringValue.Split('、');
                for (int j = 0; j < tmp.Length; j++)
                {

                    if (dic.ContainsKey(tmp[j]))
                    {
                        dic[tmp[j]] = dic[tmp[j]] + cells[i, 2].IntValue;
                    }
                    else
                    {
                        dic.Add(tmp[j], cells[i, 2].IntValue);
                    }
                }
            }
        }

        static void WriteExcel()
        {
            workbook.Worksheets.Add("");
        }
    }

    class bumen
    { 
        public string yue { get; set; }
           public string ri { get; set; }
        public string bm { get; set; }
    }
}
