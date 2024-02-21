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

namespace Azure.ResourceManager.Sample.Models
{
    public partial class RollingUpgradeProgressInfo : IUtf8JsonSerializable, IJsonModel<RollingUpgradeProgressInfo>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<RollingUpgradeProgressInfo>)this).Write(writer, new ModelReaderWriterOptions("W"));

        void IJsonModel<RollingUpgradeProgressInfo>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<RollingUpgradeProgressInfo>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(RollingUpgradeProgressInfo)} does not support '{format}' format.");
            }

            writer.WriteStartObject();
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
                    using (JsonDocument document = JsonDocument.Parse(item.Value))
                    {
                        JsonSerializer.Serialize(writer, document.RootElement);
                    }
#endif
                }
            }
            writer.WriteEndObject();
        }

        RollingUpgradeProgressInfo IJsonModel<RollingUpgradeProgressInfo>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<RollingUpgradeProgressInfo>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(RollingUpgradeProgressInfo)} does not support '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeRollingUpgradeProgressInfo(document.RootElement, options);
        }

        internal static RollingUpgradeProgressInfo DeserializeRollingUpgradeProgressInfo(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= new ModelReaderWriterOptions("W");

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<int> successfulInstanceCount = default;
            Optional<int> failedInstanceCount = default;
            Optional<int> inProgressInstanceCount = default;
            Optional<int> pendingInstanceCount = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
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
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new RollingUpgradeProgressInfo(Optional.ToNullable(successfulInstanceCount), Optional.ToNullable(failedInstanceCount), Optional.ToNullable(inProgressInstanceCount), Optional.ToNullable(pendingInstanceCount), serializedAdditionalRawData);
        }

        private BinaryData SerializeBicep(ModelReaderWriterOptions options)
        {
            StringBuilder builder = new StringBuilder();
            BicepModelReaderWriterOptions bicepOptions = options as BicepModelReaderWriterOptions;
            IDictionary<string, string> propertyOverrides = null;
            bool hasObjectOverride = bicepOptions != null && bicepOptions.ParameterOverrides.TryGetValue(this, out propertyOverrides);
            bool hasPropertyOverride = false;
            string propertyOverride = null;

            builder.AppendLine("{");

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(SuccessfulInstanceCount), out propertyOverride);
            if (Optional.IsDefined(SuccessfulInstanceCount) || hasPropertyOverride)
            {
                builder.Append("  successfulInstanceCount: ");
                if (hasPropertyOverride)
                {
                    builder.AppendLine($"{propertyOverride}");
                }
                else
                {
                    builder.AppendLine($"{SuccessfulInstanceCount.Value}");
                }
            }

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(FailedInstanceCount), out propertyOverride);
            if (Optional.IsDefined(FailedInstanceCount) || hasPropertyOverride)
            {
                builder.Append("  failedInstanceCount: ");
                if (hasPropertyOverride)
                {
                    builder.AppendLine($"{propertyOverride}");
                }
                else
                {
                    builder.AppendLine($"{FailedInstanceCount.Value}");
                }
            }

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(InProgressInstanceCount), out propertyOverride);
            if (Optional.IsDefined(InProgressInstanceCount) || hasPropertyOverride)
            {
                builder.Append("  inProgressInstanceCount: ");
                if (hasPropertyOverride)
                {
                    builder.AppendLine($"{propertyOverride}");
                }
                else
                {
                    builder.AppendLine($"{InProgressInstanceCount.Value}");
                }
            }

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(PendingInstanceCount), out propertyOverride);
            if (Optional.IsDefined(PendingInstanceCount) || hasPropertyOverride)
            {
                builder.Append("  pendingInstanceCount: ");
                if (hasPropertyOverride)
                {
                    builder.AppendLine($"{propertyOverride}");
                }
                else
                {
                    builder.AppendLine($"{PendingInstanceCount.Value}");
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
                    stringBuilder.AppendLine($"{line}");
                }
                else
                {
                    stringBuilder.AppendLine($"{indent}{line}");
                }
            }
        }

        BinaryData IPersistableModel<RollingUpgradeProgressInfo>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<RollingUpgradeProgressInfo>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                case "bicep":
                    return SerializeBicep(options);
                default:
                    throw new FormatException($"The model {nameof(RollingUpgradeProgressInfo)} does not support '{options.Format}' format.");
            }
        }

        RollingUpgradeProgressInfo IPersistableModel<RollingUpgradeProgressInfo>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<RollingUpgradeProgressInfo>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeRollingUpgradeProgressInfo(document.RootElement, options);
                    }
                case "bicep":
                    throw new InvalidOperationException("Bicep deserialization is not supported for this type.");
                default:
                    throw new FormatException($"The model {nameof(RollingUpgradeProgressInfo)} does not support '{options.Format}' format.");
            }
        }

        string IPersistableModel<RollingUpgradeProgressInfo>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
