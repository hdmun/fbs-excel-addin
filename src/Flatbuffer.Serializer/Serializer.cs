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

        public void Serialize(IEnumerable<FlatBufferTableRow> rows)
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
    }
}
