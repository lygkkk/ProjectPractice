using Microsoft.Office.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Excel = Microsoft.Office.Interop.Excel;
using Office = Microsoft.Office.Core;

namespace ProjectPractice.VstoXml
{
    public partial class ThisAddIn
    {
        private Ribbon1 ribbon;
        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
        }

        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
        }

        private void WorkbookOpen(Excel.Workbook workbook)
        {
            //if (!Application.ActiveWorkbook.Name.Contains("导入设置.xlsx")) return;
            ribbon.Workbook = Application.ActiveWorkbook;
            ribbon.ribbon.InvalidateControl("Tab1");
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
            Application.WorkbookOpen += WorkbookOpen;
        }

        protected override Microsoft.Office.Core.IRibbonExtensibility CreateRibbonExtensibilityObject()
        {
            ribbon = new Ribbon1();
            return ribbon;
        }
     
        #endregion
    }
}
