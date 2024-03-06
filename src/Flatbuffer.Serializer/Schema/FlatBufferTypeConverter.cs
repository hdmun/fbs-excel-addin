using Google.FlatBuffers;
using System;
using System.Collections.Generic;

namespace Flatbuffer.Serializer.Schema
{
    public static class FlatBufferTypeConverter
    {
        private static readonly Dictionary<string, Func<string, object>> _types
            = new Dictionary<string, Func<string, object>>
            {
                // TODO : 네이밍만 다른 겹치는 자료형이 있어 제한해서 사용할 필요는 있을듯
                // 당장 생각나는 구조가 이거 밖에 떠오르지 않았다
                { "int8", (value) => byte.Parse(value) },
                { "uint8", (value) => sbyte.Parse(value) },
                { "byte", (value) => byte.Parse(value) },
                { "ubyte", (value) => sbyte.Parse(value) },
                { "bool", (value) => bool.Parse(value) },
                { "int16", (value) => short.Parse(value) },
                { "uint16", (value) => ushort.Parse(value) },
                { "short", (value) => short.Parse(value) },
                { "ushort", (value) => ushort.Parse(value) },
                { "int32", (value) => int.Parse(value) },
                { "uint32", (value) => uint.Parse(value) },
                { "int", (value) => int.Parse(value) },
                { "uint", (value) => uint.Parse(value) },
                { "float32", (value) => float.Parse(value) },
                { "float", (value) => float.Parse(value) },
                { "int64", (value) => long.Parse(value) },
                { "uint64", (value) => ulong.Parse(value) },
                { "long", (value) => long.Parse(value) },
                { "ulong", (value) => ulong.Parse(value) },
                { "float64", (value) => double.Parse(value) },
                { "double", (value) => double.Parse(value) },
                { "string", (value) => value },
            };

        public static bool Validate(string type)
        {
            return _types.ContainsKey(type);
        }

        public static object Cast(FlatBufferBuilder builder, string typename, string value)
        {
            if (false == _types.TryGetValue(typename, out var func))
                return null;

            // 일단 예외 처리
            if ("string" == typename)
                return builder.CreateString(value);
 
            return func.Invoke(value);
        }
    }
}
