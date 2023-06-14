// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace CognitiveSearch.Models
{
    public partial class DataChangeDetectionPolicy : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("@odata.type"u8);
            writer.WriteStringValue(OdataType);
            writer.WriteEndObject();
        }

        internal static DataChangeDetectionPolicy DeserializeDataChangeDetectionPolicy(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            if (element.TryGetProperty("@odata.type", out JsonElement discriminator))
            {
                switch (discriminator.GetString())
                {
                    case "#Microsoft.Azure.Search.HighWaterMarkChangeDetectionPolicy": return HighWaterMarkChangeDetectionPolicy.DeserializeHighWaterMarkChangeDetectionPolicy(element);
                    case "#Microsoft.Azure.Search.SqlIntegratedChangeTrackingPolicy": return SqlIntegratedChangeTrackingPolicy.DeserializeSqlIntegratedChangeTrackingPolicy(element);
                }
            }
            return UnknownDataChangeDetectionPolicy.DeserializeUnknownDataChangeDetectionPolicy(element);
        }
    }
}
