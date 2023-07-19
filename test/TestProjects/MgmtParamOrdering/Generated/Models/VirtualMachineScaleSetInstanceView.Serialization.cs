// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Text.Json;
using Azure.Core;
using Azure.Core.Serialization;

namespace MgmtParamOrdering.Models
{
    public partial class VirtualMachineScaleSetInstanceView : IUtf8JsonSerializable, IJsonModelSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModelSerializable)this).Serialize(writer, ModelSerializerOptions.AzureServiceDefault);

        void IJsonModelSerializable.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WriteEndObject();
        }

        object IModelSerializable.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            using var doc = JsonDocument.Parse(data);
            return DeserializeVirtualMachineScaleSetInstanceView(doc.RootElement, options);
        }

        internal static VirtualMachineScaleSetInstanceView DeserializeVirtualMachineScaleSetInstanceView(JsonElement element, ModelSerializerOptions options = default)
        {
            options ??= ModelSerializerOptions.AzureServiceDefault;
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<string> virtualMachine = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("virtualMachine"u8))
                {
                    virtualMachine = property.Value.GetString();
                    continue;
                }
            }
            return new VirtualMachineScaleSetInstanceView(virtualMachine.Value);
        }

        object IJsonModelSerializable.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            using var doc = JsonDocument.ParseValue(ref reader);
            return DeserializeVirtualMachineScaleSetInstanceView(doc.RootElement, options);
        }
    }
}
