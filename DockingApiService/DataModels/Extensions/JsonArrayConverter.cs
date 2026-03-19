using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Newtonsoft.Json;

namespace DockingApiService.DataModels;

public class JsonArrayConverter<TArrayElement> : ValueConverter<TArrayElement[], string>
{
    public JsonArrayConverter(ConverterMappingHints mappingHints = null)
        : base(o => JsonConvert.SerializeObject(o), o => JsonConvert.DeserializeObject<TArrayElement[]>(o), mappingHints)
    {
    }
}
