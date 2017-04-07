namespace Svetsoft.Data.Expressions
{
    public interface IRule<T>
    {
        void AddCondition(ConditionPredicate<T> condition, LogicalOperation operation);
        void AddCondition(string fieldName, ExpressionOperator expressionOperator, string value, LogicalOperation logicalOperation);
        void AddAction(ActionPredicate<T> action);
        void AddAction(string fieldName, ExpressionOperator expressionOperator, string value);
        void Evaluate(T obj);
    }
}