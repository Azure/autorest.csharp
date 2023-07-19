// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using Azure.Core.Serialization;

namespace dpg_customization_LowLevel.Models
{
    public partial class Input : IUtf8JsonSerializable, IJsonModelSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModelSerializable)this).Serialize(writer, ModelSerializerOptions.AzureServiceDefault);

        void IJsonModelSerializable.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("hello");
            writer.WriteStringValue(Hello);
            writer.WriteEndObject();
        }

        internal static Input DeserializeInput(JsonElement element, ModelSerializerOptions options = default)
        {
            options ??= ModelSerializerOptions.AzureServiceDefault;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string hello = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("hello"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    hello = property.Value.GetString();
                    continue;
                }
            }
            return new Input(hello);
        }

        internal static RequestContent ToRequestContent(Input input)
        {
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(input);
            return content;
        }

        object IJsonModelSerializable.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            throw new NotImplementedException();
        }

        object IModelSerializable.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            using var doc = JsonDocument.Parse(data);
            return DeserializeInput(doc.RootElement, options);
        }
    }
}
