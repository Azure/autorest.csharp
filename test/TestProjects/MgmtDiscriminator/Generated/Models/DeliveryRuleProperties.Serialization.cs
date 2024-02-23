// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using Azure.Core;

namespace MgmtDiscriminator.Models
{
    public partial class DeliveryRuleProperties : IUtf8JsonSerializable, IJsonModel<DeliveryRuleProperties>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<DeliveryRuleProperties>)this).Write(writer, new ModelReaderWriterOptions("W"));

        void IJsonModel<DeliveryRuleProperties>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<DeliveryRuleProperties>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(DeliveryRuleProperties)} does not support '{format}' format.");
            }

            writer.WriteStartObject();
            if (Order.HasValue)
            {
                writer.WritePropertyName("order"u8);
                writer.WriteNumberValue(Order.Value);
            }
            if (Conditions != null)
            {
                writer.WritePropertyName("conditions"u8);
                writer.WriteObjectValue(Conditions);
            }
            if (!(Actions is ChangeTrackingList<DeliveryRuleAction> collection && collection.IsUndefined))
            {
                writer.WritePropertyName("actions"u8);
                writer.WriteStartArray();
                foreach (var item in Actions)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            if (!(ExtraMappingInfo is ChangeTrackingDictionary<string, DeliveryRuleAction> collection0 && collection0.IsUndefined))
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
            if (Pet != null)
            {
                writer.WritePropertyName("pet"u8);
                writer.WriteObjectValue(Pet);
            }
            if (options.Format != "W" && Foo != null)
            {
                writer.WritePropertyName("foo"u8);
                writer.WriteStringValue(Foo);
            }
            if (options.Format != "W" && _serializedAdditionalRawData != null)
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
            var format = options.Format == "W" ? ((IPersistableModel<DeliveryRuleProperties>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(DeliveryRuleProperties)} does not support '{format}' format.");
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
                    conditions = DeliveryRuleCondition.DeserializeDeliveryRuleCondition(property.Value, options);
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
                        array.Add(DeliveryRuleAction.DeserializeDeliveryRuleAction(item, options));
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
                        dictionary.Add(property0.Name, DeliveryRuleAction.DeserializeDeliveryRuleAction(property0.Value, options));
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
                    pet = Pet.DeserializePet(property.Value, options);
                    continue;
                }
                if (property.NameEquals("foo"u8))
                {
                    foo = property.Value.GetString();
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new DeliveryRuleProperties(Optional.ToNullable(order), conditions.Value, Optional.ToList(actions), Optional.ToDictionary(extraMappingInfo), pet.Value, foo.Value, serializedAdditionalRawData);
        }

        private BinaryData SerializeBicep(ModelReaderWriterOptions options)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("{");

            if (Order.HasValue)
            {
                builder.Append("  order:");
                builder.AppendLine($" {Order.Value}");
            }

            if (Conditions != null)
            {
                builder.Append("  conditions:");
                AppendChildObject(builder, Conditions, options, 2, false);
            }

            if (!(Actions is ChangeTrackingList<DeliveryRuleAction> collection && collection.IsUndefined))
            {
                if (Actions.Any())
                {
                    builder.Append("  actions:");
                    builder.AppendLine(" [");
                    foreach (var item in Actions)
                    {
                        AppendChildObject(builder, item, options, 4, true);
                    }
                    builder.AppendLine("  ]");
                }
            }

            if (!(ExtraMappingInfo is ChangeTrackingDictionary<string, DeliveryRuleAction> collection0 && collection0.IsUndefined))
            {
                if (ExtraMappingInfo.Any())
                {
                    builder.Append("  extraMappingInfo:");
                    builder.AppendLine(" {");
                    foreach (var item in ExtraMappingInfo)
                    {
                        builder.Append($"    {item.Key}:");
                        AppendChildObject(builder, item.Value, options, 4, false);
                    }
                    builder.AppendLine("  }");
                }
            }

            if (Pet != null)
            {
                builder.Append("  pet:");
                AppendChildObject(builder, Pet, options, 2, false);
            }

            if (Foo != null)
            {
                builder.Append("  foo:");
                if (Foo.Contains(Environment.NewLine))
                {
                    builder.AppendLine(" '''");
                    builder.AppendLine($"{Foo}'''");
                }
                else
                {
                    builder.AppendLine($" '{Foo}'");
                }
            }

            builder.AppendLine("}");
            return BinaryData.FromString(builder.ToString());
        }

        private void AppendChildObject(StringBuilder stringBuilder, object childObject, ModelReaderWriterOptions options, int spaces, bool indentFirstLine)
        {
            string indent = new string(' ', spaces);
            BinaryData data = ModelReaderWriter.Write(childObject, options);
            string[] lines = data.ToString().Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            bool inMultilineString = false;
            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i];
                if (inMultilineString)
                {
                    if (line.Contains("'''"))
                    {
                        inMultilineString = false;
                    }
                    stringBuilder.AppendLine(line);
                    continue;
                }
                if (line.Contains("'''"))
                {
                    inMultilineString = true;
                    stringBuilder.AppendLine($"{indent}{line}");
                    continue;
                }
                if (i == 0 && !indentFirstLine)
                {
                    stringBuilder.AppendLine($" {line}");
                }
                else
                {
                    stringBuilder.AppendLine($"{indent}{line}");
                }
            }
        }

        BinaryData IPersistableModel<DeliveryRuleProperties>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<DeliveryRuleProperties>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                case "bicep":
                    return SerializeBicep(options);
                default:
                    throw new FormatException($"The model {nameof(DeliveryRuleProperties)} does not support '{options.Format}' format.");
            }
        }

        DeliveryRuleProperties IPersistableModel<DeliveryRuleProperties>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<DeliveryRuleProperties>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeDeliveryRuleProperties(document.RootElement, options);
                    }
                case "bicep":
                    throw new InvalidOperationException("Bicep deserialization is not supported for this type.");
                default:
                    throw new FormatException($"The model {nameof(DeliveryRuleProperties)} does not support '{options.Format}' format.");
            }
        }

        string IPersistableModel<DeliveryRuleProperties>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
