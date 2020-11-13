// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace CognitiveSearch.Models
{
    public partial class InputFieldMappingEntry : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("name");
            writer.WriteStringValue(Name);
            if (Optional.IsDefined(Source))
            {
                writer.WritePropertyName("source");
                writer.WriteStringValue(Source);
            }
            if (Optional.IsDefined(SourceContext))
            {
                writer.WritePropertyName("sourceContext");
                writer.WriteStringValue(SourceContext);
            }
            if (Optional.IsCollectionDefined(Inputs))
            {
                writer.WritePropertyName("inputs");
                writer.WriteStartArray();
                foreach (var item in Inputs)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            writer.WriteEndObject();
        }

        internal static InputFieldMappingEntry DeserializeInputFieldMappingEntry(JsonElement element)
        {
            string name = default;
            Optional<string> source = default;
            Optional<string> sourceContext = default;
            Optional<IList<InputFieldMappingEntry>> inputs = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("name"))
                {
                    name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("source"))
                {
                    source = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("sourceContext"))
                {
                    sourceContext = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("inputs"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    List<InputFieldMappingEntry> array = new List<InputFieldMappingEntry>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(DeserializeInputFieldMappingEntry(item));
                    }
                    inputs = array;
                    continue;
                }
            }
            return new InputFieldMappingEntry(name, source.Value, sourceContext.Value, Optional.ToList(inputs));
        }
    }
}
