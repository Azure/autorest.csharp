// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Text.Json;
using Azure.Core;
using Azure.Core.Serialization;

namespace Azure.AI.FormRecognizer.Models
{
    public partial class CopyOperationResult : IUtf8JsonSerializable, IModelJsonSerializable<CopyOperationResult>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<CopyOperationResult>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<CopyOperationResult>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("status"u8);
            writer.WriteStringValue(Status.ToSerialString());
            writer.WritePropertyName("createdDateTime"u8);
            writer.WriteStringValue(CreatedDateTime, "O");
            writer.WritePropertyName("lastUpdatedDateTime"u8);
            writer.WriteStringValue(LastUpdatedDateTime, "O");
            if (Optional.IsDefined(CopyResult))
            {
                writer.WritePropertyName("copyResult"u8);
                writer.WriteObjectValue(CopyResult);
            }
            writer.WriteEndObject();
        }

        CopyOperationResult IModelJsonSerializable<CopyOperationResult>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeCopyOperationResult(document.RootElement, options);
        }

        BinaryData IModelSerializable<CopyOperationResult>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);
            return ModelSerializer.SerializeCore(this, options);
        }

        CopyOperationResult IModelSerializable<CopyOperationResult>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeCopyOperationResult(document.RootElement, options);
        }

        internal static CopyOperationResult DeserializeCopyOperationResult(JsonElement element, ModelSerializerOptions options = null)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            OperationStatus status = default;
            DateTimeOffset createdDateTime = default;
            DateTimeOffset lastUpdatedDateTime = default;
            Optional<CopyResult> copyResult = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("status"u8))
                {
                    status = property.Value.GetString().ToOperationStatus();
                    continue;
                }
                if (property.NameEquals("createdDateTime"u8))
                {
                    createdDateTime = property.Value.GetDateTimeOffset("O");
                    continue;
                }
                if (property.NameEquals("lastUpdatedDateTime"u8))
                {
                    lastUpdatedDateTime = property.Value.GetDateTimeOffset("O");
                    continue;
                }
                if (property.NameEquals("copyResult"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    copyResult = CopyResult.DeserializeCopyResult(property.Value);
                    continue;
                }
            }
            return new CopyOperationResult(status, createdDateTime, lastUpdatedDateTime, copyResult.Value);
        }
    }
}
