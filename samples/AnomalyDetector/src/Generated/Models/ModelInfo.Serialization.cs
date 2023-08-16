// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Text.Json;
using Azure;
using Azure.Core;
using Azure.Core.Serialization;

namespace AnomalyDetector.Models
{
    public partial class ModelInfo : IUtf8JsonSerializable, IModelJsonSerializable<ModelInfo>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<ModelInfo>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<ModelInfo>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            writer.WriteStartObject();
            writer.WritePropertyName("dataSource"u8);
            writer.WriteStringValue(DataSource);
            if (Optional.IsDefined(DataSchema))
            {
                writer.WritePropertyName("dataSchema"u8);
                writer.WriteStringValue(DataSchema.Value.ToString());
            }
            writer.WritePropertyName("startTime"u8);
            writer.WriteStringValue(StartTime, "O");
            writer.WritePropertyName("endTime"u8);
            writer.WriteStringValue(EndTime, "O");
            if (Optional.IsDefined(DisplayName))
            {
                writer.WritePropertyName("displayName"u8);
                writer.WriteStringValue(DisplayName);
            }
            if (Optional.IsDefined(SlidingWindow))
            {
                writer.WritePropertyName("slidingWindow"u8);
                writer.WriteNumberValue(SlidingWindow.Value);
            }
            if (Optional.IsDefined(AlignPolicy))
            {
                writer.WritePropertyName("alignPolicy"u8);
                writer.WriteObjectValue(AlignPolicy);
            }
            if (Optional.IsDefined(Status))
            {
                writer.WritePropertyName("status"u8);
                writer.WriteStringValue(Status.Value.ToSerialString());
            }
            if (Optional.IsDefined(DiagnosticsInfo))
            {
                writer.WritePropertyName("diagnosticsInfo"u8);
                writer.WriteObjectValue(DiagnosticsInfo);
            }
            if (_rawData is not null && options.Format == ModelSerializerFormat.Json)
            {
                foreach (var property in _rawData)
                {
                    writer.WritePropertyName(property.Key);
#if NET6_0_OR_GREATER
				writer.WriteRawValue(property.Value);
#else
                    JsonSerializer.Serialize(writer, JsonDocument.Parse(property.Value.ToString()).RootElement);
#endif
                }
            }
            writer.WriteEndObject();
        }

        internal static ModelInfo DeserializeModelInfo(JsonElement element, ModelSerializerOptions options = default)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string dataSource = default;
            Optional<DataSchema> dataSchema = default;
            DateTimeOffset startTime = default;
            DateTimeOffset endTime = default;
            Optional<string> displayName = default;
            Optional<int> slidingWindow = default;
            Optional<AlignPolicy> alignPolicy = default;
            Optional<ModelStatus> status = default;
            Optional<IReadOnlyList<ErrorResponse>> errors = default;
            Optional<DiagnosticsInfo> diagnosticsInfo = default;
            Dictionary<string, BinaryData> rawData = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("dataSource"u8))
                {
                    dataSource = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("dataSchema"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    dataSchema = new DataSchema(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("startTime"u8))
                {
                    startTime = property.Value.GetDateTimeOffset("O");
                    continue;
                }
                if (property.NameEquals("endTime"u8))
                {
                    endTime = property.Value.GetDateTimeOffset("O");
                    continue;
                }
                if (property.NameEquals("displayName"u8))
                {
                    displayName = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("slidingWindow"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    slidingWindow = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("alignPolicy"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    alignPolicy = AlignPolicy.DeserializeAlignPolicy(property.Value);
                    continue;
                }
                if (property.NameEquals("status"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    status = property.Value.GetString().ToModelStatus();
                    continue;
                }
                if (property.NameEquals("errors"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<ErrorResponse> array = new List<ErrorResponse>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(ErrorResponse.DeserializeErrorResponse(item));
                    }
                    errors = array;
                    continue;
                }
                if (property.NameEquals("diagnosticsInfo"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    diagnosticsInfo = DiagnosticsInfo.DeserializeDiagnosticsInfo(property.Value);
                    continue;
                }
                if (options.Format == ModelSerializerFormat.Json)
                {
                    rawData.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                    continue;
                }
            }
            return new ModelInfo(dataSource, Optional.ToNullable(dataSchema), startTime, endTime, displayName.Value, Optional.ToNullable(slidingWindow), alignPolicy.Value, Optional.ToNullable(status), Optional.ToList(errors), diagnosticsInfo.Value, rawData);
        }

        ModelInfo IModelJsonSerializable<ModelInfo>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using var doc = JsonDocument.ParseValue(ref reader);
            return DeserializeModelInfo(doc.RootElement, options);
        }

        BinaryData IModelSerializable<ModelInfo>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            return ModelSerializer.SerializeCore(this, options);
        }

        ModelInfo IModelSerializable<ModelInfo>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using var doc = JsonDocument.Parse(data);
            return DeserializeModelInfo(doc.RootElement, options);
        }

        public static implicit operator RequestContent(ModelInfo model)
        {
            if (model is null)
            {
                return null;
            }

            return RequestContent.Create(model, ModelSerializerOptions.DefaultWireOptions);
        }

        public static explicit operator ModelInfo(Response response)
        {
            if (response is null)
            {
                return null;
            }

            using JsonDocument doc = JsonDocument.Parse(response.ContentStream);
            return DeserializeModelInfo(doc.RootElement, ModelSerializerOptions.DefaultWireOptions);
        }
    }
}
