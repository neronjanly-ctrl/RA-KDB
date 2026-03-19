using CommonTools;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace DockingApiService.DataModels;

public static class ConverterForTypeExtensions
{
    public static ModelBuilder UseValueConverterForType<TDataType>(this ModelBuilder modelBuilder, ValueConverter converter)
    {
        return modelBuilder.UseValueConverterForType(typeof(TDataType), converter);
    }

    public static ModelBuilder UseValueConverterForType(this ModelBuilder modelBuilder, Type type, ValueConverter converter)
    {
        foreach (IMutableEntityType entityType in modelBuilder.Model.GetEntityTypes())
        {
            IEnumerable<PropertyInfo> properties = entityType.ClrType.GetProperties().Where(p => p.PropertyType == type);
            foreach (PropertyInfo property in properties)
            {
                modelBuilder
                    .Entity(entityType.Name)
                    .Property(property.Name)
                    .HasConversion(converter);
                Console.WriteLine($"Added conversion {converter.GetFriendlyTypeName()} for type {entityType.Name}.{property.Name}");
            }
        }

        return modelBuilder;
    }
}
