// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace model_flattening.Models
{
    public partial class ResourceCollection : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Productresource != null)
            {
                writer.WritePropertyName("productresource");
                writer.WriteObjectValue(Productresource);
            }
            if (Arrayofresources != null)
            {
                writer.WritePropertyName("arrayofresources");
                writer.WriteStartArray();
                foreach (var item in Arrayofresources)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            if (Dictionaryofresources != null)
            {
                writer.WritePropertyName("dictionaryofresources");
                writer.WriteStartObject();
                foreach (var item in Dictionaryofresources)
                {
                    writer.WritePropertyName(item.Key);
                    writer.WriteObjectValue(item.Value);
                }
                writer.WriteEndObject();
            }
            writer.WriteEndObject();
        }
        internal static ResourceCollection DeserializeResourceCollection(JsonElement element)
        {
            ResourceCollection result = new ResourceCollection();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("productresource"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.Productresource = FlattenedProduct.DeserializeFlattenedProduct(property.Value);
                    continue;
                }
                if (property.NameEquals("arrayofresources"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.Arrayofresources = new List<FlattenedProduct>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        result.Arrayofresources.Add(FlattenedProduct.DeserializeFlattenedProduct(item));
                    }
                    continue;
                }
                if (property.NameEquals("dictionaryofresources"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.Dictionaryofresources = new System.Collections.Generic.IDictionary<string, FlattenedProduct>();
                    foreach (var property0 in property.Value.EnumerateObject())
                    {
                        result.Dictionaryofresources.Add(property0.Name, FlattenedProduct.DeserializeFlattenedProduct(property0.Value));
                    }
                    continue;
                }
            }
            return result;
        }
    }
}
