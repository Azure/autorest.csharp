// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure;
using Azure.Core;

namespace Models.Inheritance
{
    public partial class Salmon : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("kind");
            writer.WriteStringValue(Kind);
            if (Optional.IsCollectionDefined(Friends))
            {
                writer.WritePropertyName("friends");
                writer.WriteStartArray();
                foreach (var item in Friends)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsCollectionDefined(Hate))
            {
                writer.WritePropertyName("hate");
                writer.WriteStartObject();
                foreach (var item in Hate)
                {
                    writer.WritePropertyName(item.Key);
                    writer.WriteObjectValue(item.Value);
                }
                writer.WriteEndObject();
            }
            if (Optional.IsDefined(Partner))
            {
                writer.WritePropertyName("partner");
                writer.WriteObjectValue(Partner);
            }
            writer.WriteEndObject();
        }

        internal static Salmon DeserializeSalmon(JsonElement element)
        {
            string kind = default;
            Optional<IList<Fish>> friends = default;
            Optional<IDictionary<string, Fish>> hate = default;
            Optional<Fish> partner = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("kind"))
                {
                    kind = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("friends"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    List<Fish> array = new List<Fish>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(DeserializeFish(item));
                    }
                    friends = array;
                    continue;
                }
                if (property.NameEquals("hate"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    Dictionary<string, Fish> dictionary = new Dictionary<string, Fish>();
                    foreach (var property0 in property.Value.EnumerateObject())
                    {
                        dictionary.Add(property0.Name, DeserializeFish(property0.Value));
                    }
                    hate = dictionary;
                    continue;
                }
                if (property.NameEquals("partner"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    partner = DeserializeFish(property.Value);
                    continue;
                }
            }
            return new Salmon(kind, Optional.ToList(friends), Optional.ToDictionary(hate), partner);
        }

        internal RequestContent ToRequestContent()
        {
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(this);
            return content;
        }

        internal static Salmon FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeSalmon(document.RootElement);
        }
    }
}
