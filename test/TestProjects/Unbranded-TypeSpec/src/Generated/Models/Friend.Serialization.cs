// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.ServiceModel.Rest;
using System.ServiceModel.Rest.Core;
using System.Text.Json;
using Azure.Core;

namespace UnbrandedTypeSpec.Models
{
    public partial class Friend : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("name"u8);
            writer.WriteStringValue(Name);
            writer.WriteEndObject();
        }

        internal static Friend DeserializeFriend(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string name = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("name"u8))
                {
                    name = property.Value.GetString();
                    continue;
                }
            }
            return new Friend(name);
        }

        /// <summary> Deserializes the model from a raw result. </summary>
        /// <param name="result"> The result to deserialize the model from. </param>
        internal static Friend FromResult(Result result)
        {
            using var document = JsonDocument.Parse(result.Content);
            return DeserializeFriend(document.RootElement);
        }

        /// <summary> Convert into a Utf8JsonRequestBody. </summary>
        internal virtual RequestBody ToRequestBody()
        {
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(this);
            return content;
        }
    }
}
