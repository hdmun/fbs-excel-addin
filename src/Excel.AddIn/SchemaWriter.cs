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
            var path = $"{table.Name}.fbs";
            File.WriteAllText(path, table.ToSchemaText());

            // 클래스 파일 출력
            var flatc = "flatc.exe";
            Process.Start(flatc, $"--csharp {path}");
        }
    }
}
