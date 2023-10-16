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
    public partial class VirtualMachineExtensionHandlerInstanceView : IUtf8JsonSerializable, IModelJsonSerializable<VirtualMachineExtensionHandlerInstanceView>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<VirtualMachineExtensionHandlerInstanceView>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<VirtualMachineExtensionHandlerInstanceView>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(VirtualMachineExtensionHandlerInstanceViewType))
            {
                writer.WritePropertyName("type"u8);
                writer.WriteStringValue(VirtualMachineExtensionHandlerInstanceViewType);
            }
            if (Optional.IsDefined(TypeHandlerVersion))
            {
                writer.WritePropertyName("typeHandlerVersion"u8);
                writer.WriteStringValue(TypeHandlerVersion);
            }
            if (Optional.IsDefined(Status))
            {
                writer.WritePropertyName("status"u8);
                writer.WriteObjectValue(Status);
            }
            writer.WriteEndObject();
        }

        VirtualMachineExtensionHandlerInstanceView IModelJsonSerializable<VirtualMachineExtensionHandlerInstanceView>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument doc = JsonDocument.ParseValue(ref reader);
            return DeserializeVirtualMachineExtensionHandlerInstanceView(doc.RootElement, options);
        }

        BinaryData IModelSerializable<VirtualMachineExtensionHandlerInstanceView>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);
            return ModelSerializer.SerializeCore(this, options);
        }

        VirtualMachineExtensionHandlerInstanceView IModelSerializable<VirtualMachineExtensionHandlerInstanceView>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeVirtualMachineExtensionHandlerInstanceView(document.RootElement, options);
        }

        internal static VirtualMachineExtensionHandlerInstanceView DeserializeVirtualMachineExtensionHandlerInstanceView(JsonElement element, ModelSerializerOptions options = null)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<string> type = default;
            Optional<string> typeHandlerVersion = default;
            Optional<InstanceViewStatus> status = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("type"u8))
                {
                    type = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("typeHandlerVersion"u8))
                {
                    typeHandlerVersion = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("status"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    status = InstanceViewStatus.DeserializeInstanceViewStatus(property.Value);
                    continue;
                }
            }
            return new VirtualMachineExtensionHandlerInstanceView(type.Value, typeHandlerVersion.Value, status.Value);
        }
    }
}
