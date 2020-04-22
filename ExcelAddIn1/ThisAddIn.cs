using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;
using Excel = Microsoft.Office.Interop.Excel;
using Office = Microsoft.Office.Core;
using Microsoft.Office.Tools.Excel;
using System.Diagnostics;

namespace ExcelAddIn1
{
    public partial class ThisAddIn
    {
        private Excel.Workbooks workbooks;
        private Excel.Application application;
        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            //Excel.Workbook excel = Application.GetOpenFilename(@"C:\Users\Administrator\Desktop\销售跟踪表.xlsx");
            //MessageBox.Show("aaaaa");
            Application.SheetChange += CellChange;

        }

        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
        }

        #region 单元格内容被修改后触发事件
        /// <summary>
        /// 单元格内容被修改后触发事件
        /// </summary>
        /// <param name="sender">工作表</param>
        /// <param name="target">目标单元格</param>
        private void CellChange(object sender, Excel.Range target)
        {
            var sheet = (Excel.Worksheet) sender;

            //Process[] process = Process.GetProcessesByName("");
            Form1 form1 = new Form1();
            form1.Show();
            //MessageBox.Show(sheet.Name);
            //MessageBox.Show(target.Address);
            //application = new Excel.Application {Visible = true};
            //application.Workbooks.Open(@"C:\Users\Administrator\Desktop\销售跟踪表.xlsx");
            //Excel.Workbook = workbooks[""];

            //application = (Excel.Application) Marshal.GetActiveObject("excel.application");
            //application.Workbooks.Open()
        }

        #endregion


        #region VSTO 生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisAddIn_Startup);
            this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
        }
        
        #endregion
    }
}
