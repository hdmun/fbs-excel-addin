using Flatbuffer.Serializer;
using System.Collections.Generic;

namespace Excel.AddIn.Model
{
    public class ConfigModel
    {
        public Dictionary<CompileLanguage, bool> Lanaguage = new Dictionary<CompileLanguage, bool>();
        public List<string> ClassOutputPaths { get; set; } = new List<string>();
        public List<string> BinaryOutputPaths { get; set; } = new List<string>();
    }
}
