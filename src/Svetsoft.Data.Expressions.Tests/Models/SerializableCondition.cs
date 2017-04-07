using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Svetsoft.Data.Expressions.Tests
{
    public class SerializableCondition
    {
        public string FieldName { get; set; }
        
        [JsonConverter(typeof(StringEnumConverter))]
        public ExpressionOperator Operation { get; set; }
        
        public string Value { get; set; }
    }
}