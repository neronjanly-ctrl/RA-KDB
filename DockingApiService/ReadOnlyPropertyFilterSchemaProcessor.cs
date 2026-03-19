using NJsonSchema;
using NJsonSchema.Generation;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace DockingApiService;

public class ReadOnlyPropertyFilterSchemaProcessor : ISchemaProcessor
{
    private readonly JsonNamingPolicy _jsonNamingPolicy = null;

    public ReadOnlyPropertyFilterSchemaProcessor()
    {
    }

    public ReadOnlyPropertyFilterSchemaProcessor(JsonNamingPolicy jsonNamingPolicy)
    {
        _jsonNamingPolicy = jsonNamingPolicy;
    }

    public void Process(SchemaProcessorContext context)
    {
        IDictionary<string, JsonSchemaProperty> schemaProps = context.Schema.Properties;

        // Schema type has a curated property list (excluding JsonIgnore ones)
        if (schemaProps.Count == 0)
            return;

        // Original underlying type has the full property list
        IEnumerable<string> propertiesToRemove = context.ContextualType.Properties
            .Where(p => !p.CanWrite)
            .Select(p => p.Name);

        foreach (string prop in propertiesToRemove)
        {
            string propName = _jsonNamingPolicy == null ? prop : _jsonNamingPolicy.ConvertName(prop);
            schemaProps.Remove(propName);
        }
    }
}
