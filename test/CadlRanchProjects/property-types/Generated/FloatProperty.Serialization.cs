// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure;
using Azure.Core;

namespace Types
{
    public partial class FloatProperty : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("property");
            writer.WriteNumberValue(Property);
            writer.WriteEndObject();
        }

        internal static FloatProperty DeserializeFloatProperty(JsonElement element)
        {
            float property = default;
            foreach (var property0 in element.EnumerateObject())
            {
                if (property0.NameEquals("property"))
                {
                    property = property0.Value.GetSingle();
                    continue;
                }
            }
            return new FloatProperty(property);
        }

        internal RequestContent ToRequestContent()
        {
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(this);
            return content;
        }

        internal static FloatProperty FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeFloatProperty(document.RootElement);
        }
    }
}
