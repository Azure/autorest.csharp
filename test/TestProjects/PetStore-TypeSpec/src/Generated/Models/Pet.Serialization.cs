// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure;
using Azure.Core;

namespace PetStore.Models
{
    public partial class Pet : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("name"u8);
            writer.WriteStringValue(Name);
            if (Optional.IsDefined(Tag))
            {
                writer.WritePropertyName("tag"u8);
                writer.WriteStringValue(Tag);
            }
            writer.WritePropertyName("age"u8);
            writer.WriteNumberValue(Age);
            writer.WriteEndObject();
        }

        internal static Pet DeserializePet(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string name = default;
            Optional<string> tag = default;
            int age = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("name"u8))
                {
                    name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("tag"u8))
                {
                    tag = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("age"u8))
                {
                    age = property.Value.GetInt32();
                    continue;
                }
            }
            return new Pet(name, tag.Value, age);
        }

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The response to deserialize the model from. </param>
        internal static Pet FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializePet(document.RootElement);
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
