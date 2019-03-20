using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Core;
using Microsoft.Office.Tools.Ribbon;
using Excel = Microsoft.Office.Interop.Excel;
using Tools = Microsoft.Office.Tools;
using TaskPane  = TaskPane;
namespace TaskPane
{
    class Program
    {
        static void Main(string[] args)
        {
            TaskPane taskPane = new TaskPane();
            taskPane.CustomTaskPanes.Add(new UserControl1(), "zdy");

            Excel.Application app = new Excel.Application();
            Excel.Workbook wbk =  app.Workbooks.Add();
            //Excel.Application.DisplayStatusBar = true
            //Excel.AddIn addin = null;
            //Excel.Global global = new Excel.Global();
            //global.Toolbars.Add("Task Pane");
            //app.Visible = true;
            //Tools.Excel.Action action = 
            //app.DisplayDocumentActionTaskPane = true;
            //Microsoft.Office.Tools.CustomTaskPane
            
            
        }
    }
}
