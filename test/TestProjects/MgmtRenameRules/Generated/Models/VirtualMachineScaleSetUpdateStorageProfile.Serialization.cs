// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using Azure.Core.Serialization;

namespace MgmtRenameRules.Models
{
    public partial class VirtualMachineScaleSetUpdateStorageProfile : IUtf8JsonSerializable, IJsonModelSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModelSerializable)this).Serialize(writer, ModelSerializerOptions.AzureServiceDefault);

        void IJsonModelSerializable.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(ImageReference))
            {
                writer.WritePropertyName("imageReference"u8);
                writer.WriteObjectValue(ImageReference);
            }
            if (Optional.IsDefined(OSDisk))
            {
                writer.WritePropertyName("osDisk"u8);
                writer.WriteObjectValue(OSDisk);
            }
            if (Optional.IsCollectionDefined(DataDisks))
            {
                writer.WritePropertyName("dataDisks"u8);
                writer.WriteStartArray();
                foreach (var item in DataDisks)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            writer.WriteEndObject();
        }

        object IModelSerializable.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            using var doc = JsonDocument.Parse(data);
            return DeserializeVirtualMachineScaleSetUpdateStorageProfile(doc.RootElement, options);
        }

        internal static VirtualMachineScaleSetUpdateStorageProfile DeserializeVirtualMachineScaleSetUpdateStorageProfile(JsonElement element, ModelSerializerOptions options = default)
        {
            options ??= ModelSerializerOptions.AzureServiceDefault;
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<ImageReference> imageReference = default;
            Optional<VirtualMachineScaleSetUpdateOSDisk> osDisk = default;
            Optional<IList<VirtualMachineScaleSetDataDisk>> dataDisks = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("imageReference"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    imageReference = ImageReference.DeserializeImageReference(property.Value);
                    continue;
                }
                if (property.NameEquals("osDisk"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    osDisk = VirtualMachineScaleSetUpdateOSDisk.DeserializeVirtualMachineScaleSetUpdateOSDisk(property.Value);
                    continue;
                }
                if (property.NameEquals("dataDisks"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<VirtualMachineScaleSetDataDisk> array = new List<VirtualMachineScaleSetDataDisk>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(VirtualMachineScaleSetDataDisk.DeserializeVirtualMachineScaleSetDataDisk(item));
                    }
                    dataDisks = array;
                    continue;
                }
            }
            return new VirtualMachineScaleSetUpdateStorageProfile(imageReference.Value, osDisk.Value, Optional.ToList(dataDisks));
        }

        object IJsonModelSerializable.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            using var doc = JsonDocument.ParseValue(ref reader);
            return DeserializeVirtualMachineScaleSetUpdateStorageProfile(doc.RootElement, options);
        }
    }
}
