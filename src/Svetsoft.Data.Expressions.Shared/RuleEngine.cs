using System.Collections.Generic;
using System.Linq;

namespace Svetsoft.Data.Expressions
{
    public class RuleEngine<T>
    {
        private readonly IDictionary<int, IRule<T>> _rules = new Dictionary<int, IRule<T>>();

        public void AddRule(IRule<T> rule)
        {
            _rules.Add(_rules.Count, rule);
        }

        public void Evaluate(T obj)
        {
            foreach (var rule in _rules.OrderBy(kv => kv.Key).Select(kv => kv.Value))
            {
                rule.Evaluate(obj);
            }
        }
    }
}