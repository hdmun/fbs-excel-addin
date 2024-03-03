using Microsoft.CSharp;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace Flatbuffer.Serializer
{
    public class RuntimeCompiler
    {
        private readonly Dictionary<string, Assembly> _assemblies;

        public RuntimeCompiler()
        {
            _assemblies = new Dictionary<string, Assembly>();
        }

        public Type Compile(string[] files, string className)
        {
            // 컴파일러 인스턴스 생성
            var provider = new CSharpCodeProvider();
            var parameters = new CompilerParameters();
            parameters.GenerateInMemory = true;
            parameters.ReferencedAssemblies.Add("Google.FlatBuffers.dll");

            // 코드 컴파일
            var results = provider.CompileAssemblyFromFile(parameters, files);
            var assembly = results.CompiledAssembly;

            _assemblies.Add(className, assembly);

            // 컴파일된 어셈블리에서 클래스 형식 가져오기
            var myClassType = assembly.GetType(className);
            return myClassType;
        }
    }
}
