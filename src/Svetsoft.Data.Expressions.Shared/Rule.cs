using System.Collections.Generic;

namespace Svetsoft.Data.Expressions
{
    public class Rule<T> : IRule<T>
    {
        private readonly IList<IAction<T>> _actions = new List<IAction<T>>();
        private readonly IList<ICondition<T>> _conditions = new List<ICondition<T>>();

        public void AddCondition(ConditionPredicate<T> condition, LogicalOperation operation)
        {
            _conditions.Add(new RuleCondition<T>(condition, operation));
        }

        public void AddCondition(string fieldName, ExpressionOperator expressionOperator, string value, LogicalOperation operation)
        {
            _conditions.Add(new RuleCondition<T>(fieldName, expressionOperator, value, operation));
        }

        public void AddAction(ActionPredicate<T> action)
        {
            _actions.Add(new RuleAction<T>(action));
        }

        public void AddAction(string fieldName, ExpressionOperator expressionOperator, string value)
        {
            _actions.Add(new RuleAction<T>(fieldName, expressionOperator, value));
        }

        public void Evaluate(T obj)
        {
            var result = true;
            foreach (var condition in _conditions)
            {
                var res = condition.Validate(obj);

                switch (condition.Operation)
                {
                    case LogicalOperation.And:
                        result = result && res;
                        break;
                    case LogicalOperation.Or:
                        result = result || res;
                        break;
                }
            }

            if (result)
            {
                foreach (var action in _actions)
                {
                    action.Execute(obj);
                }
            }
        }
    }
}