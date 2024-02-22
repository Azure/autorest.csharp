// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace ExtensionClientName.Models
{
    public partial class RenamedSchema : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (!(RenamedProperty is ChangeTrackingDictionary<string, string> collection && collection.IsUndefined))
            {
                writer.WritePropertyName("originalProperty"u8);
                writer.WriteStartObject();
                foreach (var item in RenamedProperty)
                {
                    writer.WritePropertyName(item.Key);
                    writer.WriteStringValue(item.Value);
                }
                writer.WriteEndObject();
            }
            if (Optional.IsDefined(RenamedPropertyString))
            {
                writer.WritePropertyName("originalPropertyString"u8);
                writer.WriteStringValue(RenamedPropertyString);
            }
            writer.WriteEndObject();
        }

        internal static RenamedSchema DeserializeRenamedSchema(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<IDictionary<string, string>> originalProperty = default;
            Optional<string> originalPropertyString = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("originalProperty"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    Dictionary<string, string> dictionary = new Dictionary<string, string>();
                    foreach (var property0 in property.Value.EnumerateObject())
                    {
                        dictionary.Add(property0.Name, property0.Value.GetString());
                    }
                    originalProperty = dictionary;
                    continue;
                }
                if (property.NameEquals("originalPropertyString"u8))
                {
                    originalPropertyString = property.Value.GetString();
                    continue;
                }
            }
            return new RenamedSchema(Optional.ToDictionary(originalProperty), originalPropertyString.Value);
        }
    }
}
