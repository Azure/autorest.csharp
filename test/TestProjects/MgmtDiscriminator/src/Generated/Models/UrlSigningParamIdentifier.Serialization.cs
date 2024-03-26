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
    public partial class UrlSigningParamIdentifier : IUtf8JsonSerializable, IJsonModel<UrlSigningParamIdentifier>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<UrlSigningParamIdentifier>)this).Write(writer, new ModelReaderWriterOptions("W"));

        void IJsonModel<UrlSigningParamIdentifier>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<UrlSigningParamIdentifier>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(UrlSigningParamIdentifier)} does not support writing '{format}' format.");
            }

            writer.WriteStartObject();
            writer.WritePropertyName("paramIndicator"u8);
            writer.WriteStringValue(ParamIndicator.ToString());
            writer.WritePropertyName("paramName"u8);
            writer.WriteStringValue(ParamName);
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

        UrlSigningParamIdentifier IJsonModel<UrlSigningParamIdentifier>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<UrlSigningParamIdentifier>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(UrlSigningParamIdentifier)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeUrlSigningParamIdentifier(document.RootElement, options);
        }

        internal static UrlSigningParamIdentifier DeserializeUrlSigningParamIdentifier(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= new ModelReaderWriterOptions("W");

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            ParamIndicator paramIndicator = default;
            string paramName = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("paramIndicator"u8))
                {
                    paramIndicator = new ParamIndicator(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("paramName"u8))
                {
                    paramName = property.Value.GetString();
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new UrlSigningParamIdentifier(paramIndicator, paramName, serializedAdditionalRawData);
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

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(ParamIndicator), out propertyOverride);
            builder.Append("  paramIndicator: ");
            if (hasPropertyOverride)
            {
                builder.AppendLine($"{propertyOverride}");
            }
            else
            {
                builder.AppendLine($"'{ParamIndicator.ToString()}'");
            }

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(ParamName), out propertyOverride);
            if (Optional.IsDefined(ParamName) || hasPropertyOverride)
            {
                builder.Append("  paramName: ");
                if (hasPropertyOverride)
                {
                    builder.AppendLine($"{propertyOverride}");
                }
                else
                {
                    if (ParamName.Contains(Environment.NewLine))
                    {
                        builder.AppendLine("'''");
                        builder.AppendLine($"{ParamName}'''");
                    }
                    else
                    {
                        builder.AppendLine($"'{ParamName}'");
                    }
                }
            }

            builder.AppendLine("}");
            return BinaryData.FromString(builder.ToString());
        }

        BinaryData IPersistableModel<UrlSigningParamIdentifier>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<UrlSigningParamIdentifier>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                case "bicep":
                    return SerializeBicep(options);
                default:
                    throw new FormatException($"The model {nameof(UrlSigningParamIdentifier)} does not support writing '{options.Format}' format.");
            }
        }

        UrlSigningParamIdentifier IPersistableModel<UrlSigningParamIdentifier>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<UrlSigningParamIdentifier>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeUrlSigningParamIdentifier(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(UrlSigningParamIdentifier)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<UrlSigningParamIdentifier>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
