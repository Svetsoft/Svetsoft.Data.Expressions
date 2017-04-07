using System.Collections.Generic;

namespace Svetsoft.Data.Expressions.Tests
{
    public interface ISerializableObject
    {
        List<SerializableRule> Rules { get; set; }
    }
}