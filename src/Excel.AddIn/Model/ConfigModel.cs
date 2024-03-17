using System.Collections.Generic;

namespace Excel.AddIn.Model
{
    public class ConfigModel
    {
        public List<string> ClassOutputPaths { get; set; } = new List<string>();
        public List<string> BinaryOutputPaths { get; set; } = new List<string>();
    }
}
