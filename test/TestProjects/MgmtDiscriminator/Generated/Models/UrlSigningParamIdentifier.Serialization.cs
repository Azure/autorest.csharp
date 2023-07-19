// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Text.Json;
using Azure.Core;
using Azure.Core.Serialization;

namespace MgmtDiscriminator.Models
{
    public partial class UrlSigningParamIdentifier : IUtf8JsonSerializable, IJsonModelSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModelSerializable)this).Serialize(writer, ModelSerializerOptions.AzureServiceDefault);

        void IJsonModelSerializable.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("paramIndicator"u8);
            writer.WriteStringValue(ParamIndicator.ToString());
            writer.WritePropertyName("paramName"u8);
            writer.WriteStringValue(ParamName);
            writer.WriteEndObject();
        }

        object IModelSerializable.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            using var doc = JsonDocument.Parse(data);
            return DeserializeUrlSigningParamIdentifier(doc.RootElement, options);
        }

        internal static UrlSigningParamIdentifier DeserializeUrlSigningParamIdentifier(JsonElement element, ModelSerializerOptions options = default)
        {
            options ??= ModelSerializerOptions.AzureServiceDefault;
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            ParamIndicator paramIndicator = default;
            string paramName = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("paramIndicator"u8))
                {
                    paramIndicator = new ParamIndicator(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("paramName"u8))
                {
                    paramName = property.Value.GetString();
                    continue;
                }
            }
            return new UrlSigningParamIdentifier(paramIndicator, paramName);
        }

        object IJsonModelSerializable.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            using var doc = JsonDocument.ParseValue(ref reader);
            return DeserializeUrlSigningParamIdentifier(doc.RootElement, options);
        }
    }
}
