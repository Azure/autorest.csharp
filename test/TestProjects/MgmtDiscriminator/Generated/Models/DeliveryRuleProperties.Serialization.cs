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

namespace MgmtDiscriminator.Models
{
    public partial class DeliveryRuleProperties : IUtf8JsonSerializable, IJsonModel<DeliveryRuleProperties>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<DeliveryRuleProperties>)this).Write(writer, new ModelReaderWriterOptions("W"));

        void IJsonModel<DeliveryRuleProperties>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            if ((options.Format != "W" || ((IPersistableModel<DeliveryRuleProperties>)this).GetFormatFromOptions(options) != "J") && options.Format != "J")
            {
                throw new InvalidOperationException($"Must use 'J' format when calling the {nameof(IJsonModel<DeliveryRuleProperties>)} interface");
            }

            writer.WriteStartObject();
            if (Optional.IsDefined(Order))
            {
                writer.WritePropertyName("order"u8);
                writer.WriteNumberValue(Order.Value);
            }
            if (Optional.IsDefined(Conditions))
            {
                writer.WritePropertyName("conditions"u8);
                writer.WriteObjectValue(Conditions);
            }
            if (Optional.IsCollectionDefined(Actions))
            {
                writer.WritePropertyName("actions"u8);
                writer.WriteStartArray();
                foreach (var item in Actions)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsCollectionDefined(ExtraMappingInfo))
            {
                writer.WritePropertyName("extraMappingInfo"u8);
                writer.WriteStartObject();
                foreach (var item in ExtraMappingInfo)
                {
                    writer.WritePropertyName(item.Key);
                    writer.WriteObjectValue(item.Value);
                }
                writer.WriteEndObject();
            }
            if (Optional.IsDefined(Pet))
            {
                writer.WritePropertyName("pet"u8);
                writer.WriteObjectValue(Pet);
            }
            if (options.Format == "J")
            {
                if (Optional.IsDefined(Foo))
                {
                    writer.WritePropertyName("foo"u8);
                    writer.WriteStringValue(Foo);
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

        DeliveryRuleProperties IJsonModel<DeliveryRuleProperties>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == "J" || options.Format == "W";
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(DeliveryRuleProperties)} does not support '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeDeliveryRuleProperties(document.RootElement, options);
        }

        internal static DeliveryRuleProperties DeserializeDeliveryRuleProperties(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= new ModelReaderWriterOptions("W");

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<int> order = default;
            Optional<DeliveryRuleCondition> conditions = default;
            Optional<IList<DeliveryRuleAction>> actions = default;
            Optional<IDictionary<string, DeliveryRuleAction>> extraMappingInfo = default;
            Optional<Pet> pet = default;
            Optional<string> foo = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("order"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    order = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("conditions"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    conditions = DeliveryRuleCondition.DeserializeDeliveryRuleCondition(property.Value);
                    continue;
                }
                if (property.NameEquals("actions"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<DeliveryRuleAction> array = new List<DeliveryRuleAction>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(DeliveryRuleAction.DeserializeDeliveryRuleAction(item));
                    }
                    actions = array;
                    continue;
                }
                if (property.NameEquals("extraMappingInfo"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    Dictionary<string, DeliveryRuleAction> dictionary = new Dictionary<string, DeliveryRuleAction>();
                    foreach (var property0 in property.Value.EnumerateObject())
                    {
                        dictionary.Add(property0.Name, DeliveryRuleAction.DeserializeDeliveryRuleAction(property0.Value));
                    }
                    extraMappingInfo = dictionary;
                    continue;
                }
                if (property.NameEquals("pet"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    pet = Pet.DeserializePet(property.Value);
                    continue;
                }
                if (property.NameEquals("foo"u8))
                {
                    foo = property.Value.GetString();
                    continue;
                }
                if (options.Format == "J")
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new DeliveryRuleProperties(Optional.ToNullable(order), conditions.Value, Optional.ToList(actions), Optional.ToDictionary(extraMappingInfo), pet.Value, foo.Value, serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<DeliveryRuleProperties>.Write(ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == "J" || options.Format == "W";
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(DeliveryRuleProperties)} does not support '{options.Format}' format.");
            }

            return ModelReaderWriter.Write(this, options);
        }

        DeliveryRuleProperties IPersistableModel<DeliveryRuleProperties>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == "J" || options.Format == "W";
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(DeliveryRuleProperties)} does not support '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeDeliveryRuleProperties(document.RootElement, options);
        }

        string IPersistableModel<DeliveryRuleProperties>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
