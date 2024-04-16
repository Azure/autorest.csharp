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
    public partial class LastPatchInstallationSummary : IUtf8JsonSerializable, IJsonModel<LastPatchInstallationSummary>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<LastPatchInstallationSummary>)this).Write(writer, ModelSerializationExtensions.WireOptions);

        void IJsonModel<LastPatchInstallationSummary>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<LastPatchInstallationSummary>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(LastPatchInstallationSummary)} does not support writing '{format}' format.");
            }

            writer.WriteStartObject();
            if (options.Format != "W" && Optional.IsDefined(Status))
            {
                writer.WritePropertyName("status"u8);
                writer.WriteStringValue(Status.Value.ToString());
            }
            if (options.Format != "W" && Optional.IsDefined(InstallationActivityId))
            {
                writer.WritePropertyName("installationActivityId"u8);
                writer.WriteStringValue(InstallationActivityId);
            }
            if (options.Format != "W" && Optional.IsDefined(MaintenanceWindowExceeded))
            {
                writer.WritePropertyName("maintenanceWindowExceeded"u8);
                writer.WriteBooleanValue(MaintenanceWindowExceeded.Value);
            }
            if (options.Format != "W" && Optional.IsDefined(RebootStatus))
            {
                writer.WritePropertyName("rebootStatus"u8);
                writer.WriteStringValue(RebootStatus.Value.ToString());
            }
            if (options.Format != "W" && Optional.IsDefined(NotSelectedPatchCount))
            {
                writer.WritePropertyName("notSelectedPatchCount"u8);
                writer.WriteNumberValue(NotSelectedPatchCount.Value);
            }
            if (options.Format != "W" && Optional.IsDefined(ExcludedPatchCount))
            {
                writer.WritePropertyName("excludedPatchCount"u8);
                writer.WriteNumberValue(ExcludedPatchCount.Value);
            }
            if (options.Format != "W" && Optional.IsDefined(PendingPatchCount))
            {
                writer.WritePropertyName("pendingPatchCount"u8);
                writer.WriteNumberValue(PendingPatchCount.Value);
            }
            if (options.Format != "W" && Optional.IsDefined(InstalledPatchCount))
            {
                writer.WritePropertyName("installedPatchCount"u8);
                writer.WriteNumberValue(InstalledPatchCount.Value);
            }
            if (options.Format != "W" && Optional.IsDefined(FailedPatchCount))
            {
                writer.WritePropertyName("failedPatchCount"u8);
                writer.WriteNumberValue(FailedPatchCount.Value);
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
            if (options.Format != "W" && Optional.IsDefined(StartedBy))
            {
                writer.WritePropertyName("startedBy"u8);
                writer.WriteStringValue(StartedBy);
            }
            if (options.Format != "W" && Optional.IsDefined(Error))
            {
                writer.WritePropertyName("error"u8);
                writer.WriteObjectValue(Error, options);
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

        LastPatchInstallationSummary IJsonModel<LastPatchInstallationSummary>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<LastPatchInstallationSummary>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(LastPatchInstallationSummary)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeLastPatchInstallationSummary(document.RootElement, options);
        }

        internal static LastPatchInstallationSummary DeserializeLastPatchInstallationSummary(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelSerializationExtensions.WireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            PatchOperationStatus? status = default;
            string installationActivityId = default;
            bool? maintenanceWindowExceeded = default;
            RebootStatus? rebootStatus = default;
            int? notSelectedPatchCount = default;
            int? excludedPatchCount = default;
            int? pendingPatchCount = default;
            int? installedPatchCount = default;
            int? failedPatchCount = default;
            DateTimeOffset? startTime = default;
            DateTimeOffset? lastModifiedTime = default;
            string startedBy = default;
            ApiError error = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> rawDataDictionary = new Dictionary<string, BinaryData>();
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
                if (property.NameEquals("installationActivityId"u8))
                {
                    installationActivityId = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("maintenanceWindowExceeded"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    maintenanceWindowExceeded = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("rebootStatus"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    rebootStatus = new RebootStatus(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("notSelectedPatchCount"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    notSelectedPatchCount = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("excludedPatchCount"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    excludedPatchCount = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("pendingPatchCount"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    pendingPatchCount = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("installedPatchCount"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    installedPatchCount = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("failedPatchCount"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    failedPatchCount = property.Value.GetInt32();
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
                if (property.NameEquals("startedBy"u8))
                {
                    startedBy = property.Value.GetString();
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
                    rawDataDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = rawDataDictionary;
            return new LastPatchInstallationSummary(
                status,
                installationActivityId,
                maintenanceWindowExceeded,
                rebootStatus,
                notSelectedPatchCount,
                excludedPatchCount,
                pendingPatchCount,
                installedPatchCount,
                failedPatchCount,
                startTime,
                lastModifiedTime,
                startedBy,
                error,
                serializedAdditionalRawData);
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

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(InstallationActivityId), out propertyOverride);
            if (Optional.IsDefined(InstallationActivityId) || hasPropertyOverride)
            {
                builder.Append("  installationActivityId: ");
                if (hasPropertyOverride)
                {
                    builder.AppendLine($"{propertyOverride}");
                }
                else
                {
                    if (InstallationActivityId.Contains(Environment.NewLine))
                    {
                        builder.AppendLine("'''");
                        builder.AppendLine($"{InstallationActivityId}'''");
                    }
                    else
                    {
                        builder.AppendLine($"'{InstallationActivityId}'");
                    }
                }
            }

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(MaintenanceWindowExceeded), out propertyOverride);
            if (Optional.IsDefined(MaintenanceWindowExceeded) || hasPropertyOverride)
            {
                builder.Append("  maintenanceWindowExceeded: ");
                if (hasPropertyOverride)
                {
                    builder.AppendLine($"{propertyOverride}");
                }
                else
                {
                    var boolValue = MaintenanceWindowExceeded.Value == true ? "true" : "false";
                    builder.AppendLine($"{boolValue}");
                }
            }

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(RebootStatus), out propertyOverride);
            if (Optional.IsDefined(RebootStatus) || hasPropertyOverride)
            {
                builder.Append("  rebootStatus: ");
                if (hasPropertyOverride)
                {
                    builder.AppendLine($"{propertyOverride}");
                }
                else
                {
                    builder.AppendLine($"'{RebootStatus.Value.ToString()}'");
                }
            }

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(NotSelectedPatchCount), out propertyOverride);
            if (Optional.IsDefined(NotSelectedPatchCount) || hasPropertyOverride)
            {
                builder.Append("  notSelectedPatchCount: ");
                if (hasPropertyOverride)
                {
                    builder.AppendLine($"{propertyOverride}");
                }
                else
                {
                    builder.AppendLine($"{NotSelectedPatchCount.Value}");
                }
            }

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(ExcludedPatchCount), out propertyOverride);
            if (Optional.IsDefined(ExcludedPatchCount) || hasPropertyOverride)
            {
                builder.Append("  excludedPatchCount: ");
                if (hasPropertyOverride)
                {
                    builder.AppendLine($"{propertyOverride}");
                }
                else
                {
                    builder.AppendLine($"{ExcludedPatchCount.Value}");
                }
            }

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(PendingPatchCount), out propertyOverride);
            if (Optional.IsDefined(PendingPatchCount) || hasPropertyOverride)
            {
                builder.Append("  pendingPatchCount: ");
                if (hasPropertyOverride)
                {
                    builder.AppendLine($"{propertyOverride}");
                }
                else
                {
                    builder.AppendLine($"{PendingPatchCount.Value}");
                }
            }

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(InstalledPatchCount), out propertyOverride);
            if (Optional.IsDefined(InstalledPatchCount) || hasPropertyOverride)
            {
                builder.Append("  installedPatchCount: ");
                if (hasPropertyOverride)
                {
                    builder.AppendLine($"{propertyOverride}");
                }
                else
                {
                    builder.AppendLine($"{InstalledPatchCount.Value}");
                }
            }

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(FailedPatchCount), out propertyOverride);
            if (Optional.IsDefined(FailedPatchCount) || hasPropertyOverride)
            {
                builder.Append("  failedPatchCount: ");
                if (hasPropertyOverride)
                {
                    builder.AppendLine($"{propertyOverride}");
                }
                else
                {
                    builder.AppendLine($"{FailedPatchCount.Value}");
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

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(StartedBy), out propertyOverride);
            if (Optional.IsDefined(StartedBy) || hasPropertyOverride)
            {
                builder.Append("  startedBy: ");
                if (hasPropertyOverride)
                {
                    builder.AppendLine($"{propertyOverride}");
                }
                else
                {
                    if (StartedBy.Contains(Environment.NewLine))
                    {
                        builder.AppendLine("'''");
                        builder.AppendLine($"{StartedBy}'''");
                    }
                    else
                    {
                        builder.AppendLine($"'{StartedBy}'");
                    }
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
                    BicepSerializationHelpers.AppendChildObject(builder, Error, options, 2, false, "  error: ");
                }
            }

            builder.AppendLine("}");
            return BinaryData.FromString(builder.ToString());
        }

        BinaryData IPersistableModel<LastPatchInstallationSummary>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<LastPatchInstallationSummary>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                case "bicep":
                    return SerializeBicep(options);
                default:
                    throw new FormatException($"The model {nameof(LastPatchInstallationSummary)} does not support writing '{options.Format}' format.");
            }
        }

        LastPatchInstallationSummary IPersistableModel<LastPatchInstallationSummary>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<LastPatchInstallationSummary>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeLastPatchInstallationSummary(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(LastPatchInstallationSummary)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<LastPatchInstallationSummary>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
