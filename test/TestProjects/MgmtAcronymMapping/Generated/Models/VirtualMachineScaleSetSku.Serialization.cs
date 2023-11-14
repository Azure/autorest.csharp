// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Net.ClientModel;
using System.Net.ClientModel.Core;
using System.Text.Json;
using Azure.Core;

namespace MgmtAcronymMapping.Models
{
    public partial class VirtualMachineScaleSetSku : IUtf8JsonSerializable, IJsonModel<VirtualMachineScaleSetSku>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<VirtualMachineScaleSetSku>)this).Write(writer, ModelReaderWriterOptions.Wire);

        void IJsonModel<VirtualMachineScaleSetSku>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            if ((options.Format != "W" || ((IPersistableModel<VirtualMachineScaleSetSku>)this).GetWireFormat(options) != "J") && options.Format != "J")
            {
                throw new InvalidOperationException($"Must use 'J' format when calling the {nameof(IJsonModel<VirtualMachineScaleSetSku>)} interface");
            }

            writer.WriteStartObject();
            if (options.Format == "J")
            {
                if (Optional.IsDefined(ResourceType))
                {
                    writer.WritePropertyName("resourceType"u8);
                    writer.WriteStringValue(ResourceType);
                }
            }
            if (options.Format == "J")
            {
                if (Optional.IsDefined(Sku))
                {
                    writer.WritePropertyName("sku"u8);
                    writer.WriteObjectValue(Sku);
                }
            }
            if (options.Format == "J")
            {
                if (Optional.IsDefined(Capacity))
                {
                    writer.WritePropertyName("capacity"u8);
                    writer.WriteObjectValue(Capacity);
                }
            }
            if (_serializedAdditionalRawData != null && options.Format == "J")
            {
                foreach (var item in _serializedAdditionalRawData)
                {
                    writer.WritePropertyName(item.Key);
#if NET6_0_OR_GREATER
				writer.WriteRawValue(item.Value);
#else
                    using (JsonDocument document = JsonDocument.Parse(item.Value))
                    {
                        JsonSerializer.Serialize(writer, document.RootElement);
                    }
#endif
                }
            }
            writer.WriteEndObject();
        }

        VirtualMachineScaleSetSku IJsonModel<VirtualMachineScaleSetSku>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == "J" || options.Format == "W";
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(VirtualMachineScaleSetSku)} does not support '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeVirtualMachineScaleSetSku(document.RootElement, options);
        }

        internal static VirtualMachineScaleSetSku DeserializeVirtualMachineScaleSetSku(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelReaderWriterOptions.Wire;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<string> resourceType = default;
            Optional<MgmtAcronymMappingSku> sku = default;
            Optional<VirtualMachineScaleSetSkuCapacity> capacity = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("resourceType"u8))
                {
                    resourceType = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("sku"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    sku = MgmtAcronymMappingSku.DeserializeMgmtAcronymMappingSku(property.Value);
                    continue;
                }
                if (property.NameEquals("capacity"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    capacity = VirtualMachineScaleSetSkuCapacity.DeserializeVirtualMachineScaleSetSkuCapacity(property.Value);
                    continue;
                }
                if (options.Format == "J")
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new VirtualMachineScaleSetSku(resourceType.Value, sku.Value, capacity.Value, serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<VirtualMachineScaleSetSku>.Write(ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == "J" || options.Format == "W";
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(VirtualMachineScaleSetSku)} does not support '{options.Format}' format.");
            }

            return ModelReaderWriter.Write(this, options);
        }

        VirtualMachineScaleSetSku IPersistableModel<VirtualMachineScaleSetSku>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == "J" || options.Format == "W";
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(VirtualMachineScaleSetSku)} does not support '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeVirtualMachineScaleSetSku(document.RootElement, options);
        }

        string IPersistableModel<VirtualMachineScaleSetSku>.GetWireFormat(ModelReaderWriterOptions options) => "J";
    }
}
