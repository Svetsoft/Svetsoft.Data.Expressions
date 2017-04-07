using System;
using System.Linq.Expressions;

namespace Svetsoft.Data.Expressions
{
    public static class Dynamic
    {
        public static ConditionPredicate<T> GetConditionPredicate<T>(string fieldName, ExpressionOperator expressionOperator, string value)
        {
            var itemType = typeof(T);
            var predParam = Expression.Parameter(itemType, "Target");
            var propertyInfo = itemType.GetProperty(fieldName);
            Expression left = Expression.Property(predParam, propertyInfo);
            Expression right = Expression.Constant(ObjectTypeConverter.ChangeType(value, propertyInfo.PropertyType), propertyInfo.PropertyType);
            var result = GetExpression(expressionOperator, left, right);
            var function = (Func<T, bool>) Expression.Lambda(result, predParam).Compile();
            return new ConditionPredicate<T>(function);
        }

        public static Delegate GetActionPredicate<T>(string fieldName, ExpressionOperator expressionOperator, string value)
        {
            var itemType = typeof(T);
            var parameterExpression = Expression.Parameter(itemType, "Target");
            var propertyInfo = itemType.GetProperty(fieldName);
            Expression left = Expression.Property(parameterExpression, propertyInfo);
            Expression right = Expression.Constant(ObjectTypeConverter.ChangeType(value, propertyInfo.PropertyType), propertyInfo.PropertyType);
            var result = GetExpression(expressionOperator, left, right);
            var function = Expression.Lambda(result, parameterExpression).Compile();
            return function;
        }

        public static Expression GetExpression(ExpressionOperator expressionOperator, Expression left, Expression right)
        {
            Expression result;
            switch (expressionOperator)
            {
                case ExpressionOperator.Equal:
                    result = Expression.Equal(left, right);
                    break;
                case ExpressionOperator.NotEqual:
                    result = Expression.NotEqual(left, right);
                    break;
                case ExpressionOperator.Throw:
                    result = Expression.Throw(Expression.Constant(new Exception()));
                    break;
                case ExpressionOperator.Assign:
                    result = Expression.Assign(left, right);
                    break;
                case ExpressionOperator.GreaterThanOrEqual:
                    result = Expression.GreaterThanOrEqual(left, right);
                    break;
                case ExpressionOperator.LessThanOrEqual:
                    result = Expression.LessThanOrEqual(left, right);
                    break;
                case ExpressionOperator.GreaterThan:
                    result = Expression.GreaterThan(left, right);
                    break;
                case ExpressionOperator.LessThan:
                    result = Expression.LessThan(left, right);
                    break;
                case ExpressionOperator.Add:
                    result = Expression.Add(left, right);
                    break;
                case ExpressionOperator.Subtract:
                    result = Expression.Subtract(left, right);
                    break;
                case ExpressionOperator.Multiply:
                    result = Expression.Multiply(left, right);
                    break;
                case ExpressionOperator.Divide:
                    result = Expression.Divide(left, right);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(expressionOperator), $"Unknown expression operator {expressionOperator}.");
            }

            return result;
        }
    }
}