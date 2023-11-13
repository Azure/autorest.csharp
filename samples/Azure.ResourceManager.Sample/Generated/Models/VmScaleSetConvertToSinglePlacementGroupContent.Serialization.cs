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

namespace Azure.ResourceManager.Sample.Models
{
    public partial class VmScaleSetConvertToSinglePlacementGroupContent : IUtf8JsonSerializable, IJsonModel<VmScaleSetConvertToSinglePlacementGroupContent>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<VmScaleSetConvertToSinglePlacementGroupContent>)this).Write(writer, ModelReaderWriterOptions.Wire);

        void IJsonModel<VmScaleSetConvertToSinglePlacementGroupContent>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            if ((options.Format != "W" || ((IPersistableModel<VmScaleSetConvertToSinglePlacementGroupContent>)this).GetWireFormat(options) != "J") && options.Format != "J")
            {
                throw new InvalidOperationException($"Must use 'J' format when calling the {nameof(IJsonModel<VmScaleSetConvertToSinglePlacementGroupContent>)} interface");
            }

            writer.WriteStartObject();
            if (Optional.IsDefined(ActivePlacementGroupId))
            {
                writer.WritePropertyName("activePlacementGroupId"u8);
                writer.WriteStringValue(ActivePlacementGroupId);
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

        VmScaleSetConvertToSinglePlacementGroupContent IJsonModel<VmScaleSetConvertToSinglePlacementGroupContent>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == "J" || options.Format == "W";
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(VmScaleSetConvertToSinglePlacementGroupContent)} does not support '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeVmScaleSetConvertToSinglePlacementGroupContent(document.RootElement, options);
        }

        internal static VmScaleSetConvertToSinglePlacementGroupContent DeserializeVmScaleSetConvertToSinglePlacementGroupContent(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelReaderWriterOptions.Wire;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<string> activePlacementGroupId = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("activePlacementGroupId"u8))
                {
                    activePlacementGroupId = property.Value.GetString();
                    continue;
                }
                if (options.Format == "J")
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new VmScaleSetConvertToSinglePlacementGroupContent(activePlacementGroupId.Value, serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<VmScaleSetConvertToSinglePlacementGroupContent>.Write(ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == "J" || options.Format == "W";
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(VmScaleSetConvertToSinglePlacementGroupContent)} does not support '{options.Format}' format.");
            }

            return ModelReaderWriter.Write(this, options);
        }

        VmScaleSetConvertToSinglePlacementGroupContent IPersistableModel<VmScaleSetConvertToSinglePlacementGroupContent>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == "J" || options.Format == "W";
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(VmScaleSetConvertToSinglePlacementGroupContent)} does not support '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeVmScaleSetConvertToSinglePlacementGroupContent(document.RootElement, options);
        }

        string IPersistableModel<VmScaleSetConvertToSinglePlacementGroupContent>.GetWireFormat(ModelReaderWriterOptions options) => "J";
    }
}
