using Flatbuffer.Serializer;
using Flatbuffer.Serializer.Schema;
using System.Diagnostics;
using System.IO;

namespace Excel.AddIn
{
    public class SchemaWriter
    {
        public string WorkingDirectory { get; set; } = string.Empty;
        public string OutputDirectory { get; set; } = string.Empty;

        public SchemaWriter()
        {
        }

        public (string tablePath, string itemPath) Write(FlatBufferTable table, CompileLanguage language)
        {
            var itemSchemaText = table.ToSchemaItem();
            var itemPath = WriteInternal($"{table.Name}_item", itemSchemaText, language);

            var tableSchemaText = table.ToSchemaTable();
            var tablePath = WriteInternal($"{table.Name}", tableSchemaText, language);

            return (tablePath, itemPath);
        }

        private string WriteInternal(string fileName, string text, CompileLanguage language)
        {
            // 스키마 파일은 임시 폴더에 생성
            var tempPath = Path.GetTempPath();
            var schemaPath = Path.Combine(tempPath, $"{fileName}.fbs");
            File.WriteAllText(schemaPath, text);

            // 클래스 파일 출력
            var flatc = Path.Combine(WorkingDirectory, "flatc.exe");
            Process.Start(flatc, $"-o {OutputDirectory} --{language} {schemaPath}");

            return Path.Combine(OutputDirectory, fileName);
        }
    }
}
