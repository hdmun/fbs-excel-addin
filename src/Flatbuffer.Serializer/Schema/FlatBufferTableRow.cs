using Google.FlatBuffers;
using System.Collections.Generic;
using System.Linq;

namespace Flatbuffer.Serializer.Schema
{
    public class FlatBufferTableRow
    {
        private readonly List<(string Type, string Value)> _row;

        public FlatBufferTableRow()
        {
            _row = new List<(string Type, string Value)>();
        }

        public bool IsEmpty()
        {
            var empty = _row.Any(x => false == string.IsNullOrEmpty(x.Value));
            return empty;
        }

        public void Add(string type, string value)
        {
            _row.Add((type, value));
        }

        // 직렬화할 파라미터들을 캐스팅 후 리턴
        public IEnumerable<object> ToSerializeParameters(FlatBufferBuilder builder)
        {
            foreach (var (type, value) in _row)
            {
               var casted = FlatBufferTypeConverter.Cast(builder, type, value);
               yield return casted;
            }
        }
    }
}
