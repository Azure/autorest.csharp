// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Sample.Models
{
    public partial class LastPatchInstallationSummary : IUtf8JsonSerializable, IJsonModel<LastPatchInstallationSummary>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<LastPatchInstallationSummary>)this).Write(writer, new ModelReaderWriterOptions("W"));

        void IJsonModel<LastPatchInstallationSummary>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<LastPatchInstallationSummary>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new InvalidOperationException($"The model {nameof(LastPatchInstallationSummary)} does not support '{format}' format.");
            }

            writer.WriteStartObject();
            if (options.Format == "J")
            {
                if (Optional.IsDefined(Status))
                {
                    writer.WritePropertyName("status"u8);
                    writer.WriteStringValue(Status.Value.ToString());
                }
            }
            if (options.Format == "J")
            {
                if (Optional.IsDefined(InstallationActivityId))
                {
                    writer.WritePropertyName("installationActivityId"u8);
                    writer.WriteStringValue(InstallationActivityId);
                }
            }
            if (options.Format == "J")
            {
                if (Optional.IsDefined(MaintenanceWindowExceeded))
                {
                    writer.WritePropertyName("maintenanceWindowExceeded"u8);
                    writer.WriteBooleanValue(MaintenanceWindowExceeded.Value);
                }
            }
            if (options.Format == "J")
            {
                if (Optional.IsDefined(RebootStatus))
                {
                    writer.WritePropertyName("rebootStatus"u8);
                    writer.WriteStringValue(RebootStatus.Value.ToString());
                }
            }
            if (options.Format == "J")
            {
                if (Optional.IsDefined(NotSelectedPatchCount))
                {
                    writer.WritePropertyName("notSelectedPatchCount"u8);
                    writer.WriteNumberValue(NotSelectedPatchCount.Value);
                }
            }
            if (options.Format == "J")
            {
                if (Optional.IsDefined(ExcludedPatchCount))
                {
                    writer.WritePropertyName("excludedPatchCount"u8);
                    writer.WriteNumberValue(ExcludedPatchCount.Value);
                }
            }
            if (options.Format == "J")
            {
                if (Optional.IsDefined(PendingPatchCount))
                {
                    writer.WritePropertyName("pendingPatchCount"u8);
                    writer.WriteNumberValue(PendingPatchCount.Value);
                }
            }
            if (options.Format == "J")
            {
                if (Optional.IsDefined(InstalledPatchCount))
                {
                    writer.WritePropertyName("installedPatchCount"u8);
                    writer.WriteNumberValue(InstalledPatchCount.Value);
                }
            }
            if (options.Format == "J")
            {
                if (Optional.IsDefined(FailedPatchCount))
                {
                    writer.WritePropertyName("failedPatchCount"u8);
                    writer.WriteNumberValue(FailedPatchCount.Value);
                }
            }
            if (options.Format == "J")
            {
                if (Optional.IsDefined(StartOn))
                {
                    writer.WritePropertyName("startTime"u8);
                    writer.WriteStringValue(StartOn.Value, "O");
                }
            }
            if (options.Format == "J")
            {
                if (Optional.IsDefined(LastModifiedOn))
                {
                    writer.WritePropertyName("lastModifiedTime"u8);
                    writer.WriteStringValue(LastModifiedOn.Value, "O");
                }
            }
            if (options.Format == "J")
            {
                if (Optional.IsDefined(StartedBy))
                {
                    writer.WritePropertyName("startedBy"u8);
                    writer.WriteStringValue(StartedBy);
                }
            }
            if (options.Format == "J")
            {
                if (Optional.IsDefined(Error))
                {
                    writer.WritePropertyName("error"u8);
                    writer.WriteObjectValue(Error);
                }
            }
            if (_serializedAdditionalRawData != null && options.Format != "W")
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
                throw new InvalidOperationException($"The model {nameof(LastPatchInstallationSummary)} does not support '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeLastPatchInstallationSummary(document.RootElement, options);
        }

        internal static LastPatchInstallationSummary DeserializeLastPatchInstallationSummary(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= new ModelReaderWriterOptions("W");

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<PatchOperationStatus> status = default;
            Optional<string> installationActivityId = default;
            Optional<bool> maintenanceWindowExceeded = default;
            Optional<RebootStatus> rebootStatus = default;
            Optional<int> notSelectedPatchCount = default;
            Optional<int> excludedPatchCount = default;
            Optional<int> pendingPatchCount = default;
            Optional<int> installedPatchCount = default;
            Optional<int> failedPatchCount = default;
            Optional<DateTimeOffset> startTime = default;
            Optional<DateTimeOffset> lastModifiedTime = default;
            Optional<string> startedBy = default;
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
                    error = ApiError.DeserializeApiError(property.Value);
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new LastPatchInstallationSummary(Optional.ToNullable(status), installationActivityId.Value, Optional.ToNullable(maintenanceWindowExceeded), Optional.ToNullable(rebootStatus), Optional.ToNullable(notSelectedPatchCount), Optional.ToNullable(excludedPatchCount), Optional.ToNullable(pendingPatchCount), Optional.ToNullable(installedPatchCount), Optional.ToNullable(failedPatchCount), Optional.ToNullable(startTime), Optional.ToNullable(lastModifiedTime), startedBy.Value, error.Value, serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<LastPatchInstallationSummary>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<LastPatchInstallationSummary>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new InvalidOperationException($"The model {nameof(LastPatchInstallationSummary)} does not support '{options.Format}' format.");
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
                    throw new InvalidOperationException($"The model {nameof(LastPatchInstallationSummary)} does not support '{options.Format}' format.");
            }
        }

        string IPersistableModel<LastPatchInstallationSummary>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
