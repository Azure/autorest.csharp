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
    public partial class HeaderActionParameters : IUtf8JsonSerializable, IJsonModel<HeaderActionParameters>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<HeaderActionParameters>)this).Write(writer, ModelSerializationExtensions.WireOptions);

        void IJsonModel<HeaderActionParameters>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<HeaderActionParameters>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(HeaderActionParameters)} does not support writing '{format}' format.");
            }

            writer.WriteStartObject();
            writer.WritePropertyName("typeName"u8);
            writer.WriteStringValue(TypeName.ToString());
            writer.WritePropertyName("headerAction"u8);
            writer.WriteStringValue(HeaderAction.ToString());
            writer.WritePropertyName("headerName"u8);
            writer.WriteStringValue(HeaderName);
            if (Optional.IsDefined(Value))
            {
                writer.WritePropertyName("value"u8);
                writer.WriteStringValue(Value);
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

        HeaderActionParameters IJsonModel<HeaderActionParameters>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<HeaderActionParameters>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(HeaderActionParameters)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeHeaderActionParameters(document.RootElement, options);
        }

        internal static HeaderActionParameters DeserializeHeaderActionParameters(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelSerializationExtensions.WireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            HeaderActionParametersTypeName typeName = default;
            HeaderAction headerAction = default;
            string headerName = default;
            string value = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> rawDataDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("typeName"u8))
                {
                    typeName = new HeaderActionParametersTypeName(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("headerAction"u8))
                {
                    headerAction = new HeaderAction(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("headerName"u8))
                {
                    headerName = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("value"u8))
                {
                    value = property.Value.GetString();
                    continue;
                }
                if (options.Format != "W")
                {
                    rawDataDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = rawDataDictionary;
            return new HeaderActionParameters(typeName, headerAction, headerName, value, serializedAdditionalRawData);
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

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(TypeName), out propertyOverride);
            if (hasPropertyOverride) builder.Append("  typeName: ");
            builder.AppendLine(propertyOverride);
else builder.Append("  typeName: ");
            builder.AppendLine($"'{TypeName.ToString()}'");

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(HeaderAction), out propertyOverride);
            if (hasPropertyOverride) builder.Append("  headerAction: ");
            builder.AppendLine(propertyOverride);
else builder.Append("  headerAction: ");
            builder.AppendLine($"'{HeaderAction.ToString()}'");

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(HeaderName), out propertyOverride);
            if (hasPropertyOverride) builder.Append("  headerName: ");
            builder.AppendLine(propertyOverride);
else if (Optional.IsDefined(HeaderName))
            {
                builder.Append("  headerName: ");
                if (HeaderName.Contains(Environment.NewLine))
                {
                    builder.AppendLine("'''");
                    builder.AppendLine($"{HeaderName}'''");
                }
                else
                {
                    builder.AppendLine($"'{HeaderName}'");
                }
            }

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(Value), out propertyOverride);
            if (hasPropertyOverride) builder.Append("  value: ");
            builder.AppendLine(propertyOverride);
else if (Optional.IsDefined(Value))
            {
                builder.Append("  value: ");
                if (Value.Contains(Environment.NewLine))
                {
                    builder.AppendLine("'''");
                    builder.AppendLine($"{Value}'''");
                }
                else
                {
                    builder.AppendLine($"'{Value}'");
                }
            }

            builder.AppendLine("}");
            return BinaryData.FromString(builder.ToString());
        }

        BinaryData IPersistableModel<HeaderActionParameters>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<HeaderActionParameters>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                case "bicep":
                    return SerializeBicep(options);
                default:
                    throw new FormatException($"The model {nameof(HeaderActionParameters)} does not support writing '{options.Format}' format.");
            }
        }

        HeaderActionParameters IPersistableModel<HeaderActionParameters>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<HeaderActionParameters>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeHeaderActionParameters(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(HeaderActionParameters)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<HeaderActionParameters>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
