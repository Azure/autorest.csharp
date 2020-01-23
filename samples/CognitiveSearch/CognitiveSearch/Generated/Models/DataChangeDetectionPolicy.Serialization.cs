// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core;

namespace CognitiveSearch.Models
{
    public partial class DataChangeDetectionPolicy : Azure.Core.IUtf8JsonSerializable
    {
        void Azure.Core.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("@odata.type");
            writer.WriteStringValue(OdataType);
            writer.WriteEndObject();
        }
        internal static CognitiveSearch.Models.DataChangeDetectionPolicy DeserializeDataChangeDetectionPolicy(System.Text.Json.JsonElement element)
        {
            if (element.TryGetProperty("@odata.type", out System.Text.Json.JsonElement discriminator))
            {
                switch (discriminator.GetString())
                {
                    case "#Microsoft.Azure.Search.HighWaterMarkChangeDetectionPolicy": return CognitiveSearch.Models.HighWaterMarkChangeDetectionPolicy.DeserializeHighWaterMarkChangeDetectionPolicy(element);
                    case "#Microsoft.Azure.Search.SqlIntegratedChangeTrackingPolicy": return CognitiveSearch.Models.SqlIntegratedChangeTrackingPolicy.DeserializeSqlIntegratedChangeTrackingPolicy(element);
                }
            }
            CognitiveSearch.Models.DataChangeDetectionPolicy result = new CognitiveSearch.Models.DataChangeDetectionPolicy();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("@odata.type"))
                {
                    result.OdataType = property.Value.GetString();
                    continue;
                }
            }
            return result;
        }
    }
}
