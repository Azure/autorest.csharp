// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Text.Json;
using Azure.Core;
using Azure.Core.Serialization;

namespace validation.Models
{
    public partial class ConstantProduct : IUtf8JsonSerializable, IJsonModelSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModelSerializable)this).Serialize(writer, ModelSerializerOptions.AzureServiceDefault);

        void IJsonModelSerializable.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("constProperty"u8);
            writer.WriteStringValue(ConstProperty.ToString());
            writer.WritePropertyName("constProperty2"u8);
            writer.WriteStringValue(ConstProperty2.ToString());
            writer.WriteEndObject();
        }

        object IModelSerializable.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            using var doc = JsonDocument.Parse(data);
            return DeserializeConstantProduct(doc.RootElement, options);
        }

        internal static ConstantProduct DeserializeConstantProduct(JsonElement element, ModelSerializerOptions options = default)
        {
            options ??= ModelSerializerOptions.AzureServiceDefault;
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            ConstantProductConstProperty constProperty = default;
            ConstantProductConstProperty2 constProperty2 = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("constProperty"u8))
                {
                    constProperty = new ConstantProductConstProperty(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("constProperty2"u8))
                {
                    constProperty2 = new ConstantProductConstProperty2(property.Value.GetString());
                    continue;
                }
            }
            return new ConstantProduct(constProperty, constProperty2);
        }

        object IJsonModelSerializable.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            using var doc = JsonDocument.ParseValue(ref reader);
            return DeserializeConstantProduct(doc.RootElement, options);
        }
    }
}
