// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace body_complex.Models
{
    public partial class DictionaryWrapper : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsCollectionDefined(DefaultProgram))
            {
                if (DefaultProgram != null)
                {
                    writer.WritePropertyName("defaultProgram"u8);
                    writer.WriteStartObject();
                    foreach (var item in DefaultProgram)
                    {
                        writer.WritePropertyName(item.Key);
                        writer.WriteStringValue(item.Value);
                    }
                    writer.WriteEndObject();
                }
                else
                {
                    writer.WriteNull("defaultProgram");
                }
            }
            writer.WriteEndObject();
        }

        internal static DictionaryWrapper DeserializeDictionaryWrapper(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<IDictionary<string, string>> defaultProgram = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("defaultProgram"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        defaultProgram = null;
                        continue;
                    }
                    Dictionary<string, string> dictionary = new Dictionary<string, string>();
                    foreach (var property0 in property.Value.EnumerateObject())
                    {
                        dictionary.Add(property0.Name, property0.Value.GetString());
                    }
                    defaultProgram = dictionary;
                    continue;
                }
            }
            return new DictionaryWrapper(Optional.ToDictionary(defaultProgram));
        }
    }
}
