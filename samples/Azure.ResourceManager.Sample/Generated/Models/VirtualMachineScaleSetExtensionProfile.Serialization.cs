// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using Azure.Core.Serialization;
using Azure.ResourceManager.Sample;

namespace Azure.ResourceManager.Sample.Models
{
    public partial class VirtualMachineScaleSetExtensionProfile : IUtf8JsonSerializable, IModelSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelSerializable)this).Serialize(writer, new SerializableOptions());

        void IModelSerializable.Serialize(Utf8JsonWriter writer, SerializableOptions options)
        {
            writer.WriteStartObject();
            if (Optional.IsCollectionDefined(Extensions))
            {
                writer.WritePropertyName("extensions"u8);
                writer.WriteStartArray();
                foreach (var item in Extensions)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsDefined(ExtensionsTimeBudget))
            {
                writer.WritePropertyName("extensionsTimeBudget"u8);
                writer.WriteStringValue(ExtensionsTimeBudget);
            }
            writer.WriteEndObject();
        }

        internal static VirtualMachineScaleSetExtensionProfile DeserializeVirtualMachineScaleSetExtensionProfile(JsonElement element, SerializableOptions options = default)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<IList<VirtualMachineScaleSetExtensionData>> extensions = default;
            Optional<string> extensionsTimeBudget = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("extensions"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<VirtualMachineScaleSetExtensionData> array = new List<VirtualMachineScaleSetExtensionData>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(VirtualMachineScaleSetExtensionData.DeserializeVirtualMachineScaleSetExtensionData(item));
                    }
                    extensions = array;
                    continue;
                }
                if (property.NameEquals("extensionsTimeBudget"u8))
                {
                    extensionsTimeBudget = property.Value.GetString();
                    continue;
                }
            }
            return new VirtualMachineScaleSetExtensionProfile(Optional.ToList(extensions), extensionsTimeBudget.Value);
        }
    }
}
