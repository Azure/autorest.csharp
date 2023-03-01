// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace OmitOperationGroups.Models
{
    public partial class Model5 : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(Id))
            {
                writer.WritePropertyName("id"u8);
                writer.WriteStringValue(Id);
            }
            if (Optional.IsCollectionDefined(Modelqs))
            {
                writer.WritePropertyName("modelqs"u8);
                writer.WriteStartArray();
                foreach (var item in Modelqs)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            writer.WriteEndObject();
        }

        internal static Model5 DeserializeModel5(JsonElement element)
        {
            Optional<string> id = default;
            Optional<string> k = default;
            Optional<IList<ModelQ>> modelqs = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("id"u8))
                {
                    id = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("k"u8))
                {
                    k = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("modelqs"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<ModelQ> array = new List<ModelQ>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(ModelQ.DeserializeModelQ(item));
                    }
                    modelqs = array;
                    continue;
                }
            }
            return new Model5(id.Value, k.Value, Optional.ToList(modelqs));
        }
    }
}
