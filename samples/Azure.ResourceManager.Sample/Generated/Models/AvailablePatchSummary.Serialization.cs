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
    public partial class AvailablePatchSummary : IUtf8JsonSerializable, IJsonModel<AvailablePatchSummary>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<AvailablePatchSummary>)this).Write(writer, new ModelReaderWriterOptions("W"));

        void IJsonModel<AvailablePatchSummary>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<AvailablePatchSummary>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(AvailablePatchSummary)} does not support '{format}' format.");
            }

            writer.WriteStartObject();
            if (options.Format != "W" && Optional.IsDefined(Status))
            {
                writer.WritePropertyName("status"u8);
                writer.WriteStringValue(Status.Value.ToString());
            }
            if (options.Format != "W" && Optional.IsDefined(AssessmentActivityId))
            {
                writer.WritePropertyName("assessmentActivityId"u8);
                writer.WriteStringValue(AssessmentActivityId);
            }
            if (options.Format != "W" && Optional.IsDefined(RebootPending))
            {
                writer.WritePropertyName("rebootPending"u8);
                writer.WriteBooleanValue(RebootPending.Value);
            }
            if (options.Format != "W" && Optional.IsDefined(CriticalAndSecurityPatchCount))
            {
                writer.WritePropertyName("criticalAndSecurityPatchCount"u8);
                writer.WriteNumberValue(CriticalAndSecurityPatchCount.Value);
            }
            if (options.Format != "W" && Optional.IsDefined(OtherPatchCount))
            {
                writer.WritePropertyName("otherPatchCount"u8);
                writer.WriteNumberValue(OtherPatchCount.Value);
            }
            if (options.Format != "W" && Optional.IsDefined(StartOn))
            {
                writer.WritePropertyName("startTime"u8);
                writer.WriteStringValue(StartOn.Value, "O");
            }
            if (options.Format != "W" && Optional.IsDefined(LastModifiedOn))
            {
                writer.WritePropertyName("lastModifiedTime"u8);
                writer.WriteStringValue(LastModifiedOn.Value, "O");
            }
            if (options.Format != "W" && Optional.IsDefined(Error))
            {
                writer.WritePropertyName("error"u8);
                writer.WriteObjectValue(Error);
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

        AvailablePatchSummary IJsonModel<AvailablePatchSummary>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<AvailablePatchSummary>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(AvailablePatchSummary)} does not support '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeAvailablePatchSummary(document.RootElement, options);
        }

        internal static AvailablePatchSummary DeserializeAvailablePatchSummary(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= new ModelReaderWriterOptions("W");

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<PatchOperationStatus> status = default;
            Optional<string> assessmentActivityId = default;
            Optional<bool> rebootPending = default;
            Optional<int> criticalAndSecurityPatchCount = default;
            Optional<int> otherPatchCount = default;
            Optional<DateTimeOffset> startTime = default;
            Optional<DateTimeOffset> lastModifiedTime = default;
            Optional<ApiError> error = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("status"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    status = new PatchOperationStatus(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("assessmentActivityId"u8))
                {
                    assessmentActivityId = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("rebootPending"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    rebootPending = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("criticalAndSecurityPatchCount"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    criticalAndSecurityPatchCount = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("otherPatchCount"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    otherPatchCount = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("startTime"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    startTime = property.Value.GetDateTimeOffset("O");
                    continue;
                }
                if (property.NameEquals("lastModifiedTime"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    lastModifiedTime = property.Value.GetDateTimeOffset("O");
                    continue;
                }
                if (property.NameEquals("error"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    error = ApiError.DeserializeApiError(property.Value, options);
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new AvailablePatchSummary(Optional.ToNullable(status), assessmentActivityId.Value, Optional.ToNullable(rebootPending), Optional.ToNullable(criticalAndSecurityPatchCount), Optional.ToNullable(otherPatchCount), Optional.ToNullable(startTime), Optional.ToNullable(lastModifiedTime), error.Value, serializedAdditionalRawData);
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

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(Status), out propertyOverride);
            if (Optional.IsDefined(Status) || hasPropertyOverride)
            {
                builder.Append("  status: ");
                if (hasPropertyOverride)
                {
                    builder.AppendLine($"{propertyOverride}");
                }
                else
                {
                    builder.AppendLine($"'{Status.Value.ToString()}'");
                }
            }

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(AssessmentActivityId), out propertyOverride);
            if (Optional.IsDefined(AssessmentActivityId) || hasPropertyOverride)
            {
                builder.Append("  assessmentActivityId: ");
                if (hasPropertyOverride)
                {
                    builder.AppendLine($"{propertyOverride}");
                }
                else
                {
                    if (AssessmentActivityId.Contains(Environment.NewLine))
                    {
                        builder.AppendLine("'''");
                        builder.AppendLine($"{AssessmentActivityId}'''");
                    }
                    else
                    {
                        builder.AppendLine($"'{AssessmentActivityId}'");
                    }
                }
            }

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(RebootPending), out propertyOverride);
            if (Optional.IsDefined(RebootPending) || hasPropertyOverride)
            {
                builder.Append("  rebootPending: ");
                if (hasPropertyOverride)
                {
                    builder.AppendLine($"{propertyOverride}");
                }
                else
                {
                    var boolValue = RebootPending.Value == true ? "true" : "false";
                    builder.AppendLine($"{boolValue}");
                }
            }

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(CriticalAndSecurityPatchCount), out propertyOverride);
            if (Optional.IsDefined(CriticalAndSecurityPatchCount) || hasPropertyOverride)
            {
                builder.Append("  criticalAndSecurityPatchCount: ");
                if (hasPropertyOverride)
                {
                    builder.AppendLine($"{propertyOverride}");
                }
                else
                {
                    builder.AppendLine($"{CriticalAndSecurityPatchCount.Value}");
                }
            }

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(OtherPatchCount), out propertyOverride);
            if (Optional.IsDefined(OtherPatchCount) || hasPropertyOverride)
            {
                builder.Append("  otherPatchCount: ");
                if (hasPropertyOverride)
                {
                    builder.AppendLine($"{propertyOverride}");
                }
                else
                {
                    builder.AppendLine($"{OtherPatchCount.Value}");
                }
            }

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(StartOn), out propertyOverride);
            if (Optional.IsDefined(StartOn) || hasPropertyOverride)
            {
                builder.Append("  startTime: ");
                if (hasPropertyOverride)
                {
                    builder.AppendLine($"{propertyOverride}");
                }
                else
                {
                    var formattedDateTimeString = TypeFormatters.ToString(StartOn.Value, "o");
                    builder.AppendLine($"'{formattedDateTimeString}'");
                }
            }

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(LastModifiedOn), out propertyOverride);
            if (Optional.IsDefined(LastModifiedOn) || hasPropertyOverride)
            {
                builder.Append("  lastModifiedTime: ");
                if (hasPropertyOverride)
                {
                    builder.AppendLine($"{propertyOverride}");
                }
                else
                {
                    var formattedDateTimeString = TypeFormatters.ToString(LastModifiedOn.Value, "o");
                    builder.AppendLine($"'{formattedDateTimeString}'");
                }
            }

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(Error), out propertyOverride);
            if (Optional.IsDefined(Error) || hasPropertyOverride)
            {
                builder.Append("  error: ");
                if (hasPropertyOverride)
                {
                    builder.AppendLine($"{propertyOverride}");
                }
                else
                {
                    AppendChildObject(builder, Error, options, 2, false, "  error: ");
                }
            }

            builder.AppendLine("}");
            return BinaryData.FromString(builder.ToString());
        }

        private void AppendChildObject(StringBuilder stringBuilder, object childObject, ModelReaderWriterOptions options, int spaces, bool indentFirstLine, string formattedPropertyName)
        {
            string indent = new string(' ', spaces);
            int emptyObjectLength = 2 + spaces + Environment.NewLine.Length + Environment.NewLine.Length;
            int length = stringBuilder.Length;
            bool inMultilineString = false;

            BinaryData data = ModelReaderWriter.Write(childObject, options);
            string[] lines = data.ToString().Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
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
            if (stringBuilder.Length == length + emptyObjectLength)
            {
                stringBuilder.Length = stringBuilder.Length - emptyObjectLength - formattedPropertyName.Length;
            }
        }

        BinaryData IPersistableModel<AvailablePatchSummary>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<AvailablePatchSummary>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                case "bicep":
                    return SerializeBicep(options);
                default:
                    throw new FormatException($"The model {nameof(AvailablePatchSummary)} does not support '{options.Format}' format.");
            }
        }

        AvailablePatchSummary IPersistableModel<AvailablePatchSummary>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<AvailablePatchSummary>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeAvailablePatchSummary(document.RootElement, options);
                    }
                case "bicep":
                    throw new InvalidOperationException("Bicep deserialization is not supported for this type.");
                default:
                    throw new FormatException($"The model {nameof(AvailablePatchSummary)} does not support '{options.Format}' format.");
            }
        }

        string IPersistableModel<AvailablePatchSummary>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
