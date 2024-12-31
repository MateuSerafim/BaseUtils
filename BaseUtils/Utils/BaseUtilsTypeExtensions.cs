using System.Collections;
using BaseUtils.FlowControl.ErrorType;

namespace BaseUtils.Utils;

public static class BaseUtilsTypeExtensions
{
    public static bool IsGenericCollection<T>(this T value) 
    {
        if (value is null || value is string) return false;
        
        var type = value.GetType();

        return type.IsArray || typeof(IEnumerable).IsAssignableFrom(type);
    }

    public static string[] GetStringsByGenericCollection<T>(this T value)
    {
        if (value is IEnumerable listValues && value is not string)
        {
            List<string> stringslist = [];
            
            foreach (var item in listValues)
            {
                var itemText = item?.ToString() ?? string.Empty;
                stringslist.Add(itemText);
            }

            return [.. stringslist];
        }
        var valueText = value?.ToString() ?? string.Empty;
        return string.IsNullOrEmpty(valueText) ? [] : [valueText];
    }

    public static bool IsErrorResponseType<T>(this T value)
    {
        if (typeof(T).IsGenericType)
            return typeof(T).GetGenericArguments()[0] == typeof(ErrorResponse);           
        if (typeof(T) == typeof(ErrorResponse))
            return true;
        return false;
    }
}
