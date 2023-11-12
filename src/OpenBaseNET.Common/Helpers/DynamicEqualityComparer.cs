using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace OpenBaseNET.Common.Helpers;

public sealed class DynamicEqualityComparer<T> : IEqualityComparer<T>
{
    public bool Equals(T? x, T? y)
    {
        if (x is null || y is null)
            return false;

        var type = typeof(T);
        var properties = type.GetProperties(
            BindingFlags.Public | BindingFlags.Instance);

        foreach (var property in properties)
        {
            var xValue = property.GetValue(x);
            var yValue = property.GetValue(y);

            if (xValue is null || yValue is null)
                return false;

            if (!xValue.Equals(yValue))
                return false;
        }

        return true;
    }

    public int GetHashCode([DisallowNull] T obj)
    {
        unchecked
        {
            var type = typeof(T);
            var properties =
                type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            return properties
                .Select(property => property.GetValue(obj))
                .Where(value => value is not null)
                .Aggregate(17, (current, value)
                    =>
                {
                    if (value is not null) return current * 31 + value.GetHashCode();
                    return current;
                });
        }
    }
}