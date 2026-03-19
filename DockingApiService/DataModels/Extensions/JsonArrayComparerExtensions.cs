using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;
using System.Linq;

namespace DockingApiService.DataModels;

public static class JsonArrayComparerExtensions
{
    public static void HasJsonArrayConversion<TArrayElement>(this PropertyBuilder<TArrayElement[]> propertyBuilder)
    {
        ValueComparer<TArrayElement[]> comparer = new(
            (a, b) => a == b || a.Length == b.Length && Enumerable.Range(0, a.Length).All(o => a[o].Equals(b[o])),
            o => o.Select(p => p.GetHashCode()).Aggregate((a, b) => a ^ b),
            o => o.ToArray());

        propertyBuilder
            .HasConversion(
                o => JsonConvert.SerializeObject(o),
                o => JsonConvert.DeserializeObject<TArrayElement[]>(o)
            )
            .Metadata
            .SetValueComparer(comparer);
    }
}
