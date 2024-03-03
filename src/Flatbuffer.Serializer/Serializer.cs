using Google.FlatBuffers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Flatbuffer.Serializer
{
    public class Serializer
    {
        private readonly Type _fbTableClassType;
        private readonly Type _fbItemClassType;

        public Serializer(Type fbTableClassType, Type fbItemClassType)
        {
            _fbTableClassType = fbTableClassType;
            _fbItemClassType = fbItemClassType;
        }

        public void WriteTest()
        {
            var rows = new List<List<string>>()
            {
                new List<string>() { "몬스터1", "1000", "100" },
                new List<string>() { "몬스터2", "2000", "200" },
                new List<string>() { "몬스터3", "3000", "300" },
                new List<string>() { "몬스터4", "4000", "400" },
                new List<string>() { "몬스터5", "5000", "500" },
            };

            var builder = new FlatBufferBuilder(1);

            // 배열로 만들고 파일에 쓰기
            var fields = new List<Offset<Sheet1_item>>();

            // Sheet1.StartItemsVector(builder, rows.Count);
            foreach (var row in rows)
            {
                var name = builder.CreateString(row[0]);
                var field = Sheet1_item.CreateSheet1_item(builder, name, hp: 1, mana: 1);
                fields.Add(field);
            }
            //var vector = builder.EndVector();

            var items = Sheet1.CreateItemsVector(builder, fields.ToArray());

            Sheet1.StartSheet1(builder);
            Sheet1.AddItems(builder, items);
            var offset = Sheet1.EndSheet1(builder);
            builder.Finish(offset.Value);

            var writeBytes = builder.DataBuffer.ToSizedArray();
            File.WriteAllBytes("test.bin", writeBytes);

            var readBytes = File.ReadAllBytes("test.bin");
            var byteBuffer = new ByteBuffer(readBytes);
            var table = Sheet1.GetRootAsSheet1(builder.DataBuffer);

            var loadItems = new List<Sheet1_item?>();
            for (int i = 0; i < table.ItemsLength; i++)
            {
                var item = table.Items(i);
                loadItems.Add(item);
            }

            // 메서드 호출하여 확인
            var fieldMethods = _fbTableClassType
                .GetMethods(BindingFlags.Public | BindingFlags.Static)
                .Where(x => x.Name.Contains("Add"))
                .Select(x => x.Name.Replace("Add", "").ToLower())
                .ToList();
        }
    }
}
