// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Text.Json;
using Azure.Core;
using Azure.Core.Serialization;

namespace MgmtNonStringPathVariable.Models
{
    public partial class FakeProperties : IUtf8JsonSerializable, IJsonModelSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModelSerializable)this).Serialize(writer, ModelSerializerOptions.AzureServiceDefault);

        void IJsonModelSerializable.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(PlatformUpdateDomainCount))
            {
                writer.WritePropertyName("platformUpdateDomainCount"u8);
                writer.WriteNumberValue(PlatformUpdateDomainCount.Value);
            }
            if (Optional.IsDefined(PlatformFaultDomainCount))
            {
                writer.WritePropertyName("platformFaultDomainCount"u8);
                writer.WriteNumberValue(PlatformFaultDomainCount.Value);
            }
            writer.WriteEndObject();
        }

        object IModelSerializable.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            using var doc = JsonDocument.Parse(data);
            return DeserializeFakeProperties(doc.RootElement, options);
        }

        internal static FakeProperties DeserializeFakeProperties(JsonElement element, ModelSerializerOptions options = default)
        {
            options ??= ModelSerializerOptions.AzureServiceDefault;
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<int> platformUpdateDomainCount = default;
            Optional<int> platformFaultDomainCount = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("platformUpdateDomainCount"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    platformUpdateDomainCount = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("platformFaultDomainCount"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    platformFaultDomainCount = property.Value.GetInt32();
                    continue;
                }
            }
            return new FakeProperties(Optional.ToNullable(platformUpdateDomainCount), Optional.ToNullable(platformFaultDomainCount));
        }

        object IJsonModelSerializable.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            using var doc = JsonDocument.ParseValue(ref reader);
            return DeserializeFakeProperties(doc.RootElement, options);
        }
    }
}
