using Flatbuffer.Serializer.Schema;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Flatbuffer.Serializer.Tests
{
    [TestClass]
    public class SerializerTests
    {
        [TestMethod]
        public void SerializeTest()
        {
            // 테스용 flatbuffer 스키마 준비
            var name = "Test";
            var flatBuffTable = new FlatBufferTable(name);
            flatBuffTable.Add("test1", "int");
            flatBuffTable.Add("test2", "string");

            var schemItemText = flatBuffTable.ToSchemaItem();
            var schemTableText = flatBuffTable.ToSchemaTable();

            // 스키마 텍스트 파일로 출력
            var tempPath = Path.GetTempPath();
            var itemPath = $@"{tempPath}\{name}_item";
            File.WriteAllText($"{itemPath}.fbs", schemItemText);

            var tablePath = $@"{tempPath}\{name}";
            File.WriteAllText($"{tablePath}.fbs", schemTableText);

            // 클래스 파일 출력
            Process.Start("flatc.exe", $" -o {tempPath} --csharp {itemPath}.fbs").WaitForExit();
            Process.Start("flatc.exe", $" -o {tempPath} --csharp {tablePath}.fbs").WaitForExit();

            // 컴파일
            File.Copy("Google.FlatBuffers.dll", $@"{Path.Combine(tempPath, "Google.FlatBuffers.dll")}", overwrite: true);
            var compiler = new RuntimeCompiler();
            var itemType = compiler.Compile(new string[] { $"{itemPath}.cs" }, $"{name}_item");
            Assert.IsNotNull(itemType);

            var tableType = compiler.Compile(new string[] { $"{itemPath}.cs", $"{tablePath}.cs" }, $"{name}");
            Assert.IsNotNull(tableType);

            // 클래스 인스턴스 생성
            var fbClassInstance = Activator.CreateInstance(itemType);
            var method = itemType.GetMethod($"Create{name}_item");

            // 직렬화 대상 필드 확인
            var fieldMethods = itemType
                .GetMethods(BindingFlags.Public | BindingFlags.Static)
                .Where(x => x.Name.Contains("Add"))
                .Select(x => x.Name.Replace("Add", "").ToLower())
                .ToList();

            var serializer = new Serializer(tableType);
            serializer.WriteTest();

            // 직렬화 대상 데이터 세팅

            // 컴파일된 클래스로 직렬화한 파일 출력

            // 출력된 파일 다시 읽기 테스트
        }
    }
}
