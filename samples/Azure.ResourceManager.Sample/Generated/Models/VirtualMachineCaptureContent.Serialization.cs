// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Text.Json;
using Azure.Core;
using Azure.Core.Serialization;

namespace Azure.ResourceManager.Sample.Models
{
    public partial class VirtualMachineCaptureContent : IUtf8JsonSerializable, IJsonModelSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModelSerializable)this).Serialize(writer, ModelSerializerOptions.AzureServiceDefault);

        void IJsonModelSerializable.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("vhdPrefix"u8);
            writer.WriteStringValue(VhdPrefix);
            writer.WritePropertyName("destinationContainerName"u8);
            writer.WriteStringValue(DestinationContainerName);
            writer.WritePropertyName("overwriteVhds"u8);
            writer.WriteBooleanValue(OverwriteVhds);
            writer.WriteEndObject();
        }

        object IModelSerializable.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            using var doc = JsonDocument.Parse(data);
            return DeserializeVirtualMachineCaptureContent(doc.RootElement, options);
        }

        internal static VirtualMachineCaptureContent DeserializeVirtualMachineCaptureContent(JsonElement element, ModelSerializerOptions options = default)
        {
            options ??= ModelSerializerOptions.AzureServiceDefault;
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string vhdPrefix = default;
            string destinationContainerName = default;
            bool overwriteVhds = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("vhdPrefix"u8))
                {
                    vhdPrefix = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("destinationContainerName"u8))
                {
                    destinationContainerName = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("overwriteVhds"u8))
                {
                    overwriteVhds = property.Value.GetBoolean();
                    continue;
                }
            }
            return new VirtualMachineCaptureContent(vhdPrefix, destinationContainerName, overwriteVhds);
        }

        object IJsonModelSerializable.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            using var doc = JsonDocument.ParseValue(ref reader);
            return DeserializeVirtualMachineCaptureContent(doc.RootElement, options);
        }
    }
}
