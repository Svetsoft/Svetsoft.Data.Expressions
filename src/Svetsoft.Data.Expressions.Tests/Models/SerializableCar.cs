using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Svetsoft.Data.Expressions.Tests
{
    public class SerializableCar : ISerializableObject
    {
        public SerializableCar()
        {
            Rules = new List<SerializableRule>();
        }
        
        [JsonConverter(typeof(StringEnumConverter))]
        public CarClassification Classification { get; set; }
        
        public int WheelCount { get; set; }

        public List<SerializableRule> Rules { get; set; }
    }
}