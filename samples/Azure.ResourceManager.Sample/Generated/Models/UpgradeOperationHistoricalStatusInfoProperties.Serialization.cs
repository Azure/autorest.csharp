// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Net.ClientModel;
using System.Net.ClientModel.Core;
using System.Net.ClientModel.Internal;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Sample.Models
{
    public partial class UpgradeOperationHistoricalStatusInfoProperties : IUtf8JsonSerializable, IJsonModel<UpgradeOperationHistoricalStatusInfoProperties>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<UpgradeOperationHistoricalStatusInfoProperties>)this).Write(writer, ModelReaderWriterOptions.DefaultWireOptions);

        void IJsonModel<UpgradeOperationHistoricalStatusInfoProperties>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            if (options.Format == ModelReaderWriterFormat.Json && Optional.IsDefined(RunningStatus))
            {
                writer.WritePropertyName("runningStatus"u8);
                writer.WriteObjectValue(RunningStatus);
            }
            if (options.Format == ModelReaderWriterFormat.Json && Optional.IsDefined(Progress))
            {
                writer.WritePropertyName("progress"u8);
                writer.WriteObjectValue(Progress);
            }
            if (options.Format == ModelReaderWriterFormat.Json && Optional.IsDefined(Error))
            {
                writer.WritePropertyName("error"u8);
                writer.WriteObjectValue(Error);
            }
            if (options.Format == ModelReaderWriterFormat.Json && Optional.IsDefined(StartedBy))
            {
                writer.WritePropertyName("startedBy"u8);
                writer.WriteStringValue(StartedBy.Value.ToSerialString());
            }
            if (options.Format == ModelReaderWriterFormat.Json && Optional.IsDefined(TargetImageReference))
            {
                writer.WritePropertyName("targetImageReference"u8);
                writer.WriteObjectValue(TargetImageReference);
            }
            if (options.Format == ModelReaderWriterFormat.Json && Optional.IsDefined(RollbackInfo))
            {
                writer.WritePropertyName("rollbackInfo"u8);
                writer.WriteObjectValue(RollbackInfo);
            }
            if (_serializedAdditionalRawData != null && options.Format == ModelReaderWriterFormat.Json)
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

        UpgradeOperationHistoricalStatusInfoProperties IJsonModel<UpgradeOperationHistoricalStatusInfoProperties>.Read(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeUpgradeOperationHistoricalStatusInfoProperties(document.RootElement, options);
        }

        internal static UpgradeOperationHistoricalStatusInfoProperties DeserializeUpgradeOperationHistoricalStatusInfoProperties(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelReaderWriterOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<UpgradeOperationHistoryStatus> runningStatus = default;
            Optional<RollingUpgradeProgressInfo> progress = default;
            Optional<ApiError> error = default;
            Optional<UpgradeOperationInvoker> startedBy = default;
            Optional<ImageReference> targetImageReference = default;
            Optional<RollbackStatusInfo> rollbackInfo = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("runningStatus"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    runningStatus = UpgradeOperationHistoryStatus.DeserializeUpgradeOperationHistoryStatus(property.Value);
                    continue;
                }
                if (property.NameEquals("progress"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    progress = RollingUpgradeProgressInfo.DeserializeRollingUpgradeProgressInfo(property.Value);
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
                if (property.NameEquals("startedBy"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    startedBy = property.Value.GetString().ToUpgradeOperationInvoker();
                    continue;
                }
                if (property.NameEquals("targetImageReference"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    targetImageReference = ImageReference.DeserializeImageReference(property.Value);
                    continue;
                }
                if (property.NameEquals("rollbackInfo"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    rollbackInfo = RollbackStatusInfo.DeserializeRollbackStatusInfo(property.Value);
                    continue;
                }
                if (options.Format == ModelReaderWriterFormat.Json)
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new UpgradeOperationHistoricalStatusInfoProperties(runningStatus.Value, progress.Value, error.Value, Optional.ToNullable(startedBy), targetImageReference.Value, rollbackInfo.Value, serializedAdditionalRawData);
        }

        BinaryData IModel<UpgradeOperationHistoricalStatusInfoProperties>.Write(ModelReaderWriterOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            return ModelReaderWriter.WriteCore(this, options);
        }

        UpgradeOperationHistoricalStatusInfoProperties IModel<UpgradeOperationHistoricalStatusInfoProperties>.Read(BinaryData data, ModelReaderWriterOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeUpgradeOperationHistoricalStatusInfoProperties(document.RootElement, options);
        }
    }
}
