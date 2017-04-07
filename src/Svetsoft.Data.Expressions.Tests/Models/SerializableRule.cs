using System.Collections.Generic;

namespace Svetsoft.Data.Expressions.Tests
{
    public class SerializableRule
    {
        public string Name { get; set; }
        
        public bool Active { get; set; }

        public List<SerializableCompositeCondition> Conditions { get; set; }

        public List<SerializableAction> Actions { get; set; }
    }
}