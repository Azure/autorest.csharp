// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure;
using Azure.Core;

namespace Models.Property.Optional.Models
{
    public partial class CollectionsModelProperty : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Azure.Core.Optional.IsCollectionDefined(Property))
            {
                writer.WritePropertyName("property"u8);
                writer.WriteStartArray();
                foreach (var item in Property)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            writer.WriteEndObject();
        }

        internal static CollectionsModelProperty DeserializeCollectionsModelProperty(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<IList<StringProperty>> property = default;
            foreach (var property0 in element.EnumerateObject())
            {
                if (property0.NameEquals("property"u8))
                {
                    if (property0.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<StringProperty> array = new List<StringProperty>();
                    foreach (var item in property0.Value.EnumerateArray())
                    {
                        array.Add(StringProperty.DeserializeStringProperty(item));
                    }
                    property = array;
                    continue;
                }
            }
            return new CollectionsModelProperty(Azure.Core.Optional.ToList(property));
        }

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The response to deserialize the model from. </param>
        internal static CollectionsModelProperty FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeCollectionsModelProperty(document.RootElement);
        }

        /// <summary> Convert into a Utf8JsonRequestContent. </summary>
        internal virtual RequestContent ToRequestContent()
        {
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(this);
            return content;
        }
    }
}
