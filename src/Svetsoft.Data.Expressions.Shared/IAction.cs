namespace Svetsoft.Data.Expressions
{
    public delegate void ActionPredicate<in T>(T obj);

    public interface IAction<in T>
    {
        string FieldName { get; }
        ExpressionOperator ExpressionOperator { get; }
        string Value { get; }
        void Execute(T obj);
    }
}