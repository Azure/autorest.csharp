// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Sample.Models
{
    internal partial class DedicatedHostAvailableCapacity : IUtf8JsonSerializable, IJsonModel<DedicatedHostAvailableCapacity>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<DedicatedHostAvailableCapacity>)this).Write(writer, new ModelReaderWriterOptions("W"));

        void IJsonModel<DedicatedHostAvailableCapacity>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            if ((options.Format != "W" || ((IPersistableModel<DedicatedHostAvailableCapacity>)this).GetFormatFromOptions(options) != "J") && options.Format != "J")
            {
                throw new InvalidOperationException($"Must use 'J' format when calling the {nameof(IJsonModel<DedicatedHostAvailableCapacity>)} interface");
            }

            writer.WriteStartObject();
            if (Optional.IsCollectionDefined(AllocatableVms))
            {
                writer.WritePropertyName("allocatableVMs"u8);
                writer.WriteStartArray();
                foreach (var item in AllocatableVms)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
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

        DedicatedHostAvailableCapacity IJsonModel<DedicatedHostAvailableCapacity>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == "J" || options.Format == "W";
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(DedicatedHostAvailableCapacity)} does not support '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeDedicatedHostAvailableCapacity(document.RootElement, options);
        }

        internal static DedicatedHostAvailableCapacity DeserializeDedicatedHostAvailableCapacity(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= new ModelReaderWriterOptions("W");

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<IReadOnlyList<DedicatedHostAllocatableVm>> allocatableVms = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("allocatableVMs"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<DedicatedHostAllocatableVm> array = new List<DedicatedHostAllocatableVm>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(DedicatedHostAllocatableVm.DeserializeDedicatedHostAllocatableVm(item));
                    }
                    allocatableVms = array;
                    continue;
                }
                if (options.Format == "J")
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new DedicatedHostAvailableCapacity(Optional.ToList(allocatableVms), serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<DedicatedHostAvailableCapacity>.Write(ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == "J" || options.Format == "W";
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(DedicatedHostAvailableCapacity)} does not support '{options.Format}' format.");
            }

            return ModelReaderWriter.Write(this, options);
        }

        DedicatedHostAvailableCapacity IPersistableModel<DedicatedHostAvailableCapacity>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == "J" || options.Format == "W";
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(DedicatedHostAvailableCapacity)} does not support '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeDedicatedHostAvailableCapacity(document.RootElement, options);
        }

        string IPersistableModel<DedicatedHostAvailableCapacity>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
