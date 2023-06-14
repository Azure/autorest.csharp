// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace CognitiveSearch.Models
{
    public partial class DataSource : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("name"u8);
            writer.WriteStringValue(Name);
            if (Optional.IsDefined(Description))
            {
                writer.WritePropertyName("description"u8);
                writer.WriteStringValue(Description);
            }
            writer.WritePropertyName("type"u8);
            writer.WriteStringValue(Type.ToString());
            writer.WritePropertyName("credentials"u8);
            writer.WriteObjectValue(Credentials);
            writer.WritePropertyName("container"u8);
            writer.WriteObjectValue(Container);
            if (Optional.IsDefined(DataChangeDetectionPolicy))
            {
                writer.WritePropertyName("dataChangeDetectionPolicy"u8);
                writer.WriteObjectValue(DataChangeDetectionPolicy);
            }
            if (Optional.IsDefined(DataDeletionDetectionPolicy))
            {
                writer.WritePropertyName("dataDeletionDetectionPolicy"u8);
                writer.WriteObjectValue(DataDeletionDetectionPolicy);
            }
            if (Optional.IsDefined(ETag))
            {
                writer.WritePropertyName("@odata.etag"u8);
                writer.WriteStringValue(ETag);
            }
            writer.WriteEndObject();
        }

        internal static DataSource DeserializeDataSource(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string name = default;
            Optional<string> description = default;
            DataSourceType type = default;
            DataSourceCredentials credentials = default;
            DataContainer container = default;
            Optional<DataChangeDetectionPolicy> dataChangeDetectionPolicy = default;
            Optional<DataDeletionDetectionPolicy> dataDeletionDetectionPolicy = default;
            Optional<string> odataEtag = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("name"u8))
                {
                    name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("description"u8))
                {
                    description = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("type"u8))
                {
                    type = new DataSourceType(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("credentials"u8))
                {
                    credentials = DataSourceCredentials.DeserializeDataSourceCredentials(property.Value);
                    continue;
                }
                if (property.NameEquals("container"u8))
                {
                    container = DataContainer.DeserializeDataContainer(property.Value);
                    continue;
                }
                if (property.NameEquals("dataChangeDetectionPolicy"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    dataChangeDetectionPolicy = DataChangeDetectionPolicy.DeserializeDataChangeDetectionPolicy(property.Value);
                    continue;
                }
                if (property.NameEquals("dataDeletionDetectionPolicy"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    dataDeletionDetectionPolicy = DataDeletionDetectionPolicy.DeserializeDataDeletionDetectionPolicy(property.Value);
                    continue;
                }
                if (property.NameEquals("@odata.etag"u8))
                {
                    odataEtag = property.Value.GetString();
                    continue;
                }
            }
            return new DataSource(name, description.Value, type, credentials, container, dataChangeDetectionPolicy.Value, dataDeletionDetectionPolicy.Value, odataEtag.Value);
        }
    }
}
