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
    public partial class UrlRewriteActionParameters : IUtf8JsonSerializable, IJsonModel<UrlRewriteActionParameters>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<UrlRewriteActionParameters>)this).Write(writer, ModelSerializationExtensions.WireOptions);

        void IJsonModel<UrlRewriteActionParameters>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        /// <param name="writer"> The JSON writer. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<UrlRewriteActionParameters>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(UrlRewriteActionParameters)} does not support writing '{format}' format.");
            }

            writer.WritePropertyName("typeName"u8);
            writer.WriteStringValue(TypeName.ToString());
            writer.WritePropertyName("sourcePattern"u8);
            writer.WriteStringValue(SourcePattern);
            writer.WritePropertyName("destination"u8);
            writer.WriteStringValue(Destination);
            if (Optional.IsDefined(PreserveUnmatchedPath))
            {
                writer.WritePropertyName("preserveUnmatchedPath"u8);
                writer.WriteBooleanValue(PreserveUnmatchedPath.Value);
            }
            if (options.Format != "W" && _serializedAdditionalRawData != null)
            {
                foreach (var item in _serializedAdditionalRawData)
                {
                    writer.WritePropertyName(item.Key);
#if NET6_0_OR_GREATER
				writer.WriteRawValue(item.Value);
#else
                    using (JsonDocument document = JsonDocument.Parse(item.Value, new JsonDocumentOptions { MaxDepth = 256 }))
                    {
                        JsonSerializer.Serialize(writer, document.RootElement);
                    }
#endif
                }
            }
        }

        UrlRewriteActionParameters IJsonModel<UrlRewriteActionParameters>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<UrlRewriteActionParameters>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(UrlRewriteActionParameters)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeUrlRewriteActionParameters(document.RootElement, options);
        }

        internal static UrlRewriteActionParameters DeserializeUrlRewriteActionParameters(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelSerializationExtensions.WireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            UrlRewriteActionParametersTypeName typeName = default;
            string sourcePattern = default;
            string destination = default;
            bool? preserveUnmatchedPath = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> rawDataDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("typeName"u8))
                {
                    typeName = new UrlRewriteActionParametersTypeName(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("sourcePattern"u8))
                {
                    sourcePattern = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("destination"u8))
                {
                    destination = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("preserveUnmatchedPath"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    preserveUnmatchedPath = property.Value.GetBoolean();
                    continue;
                }
                if (options.Format != "W")
                {
                    rawDataDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = rawDataDictionary;
            return new UrlRewriteActionParameters(typeName, sourcePattern, destination, preserveUnmatchedPath, serializedAdditionalRawData);
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
            if (hasPropertyOverride)
            {
                builder.Append("  typeName: ");
                builder.AppendLine(propertyOverride);
            }
            else
            {
                builder.Append("  typeName: ");
                builder.AppendLine($"'{TypeName.ToString()}'");
            }

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(SourcePattern), out propertyOverride);
            if (hasPropertyOverride)
            {
                builder.Append("  sourcePattern: ");
                builder.AppendLine(propertyOverride);
            }
            else
            {
                if (Optional.IsDefined(SourcePattern))
                {
                    builder.Append("  sourcePattern: ");
                    if (SourcePattern.Contains(Environment.NewLine))
                    {
                        builder.AppendLine("'''");
                        builder.AppendLine($"{SourcePattern}'''");
                    }
                    else
                    {
                        builder.AppendLine($"'{SourcePattern}'");
                    }
                }
            }

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(Destination), out propertyOverride);
            if (hasPropertyOverride)
            {
                builder.Append("  destination: ");
                builder.AppendLine(propertyOverride);
            }
            else
            {
                if (Optional.IsDefined(Destination))
                {
                    builder.Append("  destination: ");
                    if (Destination.Contains(Environment.NewLine))
                    {
                        builder.AppendLine("'''");
                        builder.AppendLine($"{Destination}'''");
                    }
                    else
                    {
                        builder.AppendLine($"'{Destination}'");
                    }
                }
            }

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(PreserveUnmatchedPath), out propertyOverride);
            if (hasPropertyOverride)
            {
                builder.Append("  preserveUnmatchedPath: ");
                builder.AppendLine(propertyOverride);
            }
            else
            {
                if (Optional.IsDefined(PreserveUnmatchedPath))
                {
                    builder.Append("  preserveUnmatchedPath: ");
                    var boolValue = PreserveUnmatchedPath.Value == true ? "true" : "false";
                    builder.AppendLine($"{boolValue}");
                }
            }

            builder.AppendLine("}");
            return BinaryData.FromString(builder.ToString());
        }

        BinaryData IPersistableModel<UrlRewriteActionParameters>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<UrlRewriteActionParameters>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                case "bicep":
                    return SerializeBicep(options);
                default:
                    throw new FormatException($"The model {nameof(UrlRewriteActionParameters)} does not support writing '{options.Format}' format.");
            }
        }

        UrlRewriteActionParameters IPersistableModel<UrlRewriteActionParameters>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<UrlRewriteActionParameters>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data, new JsonDocumentOptions { MaxDepth = 256 });
                        return DeserializeUrlRewriteActionParameters(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(UrlRewriteActionParameters)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<UrlRewriteActionParameters>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
