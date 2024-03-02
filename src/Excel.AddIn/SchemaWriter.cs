using Flatbuffer.Serializer.Schema;
using System.Diagnostics;
using System.IO;

namespace Excel.AddIn
{
    public class SchemaWriter
    {
        public SchemaWriter()
        {
        }

        public void Write(FlatBufferTable table)
        {
            var path = $"{table.Name}_item.fbs";
            File.WriteAllText(path, table.ToSchemaItem());

            // 클래스 파일 출력
            var flatc = "flatc.exe";
            Process.Start(flatc, $"--csharp {path}");

            path = $"{table.Name}.fbs";
            File.WriteAllText(path, table.ToSchemaTable());

            // 클래스 파일 출력
            Process.Start(flatc, $"--csharp {path}");
        }
    }
}
