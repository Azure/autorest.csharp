// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure;
using Azure.Core;

namespace ModelsTypeSpec.Models
{
    public partial class CollectionItem : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("requiredModelRecord"u8);
            writer.WriteStartObject();
            foreach (var item in RequiredModelRecord)
            {
                writer.WritePropertyName(item.Key);
                writer.WriteObjectValue(item.Value);
            }
            writer.WriteEndObject();
            writer.WriteEndObject();
        }

        internal static CollectionItem DeserializeCollectionItem(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            IDictionary<string, RecordItem> requiredModelRecord = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("requiredModelRecord"u8))
                {
                    Dictionary<string, RecordItem> dictionary = new Dictionary<string, RecordItem>();
                    foreach (var property0 in property.Value.EnumerateObject())
                    {
                        dictionary.Add(property0.Name, RecordItem.DeserializeRecordItem(property0.Value));
                    }
                    requiredModelRecord = dictionary;
                    continue;
                }
            }
            return new CollectionItem(requiredModelRecord);
        }

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The response to deserialize the model from. </param>
        internal static CollectionItem FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeCollectionItem(document.RootElement);
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
