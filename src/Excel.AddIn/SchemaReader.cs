using Flatbuffer.Serializer.Schema;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public List<FlatBufferTableRow> ReadRowAll(FlatBufferTable table)
        {
            // find headear signature
            var header = _worksheet.Cells.Find("#scheme");
            if (header is null)
            {
                return null;
            }

            var rows = new List<FlatBufferTableRow>();

            // 맨앞 열의 행이 빈칸이 나올 때 까지 데이터를 읽는다
            var startRow = header.Row + 1;
            var startColumn = header.Column;
            Range headers = _worksheet.UsedRange.Rows[header.Row, Type.Missing];
            int columnCount = headers.Columns.Count;
            var fields = table.Fields.ToList();

            for (int row = startRow; true; row++)
            {
                var tableRow = ReadRowInternal(fields, row, startColumn, columnCount);

                // 비어있는 행이면 읽기 중단
                if (tableRow.IsEmpty())
                    break;

                rows.Add(tableRow);
            }

            return rows;
        }

        private FlatBufferTableRow ReadRowInternal(List<FlatBufferTableField> fields, int row, int col, int colCount)
        {
            var tableRow = new FlatBufferTableRow();
            // 컬럼을 증가시키면서 셀 데이터 읽기
            for(int i = 0; i < fields.Count; i++)
            {
                var field = fields[i];
                var column = col + i;
                var cell = _worksheet.Cells[row, column];
                // cell.Value2 can be double for numbers, string for strings, or bool.
                // We need to handle this conversion safely.
                // Assuming everything comes as string or convertible to string for now since Parse handles strings.
                // But Value2 returns double for numbers.
                var cellValue = Convert.ToString(cell.Value2); 

                tableRow.Add(field.Type, cellValue);
            }

            return tableRow;
        }

        private bool IsValidRow(int row, int col, int colCount)
        {
            // 컬럼을 증가시키면서 셀 데이터 읽어 비어있는지 확인
            foreach (var column in Enumerable.Range(col, colCount))
            {
                var cell = _worksheet.Cells[row, column];
                if (false == string.IsNullOrEmpty(cell.Value2))
                    return true;
            }
            return false;
        }
    }
}
