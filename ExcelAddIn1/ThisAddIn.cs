using System;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;
using System.Runtime.InteropServices;
using Microsoft.VisualBasic.CompilerServices;
using MSForms = Microsoft.Vbe.Interop.Forms;
using System.Diagnostics;
using System.Collections.Generic;

namespace ExcelAddIn1
{
    public partial class ThisAddIn
    {
        //private Excel.Workbooks workbooks;
        //private Excel.Application application;
        
        private Excel.Dialog dialog;
        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            Application.Workbooks.Open(@"C:\Users\Administrator\Desktop\Test1.xlsx");
            //Application.Workbooks.Open(@"C:\Users\Administrator\Desktop\新建 XLSX 工作表.xlsx");

            Application.ActiveCell.Value = "墨客1";
            Application.Workbooks["Test1.xlsx"].Sheets[1].range["A1"].value = "定格1";
            Excel.Worksheet sht = Application.Workbooks["Test1.xlsx"].Sheets[1];
            Excel.Range rng = sht.Range["A1"];
            string[,] obj = new string[2,2];
            sht.Range["A1:f1"].Value = obj ;

            //Excel.Application application = (Excel.Application)Marshal.GetActiveObject("excel.application");
        }

        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {

        }

        #region 工作簿激活事件
        private void WorkbookActive(object sender)
        { 
        
        }
        #endregion

        #region 新建工作表事件
        private void NewSheet(Excel.Workbook workbook, object sheet)
        { 
        
        }
        #endregion

        #region 单元格内容被修改后触发事件
        /// <summary>
        /// 单元格内容被修改后触发事件
        /// </summary>
        /// <param name="sender">工作表</param>
        /// <param name="target">目标单元格</param>
        private void CellChange(object sender, Excel.Range target)
        {
            Dxx dxx = new Dxx(Application);
            target.Value = dxx.KSzh("aa");

            //Worksheet sht = sender as Worksheet;
            //dialog = application.Dialogs;
            //dialog = Application.Dialogs[Excel.XlBuiltInDialog.xlDialogAlignment];

            //dialog.Application.ActiveCell.InsertIndent(18);
            //PropertyInfo[] properties = dialog.GetType().Assembly.GetType().GetProperties();

            foreach (Excel.Workbook item in Application.Workbooks)
            {
                MessageBox.Show(item.Name);
            }

            //dialog.Show(Arg6: 1);
            //SendKeys.Send("Enter");
            //Application.EnableEvents = false;
            //Application.Range["a:c"].Delete();
            //MessageBox.Show(Application.Range["a1"].NumberFormat);
            //Application.EnableEvents = true;
            //Excel.Sheets sheet = (Excel.Sheets) sender;
            //Excel.Range range = sheet.Item[0];
            //MessageBox.Show(range[0]);

            //Process[] process = Process.GetProcessesByName("");
            //Form1 form1 = new Form1();
            //form1.Show();
            //MessageBox.Show(sheet.Name);
            //MessageBox.Show(target.Address);
            //application = new Excel.Application {Visible = true};
            //application.Workbooks.Open(@"C:\Users\Administrator\Desktop\销售跟踪表.xlsx");
            //Excel.Workbook = workbooks[""];

            //application = (Excel.Application) Marshal.GetActiveObject("excel.application");
            //application.Workbooks.Open()
        }

        #endregion

        #region 事件绑定
        private void EventBind()
        {
            Application.WorkbookNewSheet += (w, o) => { };
            Application.SheetChange += CellChange;
            //Application.SheetSelectionChange += (s, t) => { };
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
