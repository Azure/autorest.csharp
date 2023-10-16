// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using Azure.Core.Serialization;

namespace MgmtAcronymMapping.Models
{
    public partial class VirtualMachineScaleSetVmExtensionsSummary : IUtf8JsonSerializable, IModelJsonSerializable<VirtualMachineScaleSetVmExtensionsSummary>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<VirtualMachineScaleSetVmExtensionsSummary>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<VirtualMachineScaleSetVmExtensionsSummary>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WriteEndObject();
        }

        VirtualMachineScaleSetVmExtensionsSummary IModelJsonSerializable<VirtualMachineScaleSetVmExtensionsSummary>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument doc = JsonDocument.ParseValue(ref reader);
            return DeserializeVirtualMachineScaleSetVmExtensionsSummary(doc.RootElement, options);
        }

        BinaryData IModelSerializable<VirtualMachineScaleSetVmExtensionsSummary>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);
            return ModelSerializer.SerializeCore(this, options);
        }

        VirtualMachineScaleSetVmExtensionsSummary IModelSerializable<VirtualMachineScaleSetVmExtensionsSummary>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeVirtualMachineScaleSetVmExtensionsSummary(document.RootElement, options);
        }

        internal static VirtualMachineScaleSetVmExtensionsSummary DeserializeVirtualMachineScaleSetVmExtensionsSummary(JsonElement element, ModelSerializerOptions options = null)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<string> name = default;
            Optional<IReadOnlyList<VirtualMachineStatusCodeCount>> statusesSummary = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("name"u8))
                {
                    name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("statusesSummary"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<VirtualMachineStatusCodeCount> array = new List<VirtualMachineStatusCodeCount>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(VirtualMachineStatusCodeCount.DeserializeVirtualMachineStatusCodeCount(item));
                    }
                    statusesSummary = array;
                    continue;
                }
            }
            return new VirtualMachineScaleSetVmExtensionsSummary(name.Value, Optional.ToList(statusesSummary));
        }
    }
}
