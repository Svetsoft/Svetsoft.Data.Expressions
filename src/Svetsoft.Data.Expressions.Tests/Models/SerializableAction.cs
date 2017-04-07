using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Svetsoft.Data.Expressions.Tests
{
    public class SerializableAction
    {
        public string FieldName { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public ExpressionOperator Operation { get; set; }
        
        public string Data { get; set; }
    }
}