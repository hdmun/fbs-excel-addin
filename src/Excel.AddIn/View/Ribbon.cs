using Excel.AddIn.Compile;
using Microsoft.Office.Interop.Excel;
using Microsoft.Office.Tools.Ribbon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Excel.AddIn
{
    public partial class Ribbon
    {
        private void Ribbon_Load(object sender, RibbonUIEventArgs e)
        {

        }

        private void button_Click(object sender, RibbonControlEventArgs e)
        {
            var workbook = Globals.ThisAddIn.Application.ActiveWorkbook;
            var worksheet = workbook.ActiveSheet as Worksheet;

            var reader = new SchemaReader(worksheet);
            reader.Read();
        }
    }
}
