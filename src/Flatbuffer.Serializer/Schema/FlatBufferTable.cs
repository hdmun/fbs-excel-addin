using System.Collections.Generic;
using System.Text;

namespace Flatbuffer.Serializer.Schema
{
    public class FlatBufferTable
    {
        private string _name;
        private readonly string _namespace;
        private readonly List<FlatBufferTableField> _fields;
        private readonly List<FlatBufferTableRow> _rows;

        public string Name => _name;

        public FlatBufferTable(string name)
        {
            _name = name;
            _fields = new List<FlatBufferTableField>();
            _rows = new List<FlatBufferTableRow>();
        }

        public void Add(string name, string type)
        {
            var field = FlatBufferTableField.Create(name, type);

            // TODO : 같은 이름을 쓸 경우 array 로 사용할 수 있게
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

        // row 하나에 대한 schema 정의
        public string ToSchemaItem()
        {
            var text = new StringBuilder();

            if (false == string.IsNullOrEmpty(_namespace))
            {
                text.AppendLine($"namespace {_namespace};");
            }

            text.AppendLine($"struct {_name}_item {{");

            foreach (var field in _fields)
            {
                text.AppendLine($"  {field.Name}: {field.Type};");
            }

            text.AppendLine("}");
            text.AppendLine($"root_type {_name}_item");

            return text.ToString();
        }

        // row 를 감싸는 schema 정의
        public string ToSchemaTable()
        {
            var text = new StringBuilder();

            text.AppendLine($"include \"{_name}_item.fbs\";");

            if (false == string.IsNullOrEmpty(_namespace))
            {
                text.AppendLine($"namespace {_namespace};");
            }

            text.AppendLine($"table {_name} {{");
            text.AppendLine($"  items : [{_name}_item];");
            text.AppendLine("}");
            text.AppendLine($"root_type {_name}");

            return text.ToString();
        }
    }
}
