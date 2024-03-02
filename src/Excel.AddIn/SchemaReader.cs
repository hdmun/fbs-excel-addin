using Flatbuffer.Serializer.Schema;
using Microsoft.Office.Interop.Excel;
using System;

namespace Excel.AddIn
{
    public class SchemaReader
    {
        private readonly Worksheet _worksheet;

        public SchemaReader(Worksheet worksheet)
        {
            _worksheet = worksheet;
        }

        public FlatBufferTable ReadColumns()
        {
            // find headear signature
            var header = _worksheet.Cells.Find("#scheme");
            if (header is null)
            {
                return null;
            }

            var flatBufferTable = new FlatBufferTable(_worksheet.Name);

            var rowNum = header.Row;
            var columnNum = header.Column;

            // read header columns
            var headers = _worksheet.UsedRange.Rows[rowNum, Type.Missing].Columns;
            var maxColumnNo = columnNum + headers.Count;
            for (int col = columnNum + 1; col < maxColumnNo; col++)
            {
                var cell = _worksheet.Cells[rowNum, col];
                var cellValue = cell.Value2 as string;
                if (cellValue is null)
                    continue; // error

                var split = cellValue.Split(':');
                if (split.Length != 2)
                    continue; // error

                flatBufferTable.Add(name: split[0], type: split[1]);
            }

            return flatBufferTable;
        }
    }
}
