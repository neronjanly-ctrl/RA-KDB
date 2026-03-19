using CommonTools;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace DockingApiService.DataModels;

public static class JsonArrayConverterForArrayTypeExtensions
{
    public static ModelBuilder UseJsonArrayConverterForArrayType<TArrayElement>(this ModelBuilder modelBuilder)
    {
        ValueComparer<TArrayElement[]> comparer = new(
            (a, b) => a == b || a.Length == b.Length && Enumerable.Range(0, a.Length).All(o => a[o] != null && a[o].Equals(b[o]) || a[o] == null && b[o] == null),
            o => o.Select(p => p == null ? 0 : p.GetHashCode()).Aggregate((a, b) => a ^ b),
            o => o.ToArray());

        JsonArrayConverter<TArrayElement> converter = new();
        foreach (IMutableEntityType entityType in modelBuilder.Model.GetEntityTypes())
        {
            IEnumerable<PropertyInfo> properties = entityType.ClrType.GetProperties().Where(p => p.PropertyType == typeof(TArrayElement).MakeArrayType());
            foreach (PropertyInfo property in properties)
            {
                modelBuilder
                    .Entity(entityType.Name)
                    .Property(property.Name)
                    .HasConversion(converter)
                    .Metadata
                    .SetValueComparer(comparer);
                Console.WriteLine($"Added conversion {converter.GetFriendlyTypeName()} for type {entityType.Name}.{property.Name}");
            }
        }

        return modelBuilder;
    }
}
