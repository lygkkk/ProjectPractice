using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using Microsoft.Office.Tools.Ribbon;

namespace ExcelAddIn1
{
    public partial class Ribbon1
    {
        private void Ribbon1_Load(object sender, RibbonUIEventArgs e)
        {
            tab1.Label = "zijzuod";
            Tag = "asasa";
        }

        private void button1_Click(object sender, RibbonControlEventArgs e)
        {
            Workbooks wbks = Globals.ThisAddIn.Application.Workbooks;
            foreach (Workbook item in wbks)
            {
                if (item.Name == "代码测试表.xlsm")
                {
                    
                    Worksheet sht = item.Sheets[1];
                    sht.Range["c1"].Value = "heiheihei";
                    item.Sheets[1].range["c1"].value = "heiheihei";
                    item.Sheets.Add();
                    //sht.Select
                }
            }
        }
    }
}
