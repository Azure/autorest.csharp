// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

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
            writer.WritePropertyName("name");
            writer.WriteStringValue(Name);
            if (Optional.IsDefined(Description))
            {
                writer.WritePropertyName("description");
                writer.WriteStringValue(Description);
            }
            writer.WritePropertyName("type");
            writer.WriteStringValue(Type.ToString());
            writer.WritePropertyName("credentials");
            writer.WriteObjectValue(Credentials);
            writer.WritePropertyName("container");
            writer.WriteObjectValue(Container);
            if (Optional.IsDefined(DataChangeDetectionPolicy))
            {
                writer.WritePropertyName("dataChangeDetectionPolicy");
                writer.WriteObjectValue(DataChangeDetectionPolicy);
            }
            if (Optional.IsDefined(DataDeletionDetectionPolicy))
            {
                writer.WritePropertyName("dataDeletionDetectionPolicy");
                writer.WriteObjectValue(DataDeletionDetectionPolicy);
            }
            if (Optional.IsDefined(ETag))
            {
                writer.WritePropertyName("@odata.etag");
                writer.WriteStringValue(ETag);
            }
            writer.WriteEndObject();
        }

        internal static DataSource DeserializeDataSource(JsonElement element)
        {
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
                if (property.NameEquals("name"))
                {
                    name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("description"))
                {
                    description = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("type"))
                {
                    type = new DataSourceType(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("credentials"))
                {
                    credentials = DataSourceCredentials.DeserializeDataSourceCredentials(property.Value);
                    continue;
                }
                if (property.NameEquals("container"))
                {
                    container = DataContainer.DeserializeDataContainer(property.Value);
                    continue;
                }
                if (property.NameEquals("dataChangeDetectionPolicy"))
                {
                    dataChangeDetectionPolicy = DataChangeDetectionPolicy.DeserializeDataChangeDetectionPolicy(property.Value);
                    continue;
                }
                if (property.NameEquals("dataDeletionDetectionPolicy"))
                {
                    dataDeletionDetectionPolicy = DataDeletionDetectionPolicy.DeserializeDataDeletionDetectionPolicy(property.Value);
                    continue;
                }
                if (property.NameEquals("@odata.etag"))
                {
                    odataEtag = property.Value.GetString();
                    continue;
                }
            }
            return new DataSource(name, description.Value, type, credentials, container, dataChangeDetectionPolicy.Value, dataDeletionDetectionPolicy.Value, odataEtag.Value);
        }
    }
}
