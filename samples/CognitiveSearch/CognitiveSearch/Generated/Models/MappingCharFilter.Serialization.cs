// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core;

namespace CognitiveSearch.Models
{
    public partial class MappingCharFilter : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("mappings");
            writer.WriteStartArray();
            foreach (var item in Mappings)
            {
                writer.WriteStringValue(item);
            }
            writer.WriteEndArray();
            writer.WritePropertyName("@odata.type");
            writer.WriteStringValue(OdataType);
            writer.WritePropertyName("name");
            writer.WriteStringValue(Name);
            writer.WriteEndObject();
        }
        internal static MappingCharFilter DeserializeMappingCharFilter(JsonElement element)
        {
            MappingCharFilter result = new MappingCharFilter();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("mappings"))
                {
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        result.Mappings.Add(item.GetString());
                    }
                    continue;
                }
                if (property.NameEquals("@odata.type"))
                {
                    result.OdataType = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("name"))
                {
                    result.Name = property.Value.GetString();
                    continue;
                }
            }
            return result;
        }
    }
}
