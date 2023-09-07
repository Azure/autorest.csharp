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

namespace MgmtExactMatchFlattenInheritance.Models
{
    internal partial class AzureResourceFlattenModel2ListResult : IUtf8JsonSerializable, IModelJsonSerializable<AzureResourceFlattenModel2ListResult>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<AzureResourceFlattenModel2ListResult>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<AzureResourceFlattenModel2ListResult>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
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

        internal static AzureResourceFlattenModel2ListResult DeserializeAzureResourceFlattenModel2ListResult(JsonElement element, ModelSerializerOptions options = default)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<IReadOnlyList<AzureResourceFlattenModel2>> value = default;
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
                    List<AzureResourceFlattenModel2> array = new List<AzureResourceFlattenModel2>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(AzureResourceFlattenModel2.DeserializeAzureResourceFlattenModel2(item));
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
            return new AzureResourceFlattenModel2ListResult(Optional.ToList(value), nextLink.Value, serializedAdditionalRawData);
        }

        AzureResourceFlattenModel2ListResult IModelJsonSerializable<AzureResourceFlattenModel2ListResult>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using var doc = JsonDocument.ParseValue(ref reader);
            return DeserializeAzureResourceFlattenModel2ListResult(doc.RootElement, options);
        }

        BinaryData IModelSerializable<AzureResourceFlattenModel2ListResult>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            return ModelSerializer.SerializeCore(this, options);
        }

        AzureResourceFlattenModel2ListResult IModelSerializable<AzureResourceFlattenModel2ListResult>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using var doc = JsonDocument.Parse(data);
            return DeserializeAzureResourceFlattenModel2ListResult(doc.RootElement, options);
        }

        /// <summary> Converts a <see cref="AzureResourceFlattenModel2ListResult"/> into a <see cref="RequestContent"/>. </summary>
        /// <param name="model"> The <see cref="AzureResourceFlattenModel2ListResult"/> to convert. </param>
        public static implicit operator RequestContent(AzureResourceFlattenModel2ListResult model)
        {
            if (model is null)
            {
                return null;
            }

            return RequestContent.Create(model, ModelSerializerOptions.DefaultWireOptions);
        }

        /// <summary> Converts a <see cref="Response"/> into a <see cref="AzureResourceFlattenModel2ListResult"/>. </summary>
        /// <param name="response"> The <see cref="Response"/> to convert. </param>
        public static explicit operator AzureResourceFlattenModel2ListResult(Response response)
        {
            if (response is null)
            {
                return null;
            }

            using JsonDocument doc = JsonDocument.Parse(response.ContentStream);
            return DeserializeAzureResourceFlattenModel2ListResult(doc.RootElement, ModelSerializerOptions.DefaultWireOptions);
        }
    }
}
