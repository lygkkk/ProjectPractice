using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Tools;
using Microsoft.Office.Tools.Ribbon;

namespace ExcelAddIn11111
{
    public partial class Ribbon3
    {
        
        //public 
        private void Ribbon3_Load(object sender, RibbonUIEventArgs e)
        {

        }

        private void button1_Click(object sender, RibbonControlEventArgs e)
        {
            if (!Globals.ThisAddIn. panes.ContainsKey(Globals.ThisAddIn.Application.ActiveWindow.Hwnd))
            {
                Globals.ThisAddIn.ctp = Globals.ThisAddIn.CustomTaskPanes.Add(Globals.ThisAddIn. u1, "好", Globals.ThisAddIn.Application.ActiveWindow);
                Globals.ThisAddIn.ctp.DockPosition = Microsoft.Office.Core.MsoCTPDockPosition.msoCTPDockPositionRight;
                Globals.ThisAddIn.panes.Add(Globals.ThisAddIn.Application.ActiveWindow.Hwnd, Globals.ThisAddIn.ctp);
               
            }
            Globals.ThisAddIn.ctp.Control.
            Globals.ThisAddIn.ctp.Visible = true;
        }
    }
}
