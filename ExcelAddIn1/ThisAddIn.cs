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

namespace ExcelAddIn1
{
    public partial class ThisAddIn
    {
        private Excel.Workbooks workbooks;
        private Excel.Application application;
        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            //Excel.Workbook excel = Application.GetOpenFilename(@"C:\Users\Administrator\Desktop\销售跟踪表.xlsx");

            Application.SheetChange += CellChange;

        }

        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
        }


        private void CellChange(object sender, Excel.Range target)
        {
            
            
            application = new Excel.Application {Visible = true};
            application.Workbooks.Open(@"C:\Users\Administrator\Desktop\销售跟踪表.xlsx");
            //Excel.Workbook = workbooks[""];

            //application = (Excel.Application) Marshal.GetActiveObject("excel.application");
            //application.Workbooks.Open()
        }

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
