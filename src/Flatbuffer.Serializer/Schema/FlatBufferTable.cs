using System.Collections.Generic;

namespace Flatbuffer.Serializer.Schema
{
    public class FlatBufferTable
    {
        private List<FlatBufferTableField> _fields;

        public FlatBufferTable()
        {
            _fields = new List<FlatBufferTableField>();
        }

        public void Add(string name, string type)
        {
            var field = FlatBufferTableField.Create(name, type);
            _fields.Add(field);
        }

        public bool Validate()
        {
            var invalidFields = new List<FlatBufferTableField>();
            foreach (var field in _fields)
            {
                var validate = FlatBufferTypeChecker.Validate(field.Type);
                if (false == validate)
                    invalidFields.Add(field);
            }

            // show message ?

            return invalidFields.Count > 0;
        }
    }
}
