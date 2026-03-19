using System.Text.Json;
using System.Text.Json.Serialization;

namespace DockingApiClient;

public partial class CavityClient
{
    partial void UpdateJsonSerializerSettings(JsonSerializerOptions settings)
    {
        settings.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
        settings.ReferenceHandler = ReferenceHandler.Preserve;
    }
}

public partial class DomainClient
{
    partial void UpdateJsonSerializerSettings(JsonSerializerOptions settings)
    {
        settings.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
        settings.ReferenceHandler = ReferenceHandler.Preserve;
    }
}

public partial class JobClient
{
    partial void UpdateJsonSerializerSettings(JsonSerializerOptions settings)
    {
        settings.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
        settings.ReferenceHandler = ReferenceHandler.Preserve;
    }
}

public partial class LigandClient
{
    partial void UpdateJsonSerializerSettings(JsonSerializerOptions settings)
    {
        settings.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
        settings.ReferenceHandler = ReferenceHandler.Preserve;
    }
}

public partial class ProteinClient
{
    partial void UpdateJsonSerializerSettings(JsonSerializerOptions settings)
    {
        settings.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
        settings.ReferenceHandler = ReferenceHandler.Preserve;
    }
}

public partial class ResultClient
{
    partial void UpdateJsonSerializerSettings(JsonSerializerOptions settings)
    {
        settings.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
        settings.ReferenceHandler = ReferenceHandler.Preserve;
    }
}

public partial class UserClient
{
    partial void UpdateJsonSerializerSettings(JsonSerializerOptions settings)
    {
        settings.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
        settings.ReferenceHandler = ReferenceHandler.Preserve;
    }
}
