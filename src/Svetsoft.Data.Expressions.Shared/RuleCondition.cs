namespace Svetsoft.Data.Expressions
{
    public class RuleCondition<T> : ICondition<T>
    {
        private readonly ConditionPredicate<T> _conditions;

        public RuleCondition(ConditionPredicate<T> conditions, LogicalOperation operation)
        {
            _conditions = conditions;
            Operation = operation;
        }

        public RuleCondition(string fieldName, ExpressionOperator expressionOperator, string value, LogicalOperation operation)
        {
            FieldName = fieldName;
            ExpressionOperator = expressionOperator;
            Value = value;
            Operation = operation;
        }

        public string FieldName { get; }
        public ExpressionOperator ExpressionOperator { get; }
        public string Value { get; }
        public LogicalOperation Operation { get; }

        public bool Validate(T obj)
        {
            if (_conditions != null)
            {
                return _conditions(obj);
            }

            var value = VariableEvaluation<T>.Evaluate(Value, obj);
            var dynamicCondition = Dynamic.GetConditionPredicate<T>(FieldName, ExpressionOperator, value);
            return dynamicCondition(obj);
        }
    }
}