using Microsoft.Extensions.Configuration;
using System.Linq;

namespace DockingApiService.DataModels;

public static class IConfigurationExtensions
{
    public static TElement[] GetArray<TElement>(this IConfiguration config, string sectionName)
    {
        return config.GetSection(sectionName).GetChildren().Select(o => o.Get<TElement>()).ToArray();
    }
}
