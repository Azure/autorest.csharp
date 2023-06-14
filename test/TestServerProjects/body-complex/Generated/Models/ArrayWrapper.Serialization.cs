// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace body_complex.Models
{
    public partial class ArrayWrapper : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsCollectionDefined(Array))
            {
                writer.WritePropertyName("array"u8);
                writer.WriteStartArray();
                foreach (var item in Array)
                {
                    writer.WriteStringValue(item);
                }
                writer.WriteEndArray();
            }
            writer.WriteEndObject();
        }

        internal static ArrayWrapper DeserializeArrayWrapper(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<IList<string>> array = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("array"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<string> array0 = new List<string>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array0.Add(item.GetString());
                    }
                    array = array0;
                    continue;
                }
            }
            return new ArrayWrapper(Optional.ToList(array));
        }
    }
}
