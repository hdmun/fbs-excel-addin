using Flatbuffer.Serializer.Schema;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Flatbuffer.Serializer.Tests
{
    [TestClass]
    public class FlatBufferTableTests
    {
        [TestMethod]
        public void TestAddAndValidate()
        {
            var name = "Test";
            var flatBuffTable = new FlatBufferTable(name);

            flatBuffTable.Add("test1", "string");
            flatBuffTable.Add("test2", "int");

            var validate = flatBuffTable.Validate();
            Assert.IsTrue(validate);

            flatBuffTable.Add("test3", "int2");

            validate = flatBuffTable.Validate();
            Assert.IsFalse(validate);
        }

        [TestMethod]
        public void TestToSchemaText()
        {
            var name = "Test";
            var flatBuffTable = new FlatBufferTable(name);

            flatBuffTable.Add("test1", "int");
            flatBuffTable.Add("test2", "string");

            var validate = flatBuffTable.Validate();
            Assert.IsTrue(validate);

            var schemText = flatBuffTable.ToSchemaItem();
            var contain = schemText.Contains("test1: int;");
            Assert.IsTrue(contain);

            contain = schemText.Contains("test2: string;");
            Assert.IsTrue(contain);
        }
    }
}
