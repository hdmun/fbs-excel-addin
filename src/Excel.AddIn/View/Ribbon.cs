using Microsoft.Office.Interop.Excel;
using Microsoft.Office.Tools.Ribbon;

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
            var flatbuffTable = reader.ReadColumns();

            var writer = new SchemaWriter();
            writer.Write(flatbuffTable);

            reader.ReadAll();
        }
    }
}
