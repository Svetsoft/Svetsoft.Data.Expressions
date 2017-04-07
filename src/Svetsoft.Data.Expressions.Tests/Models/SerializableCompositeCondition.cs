using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Svetsoft.Data.Expressions.Tests
{
    public class SerializableCompositeCondition
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public LogicalOperation LogicalOperation { get; set; }

        public List<SerializableCondition> Conditions { get; set; }
    }
}