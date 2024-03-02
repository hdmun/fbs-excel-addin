namespace Flatbuffer.Serializer.Schema
{
    public class FlatBufferTableField
    {
        public string Name { get; private set; }
        public string Type { get; private set; }

        public static FlatBufferTableField Create(string name, string type)
        {
            return new FlatBufferTableField
            {
                Name = name,
                Type = type
            };
        }

        private FlatBufferTableField() { }
    }
}
