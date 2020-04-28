using System;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;
using System.Runtime.InteropServices;
using Microsoft.Office.Interop.Excel;
using Microsoft.VisualBasic.CompilerServices;
using MSForms = Microsoft.Vbe.Interop.Forms;

namespace ExcelAddIn1
{
    public partial class ThisAddIn
    {
        //private Excel.Workbooks workbooks;
        //private Excel.Application application;
        private Excel.Dialog dialog;
        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            //Excel.Workbook excel = Application.GetOpenFilename(@"C:\Users\Administrator\Desktop\销售跟踪表.xlsx");
            //MessageBox.Show("aaaaa");

            //Application.Range[]
            MessageBox.Show(Application.ActiveWorkbook.Name);

            //if (Application.ActiveWorkbook.Name == "海星区块员工登记表.xlsm")
            //{

            //try
            //{
            //    GC.Collect();
            //    Marshal.FinalReleaseComObject(Globals.ThisAddIn.Application);
            //    GC.Collect();
            //}
            //catch { }

            Excel.Worksheet sheet = Application.ActiveSheet;
                Shapes shapes = sheet.Shapes;

                Excel.Shape shapeBtn = sheet.Shapes.AddOLEObject("Forms.CommandButton.1", Type.Missing, false, false, Type.Missing, Type.Missing, Type.Missing, 200, 100, 100, 100);
                shapeBtn.Name = "btnClick";
                MSForms.CommandButton CmdBtn = (MSForms.CommandButton)NewLateBinding.LateGet(
                    sheet, null, "btnClick", null, null, null, null);
                CmdBtn.Caption = "Click Me";
                //CmdBtn..Click += new Microsoft.Vbe.Interop.Forms.CommandButtonEvents_ClickEventHandler(CmdBtn_Click);
                //shapes.Item(0).OnAction = "";
                //MessageBox.Show(shapes.Count.ToString());
                //var dd = sheet.Shapes.AddCallout(Office.MsoCalloutType.msoCalloutOne, 20, 20, 20, 20);
                //dd.OnAction
            //}
            //Application.sel
            //Application在ThisAddIn.Designer.cs文件中
            //Application.SheetChange += CellChange;
            //application = (Excel.Application)Marshal.GetActiveObject("excel.application");
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
            //dialog = application.Dialogs;
            dialog = Application.Dialogs[Excel.XlBuiltInDialog.xlDialogAlignment];
            
            //dialog.Application.ActiveCell.InsertIndent(18);
            PropertyInfo[] properties = dialog.GetType().Assembly.GetType().GetProperties();

            foreach (var property in properties)
            {
               
            }

            dialog.Show(Arg6: 1);
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
