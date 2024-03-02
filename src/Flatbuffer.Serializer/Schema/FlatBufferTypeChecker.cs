using System.Linq;

namespace Flatbuffer.Serializer.Schema
{
    public class FlatBufferTypeChecker
    {
        private static string[] _types =
        {
            "int8", "uint8", "byte", "ubyte", "bool",
            "int16", "uint16", "short", "ushort",
            "int32", "uint32", "int", "uint", "float32", "float",
            "int64", "uint64", "long", "ulong", "float64", "double"
        };

        public static bool Validate(string type)
        {
            return _types.Contains(type);
        }
    }
}
