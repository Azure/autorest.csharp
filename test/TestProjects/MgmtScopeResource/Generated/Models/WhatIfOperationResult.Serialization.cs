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

namespace MgmtScopeResource.Models
{
    public partial class WhatIfOperationResult : IUtf8JsonSerializable, IModelJsonSerializable<WhatIfOperationResult>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<WhatIfOperationResult>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<WhatIfOperationResult>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            writer.WriteStartObject();
            if (Optional.IsDefined(Status))
            {
                writer.WritePropertyName("status"u8);
                writer.WriteStringValue(Status);
            }
            if (Optional.IsDefined(ErrorResponse))
            {
                writer.WritePropertyName("errorResponse"u8);
                ((IModelJsonSerializable<ErrorResponse>)ErrorResponse).Serialize(writer, options);
            }
            writer.WritePropertyName("properties"u8);
            writer.WriteStartObject();
            if (Optional.IsCollectionDefined(Changes))
            {
                writer.WritePropertyName("changes"u8);
                writer.WriteStartArray();
                foreach (var item in Changes)
                {
                    ((IModelJsonSerializable<WhatIfChange>)item).Serialize(writer, options);
                }
                writer.WriteEndArray();
            }
            writer.WriteEndObject();
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

        internal static WhatIfOperationResult DeserializeWhatIfOperationResult(JsonElement element, ModelSerializerOptions options = default)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<string> status = default;
            Optional<ErrorResponse> errorResponse = default;
            Optional<IReadOnlyList<WhatIfChange>> changes = default;
            Dictionary<string, BinaryData> rawData = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("status"u8))
                {
                    status = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("errorResponse"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    errorResponse = ErrorResponse.DeserializeErrorResponse(property.Value);
                    continue;
                }
                if (property.NameEquals("properties"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    foreach (var property0 in property.Value.EnumerateObject())
                    {
                        if (property0.NameEquals("changes"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            List<WhatIfChange> array = new List<WhatIfChange>();
                            foreach (var item in property0.Value.EnumerateArray())
                            {
                                array.Add(WhatIfChange.DeserializeWhatIfChange(item));
                            }
                            changes = array;
                            continue;
                        }
                    }
                    continue;
                }
                if (options.Format == ModelSerializerFormat.Json)
                {
                    rawData.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                    continue;
                }
            }
            return new WhatIfOperationResult(status.Value, errorResponse.Value, Optional.ToList(changes), rawData);
        }

        WhatIfOperationResult IModelJsonSerializable<WhatIfOperationResult>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using var doc = JsonDocument.ParseValue(ref reader);
            return DeserializeWhatIfOperationResult(doc.RootElement, options);
        }

        BinaryData IModelSerializable<WhatIfOperationResult>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            return ModelSerializer.SerializeCore(this, options);
        }

        WhatIfOperationResult IModelSerializable<WhatIfOperationResult>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using var doc = JsonDocument.Parse(data);
            return DeserializeWhatIfOperationResult(doc.RootElement, options);
        }

        /// <summary> Converts a <see cref="WhatIfOperationResult"/> into a <see cref="RequestContent"/>. </summary>
        /// <param name="model"> The <see cref="WhatIfOperationResult"/> to convert. </param>
        public static implicit operator RequestContent(WhatIfOperationResult model)
        {
            if (model is null)
            {
                return null;
            }

            return RequestContent.Create(model, ModelSerializerOptions.DefaultWireOptions);
        }

        /// <summary> Converts a <see cref="Response"/> into a <see cref="WhatIfOperationResult"/>. </summary>
        /// <param name="response"> The <see cref="Response"/> to convert. </param>
        public static explicit operator WhatIfOperationResult(Response response)
        {
            if (response is null)
            {
                return null;
            }

            using JsonDocument doc = JsonDocument.Parse(response.ContentStream);
            return DeserializeWhatIfOperationResult(doc.RootElement, ModelSerializerOptions.DefaultWireOptions);
        }
    }
}
