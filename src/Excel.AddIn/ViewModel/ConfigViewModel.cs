using Excel.AddIn.Feature;
using Excel.AddIn.Model;
using Flatbuffer.Serializer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Excel.AddIn.ViewModel
{
    public class ConfigViewModel
    {
        private static readonly string FileName = "config.ini";
        private static string FilePath = string.Empty;
        private readonly IniFile _iniFile = new IniFile();

        private readonly ConfigModel _model = new ConfigModel();

        public List<string> ClassOutputPaths => _model.ClassOutputPaths;
        public List<string> BinaryOutputPaths => _model.BinaryOutputPaths;
        public Dictionary<CompileLanguage, bool> Lanaguage => _model.Lanaguage;

        public void Load(string rootPath)
        {
            FilePath = Path.Combine(rootPath, FileName);

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

            if (_iniFile.TryGetSection("FlatcLanguage", out section))
            {
                _model.Lanaguage = section
                    .Where(x => Enum.TryParse<CompileLanguage>(x.Key, ignoreCase: true, out _))
                    .ToDictionary(
                        x => Enum.TryParse<CompileLanguage>(x.Key, ignoreCase: true, out var result)
                            ? result
                            : CompileLanguage.grpc,
                        x => x.Value.ToBool());
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

            section = new IniSection();
            foreach (var keyValuePair in _model.Lanaguage)
            {
                section[$"{keyValuePair.Key}"] = keyValuePair.Value;
            }
            _iniFile["FlatcLanguage"] = section;

            _iniFile.Save(FilePath);
        }

        public void UpdateCompileOption(CompileLanguage language, bool check)
        {
            _model.Lanaguage[language] = check;
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
