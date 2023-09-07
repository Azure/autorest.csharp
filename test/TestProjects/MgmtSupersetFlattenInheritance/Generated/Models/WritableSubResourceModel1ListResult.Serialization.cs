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

namespace MgmtSupersetFlattenInheritance.Models
{
    internal partial class WritableSubResourceModel1ListResult : IUtf8JsonSerializable, IModelJsonSerializable<WritableSubResourceModel1ListResult>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<WritableSubResourceModel1ListResult>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<WritableSubResourceModel1ListResult>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            writer.WriteStartObject();
            if (_serializedAdditionalRawData is not null && options.Format == ModelSerializerFormat.Json)
            {
                foreach (var property in _serializedAdditionalRawData)
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

        internal static WritableSubResourceModel1ListResult DeserializeWritableSubResourceModel1ListResult(JsonElement element, ModelSerializerOptions options = default)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<IReadOnlyList<WritableSubResourceModel1>> value = default;
            Optional<string> nextLink = default;
            Dictionary<string, BinaryData> serializedAdditionalRawData = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("value"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<WritableSubResourceModel1> array = new List<WritableSubResourceModel1>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(WritableSubResourceModel1.DeserializeWritableSubResourceModel1(item));
                    }
                    value = array;
                    continue;
                }
                if (property.NameEquals("nextLink"u8))
                {
                    nextLink = property.Value.GetString();
                    continue;
                }
                if (options.Format == ModelSerializerFormat.Json)
                {
                    serializedAdditionalRawData.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                    continue;
                }
            }
            return new WritableSubResourceModel1ListResult(Optional.ToList(value), nextLink.Value, serializedAdditionalRawData);
        }

        WritableSubResourceModel1ListResult IModelJsonSerializable<WritableSubResourceModel1ListResult>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using var doc = JsonDocument.ParseValue(ref reader);
            return DeserializeWritableSubResourceModel1ListResult(doc.RootElement, options);
        }

        BinaryData IModelSerializable<WritableSubResourceModel1ListResult>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            return ModelSerializer.SerializeCore(this, options);
        }

        WritableSubResourceModel1ListResult IModelSerializable<WritableSubResourceModel1ListResult>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using var doc = JsonDocument.Parse(data);
            return DeserializeWritableSubResourceModel1ListResult(doc.RootElement, options);
        }

        /// <summary> Converts a <see cref="WritableSubResourceModel1ListResult"/> into a <see cref="RequestContent"/>. </summary>
        /// <param name="model"> The <see cref="WritableSubResourceModel1ListResult"/> to convert. </param>
        public static implicit operator RequestContent(WritableSubResourceModel1ListResult model)
        {
            if (model is null)
            {
                return null;
            }

            return RequestContent.Create(model, ModelSerializerOptions.DefaultWireOptions);
        }

        /// <summary> Converts a <see cref="Response"/> into a <see cref="WritableSubResourceModel1ListResult"/>. </summary>
        /// <param name="response"> The <see cref="Response"/> to convert. </param>
        public static explicit operator WritableSubResourceModel1ListResult(Response response)
        {
            if (response is null)
            {
                return null;
            }

            using JsonDocument doc = JsonDocument.Parse(response.ContentStream);
            return DeserializeWritableSubResourceModel1ListResult(doc.RootElement, ModelSerializerOptions.DefaultWireOptions);
        }
    }
}
