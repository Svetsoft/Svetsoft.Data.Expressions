namespace Svetsoft.Data.Expressions
{
    public delegate bool ConditionPredicate<in T>(T obj);

    public interface ICondition<in T>
    {
        LogicalOperation Operation { get; }
        bool Validate(T obj);
    }
}