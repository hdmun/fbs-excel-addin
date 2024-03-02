using Flatbuffer.Serializer.Schema;
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
        }
    }
}
