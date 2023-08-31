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

namespace Azure.Storage.Tables.Models
{
    public partial class TableResponseProperties : IUtf8JsonSerializable, IModelJsonSerializable<TableResponseProperties>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<TableResponseProperties>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<TableResponseProperties>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            writer.WriteStartObject();
            if (Optional.IsDefined(TableName))
            {
                writer.WritePropertyName("TableName"u8);
                writer.WriteStringValue(TableName);
            }
            if (Optional.IsDefined(OdataType))
            {
                writer.WritePropertyName("odata.type"u8);
                writer.WriteStringValue(OdataType);
            }
            if (Optional.IsDefined(OdataId))
            {
                writer.WritePropertyName("odata.id"u8);
                writer.WriteStringValue(OdataId);
            }
            if (Optional.IsDefined(OdataEditLink))
            {
                writer.WritePropertyName("odata.editLink"u8);
                writer.WriteStringValue(OdataEditLink);
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

        internal static TableResponseProperties DeserializeTableResponseProperties(JsonElement element, ModelSerializerOptions options = default)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<string> tableName = default;
            Optional<string> odataType = default;
            Optional<string> odataId = default;
            Optional<string> odataEditLink = default;
            Dictionary<string, BinaryData> rawData = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("TableName"u8))
                {
                    tableName = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("odata.type"u8))
                {
                    odataType = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("odata.id"u8))
                {
                    odataId = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("odata.editLink"u8))
                {
                    odataEditLink = property.Value.GetString();
                    continue;
                }
                if (options.Format == ModelSerializerFormat.Json)
                {
                    rawData.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                    continue;
                }
            }
            return new TableResponseProperties(tableName.Value, odataType.Value, odataId.Value, odataEditLink.Value, rawData);
        }

        TableResponseProperties IModelJsonSerializable<TableResponseProperties>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using var doc = JsonDocument.ParseValue(ref reader);
            return DeserializeTableResponseProperties(doc.RootElement, options);
        }

        BinaryData IModelSerializable<TableResponseProperties>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            return ModelSerializer.SerializeCore(this, options);
        }

        TableResponseProperties IModelSerializable<TableResponseProperties>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using var doc = JsonDocument.Parse(data);
            return DeserializeTableResponseProperties(doc.RootElement, options);
        }

        /// <summary> Converts a <see cref="TableResponseProperties"/> into a <see cref="RequestContent"/>. </summary>
        /// <param name="model"> The <see cref="TableResponseProperties"/> to convert. </param>
        public static implicit operator RequestContent(TableResponseProperties model)
        {
            if (model is null)
            {
                return null;
            }

            return RequestContent.Create(model, ModelSerializerOptions.DefaultWireOptions);
        }

        /// <summary> Converts a <see cref="Response"/> into a <see cref="TableResponseProperties"/>. </summary>
        /// <param name="response"> The <see cref="Response"/> to convert. </param>
        public static explicit operator TableResponseProperties(Response response)
        {
            if (response is null)
            {
                return null;
            }

            using JsonDocument doc = JsonDocument.Parse(response.ContentStream);
            return DeserializeTableResponseProperties(doc.RootElement, ModelSerializerOptions.DefaultWireOptions);
        }
    }
}
