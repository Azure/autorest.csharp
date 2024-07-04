// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure;
using Azure.Core;

namespace Inheritance.Models
{
    public partial class SomeProperties : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(SomeProperty))
            {
                writer.WritePropertyName("SomeProperty"u8);
                SerializationMethodHook(writer);
            }
            if (Optional.IsDefined(SomeOtherProperty))
            {
                writer.WritePropertyName("SomeOtherProperty"u8);
                writer.WriteStringValue(SomeOtherProperty);
            }
            writer.WriteEndObject();
        }

        internal static SomeProperties DeserializeSomeProperties(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string someProperty = default;
            string someOtherProperty = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("SomeProperty"u8))
                {
                    someProperty = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("SomeOtherProperty"u8))
                {
                    someOtherProperty = property.Value.GetString();
                    continue;
                }
            }
            return new SomeProperties(someProperty, someOtherProperty);
        }

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The response to deserialize the model from. </param>
        internal static SomeProperties FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeSomeProperties(document.RootElement);
        }

        /// <summary> Convert into a <see cref="RequestContent"/>. </summary>
        internal virtual RequestContent ToRequestContent()
        {
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(this);
            return content;
        }
    }
}
