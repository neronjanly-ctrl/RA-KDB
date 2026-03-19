using System;
using System.Collections.Generic;
using System.Linq;

namespace CommonTools;

public static class TypeExtensions
{
    private static readonly Dictionary<Type, string> _defaultDictionary = new()
    {
        {typeof(int), "int"},
        {typeof(uint), "uint"},
        {typeof(long), "long"},
        {typeof(ulong), "ulong"},
        {typeof(short), "short"},
        {typeof(ushort), "ushort"},
        {typeof(byte), "byte"},
        {typeof(sbyte), "sbyte"},
        {typeof(bool), "bool"},
        {typeof(float), "float"},
        {typeof(double), "double"},
        {typeof(decimal), "decimal"},
        {typeof(char), "char"},
        {typeof(string), "string"},
        {typeof(object), "object"},
        {typeof(void), "void"},
    };

    public static string GetFriendlyName(this Type type)
    {
        if (_defaultDictionary.ContainsKey(type))
            return _defaultDictionary[type];
        else if (type.IsArray)
            return GetFriendlyName(type.GetElementType()) + "[]";
        else if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
            return type.GetGenericArguments()[0].GetFriendlyName() + "?";
        else if (type.IsGenericType)
            return $"{type.Name.Split('`')[0]}<{string.Join(", ", type.GetGenericArguments().Select(x => GetFriendlyName(x)))}>";
        else
            return type.Name;
    }

    public static string GetFriendlyTypeName(this object obj)
    {
        return obj.GetType().GetFriendlyName();
    }
}
