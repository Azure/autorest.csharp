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
            if (Optional.IsDefined(Productresource))
            {
                writer.WritePropertyName("productresource"u8);
                writer.WriteObjectValue(Productresource);
            }
            if (Optional.IsCollectionDefined(Arrayofresources))
            {
                writer.WritePropertyName("arrayofresources"u8);
                writer.WriteStartArray();
                foreach (var item in Arrayofresources)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsCollectionDefined(Dictionaryofresources))
            {
                writer.WritePropertyName("dictionaryofresources"u8);
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
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<FlattenedProduct> productresource = default;
            Optional<IList<FlattenedProduct>> arrayofresources = default;
            Optional<IDictionary<string, FlattenedProduct>> dictionaryofresources = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("productresource"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    productresource = FlattenedProduct.DeserializeFlattenedProduct(property.Value);
                    continue;
                }
                if (property.NameEquals("arrayofresources"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<FlattenedProduct> array = new List<FlattenedProduct>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(FlattenedProduct.DeserializeFlattenedProduct(item));
                    }
                    arrayofresources = array;
                    continue;
                }
                if (property.NameEquals("dictionaryofresources"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    Dictionary<string, FlattenedProduct> dictionary = new Dictionary<string, FlattenedProduct>();
                    foreach (var property0 in property.Value.EnumerateObject())
                    {
                        dictionary.Add(property0.Name, FlattenedProduct.DeserializeFlattenedProduct(property0.Value));
                    }
                    dictionaryofresources = dictionary;
                    continue;
                }
            }
            return new ResourceCollection(productresource.Value, Optional.ToList(arrayofresources), Optional.ToDictionary(dictionaryofresources));
        }
    }
}
