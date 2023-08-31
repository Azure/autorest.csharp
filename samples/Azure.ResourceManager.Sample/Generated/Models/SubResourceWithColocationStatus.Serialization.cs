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

namespace Azure.ResourceManager.Sample.Models
{
    public partial class SubResourceWithColocationStatus : IUtf8JsonSerializable, IModelJsonSerializable<SubResourceWithColocationStatus>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<SubResourceWithColocationStatus>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<SubResourceWithColocationStatus>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat<SubResourceWithColocationStatus>(this, options.Format);

            writer.WriteStartObject();
            if (Optional.IsDefined(ColocationStatus))
            {
                writer.WritePropertyName("colocationStatus"u8);
                if (ColocationStatus is null)
                {
                    writer.WriteNullValue();
                }
                else
                {
                    ((IModelJsonSerializable<InstanceViewStatus>)ColocationStatus).Serialize(writer, options);
                }
            }
            if (Optional.IsDefined(Id))
            {
                writer.WritePropertyName("id"u8);
                writer.WriteStringValue(Id);
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

        internal static SubResourceWithColocationStatus DeserializeSubResourceWithColocationStatus(JsonElement element, ModelSerializerOptions options = default)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<InstanceViewStatus> colocationStatus = default;
            Optional<string> id = default;
            Dictionary<string, BinaryData> rawData = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("colocationStatus"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    colocationStatus = InstanceViewStatus.DeserializeInstanceViewStatus(property.Value);
                    continue;
                }
                if (property.NameEquals("id"u8))
                {
                    id = property.Value.GetString();
                    continue;
                }
                if (options.Format == ModelSerializerFormat.Json)
                {
                    rawData.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                    continue;
                }
            }
            return new SubResourceWithColocationStatus(id.Value, colocationStatus.Value, rawData);
        }

        SubResourceWithColocationStatus IModelJsonSerializable<SubResourceWithColocationStatus>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat<SubResourceWithColocationStatus>(this, options.Format);

            using var doc = JsonDocument.ParseValue(ref reader);
            return DeserializeSubResourceWithColocationStatus(doc.RootElement, options);
        }

        BinaryData IModelSerializable<SubResourceWithColocationStatus>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat<SubResourceWithColocationStatus>(this, options.Format);

            return ModelSerializer.SerializeCore(this, options);
        }

        SubResourceWithColocationStatus IModelSerializable<SubResourceWithColocationStatus>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat<SubResourceWithColocationStatus>(this, options.Format);

            using var doc = JsonDocument.Parse(data);
            return DeserializeSubResourceWithColocationStatus(doc.RootElement, options);
        }

        /// <summary> Converts a <see cref="SubResourceWithColocationStatus"/> into a <see cref="RequestContent"/>. </summary>
        /// <param name="model"> The <see cref="SubResourceWithColocationStatus"/> to convert. </param>
        public static implicit operator RequestContent(SubResourceWithColocationStatus model)
        {
            if (model is null)
            {
                return null;
            }

            return RequestContent.Create(model, ModelSerializerOptions.DefaultWireOptions);
        }

        /// <summary> Converts a <see cref="Response"/> into a <see cref="SubResourceWithColocationStatus"/>. </summary>
        /// <param name="response"> The <see cref="Response"/> to convert. </param>
        public static explicit operator SubResourceWithColocationStatus(Response response)
        {
            if (response is null)
            {
                return null;
            }

            using JsonDocument doc = JsonDocument.Parse(response.ContentStream);
            return DeserializeSubResourceWithColocationStatus(doc.RootElement, ModelSerializerOptions.DefaultWireOptions);
        }
    }
}
