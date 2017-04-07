namespace Svetsoft.Data.Expressions
{
    public class RuleAction<T> : IAction<T>
    {
        public ActionPredicate<T> Action;

        public RuleAction(ActionPredicate<T> action)
        {
            Action = action;
        }

        public RuleAction(string fieldName, ExpressionOperator expressionOperator, string value)
        {
            FieldName = fieldName;
            ExpressionOperator = expressionOperator;
            Value = value;
        }
        
        public string FieldName { get; }
        public ExpressionOperator ExpressionOperator { get; }
        public string Value { get; }

        public void Execute(T obj)
        {
            var value = VariableEvaluation<T>.Evaluate(Value, obj);
            var dynamicAction = Dynamic.GetActionPredicate<T>(FieldName, ExpressionOperator, value);
            dynamicAction.DynamicInvoke(obj);
        }
    }
}