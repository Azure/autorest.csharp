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

namespace CognitiveSearch.Models
{
    public partial class DataDeletionDetectionPolicy : IUtf8JsonSerializable, IModelJsonSerializable<DataDeletionDetectionPolicy>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<DataDeletionDetectionPolicy>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<DataDeletionDetectionPolicy>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            writer.WriteStartObject();
            writer.WritePropertyName("@odata.type"u8);
            writer.WriteStringValue(OdataType);
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

        internal static DataDeletionDetectionPolicy DeserializeDataDeletionDetectionPolicy(JsonElement element, ModelSerializerOptions options = default)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            if (element.TryGetProperty("@odata.type", out JsonElement discriminator))
            {
                switch (discriminator.GetString())
                {
                    case "#Microsoft.Azure.Search.SoftDeleteColumnDeletionDetectionPolicy": return SoftDeleteColumnDeletionDetectionPolicy.DeserializeSoftDeleteColumnDeletionDetectionPolicy(element);
                }
            }

            // Unknown type found so we will deserialize the base properties only
            string odataType = default;
            Dictionary<string, BinaryData> serializedAdditionalRawData = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("@odata.type"u8))
                {
                    odataType = property.Value.GetString();
                    continue;
                }
                if (options.Format == ModelSerializerFormat.Json)
                {
                    serializedAdditionalRawData.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                    continue;
                }
            }
            return new UnknownDataDeletionDetectionPolicy(odataType, serializedAdditionalRawData);
        }

        DataDeletionDetectionPolicy IModelJsonSerializable<DataDeletionDetectionPolicy>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using var doc = JsonDocument.ParseValue(ref reader);
            return DeserializeDataDeletionDetectionPolicy(doc.RootElement, options);
        }

        BinaryData IModelSerializable<DataDeletionDetectionPolicy>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            return ModelSerializer.SerializeCore(this, options);
        }

        DataDeletionDetectionPolicy IModelSerializable<DataDeletionDetectionPolicy>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using var doc = JsonDocument.Parse(data);
            return DeserializeDataDeletionDetectionPolicy(doc.RootElement, options);
        }

        /// <summary> Converts a <see cref="DataDeletionDetectionPolicy"/> into a <see cref="RequestContent"/>. </summary>
        /// <param name="model"> The <see cref="DataDeletionDetectionPolicy"/> to convert. </param>
        public static implicit operator RequestContent(DataDeletionDetectionPolicy model)
        {
            if (model is null)
            {
                return null;
            }

            return RequestContent.Create(model, ModelSerializerOptions.DefaultWireOptions);
        }

        /// <summary> Converts a <see cref="Response"/> into a <see cref="DataDeletionDetectionPolicy"/>. </summary>
        /// <param name="response"> The <see cref="Response"/> to convert. </param>
        public static explicit operator DataDeletionDetectionPolicy(Response response)
        {
            if (response is null)
            {
                return null;
            }

            using JsonDocument doc = JsonDocument.Parse(response.ContentStream);
            return DeserializeDataDeletionDetectionPolicy(doc.RootElement, ModelSerializerOptions.DefaultWireOptions);
        }
    }
}
