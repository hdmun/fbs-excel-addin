using Microsoft.CSharp;
using System;
using System.CodeDom.Compiler;
using System.Reflection;

namespace Flatbuffer.Serializer
{
    public class RuntimeCompiler
    {
        private Assembly _assembly;

        public RuntimeCompiler()
        {
            _assembly = null;
        }

        public Tuple<Type, Type> Compile(string[] files, string tableClassName, string itemClassName)
        {
            // 컴파일러 인스턴스 생성
            var provider = new CSharpCodeProvider();
            var parameters = new CompilerParameters();
            parameters.GenerateInMemory = true;
            parameters.ReferencedAssemblies.Add("Google.FlatBuffers.dll");

            // 코드 컴파일
            var results = provider.CompileAssemblyFromFile(parameters, files);
            var assembly = results.CompiledAssembly;

            _assembly = assembly;

            // 컴파일된 어셈블리에서 클래스 형식 가져오기
            var tableClassType = assembly.GetType(tableClassName);
            var itemClassType = assembly.GetType(itemClassName);
            return Tuple.Create(tableClassType, itemClassType);
        }
    }
}
