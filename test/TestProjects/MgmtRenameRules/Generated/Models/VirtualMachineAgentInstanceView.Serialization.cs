// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Text.Json;
using Azure;
using Azure.Core;
using Azure.Core.Serialization;

namespace MgmtRenameRules.Models
{
    public partial class VirtualMachineAgentInstanceView : IUtf8JsonSerializable, IModelJsonSerializable<VirtualMachineAgentInstanceView>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<VirtualMachineAgentInstanceView>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<VirtualMachineAgentInstanceView>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            writer.WriteStartObject();
            if (Optional.IsDefined(VmAgentVersion))
            {
                writer.WritePropertyName("vmAgentVersion"u8);
                writer.WriteStringValue(VmAgentVersion);
            }
            if (Optional.IsCollectionDefined(ExtensionHandlers))
            {
                writer.WritePropertyName("extensionHandlers"u8);
                writer.WriteStartArray();
                foreach (var item in ExtensionHandlers)
                {
                    ((IModelJsonSerializable<VirtualMachineExtensionHandlerInstanceView>)item).Serialize(writer, options);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsCollectionDefined(Statuses))
            {
                writer.WritePropertyName("statuses"u8);
                writer.WriteStartArray();
                foreach (var item in Statuses)
                {
                    ((IModelJsonSerializable<InstanceViewStatus>)item).Serialize(writer, options);
                }
                writer.WriteEndArray();
            }
            if (_rawData is not null && options.Format == ModelSerializerFormat.Json)
            {
                foreach (var property in _rawData)
                {
                    writer.WritePropertyName(property.Key);
#if NET6_0_OR_GREATER
				writer.WriteRawValue(property.Value);
#else
                    JsonSerializer.Serialize(writer, JsonDocument.Parse(property.Value.ToString()).RootElement);
#endif
                }
            }
            writer.WriteEndObject();
        }

        internal static VirtualMachineAgentInstanceView DeserializeVirtualMachineAgentInstanceView(JsonElement element, ModelSerializerOptions options = default)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<string> vmAgentVersion = default;
            Optional<IReadOnlyList<VirtualMachineExtensionHandlerInstanceView>> extensionHandlers = default;
            Optional<IReadOnlyList<InstanceViewStatus>> statuses = default;
            Dictionary<string, BinaryData> rawData = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("vmAgentVersion"u8))
                {
                    vmAgentVersion = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("extensionHandlers"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<VirtualMachineExtensionHandlerInstanceView> array = new List<VirtualMachineExtensionHandlerInstanceView>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(VirtualMachineExtensionHandlerInstanceView.DeserializeVirtualMachineExtensionHandlerInstanceView(item));
                    }
                    extensionHandlers = array;
                    continue;
                }
                if (property.NameEquals("statuses"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<InstanceViewStatus> array = new List<InstanceViewStatus>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(InstanceViewStatus.DeserializeInstanceViewStatus(item));
                    }
                    statuses = array;
                    continue;
                }
                if (options.Format == ModelSerializerFormat.Json)
                {
                    rawData.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                    continue;
                }
            }
            return new VirtualMachineAgentInstanceView(vmAgentVersion.Value, Optional.ToList(extensionHandlers), Optional.ToList(statuses), rawData);
        }

        VirtualMachineAgentInstanceView IModelJsonSerializable<VirtualMachineAgentInstanceView>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using var doc = JsonDocument.ParseValue(ref reader);
            return DeserializeVirtualMachineAgentInstanceView(doc.RootElement, options);
        }

        BinaryData IModelSerializable<VirtualMachineAgentInstanceView>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            return ModelSerializer.SerializeCore(this, options);
        }

        VirtualMachineAgentInstanceView IModelSerializable<VirtualMachineAgentInstanceView>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using var doc = JsonDocument.Parse(data);
            return DeserializeVirtualMachineAgentInstanceView(doc.RootElement, options);
        }

        public static implicit operator RequestContent(VirtualMachineAgentInstanceView model)
        {
            if (model is null)
            {
                return null;
            }

            return RequestContent.Create(model, ModelSerializerOptions.DefaultWireOptions);
        }

        public static explicit operator VirtualMachineAgentInstanceView(Response response)
        {
            if (response is null)
            {
                return null;
            }

            using JsonDocument doc = JsonDocument.Parse(response.ContentStream);
            return DeserializeVirtualMachineAgentInstanceView(doc.RootElement, ModelSerializerOptions.DefaultWireOptions);
        }
    }
}
