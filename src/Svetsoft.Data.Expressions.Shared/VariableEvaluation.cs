namespace Svetsoft.Data.Expressions
{
    public static class VariableEvaluation<T>
    {
        private const string ObjectPropertyStartDelimiter = "obj.";
        private const string VariableStartDelimiter = "[";
        private const string VariableEndDelimiter = "]";

        public static string Evaluate(string value, T obj)
        {
            if (IsVariable(value))
            {
                ; // Variables
            }
            else if (IsObjectProperty(value))
            {
                value = GetPropertyValue(obj, value);
            }
            else if (IsExpression(value))
            {
                ; // Expressions
            }
            else
            {
                ; // Constants
            }
            return value;
        }

        /// <summary>
        ///     Returns whether a given <paramref name="value" /> is declared as a variable.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>Whether the <paramref name="value" /> is declared as a variable.</returns>
        private static bool IsVariable(string value)
        {
            // TODO: return value.StartsWith(VariableStartDelimiter) && value.EndsWith(VariableEndDelimiter);
            return false;
        }

        /// <summary>
        ///     Returns whether a given <paramref name="value" /> is declared as an object.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>Whether the <paramref name="value" /> is declared as an object.</returns>
        private static bool IsObjectProperty(string value)
        {
            return value.StartsWith(ObjectPropertyStartDelimiter);
        }

        /// <summary>
        ///     Returns whether a given <paramref name="value" /> is declared as an expression.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>Whether the <paramref name="value" /> is declared as an expression.</returns>
        private static bool IsExpression(string value)
        {
            // TODO: 
            return false;
        }

        private static string GetPropertyValue(T obj, string value)
        {
            var fieldName = value.Replace(ObjectPropertyStartDelimiter, string.Empty);
            var itemType = typeof(T);
            var propertyInfo = itemType.GetProperty(fieldName);
            return propertyInfo.GetValue(obj, null).ToString();
        }
    }
}