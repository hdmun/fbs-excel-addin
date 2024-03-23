using Flatbuffer.Serializer.Schema;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

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
            var itemPath = Path.Combine(tempPath, $"{name}_item");
            File.WriteAllText($"{itemPath}.fbs", schemItemText);

            var tablePath = Path.Combine(tempPath, $"{name}");
            File.WriteAllText($"{tablePath}.fbs", schemTableText);

            // 클래스 파일 출력
            var flatc = Process.Start("flatc.exe", $"-o {tempPath} --csharp {itemPath}.fbs");
            flatc.WaitForExit();
            Assert.AreEqual(0, flatc.ExitCode);

            flatc = Process.Start("flatc.exe", $"-o {tempPath} --csharp {tablePath}.fbs");
            flatc.WaitForExit();
            Assert.AreEqual(0, flatc.ExitCode);

            // 컴파일
            File.Copy("Google.FlatBuffers.dll", $@"{Path.Combine(tempPath, "Google.FlatBuffers.dll")}", overwrite: true);

            var workingDirectory = Directory.GetCurrentDirectory();
            var compiler = new RuntimeCompiler(workingDirectory);
            var files = new string[]
            {
                Path.Combine(tempPath, $"{itemPath}.cs"),
                Path.Combine(tempPath, $"{tablePath}.cs"),
            };
            compiler.Compile(files);

            var tableType = compiler.GetType(name);
            var itemType = compiler.GetType($"{name}_item");
            Assert.IsNotNull(itemType);
            Assert.IsNotNull(tableType);

            // 직렬화할 테스트용 데이터 세팅

            var rows = new List<FlatBufferTableRow>();
            foreach (var i in Enumerable.Range(1, 10))
            {
                var row = new FlatBufferTableRow();
                row.Add("int", $"{i}");
                row.Add("string", $"string - {i}");
                rows.Add(row);
            }

            // 컴파일된 클래스로 직렬화한 파일 출력
            var serializer = new Serializer(tableType, itemType);
            serializer.Serialize(rows.ToArray());

            // TODO : 출력된 파일 다시 읽기 테스트
        }
    }
}
