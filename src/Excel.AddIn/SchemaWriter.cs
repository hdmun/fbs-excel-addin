﻿using Flatbuffer.Serializer;
using Flatbuffer.Serializer.Schema;
using System.Diagnostics;
using System.IO;

namespace Excel.AddIn
{
    public static class SchemaWriter
    {
        public static (string tablePath, string itemPath) Write(FlatBufferTable table)
        {
            var itemPath = $"{table.Name}_item.fbs";
            File.WriteAllText(itemPath, table.ToSchemaItem());

            // 클래스 파일 출력
            var flatc = "flatc.exe";
            Process.Start(flatc, $"--csharp {itemPath}");

            var tablePath = $"{table.Name}.fbs";
            File.WriteAllText(tablePath, table.ToSchemaTable());

            // 클래스 파일 출력
            Process.Start(flatc, $"--csharp {tablePath}");

            return (tablePath, itemPath);
        }
    }
}
