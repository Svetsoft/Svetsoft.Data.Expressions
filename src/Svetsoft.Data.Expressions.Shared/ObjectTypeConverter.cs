using System;

namespace Svetsoft.Data.Expressions
{
    public class ObjectTypeConverter
    {
        /// <summary>
        ///     Converts a given <paramref name="value" /> to its CLR object equivalent.
        /// </summary>
        /// <param name="value">The object to convert.</param>
        /// <param name="type">The target type.</param>
        /// <returns>The converted object.</returns>
        public static object ChangeType(object value, Type type)
        {
            if (value == null && type.IsGenericType)
            {
                return Activator.CreateInstance(type);
            }

            if (value == null)
            {
                return null;
            }

            if (type == value.GetType())
            {
                return value;
            }

            if (type.IsEnum)
            {
                if (value is string)
                {
                    return Enum.Parse(type, value as string);
                }

                return Enum.ToObject(type, value);
            }

            if (!type.IsInterface && type.IsGenericType)
            {
                var innerType = type.GetGenericArguments()[0];
                var innerValue = ChangeType(value, innerType);
                return Activator.CreateInstance(type, innerValue);
            }

            if (value is string && type == typeof(Guid))
            {
                return new Guid(value as string);
            }

            if (value is string && type == typeof(Version))
            {
                return new Version(value as string);
            }

            if (!(value is IConvertible))
            {
                return value;
            }

            if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
            {
                type = Nullable.GetUnderlyingType(type);
            }

            return Convert.ChangeType(value, type);
        }
    }
}