using Excel.AddIn.Feature;
using Excel.AddIn.Model;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Excel.AddIn.ViewModel
{
    public class ConfigViewModel
    {
        private static readonly string FilePath = Path.Combine(Directory.GetCurrentDirectory(), "config.ini");
        private readonly IniFile _iniFile = new IniFile();

        private readonly ConfigModel _model = new ConfigModel();

        public List<string> ClassOutputPaths => _model.ClassOutputPaths;
        public List<string> BinaryOutputPaths => _model.BinaryOutputPaths;

        public void Load()
        {
            if (false == File.Exists(FilePath))
                using (var file = File.Create(FilePath)) { }

            _iniFile.Load(FilePath);

            if (_iniFile.TryGetSection("ClassOutput", out var section))
            {
                _model.ClassOutputPaths = section.Select(x => x.Value.ToString()).ToList();
            }

            if (_iniFile.TryGetSection("BinaryOutput", out section))
            {
                _model.BinaryOutputPaths = section.Select(x => x.Value.ToString()).ToList();
            }
        }

        public void Save()
        {
            var section = new IniSection();
            foreach (var (path, index) in _model.ClassOutputPaths.Select((x, i) => (x, i)))
            {
                section[$"{index}"] = path;
            }
            _iniFile["ClassOutput"] = section;

            section = new IniSection();
            foreach (var (path, index) in _model.BinaryOutputPaths.Select((x, i) => (x, i)))
            {
                section[$"{index}"] = path;
            }
            _iniFile["BinaryOutput"] = section;

            _iniFile.Save(FilePath);
        }

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
