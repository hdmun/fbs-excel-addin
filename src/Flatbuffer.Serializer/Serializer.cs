using Flatbuffer.Serializer.Schema;
using Google.FlatBuffers;
using System;
using System.Collections;
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

        public void Serialize(FlatBufferTableRow[] rows)
        {
            // 직렬화에 사용할 메소드 가져오기
            var fieldMethods = _fbTableClassType
                .GetMethods(BindingFlags.Public | BindingFlags.Static)
                .Where(x => x.Name.Contains("Add"))
                .ToDictionary(
                    x => x.Name.Replace("Add", "").ToLower(),
                    x => x
                );
            var createItemMethod = _fbItemClassType.GetMethod($"Create{_fbItemClassType.Name}");

            var builder = new FlatBufferBuilder(1);

            // 행 데이터를 담을 리스트 생성
            var itemOffsetType = typeof(Offset<>).MakeGenericType(_fbItemClassType);
            var listType = typeof(List<>).MakeGenericType(itemOffsetType);
            var items = (IList)Activator.CreateInstance(listType);

            // 행 데이터 변환
            foreach (var row in rows)
            {
                // 컬럼 별로 결정된 데이터 타입에 맞춰 캐스팅
                var parameters = new List<object>()
                {
                    builder,
                };
                var rowParams = row.ToSerializeParameters(builder);
                parameters.AddRange(rowParams);

                var item = createItemMethod.Invoke(null, parameters.ToArray());
                items.Add(item);
            }

            // 테이블에 행 데이터 반영
            var createItemVectorMethod = _fbTableClassType.GetMethod($"CreateItemsVector");

            var toArrayMethod = listType.GetMethod("ToArray");
            var itemVectorParams = new object[]
            {
                builder,
                toArrayMethod.Invoke(items, null)
            };
            var serializeItems = createItemVectorMethod.Invoke(null, itemVectorParams);

            // 직렬화 시작
            var startMethod = _fbTableClassType.GetMethod($"Start{_fbTableClassType.Name}");
            startMethod.Invoke(null, new object[] { builder });

            // 행 데이터들 직렬화
            var addItemsMethod = _fbTableClassType.GetMethod($"AddItems");
            addItemsMethod.Invoke(null, new object[] { builder, serializeItems });

            // 직렬화 종료
            var endMethod = _fbTableClassType.GetMethod($"End{_fbTableClassType.Name}");
            var offset = endMethod.Invoke(null, new object[] { builder });

            // 직렬화 마무리
            var tableOffsetType = typeof(Offset<>).MakeGenericType(_fbTableClassType);
            var offsetValueMember = tableOffsetType.GetField("Value", BindingFlags.Public | BindingFlags.Instance);
            var offsetValue = offsetValueMember.GetValue(offset);
            builder.Finish((int)offsetValue);

            // 바이트 바이너리 파일로 출력
            // TODO : path 설정이 필요할 듯?
            var writeBytes = builder.DataBuffer.ToSizedArray();
            File.WriteAllBytes($"{_fbTableClassType.Name}.fb", writeBytes);
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
