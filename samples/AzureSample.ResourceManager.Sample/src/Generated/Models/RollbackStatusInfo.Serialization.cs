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

namespace AzureSample.ResourceManager.Sample.Models
{
    public partial class RollbackStatusInfo : IUtf8JsonSerializable, IJsonModel<RollbackStatusInfo>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<RollbackStatusInfo>)this).Write(writer, ModelSerializationExtensions.WireOptions);

        void IJsonModel<RollbackStatusInfo>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        /// <param name="writer"> The JSON writer. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<RollbackStatusInfo>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(RollbackStatusInfo)} does not support writing '{format}' format.");
            }

            if (options.Format != "W" && Optional.IsDefined(SuccessfullyRolledbackInstanceCount))
            {
                writer.WritePropertyName("successfullyRolledbackInstanceCount"u8);
                writer.WriteNumberValue(SuccessfullyRolledbackInstanceCount.Value);
            }
            if (options.Format != "W" && Optional.IsDefined(FailedRolledbackInstanceCount))
            {
                writer.WritePropertyName("failedRolledbackInstanceCount"u8);
                writer.WriteNumberValue(FailedRolledbackInstanceCount.Value);
            }
            if (options.Format != "W" && Optional.IsDefined(RollbackError))
            {
                writer.WritePropertyName("rollbackError"u8);
                writer.WriteObjectValue(RollbackError, options);
            }
            if (options.Format != "W" && _serializedAdditionalRawData != null)
            {
                foreach (var item in _serializedAdditionalRawData)
                {
                    writer.WritePropertyName(item.Key);
#if NET6_0_OR_GREATER
				writer.WriteRawValue(item.Value);
#else
                    using (JsonDocument document = JsonDocument.Parse(item.Value, ModelSerializationExtensions.JsonDocumentOptions))
                    {
                        JsonSerializer.Serialize(writer, document.RootElement);
                    }
#endif
                }
            }
        }

        RollbackStatusInfo IJsonModel<RollbackStatusInfo>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<RollbackStatusInfo>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(RollbackStatusInfo)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeRollbackStatusInfo(document.RootElement, options);
        }

        internal static RollbackStatusInfo DeserializeRollbackStatusInfo(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelSerializationExtensions.WireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            int? successfullyRolledbackInstanceCount = default;
            int? failedRolledbackInstanceCount = default;
            ApiError rollbackError = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> rawDataDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("successfullyRolledbackInstanceCount"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    successfullyRolledbackInstanceCount = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("failedRolledbackInstanceCount"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    failedRolledbackInstanceCount = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("rollbackError"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    rollbackError = ApiError.DeserializeApiError(property.Value, options);
                    continue;
                }
                if (options.Format != "W")
                {
                    rawDataDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = rawDataDictionary;
            return new RollbackStatusInfo(successfullyRolledbackInstanceCount, failedRolledbackInstanceCount, rollbackError, serializedAdditionalRawData);
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

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(SuccessfullyRolledbackInstanceCount), out propertyOverride);
            if (hasPropertyOverride)
            {
                builder.Append("  successfullyRolledbackInstanceCount: ");
                builder.AppendLine(propertyOverride);
            }
            else
            {
                if (Optional.IsDefined(SuccessfullyRolledbackInstanceCount))
                {
                    builder.Append("  successfullyRolledbackInstanceCount: ");
                    builder.AppendLine($"{SuccessfullyRolledbackInstanceCount.Value}");
                }
            }

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(FailedRolledbackInstanceCount), out propertyOverride);
            if (hasPropertyOverride)
            {
                builder.Append("  failedRolledbackInstanceCount: ");
                builder.AppendLine(propertyOverride);
            }
            else
            {
                if (Optional.IsDefined(FailedRolledbackInstanceCount))
                {
                    builder.Append("  failedRolledbackInstanceCount: ");
                    builder.AppendLine($"{FailedRolledbackInstanceCount.Value}");
                }
            }

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(RollbackError), out propertyOverride);
            if (hasPropertyOverride)
            {
                builder.Append("  rollbackError: ");
                builder.AppendLine(propertyOverride);
            }
            else
            {
                if (Optional.IsDefined(RollbackError))
                {
                    builder.Append("  rollbackError: ");
                    BicepSerializationHelpers.AppendChildObject(builder, RollbackError, options, 2, false, "  rollbackError: ");
                }
            }

            builder.AppendLine("}");
            return BinaryData.FromString(builder.ToString());
        }

        BinaryData IPersistableModel<RollbackStatusInfo>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<RollbackStatusInfo>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options, AzureSampleResourceManagerSampleContext.Default);
                case "bicep":
                    return SerializeBicep(options);
                default:
                    throw new FormatException($"The model {nameof(RollbackStatusInfo)} does not support writing '{options.Format}' format.");
            }
        }

        RollbackStatusInfo IPersistableModel<RollbackStatusInfo>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<RollbackStatusInfo>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data, ModelSerializationExtensions.JsonDocumentOptions);
                        return DeserializeRollbackStatusInfo(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(RollbackStatusInfo)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<RollbackStatusInfo>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
