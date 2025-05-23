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
    public partial class RollingUpgradeProgressInfo : IUtf8JsonSerializable, IJsonModel<RollingUpgradeProgressInfo>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<RollingUpgradeProgressInfo>)this).Write(writer, ModelSerializationExtensions.WireOptions);

        void IJsonModel<RollingUpgradeProgressInfo>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        /// <param name="writer"> The JSON writer. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<RollingUpgradeProgressInfo>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(RollingUpgradeProgressInfo)} does not support writing '{format}' format.");
            }

            if (options.Format != "W" && Optional.IsDefined(SuccessfulInstanceCount))
            {
                writer.WritePropertyName("successfulInstanceCount"u8);
                writer.WriteNumberValue(SuccessfulInstanceCount.Value);
            }
            if (options.Format != "W" && Optional.IsDefined(FailedInstanceCount))
            {
                writer.WritePropertyName("failedInstanceCount"u8);
                writer.WriteNumberValue(FailedInstanceCount.Value);
            }
            if (options.Format != "W" && Optional.IsDefined(InProgressInstanceCount))
            {
                writer.WritePropertyName("inProgressInstanceCount"u8);
                writer.WriteNumberValue(InProgressInstanceCount.Value);
            }
            if (options.Format != "W" && Optional.IsDefined(PendingInstanceCount))
            {
                writer.WritePropertyName("pendingInstanceCount"u8);
                writer.WriteNumberValue(PendingInstanceCount.Value);
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

        RollingUpgradeProgressInfo IJsonModel<RollingUpgradeProgressInfo>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<RollingUpgradeProgressInfo>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(RollingUpgradeProgressInfo)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeRollingUpgradeProgressInfo(document.RootElement, options);
        }

        internal static RollingUpgradeProgressInfo DeserializeRollingUpgradeProgressInfo(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelSerializationExtensions.WireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            int? successfulInstanceCount = default;
            int? failedInstanceCount = default;
            int? inProgressInstanceCount = default;
            int? pendingInstanceCount = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> rawDataDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("successfulInstanceCount"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    successfulInstanceCount = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("failedInstanceCount"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    failedInstanceCount = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("inProgressInstanceCount"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    inProgressInstanceCount = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("pendingInstanceCount"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    pendingInstanceCount = property.Value.GetInt32();
                    continue;
                }
                if (options.Format != "W")
                {
                    rawDataDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = rawDataDictionary;
            return new RollingUpgradeProgressInfo(successfulInstanceCount, failedInstanceCount, inProgressInstanceCount, pendingInstanceCount, serializedAdditionalRawData);
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

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(SuccessfulInstanceCount), out propertyOverride);
            if (hasPropertyOverride)
            {
                builder.Append("  successfulInstanceCount: ");
                builder.AppendLine(propertyOverride);
            }
            else
            {
                if (Optional.IsDefined(SuccessfulInstanceCount))
                {
                    builder.Append("  successfulInstanceCount: ");
                    builder.AppendLine($"{SuccessfulInstanceCount.Value}");
                }
            }

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(FailedInstanceCount), out propertyOverride);
            if (hasPropertyOverride)
            {
                builder.Append("  failedInstanceCount: ");
                builder.AppendLine(propertyOverride);
            }
            else
            {
                if (Optional.IsDefined(FailedInstanceCount))
                {
                    builder.Append("  failedInstanceCount: ");
                    builder.AppendLine($"{FailedInstanceCount.Value}");
                }
            }

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(InProgressInstanceCount), out propertyOverride);
            if (hasPropertyOverride)
            {
                builder.Append("  inProgressInstanceCount: ");
                builder.AppendLine(propertyOverride);
            }
            else
            {
                if (Optional.IsDefined(InProgressInstanceCount))
                {
                    builder.Append("  inProgressInstanceCount: ");
                    builder.AppendLine($"{InProgressInstanceCount.Value}");
                }
            }

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(PendingInstanceCount), out propertyOverride);
            if (hasPropertyOverride)
            {
                builder.Append("  pendingInstanceCount: ");
                builder.AppendLine(propertyOverride);
            }
            else
            {
                if (Optional.IsDefined(PendingInstanceCount))
                {
                    builder.Append("  pendingInstanceCount: ");
                    builder.AppendLine($"{PendingInstanceCount.Value}");
                }
            }

            builder.AppendLine("}");
            return BinaryData.FromString(builder.ToString());
        }

        BinaryData IPersistableModel<RollingUpgradeProgressInfo>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<RollingUpgradeProgressInfo>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options, AzureSampleResourceManagerSampleContext.Default);
                case "bicep":
                    return SerializeBicep(options);
                default:
                    throw new FormatException($"The model {nameof(RollingUpgradeProgressInfo)} does not support writing '{options.Format}' format.");
            }
        }

        RollingUpgradeProgressInfo IPersistableModel<RollingUpgradeProgressInfo>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<RollingUpgradeProgressInfo>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data, ModelSerializationExtensions.JsonDocumentOptions);
                        return DeserializeRollingUpgradeProgressInfo(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(RollingUpgradeProgressInfo)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<RollingUpgradeProgressInfo>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
