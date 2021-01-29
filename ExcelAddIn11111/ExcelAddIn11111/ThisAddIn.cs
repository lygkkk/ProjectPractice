using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Excel = Microsoft.Office.Interop.Excel;
using Office = Microsoft.Office.Core;
using Microsoft.Office.Tools.Excel;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using Microsoft.Office.Tools;

namespace ExcelAddIn11111
{
    
    public partial class ThisAddIn
    {
        public UserControl1 u1 = new UserControl1();
        //Ribbon2 r2 = new Ribbon2();
        public Excel.Workbook wbk;
        public CustomTaskPane ctp;
        Ribbon3 r2 = new Ribbon3();
        
        public IDictionary<int, CustomTaskPane> panes = new Dictionary<int, CustomTaskPane>();
        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            //r2.
            //r2.Ribbon_Load();
            Globals.ThisAddIn.Application.Workbooks.Open(@"C:\Users\Administrator\Desktop\代码测试表.xlsm");
            wbk = Globals.ThisAddIn.Application.ActiveWorkbook;
            //Globals.ThisAddIn.Application.Workbooks.Open(@"C:\Users\Administrator\Desktop\Test1.xlsx");
            //Globals.ThisAddIn.Application.Workbooks.Add(@"C:\Users\Administrator\Desktop\代码测试表.xlsm");
            //var wbk = Globals.ThisAddIn.Application.ActiveWorkbook;
            //var sht =wbk.Sheets.Add();
            //sht.Name = "哈哈";
            //wbk.Sheets[1].Delete();
            //Globals.ThisAddIn.Application.Workbooks[1].Sheets[1].Select();

            //Globals.ThisAddIn.Application.Workbooks[2].Sheets[1].range["c1"].value = "heiheihei";
            //Application.WorkbookActivate += s => { MessageBox.Show("qwe"); };
            //Application.WorkbookActivate += WorkbookActive;
            //Application.SheetSelectionChange += CellSelectionChange;
            //Application.WorkbookNewSheet += NewSheet;
        }

        private void CellSelectionChange(object sender, Range target) 
        {
            Excel.Worksheet sht = (Excel.Worksheet)sender;
            MessageBox.Show(sht.Range["a1"].Value);
        }
        private void WorkbookActive(object sender) 
        {
            MessageBox.Show("11");
        }
        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {

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

        //protected override Microsoft.Office.Core.IRibbonExtensibility CreateRibbonExtensibilityObject()
        //{
        //    return r2;
        //}
    }
}
