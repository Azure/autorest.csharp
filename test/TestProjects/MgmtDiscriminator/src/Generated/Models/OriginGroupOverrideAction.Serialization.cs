// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager;

namespace MgmtDiscriminator.Models
{
    public partial class OriginGroupOverrideAction : IUtf8JsonSerializable, IJsonModel<OriginGroupOverrideAction>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<OriginGroupOverrideAction>)this).Write(writer, ModelSerializationExtensions.WireOptions);

        void IJsonModel<OriginGroupOverrideAction>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<OriginGroupOverrideAction>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(OriginGroupOverrideAction)} does not support writing '{format}' format.");
            }

            writer.WriteStartObject();
            writer.WritePropertyName("parameters"u8);
            writer.WriteObjectValue(Parameters, options);
            writer.WritePropertyName("name"u8);
            writer.WriteStringValue(Name.ToString());
            if (options.Format != "W" && Optional.IsDefined(Foo))
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

        OriginGroupOverrideAction IJsonModel<OriginGroupOverrideAction>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<OriginGroupOverrideAction>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(OriginGroupOverrideAction)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeOriginGroupOverrideAction(document.RootElement, options);
        }

        internal static OriginGroupOverrideAction DeserializeOriginGroupOverrideAction(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelSerializationExtensions.WireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            OriginGroupOverrideActionParameters parameters = default;
            DeliveryRuleActionType name = default;
            string foo = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> rawDataDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("parameters"u8))
                {
                    parameters = OriginGroupOverrideActionParameters.DeserializeOriginGroupOverrideActionParameters(property.Value, options);
                    continue;
                }
                if (property.NameEquals("name"u8))
                {
                    name = new DeliveryRuleActionType(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("foo"u8))
                {
                    foo = property.Value.GetString();
                    continue;
                }
                if (options.Format != "W")
                {
                    rawDataDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = rawDataDictionary;
            return new OriginGroupOverrideAction(name, foo, serializedAdditionalRawData, parameters);
        }

        private BinaryData SerializeBicep(ModelReaderWriterOptions options)
        {
            StringBuilder builder = new StringBuilder();
            BicepModelReaderWriterOptions bicepOptions = options as BicepModelReaderWriterOptions;
            IDictionary<string, string> propertyOverrides = null;
            bool hasObjectOverride = bicepOptions != null && bicepOptions.PropertyOverrides.TryGetValue(this, out propertyOverrides);
            bool hasPropertyOverride = false;
            string propertyOverride = null;

            builder.AppendLine("{");

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(Parameters), out propertyOverride);
            if (hasPropertyOverride) builder.Append("  parameters: ");
            builder.AppendLine(propertyOverride);
else if (Optional.IsDefined(Parameters))
            {
                builder.Append("  parameters: ");
                BicepSerializationHelpers.AppendChildObject(builder, Parameters, options, 2, false, "  parameters: ");
            }

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(Name), out propertyOverride);
            if (hasPropertyOverride) builder.Append("  name: ");
            builder.AppendLine(propertyOverride);
else builder.Append("  name: ");
            builder.AppendLine($"'{Name.ToString()}'");

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(Foo), out propertyOverride);
            if (hasPropertyOverride) builder.Append("  foo: ");
            builder.AppendLine(propertyOverride);
else if (Optional.IsDefined(Foo))
            {
                builder.Append("  foo: ");
                if (Foo.Contains(Environment.NewLine))
                {
                    builder.AppendLine("'''");
                    builder.AppendLine($"{Foo}'''");
                }
                else
                {
                    builder.AppendLine($"'{Foo}'");
                }
            }

            builder.AppendLine("}");
            return BinaryData.FromString(builder.ToString());
        }

        BinaryData IPersistableModel<OriginGroupOverrideAction>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<OriginGroupOverrideAction>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                case "bicep":
                    return SerializeBicep(options);
                default:
                    throw new FormatException($"The model {nameof(OriginGroupOverrideAction)} does not support writing '{options.Format}' format.");
            }
        }

        OriginGroupOverrideAction IPersistableModel<OriginGroupOverrideAction>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<OriginGroupOverrideAction>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeOriginGroupOverrideAction(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(OriginGroupOverrideAction)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<OriginGroupOverrideAction>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
