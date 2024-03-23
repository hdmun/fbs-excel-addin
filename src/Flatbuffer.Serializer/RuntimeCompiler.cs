using Microsoft.CSharp;
using System;
using System.CodeDom.Compiler;
using System.IO;
using System.Reflection;

namespace Flatbuffer.Serializer
{
    public class RuntimeCompiler
    {
        private readonly string _workingDirectory;
        private Assembly _assembly;

        public RuntimeCompiler(string workingDirectory)
        {
            _workingDirectory = workingDirectory;
            _assembly = null;
        }

        public Type GetType(string className) => _assembly.GetType(className);

        public void Compile(string[] files)
        {
            // 컴파일러 인스턴스 생성
            var provider = new CSharpCodeProvider();
            var parameters = new CompilerParameters();

            parameters.GenerateInMemory = true;
            parameters.ReferencedAssemblies.Add(Path.Combine(_workingDirectory, "Google.FlatBuffers.dll"));

            // 코드 컴파일
            var results = provider.CompileAssemblyFromFile(parameters, files);
            _assembly = results.CompiledAssembly;
        }
    }
}
