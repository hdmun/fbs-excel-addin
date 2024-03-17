using Excel.AddIn.Model;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Excel.AddIn.ViewModel
{
    public class ConfigViewModel
    {
        [DllImport("kernel32.dll")]
        public static extern long WritePrivateProfileString(string section, string key, string val, string filepath);

        [DllImport("kernel32.dll")]
        public static extern long GetPrivateProfileString(string section, string key, string def, StringBuilder retString, int size, string filepath);

        private readonly ConfigModel _model = new ConfigModel();

        public List<string> ClassOutputPaths => _model.ClassOutputPaths;
        public List<string> BinaryOutputPaths => _model.BinaryOutputPaths;

        public bool AddClassOutputPath(string path)
        {
            if (_model.ClassOutputPaths.Contains(path))
                return false;
            
            _model.ClassOutputPaths.Add(path);
            return true;
        }

        public bool AddBinaryOutputPath(string path)
        {
            if (_model.BinaryOutputPaths.Contains(path))
                return false;

            _model.BinaryOutputPaths.Add(path);
            return true;
        }

        public bool RemoveClassOutputPath(int index)
        {
            if (index < 0 || _model.ClassOutputPaths.Count <= index)
                return false;

            _model.ClassOutputPaths.RemoveAt(index);
            return true;
        }

        public bool RemoveBinaryOutputPath(int index)
        {
            if (index < 0 || _model.BinaryOutputPaths.Count <= index)
                return false;

            _model.BinaryOutputPaths.RemoveAt(index);
            return true;
        }
    }
}
