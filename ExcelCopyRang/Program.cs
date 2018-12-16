using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication.ExtendedProtection.Configuration;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;
namespace ExcelCopyRang
{
    class Program
    {
        static void Main(string[] args)
        {
            Excel.Application app = new Excel.Application();
            Excel.Worksheet newSht;
            app.Visible = true;
            newSht = app.Workbooks.Add().ActiveSheet;
            Excel.Workbook wbk = app.Workbooks.Open(@"C:\Users\Administrator\Desktop\测试.xlsx");
            Excel.Worksheet sht = wbk.Sheets["Sheet1"];
            //sht.Range["a1:h10"].Copy(newSht.Range["a1:h1"]);
            sht.Copy(newSht);
            //app.Workbooks.Add();
            //newSht = app.ActiveSheet;
            //newSht.PasteSpecial();
        }
    }
}
