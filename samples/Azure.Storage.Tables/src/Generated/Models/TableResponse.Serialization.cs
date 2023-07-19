// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Text.Json;
using Azure.Core;
using Azure.Core.Serialization;

namespace Azure.Storage.Tables.Models
{
    public partial class TableResponse : IUtf8JsonSerializable, IJsonModelSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModelSerializable)this).Serialize(writer, ModelSerializerOptions.AzureServiceDefault);

        void IJsonModelSerializable.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(OdataMetadata))
            {
                writer.WritePropertyName("odata.metadata"u8);
                writer.WriteStringValue(OdataMetadata);
            }
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
            writer.WriteEndObject();
        }

        object IModelSerializable.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            using var doc = JsonDocument.Parse(data);
            return DeserializeTableResponse(doc.RootElement, options);
        }

        internal static TableResponse DeserializeTableResponse(JsonElement element, ModelSerializerOptions options = default)
        {
            options ??= ModelSerializerOptions.AzureServiceDefault;
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<string> odataMetadata = default;
            Optional<string> tableName = default;
            Optional<string> odataType = default;
            Optional<string> odataId = default;
            Optional<string> odataEditLink = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("odata.metadata"u8))
                {
                    odataMetadata = property.Value.GetString();
                    continue;
                }
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
            }
            return new TableResponse(tableName.Value, odataType.Value, odataId.Value, odataEditLink.Value, odataMetadata.Value);
        }

        object IJsonModelSerializable.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            using var doc = JsonDocument.ParseValue(ref reader);
            return DeserializeTableResponse(doc.RootElement, options);
        }
    }
}
