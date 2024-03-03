using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Flatbuffer.Serializer.Schema
{
    public class FlatBufferTableRow
    {
        private readonly List<string> _row;

        public FlatBufferTableRow()
        {
            _row = new List<string>();
        }

        public bool IsEmpty()
        {
            var empty = _row.Any(x => false == string.IsNullOrEmpty(x));
            return empty;
        }

        public void Add(string value)
        {
            _row.Add(value);
        }
    }
}
